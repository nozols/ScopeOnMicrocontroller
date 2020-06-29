namespace ScopeOnMicrocontroller.Window
{
    partial class BodePlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodePlot));
            this.chartPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPlot
            // 
            this.chartPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPlot.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.Interval = 50D;
            chartArea1.AxisX.Maximum = 1000D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 20D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.Title = "Frequency (Hz)";
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.MajorGrid.Interval = 20D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = -60D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 2D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Title = "Magnitude (dB)";
            chartArea1.Name = "ChartArea1";
            this.chartPlot.ChartAreas.Add(chartArea1);
            this.chartPlot.Location = new System.Drawing.Point(16, 15);
            this.chartPlot.Margin = new System.Windows.Forms.Padding(4);
            this.chartPlot.Name = "chartPlot";
            this.chartPlot.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "Series1";
            this.chartPlot.Series.Add(series1);
            this.chartPlot.Size = new System.Drawing.Size(1035, 620);
            this.chartPlot.TabIndex = 0;
            this.chartPlot.Text = "plot";
            title1.Name = "Title1";
            title1.Text = "Bode Plot";
            this.chartPlot.Titles.Add(title1);
            // 
            // BodePlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 650);
            this.Controls.Add(this.chartPlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BodePlot";
            this.Text = "Bode Plot";
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlot;
    }
}