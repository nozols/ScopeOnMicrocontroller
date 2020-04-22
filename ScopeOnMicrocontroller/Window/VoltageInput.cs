/*
 * @Author Niels de Boer
 * @Date 22-april-2020
 * 
 * This class can be used to combine a NumericUpDown and a ComboBox to selected
 * voltages. NumericUpDown can be used to input 0 to 10000 and the ComboBox is
 * used to determine the factor (uV, mV, V)
 */
using System;
using System.Windows.Forms;

namespace ScopeOnMicrocontroller.Window
{
    class VoltageInput
    {
        private readonly string Name;
        private NumericUpDown Volt;
        private ComboBox Prefix;
        public delegate void ValueChanged(double value);
        /// <summary>
        /// This event is thrown when the value of this input has changed
        /// </summary>
        public event ValueChanged OnValueChanged;

        /// <summary>
        /// Create an instance
        /// </summary>
        /// <param name="name">Unique name of the generated inputs</param>
        public VoltageInput(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Get the value of this input.
        /// </summary>
        /// <returns>Volt value</returns>
        public double GetValue()
        {
            Reference.VoltagePrefixFactors.TryGetValue((string)Prefix.SelectedItem, out double prefixValue);
            
            return prefixValue * decimal.ToDouble(Volt.Value);
        }

        /// <summary>
        /// Initialize the component
        /// </summary>
        /// <param name="defaultValue">Default numeric value</param>
        /// <param name="maximum">Maximum value of NumericUpDown</param>
        /// <param name="minimum">Minimum value of NumericUpDown</param>
        /// <returns></returns>
        public TableLayoutPanel InitializeComponent(decimal defaultValue = 1000, decimal maximum = 10000, decimal minimum = 0)
        {
            TableLayoutPanel layout = new TableLayoutPanel()
            {
                RowCount = 1,
                ColumnCount = 2,
                Anchor = AnchorStyles.Left,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Volt = new NumericUpDown()
            {
                Name = "NumericUpDown" + Name,
                Anchor = AnchorStyles.Left,
                Maximum = maximum,
                Minimum = minimum,
                TabIndex = 0,
                Value = defaultValue,
            };

            Prefix = new ComboBox()
            {
                Name = "ComboBoxPrefix" + Name,
                Anchor = AnchorStyles.Right,
                FormattingEnabled = true,
                TabIndex = 1,
            };

            Prefix.Items.AddRange(new object[]
            {
                "uV",
                "mV",
                "V"
            });

            Prefix.SelectedItem = "mV";

            Prefix.SelectedIndexChanged += PrefixChanged;
            Volt.ValueChanged += VoltChanged;

            layout.Controls.Add(Volt, 0, 0);
            layout.Controls.Add(Prefix, 1, 0);

            return layout;
        }

        /// <summary>
        /// Event for when the volt input has changed.
        /// Triggers OnValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VoltChanged(object sender, EventArgs e)
        {
            OnValueChanged?.Invoke(GetValue());
        }

        /// <summary>
        /// Event for when the prefix has changed
        /// Triggers OnValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrefixChanged(object sender, EventArgs e)
        {
            OnValueChanged?.Invoke(GetValue());
        }
    }
}
