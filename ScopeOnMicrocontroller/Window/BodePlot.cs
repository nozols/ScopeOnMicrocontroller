/*
 * @Author Niels de Boer
 * 
 * This form displays a bode plot
 */
using ScopeOnMicrocontroller.Messages;
using System;
using System.Windows.Forms;

namespace ScopeOnMicrocontroller.Window
{
    public partial class BodePlot : Form
    {
        private int lastFrequencyAdded = 0;

        public bool IsGraphComplete
        {
            get
            {
                return lastFrequencyAdded >= chartPlot.ChartAreas[0].AxisX.Maximum;
            }
        }

        /// <summary>
        /// Create a new bode plot window
        /// </summary>
        /// <param name="minX">Minimum frequency</param>
        /// <param name="maxX">Maximum frequency</param>
        public BodePlot(int minX, int maxX)
        {
            InitializeComponent();
            chartPlot.ChartAreas[0].AxisX.Minimum = minX;
            chartPlot.ChartAreas[0].AxisX.Maximum = maxX;
            chartPlot.ChartAreas[0].AxisX.MajorGrid.Interval = Math.Pow(10, Math.Floor(Math.Log10(maxX) - 1));
        }

        /// <summary>
        /// Add a new datapoint
        /// </summary>
        /// <param name="data">The data to add</param>
        public void AddDataPoint(IncomingBodeData data)
        {
            double displayData;

            if (data.RelativeAmplitude == 0)
            {
                // Zero cannot be displayed (will be come -infinity) on a log scale, use a very low value
                displayData = -100;
            }
            else
            {
                displayData = 20 * Math.Log10(data.RelativeAmplitude);
            }

            chartPlot.Series[0].Points.AddXY(data.Frequency, displayData);

            lastFrequencyAdded = data.Frequency;
        }
    }
}
