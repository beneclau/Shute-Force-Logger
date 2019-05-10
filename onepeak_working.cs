/*
 * SIMPLE SPECTROMETER
 * 
 * A simple program to take a spectrum with a Qwave, Qmini or Qstick spectrometer
 * 
 * demonstrating how to use the RGBDriverKit library in order to
 * use the spectrometer from your own software.
 * 
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
using System.Windows.Forms;
using RgbDriverKit;          //The Library file RgbDriverKit.dll must be added to your project as a reference.
using System.Diagnostics;
using System.Threading;
//using SHUTEmjoelner;
using ZedGraph;
using SHUTE_Logger;

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

        COG peak1 = new COG();
        PeakTrace peakTrace1 = new PeakTrace();

        public static double[] givenCoefficients = new double[4] { -2.153177E-10, -4.191266E-06, 0.1563009, 724.0815 };
        public static float[] givenWaveLeft = new float[5] { 852.14f, 856.04f, 854.01f, 844.02f, 849.10f };
        public static float[] givenWaveRight = new float[5] { 854.85f, 858.92f, 855.87f, 848.93f, 851.97f };
        public static float givenThershold = 40.0f;


        public static System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();


        SaveFileDialog sfd = new SaveFileDialog();

        StreamWriter writingFileTest2;

        public static float a = -49.655f;
        public static float b = -0.51391f;
        public static float c = 858.4071f;

        static int numberofpeaks = 5;
        float[] peaksValues = new float[numberofpeaks];
        COG[] peaks = new COG[numberofpeaks];
        PeakTrace[] traces = new PeakTrace[numberofpeaks];



        BackgroundWorker workerThread = null;

        bool _keepRunning = false;

        int TickStart = 1;
        int intMode = 1;


        public MainForm()
            {
            InitializeComponent();
            InstantiateWorkerThread();
            }


        private void InstantiateWorkerThread()
            {
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
            if (spectrometer != null) spectrometer.Close();

            //This static method searches for devices and returns a list of driver for the available devices.
            Spectrometer[] devices = Qseries.SearchDevices();
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

            //Otherwise, take the first device and initialize it.
            spectrometer = devices[0];
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

                //      (spectrometer as CalibratedSpectrometer).UseExternalTrigger = true;


                peak1.SetWaveCof(spectrometer.WavelengthCoefficients);
                peak1.SetWaveLeft((float)numericUpDown1.Value);
                peak1.SetWaveRight((float)numericUpDown2.Value);
                peak1.SetThresholde((float)numericUpDowntr1.Value * (float)0.01);


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
                    System.Threading.Thread.Sleep(50);
                    //Taking a spectrum could be aborted with: spectrometer.CancelExposure()
                    }

                IntensitiesDrawing();

                labelPeak1.Text = "Peak [nm]: " + peak1.GetCOGinWaveLength();
                label7.Text = $"Peak [nm]: {peak1.GetCOGinWaveLength()}";
                label8.Text = $"Temp [°C]: {GetTemperature(a, b, c, peak1)}";
                }

            catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "Cannot take spectrum",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        private void IntensitiesDrawing()
            {
            intensitiesSpectrum = spectrometer.GetSpectrum();

            int length = 100;
            Debug.WriteLine("New sampling");


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
            DrawDiagram(intensitiesListSpectrum);

            }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
            if (spectrometer != null)
                {
                spectrometer.Close();
                }
            if (writingFileTest2 != null)
                {
                writingFileTest2.Close();
                }
            }

        private void DrawDiagram(List<float> values)
            {

            using (Graphics gr = pictureBox1.CreateGraphics())
                {

                gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);

                float min = float.MaxValue;
                float max = float.MinValue;
                for (int i = 0; i < values.Count; i++)
                    {
                    if (values[i] < min) min = values[i];
                    if (values[i] > max) max = values[i];
                    }

                Point[] points = new Point[500];
                /*for (int i = 0; i < values.Count; i++)
                      {
                      points[i].X = i * (pictureBox1.Width - 1) / values.Count;
                      points[i].Y = (pictureBox1.Height - 1) - (int)((values[i] - min) / (max - min) * (pictureBox1.Height - 1));
                      }
                  gr.DrawLines(Pens.Maroon, points);
                  */
                for (int i = 0; i < 500; i++)
                    {
                    points[i].X = i * (pictureBox1.Width - 1) / 500;
                    points[i].Y = (pictureBox1.Height - 1) - (int)((values[i + 1000] - min) / (max - min) * (pictureBox1.Height - 1));
                    }
                gr.DrawLines(Pens.Maroon, points);

                float peakFloat = peak1.GetCOG(values);
                peakTrace1.AddPeak(peak1.GetCOGinWaveLength(), 1.123);





                Console.WriteLine("Peak: {0}", peakFloat);
                Console.WriteLine("PeakTrace: {0}", peakTrace1.GetPeak(peakTrace1.GetLength() - 1));

                int peakInt = (int)(peakFloat * ((float)pictureBox1.Width - 1f) / (float)500);
                int WaveAInt = (int)((float)peak1.GetPixelLeft() * ((float)pictureBox1.Width - 1f) / (float)values.Count);
                int WaveBInt = (int)((float)peak1.GetPixelRight() * ((float)pictureBox1.Width - 1f) / (float)values.Count);
                int thresholdeInt = (pictureBox1.Height - 1) - (int)((peak1.GetPeakThresholde() - min) / (max - min) * (float)(pictureBox1.Height - 1));
                gr.DrawLine(Pens.Blue, peakInt, 0f, peakInt, pictureBox1.Height);
                gr.DrawLine(Pens.Green, WaveAInt, 0f, WaveAInt, pictureBox1.Height);
                gr.DrawLine(Pens.Yellow, WaveBInt, 0f, WaveBInt, pictureBox1.Height);
                gr.DrawLine(Pens.Violet, 0, thresholdeInt, pictureBox1.Width, thresholdeInt);

                gr.DrawRectangle(Pens.Black, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);


                }





            }





        private void DrawRollerDiagram(List<float> values)
            {
            using (Graphics gr = pictureBox2.CreateGraphics())
                {
                gr.FillRectangle(Brushes.White, 0, 0, pictureBox2.Width, pictureBox2.Height);

                float peakFloat = peak1.GetCOG(values);
                Console.WriteLine("Peak: {0}", peakFloat);

                float min = float.MaxValue;
                float max = float.MinValue;
                for (int i = 0; i < values.Count; i++)
                    {
                    if (values[i] < min) min = values[i];
                    if (values[i] > max) max = values[i];
                    }

                Point[] points = new Point[values.Count];
                for (int i = 0; i < 500; i++)
                    {
                    points[i].X = i * (pictureBox2.Width - 1) / 500;
                    points[i].Y = (pictureBox2.Height - 1) - (int)((peakFloat - min) / (max - min) * (pictureBox2.Height - 1));
                    //points[i].Y = (pictureBox2.Height - 1) - (int)((peakFloat) / 900 * (pictureBox2.Height - 1));
                    }

                /* Point[] points = new Point[values.Count];
                 for (int i = 0; i < values.Count; i++)
                     {
                     points[i].X = i * (pictureBox2.Width - 1) / values.Count;
                     points[i].Y = (pictureBox2.Height - 1) - (int)((peakFloat - min) / (max - min) * (pictureBox2.Height - 1));
                     //points[i].Y = (pictureBox2.Height - 1) - (int)((peakFloat) / 900 * (pictureBox2.Height - 1));
                     }
                     */
                /* float peakFloat = peaks[0].GetCOG(values);
                 Console.WriteLine("Peak: {0}", peakFloat);
                 int peakInt = (int)(peakFloat * ((float)pictureBox2.Width - 1f) / (float)values.Length);
                 int WaveAInt = (int)((float)peaks[0].GetPixelLeft() * ((float)pictureBox2.Width - 1f) / (float)values.Length);
                 int WaveBInt = (int)((float)peaks[0].GetPixelRight() * ((float)pictureBox2.Width - 1f) / (float)values.Length);
                 int thresholdeInt = (pictureBox2.Height - 1) - (int)((peaks[0].GetPeakThresholde() - min) / (max - min) * (float)(pictureBox2.Height - 1));
                 gr.DrawLine(Pens.Blue, peakInt, 0f, peakInt, pictureBox2.Height);
                 gr.DrawLine(Pens.Green, WaveAInt, 0f, WaveAInt, pictureBox2.Height);
                 gr.DrawLine(Pens.Yellow, WaveBInt, 0f, WaveBInt, pictureBox2.Height);
                 gr.DrawLine(Pens.Violet, 0, thresholdeInt, pictureBox2.Width, thresholdeInt);
                 */

                //float[] peakFloat = new float[numberofpeaks];



                int peakInt = (int)(peakFloat * ((float)pictureBox2.Width - 1f) / (float)values.Count);
                gr.DrawLine(Pens.Blue, peakInt, 0f, peakInt, pictureBox2.Height);



                gr.DrawRectangle(Pens.Black, 0, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
                }

            //   labelPeak.Text = "Peak [nm]: " + peak1.GetCOGinWaveLength();
            }

        private void numericUpDowntr1_ValueChanged(object sender, EventArgs e)
            {

            peaks[0].SetThresholde((float)numericUpDowntr1.Value * (float)0.01);

            }
        private void numericUpDowntr2_ValueChanged(object sender, EventArgs e)
            {

            peaks[1].SetThresholde((float)numericUpDowntr2.Value * (float)0.01);

            }
        private void numericUpDowntr3_ValueChanged(object sender, EventArgs e)
            {

            peaks[2].SetThresholde((float)numericUpDowntr3.Value * (float)0.01);

            }
        private void numericUpDowntr4_ValueChanged(object sender, EventArgs e)
            {

            peaks[3].SetThresholde((float)numericUpDowntr4.Value * (float)0.01);

            }
        private void numericUpDowntr5_ValueChanged(object sender, EventArgs e)
            {

            peaks[4].SetThresholde((float)numericUpDowntr5.Value * (float)0.01);

            }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
            peaks[0].SetWaveLeft((float)numericUpDown1.Value);
            }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
            {
            peaks[0].SetWaveRight((float)numericUpDown2.Value);
            }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
            {
            peaks[1].SetWaveLeft((float)numericUpDown3.Value);
            }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
            {
            peaks[1].SetWaveRight((float)numericUpDown4.Value);
            }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
            {
            peaks[2].SetWaveLeft((float)numericUpDown5.Value);
            }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
            {
            peaks[2].SetWaveRight((float)numericUpDown6.Value);
            }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
            {
            peaks[3].SetWaveLeft((float)numericUpDown7.Value);
            }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
            {
            peaks[3].SetWaveRight((float)numericUpDown8.Value);

            }
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
            {
            peaks[4].SetWaveLeft((float)numericUpDown9.Value);
            }
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
            {
            peaks[4].SetWaveRight((float)numericUpDown10.Value);
            }


        private void InitSpectrometer()
            {

            //Close any previously used spectrometer (in case user clicks on the button more than once)
            if (spectrometer != null) spectrometer.Close();

            //This static method searches for devices and returns a list of driver for the available devices.
            Spectrometer[] devices = Qseries.SearchDevices();
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

            //Otherwise, take the first device and initialize it.
            spectrometer = devices[0];
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
                    //checkBoxEksternTrigger.Checked = (spectrometer as CalibratedSpectrometer).UseExternalTrigger;
                    }
                else
                    {
                    SensitivityCalibrationCheckBox.Checked = false;
                    SensitivityCalibrationCheckBox.Enabled = false;
                    }

                //      (spectrometer as CalibratedSpectrometer).UseExternalTrigger = true;


                peak1.SetWaveCof(spectrometer.WavelengthCoefficients);
                peak1.SetWaveLeft((float)numericUpDown1.Value);
                peak1.SetWaveRight((float)numericUpDown2.Value);
                peak1.SetThresholde((float)numericUpDowntr1.Value * (float)0.01);

                /*
                   InitStatusLabel.Text = "Found " + spectrometer.DetailedDeviceName;
                   MessageBox.Show("Device name: " + spectrometer.ModelName + Environment.NewLine
                       + "Manufacturer: " + spectrometer.Manufacturer + Environment.NewLine
                       + "Serial number: " + spectrometer.SerialNo + Environment.NewLine
                       + "Number of pixels: " + spectrometer.PixelCount,
                       "Spectrometer found and initialized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                */
                }
            catch (Exception ex)
                {
                spectrometer = null;
                InitStatusLabel.Text = "Initialization error.";
                MessageBox.Show(ex.Message, "Cannot initialize spectrometer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


        //----------Thred

        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
            lblStopWatch.Text = e.UserState.ToString();
            labelPeak1.Text = "Peak [nm]: " + peak1.GetCOGinWaveLength();
            label7.Text = $"Peak [nm]: {peak1.GetCOGinWaveLength()}";
            label8.Text = $"Temp [°C]: {GetTemperature(a, b, c, peak1)}";

            }

        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
            if (e.Cancelled)
                {
                lblStopWatch.Text = "Cancelled";
                }
            else
                {
                lblStopWatch.Text = "Stopped";
                }
            }

        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
            {
            // DateTime startTime = DateTime.Now;

            //  float peakResult = peak1.GetCOGinWaveLength();


            _keepRunning = true;

            while (_keepRunning)
                {
                /*
                Thread.Sleep(1000);
                string timeElapsedInstring = "00";// (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
                workerThread.ReportProgress(0, timeElapsedInstring);
                */
                workerThread.ReportProgress(0, peak1.GetCOGinWaveLength());




                if (spectrometer == null) return;
                try
                    {
                    spectrometer.StartExposure();

                    while (spectrometer.Status > SpectrometerStatus.Idle) //this could be SpectrometerStatus.TakingSpectrum or SpectrometerStatus.WaitingForTrigger
                        {
                        //System.Threading.Thread.Sleep(50);
                        //Taking a spectrum could be aborted with: spectrometer.CancelExposure()
                        }

                    IntensitiesDrawing();

                    }
                catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message, "Cannot take spectrum",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                if (workerThread.CancellationPending)
                    {
                    // this is important as it set the cancelled property of RunWorkerCompletedEventArgs to true
                    e.Cancel = true;
                    break;
                    }
                }
            }
            }

        private void button1_Click(object sender, EventArgs e)
            {

            if (button1.Text == "RUN")
                {
                button1.Text = "STOP";
                button1.BackColor = Color.Red;

                if (spectrometer == null)
                    {
                    MessageBox.Show($"Please initialize a spectrometer");
                    button1.Text = "RUN";
                    button1.BackColor = Color.Green;
                    }
                else
                    {

                    DialogResult savingQuestion = MessageBox.Show("Do you want to save the reuslts?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (savingQuestion == DialogResult.Yes)
                        {
                        sfd.Filter = "Text |*.txt";
                        sfd.Title = "Save a Text File";
                        if (sfd.ShowDialog() == DialogResult.Cancel)
                            {
                            button1.Text = "RUN";
                            button1.BackColor = Color.Green;
                            }
                        else
                            {
                            decimal inputInterval;

                            string inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                            if (Decimal.TryParse(inputStringInterval, out inputInterval))
                                {

                                time.Interval = (int)inputInterval * 1000;
                                time.Tick += new EventHandler(time_Tick);
                                //time.Enabled = true;
                                time.Stop();
                                time.Start();

                                writingFileTest2 = new StreamWriter(sfd.FileName);
                                writingFileTest2.AutoFlush = true;
                                workerThread.RunWorkerAsync();

                                }


                            }
                        }
                    else
                        {
                        workerThread.RunWorkerAsync();

                        }

                    }
                }
            else
                {
                button1.Text = "RUN";
                button1.BackColor = Color.Green;

                time.Stop();
                if (writingFileTest2 != null)
                    {
                    writingFileTest2.Close();
                    }
                workerThread.CancelAsync();

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

        private void MainForm_Load(object sender, EventArgs e)
            {
            InitSpectrometer();
            // Debug.WriteLine($"DEBUG ZEDGRAPH ---------------- {zed.GraphPane.CurveList.Count}");
            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "Test";
            myPane.XAxis.Title.Text = "Time(sec)";
            myPane.YAxis.Title.Text = "Intensity (max value)";
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            RollingPointPairList list = new RollingPointPairList(60000);
            RollingPointPairList list1 = new RollingPointPairList(60000);

            LineItem curve = myPane.AddCurve("Value1", list, Color.Red, SymbolType.None);
            //LineItem curve2 = myPane.AddCurve("Value2", list1, Color.Blue, SymbolType.None);

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 10;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = 800;
            myPane.YAxis.Scale.Max = 850;
            zed.AxisChange();
            TickStart = Environment.TickCount;

            //try
            //{
            // if (!serialPort1.IsOpen) serialPort1.Open();
            //}
            //catch (Exception ex)
            //{
            //}
            }

        private void Draw(float setpoint)
            {
            float intsetpoint = setpoint;
            // float intcurrent = current;

            // Debug.WriteLine($"DEBUG ZED GRAPH------------- {setpoint}, {current}");  


            if (zed.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zed.GraphPane.CurveList[0] as LineItem;
            // LineItem curve1 = zed.GraphPane.CurveList[1] as LineItem;
            if (curve == null)
                return;
            //if (curve1 == null)
            //return;

            IPointListEdit list = curve.Points as IPointListEdit;
            // IPointListEdit list1 = curve1.Points as IPointListEdit;

            if (list == null)
                return;
            // if (list1 == null)
            // return;
            double time = (Environment.TickCount - TickStart) / 1000.0;
            list.Add(time, intsetpoint);
            //  list1.Add(time, intcurrent);

            Scale xScale = zed.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
                {
                if (intMode == 1)
                    {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                    }
                else
                    {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = 0;
                    }
                }

            zed.AxisChange();
            zed.Invalidate();
            }

        private float GetTemperature(float a, float b, float c, COG peakMeasured)
            {

            float temp = a * (peakMeasured.GetCOGinWaveLength() - c) + b;

            return temp;

            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            float maxValue = peak1.GetCOGinWaveLength();
            // float threshold = peak1.GetPeakThresholde();
            Draw(maxValue);
            }


        private void ManualBox_CheckedChanged(object sender, EventArgs e)
            {
            if (ManualBox.Checked)
                {

                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = true;
                numericUpDown6.Enabled = true;
                numericUpDown7.Enabled = true;
                numericUpDown8.Enabled = true;
                numericUpDown9.Enabled = true;
                numericUpDown10.Enabled = true;
                numericUpDowntr1.Enabled = true;
                numericUpDowntr2.Enabled = true;
                numericUpDowntr3.Enabled = true;
                numericUpDowntr4.Enabled = true;
                numericUpDowntr5.Enabled = true;
                ExpTimeNumericUpDown.Enabled = true;
                }
            else
                {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = false;
                numericUpDown10.Enabled = false;
                numericUpDowntr1.Enabled = false;
                numericUpDowntr2.Enabled = false;
                numericUpDowntr3.Enabled = false;
                numericUpDowntr4.Enabled = false;
                numericUpDowntr5.Enabled = false;
                ExpTimeNumericUpDown.Enabled = false;
                }
            }



        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
            {


            }


        private void time_Tick(object sender, EventArgs e)
            {

            DateTime CurrentDate;

            CurrentDate = DateTime.Now; //.ToString("yyyyMMddHHmmssFFF");
            writingFileTest2.WriteLine($" Time: {CurrentDate}; PeakTrace:{peakTrace1.GetPeak(peakTrace1.GetLength() - 1)}; Temp: {GetTemperature(a, b, c, peak1)}");
            writingFileTest2.WriteLine($"Spectrum: {string.Join("; ", intensitiesSpectrum)}");

            }


        }
    



/*labelPeak1.Text = $"Peak [nm]: {peaks[0].GetCOGinWaveLength()}";
labelPeak2.Text = $"Peak [nm]: {peaks[1].GetCOGinWaveLength()}";
            labelPeak3.Text = $"Peak [nm]: {peaks[2].GetCOGinWaveLength()}";
            labelPeak4.Text = $"Peak [nm]: {peaks[3].GetCOGinWaveLength()}";
            labelPeak5.Text = $"Peak [nm]: {peaks[4].GetCOGinWaveLength()}";
            label7.Text = $"Peak [nm]: {peaks[0].GetCOGinWaveLength()}";
            label10.Text = $"Peak [nm]: {peaks[1].GetCOGinWaveLength()}";
            label13.Text = $"Peak [nm]: {peaks[2].GetCOGinWaveLength()}";
            label16.Text = $"Peak [nm]: {peaks[3].GetCOGinWaveLength()}";
            label19.Text = $"Peak [nm]: {peaks[4].GetCOGinWaveLength()}";
            label8.Text = $"Temperature [°C]: {peaksValues[0]}";
            label11.Text = $"Temperature [°C]: {peaksValues[1]}";
            label14.Text = $"Temperature [°C]: {peaksValues[2]}";
            label17.Text = $"Temperature [°C]: {peaksValues[3]}";
            label20.Text = $"Temperature [°C]: {peaksValues[3]}";
            */


/*
 *        labelPeak1.Text = "Peak [nm]: " + peaks[0].GetCOGinWaveLength();
            labelPeak2.Text = "Peak [nm]: " + peaks[1].GetCOGinWaveLength();
            labelPeak3.Text = "Peak [nm]: " + peaks[2].GetCOGinWaveLength();
            labelPeak4.Text = "Peak [nm]: " + peaks[3].GetCOGinWaveLength();  //this is here for debug but shouldnt
            labelPeak5.Text = "Peak [nm]: " + peaks[4].GetCOGinWaveLength();
*/


/*DrawDiagram with Windows Form graphic class
         * 
         * 
         * using (Graphics gr = pictureBox1.CreateGraphics())
            {
            gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            float min = float.MaxValue;
            float max = float.MinValue;
            for (int i = 0; i < values.Count; i++)
                {
                if (values[i] < min) min = values[i];
                if (values[i] > max) max = values[i];
                }
            Point[] points = new Point[values.Count];
            for (int i = 0; i < values.Count; i++)
                {
                points[i].X = i * (pictureBox1.Width - 1) / values.Count;
                points[i].Y = (pictureBox1.Height - 1) - (int)((values[i] - min) / (max - min) * (pictureBox1.Height - 1));
                }
            gr.DrawLines(Pens.Maroon, points);
            float peakFloat = peak1.GetCOG(values);
            peakTrace1.AddPeak(peak1.GetCOGinWaveLength(), 1.123);
            Console.WriteLine("Peak: {0}", peakFloat);
            Console.WriteLine("PeakTrace: {0}", peakTrace1.GetPeak(peakTrace1.GetLength() - 1));
            int peakInt = (int)(peakFloat * ((float)pictureBox1.Width - 1f) / (float)values.Count);
            int WaveAInt = (int)((float)peak1.GetPixelLeft() * ((float)pictureBox1.Width - 1f) / (float)values.Count);
            int WaveBInt = (int)((float)peak1.GetPixelRight() * ((float)pictureBox1.Width - 1f) / (float)values.Count);
            int thresholdeInt = (pictureBox1.Height - 1) - (int)((peak1.GetPeakThresholde() - min) / (max - min) * (float)(pictureBox1.Height - 1));
            gr.DrawLine(Pens.Blue, peakInt, 0f, peakInt, pictureBox1.Height);
            gr.DrawLine(Pens.Green, WaveAInt, 0f, WaveAInt, pictureBox1.Height);
            gr.DrawLine(Pens.Yellow, WaveBInt, 0f, WaveBInt, pictureBox1.Height);
            gr.DrawLine(Pens.Violet, 0, thresholdeInt, pictureBox1.Width, thresholdeInt);
            gr.DrawRectangle(Pens.Black, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            //Console.WriteLine("PeakTrace: {0}", traces[0].GetPeak(traces[0].GetLength() - 1));
            */
