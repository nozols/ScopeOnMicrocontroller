/*
 * @Author Niels de Boer
 * 
 * This class handles the screen.
 *  - Mode handling
 *  - X-axis handling
 *  - Y-axis and drawing are handled in Channel
 */
using ScopeOnMicrocontroller.Messages;
using ScopeOnMicrocontroller.Window;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ScopeOnMicrocontroller
{
    /// <summary>
    /// This enum is used to communicate the mode of the scope
    /// </summary>
    enum Mode
    {
        Single, Continuous, None
    }

    public partial class Oscilloscope : Form
    {
        private Mode CurrentMode = Mode.None;

        private Channel[] Channels = new Channel[2];

        private Serial SerialInstance = Serial.GetInstance();
        private Axis XAxis;

        double ScopeStartTimestamp = -1;
        int TimerOverflows = 0;
        int SelectedBaudRate = 256000;

        public Oscilloscope()
        {
            InitializeComponent();
            // Add event listener for new ADC data
            Serial.GetInstance().ADCSerialDataReceived += Oscilloscope_SerialDataReceived;

            // Set the default values for the dropdown boxes
            comboBoxTimePrefix.SelectedIndex = 2;

            // Always show axes even if series are disabled
            MainChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            MainChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            MainChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

            XAxis = MainChart.ChartAreas[0].AxisX;

            DoubleBuffered = true;

            InitializeChannels();

            // Update
            UpdateAvailableComDevices();
            UpdateXAxis();
            UpdateYAxes();
            SetModeButtonsStatus();

            UpdateMode(Mode.None);
        }

        /// <summary>
        /// Hanlde an incoming ADC message
        /// </summary>
        /// <param name="incomingADC">THe message</param>
        private void IncomingADCMessage(IncomingADC incomingADC)
        {
            // Adjust the timer for the overflows
            incomingADC.SetTimerOverflows(TimerOverflows);

            if (ScopeStartTimestamp == -1)
            {
                // This is the first data that was received
                ScopeStartTimestamp = incomingADC.Timestamp;
            }

            // Adjust the timer for the start time
            incomingADC.SetStartTime(ScopeStartTimestamp);

            // Hand off the the channel instance for drawing
            Channels[incomingADC.Channel].IncomingADCMessage(incomingADC);

            // If the mode is single we set the mode to zero
            // if the end of the graph is reached
            // Continous mode handling is done inside of the seperate channels
            if (CurrentMode == Mode.Single)
            {
                if (incomingADC.Timestamp >= XAxis.Maximum)
                {
                    UpdateMode(Mode.None);
                }
            }
        }

        /// <summary>
        /// Called when a IncomingTimerOverflow message has been recieved
        /// </summary>
        private void IncomingTimerOverflow()
        {
            TimerOverflows++;
        }

        /// <summary>
        /// Callback for when new serial data has arrived
        /// </summary>
        /// <param name="serialData">The serial data</param>
        private void Oscilloscope_SerialDataReceived(IncomingMessage serialData)
        {
            // This is needed because the event comes from a different thread
            if (InvokeRequired)
            {
                // Re-create method call
                var callback = new Serial.ADCSerialDataReceivedHandler(Oscilloscope_SerialDataReceived);
                BeginInvoke(callback, new object[] { serialData });
            }
            else
            {
                if (serialData is IncomingADC)
                {
                    // Only draw when the mode is set
                    if (CurrentMode != Mode.None)
                    {
                        IncomingADCMessage((IncomingADC)serialData);
                    }
                }
                else if (serialData is IncomingTimerOverflow)
                {
                    IncomingTimerOverflow();
                }
            }
        }

        #region Functions/events for connecting to serial devices

        /// <summary>
        /// This function will update comboBoxDevices to contain all the currently
        /// connected serial devices.
        /// </summary>
        private void UpdateAvailableComDevices()
        {
            // Get all the available port names
            string[] devices = SerialPort.GetPortNames();

            // Clear the list
            comboBoxDevices.Items.Clear();

            // Add devices
            comboBoxDevices.Items.AddRange(devices);

            if (!Serial.GetInstance().IsConnected)
            {
                // If device(s) is/are available select the first one
                if (comboBoxDevices.Items.Count > 0)
                {
                    comboBoxDevices.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Called when the refresh button is clicked.
        /// Will call UpdateAvailableComDevices()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateAvailableComDevices();
        }

        /// <summary>
        /// Enable or disable the mode buttons if a device is connected
        /// </summary>
        private void SetModeButtonsStatus()
        {
            bool connected = SerialInstance.IsConnected;

            buttonSingle.Enabled = connected;
            buttonContinuous.Enabled = connected;
            comboBoxDevices.Enabled = !connected;
            comboBoxBaudRate.Enabled = !connected;
        }

        private void comboBoxBaudRate_TextChanged(object sender, EventArgs e)
        {
            if(!int.TryParse(comboBoxBaudRate.Text, out int baudrate))
            {
                comboBoxBaudRate.SelectedIndex = 2;
            }
            else
            {
                SelectedBaudRate = baudrate;
            }
        }

        /// <summary>
        /// Called when the connect/disconnect button is clicked.
        /// The button toggles between connect and disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (Serial.GetInstance().IsConnected)
            {
                Serial.GetInstance().Disconnect();
                buttonConnect.Text = "Connect";
                labelInfoConnection.Text = "Not Connected";
            }
            else
            {
                Serial.GetInstance().Connect(comboBoxDevices.Text, SelectedBaudRate);
                buttonConnect.Text = "Disconnect";
                labelInfoConnection.Text = comboBoxDevices.Text + " @ " + SelectedBaudRate + " baud";
            }


            UpdateMode(Mode.None);
            SetModeButtonsStatus();
        }

        #endregion

        #region Functions/events for changing the axis

        /// <summary>
        /// This function will parse the textual representation of the
        /// time to a numerical value that is defined in the reference.
        /// </summary>
        /// <returns>Numerical value of time prefix</returns>
        double GetTimePrefixFactor()
        {
            Reference.TimePrefixFactors.TryGetValue(comboBoxTimePrefix.Text, out double result);

            return result;
        }

        /// <summary>
        /// Get the amount of divisions that must be shown on the x axis
        /// </summary>
        /// <returns>X divisions</returns>
        int GetXDivisions()
        {
            return decimal.ToInt32(numericXDivisions.Value);
        }

        /// <summary>
        /// Get the amount of divisions that must be shown on the y axis
        /// </summary>
        /// <returns>Y divisions</returns>
        int GetYDivisions()
        {
            return decimal.ToInt32(numericYDivisions.Value);
        }

        /// <summary>
        /// Update the x axis based on the inputs
        ///  - Set the interval
        ///  - Set minimum to 0
        ///  - Set maximum to divisions * interval
        ///  - Set new title
        /// </summary>
        void UpdateXAxis()
        {
            double timePerDivision = GetTimePrefixFactor() * decimal.ToDouble(timeFactor.Value);

            Axis xAxis = MainChart.ChartAreas[0].AxisX;

            Reference.TimePrefixFormatters.TryGetValue(comboBoxTimePrefix.Text, out string prefixFormatter);
            xAxis.Interval = timePerDivision;
            xAxis.Minimum = 0;
            xAxis.Maximum = timePerDivision * GetXDivisions();
            xAxis.MajorGrid.LineColor = Color.LightGray;
            xAxis.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            xAxis.MajorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            xAxis.LabelStyle.Angle = -45;
            xAxis.LabelStyle.Format = prefixFormatter;
            xAxis.Title = timeFactor.Value + " " + comboBoxTimePrefix.Text + "/div";           

            // Clear the channels if we are currently running
            if (CurrentMode != Mode.None)
            {
                ClearChannels();
            }

            MainChart.Update();
        }

        #endregion

        #region The following functions are for updating the axes when an input has changed

        private void timeFactor_ValueChanged(object sender, EventArgs e)
        {
            UpdateXAxis();
        }

        private void comboBoxTimePrefix_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateXAxis();
        }

        private void numericXDivisions_ValueChanged(object sender, EventArgs e)
        {
            UpdateXAxis();
        }

        private void numericYDivisions_ValueChanged(object sender, EventArgs e)
        {
            UpdateYAxes();
        }

        #endregion

        #region Functions for setting the mode

        /// <summary>
        /// Set the mode of the scope
        /// </summary>
        /// <param name="mode">The mode to change to</param>
        void UpdateMode(Mode mode)
        {
            CurrentMode = mode;
            SetChannelMode(mode);
            ScopeStartTimestamp = -1;

            if (mode == Mode.Single)
            {
                buttonSingle.BackColor = Color.LawnGreen;
                buttonContinuous.BackColor = Color.Salmon;
                SyncChannelEnabled();
            }
            else if (mode == Mode.Continuous)
            {
                buttonSingle.BackColor = Color.Salmon;
                buttonContinuous.BackColor = Color.LawnGreen;
                SyncChannelEnabled();
            }
            else
            {
                buttonSingle.BackColor = Color.Salmon;
                buttonContinuous.BackColor = Color.Salmon;
                SerialInstance.SetScopeEnabled(false, false);
            }
        }

        /// <summary>
        /// This function is called when the single buttons is clicked.
        /// It sets the mode of the scope
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSingle_Click(object sender, EventArgs e)
        {
            if (CurrentMode == Mode.Single)
            {
                UpdateMode(Mode.None);
            } else
            {
                UpdateMode(Mode.Single);
            }    
            
        }

        /// <summary>
        /// THis function is called when the continuous button is clicked.
        /// It sets the mode of the scope
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinuous_Click(object sender, EventArgs e)
        {
            if (CurrentMode == Mode.Continuous)
            {
                UpdateMode(Mode.None);
            }
            else
            {
                UpdateMode(Mode.Continuous);
            }
            
        }

        #endregion

        #region Functions for interacting with both channels

        /// <summary>
        /// Initialize the two channels
        /// </summary>
        void InitializeChannels()
        {
            for (int channelNumber = 0; channelNumber < Channels.Length; channelNumber++)
            {
                Channels[channelNumber] = new Channel(channelNumber, MainChart);
                Controls.Add(Channels[channelNumber].InitializeComponent(new Point(645, 233 + Channel.Height * channelNumber)));
            }
        }

        /// <summary>
        /// Update the styles of the y axes of the channels
        /// </summary>
        void UpdateYAxes()
        {
            foreach (Channel channel in Channels)
            {
                channel.SetYDivisions(GetYDivisions());
            }
        }

        /// <summary>
        /// Sync the enabled checkboxes with the device
        /// </summary>
        void SyncChannelEnabled()
        {
            foreach (Channel channel in Channels)
            {
                SerialInstance.EnableChannel(channel.ChannelNumber, channel.IsEnabled());
            }
        }

        /// <summary>
        /// Set the mode of the channels
        /// </summary>
        /// <param name="mode">Channel mode</param>
        void SetChannelMode(Mode mode)
        {
            foreach (Channel channel in Channels)
            {
                channel.SetMode(mode);
            }
        }

        /// <summary>
        /// Remove the datapoints that are not visible
        /// </summary>
        void ClearChannels()
        {
            ScopeStartTimestamp = -1;

            foreach (Channel channel in Channels)
            {
                channel.ClearChannel();
            }
        }

        #endregion

        private void Oscilloscope_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialInstance.Disconnect();
        }
    }
}
