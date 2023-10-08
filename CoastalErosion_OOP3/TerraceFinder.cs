using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CoastalErosion
{
    class TerraceFinder
    {
        private const double minTerrace = 2;
        private const double minCliff = 0.3;

        private double ydist = 0.01;
        private double[] xdist;
        private int lengthData = 0;

        private int[] minmaxarr;
        private int[] bendPoints;

        public TerraceFinder()
        {
        }

        public double[,] findTerraces(double[, ,] data)
        {
            //check it is only one profile
            if (data.GetLength(2) != 1)
                return null;

            ydist = data[0, 0, 0] - data[1, 0, 0];

            lengthData = data.GetLength(0);

            //transfer data into horisontal distances:
            xdist = new double[lengthData - 1];
            for (int i = 1; i < lengthData; i++)
                xdist[i - 1] = data[i - 1, 1, 0] - data[i, 1, 0];

            int n = 0;
            bendPoints = new int[lengthData - 1];
            //find bend points
            for (int i = 0; i < lengthData - 2; i++)
            {
                if (xdist[i + 1] / xdist[i] < 0.5)
                {
                    bendPoints[n] = i + 1;
                    n++;
                }
            }

            int index = 0;
            double[,] points = new double[n, 2];
            for (int i = 0; i < n; i++)
            {
                index = bendPoints[i];
                points[i, 0] = data[index, 1, 0];
                points[i, 1] = data[index, 0, 0];
            }
            return points;
        }

        public int[] findTerraces2(double[, ,] data)
        {
            //check it is only one profile
            if (data.GetLength(2) != 1)
                return null;

            ydist = data[0, 0, 0] - data[1, 0, 0];

            int lengthData = data.GetLength(0);

            //transfer data into horisontal distances:
            xdist = new double[lengthData - 1];
            for (int i = 1; i < lengthData; i++)
                xdist[i - 1] = data[i - 1, 1, 0] - data[i, 1, 0];

            minmaxarr = new int[lengthData - 1];
            int n = 1;  //number of min's and max's
            minmaxarr[0] = 0;
            double tmp = 0;

            //1) find max and min - some smoothing introduced
            for (int i = 0; i < lengthData - 1; i++)
            {
                //local maximum - while next interval is bigger or roughly equal to tmp
                while (i < lengthData - 1 && xdist[i] >= tmp - 0.0001*tmp)
                {
                    tmp = xdist[i];
                    i++;
                }
                if (i == lengthData - 1)
                    break;
                minmaxarr[n] = i-1;
                n++;
                tmp = xdist[i];
                i++;

                //local minimum
                while (i < lengthData - 1 && xdist[i] <= tmp + 0.0001*tmp)
                {
                    tmp = xdist[i];
                    i++;
                }
                if (i == lengthData - 1)
                    break;
                minmaxarr[n] = i - 1;
                n++;
                tmp = xdist[i];
            }
            //add last interval in xdist
            minmaxarr[n] = lengthData - 2;
            n++;

            //factually our minmax array length = n
            // 2) find bends
            bendPoints = new int[n + 1];
            bendPoints[0] = 0;
            bendPoints[n] = lengthData - 1;

            int m = 1;   //counter for bendPoints
            int startIndex, endIndex;
            double tmp1, tmp2;
 
            //go through all min-max or max-min intervals
            for (int i = 0; i < n - 1; i++)
            {
                startIndex = minmaxarr[i];
                endIndex = minmaxarr[i + 1];
                tmp1 = xdist[startIndex];
                tmp2 = xdist[endIndex];
                
                if (i % 2 == 0)   //look for depression
                {
                    if (tmp1 < ydist && tmp2 > ydist)  //find when slope changes over 45 degrees
                    {
                        int j;
                        for (j = startIndex + 1; j <= endIndex; j++)
                        {
                            tmp1 = xdist[j];
                            if (tmp1 > ydist)
                                break;                            
                        }
                        bendPoints[m] = j;
                    }
                    else   //find quickest change
                    {
                        //find change
                        double[] change = new double[endIndex - startIndex];
                        int j;
                        for (j = 0; j < change.Length; j++)
                            change[j] = xdist[startIndex + j +1] / xdist[startIndex + j];

                        double maxchange = change[0];
                        int maxchangei = 0;

                        //find biggest change
                        for (j = 0; j < change.Length; j++)
                        {
                            if (change[j] > maxchange)
                            {
                                maxchange = change[j];
                                maxchangei = j;
                            }
                        }

                        bendPoints[m] = startIndex + 1 + maxchangei;
                    }
                }
                else   //look for cliff
                {
                    if (tmp1 > ydist && tmp2 < ydist)  //find when slope changes over 45 degrees
                    {
                        int j;
                        for (j = startIndex+1; j <= endIndex; j++)
                        {
                            tmp1 = xdist[j];
                            if (tmp1 < ydist)
                                break;                            
                        }
                        bendPoints[m] = j;
                    }
                    else   //find quickest change
                    {
                        //find change
                        double[] change = new double[endIndex - startIndex];
                        int j;
                        for (j = 0; j < change.Length; j++)
                            change[j] = xdist[startIndex + j + 1] / xdist[startIndex + j];

                        double minchange = change[0];
                        int minchangei = 0;

                        //find biggest change -> smallest ratio
                        for (j = 0; j < change.Length; j++)
                        {
                            if (change[j] < minchange)
                            {
                                minchange = change[j];
                                minchangei = j;
                            }
                        }

                        bendPoints[m] = startIndex + 1 + minchangei;
                    }
                }
                m++;
            }

            ArrayList bparr = new ArrayList();
            for (int i = 0; i < n +1; i++)
                bparr.Add(bendPoints[i]);

            int nextIndex = 0, k =0;
            double diff, tmpdist;
            
            //3) eliminate terraces and cliffs that are very similar to each other
            for (int i = 0; i < n - 1; i++)
            {
                startIndex = (int) bparr[i];
                endIndex = (int) bparr[i + 1];
                nextIndex = (int)bparr[i + 2];
                k = 1;
                
                tmpdist = data[startIndex, 1, 0] - data[endIndex, 1, 0];
                diff = (data[endIndex, 1, 0] - data[nextIndex, 1, 0]) / tmpdist;

                while (Math.Abs(diff - 1) < 0.5 && i + 2 + k < n + 1)
                {
                    endIndex = nextIndex;
                    nextIndex = (int)bparr[i+2+k];
                    diff = (data[endIndex, 1, 0] - data[nextIndex, 1, 0]) / tmpdist;
                    k++;                    
                }                

                //delete couples of points between startIndex and nextIndex
                int ncouples = (k - 1) / 2;
                for (int j = i + 2 * ncouples; j > i; j--) 
                {
                    bparr.RemoveAt(j);
                    n--;
                }
            }
            
            //4) eliminate stand alone small terraces and cliffs
            for (int i = 0; i < n; i++)
            {
                startIndex = (int) bparr[i];
                endIndex = (int) bparr[i + 1];
                
                if (i % 2 == 0)   //it's a cliff
                {
                    if (data[startIndex, 0, 0] - data[endIndex, 0, 0] < minCliff)
                    {
                        //eliminate this cliff
                        bparr.RemoveAt(i + 1);
                        bparr.RemoveAt(i);
                        n -= 2;
                        i --;
                    }
                }
                else   //it's a terrace
                {
                    if (data[startIndex, 1, 0] - data[endIndex, 1, 0] < minTerrace)
                    {
                        //eliminate this terrace
                        bparr.RemoveAt(i + 1);
                        bparr.RemoveAt(i);
                        n -= 2;
                        i --;
                    }
                }
            }
            
            //5) copy array list into array
            //bendPoints = (int)bparr.ToArray(System.Type.GetType("int"));
            bendPoints = new int[bparr.Count];
            for (int i = 0; i < bendPoints.Length; i++)
            {
                bendPoints[i] = (int) bparr[i];
            }
            return bendPoints;
        }
    }
}
