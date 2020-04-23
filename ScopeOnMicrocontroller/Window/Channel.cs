/*
 * @Author Niels de Boer
 * @Date 22-april-2020
 * 
 * This class handles one channel input box
 */
using ScopeOnMicrocontroller.Messages;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ScopeOnMicrocontroller.Window
{
    class Channel
    {
        public readonly int ChannelNumber;
        /// <summary>
        /// Chart objects
        /// </summary>
        private Chart MainChart;
        private Series DataSeries;
        private DataPointCollection DataPoints;
        private Axis YAxis;
        private Axis XAxis;

        /// <summary>
        /// Inputs
        /// </summary>
        private VoltageInput YShiftVoltage;
        private VoltageInput VPerDivision;
        private CheckBox ChannelEnabled;
        private Label SampleRateLabel;

        /// <summary>
        /// Variables
        /// </summary>
        private Serial SerialInstance = Serial.GetInstance();
        private Mode CurrentMode = Mode.None;
        private int TotalRecievedSamples = 0;
        private double CurrentYShift = 0;
        private double VoltsPerDivision = 1;
        private int YDivisions = 10;
        private double ContinuousOverflows = 0;
        public static readonly int Height = 30 * 5;
        private static int ChannelsEnabled = 1;
        private int DrawCounter = 0;

        public Channel(int channelNumber, Chart chart)
        {
            ChannelNumber = channelNumber;
            MainChart = chart;
            DataSeries = chart.Series[channelNumber];
            DataPoints = chart.Series[channelNumber].Points;
            YAxis = channelNumber == 0 ? chart.ChartAreas[0].AxisY : chart.ChartAreas[0].AxisY2;
            XAxis = chart.ChartAreas[0].AxisX;
        }
        
        /// <summary>
        /// Handle an incoming ADC message for this channel
        ///  - Add to line graph
        ///  - Set sample rate
        ///  - TODO: Mode handling
        /// </summary>
        /// <param name="incomingADC"> </param>
        public void IncomingADCMessage(IncomingADC incomingADC)
        {
            if (!DoDraw())
            {
                return;
            }

            double timestampAdjustedForContinuous = incomingADC.Timestamp - ContinuousOverflows;

            DataPoints.AddXY(timestampAdjustedForContinuous, incomingADC.Volts + CurrentYShift);

            IncrementReceivedSamples(incomingADC.Timestamp);

            if (CurrentMode == Mode.Continuous)
            {
                if (ContinuousOverflows != 0)
                {
                    DataPoints.RemoveAt(0);
                }

                if (timestampAdjustedForContinuous >= XAxis.Maximum)
                {
                    ContinuousOverflows += XAxis.Maximum;

                    DataPoint emptyDataPoint = new DataPoint()
                    {
                        IsEmpty = true,
                    };

                    DataPoints.Add(emptyDataPoint);
                }
            }
        }
        
        /// <summary>
        /// Set the amount divisions on the y axis.
        /// This is directly updated on screen.
        /// </summary>
        /// <param name="yDivisions">Divisions</param>
        public void SetYDivisions(int yDivisions)
        {
            YDivisions = yDivisions;
            
            UpdateYAxis();
        }

        /// <summary>
        /// Return wether this channel is enabled
        /// </summary>
        /// <returns>Enabled</returns>
        public bool IsEnabled()
        {
            return ChannelEnabled.Checked;
        }

        /// <summary>
        /// Set the mode of the scope and update the channel accordingly
        /// </summary>
        /// <param name="mode">The current mode</param>
        public void SetMode(Mode mode)
        {
            CurrentMode = mode;
            TotalRecievedSamples = 0;
            ContinuousOverflows = 0;

            if (CurrentMode != Mode.None)
            {
                // Clear the graph
                DataPoints.Clear();
            }
        }

        /// <summary>
        /// Remove the data points that are outside of the visible range
        /// </summary>
        public void ClearChannel()
        {
            TotalRecievedSamples = 0;
            ContinuousOverflows = 0;
            DataPoints.Clear();
        }

        /// <summary>
        /// Increment the total amount of received samples
        /// </summary>
        /// <param name="totalTime">The total time that it has taken to send these samples</param>
        private void IncrementReceivedSamples(double totalTime)
        {
            TotalRecievedSamples++;
            SampleRateLabel.Text = Math.Round(TotalRecievedSamples / totalTime) + " sps";
            SampleRateLabel.Update();
        }

        
        /// <summary>
        /// If multiple channels are enabled draw a limited number of points.
        /// Points = 1/(amount of tracks)
        /// </summary>
        /// <returns>Must this point be drawn?</returns>
        private bool DoDraw()
        {
            if (ChannelsEnabled <= 1)
            {
                return true;
            }
            else
            {
                DrawCounter++;

                if (DrawCounter == ChannelsEnabled)
                {
                    DrawCounter = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #region InitialzeComponent - Code that generates the channel inputs

        /// <summary>
        /// Initialize the component
        /// </summary>
        /// <returns>Container of the component</returns>
        public GroupBox InitializeComponent(Point location)
        {
            GroupBox groupBox = new GroupBox();
            TableLayoutPanel containerLayout = new TableLayoutPanel();

            ///
            /// GroupBox main container
            ///
            groupBox.Text = "Channel " + (ChannelNumber + 1);
            groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox.Controls.Add(containerLayout);
            groupBox.Location = location;
            groupBox.Name = "groupBoxChannel" + ChannelNumber;
            groupBox.Size = new System.Drawing.Size(287, Height);
            groupBox.TabIndex = ChannelNumber;
            groupBox.TabStop = false;
            ///
            /// TableLayoutPanel main layout
            ///
            containerLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            containerLayout.Name = "tableLayoutPanelChannel" + ChannelNumber;
            containerLayout.Size = new System.Drawing.Size(274, 30 * 4);
            containerLayout.Location = new System.Drawing.Point(7, 21);
            containerLayout.TabIndex = 0;
            containerLayout.ColumnCount = 2;
            containerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            containerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            containerLayout.RowCount = 4;
            containerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            containerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            containerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            containerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            
            ///
            /// Set the labels in the first column
            ///
            containerLayout.Controls.Add(MakeLabel("YPosition", "Y-position"), 0, 0);
            containerLayout.Controls.Add(MakeLabel("VoltPerDivision", "V/Div"), 0, 1); 
            containerLayout.Controls.Add(MakeLabel("Enabled", "Enabled"), 0, 2);
            containerLayout.Controls.Add(MakeLabel("SampleRate", "Sample Rate"), 0, 3);

            ///
            /// Inputs in second column
            ///
            YShiftVoltage = new VoltageInput("YShiftVoltage" + ChannelNumber);
            containerLayout.Controls.Add(YShiftVoltage.InitializeComponent(0, 10000, -10000), 1, 0);

            VPerDivision = new VoltageInput("VoltPerDivision" + ChannelNumber);

            containerLayout.Controls.Add(VPerDivision.InitializeComponent(), 1, 1);

            ChannelEnabled = new CheckBox()
            {
                Name = "CheckboxChannelEnabled" + ChannelNumber,
                Anchor = AnchorStyles.Left,
                TabIndex = 3,
            };
            ChannelEnabled.Checked = ChannelNumber == 0;
            containerLayout.Controls.Add(ChannelEnabled, 1, 2);

            SampleRateLabel = MakeLabel("sps", "0 sps");
            containerLayout.Controls.Add(SampleRateLabel, 1, 3);

            YShiftVoltage.OnValueChanged += OnYShiftVoltageChange;
            VPerDivision.OnValueChanged += OnVoltagePerDivisionChange;
            ChannelEnabled.CheckedChanged += OnChannelEnabledChange;

            return groupBox;
        }

        /// <summary>
        /// Create a label with default settings
        /// </summary>
        /// <param name="name">Name of the label. Will be prefix by "Label" and postfixed by "ChannelX"</param>
        /// <param name="text">The text that the label must display</param>
        /// <returns>Label</returns>
        private Label MakeLabel(string name, string text)
        {
            return new Label()
            {
                Name = "Label" + name + "Channel" + ChannelNumber,
                Text = text,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
            };
        }

        #endregion

        /// <summary>
        /// Called when the checkbox to enable and disable is clicked
        /// Enables/disables the series that corresponds to this channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChannelEnabledChange(object sender, EventArgs e)
        {
            bool enabled = IsEnabled();

            DataSeries.Enabled = enabled;

            // Only change the channel status on the device 
            // when the scope is in a running mode
            if (CurrentMode != Mode.None)
            {
                SerialInstance.EnableChannel(ChannelNumber, enabled);
            }

            // Keep track of the amount of channels that are enabled
            if (enabled)
            {
                ChannelsEnabled++;
            }
            else
            {
                ChannelsEnabled--;
            }
        }

        /// <summary>
        /// Called when the volts per division of this channel has changed
        /// </summary>
        /// <param name="value">Volts per division</param>
        private void OnVoltagePerDivisionChange(double voltsPerDivision)
        {
            VoltsPerDivision = voltsPerDivision;

            UpdateYAxis();
        }

        /// <summary>
        /// Called when the Y shift voltage must change
        /// Updates all the datapoints
        /// </summary>
        /// <param name="yShift">The total y shift in volts</param>
        private void OnYShiftVoltageChange(double yShift)
        {   
            double relativeYShift = yShift - CurrentYShift;

            foreach (DataPoint dataPoint in DataPoints)
            {
                for (int i = 0; i < dataPoint.YValues.Length; i++)
                {
                    dataPoint.YValues[i] += relativeYShift;
                }
            }

            CurrentYShift = yShift;

            MainChart.Refresh();
        }

        /// <summary>
        /// Update the y-axis for this channel to the latest settings
        /// Channel.YDivisions determines the amount of divisions
        /// Channel.VoltsPerDivision determines the amount of volts per division
        /// </summary>
        private void UpdateYAxis()
        {
            YAxis.Interval = 0.5 * YDivisions * VoltsPerDivision;
            YAxis.Minimum = -0.5 * YDivisions * VoltsPerDivision;
            YAxis.Maximum = 0.5 * YDivisions * VoltsPerDivision;
            YAxis.MinorGrid.Interval = VoltsPerDivision;
            YAxis.MinorGrid.LineColor = Color.LightGray;
            YAxis.MinorGrid.LineDashStyle = ChartDashStyle.DashDot;
            YAxis.MinorGrid.Enabled = true;
            YAxis.MinorTickMark.Interval = YAxis.MinorGrid.Interval;
            YAxis.MinorTickMark.Enabled = true;
            YAxis.MinorTickMark.TickMarkStyle = TickMarkStyle.AcrossAxis;
            YAxis.LabelStyle.Interval = YAxis.MinorGrid.Interval;
        }
    }
}
