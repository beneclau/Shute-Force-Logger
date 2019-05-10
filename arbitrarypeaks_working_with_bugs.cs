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
        public static COG peak1 = new COG(0, 0, 0, 0, 0);
        
        public static COG peak2 = new COG(0, 0, 0, 0, 0);
        //public PeakTrace peakTrace2 = new PeakTrace();
     


        public static System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();


        SaveFileDialog sfd = new SaveFileDialog();

        StreamWriter writingFileTest2;

        public static float a = -49.655f;
        public static float b = -0.51391f;
        public static float c = 858.4071f;

       public static string stringOfPeaks = Microsoft.VisualBasic.Interaction.InputBox("Insert the number of peaks to track", "Peaks", "2", 600, 300);
        public static int numberOfPeaks = Int32.Parse(stringOfPeaks);
        float[] peaksValues = new float[numberOfPeaks];
      // COG[] peaks = new COG[numberOfPeaks];
       // PeakTrace[] traces = new PeakTrace[numberOfPeaks];
        //NumericUpDown[] waveLengths = new NumericUpDown[numberOfPeaks*2];
        
        public static List<COG> peaks = new List<COG>();
        public static List<PeakTrace> traces =new List<PeakTrace>();
        public static List<NumericUpDown> wLeft = new List<NumericUpDown>();
        public static List<NumericUpDown> wRight = new List<NumericUpDown>();
        public static List<NumericUpDown> threshList = new List<NumericUpDown>();
        public static List<System.Windows.Forms.Label> labelPList = new List<System.Windows.Forms.Label>();
        public static List<System.Windows.Forms.Label> labelCOG = new List<System.Windows.Forms.Label>();

        public static List<PeakTrace> peakTrace1 = new List<PeakTrace>();
        public static List<int> peakInt = new List<int>();
        public static List<int> waveLInt = new List<int>();
        public static List<int> waveRInt = new List<int>();
        public static List<int> thresInt = new List<int>();

        BackgroundWorker workerThread = null;

        bool _keepRunning = false;

        int TickStart = 1;
        int intMode = 1;


        public MainForm()
            {
            while (!stringOfPeaks.All(char.IsDigit) || Int32.Parse(stringOfPeaks) >= 10)
                {
                MessageBox.Show("Please insert only numeric values <10");
                stringOfPeaks = Microsoft.VisualBasic.Interaction.InputBox("Insert the number of peaks to track", "Peaks", "2", 600, 300);

                //if you stop and run again goes into an infinte loop --- INSTABLE CODE HERE
                }
            //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 1 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
            numberOfPeaks = Int32.Parse(stringOfPeaks);
            InitializeComponent();
            InstantiateWorkerThread();

            
            }


        private void InstantiateWorkerThread()
            {
            //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 5 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
            workerThread = new BackgroundWorker();
            workerThread.ProgressChanged += WorkerThread_ProgressChanged;
            workerThread.DoWork += WorkerThread_DoWork;
            workerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
            workerThread.WorkerReportsProgress = true;
            workerThread.WorkerSupportsCancellation = true;
            //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 6 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
            
            }

        // ********** Initialize the spectrometer **********

        private void InitializeButton_Click(object sender, EventArgs e)
            {
           // Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 7 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
            //Close any previously used spectrometer (in case user clicks on the button more than once)
            if (spectrometer != null) spectrometer.Close();
           // Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 8 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
            //This static method searches for devices and returns a list of driver for the available devices.
            Spectrometer[] devices = Qseries.SearchDevices();
            if (devices.Length == 0) devices = RgbSpectrometer.SearchDevices();
            if (devices.Length == 0) devices = Qstick.SearchDevices();
            //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 9 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
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
            //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 10 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
            try
                {
                InitStatusLabel.Text = "Initializing spectrometer ...";
                statusStrip1.Update();

                spectrometer.Open();
               //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 11 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
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
                peaksTable.RowCount= numberOfPeaks;
                // Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 12 ¤¤¤¤¤¤¤¤¤¤¤¤¤");

                for (int i=0; i <numberOfPeaks; i++) {
                    peaks.Add(new COG(0,0,0,0,0));
                    peaksTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
                    }
                //      (spectrometer as CalibratedSpectrometer).UseExternalTrigger = true;
               
         
                for (int i = 0; i < numberOfPeaks; i++)
                    {
                        
                        //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 13 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
                        wLeft.Add(new NumericUpDown());
                        wRight.Add(new NumericUpDown());
                        threshList.Add(new NumericUpDown());
                        labelPList.Add(new System.Windows.Forms.Label());
                        labelCOG.Add(new System.Windows.Forms.Label());
                        

                        SetWaves(wLeft[i]);
                        wLeft[i].Name = $"waveLengthLeft {(i + 1).ToString()}";
                        peaksTable.Controls.Add(wLeft[i], 2, i );

                        SetWaves(wRight[i]);
                        wRight[i].Name = $"waveLengthRight {(i + 1).ToString()}";
                        peaksTable.Controls.Add(wRight[i], 3, i);

                        SetThres(threshList[i]);
                        threshList[i].Name = $"threshold {(i + 1).ToString()}";
                        peaksTable.Controls.Add(threshList[i], 4, i);

                        SetLabelP(labelPList[i]);
                        labelPList[i].Text = $"Peak {(i+1).ToString()}";
                        peaksTable.Controls.Add(labelPList[i], 1, i);

                       





                    //PeakTrackBox.Controls.Add(waveLengths[i]);
                    }

                


                for(int i= 0; i<peaks.Count; i++)
                    {
                    InitPeak(peaks[i], spectrometer.WavelengthCoefficients,wLeft[i], wRight[i], threshList[i]);
                    Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 16 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
                    }
                // Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 15 ¤¤¤¤¤¤¤¤¤¤¤¤¤");
                //peak1.SetWaveCof(spectrometer.WavelengthCoefficients);
                //peak1.SetWaveLeft((float)numericUpDown1.Value);
                // peak1.SetWaveRight((float)numericUpDown2.Value);
                //peak1.SetThresholde((float)numericUpDowntr1.Value * (float)0.01);
                //peak1.waveLeft = (float)numericUpDown1.Value;
                //peak1.waveRight = (float)numericUpDown2.Value;
                //peak1.waveLeft = (float)waveLengths[0].Value;
                //peak1.waveRight = (float)waveLengths[1].Value;
                //peak1.thresholde = (float)numericUpDowntr1.Value * (float)0.01;
                // peak2.SetWaveCof(spectrometer.WavelengthCoefficients);   //the overwriting happens here.
                //peak2.SetWaveLeft((float)numericUpDown3.Value);
                // peak2.SetWaveRight((float)numericUpDown4.Value);
                //peak2.SetThresholde((float)numericUpDowntr2.Value * (float)0.01);
                // peak2.waveLeft = (float)waveLengths[2].Value;
                // peak2.waveRight = (float)waveLengths[3].Value;
                // peak2.thresholde = (float)numericUpDowntr2.Value * (float)0.01;
                Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤ DEBUG 17 ¤¤¤¤¤¤¤¤¤¤¤¤¤");

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


                /*labelPeak1.Text = "Peak [nm]: " + peak1.COGinWaveLength;
                label7.Text = $"Peak [nm]: {peak1.COGinWaveLength}";
                label8.Text = $"Temp [°C]: {GetTemperature(a, b, c, peak1)}";

                 labelPeak2.Text = "Peak [nm]: " + peak2.COGinWaveLength;
                 label10.Text = $"Peak [nm]: {peak2.COGinWaveLength}";
                // label11.Text = $"Temp [°C]: {GetTemperature(a, b, c, peak2)}";
                */

               /* for (int i = 0; i < peaks.Count; i++)
                    {
                    labelCOG.Add(new System.Windows.Forms.Label());
                    SetLabelP(labelCOG[i]);
                    labelCOG[i].Text = $"{(peaks[i].COGinWaveLength)}";
                    peaksTable.Controls.Add(labelCOG[i], 5, i);
                    }
                    */
                // LabelPlacering(peaks[0], labelPeak1, label7, label8);
                // LabelPlacering(peaks[1], labelPeak2, label10, label11);   TO DO 

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

        private void DrawDiagram(float [] values)
            {

            using (Graphics gr = pictureBox1.CreateGraphics())
                {

                gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
               
                float min = float.MaxValue;
                float max = float.MinValue;
                for (int i = 0; i < values.Length; i++)
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
                             
                // peaks[0].COGresult = peaks[0].GetCOG(values);
                //peakTrace1.AddPeak(peaks[0].COGinWaveLength, 1.123);
                //peaks[1].COGresult = peaks[1].GetCOG(values);
                //peakTrace2.AddPeak(peaks[1].COGinWaveLength, 1.123);
                //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                
                for( int i= 0; i<peaks.Count; i++)
                    {
                    peakInt.Add(new int());
                    waveLInt.Add(new int());
                    waveRInt.Add(new int());
                    thresInt.Add(new int());
                    peakTrace1.Add(new PeakTrace());
                   // Debug.WriteLine($"¤¤¤¤¤¤¤ NUMBER OF PEAKS IN PEAKTRACE 1 {peakTrace1.Count}");
                    peaks[i].COGresult = peaks[i].GetCOG(values);
                    peakTrace1[i].AddPeak(peaks[i].COGinWaveLength, 1.123);

                    peakInt[i] = (int)(peaks[i].COGresult * (pictureBox1.Width - 1f) / values.Length-43);
                    waveLInt[i] = (int)(peaks[i].GetPixelLeft() * (pictureBox1.Width - 1f) / values.Length - 50);
                    waveRInt[i] = (int)(peaks[0].GetPixelRight() * (pictureBox1.Width - 1f) / values.Length - 30);
                    thresInt[i] = (pictureBox1.Height - 1) - (int)((peaks[i].GetPeakThresholde() - min) / (max - min) * (pictureBox1.Height - 1));

                    gr.DrawLine(Pens.Red, peakInt[i], 0f, peakInt[i], pictureBox1.Height);
                    gr.DrawLine(Pens.Green, waveLInt[i], 0f, waveLInt[i], pictureBox1.Height);
                    gr.DrawLine(Pens.Blue, waveRInt[i], 0f, waveRInt[i], pictureBox1.Height);
                    gr.DrawLine(Pens.Violet, 0, thresInt[i], pictureBox1.Width, thresInt[i]);

                    }

                //int peakInt1 = (int)(peaks[0].COGresult * (pictureBox1.Width - 1f) / values.Length-43);
                //int WaveAInt = (int)(peaks[0].GetPixelLeft() * (pictureBox1.Width - 1f) / values.Length-50);
                // int WaveBInt = (int)(peaks[0].GetPixelRight() * (pictureBox1.Width - 1f) /values.Length-30);
                //int thresholdeInt = (pictureBox1.Height - 1) - (int)((peaks[0].GetPeakThresholde() - min) / (max - min) *(pictureBox1.Height - 1));
               
                /* gr.DrawLine(Pens.Blue, peakInt1, 0f, peakInt1, pictureBox1.Height);
                gr.DrawLine(Pens.Green, WaveAInt, 0f, WaveAInt, pictureBox1.Height);
                gr.DrawLine(Pens.Yellow, WaveBInt, 0f, WaveBInt, pictureBox1.Height);
                gr.DrawLine(Pens.Violet, 0, thresholdeInt, pictureBox1.Width, thresholdeInt);

                */

                /*int peakInt2 = (int)(peaks[1].COGresult * ((float)pictureBox1.Width - 1f) / (float)values.Length-25);
                int WaveAInt2 = (int)((float)peaks[1].GetPixelLeft() * ((float)pictureBox1.Width - 1f) / (float)values.Length-30);
                int WaveBInt2 = (int)((float)peaks[1].GetPixelRight() * ((float)pictureBox1.Width - 1f) / (float)values.Length-20);
                int thresholdeInt2 = (pictureBox1.Height - 1) - (int)((peaks[1].GetPeakThresholde() - min) / (max - min) * (float)(pictureBox1.Height - 1));
                gr.DrawLine(Pens.Aqua, peakInt2, 0f, peakInt2, pictureBox1.Height);
                gr.DrawLine(Pens.DarkGreen, WaveAInt2, 0f, WaveAInt2, pictureBox1.Height);
                gr.DrawLine(Pens.DarkOrange, WaveBInt2, 0f, WaveBInt2, pictureBox1.Height);
                gr.DrawLine(Pens.Magenta, 0, thresholdeInt2, pictureBox1.Width, thresholdeInt2);
                */

                //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                gr.DrawRectangle(Pens.Black, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);


              
                }

            }



        private void DrawRollerDiagram(float [] values)
            {
            using (Graphics gr = pictureBox2.CreateGraphics())
                {
                gr.FillRectangle(Brushes.White, 0, 0, pictureBox2.Width, pictureBox2.Height);

                float peakFloat = peak1.GetCOG(values);
                Console.WriteLine("Peak: {0}", peakFloat);

                float min = float.MaxValue;
                float max = float.MinValue;
                for (int i = 0; i < values.Length; i++)
                    {
                    if (values[i] < min) min = values[i];
                    if (values[i] > max) max = values[i];
                    }

                Point[] points = new Point[values.Length];
                for (int i = 0; i < 500; i++)
                    {
                    points[i].X = i * (pictureBox2.Width - 1) / 500;
                    points[i].Y = (pictureBox2.Height - 1) - (int)((peakFloat - min) / (max - min) * (pictureBox2.Height - 1));
                    //points[i].Y = (pictureBox2.Height - 1) - (int)((peakFloat) / 900 * (pictureBox2.Height - 1));
                    }



                int peakInt = (int)(peakFloat * ((float)pictureBox2.Width - 1f) / (float)values.Length);
                gr.DrawLine(Pens.Blue, peakInt, 0f, peakInt, pictureBox2.Height);



                gr.DrawRectangle(Pens.Black, 0, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
                }

            //   labelPeak.Text = "Peak [nm]: " + peak1.COGinWaveLength;
            }

        private void numericUpDowntr1_ValueChanged(object sender, EventArgs e)
            {

           // peak1.thresholde = (float)numericUpDowntr1.Value*(float)0.01;

            }
        private void numericUpDowntr2_ValueChanged(object sender, EventArgs e)
            {

           // peak2.thresholde = (float)numericUpDowntr2.Value * (float)0.01;

            }
        private void numericUpDowntr3_ValueChanged(object sender, EventArgs e)
            {

            //peaks[2].SetThresholde((float)numericUpDowntr3.Value * (float)0.01);

            }
        private void numericUpDowntr4_ValueChanged(object sender, EventArgs e)
            {

            // peaks[3].SetThresholde((float)numericUpDowntr4.Value * (float)0.01);

            }
        private void numericUpDowntr5_ValueChanged(object sender, EventArgs e)
            {

            //peaks[4].SetThresholde((float)numericUpDowntr5.Value * (float)0.01);

            }


        private void waveLengths_ValueChanged(object sender, EventArgs e)
            {
            // peak1.SetWaveLeft((float)numericUpDown1.Value);
            peaks[0].waveLeft = (float)wLeft[0].Value;
            peaks[0].waveRight = (float)wRight[0].Value;
            peaks[1].waveLeft = (float)wLeft[1].Value;
            peaks[1].waveRight = (float)wRight[1].Value;
            }

       /* private void numericUpDown2_ValueChanged(object sender, EventArgs e)
            {
            //peak1.SetWaveRight((float)numericUpDown2.Value);
            peak1.waveRight = (float)numericUpDown2.Value;
            }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
            {
            peak2.waveLeft = (float)numericUpDown3.Value;
            }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
            {
            //peak2.SetWaveRight((float)numericUpDown4.Value);
            peak1.waveRight = (float)numericUpDown4.Value;

            }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
            {
            //peaks[2].SetWaveLeft((float)numericUpDown5.Value);
            }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
            {
            //peaks[2].SetWaveRight((float)numericUpDown6.Value);
            }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
            {
            // peaks[3].SetWaveLeft((float)numericUpDown7.Value);
            }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
            {
            //peaks[3].SetWaveRight((float)numericUpDown8.Value);

            }
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
            {
            //peaks[4].SetWaveLeft((float)numericUpDown9.Value);
            }
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
            {
            // peaks[4].SetWaveRight((float)numericUpDown10.Value);
            }

            */
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

            /*for (int i = 0; i < peaks.Count; i++)
                {
                labelCOG.Add(new System.Windows.Forms.Label());
                SetLabelP(labelCOG[i]);
                labelCOG[i].Text = $"{(peaks[i].COGinWaveLength)}";
                peaksTable.Controls.Add(labelCOG[i], 5, i);
                }
                */
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


            _keepRunning = true;

            while (_keepRunning)
                {
                /*
                Thread.Sleep(1000);
                string timeElapsedInstring = "00";// (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
                workerThread.ReportProgress(0, timeElapsedInstring);
                */
                workerThread.ReportProgress(0, peak1.COGinWaveLength);
                // workerThread.ReportProgress(0, peak2.COGinWaveLength); //non so se serve




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

        private void button1_Click(object sender, EventArgs e)
            {
            if (spectrometer == null)
                {
                MessageBox.Show($"Please initialize a spectrometer");
                button1.Text = "RUN";
                button1.BackColor = Color.Green;
                }
            
                if (button1.Text == "RUN")
                    {
                    button1.Text = "STOP";
                    button1.BackColor = Color.Red;
                    workerThread.RunWorkerAsync();
                    timer1.Enabled = true;
              
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
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "Test";
            myPane.XAxis.Title.Text = "Time(sec)";
            myPane.YAxis.Title.Text = "Intensity (max value)";
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            RollingPointPairList list = new RollingPointPairList(60000);
            RollingPointPairList list1 = new RollingPointPairList(60000);

            LineItem curve = myPane.AddCurve("Value1", list, Color.Red, SymbolType.None);
            LineItem curve2 = myPane.AddCurve("Value2", list1, Color.Blue, SymbolType.None);

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 10;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            //myPane.YAxis.Scale.Min = (double)numericUpDown1.Value-15;
            //myPane.YAxis.Scale.Max = (double)numericUpDown4.Value +10;
            myPane.YAxis.Scale.Min = 840;
            myPane.YAxis.Scale.Max = 850;
            zed.AxisChange();
            TickStart = Environment.TickCount;
            }

        private void Draw(float setpoint, float value2)
            {
            float intsetpoint = setpoint;
            float intcurrent = value2;

            if (zed.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zed.GraphPane.CurveList[0] as LineItem;
            LineItem curve1 = zed.GraphPane.CurveList[1] as LineItem;
            if (curve == null)
                return;
            if (curve1 == null)
            return;

            IPointListEdit list = curve.Points as IPointListEdit;
            IPointListEdit list1 = curve1.Points as IPointListEdit;

            if (list == null)
                return;
             if (list1 == null)
            return;
            double time = (Environment.TickCount - TickStart) / 1000.0;
            list.Add(time, intsetpoint);
            list1.Add(time, intcurrent);

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

            float temp = a * (peakMeasured.COGinWaveLength - c) + b;

            return temp;

            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            float maxValue = peaks[0].COGinWaveLength;
            float maxValue2 = peaks[1].COGinWaveLength;
            Draw(maxValue, maxValue2);
            }


        private void ManualBox_CheckedChanged(object sender, EventArgs e)
            {
            if (ManualBox.Checked)
                {

                /*numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = true;
                numericUpDown6.Enabled = true;
                numericUpDown7.Enabled = true;
                numericUpDown8.Enabled = true;
                numericUpDown9.Enabled = true;
                numericUpDown10.Enabled = true;
                */
          
                ExpTimeNumericUpDown.Enabled = true;
                }
            else
                {
                /*numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = false;
                numericUpDown10.Enabled = false;
                */
      
                ExpTimeNumericUpDown.Enabled = false;
                }
            }






        private void time_Tick(object sender, EventArgs e)
            {
            
            DateTime CurrentDate;

            CurrentDate = DateTime.Now; //.ToString("yyyyMMddHHmmssFFF");
            writingFileTest2.WriteLine($" Time: {CurrentDate}; Spectrum: {string.Join("; ", intensitiesSpectrum)}");
            for(int i =0; i<peaks.Count; i++)
                {
                //Debug.WriteLine($"¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
                writingFileTest2.WriteLine($"  PeakTrace 1:{peaks[i].GetCOGinWaveLength()}"); 
                //writingFileTest2.WriteLine($"  PeakTrace 2:{peakTrace2.GetPeak(peakTrace2.GetLength() - 1)};");
               
                }
            
            //Temp: {GetTemperature(a, b, c, peak2)}


            }

        private void LabelPlacering(COG peakToLabel, System.Windows.Forms.Label peakLabel, System.Windows.Forms.Label peakLabel2, System.Windows.Forms.Label temp)
            {
            //peakLabel.Text = $"Peak [nm]:  { peakTrace1.GetPeak(peakTrace1.GetLength() - 1)}";
            //peakLabel2.Text = $"Peak [nm]: {peakTrace2.GetPeak(peakTrace2.GetLength() - 1)}";
            temp.Text = $"Temp [°C]: {GetTemperature(a, b, c, peakToLabel)}";
            }

        private void InitPeak(COG peakToInit, double[] Wavelengths, NumericUpDown wLeft, NumericUpDown wRight, NumericUpDown thres)
            {
            peakToInit.SetWaveCof(Wavelengths);
            peakToInit.waveLeft = (float)wLeft.Value;
            peakToInit.waveRight = (float)wRight.Value;
            peakToInit.thresholde= (float)thres.Value * (float)0.01;

            }

        private void buttonAddPeak_Click(object sender, EventArgs e)
            {
           
            wLeft.Add(new NumericUpDown());
            wRight.Add(new NumericUpDown());
            threshList.Add(new NumericUpDown());
            labelPList.Add(new System.Windows.Forms.Label());
            labelCOG.Add(new System.Windows.Forms.Label());
            //Debug.WriteLine($"DEBUG PEAK NUMBERS ¤¤¤¤¤¤¤¤¤¤¤ {peaks.Count}");
            peaksTable.RowCount = peaksTable.RowCount + 1;
            peaksTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));

            SetWaves(wLeft[wLeft.Count-1]);
            wLeft[wLeft.Count-1].Name = "wavelengthLeft" + wLeft.Count.ToString();
            peaksTable.Controls.Add(wLeft[wLeft.Count - 1], 2, wLeft.Count - 1);

            SetWaves(wRight[wRight.Count-1]);
            wRight[wRight.Count - 1].Name = "wavelengthRight" + wRight.Count.ToString();
            peaksTable.Controls.Add(wRight[wRight.Count - 1], 3, wRight.Count - 1);

            SetThres(threshList[threshList.Count-1]);
            threshList[threshList.Count - 1].Name = "thresholde" + threshList.Count.ToString();
            peaksTable.Controls.Add(threshList[threshList.Count - 1], 4, threshList.Count - 1);
            //Debug.WriteLine($"DEBUG thres NUMBERS ¤¤¤¤¤¤¤¤¤¤¤ {threshList.Count}");

            SetLabelP(labelPList[labelPList.Count-1]);
            labelPList[labelPList.Count - 1].Text = $"Peak {labelPList.Count.ToString()}";
            peaksTable.Controls.Add(labelPList[labelPList.Count - 1], 1, labelPList.Count - 1);
           
            /*SetLabelP(labelCOG[labelCOG.Count-1]);
            labelCOG[labelCOG.Count - 1].Text = $"{(peaks[labelCOG.Count - 1].COGinWaveLength)}";
            peaksTable.Controls.Add(labelCOG[labelCOG.Count - 1], 5, labelCOG.Count - 1);
             */   
            peaks.Add(new COG((float)wLeft[wLeft.Count - 1].Value, (float)wRight[wRight.Count - 1].Value, (float)threshList[threshList.Count - 1].Value, 0, 0));
            }

        private void buttonSaveLog_Click(object sender, EventArgs e)
            {
          
            DialogResult savingQuestion = MessageBox.Show("Do you want to save the reuslts?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (savingQuestion == DialogResult.Yes)
                    {
                   
                    if (writingFileTest2 != null)
                        {
                           writingFileTest2.Close();
                            time.Stop();
                        }
                sfd.Filter = "Text |*.txt";
                    sfd.Title = "Save a Text File";
                    /*  while (sfd.FileName.Any(char.IsSymbol))
                          {
                          MessageBox.Show("Please insert only numeric values");
                          sfd.Filter = "Text |*.txt";
                          sfd.Title = "Save a Text File";
                          }*/
                    if (sfd.ShowDialog() == DialogResult.Cancel)
                        {
                        
                        }

                    else
                        {
                        decimal inputInterval;

                        string inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                        /*char[] inputCharInterval = inputStringInterval.ToCharArray();
                        while (inputCharInterval[0] == 0 && inputCharInterval[inputCharInterval.Length - 1] == 0)
                            {
                            MessageBox.Show("Invalid value");
                            inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                            }
                        */
                            {
                            while (!inputStringInterval.All(char.IsDigit) && button1.Text == "STOP")
                                {
                                MessageBox.Show("Please insert only numeric values");
                                inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                                //if you stop and run again goes into an infinte loop --- INSTABLE CODE HERE
                                }
                            }
                        if (Decimal.TryParse(inputStringInterval, out inputInterval))
                            {

                            time.Interval = (int)inputInterval * 1000;
                            time.Tick += new EventHandler(time_Tick);
                        //time.Enabled = true;
                        
                        time.Stop();
                        time.Start();

                        writingFileTest2 = new StreamWriter(sfd.FileName);
                            writingFileTest2.AutoFlush = true;
                            //workerThread.RunWorkerAsync();

                            }


                        }
                    }
              
            }

       
        private void SetWaves (NumericUpDown waveToSet)
            {
            waveToSet.DecimalPlaces = 1;
            //wLeft[i].Location = new System.Drawing.Point(94 + 20 * i, 58 + 10 * i);
            waveToSet.Maximum = new decimal(new int[] {
                        10860,
                        0,
                        0,
                        65536});
            waveToSet.Minimum = new decimal(new int[] {
                        7250,
                        0,
                        0,
                        65536});
          
            waveToSet.Size = new System.Drawing.Size(57, 24);
            waveToSet.Value = new decimal(new int[] {
                        8400,
                        0,
                        0,
                        65536});
            waveToSet.Enabled = true;
            waveToSet.ValueChanged += new System.EventHandler(waveLengths_ValueChanged);

            }

        private void SetLabelP(System.Windows.Forms.Label labelP)
            {
            labelP.AutoSize = true;
            labelP.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
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
            thresToSet.Location = new System.Drawing.Point(103, 109);
            thresToSet.Margin = new System.Windows.Forms.Padding(2);
            thresToSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            
            thresToSet.Size = new System.Drawing.Size(62, 24);
            
            thresToSet.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            thresToSet.ValueChanged += new System.EventHandler(this.waveLengths_ValueChanged);

            }

        }
}






