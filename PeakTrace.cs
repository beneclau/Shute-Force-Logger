using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace SHUTEmjoelner
namespace SHUTE_Logger
{
    public class PeakTrace
    {
        private List<float> peak = new List<float>();
        private List<double> delay = new List<double>();
        //     private static double[] peak;
        // private static double[] delay;
        private static long length;


        public PeakTrace()
        {
            length = 0;
        }

        public void AddPeak(float pe, double de)
        {
            peak.Add(pe);
            delay.Add(de);
        }

        public int GetLength()
        {
            int length = peak.Count();
            return length;
        }

        public float GetPeak(int nr)
        {
           return peak.ElementAt(nr);
        }

        public double GetDelay(int nr)
        {
            return delay.ElementAt(nr);
        }

 
    }
}
