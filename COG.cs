using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSpectrometer
    {

    public class COG
        {
        //  public float GetCOG;
        public float thresholde = 0.0f;
        static float peakThresholde = 0.0f;
        public  float waveRight = 0.0f;
        public  float waveLeft = 0.0f;
        public float COGresult = 0.0f;
        public float COGinWaveLength = 0.0f;
        static float COGmaxValue = 0.0f;
        public  double[] waveCof = new double[4];
        //public static float thresholde = 0.0f;
        // public static float peakThresholde = 0.0f;
        // public static float waveRight = 0.0f;
        //public static float waveLeft = 0.0f;
        //public static float COGresult = 0.0f;
        // public static float COGinWaveLength = 0.0f;
        //public static float COGmaxValue = 0.0f;
        //public static double[] waveCof = new double[4];

         public COG(double [] coef, float wL, float wR, float thres, float COGRes, float COGinWL)

            {
            waveCof = coef;
            waveLeft = wL;
            waveRight = wR;
            thresholde = thres;
            COGresult = COGRes;
            COGinWaveLength = COGinWL;

            }

        float PixToWave(float pix)
            {
            float wavelength = 0;
            double pixDouble = (double)pix;

            wavelength = (float)(waveCof[0] + waveCof[1] * pixDouble + waveCof[2] * Math.Pow(pixDouble, 2) + waveCof[3] * Math.Pow(pixDouble, 3));
            // Console.WriteLine("PixToWave: {0}", wavelength);
            return wavelength;
            }

        int WaveToPixelLower(float waveSet)
            {
            int pixelResult = 0;
            float wavelength = 725.0f;

            while (wavelength < waveSet)
                {
                wavelength = (float)(waveCof[0] + waveCof[1] * (double)pixelResult + waveCof[2] * Math.Pow((double)pixelResult, 2) + waveCof[3] * Math.Pow((double)pixelResult, 3));
                pixelResult = pixelResult + 1;
                }


            // Console.WriteLine("WaveToPixelLower: {0}", pixelResult);
            // Console.WriteLine("Wavelength: {0}", wavelength);
            // Console.WriteLine("Coff: {0}, {1}, {2}, {3}", waveCof[0], waveCof[1], waveCof[1], waveCof[2], waveCof[3]);
            return pixelResult;
            }

        int WaveToPixelUpper(float waveSet)
            {
            int pixelResult = 2500;
            float wavelength = 1100.0f;

            while (wavelength > waveSet)
                {
                wavelength = (float)(waveCof[0] + waveCof[1] * (double)pixelResult + waveCof[2] * Math.Pow((double)pixelResult, 2) + waveCof[3] * Math.Pow((double)pixelResult, 3));
                pixelResult = pixelResult - 1;
                }

            //Console.WriteLine("WaveToPixelUpper: {0}, {1}", pixelResult, wavelength);
            return pixelResult;
            }

        public float GetCOG(float [] pixSampling)
            {

            float T = 0;
            int xiP = 0;
            float yiP;
            float yi2P;
            float yi;
            float yi2;
            float XL2;
            float YL2;
            float XR;
            float YR;
            int xi = WaveToPixelLower(waveLeft);
            int xk = WaveToPixelUpper(waveRight);
            float maxVal = 0;
            float sumNu = 0, sumDe = 0;

            /* Finds the maximu pixel value and finds the threshold */
            for (int i = xi; i <= xk; i++)
                {
                if (pixSampling[i] > maxVal)
                    {
                    maxVal = pixSampling[i];
                    }
                }

            COGmaxValue = (float)maxVal;

            T = maxVal * thresholde;                // this contains the theshold value
            peakThresholde = T;

            /*Finds xi and xk used in the formula */
            while (pixSampling[xi] < T)
                {
                xi++;
                }
            xi--;

            while (pixSampling[xk] < T)
                {
                xk--;
                }

            /* Defines*/
            xiP = xi + 1;
            yiP = pixSampling[xi + 1];
            yi2P = pixSampling[xk + 1];
            yi = pixSampling[xi];
            yi2 = pixSampling[xk];

            /* Calculations */
            XL2 = (float)xi + ((T - yi) / (yiP - yi));
            YL2 = yi * (((yiP * yiP) - (T * T)) / ((yiP * yiP) - (yi * yi)));

            XR = (float)xk + ((yi2 - T) / (yi2 - yi2P));
            YR = yi2P * (((yi2 * yi2) - (T * T)) / ((yi2 * yi2) - (yi2P * yi2P)));

            for (int i = xiP; i <= xk; i++)
                {
                sumNu = sumNu + ((float)i * pixSampling[i]);
                }
            for (int i = xiP; i <= xk; i++)
                {
                sumDe = sumDe + pixSampling[i];
                }

            COGresult = ((XL2 * YL2) + (XR * YR) + sumNu) / (YL2 + YR + sumDe);

            COGinWaveLength = PixToWave(COGresult);

            return COGresult;
            }

        public float GetCOG(float wL, float wR, float thres, List<float> pixSampling)
            {
            waveLeft = wL;
            waveRight = wR;
            thresholde = thres;

            float T = 0;
            int xiP = 0;
            float yiP;
            float yi2P;
            float yi;
            float yi2;
            float XL2;
            float YL2;
            float XR;
            float YR;
            int xi = WaveToPixelLower(waveLeft);
            int xk = WaveToPixelUpper(waveRight);
            float maxVal = 0;
            float sumNu = 0, sumDe = 0;

            /* Finds the maximu pixel value and finds the threshold */
            for (int i = xi; i <= xk; i++)
                {
                if (pixSampling[i] > maxVal)
                    {
                    maxVal = pixSampling[i];
                    }
                }

            COGmaxValue = (float)maxVal;

            T = maxVal * thresholde;                // this contains the theshold value
            peakThresholde = T;

            /*Finds xi and xk used in the formula */
            while (pixSampling[xi] < T)
                {
                xi++;
                }
            xi--;

            while (pixSampling[xk] < T)
                {
                xk--;
                }

            /* Defines*/
            xiP = xi + 1;
            yiP = pixSampling[xi + 1];
            yi2P = pixSampling[xk + 1];
            yi = pixSampling[xi];
            yi2 = pixSampling[xk];

            /* Calculations */
            XL2 = (float)xi + ((T - yi) / (yiP - yi));
            YL2 = yi * (((yiP * yiP) - (T * T)) / ((yiP * yiP) - (yi * yi)));

            XR = (float)xk + ((yi2 - T) / (yi2 - yi2P));
            YR = yi2P * (((yi2 * yi2) - (T * T)) / ((yi2 * yi2) - (yi2P * yi2P)));

            for (int i = xiP; i <= xk; i++)
                {
                sumNu = sumNu + ((float)i * pixSampling[i]);
                }
            for (int i = xiP; i <= xk; i++)
                {
                sumDe = sumDe + pixSampling[i];
                }

            COGresult = ((XL2 * YL2) + (XR * YR) + sumNu) / (YL2 + YR + sumDe);

            return COGresult;
            }

        public float GetPeakThresholde()
            {
            return peakThresholde;
            }

        float GetCOGWaveLength()
            {
            return COGinWaveLength;
            }

       /* public void SetWaveCof(double[] wcof)
            {
            waveCof[0] = wcof[0];
            waveCof[1] = wcof[1];
            waveCof[2] = wcof[2];
            waveCof[3] = wcof[3];
            }
            */
        public float GetCOGresult()
            {
            return COGresult;
            }

        public float GetCOGinWaveLength()
            {
            return COGinWaveLength;
            }

        /*public void SetThresholde(float thres)
            {
            thresholde = thres;
            // Console.WriteLine("Thresholde: {0}", thresholde);
            }
            */
        public float GetThresholde()
            {
            return thresholde;
            }

       /* public void SetWaveLeft(float wL)
            {
            waveLeft = wL;
            // Console.WriteLine("WaveLeft: {0}", waveLeft);
            }
            */
        public float GetWaveLeft()
            {
            return waveLeft;
            }

       /* public void SetWaveRight(float wR)
            {
            waveRight = wR;
            Console.WriteLine("WaveRight: {0}", waveRight);
            }
            */
        public float GetWaveRight()
            {
            //Console.WriteLine(" DEBUG WAVE RIGHT WaveRight: {0}", waveRight);
            return waveRight;
            }

        public int GetPixelLeft()
            {
            return WaveToPixelLower(waveLeft);
            }

        public int GetPixelRight()
            {
            return WaveToPixelUpper(waveRight);
            }

        public float GetMaxValue()
            {
            return COGmaxValue;
            }

        }
    }
