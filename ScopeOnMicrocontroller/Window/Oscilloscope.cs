using ScopeOnMicrocontroller.Messages;
using ScopeOnMicrocontroller.Window;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ScopeOnMicrocontroller
{
    enum Mode
    {
        Single, Continuous, None
    }

    public partial class Oscilloscope : Form
    {
        private const int CHANNEL_1 = 0;
        private const int CHANNEL_2 = 1;
        private int TimerOverflows = 0;
        private double StartElapsed = 0;
        private double[] CurrentShiftChannel = { 0, 0 };
        private Mode CurrentMode = Mode.None;
        private int[] TotalReceivedSamples = new int[] { 0, 0 };
        private double ShiftY = 0;

        private Channel[] Channels = new Channel[2];

        public Oscilloscope()
        {
            InitializeComponent();

            // Add event listener for new ADC data
            Serial.GetInstance().ADCSerialDataReceived += Oscilloscope_ADCSerialDataReceived;

            // Set the default values for the dropdown boxes
            comboBoxTimePrefix.SelectedIndex = 2;
            comboBoxVoltagePrefixChannel1.SelectedIndex = 1;
            comboBoxVoltagePrefixChannel2.SelectedIndex = 1;
            comboBoxShiftPrefixChannel1.SelectedIndex = 1;
            comboBoxShiftPrefixChannel2.SelectedIndex = 1;

            // Always show axes even if series are disabled
            MainChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            MainChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            MainChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            
            // Update
            UpdateAvailableComDevices();
            UpdateXAxis();
            UpdateYAxes();
            UpdateModeButtons();

            UpdateMode(Mode.None);

            
            for (int channelNumber = 0; channelNumber < Channels.Length; channelNumber++)
            {
                Channels[channelNumber] = new Channel(channelNumber);
                Controls.Add(Channels[channelNumber].InitializeComponent(new Point(450, 50 + Channel.Height * channelNumber)));
            }
            
        }

        private void IncomingADCMessage(IncomingADC incomingADC)
        {
            incomingADC.SetTimerOverflows(TimerOverflows);

            // Check if the this is the first data that has come in
            if (StartElapsed == 0)
            {
                // Since this is the first data that has come in, set this as the reference
                StartElapsed = incomingADC.Timestamp;
            }

            double secondsSinceStart = (incomingADC.Timestamp - StartElapsed) - ShiftY;

            // Add the point to the appropriate series
            // X = seconds since the first data
            // Y = Volts + shift
            MainChart.Series[incomingADC.Channel].Points.AddXY(secondsSinceStart, incomingADC.Volts + CurrentShiftChannel[incomingADC.Channel]);

            TotalReceivedSamples[incomingADC.Channel]++;
            
            if (incomingADC.Channel == CHANNEL_1)
            {
                labelSampleRateChannel0.Text = Math.Round(TotalReceivedSamples[incomingADC.Channel] / secondsSinceStart) + " sps";
            }
            else
            {
                labelSampleRateChannel1.Text = Math.Round(TotalReceivedSamples[incomingADC.Channel] / secondsSinceStart) + " sps";
            }
            

            if (CurrentMode == Mode.Single)
            {
                if (MainChart.ChartAreas[0].AxisX.Maximum <= secondsSinceStart)
                {
                    UpdateMode(Mode.None);
                }
            }
            else if (CurrentMode == Mode.Continuous)
            {
                if (MainChart.ChartAreas[0].AxisX.Maximum <= secondsSinceStart)
                {
                    ShiftY += MainChart.ChartAreas[0].AxisX.Maximum;
                    
                    DataPoint dp = new DataPoint
                    {
                        IsEmpty = true
                    };                    

                    if (MainChart.Series[0].Points.Count > 0)
                        MainChart.Series[0].Points.Add(dp);

                    if (MainChart.Series[1].Points.Count > 0)
                        MainChart.Series[1].Points.Add(dp);
                }

                if (ShiftY != 0)
                {
                    if (MainChart.Series[incomingADC.Channel].Points.Count > 0)
                        MainChart.Series[incomingADC.Channel].Points.RemoveAt(0);
                }
            }
        }

        private void IncomingTimerOverflow(IncomingTimerOverflow incomingTimerOverflow)
        {
            TimerOverflows++;
        }

        /// <summary>
        /// Reset the graph to its default state
        ///  - Set start time to zero
        ///  - Set the mode to None
        ///  - Set timer overflow counter to zero
        ///  - Set subtract y to zero
        ///  - Set total samples received to zero
        ///  - Clear the graph lines
        /// </summary>
        void ResetGraph()
        {
            StartElapsed = 0;
            CurrentMode = Mode.None;
            TimerOverflows = 0;
            ShiftY = 0;
            TotalReceivedSamples = new int[] { 0, 0 };
            MainChart.Series[0].Points.Clear();
            MainChart.Series[1].Points.Clear();
        }

        /// <summary>
        /// Callback for when new serial data has arrived
        /// </summary>
        /// <param name="serialData">The serial data</param>
        private void Oscilloscope_ADCSerialDataReceived(IncomingMessage serialData)
        {
            // This is needed because the event comes from a different thread
            if (InvokeRequired)
            {
                // Re-create method call
                var callback = new Serial.ADCSerialDataReceivedHandler(Oscilloscope_ADCSerialDataReceived);
                BeginInvoke(callback, new object[] { serialData });
            }
            else
            {
                if (serialData is IncomingADC)
                {
                    IncomingADCMessage((IncomingADC)serialData);
                }
                else if (serialData is IncomingTimerOverflow)
                {
                    IncomingTimerOverflow((IncomingTimerOverflow)serialData);
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

        private void UpdateModeButtons()
        {
            bool connected = Serial.GetInstance().IsConnected;

            buttonSingle.Enabled = connected;
            buttonContinuous.Enabled = connected;
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
                // Reset the start time
                StartElapsed = 0;
                buttonConnect.Text = "Connect";
            }
            else
            {
                Serial.GetInstance().Connect(comboBoxDevices.Text);
                // Clear the old data
                MainChart.Series[0].Points.Clear();
                MainChart.Series[1].Points.Clear();
                buttonConnect.Text = "Disconnect";

                UpdateMode(Mode.None);
            }

            UpdateModeButtons();
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
        /// This function will parse the SI units of voltage
        /// to a numerical factor
        /// </summary>
        /// <param name="channel">For which channel</param>
        /// <returns>Voltage multiplication factor</returns>
        double GetVoltagePrefixFactor(int channel)
        {
            if (channel == CHANNEL_1)
            {
                Reference.VoltagePrefixFactors.TryGetValue(comboBoxVoltagePrefixChannel1.Text, out double result);

                return result;
            }
            else
            {
                Reference.VoltagePrefixFactors.TryGetValue(comboBoxVoltagePrefixChannel2.Text, out double result);

                return result;
            }
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

            if (CurrentMode != Mode.None)
            {
                MainChart.Series[0].Points.Clear();
                MainChart.Series[1].Points.Clear();
                StartElapsed = 0;
            }
            

            MainChart.Update();
        }

        /// <summary>
        /// Update both the Y axes by calling UpdateYAxis()
        /// </summary>
        void UpdateYAxes()
        {
            // Update channel 1
            UpdateYAxis(decimal.ToDouble(mVDivChannel1.Value) * GetVoltagePrefixFactor(CHANNEL_1), MainChart.ChartAreas[0].AxisY);

            // Update channel 2
            UpdateYAxis(decimal.ToDouble(mVDivChannel2.Value) * GetVoltagePrefixFactor(CHANNEL_2), MainChart.ChartAreas[0].AxisY2);

            MainChart.Update();
        }

        /// <summary>
        /// Update an y Axis
        ///  - Set the interval (voltagePerDivision)
        ///  - Set minimum 
        ///  - Set maximum
        /// </summary>
        /// <param name="voltagePerDivision">How many volts per division</param>
        /// <param name="yAxis">The axis to modify</param>
        void UpdateYAxis(double voltagePerDivision, Axis yAxis)
        {           int yDivision = GetYDivisions();

            yAxis.Interval = 0.5 * yDivision * voltagePerDivision;
            yAxis.Minimum = -0.5 * GetYDivisions() * voltagePerDivision;
            yAxis.Maximum = 0.5 * GetYDivisions() * voltagePerDivision;
            yAxis.MinorGrid.Interval = voltagePerDivision;
            yAxis.MinorGrid.LineColor = Color.LightGray;
            yAxis.MinorGrid.LineDashStyle = ChartDashStyle.DashDot;
            yAxis.MinorGrid.Enabled = true;
            yAxis.MinorTickMark.Interval = yAxis.MinorGrid.Interval;
            yAxis.MinorTickMark.Enabled = true;
            yAxis.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            yAxis.LabelStyle.Interval = yAxis.MinorGrid.Interval;
        }

        #region The following functions are for updating the axes when an input has changed

        private void timeFactor_ValueChanged(object sender, EventArgs e)
        {
            UpdateXAxis();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateXAxis();
        }

        private void mVDivChannel1_ValueChanged(object sender, EventArgs e)
        {
            UpdateYAxes();
        }

        private void mVDivChannel2_ValueChanged(object sender, EventArgs e)
        {
            UpdateYAxes();
        }

        private void numericXDivisions_ValueChanged(object sender, EventArgs e)
        {
            UpdateXAxis();
        }

        private void numericYDivisions_ValueChanged(object sender, EventArgs e)
        {
            UpdateYAxes();
        }

        private void comboBoxVoltagePrefixChannel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateYAxes();
        }

        private void comboBoxVoltagePrefixChannel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateYAxes();
        }

        #endregion

        #endregion

        #region The following functions are for shifting the two channels up and down

        /// <summary>
        /// Update the channel shift for a channel
        /// - The Values are fetched and adjusted
        /// - passed to UpdateChannelShift(int, double)
        /// </summary>
        /// <param name="channel"></param>
        void UpdateChannelShift(int channel)
        {
            if (channel == CHANNEL_1)
            {
                Reference.VoltagePrefixFactors.TryGetValue(comboBoxShiftPrefixChannel1.Text, out double shiftFactor);
                shiftFactor *= decimal.ToDouble(yPosChannel1.Value);
                UpdateChannelShift(channel, shiftFactor);
            }
            else
            {
                Reference.VoltagePrefixFactors.TryGetValue(comboBoxShiftPrefixChannel2.Text, out double shiftFactor);
                shiftFactor *= decimal.ToDouble(yPosChannel2.Value);
                UpdateChannelShift(channel, shiftFactor);
            }
        }

        /// <summary>
        /// Set the channel shift to a specific amount
        /// </summary>
        /// <param name="channel">Channel to shift</param>
        /// <param name="amount">Set shift to</param>
        void UpdateChannelShift(int channel, double amount)
        {
            // Calculate by which amount the line should actually be shifted
            double amountToShift = amount - CurrentShiftChannel[channel];

            // Adjust each y point
            foreach (DataPoint point in MainChart.Series[channel].Points)
            {
                for(int i = 0; i < point.YValues.Length; i++)
                {
                    point.YValues[i] += amountToShift;
                }
            }

            // Update the current shift
            CurrentShiftChannel[channel] = amount;
        }


        private void yPosChannel2_ValueChanged(object sender, EventArgs e)
        {
            UpdateChannelShift(CHANNEL_2);
        }

        private void comboBoxShiftPrefixChannel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChannelShift(CHANNEL_2);
        }

        private void yPosChannel1_ValueChanged(object sender, EventArgs e)
        {
            UpdateChannelShift(CHANNEL_1);
        }

        private void comboBoxShiftPrefixChannel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChannelShift(CHANNEL_1);
        }

        #endregion

        #region Functions for enabeling/disabeling channels

        private void SetScopesAccordingToCheckboxes()
        {
            Serial.GetInstance().SetScopeEnabled(EnableChannel1.Checked, EnableChannel2.Checked);
        }

        private void EnableChannel2_CheckedChanged(object sender, EventArgs e)
        {
            MainChart.Series[CHANNEL_2].Enabled = EnableChannel2.Checked;

            SetScopesAccordingToCheckboxes();
        }

        private void EnableChannel1_CheckedChanged(object sender, EventArgs e)
        {
            MainChart.Series[CHANNEL_1].Enabled = EnableChannel1.Checked;

            SetScopesAccordingToCheckboxes();
        }

        #endregion

        #region Functions for setting the mode

        /// <summary>
        /// Set the mode of the scope
        /// </summary>
        /// <param name="mode">The mode to change to</param>
        void UpdateMode(Mode mode)
        {
            Console.WriteLine(mode);
            if (mode == Mode.None)
            {
                Serial.GetInstance().SetScopeEnabled(false, false);
                buttonSingle.BackColor = Color.Salmon;
                buttonContinuous.BackColor = Color.Salmon;
            }
            else if (mode == Mode.Single)
            {
                ResetGraph();
                SetScopesAccordingToCheckboxes();
                buttonSingle.BackColor = Color.DarkSeaGreen;
            }
            else if (mode == Mode.Continuous)
            {
                ResetGraph();
                SetScopesAccordingToCheckboxes();
                buttonContinuous.BackColor = Color.DarkSeaGreen;
            }
            CurrentMode = mode;
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
    }
}
