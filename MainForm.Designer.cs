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
        public void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InitializeButton = new System.Windows.Forms.Button();
            this.ExpTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TakeSpectrumButton = new System.Windows.Forms.Button();
            this.labelExposureTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.InitStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SensitivityCalibrationCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.zed = new ZedGraph.ZedGraphControl();
            this.lblStopWatch = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSpectrum = new System.Windows.Forms.TabPage();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.labelSec = new System.Windows.Forms.Label();
            this.comboSampleTime = new System.Windows.Forms.ComboBox();
            this.labelSampleTime = new System.Windows.Forms.Label();
            this.selectAllBox = new System.Windows.Forms.CheckBox();
            this.removePeakButton = new System.Windows.Forms.Button();
            this.peaksPanel = new System.Windows.Forms.Panel();
            this.peaksTable = new System.Windows.Forms.TableLayoutPanel();
            this.labelPeakName = new System.Windows.Forms.Label();
            this.waveLengthsL = new System.Windows.Forms.Label();
            this.waveLengthsR = new System.Windows.Forms.Label();
            this.labelCOGResult = new System.Windows.Forms.Label();
            this.labelSavePeak = new System.Windows.Forms.Label();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonAddPeak = new System.Windows.Forms.Button();
            this.tabPagePeakTrack = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ExpTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageSpectrum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.peaksPanel.SuspendLayout();
            this.peaksTable.SuspendLayout();
            this.tabPagePeakTrack.SuspendLayout();
            this.SuspendLayout();
            // 
            // InitializeButton
            // 
            this.InitializeButton.Location = new System.Drawing.Point(10, 31);
            this.InitializeButton.Name = "InitializeButton";
            this.InitializeButton.Size = new System.Drawing.Size(98, 23);
            this.InitializeButton.TabIndex = 0;
            this.InitializeButton.Text = "Initialize";
            this.InitializeButton.UseVisualStyleBackColor = true;
            this.InitializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
            // 
            // ExpTimeNumericUpDown
            // 
            this.ExpTimeNumericUpDown.DecimalPlaces = 6;
            this.ExpTimeNumericUpDown.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpTimeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ExpTimeNumericUpDown.Location = new System.Drawing.Point(10, 88);
            this.ExpTimeNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.ExpTimeNumericUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.ExpTimeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.ExpTimeNumericUpDown.Name = "ExpTimeNumericUpDown";
            this.ExpTimeNumericUpDown.Size = new System.Drawing.Size(84, 26);
            this.ExpTimeNumericUpDown.TabIndex = 2;
            this.ExpTimeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ExpTimeNumericUpDown.ValueChanged += new System.EventHandler(this.ExpTimeNumericUpDown_ValueChanged);
            this.ExpTimeNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ExpTimeNumericUpDown_MouseWheel);
            // 
            // TakeSpectrumButton
            // 
            this.TakeSpectrumButton.Location = new System.Drawing.Point(15, 281);
            this.TakeSpectrumButton.Margin = new System.Windows.Forms.Padding(2);
            this.TakeSpectrumButton.Name = "TakeSpectrumButton";
            this.TakeSpectrumButton.Size = new System.Drawing.Size(114, 24);
            this.TakeSpectrumButton.TabIndex = 3;
            this.TakeSpectrumButton.Text = "Take Spectrum";
            this.TakeSpectrumButton.UseVisualStyleBackColor = true;
            this.TakeSpectrumButton.Click += new System.EventHandler(this.TakeSpectrumButton_Click);
            // 
            // labelExposureTime
            // 
            this.labelExposureTime.AutoSize = true;
            this.labelExposureTime.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExposureTime.Location = new System.Drawing.Point(5, 66);
            this.labelExposureTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExposureTime.Name = "labelExposureTime";
            this.labelExposureTime.Size = new System.Drawing.Size(122, 18);
            this.labelExposureTime.TabIndex = 4;
            this.labelExposureTime.Text = "Exposure time:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(161, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1068, 245);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InitStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1286, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // InitStatusLabel
            // 
            this.InitStatusLabel.Name = "InitStatusLabel";
            this.InitStatusLabel.Size = new System.Drawing.Size(80, 17);
            this.InitStatusLabel.Text = "Not initialized";
            // 
            // SensitivityCalibrationCheckBox
            // 
            this.SensitivityCalibrationCheckBox.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensitivityCalibrationCheckBox.Location = new System.Drawing.Point(7, 186);
            this.SensitivityCalibrationCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.SensitivityCalibrationCheckBox.Name = "SensitivityCalibrationCheckBox";
            this.SensitivityCalibrationCheckBox.Size = new System.Drawing.Size(147, 48);
            this.SensitivityCalibrationCheckBox.TabIndex = 8;
            this.SensitivityCalibrationCheckBox.Text = "Use sensitivity calibration";
            this.SensitivityCalibrationCheckBox.UseVisualStyleBackColor = true;
            this.SensitivityCalibrationCheckBox.CheckedChanged += new System.EventHandler(this.SensitivityCalibrationCheckBox_CheckedChanged);
            // 
            // buttonRun
            // 
            this.buttonRun.BackColor = System.Drawing.Color.Green;
            this.buttonRun.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRun.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRun.Location = new System.Drawing.Point(15, 239);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(113, 32);
            this.buttonRun.TabIndex = 18;
            this.buttonRun.Text = "RUN";
            this.buttonRun.UseVisualStyleBackColor = false;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(20, -32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1144, 428);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // zed
            // 
            this.zed.Location = new System.Drawing.Point(20, 0);
            this.zed.Margin = new System.Windows.Forms.Padding(4);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(1155, 411);
            this.zed.TabIndex = 29;
            // 
            // lblStopWatch
            // 
            this.lblStopWatch.AutoSize = true;
            this.lblStopWatch.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopWatch.Location = new System.Drawing.Point(11, 324);
            this.lblStopWatch.Name = "lblStopWatch";
            this.lblStopWatch.Size = new System.Drawing.Size(80, 13);
            this.lblStopWatch.TabIndex = 17;
            this.lblStopWatch.Text = "lblStopWatch";
            this.lblStopWatch.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSpectrum);
            this.tabControl1.Controls.Add(this.tabPagePeakTrack);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1286, 574);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPageSpectrum
            // 
            this.tabPageSpectrum.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSpectrum.Controls.Add(this.trackZoom);
            this.tabPageSpectrum.Controls.Add(this.labelSec);
            this.tabPageSpectrum.Controls.Add(this.comboSampleTime);
            this.tabPageSpectrum.Controls.Add(this.labelSampleTime);
            this.tabPageSpectrum.Controls.Add(this.selectAllBox);
            this.tabPageSpectrum.Controls.Add(this.removePeakButton);
            this.tabPageSpectrum.Controls.Add(this.peaksPanel);
            this.tabPageSpectrum.Controls.Add(this.buttonSaveLog);
            this.tabPageSpectrum.Controls.Add(this.buttonAddPeak);
            this.tabPageSpectrum.Controls.Add(this.lblStopWatch);
            this.tabPageSpectrum.Controls.Add(this.pictureBox1);
            this.tabPageSpectrum.Controls.Add(this.buttonRun);
            this.tabPageSpectrum.Controls.Add(this.InitializeButton);
            this.tabPageSpectrum.Controls.Add(this.SensitivityCalibrationCheckBox);
            this.tabPageSpectrum.Controls.Add(this.TakeSpectrumButton);
            this.tabPageSpectrum.Controls.Add(this.labelExposureTime);
            this.tabPageSpectrum.Controls.Add(this.ExpTimeNumericUpDown);
            this.tabPageSpectrum.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpectrum.Name = "tabPageSpectrum";
            this.tabPageSpectrum.Size = new System.Drawing.Size(1278, 548);
            this.tabPageSpectrum.TabIndex = 2;
            this.tabPageSpectrum.Text = "Spectrum";
            // 
            // trackZoom
            // 
            this.trackZoom.BackColor = System.Drawing.SystemColors.Control;
            this.trackZoom.Location = new System.Drawing.Point(998, 292);
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(243, 45);
            this.trackZoom.TabIndex = 37;
            this.trackZoom.TickFrequency = 10;
            this.trackZoom.Visible = false;
            // 
            // labelSec
            // 
            this.labelSec.AutoSize = true;
            this.labelSec.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSec.Location = new System.Drawing.Point(111, 90);
            this.labelSec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSec.Name = "labelSec";
            this.labelSec.Size = new System.Drawing.Size(16, 18);
            this.labelSec.TabIndex = 36;
            this.labelSec.Text = "s";
            // 
            // comboSampleTime
            // 
            this.comboSampleTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboSampleTime.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.comboSampleTime.FormattingEnabled = true;
            this.comboSampleTime.Items.AddRange(new object[] {
            "0.1 s (100 ms)",
            "1 s",
            "10 s",
            "60 s",
            "600 s (10 min)",
            "1200 s (20 min)",
            "1800 s (30 min)",
            "3600 s (1 h)",
            "10800 s (3 h)"});
            this.comboSampleTime.Location = new System.Drawing.Point(8, 160);
            this.comboSampleTime.Name = "comboSampleTime";
            this.comboSampleTime.Size = new System.Drawing.Size(140, 21);
            this.comboSampleTime.TabIndex = 35;
            this.comboSampleTime.Text = "0.1 s (100 ms)";
            // 
            // labelSampleTime
            // 
            this.labelSampleTime.AutoSize = true;
            this.labelSampleTime.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSampleTime.Location = new System.Drawing.Point(7, 130);
            this.labelSampleTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSampleTime.Name = "labelSampleTime";
            this.labelSampleTime.Size = new System.Drawing.Size(123, 18);
            this.labelSampleTime.TabIndex = 34;
            this.labelSampleTime.Text = "Sampling Time:";
            // 
            // selectAllBox
            // 
            this.selectAllBox.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllBox.Location = new System.Drawing.Point(10, 340);
            this.selectAllBox.Name = "selectAllBox";
            this.selectAllBox.Size = new System.Drawing.Size(124, 39);
            this.selectAllBox.TabIndex = 33;
            this.selectAllBox.Text = "Select All Peaks";
            this.selectAllBox.UseVisualStyleBackColor = true;
            this.selectAllBox.CheckedChanged += new System.EventHandler(this.selectAllBox_CheckedChanged);
            // 
            // removePeakButton
            // 
            this.removePeakButton.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePeakButton.ForeColor = System.Drawing.Color.Black;
            this.removePeakButton.Location = new System.Drawing.Point(14, 434);
            this.removePeakButton.Margin = new System.Windows.Forms.Padding(2);
            this.removePeakButton.Name = "removePeakButton";
            this.removePeakButton.Size = new System.Drawing.Size(114, 24);
            this.removePeakButton.TabIndex = 32;
            this.removePeakButton.Text = "Remove Peak";
            this.removePeakButton.UseVisualStyleBackColor = true;
            this.removePeakButton.Click += new System.EventHandler(this.removePeakButton_Click);
            // 
            // peaksPanel
            // 
            this.peaksPanel.AutoScroll = true;
            this.peaksPanel.Controls.Add(this.peaksTable);
            this.peaksPanel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peaksPanel.Location = new System.Drawing.Point(145, 281);
            this.peaksPanel.Name = "peaksPanel";
            this.peaksPanel.Size = new System.Drawing.Size(835, 247);
            this.peaksPanel.TabIndex = 31;
            this.peaksPanel.Text = "Peak Tracker";
            // 
            // peaksTable
            // 
            this.peaksTable.AutoSize = true;
            this.peaksTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.peaksTable.BackColor = System.Drawing.Color.White;
            this.peaksTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.peaksTable.ColumnCount = 6;
            this.peaksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.peaksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.peaksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.peaksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.peaksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.peaksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.peaksTable.Controls.Add(this.labelPeakName, 1, 0);
            this.peaksTable.Controls.Add(this.waveLengthsL, 2, 0);
            this.peaksTable.Controls.Add(this.waveLengthsR, 3, 0);
            this.peaksTable.Controls.Add(this.labelCOGResult, 5, 0);
            this.peaksTable.Controls.Add(this.labelSavePeak, 0, 0);
            this.peaksTable.Controls.Add(this.labelThreshold, 4, 0);
            this.peaksTable.ForeColor = System.Drawing.Color.Black;
            this.peaksTable.Location = new System.Drawing.Point(16, 19);
            this.peaksTable.Margin = new System.Windows.Forms.Padding(2);
            this.peaksTable.Name = "peaksTable";
            this.peaksTable.RowCount = 1;
            this.peaksTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.peaksTable.Size = new System.Drawing.Size(814, 54);
            this.peaksTable.TabIndex = 30;
            // 
            // labelPeakName
            // 
            this.labelPeakName.AutoSize = true;
            this.labelPeakName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeakName.Location = new System.Drawing.Point(106, 1);
            this.labelPeakName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPeakName.Name = "labelPeakName";
            this.labelPeakName.Size = new System.Drawing.Size(49, 18);
            this.labelPeakName.TabIndex = 38;
            this.labelPeakName.Text = "Peak";
            // 
            // waveLengthsL
            // 
            this.waveLengthsL.AutoSize = true;
            this.waveLengthsL.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveLengthsL.Location = new System.Drawing.Point(200, 1);
            this.waveLengthsL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.waveLengthsL.Name = "waveLengthsL";
            this.waveLengthsL.Size = new System.Drawing.Size(143, 18);
            this.waveLengthsL.TabIndex = 37;
            this.waveLengthsL.Text = "Left Wavelength";
            // 
            // waveLengthsR
            // 
            this.waveLengthsR.AutoSize = true;
            this.waveLengthsR.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveLengthsR.Location = new System.Drawing.Point(349, 1);
            this.waveLengthsR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.waveLengthsR.Name = "waveLengthsR";
            this.waveLengthsR.Size = new System.Drawing.Size(153, 18);
            this.waveLengthsR.TabIndex = 36;
            this.waveLengthsR.Text = "Right Wavelength";
            // 
            // labelCOGResult
            // 
            this.labelCOGResult.AutoSize = true;
            this.labelCOGResult.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCOGResult.Location = new System.Drawing.Point(621, 1);
            this.labelCOGResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCOGResult.Name = "labelCOGResult";
            this.labelCOGResult.Size = new System.Drawing.Size(165, 18);
            this.labelCOGResult.TabIndex = 35;
            this.labelCOGResult.Text = "COG in Wavelength";
            // 
            // labelSavePeak
            // 
            this.labelSavePeak.AutoSize = true;
            this.labelSavePeak.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSavePeak.Location = new System.Drawing.Point(3, 1);
            this.labelSavePeak.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSavePeak.Name = "labelSavePeak";
            this.labelSavePeak.Size = new System.Drawing.Size(58, 36);
            this.labelSavePeak.TabIndex = 34;
            this.labelSavePeak.Text = "Track Peak";
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThreshold.Location = new System.Drawing.Point(513, 1);
            this.labelThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(98, 18);
            this.labelThreshold.TabIndex = 33;
            this.labelThreshold.Text = "Thresholde";
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveLog.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveLog.Location = new System.Drawing.Point(15, 481);
            this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(114, 24);
            this.buttonSaveLog.TabIndex = 29;
            this.buttonSaveLog.Text = "Save Data Log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonAddPeak
            // 
            this.buttonAddPeak.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPeak.ForeColor = System.Drawing.Color.Black;
            this.buttonAddPeak.Location = new System.Drawing.Point(15, 385);
            this.buttonAddPeak.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddPeak.Name = "buttonAddPeak";
            this.buttonAddPeak.Size = new System.Drawing.Size(114, 24);
            this.buttonAddPeak.TabIndex = 28;
            this.buttonAddPeak.Text = "Add new peak";
            this.buttonAddPeak.UseVisualStyleBackColor = true;
            this.buttonAddPeak.Click += new System.EventHandler(this.buttonAddPeak_Click);
            // 
            // tabPagePeakTrack
            // 
            this.tabPagePeakTrack.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePeakTrack.Controls.Add(this.zed);
            this.tabPagePeakTrack.Controls.Add(this.pictureBox2);
            this.tabPagePeakTrack.Location = new System.Drawing.Point(4, 22);
            this.tabPagePeakTrack.Name = "tabPagePeakTrack";
            this.tabPagePeakTrack.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePeakTrack.Size = new System.Drawing.Size(1196, 548);
            this.tabPagePeakTrack.TabIndex = 1;
            this.tabPagePeakTrack.Text = "Peak Track";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 574);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
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
            this.tabPageSpectrum.ResumeLayout(false);
            this.tabPageSpectrum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.peaksPanel.ResumeLayout(false);
            this.peaksPanel.PerformLayout();
            this.peaksTable.ResumeLayout(false);
            this.peaksTable.PerformLayout();
            this.tabPagePeakTrack.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Button InitializeButton;
        private System.Windows.Forms.NumericUpDown ExpTimeNumericUpDown;
        private System.Windows.Forms.Button TakeSpectrumButton;
        private System.Windows.Forms.Label labelExposureTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel InitStatusLabel;
        private System.Windows.Forms.CheckBox SensitivityCalibrationCheckBox;
        private System.Windows.Forms.Button buttonRun;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblStopWatch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePeakTrack;
        private System.Windows.Forms.TabPage tabPageSpectrum;
        private ZedGraph.ZedGraphControl zed;
      
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;



        private System.Windows.Forms.Button buttonAddPeak;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.TableLayoutPanel peaksTable;
        private System.Windows.Forms.Panel peaksPanel;
        private System.Windows.Forms.Button removePeakButton;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.Label labelSavePeak;
        private System.Windows.Forms.Label labelPeakName;
        private System.Windows.Forms.Label waveLengthsL;
        private System.Windows.Forms.Label waveLengthsR;
        private System.Windows.Forms.Label labelCOGResult;
        private System.Windows.Forms.CheckBox selectAllBox;

        private System.Windows.Forms.Label labelSampleTime;
        private System.Windows.Forms.ComboBox comboSampleTime;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.TrackBar trackZoom;
        }
    }

