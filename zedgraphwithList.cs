 //float intsetpoint = max[0];
            //float intcurrent = max[1];
            
            Debug.WriteLine($"DEBUG CURVES ¤¤¤¤¤¤¤¤¤¤ {curves.Count} ");
            Debug.WriteLine($"DEBUG CURVES 2 ¤¤¤¤¤¤¤¤¤¤ {zed.GraphPane.CurveList.Count} ");
            if (zed.GraphPane.CurveList.Count <= 0)
                return;
            //List<LineItem> curves = new List<LineItem>();
            for (int i = 0; i < peaks.Count; i++)
                {
                
                curves[i] = zed.GraphPane.CurveList[i] as LineItem;
                }
            
            //LineItem curve = zed.GraphPane.CurveList[0] as LineItem;
            // LineItem curve1 = zed.GraphPane.CurveList[1] as LineItem;
            if (curves == null)
                return;
            // if (curve1 == null)
            //   return;
            
            foreach (LineItem item in curves)
                {
                list.Add(item.Points as IPointListEdit);
                }
                //IPointListEdit list1 = curve1.Points as IPointListEdit;

                if (list == null)
                return;
            //if (list1 == null)
             //   return;
            double time = (Environment.TickCount - TickStart) / 1000.0;
           // list.Add(time, intsetpoint);
           // list1.Add(time, intcurrent);
           for (int i =0; i <peaks.Count; i++)
                {
                list[i].Add(time, max[i]);
                Debug.WriteLine($"DEBUG ZEDGRAPH 2 {max[i]}"); 
                }
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
