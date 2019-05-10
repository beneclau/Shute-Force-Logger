/*
 * SIMPLE SPECTROMETER
 * 
 * A simple program to take a spectrum with a Qwave, Qmini or Qstick spectrometer
 * 
 * demonstrating how to use the RGBDriverKit library in order to
 * use the spectrometer from your own software.
 //* 
 * Copyright 2016 RGB Photonics GmbH
 * written by Joerg Ehehalt
 *
 * Version 1.3.0 - June 15, 2016
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using RgbDriverKit;          //The Library file RgbDriverKit.dll must be added to your project as a reference.
using System.Diagnostics;
using System.Threading;
//using SHUTEmjoelner;
using ZedGraph;
using SHUTE_Logger;
using System.Drawing.Drawing2D;

namespace SimpleSpectrometer
    {


    public partial class MainForm : Form
        {
        //CLASS HIERARCHY:

        //The main class that you need in order to communicate with the device is:
        //Qseries or RgbSpectrometer or Qstick,
        //    which is a descendant of the CalibratedSpectrometerSpectrometer class,
        //      which is a descendant of the Spectrometer class,
        //        which is a descendant of the Device class.

        //(RgbSpectrometer and Qstick are also a descendant of the ThreadedCalibratedSpectrometer class)

        //"Device" includes basic features used by all kinds of laboratory equipment.
        //"Spectrometer" is a base class for a simple spectrometer.
        //"CalibratedSpectrometer" is a base class for a spectrometer that is calibrated for sensitivity, nonlinearity and dark spectra.
        //"ThreadedCalibratedSpectrometer" is a base class for a spectrometer that also includes a separate thread for reading out data from the device.

        //The library also includes the "SimulatedSpectrometer" class, that may be used instead
        //in order to test your software if you don't have a real device available.

        private Spectrometer spectrometer; //the actual device class to communicate with the device
                                           //Here, we could also use another spectrometer class, however,
                                           //using the base class gives us more flexibility to change
                                           //the driver for the actual device later.




        public static List<float> intensities2;
        public static float[] intensitiesSpectrum;

       // public static string stringOfPeaks = Microsoft.VisualBasic.Interaction.InputBox("Insert the number of peaks to track", "Peaks", "2", 600, 300);
       // public static int numberOfPeaks = Int32.Parse(stringOfPeaks);
        //float[] peaksValues = new float[numberOfPeaks];

        public static double[] zeros = new double[] { 0, 0, 0, 0 };
        public static List<COG> peaks = new List<COG>(); //List of COGs. At the beginning the list is initialized with as many COGs as numberOfPeaks 
        public static List<PeakTrace> traces = new List<PeakTrace>();

        //Graphic elements lists in order to create them dynamically 
        public static List<NumericUpDown> wLeft = new List<NumericUpDown>();
        public static List<NumericUpDown> wRight = new List<NumericUpDown>();
        public static List<NumericUpDown> threshList = new List<NumericUpDown>();
        public static List<System.Windows.Forms.Label> labelPList = new List<System.Windows.Forms.Label>();
        public static List<System.Windows.Forms.Label> labelCOG = new List<System.Windows.Forms.Label>();
        public static List<CheckBox> peaksCheck = new List<CheckBox>();

        //Elements for choosing a device from a list of devices. 
        public static List<Spectrometer> devices = new List<Spectrometer>(); //LKist containing all the devices found
        public static ListBox devicesListBox = new ListBox();
        public static Form formBox = new Form();

        //Lists containing values used for drawing on  the Spectrum tab
        public static List<PeakTrace> peakTrace1 = new List<PeakTrace>();
        public static List<int> peakInt = new List<int>();
        public static List<int> waveLInt = new List<int>();
        public static List<int> waveRInt = new List<int>();
        public static List<int> thresInt = new List<int>();


        // Lists containing the values used for drawing the zedgraph at real time on the Peak Track tab
        public static List<float> maxValues = new List<float>();
        public static List<RollingPointPairList> listRollingPoint = new List<RollingPointPairList>(10000);
        List<LineItem> curves = new List<LineItem>();
        List<IPointListEdit> list = new List<IPointListEdit>();

        //Predefined set of colors to choose from in the zed graph
        public static Color[] colors = { Color.Blue, Color.Orange, Color.OrangeRed, Color.Orchid, Color.Pink, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkSeaGreen, Color.SpringGreen, Color.Purple, Color.Violet, Color.MediumVioletRed, Color.Red, Color.Green, Color.AliceBlue, Color.Aqua, Color.Aquamarine, Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chocolate, Color.Coral, Color.Crimson, Color.DarkBlue };



        public BackgroundWorker workerThread = null;   // BackgroundWorker in charge of running and stopping the data collection


        bool _keepRunning = false;

        public static int TickStart = 1;
        int intMode = 1;

        System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();    //timer used for log file

        System.Windows.Forms.Timer timerZedGraph = new System.Windows.Forms.Timer(); // timer used for zedgraph sampling time
      

        SaveFileDialog sfd = new SaveFileDialog(); //Saving dialog for log file 
        StreamWriter writingFileTest2; // Streamwriter to write on the log file

        Random random = new Random();

        Graphics gr;


        public MainForm()
            {
    
            InitializeComponent();
            InstantiateWorkerThread();
            string[] sPorts = SerialPort.GetPortNames();
            serialPort1.PortName = sPorts[0]; //Arduino
            serialPort2.PortName = sPorts[1]; // Force Gauge
            serialPort2.BaudRate = 256000;
            serialPort2.Parity = Parity.None;
            serialPort2.DataBits = 8;
            serialPort2.StopBits = StopBits.One;
            serialPort2.Handshake = Handshake.RequestToSend;
           
          
           serialPort1.Open();
           //serialPort1.Write("1");
            serialPort1.Write("1");
            //serialPort1.Write("1");
            serialPort2.Open();
            serialPort2.Write("D\r");

            // Debug.WriteLine("SERIALPORT2 DEBUG " + serialPort2.RtsEnable);
            serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort2_DataReceived);


           // Debug.WriteLine("SERIALPORTSNUMBERS" + serialPort2.DataReceived);


            }


        private void InstantiateWorkerThread()
            {
            //Thread operations
            workerThread = new BackgroundWorker();
            workerThread.ProgressChanged += WorkerThread_ProgressChanged;
            workerThread.DoWork += WorkerThread_DoWork;
            workerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
            workerThread.WorkerReportsProgress = true;
            workerThread.WorkerSupportsCancellation = true;

            }

        // ********** Initialize the spectrometer **********

        private void InitializeButton_Click(object sender, EventArgs e)
            {

            //Close any previously used spectrometer (in case user clicks on the button more than once)
            if (spectrometer != null)
                {
                spectrometer.Close();
                }
            if (peaksTable.RowCount > 1) //If initialized is pressed after the program has been running already --> restart
                {
                Application.Restart();
                }
            //This static method searches for devices and returns a list of driver for the available devices.
            Spectrometer[] devicesQ = Qseries.SearchDevices();
            Spectrometer[] devicesRGB = RgbSpectrometer.SearchDevices();
            Spectrometer[] devicesQstick = Qstick.SearchDevices();


            foreach (Spectrometer item in devicesQ)
                {
                devices.Add(item);
                }
            foreach (Spectrometer item in devicesRGB)
                {
                devices.Add(item);
                }

            foreach (Spectrometer item in devicesQstick)
                {
                devices.Add(item);
                }

            //If no device1 was found:
            if (devices.Count == 0)
                {
                InitStatusLabel.Text = "No spectrometer found.";
                MessageBox.Show("No spectrometer found.", "Cannot initialize spectrometer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

                }

            //Otherwise, take the first device and initialize it.
            else if (devices.Count == 1)
                {
                spectrometer = devices[0];
                }
            else
                {

                //possibility to choose from a list which device you want to use 

                devicesListBox.Location = new Point(12, 12);
                devicesListBox.Name = "devicesListBox";
                devicesListBox.Size = new Size(290, 245);

                foreach (Spectrometer item in devices)
                    {
                    devicesListBox.Items.Add(item + " " + item.SerialNo);

                    }

                
                Button okBoxButton = new Button();
                okBoxButton.DialogResult = DialogResult.OK;
                okBoxButton.Text = "OK";
                okBoxButton.Dock = DockStyle.Bottom;
                okBoxButton.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); ;

                // okBoxButton.Anchor = (AnchorStyles.Bottom); // | AnchorStyles.Right | AnchorStyles.Left);
                //okBoxButton.Enabled = false;

                devicesListBox.Dock = DockStyle.Top;
                devicesListBox.BackColor = Color.Silver;
                devicesListBox.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); ;

                formBox.Controls.Add(okBoxButton);
                formBox.Controls.Add(devicesListBox);
                formBox.ShowDialog();

                // devicesListBox.SelectedIndexChanged += new EventHandler(devicesListBox_SelectedIndexChanged);
                int selected = devicesListBox.SelectedIndex;

                if (selected >= 0)
                    {
                    okBoxButton.Enabled = true;
                    spectrometer = devices[selected];
                    }
                else
                    {
                    spectrometer = devices[0];

                    }
                //okBoxButton.Click += new EventHandler(okBoxButton_Click);
                }

            try
                {
                InitStatusLabel.Text = "Initializing spectrometer ...";
                statusStrip1.Update();

                spectrometer.Open();

                //Get the wavelength of each pixel (this is not actually used in this sample code)
                double[] wavelengths = spectrometer.GetWavelengths();

                //Initialize values in GUI
                ExpTimeNumericUpDown.Value = (decimal)spectrometer.ExposureTime;
                if (spectrometer is CalibratedSpectrometer)
                    {
                    SensitivityCalibrationCheckBox.Checked = (spectrometer as CalibratedSpectrometer).UseSensitivityCalibration;
                    SensitivityCalibrationCheckBox.Enabled = true;
                    }
                else
                    {
                    SensitivityCalibrationCheckBox.Checked = false;
                    SensitivityCalibrationCheckBox.Enabled = false;
                    }

                //create as many empty COG objects as numberOfPeaks chosen from the user, adding them to the COG list
               
                    peaks.Add(new COG(zeros, 0, 0, 0, 0, 0));
                    peaksTable.RowCount += 1;
                    peaksTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
                   
                //      (spectrometer as CalibratedSpectrometer).UseExternalTrigger = true;

                // Initialization of the peaks 
             
                    //Add an element to each list defining a property for the peak
                    wLeft.Add(new NumericUpDown());
                    wRight.Add(new NumericUpDown());
                    threshList.Add(new NumericUpDown());
                    labelPList.Add(new System.Windows.Forms.Label());
                    labelCOG.Add(new System.Windows.Forms.Label());
                    peaksCheck.Add(new CheckBox());

                    //Creating and setting  values for the NumericUpAndDown for wavelengths left, right and thresholde
                    SetWavesLeft(wLeft[0]);
                    wLeft[0].Name = $"waveLengthLeft1";
                    peaksTable.Controls.Add(wLeft[0], 2, 1);

                    SetWavesRight(wRight[0]);
                    wRight[0].Name = $"waveLengthRight1";
                    peaksTable.Controls.Add(wRight[0], 3, 1);

                    SetThres(threshList[0]);
                    threshList[0].Name = $"threshold1";
                    peaksTable.Controls.Add(threshList[0], 4, 1);

                    //Creating labels for peak names and peak values
                    SetLabelP(labelPList[0]);
                    labelPList[0].Text = $"Peak1";
                    peaksTable.Controls.Add(labelPList[0], 1, 1);

                    SetLabelP(labelCOG[0]);
                    labelCOG[0].Name = $"COGResult1";
                    labelCOG[0].Text = $"{peaks[0].GetCOGinWaveLength()}";
                    peaksTable.Controls.Add(labelCOG[0], 5,1);

                    SetCheckBox(peaksCheck[0]);
                    peaksCheck[0].Name = $"SavingBox1";
                    peaksCheck[0].Checked = true;
                    peaksTable.Controls.Add(peaksCheck[0], 0,1);




                  

                //Initialize every COG object in the peaks list
                for (int i = 0; i < peaks.Count; i++)
                    {
                    InitPeak(peaks[i], spectrometer.WavelengthCoefficients, wLeft[i], wRight[i], threshList[i]);

                    }



                InitStatusLabel.Text = "Found " + spectrometer.DetailedDeviceName;
                MessageBox.Show("Device name: " + spectrometer.ModelName + Environment.NewLine
                    + "Manufacturer: " + spectrometer.Manufacturer + Environment.NewLine
                    + "Serial number: " + spectrometer.SerialNo + Environment.NewLine
                    + "Number of pixels: " + spectrometer.PixelCount,
                    "Spectrometer found and initialized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            catch (Exception ex)
                {
                spectrometer = null;
                InitStatusLabel.Text = "Initialization error.";
                MessageBox.Show(ex.Message, "Cannot initialize spectrometer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        // ********** Set the exposure time **********

        private void ExpTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
            {


            if (spectrometer == null) return;

            try
                {
                float newtime = (float)ExpTimeNumericUpDown.Value;
                if (newtime < spectrometer.MinExposureTime || newtime > spectrometer.MaxExposureTime)
                    {
                    ExpTimeNumericUpDown.Value = (decimal)spectrometer.ExposureTime;
                    throw new Exception("Exposure time value out of range.");
                    }
                spectrometer.ExposureTime = newtime;


                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "Cannot set exposure time",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        private void ExpTimeNumericUpDown_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
            {
            ((HandledMouseEventArgs)e).Handled = true;
            //MouseWheel is disabled because the change was too fast and it was freezing the program
            }

        private void SensitivityCalibrationCheckBox_CheckedChanged(object sender, EventArgs e)
            {
            if (spectrometer is CalibratedSpectrometer)
                (spectrometer as CalibratedSpectrometer).UseSensitivityCalibration = SensitivityCalibrationCheckBox.Checked;
            }

        // ********** Take a spectrum *********

        private void TakeSpectrumButton_Click(object sender, EventArgs e)
            {


            if (spectrometer == null) return;
            try
                {
                spectrometer.StartExposure();

                while (spectrometer.Status > SpectrometerStatus.Idle) //this could be SpectrometerStatus.TakingSpectrum or SpectrometerStatus.WaitingForTrigger
                    {  
                    //Thread.Sleep(50);
                    //Taking a spectrum could be aborted with: spectrometer.CancelExposure()
                    }

                IntensitiesDrawing();



                // writing peaks value in the last column of the table at run time
                for (int i = 0; i < peaks.Count; i++)
                    {
                    labelCOG[i].Text = $"{peaks[i].COGinWaveLength}";

                    }



                }

           catch (Exception ex)
                {
             //   MessageBox.Show(ex.Message, "Cannot take spectrum",
                   // MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        //Drawing of spectrum and waves left, right, tresholde and peak.
        private void IntensitiesDrawing()
            {

            intensitiesSpectrum = spectrometer.GetSpectrum();

            int length = 100;



            float max = intensitiesSpectrum[0];
            float min = intensitiesSpectrum[0];

            for (int j = 0; j < length; j++)
                {
                if (intensitiesSpectrum[j] > max) max = intensitiesSpectrum[j];
                if (intensitiesSpectrum[j] < min) min = intensitiesSpectrum[j];

                }


            //You could also call spectrometer.GetSpectrumData() instead, which return a structure with some more information about the spectrum.               
            //If you also need the corresponsing wavelengths for each point, please see above in the initialization section.

            List<float> intensitiesListSpectrum = intensitiesSpectrum.ToList();
            DrawDiagram(intensitiesSpectrum);

            }

        // Action to perform when the Form is closed
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
            if (spectrometer != null)
                {
                spectrometer.Close(); //Close the spectrometrer
                }
            if (writingFileTest2 != null) //Close the log file, in case it exists
                {
                writingFileTest2.Close();
                //*time.Stop();
                }

            }

        private void DrawDiagram(float[] values)  //Draw spectrum and wavelengths
            {

            using (gr = pictureBox1.CreateGraphics())
                {

                gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
                

                float min = float.MaxValue;
                float max = float.MinValue;
                for (int i = 0; i < values.Length; i++)
                    {
                    if (values[i] < min) min = values[i];
                    if (values[i] > max) max = values[i];
                    }

                Point[] points = new Point[values.Length];

                 for (int i = 0; i < values.Length; i++)
                     {
                     points[i].X = i * (pictureBox1.Width - 1) / values.Length;
                     points[i].Y = (pictureBox1.Height - 1) - (int)((values[i] - min) / (max - min) * (pictureBox1.Height - 1));

                     }
                     
                

               
                gr.DrawLines(Pens.Maroon, points);

                float[] newvalues = new float[500];
                Array.Copy(values, 500, newvalues, 0, 500);
            
                for (int i = 0; i < peaks.Count; i++)
                    {
                    
                    if (peaksCheck[i].Checked)
                        {
                        peakInt.Add(new int());
                        waveLInt.Add(new int());
                        waveRInt.Add(new int());
                        thresInt.Add(new int());
                        peakTrace1.Add(new PeakTrace());
                      
                        peaks[i].COGresult = peaks[i].GetCOG(values);
                       
                        peakTrace1[i].AddPeak(peaks[i].COGinWaveLength, 1.123);

                        peakInt[i] = (int)(peaks[i].COGresult  * (pictureBox1.Width - 1f) / values.Length);
                        waveLInt[i] = (int)(peaks[i].GetPixelLeft()  * (pictureBox1.Width - 1f) / values.Length);
                        waveRInt[i] = (int)(peaks[i].GetPixelRight() * (pictureBox1.Width - 1f) / values.Length);
                        thresInt[i] = (pictureBox1.Height - 1) - (int)((peaks[i].GetPeakThresholde() - min) / (max - min) * (pictureBox1.Height - 1));

                        Debug.WriteLine( $"PEAKS {peakInt[0]}");

                        gr.DrawLine(Pens.Red, peakInt[i], 0f, peakInt[i], pictureBox1.Height);
                        gr.DrawLine(Pens.Green, waveLInt[i], 0f, waveLInt[i], pictureBox1.Height);
                        gr.DrawLine(Pens.Blue, waveRInt[i], 0f, waveRInt[i], pictureBox1.Height);
                        gr.DrawLine(Pens.Violet, 0, thresInt[i], pictureBox1.Width, thresInt[i]);

                        }
                    }



                gr.DrawRectangle(Pens.Black, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);



                }

            }

        //Events occurring when a value in one of the numericUpDown is changed

        private void waveLengthsLeft_ValueChanged(object sender, EventArgs e)
            {
            NumericUpDown left = sender as NumericUpDown;
            peaks[wLeft.IndexOf(left)].waveLeft = (float)left.Value;

            }


        private void waveLengthsRight_ValueChanged(object sender, EventArgs e)
            {
            NumericUpDown right = sender as NumericUpDown;
            int rightInt = wRight.IndexOf(right);
            peaks[rightInt].waveRight = (float)right.Value;

            }


        private void thresh_ValueChanged(object sender, EventArgs e)
            {
            NumericUpDown thresh = sender as NumericUpDown;
            peaks[threshList.IndexOf(thresh)].waveLeft = (float)thresh.Value;

            }


      private void trackZoom_ValueChanged(object sender, EventArgs e)
            {

            gr.ScaleTransform(0.2f/pictureBox1.Width, 0.2f/pictureBox1.Height);
            }
            
        private void InitSpectrometer()
            {

            //Close any previously used spectrometer (in case user clicks on the button more than once)
            if (spectrometer != null) spectrometer.Close();

            //This static method searches for devices and returns a list of driver for the available devices.
            Spectrometer[] devices = Qseries.SearchDevices();
            Debug.WriteLine($"devices @@@@ {devices.Length}");
            if (devices.Length == 0) devices = RgbSpectrometer.SearchDevices();
            if (devices.Length == 0) devices = Qstick.SearchDevices();

            //If no device was found:
            if (devices.Length == 0)
                {
                InitStatusLabel.Text = "No spectrometer found.";
                MessageBox.Show("No spectrometer found.", "Cannot initialize spectrometer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            else if (devices.Length == 1)
                {
                spectrometer = devices[0];
                }
            else
                {
                Debug.WriteLine($"2 spectrometers found");
                spectrometer = devices[0];
                }

            //Otherwise, take the first device and initialize it.

            try
                {
                InitStatusLabel.Text = "Initializing spectrometer ...";
                statusStrip1.Update();

                spectrometer.Open();

                //Get the wavelength of each pixel (this is not actually used in this sample code)
                double[] wavelengths = spectrometer.GetWavelengths();

                //Initialize values in GUI
                //ExpTimeNumericUpDown.Value = (decimal)spectrometer.ExposureTime;
                ExpTimeNumericUpDown.Value = (decimal)spectrometer.ExposureTime;
                if (spectrometer is CalibratedSpectrometer)
                    {
                    SensitivityCalibrationCheckBox.Checked = (spectrometer as CalibratedSpectrometer).UseSensitivityCalibration;
                    SensitivityCalibrationCheckBox.Enabled = true;
                    //checkBoxEksternTrigger.Checked = (spectrometer as CalibratedSpectrometer).UseExternalTrigger;
                    }
                else
                    {
                    SensitivityCalibrationCheckBox.Checked = false;
                    SensitivityCalibrationCheckBox.Enabled = false;
                    }

                //      (spectrometer as CalibratedSpectrometer).UseExternalTrigger = true;


                }
            catch (Exception ex)
                {
                spectrometer = null;
                InitStatusLabel.Text = "Initialization error.";
                MessageBox.Show(ex.Message, "Cannot initialize spectrometer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


        //----------Thread

        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
            lblStopWatch.Text = e.UserState.ToString();

            for (int i = 0; i < labelCOG.Count; i++)
                {
                labelCOG[i].Text = $"{(peaks[i].COGinWaveLength)}";
                }

            }

        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
            //Event called whenm the cancellation of the thread is set to true and all the actions in the therad are completed 

            //MessageBox.Show((new StackTrace().GetFrame(0).GetMethod().Name));

            if (e.Cancelled)
                {

                lblStopWatch.Text = "Cancelled";
                //workerThread.Dispose();
                }
            else
                {
                lblStopWatch.Text = "Stopped";
                }
            }

        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
            {
            //Work during the thread

            //MessageBox.Show((new StackTrace().GetFrame(0).GetMethod().Name));
            // MessageBox.Show((new StackTrace().ToString()));
            _keepRunning = true;

            while (_keepRunning)
                {

                //Thread.Sleep(1000);
                string timeElapsedInstring = "00";// (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
                workerThread.ReportProgress(0, timeElapsedInstring);

                for (int i = 0; i < peaks.Count; i++)
                    {
                    workerThread.ReportProgress(0, peaks[i].COGinWaveLength);
                    }

                // workerThread.ReportProgress(0, peak2.COGinWaveLength); //non so se serve




                if (spectrometer == null) return;
                try
                    {
                    spectrometer.StartExposure();

                    while (spectrometer.Status > SpectrometerStatus.Idle) //this could be SpectrometerStatus.TakingSpectrum or SpectrometerStatus.WaitingForTrigger
                        {
                        Thread.Sleep(50);
                        //Taking a spectrum could be aborted with: spectrometer.CancelExposure()
                        }

                    IntensitiesDrawing();


                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show(ex.Message, "Cannot take spectrum",
                     //   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                if (workerThread.CancellationPending)
                    {

                    // this is important as it set the cancelled property of RunWorkerCompletedEventArgs to true
                    e.Cancel = true;
                    break;
                    }
                }

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            
            }

        private void buttonRun_Click(object sender, EventArgs e)
            {
            //If press RUN
            if (buttonRun.Text == "RUN")
                {

                int index = comboSampleTime.SelectedIndex;

                if (peaksTable.RowCount < 2)  //If Initialization didn't happen yet, ask to initialize 
                    {
                    MessageBox.Show($"Please press initialize button first");
                    buttonRun.Text = "RUN";
                    buttonRun.BackColor = Color.Green;
                    }
                if (index == -1) // and ask to choose a sampling time 
                    {
                    MessageBox.Show($"Please choose a Sampling Time");
                    buttonRun.Text = "RUN";
                    buttonRun.BackColor = Color.Green;
                    }
                else
                    {
                    // Otherwise run the thread
                    buttonRun.Text = "STOP";
                    buttonRun.BackColor = Color.Red;

                    comboSampleTime.Enabled = false;

                    serialPort1.Write("2");
                    
                       // Debug.WriteLine("SERIALPORT1 DEBUG "+ serialPort1.ReadByte());
                   
                    //Switch for all the possible caqses of the sampling time box 

                    switch (index)
                        {


                        case 0:
                        timerZedGraph.Interval = 100;
                        break;

                        case 1:
                        timerZedGraph.Interval = 1000;
                        break;

                        case 2:
                        timerZedGraph.Interval = 10000;
                        break;

                        case 3:
                        timerZedGraph.Interval = 60000;
                        break;

                        case 4:
                        timerZedGraph.Interval = 600000;
                        break;

                        case 5:
                        timerZedGraph.Interval = 1200000;
                        break;

                        case 6:
                        timerZedGraph.Interval = 1800000;
                        break;

                        case 7:
                        timerZedGraph.Interval = 3600000;
                        break;

                        case 8:
                        timerZedGraph.Interval = 10800000;
                        break;



                        }
                    //Zedgraph is started
                    timerZedGraph.Stop();
                    timerZedGraph.Tick += new EventHandler(timerZedGraph_Tick);
                    timerZedGraph.Start();

                    //the thread is started
                    workerThread.RunWorkerAsync();
                    }
                }
            else
            //If press STOP
                {



                buttonRun.Text = "RUN";
                buttonRun.BackColor = Color.Green;
                comboSampleTime.Enabled = true;
                time.Stop(); //Stop the file log timer 

                if (writingFileTest2 != null) // Close the log fil, if existing and open
                    {
                    writingFileTest2.Close();
                    }

                workerThread.CancelAsync();  //Request for thread cancellation
                }
            }


        public void SetControlText(Control control, string text)
            {

            if (this.InvokeRequired)
                {
                this.Invoke(new Action<Control, string>(SetControlText), new object[] { control, text });
                }
            else
                {
                control.Text = text;
                }
            }
        //Actions to perform when the program is loaded
        private void MainForm_Load(object sender, EventArgs e)
            {

            InitSpectrometer(); //Initialize Spectrometer(s)

            DoubleBuffered = true;  //Avoid some of the flickering in the drawings of the spectrum
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Initialize Zedgraph
            zed.GraphPane.Title.Text = "Test";
            zed.GraphPane.XAxis.Title.Text = "Time(sec)";
            zed.GraphPane.YAxis.Title.Text = "Intensity (max value)";
            zed.GraphPane.XAxis.Title.FontSpec.Size = 17;
            zed.GraphPane.YAxis.Title.FontSpec.Size = 17;
            
            
           
                        listRollingPoint.Add(new RollingPointPairList(5000));
                        zed.GraphPane.AddCurve("Peak 1", listRollingPoint[0], colors[random.Next(0,colors.Length-1)], SymbolType.None);
                        curves.Add(new LineItem("Peak 1" , listRollingPoint[0], colors[random.Next(0, colors.Length-1)], SymbolType.None));
                      


            zed.GraphPane.XAxis.Scale.Min = 0;
            zed.GraphPane.XAxis.Scale.Max = 10;
            zed.GraphPane.XAxis.Scale.MinorStep = 1;
            zed.GraphPane.XAxis.Scale.MajorStep = 5;
            zed.AxisChange();

            for (int i = 0; i < curves.Count; i++)
                {
                list.Add(curves[i].Points as IPointListEdit);
                }

            TickStart = Environment.TickCount;

            //Define an event for the timer for the logger, to call whenever the time will be initialized 
            time.Tick += new EventHandler(time_Tick);

           // trackZoom.Value = (int)scaleX;
            trackZoom.ValueChanged += new EventHandler(trackZoom_ValueChanged);

            }
        // Draw the zedgraph at real time

        private void Draw(List<float> max)
            {

            if (zed.GraphPane.CurveList.Count <= 0)
                return;

            for (int i = 0; i < peaks.Count; i++)
                {
                curves[i] = zed.GraphPane.CurveList[i] as LineItem;
                }

            if (curves == null)
                return;

            if (list == null)
                return;

            double timeZed = (Environment.TickCount - TickStart) / 1000.0;
            for (int i = 0; i < peaks.Count; i++)
                {
                if (peaksCheck[i].Checked)
                    {
                    list[i].Add(timeZed, max[i]);

                    }
                }

            Scale xScale = zed.GraphPane.XAxis.Scale;
            if (timeZed > xScale.Max - xScale.MajorStep)
                {
                if (intMode == 1)
                    {
                    xScale.Max = timeZed + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                    }
                else
                    {
                    xScale.Max = timeZed + xScale.MajorStep;
                    xScale.Min = 0;
                    }
                }

            zed.AxisChange();
            zed.Invalidate();
            }



        private void timerZedGraph_Tick(object sender, EventArgs e)
            {

            for (int i = 0; i < peaks.Count; i++)
                {
                maxValues.Add(new float());
                maxValues[i] = peaks[i].GetCOGinWaveLength();
                }

            Draw(maxValues);


            }

        // Write on the file everytime the timer ticks
        private void time_Tick(object sender, EventArgs e)
            {
            String CurrentDate;
            CurrentDate = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss:FFFFFFF");
            writingFileTest2.WriteLine($" Time: {CurrentDate}; Spectrum: {string.Join("; ", intensitiesSpectrum)}");
            for (int i = 0; i < peaks.Count; i++)
                {
                if (peaksCheck[i].Checked)
                    {
                    writingFileTest2.WriteLine($" PeakTrace {i + 1}:{peaks[i].GetCOGinWaveLength()}");
                    }
                }

            }

        //Method for initializing empty COG objects
        private void InitPeak(COG peakToInit, double[] Wavelengths, NumericUpDown wLeft, NumericUpDown wRight, NumericUpDown thres)
            {
            peakToInit.waveCof = Wavelengths;
            peakToInit.waveLeft = (float)wLeft.Value;
            peakToInit.waveRight = (float)wRight.Value;
            peakToInit.thresholde = (float)thres.Value * (float)0.01;

            }

        //Adding a peak and tracking it at run time
        private void buttonAddPeak_Click(object sender, EventArgs e)
            {
            /* if (peaks.Count >= colors.Length)
                 {
                 MessageBox.Show($"You reached the maximum number of peaks allowed!");
                 return;
                 }
                 */

            listRollingPoint.Add(new RollingPointPairList(5000));
            zed.GraphPane.AddCurve("Peak" + (listRollingPoint.Count).ToString(), listRollingPoint[listRollingPoint.Count - 1], colors[random.Next(0,colors.Length-1)], SymbolType.None);
            curves.Add(new LineItem("Peak" + (listRollingPoint.Count).ToString(), listRollingPoint[listRollingPoint.Count - 1], colors[random.Next(0, colors.Length - 1)], SymbolType.None));
            list.Add(curves[listRollingPoint.Count - 1].Points as IPointListEdit);
            maxValues.Add(new float());
            wLeft.Add(new NumericUpDown());
            wRight.Add(new NumericUpDown());
            threshList.Add(new NumericUpDown());
            labelPList.Add(new System.Windows.Forms.Label());
            labelCOG.Add(new System.Windows.Forms.Label());
            peaksCheck.Add(new CheckBox());
            peaks.Add(new COG(zeros, 0, 0, 0, 0, 0));


            peaksTable.RowCount = peaksTable.RowCount + 1;
            peaksTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));


            SetWavesLeft(wLeft[wLeft.Count - 1]);
            wLeft[wLeft.Count - 1].Name = "wavelengthLeft" + wLeft.Count.ToString();
            peaksTable.Controls.Add(wLeft[wLeft.Count - 1], 2, wLeft.Count);


            SetWavesRight(wRight[wRight.Count - 1]);
            wRight[wRight.Count - 1].Name = "wavelengthRight" + wRight.Count.ToString();
            peaksTable.Controls.Add(wRight[wRight.Count - 1], 3, wRight.Count);

            SetThres(threshList[threshList.Count - 1]);
            threshList[threshList.Count - 1].Name = "thresholde" + threshList.Count.ToString();
            peaksTable.Controls.Add(threshList[threshList.Count - 1], 4, threshList.Count);


            SetLabelP(labelPList[labelPList.Count - 1]);
            labelPList[labelPList.Count - 1].Text = $"Peak {labelPList.Count.ToString()}";
            peaksTable.Controls.Add(labelPList[labelPList.Count - 1], 1, labelPList.Count);

            SetCheckBox(peaksCheck[peaksCheck.Count - 1]);
            peaksCheck[peaksCheck.Count - 1].Name = $"SavingBox {peaksCheck.Count.ToString()}";
            peaksTable.Controls.Add(peaksCheck[peaksCheck.Count - 1], 0, peaksCheck.Count);

            SetLabelP(labelCOG[labelCOG.Count - 1]);
            labelCOG[labelCOG.Count - 1].Name = $"COGResult{(labelCOG.Count).ToString()}";
            labelCOG[labelCOG.Count - 1].Text = $"{peaks[labelCOG.Count - 1].GetCOGinWaveLength()}";
            peaksTable.Controls.Add(labelCOG[labelCOG.Count - 1], 5, labelCOG.Count);

            InitPeak(peaks[peaks.Count - 1], peaks[0].waveCof, wLeft[wLeft.Count - 1], wRight[wRight.Count - 1], threshList[threshList.Count - 1]);
            list[list.Count - 1].Add((Environment.TickCount - TickStart) / 1000.0, peaks[peaks.Count - 1].GetCOGinWaveLength());
            }

        //Event when Saving button is pressed
        private void buttonSaveLog_Click(object sender, EventArgs e)
            {

            if (peaksTable.RowCount < 2) //Prevent to save in case of initialization didn't happen
                {
                MessageBox.Show($"Please press initialize button first");
                }

            if (buttonSaveLog.Text == "Save Data Log")
                {
                time.Stop();  //stop eventual timer running

                if (!workerThread.IsBusy) //check and run the thread if it's not running already
                    {
                    workerThread.RunWorkerAsync();
                    }


                if (writingFileTest2 != null)  //close previous log file if existing and open
                    {
                    writingFileTest2.Close();
                    }


                buttonSaveLog.Text = "Stop Saving";
                ExpTimeNumericUpDown.Enabled = false;
                comboSampleTime.Enabled = false;

                //Ask if the user wants to save results
                DialogResult savingQuestion = MessageBox.Show("Do you want to save the reuslts?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (savingQuestion == DialogResult.Yes)
                    {
                    time.Stop();
                    sfd.Filter = "Text |*.txt";
                    sfd.Title = "Save a Text File";

                    if (sfd.ShowDialog() == DialogResult.Cancel)
                        {
                        buttonSaveLog.Text = "Save Data Log";
                        ExpTimeNumericUpDown.Enabled = true;
                        return;
                        }
                    else
                        {
                        // Set the interval for writing on the log file
                        string inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                        decimal inputDecimalInterval;
                        if (!inputStringInterval.All(char.IsDigit))  //to change to milliseconds line 1105
                            {
                            MessageBox.Show($"Please insert only numeric values");
                            buttonSaveLog.Text = "Save Data Log";
                            return;
                            }

                        if (Decimal.TryParse(inputStringInterval, out inputDecimalInterval))
                            {
                            inputDecimalInterval = decimal.Parse(inputStringInterval);
                            while (inputDecimalInterval == 0)
                                {
                                MessageBox.Show("Please insert only numeric values bigger than 0");
                                inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                                //if you stop and run again goes into an infinte loop --- INSTABLE CODE HERE
                                inputDecimalInterval = decimal.Parse(inputStringInterval);
                                }
                            }
                      

                        else
                            {
                            MessageBox.Show($"Unable to set the interval");
                            buttonSaveLog.Text = "Save Data Log";
                            return;
                            }


                        // Stop the timer in case of an already existing one, set the new interval, start new timer
                        time.Stop();

                        time.Interval = (int)(inputDecimalInterval * 1000);

                        time.Start();


                        //Streamwriter write to test
                        writingFileTest2 = new StreamWriter(sfd.FileName);
                        writingFileTest2.AutoFlush = true;
                        }

                    }
                else
                    {
                    buttonSaveLog.Text = "Save Data Log";
                    ExpTimeNumericUpDown.Enabled = true;
                    comboSampleTime.Enabled = true;
                    }
                }
            else
                {
                //If you press "Stop Saving"
                buttonSaveLog.Text = "Save Data Log";
                ExpTimeNumericUpDown.Enabled = true;

                time.Enabled = false;
                if (writingFileTest2 != null)
                    {
                    writingFileTest2.Close();
                    }
                buttonRun.Text = "RUN";
                buttonRun.BackColor = Color.Green;
                time.Stop();
                workerThread.CancelAsync();
                }


            }
        //Methods to create and initialize dynamically controls elements 
        private void SetWavesLeft(NumericUpDown waveToSet)
            {
            waveToSet.DecimalPlaces = 1;
            waveToSet.Maximum = new decimal(new int[] {
                        10860,
                        0,
                        0,
                        65536});
            waveToSet.Minimum = new decimal(new int[] {
                        6900,
                        0,
                        0,
                        65536});

            waveToSet.Size = new Size(65, 24);
            waveToSet.Value = new decimal(new int[] {
                        7000,
                        0,
                        0,
                        65536});
            waveToSet.Enabled = true;
            waveToSet.ValueChanged += new EventHandler(waveLengthsLeft_ValueChanged);



            }

        private void SetWavesRight(NumericUpDown waveToSet)
            {

            waveToSet.DecimalPlaces = 1;

            waveToSet.Maximum = new decimal(new int[] {
                        10860,
                        0,
                        0,
                        65536});
            waveToSet.Minimum = new decimal(new int[] {
                        6900,
                        0,
                        0,
                        65536});

            waveToSet.Size = new Size(65, 24);
            waveToSet.Value = new decimal(new int[] {
                        9000,
                        0,
                        0,
                        65536});
            waveToSet.Enabled = true;
            waveToSet.ValueChanged += new EventHandler(waveLengthsRight_ValueChanged);

            }
        private void SetLabelP(System.Windows.Forms.Label labelP)
            {
            labelP.AutoSize = true;
            labelP.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            labelP.Margin = new Padding(2, 0, 2, 0);
            labelP.Size = new Size(107, 18);

            }

        private void SetThres(NumericUpDown thresToSet)
            {

            thresToSet.DecimalPlaces = 1;
            thresToSet.Enabled = true;
            thresToSet.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            thresToSet.Location = new Point(103, 109);
            thresToSet.Margin = new Padding(2);
            thresToSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});

            thresToSet.Size = new Size(65, 24);

            thresToSet.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            thresToSet.ValueChanged += new EventHandler(this.thresh_ValueChanged);

            }

        private void SetCheckBox(CheckBox check)
            {

            check.Margin = new Padding(2);
            check.Size = new Size(78, 32);
            check.UseVisualStyleBackColor = true;
            check.CheckedChanged += new EventHandler(check_CheckedChanged);

            }

        private void check_CheckedChanged(object sender, EventArgs e)
            {

            }
        private void okBoxButton_Click(object sender, EventArgs e)
            {
            formBox.Close();
            }

        //Remove last peak from the table 
        private void removePeakButton_Click(object sender, EventArgs e)
            {
            if (peaks.Count <= 0)
                {
                return;
                }
            peaksTable.Controls.Remove(wLeft[wLeft.Count - 1]);
            peaksTable.Controls.Remove(wRight[wRight.Count - 1]);
            peaksTable.Controls.Remove(threshList[threshList.Count - 1]);
            peaksTable.Controls.Remove(labelPList[labelPList.Count - 1]);
            peaksTable.Controls.Remove(peaksCheck[peaksCheck.Count - 1]);
            peaksTable.Controls.Remove(labelCOG[labelCOG.Count - 1]);
            peaksTable.RowCount--;
            Debug.WriteLine($" ########## {peaks.Count}");
            peaks.Remove(peaks[peaks.Count - 1]);
            Debug.WriteLine($" ########## {peaks.Count}");
            wLeft.Remove(wLeft[wLeft.Count - 1]);
            wRight.Remove(wRight[wRight.Count - 1]);
            threshList.Remove(threshList[threshList.Count - 1]);
            labelCOG.Remove(labelCOG[labelCOG.Count - 1]);
            labelPList.Remove(labelPList[labelPList.Count - 1]);
            peaksCheck.Remove(peaksCheck[peaksCheck.Count - 1]);
           
            zed.GraphPane.CurveList.Remove(curves[curves.Count - 1]);
            listRollingPoint.Remove(listRollingPoint[listRollingPoint.Count-1]);
            list.Remove(list[list.Count-1]);

            curves.Remove(curves[curves.Count - 1]);

            }
        //Check box to select or deselect all the paks in the table at the same time 
        private void selectAllBox_CheckedChanged(object sender, EventArgs e)
            {
            if (selectAllBox.Checked)
                {
                selectAllBox.Text = "Deselect All Peaks";
                foreach (CheckBox item in peaksCheck)
                    {
                    if (!item.Checked)
                        {
                        item.Checked = true;
                        }
                    }
                }
            else
                {
                selectAllBox.Text = "Select All Peaks";
                foreach (CheckBox item in peaksCheck)
                    {
                    if (item.Checked)
                        {
                        item.Checked = false;
                        }
                    }
                }
            }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
            Debug.WriteLine("AM I HERE 1???????????");
            //string s = serialPort1.ReadExisting();//reads the serialport buffer
          //  if (s == "1")
            //    {
             //   serialPort1.Write("2");
              //  }
             //   if (s == "2")
             //       {
             //       serialPort1.Write("1");
              //      }
         
            }

        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {

            Debug.WriteLine("AM I HERE???????????");
            Debug.WriteLine(serialPort2.ReadExisting());
            
                    }
                

        

          }
        }
    






