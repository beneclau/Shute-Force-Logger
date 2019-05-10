namespace SimpleSpectrometer
    {
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InitializeButton = new System.Windows.Forms.Button();
            this.ExpTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TakeSpectrumButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.InitStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SensitivityCalibrationCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.zed = new ZedGraph.ZedGraphControl();
            this.lblStopWatch = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTemp = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPagePeakTrack = new System.Windows.Forms.TabPage();
            this.tabPageSpectrum = new System.Windows.Forms.TabPage();
            this.PeakTrackBox = new System.Windows.Forms.GroupBox();
            this.numericUpDowntr5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowntr4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowntr3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowntr2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowntr1 = new System.Windows.Forms.NumericUpDown();
            this.labelPeak5 = new System.Windows.Forms.Label();
            this.labelPeak4 = new System.Windows.Forms.Label();
            this.labelPeak3 = new System.Windows.Forms.Label();
            this.labelPeak1 = new System.Windows.Forms.Label();
            this.labelPeak2 = new System.Windows.Forms.Label();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labpeak10 = new System.Windows.Forms.Label();
            this.labpeak9 = new System.Windows.Forms.Label();
            this.labpeak8 = new System.Windows.Forms.Label();
            this.labpeak7 = new System.Windows.Forms.Label();
            this.labpeak1 = new System.Windows.Forms.Label();
            this.labpeak2 = new System.Windows.Forms.Label();
            this.labpeak3 = new System.Windows.Forms.Label();
            this.labpeak4 = new System.Windows.Forms.Label();
            this.labpeak5 = new System.Windows.Forms.Label();
            this.labpeak6 = new System.Windows.Forms.Label();
            this.labtr1 = new System.Windows.Forms.Label();
            this.labtr2 = new System.Windows.Forms.Label();
            this.labtr3 = new System.Windows.Forms.Label();
            this.labtr4 = new System.Windows.Forms.Label();
            this.labtr5 = new System.Windows.Forms.Label();
            this.ManualBox = new System.Windows.Forms.CheckBox();
            this.tabPageCalibration = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ExpTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageTemp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPagePeakTrack.SuspendLayout();
            this.tabPageSpectrum.SuspendLayout();
            this.PeakTrackBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // InitializeButton
            // 
            this.InitializeButton.Location = new System.Drawing.Point(4, 6);
            this.InitializeButton.Margin = new System.Windows.Forms.Padding(4);
            this.InitializeButton.Name = "InitializeButton";
            this.InitializeButton.Size = new System.Drawing.Size(131, 28);
            this.InitializeButton.TabIndex = 0;
            this.InitializeButton.Text = "Initialize";
            this.InitializeButton.UseVisualStyleBackColor = true;
            this.InitializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
            // 
            // ExpTimeNumericUpDown
            // 
            this.ExpTimeNumericUpDown.DecimalPlaces = 6;
            this.ExpTimeNumericUpDown.Enabled = false;
            this.ExpTimeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpTimeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ExpTimeNumericUpDown.Location = new System.Drawing.Point(5, 65);
            this.ExpTimeNumericUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.ExpTimeNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            393216});
            this.ExpTimeNumericUpDown.Name = "ExpTimeNumericUpDown";
            this.ExpTimeNumericUpDown.Size = new System.Drawing.Size(99, 29);
            this.ExpTimeNumericUpDown.TabIndex = 2;
            this.ExpTimeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ExpTimeNumericUpDown.ValueChanged += new System.EventHandler(this.ExpTimeNumericUpDown_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TakeSpectrumButton
            // 
            this.TakeSpectrumButton.Location = new System.Drawing.Point(5, 164);
            this.TakeSpectrumButton.Name = "TakeSpectrumButton";
            this.TakeSpectrumButton.Size = new System.Drawing.Size(130, 30);
            this.TakeSpectrumButton.TabIndex = 3;
            this.TakeSpectrumButton.Text = "Take Spectrum";
            this.TakeSpectrumButton.UseVisualStyleBackColor = true;
            this.TakeSpectrumButton.Click += new System.EventHandler(this.TakeSpectrumButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Exposure time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "s";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(193, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1154, 305);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InitStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1460, 25);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // InitStatusLabel
            // 
            this.InitStatusLabel.Name = "InitStatusLabel";
            this.InitStatusLabel.Size = new System.Drawing.Size(103, 20);
            this.InitStatusLabel.Text = "Not initialized";
            // 
            // SensitivityCalibrationCheckBox
            // 
            this.SensitivityCalibrationCheckBox.Location = new System.Drawing.Point(7, 119);
            this.SensitivityCalibrationCheckBox.Name = "SensitivityCalibrationCheckBox";
            this.SensitivityCalibrationCheckBox.Size = new System.Drawing.Size(104, 39);
            this.SensitivityCalibrationCheckBox.TabIndex = 8;
            this.SensitivityCalibrationCheckBox.Text = "Use sensitivity calibration";
            this.SensitivityCalibrationCheckBox.UseVisualStyleBackColor = true;
            this.SensitivityCalibrationCheckBox.CheckedChanged += new System.EventHandler(this.SensitivityCalibrationCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(5, 201);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 39);
            this.button1.TabIndex = 18;
            this.button1.Text = "RUN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(27, 34);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1396, 393);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // zed
            // 
            this.zed.Location = new System.Drawing.Point(27, 34);
            this.zed.Margin = new System.Windows.Forms.Padding(5);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(1396, 393);
            this.zed.TabIndex = 29;
            // 
            // lblStopWatch
            // 
            this.lblStopWatch.AutoSize = true;
            this.lblStopWatch.Location = new System.Drawing.Point(11, 254);
            this.lblStopWatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopWatch.Name = "lblStopWatch";
            this.lblStopWatch.Size = new System.Drawing.Size(91, 17);
            this.lblStopWatch.TabIndex = 17;
            this.lblStopWatch.Text = "lblStopWatch";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTemp);
            this.tabControl1.Controls.Add(this.tabPagePeakTrack);
            this.tabControl1.Controls.Add(this.tabPageSpectrum);
            this.tabControl1.Controls.Add(this.tabPageCalibration);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1460, 779);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPageTemp
            // 
            this.tabPageTemp.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageTemp.Controls.Add(this.tableLayoutPanel1);
            this.tabPageTemp.Location = new System.Drawing.Point(4, 25);
            this.tabPageTemp.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTemp.Name = "tabPageTemp";
            this.tabPageTemp.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTemp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageTemp.Size = new System.Drawing.Size(1452, 750);
            this.tabPageTemp.TabIndex = 0;
            this.tabPageTemp.Text = "Temp";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 341F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 422F));
            this.tableLayoutPanel1.Controls.Add(this.label20, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label19, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(41, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 473);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(497, 376);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(416, 96);
            this.label20.TabIndex = 34;
            this.label20.Text = "Temperature ( °C)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(497, 279);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(416, 96);
            this.label17.TabIndex = 33;
            this.label17.Text = "Temperature ( °C)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(497, 195);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(416, 83);
            this.label14.TabIndex = 32;
            this.label14.Text = "Temperature ( °C)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(497, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(416, 84);
            this.label11.TabIndex = 31;
            this.label11.Text = "Temperature ( °C)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(497, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(416, 77);
            this.label8.TabIndex = 30;
            this.label8.Text = "Temperature ( °C)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(155, 376);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(335, 96);
            this.label19.TabIndex = 29;
            this.label19.Text = "Peak [nm]";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(155, 279);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(335, 96);
            this.label16.TabIndex = 28;
            this.label16.Text = "Peak [nm]";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(155, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(335, 83);
            this.label13.TabIndex = 27;
            this.label13.Text = "Peak [nm]";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(155, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(335, 84);
            this.label10.TabIndex = 26;
            this.label10.Text = "Peak [nm]";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(4, 376);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 96);
            this.label18.TabIndex = 15;
            this.label18.Text = "Peak 5";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(4, 279);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 96);
            this.label15.TabIndex = 12;
            this.label15.Text = "Peak 4";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(4, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 83);
            this.label12.TabIndex = 9;
            this.label12.Text = "Peak 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(4, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 84);
            this.label9.TabIndex = 6;
            this.label9.Text = "Peak2";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 77);
            this.label6.TabIndex = 3;
            this.label6.Text = "Peak 1 ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(497, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(416, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Temperature ( °C)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(155, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(335, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "Wave Length [ nm ]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 30);
            this.label3.TabIndex = 0;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(155, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(335, 77);
            this.label7.TabIndex = 16;
            this.label7.Text = "Peak [nm]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPagePeakTrack
            // 
            this.tabPagePeakTrack.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePeakTrack.Controls.Add(this.zed);
            this.tabPagePeakTrack.Controls.Add(this.pictureBox2);
            this.tabPagePeakTrack.Location = new System.Drawing.Point(4, 25);
            this.tabPagePeakTrack.Margin = new System.Windows.Forms.Padding(4);
            this.tabPagePeakTrack.Name = "tabPagePeakTrack";
            this.tabPagePeakTrack.Padding = new System.Windows.Forms.Padding(4);
            this.tabPagePeakTrack.Size = new System.Drawing.Size(1452, 750);
            this.tabPagePeakTrack.TabIndex = 1;
            this.tabPagePeakTrack.Text = "Peak Track";
            // 
            // tabPageSpectrum
            // 
            this.tabPageSpectrum.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSpectrum.Controls.Add(this.PeakTrackBox);
            this.tabPageSpectrum.Controls.Add(this.lblStopWatch);
            this.tabPageSpectrum.Controls.Add(this.pictureBox1);
            this.tabPageSpectrum.Controls.Add(this.button1);
            this.tabPageSpectrum.Controls.Add(this.InitializeButton);
            this.tabPageSpectrum.Controls.Add(this.SensitivityCalibrationCheckBox);
            this.tabPageSpectrum.Controls.Add(this.TakeSpectrumButton);
            this.tabPageSpectrum.Controls.Add(this.label2);
            this.tabPageSpectrum.Controls.Add(this.ExpTimeNumericUpDown);
            this.tabPageSpectrum.Controls.Add(this.label1);
            this.tabPageSpectrum.Controls.Add(this.ManualBox);
            this.tabPageSpectrum.Location = new System.Drawing.Point(4, 25);
            this.tabPageSpectrum.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSpectrum.Name = "tabPageSpectrum";
            this.tabPageSpectrum.Size = new System.Drawing.Size(1452, 750);
            this.tabPageSpectrum.TabIndex = 2;
            this.tabPageSpectrum.Text = "Spectrum";
            // 
            // PeakTrackBox
            // 
            this.PeakTrackBox.Controls.Add(this.numericUpDowntr5);
            this.PeakTrackBox.Controls.Add(this.numericUpDowntr4);
            this.PeakTrackBox.Controls.Add(this.numericUpDowntr3);
            this.PeakTrackBox.Controls.Add(this.numericUpDowntr2);
            this.PeakTrackBox.Controls.Add(this.numericUpDowntr1);
            this.PeakTrackBox.Controls.Add(this.labelPeak5);
            this.PeakTrackBox.Controls.Add(this.labelPeak4);
            this.PeakTrackBox.Controls.Add(this.labelPeak3);
            this.PeakTrackBox.Controls.Add(this.labelPeak1);
            this.PeakTrackBox.Controls.Add(this.labelPeak2);
            this.PeakTrackBox.Controls.Add(this.numericUpDown10);
            this.PeakTrackBox.Controls.Add(this.numericUpDown9);
            this.PeakTrackBox.Controls.Add(this.numericUpDown8);
            this.PeakTrackBox.Controls.Add(this.numericUpDown7);
            this.PeakTrackBox.Controls.Add(this.numericUpDown6);
            this.PeakTrackBox.Controls.Add(this.numericUpDown5);
            this.PeakTrackBox.Controls.Add(this.numericUpDown4);
            this.PeakTrackBox.Controls.Add(this.numericUpDown3);
            this.PeakTrackBox.Controls.Add(this.numericUpDown2);
            this.PeakTrackBox.Controls.Add(this.numericUpDown1);
            this.PeakTrackBox.Controls.Add(this.labpeak10);
            this.PeakTrackBox.Controls.Add(this.labpeak9);
            this.PeakTrackBox.Controls.Add(this.labpeak8);
            this.PeakTrackBox.Controls.Add(this.labpeak7);
            this.PeakTrackBox.Controls.Add(this.labpeak1);
            this.PeakTrackBox.Controls.Add(this.labpeak2);
            this.PeakTrackBox.Controls.Add(this.labpeak3);
            this.PeakTrackBox.Controls.Add(this.labpeak4);
            this.PeakTrackBox.Controls.Add(this.labpeak5);
            this.PeakTrackBox.Controls.Add(this.labpeak6);
            this.PeakTrackBox.Controls.Add(this.labtr1);
            this.PeakTrackBox.Controls.Add(this.labtr2);
            this.PeakTrackBox.Controls.Add(this.labtr3);
            this.PeakTrackBox.Controls.Add(this.labtr4);
            this.PeakTrackBox.Controls.Add(this.labtr5);
            this.PeakTrackBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeakTrackBox.Location = new System.Drawing.Point(177, 351);
            this.PeakTrackBox.Margin = new System.Windows.Forms.Padding(4);
            this.PeakTrackBox.Name = "PeakTrackBox";
            this.PeakTrackBox.Padding = new System.Windows.Forms.Padding(4);
            this.PeakTrackBox.Size = new System.Drawing.Size(1094, 226);
            this.PeakTrackBox.TabIndex = 26;
            this.PeakTrackBox.TabStop = false;
            this.PeakTrackBox.Text = "Peak Tracker";
            // 
            // numericUpDowntr5
            // 
            this.numericUpDowntr5.DecimalPlaces = 1;
            this.numericUpDowntr5.Enabled = false;
            this.numericUpDowntr5.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDowntr5.Location = new System.Drawing.Point(972, 146);
            this.numericUpDowntr5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowntr5.Name = "numericUpDowntr5";
            this.numericUpDowntr5.Size = new System.Drawing.Size(82, 29);
            this.numericUpDowntr5.TabIndex = 39;
            this.numericUpDowntr5.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDowntr5.ValueChanged += new System.EventHandler(this.numericUpDowntr5_ValueChanged);
            // 
            // numericUpDowntr4
            // 
            this.numericUpDowntr4.DecimalPlaces = 1;
            this.numericUpDowntr4.Enabled = false;
            this.numericUpDowntr4.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDowntr4.Location = new System.Drawing.Point(765, 149);
            this.numericUpDowntr4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowntr4.Name = "numericUpDowntr4";
            this.numericUpDowntr4.Size = new System.Drawing.Size(82, 29);
            this.numericUpDowntr4.TabIndex = 38;
            this.numericUpDowntr4.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDowntr4.ValueChanged += new System.EventHandler(this.numericUpDowntr4_ValueChanged);
            // 
            // numericUpDowntr3
            // 
            this.numericUpDowntr3.DecimalPlaces = 1;
            this.numericUpDowntr3.Enabled = false;
            this.numericUpDowntr3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDowntr3.Location = new System.Drawing.Point(553, 154);
            this.numericUpDowntr3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowntr3.Name = "numericUpDowntr3";
            this.numericUpDowntr3.Size = new System.Drawing.Size(82, 29);
            this.numericUpDowntr3.TabIndex = 37;
            this.numericUpDowntr3.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDowntr3.ValueChanged += new System.EventHandler(this.numericUpDowntr3_ValueChanged);
            // 
            // numericUpDowntr2
            // 
            this.numericUpDowntr2.DecimalPlaces = 1;
            this.numericUpDowntr2.Enabled = false;
            this.numericUpDowntr2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDowntr2.Location = new System.Drawing.Point(345, 147);
            this.numericUpDowntr2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowntr2.Name = "numericUpDowntr2";
            this.numericUpDowntr2.Size = new System.Drawing.Size(82, 29);
            this.numericUpDowntr2.TabIndex = 36;
            this.numericUpDowntr2.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDowntr2.ValueChanged += new System.EventHandler(this.numericUpDowntr2_ValueChanged);
            // 
            // numericUpDowntr1
            // 
            this.numericUpDowntr1.DecimalPlaces = 1;
            this.numericUpDowntr1.Enabled = false;
            this.numericUpDowntr1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDowntr1.Location = new System.Drawing.Point(126, 149);
            this.numericUpDowntr1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowntr1.Name = "numericUpDowntr1";
            this.numericUpDowntr1.Size = new System.Drawing.Size(82, 29);
            this.numericUpDowntr1.TabIndex = 35;
            this.numericUpDowntr1.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDowntr1.ValueChanged += new System.EventHandler(this.numericUpDowntr1_ValueChanged);
            // 
            // labelPeak5
            // 
            this.labelPeak5.AutoSize = true;
            this.labelPeak5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeak5.Location = new System.Drawing.Point(862, 198);
            this.labelPeak5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPeak5.Name = "labelPeak5";
            this.labelPeak5.Size = new System.Drawing.Size(115, 20);
            this.labelPeak5.TabIndex = 30;
            this.labelPeak5.Text = "Peak 5 [nm]:";
            // 
            // labelPeak4
            // 
            this.labelPeak4.AutoSize = true;
            this.labelPeak4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeak4.Location = new System.Drawing.Point(647, 198);
            this.labelPeak4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPeak4.Name = "labelPeak4";
            this.labelPeak4.Size = new System.Drawing.Size(115, 20);
            this.labelPeak4.TabIndex = 29;
            this.labelPeak4.Text = "Peak 4 [nm]:";
            // 
            // labelPeak3
            // 
            this.labelPeak3.AutoSize = true;
            this.labelPeak3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeak3.Location = new System.Drawing.Point(429, 198);
            this.labelPeak3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPeak3.Name = "labelPeak3";
            this.labelPeak3.Size = new System.Drawing.Size(115, 20);
            this.labelPeak3.TabIndex = 28;
            this.labelPeak3.Text = "Peak 3 [nm]:";
            // 
            // labelPeak1
            // 
            this.labelPeak1.AutoSize = true;
            this.labelPeak1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeak1.Location = new System.Drawing.Point(12, 198);
            this.labelPeak1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPeak1.Name = "labelPeak1";
            this.labelPeak1.Size = new System.Drawing.Size(115, 20);
            this.labelPeak1.TabIndex = 17;
            this.labelPeak1.Text = "Peak 1 [nm]:";
            // 
            // labelPeak2
            // 
            this.labelPeak2.AutoSize = true;
            this.labelPeak2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeak2.Location = new System.Drawing.Point(222, 198);
            this.labelPeak2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPeak2.Name = "labelPeak2";
            this.labelPeak2.Size = new System.Drawing.Size(115, 20);
            this.labelPeak2.TabIndex = 18;
            this.labelPeak2.Text = "Peak 2 [nm]:";
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.DecimalPlaces = 1;
            this.numericUpDown10.Enabled = false;
            this.numericUpDown10.Location = new System.Drawing.Point(972, 110);
            this.numericUpDown10.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown10.TabIndex = 26;
            this.numericUpDown10.Value = new decimal(new int[] {
            8520,
            0,
            0,
            65536});
            this.numericUpDown10.ValueChanged += new System.EventHandler(this.numericUpDown10_ValueChanged);
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.DecimalPlaces = 1;
            this.numericUpDown9.Enabled = false;
            this.numericUpDown9.Location = new System.Drawing.Point(972, 77);
            this.numericUpDown9.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown9.TabIndex = 25;
            this.numericUpDown9.Value = new decimal(new int[] {
            8491,
            0,
            0,
            65536});
            this.numericUpDown9.ValueChanged += new System.EventHandler(this.numericUpDown9_ValueChanged);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.DecimalPlaces = 1;
            this.numericUpDown8.Enabled = false;
            this.numericUpDown8.Location = new System.Drawing.Point(770, 113);
            this.numericUpDown8.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown8.TabIndex = 24;
            this.numericUpDown8.Value = new decimal(new int[] {
            8489,
            0,
            0,
            65536});
            this.numericUpDown8.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.DecimalPlaces = 1;
            this.numericUpDown7.Enabled = false;
            this.numericUpDown7.Location = new System.Drawing.Point(765, 75);
            this.numericUpDown7.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown7.TabIndex = 23;
            this.numericUpDown7.Value = new decimal(new int[] {
            8440,
            0,
            0,
            65536});
            this.numericUpDown7.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.DecimalPlaces = 1;
            this.numericUpDown6.Enabled = false;
            this.numericUpDown6.Location = new System.Drawing.Point(559, 110);
            this.numericUpDown6.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown6.TabIndex = 22;
            this.numericUpDown6.Value = new decimal(new int[] {
            8559,
            0,
            0,
            65536});
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 1;
            this.numericUpDown5.Enabled = false;
            this.numericUpDown5.Location = new System.Drawing.Point(553, 75);
            this.numericUpDown5.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown5.TabIndex = 21;
            this.numericUpDown5.Value = new decimal(new int[] {
            8540,
            0,
            0,
            65536});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 1;
            this.numericUpDown4.Enabled = false;
            this.numericUpDown4.Location = new System.Drawing.Point(345, 108);
            this.numericUpDown4.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown4.TabIndex = 20;
            this.numericUpDown4.Value = new decimal(new int[] {
            8500,
            0,
            0,
            65536});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Enabled = false;
            this.numericUpDown3.Location = new System.Drawing.Point(351, 69);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown3.TabIndex = 19;
            this.numericUpDown3.Value = new decimal(new int[] {
            8440,
            0,
            0,
            65536});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(126, 108);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown2.TabIndex = 18;
            this.numericUpDown2.Value = new decimal(new int[] {
            8440,
            0,
            0,
            65536});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(126, 72);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10860,
            0,
            0,
            65536});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            7250,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(76, 29);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            8400,
            0,
            0,
            65536});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labpeak10
            // 
            this.labpeak10.AutoSize = true;
            this.labpeak10.Location = new System.Drawing.Point(854, 113);
            this.labpeak10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak10.Name = "labpeak10";
            this.labpeak10.Size = new System.Drawing.Size(116, 24);
            this.labpeak10.TabIndex = 4;
            this.labpeak10.Text = "WaveRight 5";
            // 
            // labpeak9
            // 
            this.labpeak9.AutoSize = true;
            this.labpeak9.Location = new System.Drawing.Point(862, 77);
            this.labpeak9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak9.Name = "labpeak9";
            this.labpeak9.Size = new System.Drawing.Size(102, 24);
            this.labpeak9.TabIndex = 3;
            this.labpeak9.Text = "WaveLeft 5";
            // 
            // labpeak8
            // 
            this.labpeak8.AutoSize = true;
            this.labpeak8.Location = new System.Drawing.Point(646, 115);
            this.labpeak8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak8.Name = "labpeak8";
            this.labpeak8.Size = new System.Drawing.Size(116, 24);
            this.labpeak8.TabIndex = 2;
            this.labpeak8.Text = "WaveRight 4";
            // 
            // labpeak7
            // 
            this.labpeak7.AutoSize = true;
            this.labpeak7.Location = new System.Drawing.Point(646, 74);
            this.labpeak7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak7.Name = "labpeak7";
            this.labpeak7.Size = new System.Drawing.Size(102, 24);
            this.labpeak7.TabIndex = 1;
            this.labpeak7.Text = "WaveLeft 4";
            // 
            // labpeak1
            // 
            this.labpeak1.AutoSize = true;
            this.labpeak1.Location = new System.Drawing.Point(8, 77);
            this.labpeak1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak1.Name = "labpeak1";
            this.labpeak1.Size = new System.Drawing.Size(102, 24);
            this.labpeak1.TabIndex = 0;
            this.labpeak1.Text = "WaveLeft 1";
            // 
            // labpeak2
            // 
            this.labpeak2.AutoSize = true;
            this.labpeak2.Location = new System.Drawing.Point(8, 110);
            this.labpeak2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak2.Name = "labpeak2";
            this.labpeak2.Size = new System.Drawing.Size(116, 24);
            this.labpeak2.TabIndex = 0;
            this.labpeak2.Text = "WaveRight 1";
            // 
            // labpeak3
            // 
            this.labpeak3.AutoSize = true;
            this.labpeak3.Location = new System.Drawing.Point(231, 74);
            this.labpeak3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak3.Name = "labpeak3";
            this.labpeak3.Size = new System.Drawing.Size(102, 24);
            this.labpeak3.TabIndex = 0;
            this.labpeak3.Text = "WaveLeft 2";
            // 
            // labpeak4
            // 
            this.labpeak4.AutoSize = true;
            this.labpeak4.Location = new System.Drawing.Point(216, 110);
            this.labpeak4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak4.Name = "labpeak4";
            this.labpeak4.Size = new System.Drawing.Size(121, 24);
            this.labpeak4.TabIndex = 0;
            this.labpeak4.Text = "Wave Right 2";
            // 
            // labpeak5
            // 
            this.labpeak5.AutoSize = true;
            this.labpeak5.Location = new System.Drawing.Point(435, 77);
            this.labpeak5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak5.Name = "labpeak5";
            this.labpeak5.Size = new System.Drawing.Size(102, 24);
            this.labpeak5.TabIndex = 0;
            this.labpeak5.Text = "WaveLeft 3";
            // 
            // labpeak6
            // 
            this.labpeak6.AutoSize = true;
            this.labpeak6.Location = new System.Drawing.Point(428, 113);
            this.labpeak6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labpeak6.Name = "labpeak6";
            this.labpeak6.Size = new System.Drawing.Size(116, 24);
            this.labpeak6.TabIndex = 0;
            this.labpeak6.Text = "WaveRight 3";
            // 
            // labtr1
            // 
            this.labtr1.AutoSize = true;
            this.labtr1.Location = new System.Drawing.Point(14, 154);
            this.labtr1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labtr1.Name = "labtr1";
            this.labtr1.Size = new System.Drawing.Size(111, 24);
            this.labtr1.TabIndex = 17;
            this.labtr1.Text = "Threshold 1";
            // 
            // labtr2
            // 
            this.labtr2.AutoSize = true;
            this.labtr2.Location = new System.Drawing.Point(222, 149);
            this.labtr2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labtr2.Name = "labtr2";
            this.labtr2.Size = new System.Drawing.Size(111, 24);
            this.labtr2.TabIndex = 31;
            this.labtr2.Text = "Threshold 2";
            // 
            // labtr3
            // 
            this.labtr3.AutoSize = true;
            this.labtr3.Location = new System.Drawing.Point(433, 151);
            this.labtr3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labtr3.Name = "labtr3";
            this.labtr3.Size = new System.Drawing.Size(111, 24);
            this.labtr3.TabIndex = 32;
            this.labtr3.Text = "Threshold 3";
            // 
            // labtr4
            // 
            this.labtr4.AutoSize = true;
            this.labtr4.Location = new System.Drawing.Point(647, 154);
            this.labtr4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labtr4.Name = "labtr4";
            this.labtr4.Size = new System.Drawing.Size(111, 24);
            this.labtr4.TabIndex = 33;
            this.labtr4.Text = "Threshold 4";
            // 
            // labtr5
            // 
            this.labtr5.AutoSize = true;
            this.labtr5.Location = new System.Drawing.Point(854, 151);
            this.labtr5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labtr5.Name = "labtr5";
            this.labtr5.Size = new System.Drawing.Size(111, 24);
            this.labtr5.TabIndex = 34;
            this.labtr5.Text = "Threshold 5";
            // 
            // ManualBox
            // 
            this.ManualBox.Location = new System.Drawing.Point(7, 292);
            this.ManualBox.Margin = new System.Windows.Forms.Padding(4);
            this.ManualBox.Name = "ManualBox";
            this.ManualBox.Size = new System.Drawing.Size(166, 48);
            this.ManualBox.TabIndex = 27;
            this.ManualBox.Text = "Manual Input";
            this.ManualBox.UseVisualStyleBackColor = true;
            this.ManualBox.CheckedChanged += new System.EventHandler(this.ManualBox_CheckedChanged);
            // 
            // tabPageCalibration
            // 
            this.tabPageCalibration.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCalibration.Location = new System.Drawing.Point(4, 25);
            this.tabPageCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageCalibration.Name = "tabPageCalibration";
            this.tabPageCalibration.Size = new System.Drawing.Size(1452, 750);
            this.tabPageCalibration.TabIndex = 3;
            this.tabPageCalibration.Text = "Calibration";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 619);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "SHUTE Logger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExpTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTemp.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPagePeakTrack.ResumeLayout(false);
            this.tabPageSpectrum.ResumeLayout(false);
            this.tabPageSpectrum.PerformLayout();
            this.PeakTrackBox.ResumeLayout(false);
            this.PeakTrackBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowntr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.Button InitializeButton;
    private System.Windows.Forms.NumericUpDown ExpTimeNumericUpDown;
    private System.Windows.Forms.Button TakeSpectrumButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel InitStatusLabel;
    private System.Windows.Forms.CheckBox SensitivityCalibrationCheckBox;
    private System.Windows.Forms.Button button1;
    private System.IO.Ports.SerialPort serialPort1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label lblStopWatch;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageTemp;
    private System.Windows.Forms.TabPage tabPagePeakTrack;
    private System.Windows.Forms.TabPage tabPageSpectrum;
    private System.Windows.Forms.TabPage tabPageCalibration;
    private System.Windows.Forms.GroupBox PeakTrackBox;
    private System.Windows.Forms.Label labpeak1;
    private System.Windows.Forms.Label labpeak2;
    private System.Windows.Forms.Label labpeak3;
    private System.Windows.Forms.Label labpeak4;
    private System.Windows.Forms.Label labpeak5;
    private System.Windows.Forms.Label labpeak6;
    private System.Windows.Forms.Label labpeak10;
    private System.Windows.Forms.Label labpeak9;
    private System.Windows.Forms.Label labpeak8;
    private System.Windows.Forms.Label labpeak7;
    private System.Windows.Forms.NumericUpDown numericUpDown7;
    private System.Windows.Forms.NumericUpDown numericUpDown6;
    private System.Windows.Forms.NumericUpDown numericUpDown5;
    private System.Windows.Forms.NumericUpDown numericUpDown4;
    private System.Windows.Forms.NumericUpDown numericUpDown3;
    private System.Windows.Forms.NumericUpDown numericUpDown2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.NumericUpDown numericUpDown10;
    private System.Windows.Forms.NumericUpDown numericUpDown9;
    private System.Windows.Forms.NumericUpDown numericUpDown8;
    private System.Windows.Forms.CheckBox ManualBox;
    private System.Windows.Forms.Label labelPeak1;
    private System.Windows.Forms.Label labelPeak5;
    private System.Windows.Forms.Label labelPeak4;
    private System.Windows.Forms.Label labelPeak3;
    private System.Windows.Forms.Label labelPeak2;
    private System.Windows.Forms.NumericUpDown numericUpDowntr5;
    private System.Windows.Forms.NumericUpDown numericUpDowntr4;
    private System.Windows.Forms.NumericUpDown numericUpDowntr3;
    private System.Windows.Forms.NumericUpDown numericUpDowntr2;
    private System.Windows.Forms.NumericUpDown numericUpDowntr1;
    private System.Windows.Forms.Label labtr5;
    private System.Windows.Forms.Label labtr4;
    private System.Windows.Forms.Label labtr3;
    private System.Windows.Forms.Label labtr2;
    private System.Windows.Forms.Label labtr1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label7;
    private ZedGraph.ZedGraphControl zed;
    private System.Windows.Forms.Timer timer1;
    }
}

