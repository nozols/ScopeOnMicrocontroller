/*
 * @Author Niels de Boer
 * @Date 22-april-2020
 * 
 * This class handles one channel input box
 */
using System.Windows.Forms;

namespace ScopeOnMicrocontroller.Window
{
    class Channel
    {
        private int ChannelNumber;
        private VoltageInput YShiftVoltage;
        private VoltageInput VPerDivision;
        private CheckBox ChannelEnabled;
        private Label SampleRateLabel;

        public static readonly int Height = 30 * 5;

        public Channel(int channelNumber)
        {
            ChannelNumber = channelNumber;
        }

        #region InitialzeComponent - Code that generates the channel inputs

        /// <summary>
        /// Initialize the component
        /// </summary>
        /// <returns>Container of the component</returns>
        public GroupBox InitializeComponent(System.Drawing.Point location)
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
            containerLayout.Controls.Add(ChannelEnabled, 1, 2);

            SampleRateLabel = MakeLabel("sps", "0 sps");
            containerLayout.Controls.Add(SampleRateLabel, 1, 3);

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
    }
}
