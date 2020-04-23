namespace ScopeOnMicrocontroller
{
    partial class Oscilloscope
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Oscilloscope));
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSingle = new System.Windows.Forms.Button();
            this.buttonContinuous = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timeFactor = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTimePrefix = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.numericYDivisions = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericXDivisions = new System.Windows.Forms.NumericUpDown();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelInfoConnection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeFactor)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericYDivisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXDivisions)).BeginInit();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            this.MainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainChart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisY.Title = "mV (Channel 1)";
            chartArea1.AxisY2.Title = "mV (Channel 2)";
            chartArea1.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea1);
            this.MainChart.Location = new System.Drawing.Point(12, 12);
            this.MainChart.Name = "MainChart";
            this.MainChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Name = "Series2";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.MainChart.Series.Add(series1);
            this.MainChart.Series.Add(series2);
            this.MainChart.Size = new System.Drawing.Size(627, 568);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            // 
            // buttonSingle
            // 
            this.buttonSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSingle.BackColor = System.Drawing.Color.Salmon;
            this.buttonSingle.Location = new System.Drawing.Point(643, 40);
            this.buttonSingle.Name = "buttonSingle";
            this.buttonSingle.Size = new System.Drawing.Size(75, 23);
            this.buttonSingle.TabIndex = 2;
            this.buttonSingle.Text = "Single";
            this.buttonSingle.UseVisualStyleBackColor = false;
            this.buttonSingle.Click += new System.EventHandler(this.buttonSingle_Click);
            // 
            // buttonContinuous
            // 
            this.buttonContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinuous.BackColor = System.Drawing.Color.Salmon;
            this.buttonContinuous.Location = new System.Drawing.Point(724, 40);
            this.buttonContinuous.Name = "buttonContinuous";
            this.buttonContinuous.Size = new System.Drawing.Size(75, 23);
            this.buttonContinuous.TabIndex = 3;
            this.buttonContinuous.Text = "Continuous";
            this.buttonContinuous.UseVisualStyleBackColor = false;
            this.buttonContinuous.Click += new System.EventHandler(this.buttonContinuous_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(855, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(826, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(23, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "↻";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(643, 13);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(75, 21);
            this.comboBoxDevices.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.timeFactor);
            this.groupBox2.Controls.Add(this.comboBoxTimePrefix);
            this.groupBox2.Location = new System.Drawing.Point(645, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 44);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X-axis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Time/Div";
            // 
            // timeFactor
            // 
            this.timeFactor.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeFactor.Location = new System.Drawing.Point(146, 14);
            this.timeFactor.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.timeFactor.Name = "timeFactor";
            this.timeFactor.Size = new System.Drawing.Size(87, 20);
            this.timeFactor.TabIndex = 1;
            this.timeFactor.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.timeFactor.ValueChanged += new System.EventHandler(this.timeFactor_ValueChanged);
            // 
            // comboBoxTimePrefix
            // 
            this.comboBoxTimePrefix.DisplayMember = "ms";
            this.comboBoxTimePrefix.FormattingEnabled = true;
            this.comboBoxTimePrefix.Items.AddRange(new object[] {
            "ns",
            "us",
            "ms",
            "s"});
            this.comboBoxTimePrefix.Location = new System.Drawing.Point(239, 14);
            this.comboBoxTimePrefix.Name = "comboBoxTimePrefix";
            this.comboBoxTimePrefix.Size = new System.Drawing.Size(38, 21);
            this.comboBoxTimePrefix.TabIndex = 0;
            this.comboBoxTimePrefix.ValueMember = "ms";
            this.comboBoxTimePrefix.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimePrefix_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(645, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 108);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zoom";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.numericYDivisions, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericXDivisions, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(273, 80);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // numericYDivisions
            // 
            this.numericYDivisions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericYDivisions.Location = new System.Drawing.Point(139, 50);
            this.numericYDivisions.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericYDivisions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericYDivisions.Name = "numericYDivisions";
            this.numericYDivisions.Size = new System.Drawing.Size(131, 20);
            this.numericYDivisions.TabIndex = 4;
            this.numericYDivisions.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericYDivisions.ValueChanged += new System.EventHandler(this.numericYDivisions_ValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Y-Divisions";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "X-Divisions";
            // 
            // numericXDivisions
            // 
            this.numericXDivisions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericXDivisions.Location = new System.Drawing.Point(139, 10);
            this.numericXDivisions.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericXDivisions.Name = "numericXDivisions";
            this.numericXDivisions.Size = new System.Drawing.Size(131, 20);
            this.numericXDivisions.TabIndex = 3;
            this.numericXDivisions.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericXDivisions.ValueChanged += new System.EventHandler(this.numericXDivisions_ValueChanged);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "115200",
            "230400",
            "256000",
            "400000",
            "500000"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(725, 13);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(95, 21);
            this.comboBoxBaudRate.TabIndex = 9;
            this.comboBoxBaudRate.Text = "256000";
            this.comboBoxBaudRate.TextChanged += new System.EventHandler(this.comboBoxBaudRate_TextChanged);
            // 
            // labelInfoConnection
            // 
            this.labelInfoConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfoConnection.AutoSize = true;
            this.labelInfoConnection.Location = new System.Drawing.Point(805, 45);
            this.labelInfoConnection.Name = "labelInfoConnection";
            this.labelInfoConnection.Size = new System.Drawing.Size(79, 13);
            this.labelInfoConnection.TabIndex = 10;
            this.labelInfoConnection.Text = "Not Connected";
            // 
            // Oscilloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 592);
            this.Controls.Add(this.labelInfoConnection);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonContinuous);
            this.Controls.Add(this.buttonSingle);
            this.Controls.Add(this.MainChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Oscilloscope";
            this.Text = "Oscilloscope on a microcontroller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Oscilloscope_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeFactor)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericYDivisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXDivisions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSingle;
        private System.Windows.Forms.Button buttonContinuous;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxTimePrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown timeFactor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numericYDivisions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericXDivisions;
        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelInfoConnection;
    }
}

