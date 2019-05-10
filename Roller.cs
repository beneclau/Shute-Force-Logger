using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSpectrometer
{
    class Roller
    {
        public static int speedRPM = 0;
        public static double speedMMs = 0; //mm/sek
        public static double speedMMus = 0; //mm/microsek
        public static double angleUs = 0; //mm/microsek
        public static long speedUsR = 0; //microsek/resolution
        public static int diameter = 0; //in mm
        public static int radius = 0; //in mm
        public static double circumference = 0; //in mm
        public static bool cwRotate = true;
 
        public Roller(int d, bool cw)
        {
            diameter = d;
            cwRotate = cw;
            circumference = Math.PI * (double)d;
            radius = d / 2;
        }

        public void SetDiameter(int d)
        {
            diameter = d;
            circumference = (int)(Math.PI * (double)d);
            radius = d / 2;

        }

        public int GetDiameter()
        {
            return diameter;
        }

        public void SetRadius(int r)
        {
            radius = r;
            diameter = r*2;
            circumference = Math.PI * (double)(2*r);
        }

        int GetRadius()
        {
            return radius;
        }

        public void SetSpeedRPM(int rpm)
        {
            speedRPM = rpm;
            speedMMs = circumference * ((double)rpm / (double)60);
            speedMMus = (circumference * ((double)rpm / (double)60000000));
            speedUsR = (UInt32)((double)60000000/(double)rpm);
            angleUs = ((double)60000000 / (double)rpm)/(double)360;
        }

        public long GetUsFromAngle(double ang)
        {
            long us = (long)(angleUs * ang);
            return us;
        }

        public long GetMaxUsFromAngle()
        {
            long maxus = (long)(angleUs * 360);
            return maxus;
        }

        public int GetSpeedRPM()
        {
            return speedRPM;
        }

        public long GetSpeedUsR()
        {
            return speedUsR;
        }

        public double GetSpeedMMs()
        {
            return speedMMs;
        }

        public double GetSpeedMMus()
        {
            return speedMMus;
        }

        public double GetangleUs()
        {
            return angleUs;
        }


        public void SetCircumference(double cir)
        {
            circumference = cir;
        }

        public double GetCircumference()
        {
            return circumference;
        }

        public void SetCwRotate(bool cw)
        {
            cwRotate = cw;
        }

        public bool GetCwRotate()
        {
            return cwRotate;
        }


    }
}
