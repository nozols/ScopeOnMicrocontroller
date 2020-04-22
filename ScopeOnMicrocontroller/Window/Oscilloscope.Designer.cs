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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Oscilloscope));
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.boxChannel1 = new System.Windows.Forms.GroupBox();
            this.comboBoxShiftPrefixChannel1 = new System.Windows.Forms.ComboBox();
            this.comboBoxVoltagePrefixChannel1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.yPosChannel1 = new System.Windows.Forms.NumericUpDown();
            this.mVDivChannel1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.EnableChannel1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSampleRateChannel0 = new System.Windows.Forms.Label();
            this.buttonSingle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxShiftPrefixChannel2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yPosChannel2 = new System.Windows.Forms.NumericUpDown();
            this.mVDivChannel2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.EnableChannel2 = new System.Windows.Forms.CheckBox();
            this.labelSampleRateChannel1 = new System.Windows.Forms.Label();
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
            this.comboBoxVoltagePrefixChannel2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.boxChannel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yPosChannel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mVDivChannel1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yPosChannel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mVDivChannel2)).BeginInit();
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
            this.MainChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.MainChart.Size = new System.Drawing.Size(426, 586);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            // 
            // boxChannel1
            // 
            this.boxChannel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxChannel1.Controls.Add(this.comboBoxShiftPrefixChannel1);
            this.boxChannel1.Controls.Add(this.comboBoxVoltagePrefixChannel1);
            this.boxChannel1.Controls.Add(this.tableLayoutPanel1);
            this.boxChannel1.Location = new System.Drawing.Point(812, 233);
            this.boxChannel1.Name = "boxChannel1";
            this.boxChannel1.Size = new System.Drawing.Size(287, 186);
            this.boxChannel1.TabIndex = 1;
            this.boxChannel1.TabStop = false;
            this.boxChannel1.Text = "Channel 1";
            // 
            // comboBoxShiftPrefixChannel1
            // 
            this.comboBoxShiftPrefixChannel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShiftPrefixChannel1.FormattingEnabled = true;
            this.comboBoxShiftPrefixChannel1.Items.AddRange(new object[] {
            "uV",
            "mV",
            "V"});
            this.comboBoxShiftPrefixChannel1.Location = new System.Drawing.Point(240, 30);
            this.comboBoxShiftPrefixChannel1.Name = "comboBoxShiftPrefixChannel1";
            this.comboBoxShiftPrefixChannel1.Size = new System.Drawing.Size(38, 21);
            this.comboBoxShiftPrefixChannel1.TabIndex = 4;
            this.comboBoxShiftPrefixChannel1.SelectedIndexChanged += new System.EventHandler(this.comboBoxShiftPrefixChannel1_SelectedIndexChanged);
            // 
            // comboBoxVoltagePrefixChannel1
            // 
            this.comboBoxVoltagePrefixChannel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVoltagePrefixChannel1.FormattingEnabled = true;
            this.comboBoxVoltagePrefixChannel1.Items.AddRange(new object[] {
            "uV",
            "mV",
            "V"});
            this.comboBoxVoltagePrefixChannel1.Location = new System.Drawing.Point(240, 70);
            this.comboBoxVoltagePrefixChannel1.Name = "comboBoxVoltagePrefixChannel1";
            this.comboBoxVoltagePrefixChannel1.Size = new System.Drawing.Size(38, 21);
            this.comboBoxVoltagePrefixChannel1.TabIndex = 3;
            this.comboBoxVoltagePrefixChannel1.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoltagePrefixChannel1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.yPosChannel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mVDivChannel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EnableChannel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSampleRateChannel0, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 166);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "mV/Div";
            // 
            // yPosChannel1
            // 
            this.yPosChannel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.yPosChannel1.Location = new System.Drawing.Point(140, 10);
            this.yPosChannel1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yPosChannel1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.yPosChannel1.Name = "yPosChannel1";
            this.yPosChannel1.Size = new System.Drawing.Size(87, 20);
            this.yPosChannel1.TabIndex = 0;
            this.yPosChannel1.ValueChanged += new System.EventHandler(this.yPosChannel1_ValueChanged);
            // 
            // mVDivChannel1
            // 
            this.mVDivChannel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mVDivChannel1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mVDivChannel1.Location = new System.Drawing.Point(140, 50);
            this.mVDivChannel1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mVDivChannel1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mVDivChannel1.Name = "mVDivChannel1";
            this.mVDivChannel1.Size = new System.Drawing.Size(87, 20);
            this.mVDivChannel1.TabIndex = 1;
            this.mVDivChannel1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mVDivChannel1.ValueChanged += new System.EventHandler(this.mVDivChannel1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Y-position";
            // 
            // EnableChannel1
            // 
            this.EnableChannel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EnableChannel1.AutoSize = true;
            this.EnableChannel1.Checked = true;
            this.EnableChannel1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableChannel1.Location = new System.Drawing.Point(140, 91);
            this.EnableChannel1.Name = "EnableChannel1";
            this.EnableChannel1.Size = new System.Drawing.Size(131, 17);
            this.EnableChannel1.TabIndex = 4;
            this.EnableChannel1.Text = "Enable";
            this.EnableChannel1.UseVisualStyleBackColor = true;
            this.EnableChannel1.CheckedChanged += new System.EventHandler(this.EnableChannel1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sample rate";
            // 
            // labelSampleRateChannel0
            // 
            this.labelSampleRateChannel0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSampleRateChannel0.AutoSize = true;
            this.labelSampleRateChannel0.Location = new System.Drawing.Point(140, 133);
            this.labelSampleRateChannel0.Name = "labelSampleRateChannel0";
            this.labelSampleRateChannel0.Size = new System.Drawing.Size(32, 13);
            this.labelSampleRateChannel0.TabIndex = 6;
            this.labelSampleRateChannel0.Text = "0 sps";
            // 
            // buttonSingle
            // 
            this.buttonSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSingle.BackColor = System.Drawing.Color.Salmon;
            this.buttonSingle.Location = new System.Drawing.Point(812, 40);
            this.buttonSingle.Name = "buttonSingle";
            this.buttonSingle.Size = new System.Drawing.Size(75, 23);
            this.buttonSingle.TabIndex = 2;
            this.buttonSingle.Text = "Single";
            this.buttonSingle.UseVisualStyleBackColor = false;
            this.buttonSingle.Click += new System.EventHandler(this.buttonSingle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxShiftPrefixChannel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(814, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 173);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel 2";
            // 
            // comboBoxShiftPrefixChannel2
            // 
            this.comboBoxShiftPrefixChannel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShiftPrefixChannel2.FormattingEnabled = true;
            this.comboBoxShiftPrefixChannel2.Items.AddRange(new object[] {
            "uV",
            "mV",
            "V"});
            this.comboBoxShiftPrefixChannel2.Location = new System.Drawing.Point(240, 30);
            this.comboBoxShiftPrefixChannel2.Name = "comboBoxShiftPrefixChannel2";
            this.comboBoxShiftPrefixChannel2.Size = new System.Drawing.Size(38, 21);
            this.comboBoxShiftPrefixChannel2.TabIndex = 5;
            this.comboBoxShiftPrefixChannel2.SelectedIndexChanged += new System.EventHandler(this.comboBoxShiftPrefixChannel2_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.yPosChannel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.mVDivChannel2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EnableChannel2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelSampleRateChannel1, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(274, 153);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Sample rate";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "mV/Div";
            // 
            // yPosChannel2
            // 
            this.yPosChannel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.yPosChannel2.Location = new System.Drawing.Point(140, 10);
            this.yPosChannel2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yPosChannel2.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.yPosChannel2.Name = "yPosChannel2";
            this.yPosChannel2.Size = new System.Drawing.Size(87, 20);
            this.yPosChannel2.TabIndex = 0;
            this.yPosChannel2.ValueChanged += new System.EventHandler(this.yPosChannel2_ValueChanged);
            // 
            // mVDivChannel2
            // 
            this.mVDivChannel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mVDivChannel2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mVDivChannel2.Location = new System.Drawing.Point(140, 50);
            this.mVDivChannel2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mVDivChannel2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mVDivChannel2.Name = "mVDivChannel2";
            this.mVDivChannel2.Size = new System.Drawing.Size(87, 20);
            this.mVDivChannel2.TabIndex = 1;
            this.mVDivChannel2.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mVDivChannel2.ValueChanged += new System.EventHandler(this.mVDivChannel2_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y-position";
            // 
            // EnableChannel2
            // 
            this.EnableChannel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EnableChannel2.AutoSize = true;
            this.EnableChannel2.Location = new System.Drawing.Point(140, 91);
            this.EnableChannel2.Name = "EnableChannel2";
            this.EnableChannel2.Size = new System.Drawing.Size(131, 17);
            this.EnableChannel2.TabIndex = 4;
            this.EnableChannel2.TabStop = false;
            this.EnableChannel2.Text = "Enable";
            this.EnableChannel2.UseVisualStyleBackColor = true;
            this.EnableChannel2.CheckedChanged += new System.EventHandler(this.EnableChannel2_CheckedChanged);
            // 
            // labelSampleRateChannel1
            // 
            this.labelSampleRateChannel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSampleRateChannel1.AutoSize = true;
            this.labelSampleRateChannel1.Location = new System.Drawing.Point(140, 133);
            this.labelSampleRateChannel1.Name = "labelSampleRateChannel1";
            this.labelSampleRateChannel1.Size = new System.Drawing.Size(32, 13);
            this.labelSampleRateChannel1.TabIndex = 8;
            this.labelSampleRateChannel1.Text = "0 sps";
            // 
            // buttonContinuous
            // 
            this.buttonContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinuous.BackColor = System.Drawing.Color.Salmon;
            this.buttonContinuous.Location = new System.Drawing.Point(893, 40);
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
            this.buttonConnect.Location = new System.Drawing.Point(1024, 12);
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
            this.buttonRefresh.Location = new System.Drawing.Point(995, 12);
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
            this.comboBoxDevices.Location = new System.Drawing.Point(812, 13);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(177, 21);
            this.comboBoxDevices.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.timeFactor);
            this.groupBox2.Controls.Add(this.comboBoxTimePrefix);
            this.groupBox2.Location = new System.Drawing.Point(814, 183);
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
            this.comboBoxTimePrefix.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(814, 69);
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
            this.numericYDivisions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericYDivisions.Location = new System.Drawing.Point(139, 50);
            this.numericYDivisions.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericYDivisions.Name = "numericYDivisions";
            this.numericYDivisions.Size = new System.Drawing.Size(75, 20);
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
            // comboBoxVoltagePrefixChannel2
            // 
            this.comboBoxVoltagePrefixChannel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVoltagePrefixChannel2.FormattingEnabled = true;
            this.comboBoxVoltagePrefixChannel2.Items.AddRange(new object[] {
            "uV",
            "mV",
            "V"});
            this.comboBoxVoltagePrefixChannel2.Location = new System.Drawing.Point(1054, 494);
            this.comboBoxVoltagePrefixChannel2.Name = "comboBoxVoltagePrefixChannel2";
            this.comboBoxVoltagePrefixChannel2.Size = new System.Drawing.Size(38, 21);
            this.comboBoxVoltagePrefixChannel2.TabIndex = 1;
            this.comboBoxVoltagePrefixChannel2.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoltagePrefixChannel2_SelectedIndexChanged);
            // 
            // Oscilloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 610);
            this.Controls.Add(this.comboBoxVoltagePrefixChannel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonContinuous);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSingle);
            this.Controls.Add(this.boxChannel1);
            this.Controls.Add(this.MainChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Oscilloscope";
            this.Text = "Oscilloscope on a microcontroller";
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.boxChannel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yPosChannel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mVDivChannel1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yPosChannel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mVDivChannel2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeFactor)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericYDivisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXDivisions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox boxChannel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown yPosChannel1;
        private System.Windows.Forms.NumericUpDown mVDivChannel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox EnableChannel1;
        private System.Windows.Forms.Button buttonSingle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown yPosChannel2;
        private System.Windows.Forms.NumericUpDown mVDivChannel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox EnableChannel2;
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
        private System.Windows.Forms.ComboBox comboBoxVoltagePrefixChannel1;
        private System.Windows.Forms.ComboBox comboBoxVoltagePrefixChannel2;
        private System.Windows.Forms.ComboBox comboBoxShiftPrefixChannel1;
        private System.Windows.Forms.ComboBox comboBoxShiftPrefixChannel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSampleRateChannel0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelSampleRateChannel1;
    }
}

