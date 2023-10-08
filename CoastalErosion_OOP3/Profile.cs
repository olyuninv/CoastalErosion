using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace CoastalErosion
{
    class Profile
    {
        //--Erosion mode
        private int erosionMode = 2;
        public int ErosionMode
        {
            get { return erosionMode; }
            set
            {
                if (0 < value && value <= 4)
                    erosionMode = value;
            }
        }

        //--constants
        private const double g = 9.81;      //acceleration due to gravity - m/s*s;
        private const double pw = 1025.22;  //density of water - kg/ m^3        
        
        //--profile
        public double[,] data = null;     //x- and y- coord
        private int rows = 1;     //number of points in the profile
        public int Rows
        {
            get { return rows; }
        }
        private double initAccuracy = 0.01;     //requested accuracy
        public double Accuracy
        {
            get { return initAccuracy; }
            set { 
                if (value >0)
                    initAccuracy = value; 
            }
        }
        private double accuracy;     //current vertical distance between two points in the profile
        private double initIncline = 5;     //degrees         
        private int nCliffInt = 0;  //cliff height is always 0.5 of tidal range
        
        //--tide
        private int nTideLevels = 5; //number of tide levels
        private double[] tidalDuration; //hours a year

        //--waves
        private const int nWaves = 5;
        private double[] waveHeight = new double[nWaves];
        private double[] waveFrequency = new double[nWaves];
        private double[] wavePeriod = new double[nWaves];
        private double[] waveLength = new double[nWaves];
        private double[] brWaveHeight = new double[nWaves];  //breaking wave height
        private double[,] brWaveDepth = new double[nWaves, 2];    //breaking wave depth in meters and indices
        private double[] nWavesHour = new double[nWaves];
        private double maxWaveLength;

        //--erosion profile  && tide 
        private double tidalRange = 3;  //meters
        public double TidalRange
        {
            get { return tidalRange; }
        }
        private int nErIntervals = 1;     //number of intervals to erode at each iteration (depends on wave length)
        private double tideInterval; //height of one intertidal interval = tideRange/ nTideLevels
        private int indicesPerTInt; //nIndices per tide interval
        double[] erosionRates = null;
                
        //--variables
        private double k = 0.01;      //bottom roughness factor - suggested values: 0.1, 0.05, 0.01 
        private double Sfmin = 20;    //threshhold minimum surf force term - kg/m*m
        private double s = 1;       //depth decay const for submarine erosion
        private double M = 6.5*0.00000001;   //coefficient to convert force into meters of erosion
        private double Q = 1;   //debris accumulation
        private double tectMovement;

        //--other
        private int wlIndex = -1; //something impossible
        public int WLIndex
        {
            get { return wlIndex; }
        }
        private float cWaterLevel = 0;
        
        //--drawing
        private float xmin = 0, xmax = 320, ymin = 0, ymax = 220;
        private float xdmin = 0, xdmax = 320, ydmin = 0, ydmax = 220;
        private float sx = 1, sy = 1, tx = 0, ty = 0;
        private float tr;
                
        //-----------CONSTRUCTORS---------------
        public Profile()
        {
        }

        public Profile(TideInfo ti)
        {
            setTide(ti);
        }

        public Profile(TideInfo ti, RunInfo vars, WaveInfo waves)
        {
            setTide(ti);
            setWaves(waves);
            setVariables(vars);
        }

        public Profile(TideInfo ti, RunInfo vars, WaveInfo waves, double initAccuracy)
        {
            setTide(ti);
            setWaves(waves);
            this.initAccuracy = initAccuracy;
            setVariables(vars);            
        }

        //---------INITIALISE PROFILE----------
        public void setTide(TideInfo ti)
        {
            tidalDuration = ti.getTidalDurations();
            this.nTideLevels = tidalDuration.Length;
            erosionRates = new double[nTideLevels];
        }

        public void setWaves(WaveInfo wi)
        {
            waveHeight = wi.getWaveHeight();
            waveFrequency = wi.getWaveFrequency();
            wavePeriod = wi.getWavePeriod();

            //wave length L0 = 1.56*T*T, where T is period
            double temp = 0;
            for (int i = 0; i < nWaves; i++)
            {
                waveLength[i] = 1.56 * wavePeriod[i] * wavePeriod[i];
                if (temp < waveLength[i])
                    temp = waveLength[i];
            }
            maxWaveLength = temp;

            //corresponding breaking wave heights
            for (int i = 0; i < brWaveHeight.Length; i++)
                brWaveHeight[i] = 0.39 * Math.Pow(g, 0.2) * Math.Pow(wavePeriod[i] * waveHeight[i] * waveHeight[i], 0.4);

            // corresponding breaking wave depth
            for (int i = 0; i < brWaveDepth.GetLength(0); i++)
                brWaveDepth[i,0] = brWaveHeight[i] / 0.78;

            //corresponding wave hours for each type of wave
            for (int i = 0; i < nWavesHour.Length; i++)
                nWavesHour[i] = 3600 * waveFrequency[i] / wavePeriod[i]; //sec an hour * wave % frequency/ wave period
                        
        }
                
        public void setVariables (RunInfo ri)
        {
            tidalRange = ri.TidalRange;
            tr = (float)tidalRange;
            initIncline = ri.InitSlope;
            k = ri.K;
            s = ri.S;
            M = ri.getM;
            Q = ri.getQ;
            Sfmin = ri.Sfmin;
            tectMovement = ri.TectMovement;
        }

        public void initialiseProfile(double fluctRange, int yearsRunning)
        {
            //check that the wave array is set
            if (maxWaveLength < 0.001)
                return;

            tideInterval = tidalRange / (nTideLevels - 1);
                        
            accuracy = initAccuracy * tideInterval;
            indicesPerTInt = (int) Math.Round(1 / initAccuracy);
            
            //Cliff - half the tidalrange
            nCliffInt = 2 * indicesPerTInt;
            
            //Erosion intervals 
            nErIntervals = nTideLevels + (int)Math.Floor(0.5 * maxWaveLength / tideInterval);
            
            //Total points in profile
            rows = nCliffInt + nErIntervals * indicesPerTInt + (int)Math.Ceiling(fluctRange/accuracy) + (int)Math.Ceiling((tectMovement*yearsRunning) / accuracy)+2;
            
            //Fill data array
            data = new double[rows, 2];
            double angleTan = Math.Tan(initIncline * Math.PI / 180);
            double xdist = accuracy / angleTan;

            //cliff
            for (int i = 0; i < nCliffInt; i++)
            {
                data[i, 0] = (nCliffInt - i) * accuracy;  //vertical co-ordinate
                data[i, 1] = 0;  //horisontal co-ord                
            }
            //rest of profile
            for (int i = nCliffInt; i < rows; i++)
            {
                data[i, 0] = (nCliffInt - i) * accuracy; //vertical co-ord
                data[i, 1] = (nCliffInt - i) * xdist;  //horizontal co-ordinate
            }

            //save depthes of waves in indices (uses accuracy....!)
            for (int i = 0; i < nWaves; i++)
                brWaveDepth[i, 1] = Math.Floor (brWaveDepth[i, 0] / accuracy);

            wlIndex = -1;  
        }

        //---------ERODE PROFILE-----------------
        public void erodeProfile(double cWaterLevel)
        {
            this.cWaterLevel = (float) cWaterLevel; //for graphics

            //index of water level in the profile
            wlIndex = (int)Math.Round((data[0,0] - cWaterLevel) / accuracy);

            getCurrentErosionRates();

            //Modify profile accordingly
            switch (erosionMode)
            {
                case 1:
                    modifyProfile1();
                    break;
                case 2:
                    modifyProfile2();
                    break;
                case 3:
                    modifyProfile3();
                    break;
                case 4:
                    modifyProfile4();
                    break;            
            }

            collapseOverhanging();            
        }

        private void getCurrentErosionRates()   //method modifies erosionRates array
        {
            //get erosion rates at each intertidal level
            int cTideIndex = wlIndex, bpIndex;
            double ws, addAngle, sum, C, ksi, submAngle, Sf, rest, xtemp;

            //for each intertidal level
            for (int i = 0; i < nTideLevels; i++)
            {
                sum = 0;

                //for each type of wave
                for (int j = 0; j < nWaves; j++)
                {
                    bpIndex = cTideIndex + (int)brWaveDepth[j, 1];

                    //width of the surf zone for this wave and tide level
                    ws = data[cTideIndex, 1] - data[bpIndex, 1];

                    //Plus we want to take into account additional ws if accuracy is big 
                    rest = brWaveDepth[j, 0] - brWaveDepth[j, 1] * accuracy;
                    xtemp = data[bpIndex, 1] - data[bpIndex + 1, 1];
                    if (xtemp > 0.0002)  //slope is not vertical
                    {
                        addAngle = accuracy / xtemp;
                        ws += rest / addAngle;
                    }

                    // find C
                    xtemp = data[bpIndex - 1, 1] - data[bpIndex, 1];
                    if (xtemp > 0.0002)  //slope is not vertical
                    {
                        submAngle = accuracy / xtemp;
                        ksi = submAngle / Math.Sqrt(brWaveHeight[j] / waveLength[j]);
                        C = findC(ksi);
                    }
                    else
                        C = 0.5;

                    //Excess surf force (we only add it if it's positive)
                    Sf = 0.5 * pw * C * brWaveDepth[j, 0] * Math.Exp(-k * ws) - Sfmin;
                    if (Sf > 0)
                        sum += M * tidalDuration[i] * nWavesHour[j] * Sf;
                }

                erosionRates[i] = sum;  //erosion on each intertidal level
                cTideIndex += indicesPerTInt;
            }
        }

        private void collapseOverhanging()
        {
            for (int i = rows - 1; i > 0; i--)
                if (data[i - 1, 1] < data[i, 1])
                    data[i - 1, 1] = data[i, 1];
        }

        private void modifyProfile1()
        {
            double sum, h;
            int cIndex = wlIndex;

            for (int i = 0; i < nErIntervals - 1; i++)
            {
                sum = 0;    //summary erosion for each interval
                h = i * tideInterval;  //height to MHWS

                for (int j = 0; j < nTideLevels; j++)
                {
                    if (h < 0)
                        break;  //we are in one of the first five intervals
                    sum += erosionRates[j] * Math.Exp(-s * h);
                    h -= tideInterval;
                }

                //we need to add the erosion to all points within current interval
                for (int j = 0; j < indicesPerTInt; j++)
                    data[cIndex + j, 1] += sum;

                cIndex += indicesPerTInt;
            }
        }

        private void modifyProfile2()
        {
            double sErosion, h;
            int cIndex = wlIndex;
            int bottomIndex = cIndex + nErIntervals * indicesPerTInt - 2;

            for (int i = 0; i < nTideLevels; i++)  //for each tidal level
            {
                sErosion = erosionRates[i];
                h = 0;

                for (int j = cIndex; j < bottomIndex; j++)
                {
                    data[j, 1] += sErosion * Math.Exp(-s * h);
                    h += accuracy;
                }

                cIndex += indicesPerTInt;
            }
        }

        private void modifyProfile3()
        {
            double sErosion, h;
            int cIndex = wlIndex;
            int bottomIndex = cIndex + nErIntervals * indicesPerTInt - 1;
            
            for (int i = 0; i < nTideLevels; i++)  //for each tidal level
            {
                sErosion = erosionRates[i];
                h = 0;

                for (int j = cIndex; j < bottomIndex; j += indicesPerTInt)
                {
                    data[j, 1] += sErosion * Math.Exp(-s * h);
                    h += tideInterval;
                }

                cIndex += indicesPerTInt;
            }

            //we want to join new points with a line
            double xstep, xtmp;
            cIndex = wlIndex;

            for (int i = 0; i < nErIntervals - 1; i++)
            {
                xtmp = data[cIndex, 1];
                xstep = (data[cIndex, 1] - data[cIndex + indicesPerTInt, 1]) / indicesPerTInt;
                
                for (int j = 1; j < indicesPerTInt; j++)
                {
                    xtmp -= xstep;
                    data[cIndex + j, 1] = xtmp;
                }

                cIndex += indicesPerTInt;
            }
        }

        private void modifyProfile4()
        {
            double sErosion, h;
            int cIndex = wlIndex - indicesPerTInt / 2;
            
            //for the first five levels - add erosion to a strip
            for (int i = 0; i < nTideLevels; i++)  
            {
                sErosion = erosionRates[i];
                
                for (int j = 0; j < indicesPerTInt; j ++)
                {
                    data[cIndex + j, 1] += sErosion;
                }

                cIndex += indicesPerTInt;
            }

            //submarine erosion
            cIndex = wlIndex - indicesPerTInt / 2;
            int bottomIndex = cIndex + nErIntervals * indicesPerTInt;

            for (int i = 0; i < nTideLevels; i++)
            {
                sErosion = erosionRates[i];
                cIndex += indicesPerTInt;                
                h = tideInterval/2;

                for (int j = cIndex; j < bottomIndex; j++)
                {
                    data[j, 1] += sErosion* Math.Exp (- s* h);
                    h += accuracy;
                }                
            }
        }

        private double findC(double ksi)
        {
            if (ksi <= 0.4) //spilling breakers
                return 0.8;
            if (ksi >= 2)   //surging-collapsing breakers
                return 0.5;
            return 1;
        }

        //---------DRAW--------------
        public void Draw(Graphics g)
        {
            xmin = (float)data[rows - 1, 1];
            xmax = (float)data[0, 1];
            ymin = (float)data[rows - 1, 0];
            ymax = (float)data[0, 0];

            calcTransforms ();

            g.TranslateTransform(tx, ty);
            g.ScaleTransform(sx, sy);
            using (Pen p = new Pen(Color.Black, 1/sx))
            {
                //axis
                g.DrawLine(p, 0, ymin, 0, ymax);
                g.DrawLine(p, xmin, 0, xmax, 0);

                //scales
                float tickX = 5 / sx;
                float tickY = 5 / sy;
                g.DrawLine(p, xmin, ymin, xmax, ymin);    //top
                g.DrawLine(p, xmax, ymin, xmax, ymax);    //side
                for (float i = 0; i > xmin; i -= 100)
                    g.DrawLine(p, i, ymin - tickY, i, ymin + tickY);
                for (float i = 0; i < xmax; i += 100)
                    g.DrawLine(p, i, ymin - tickY, i, ymin + tickY);
                for (float i = 0; i < ymax; i += 10)
                    g.DrawLine(p, xmax - tickX, i, xmax + tickX, i);
                for (float i = 0; i > ymin; i -= 10)
                    g.DrawLine(p, xmax - tickX, i, xmax + tickX, i);
                
                p.Color = Color.Blue;

                //frame
                g.DrawLine(p, xmin, ymin, xmin, cWaterLevel);    //side

                //Water
                g.DrawLine(p, xmin, cWaterLevel, xmax, cWaterLevel);    //x axis
                g.DrawLine(p, xmin, cWaterLevel - 0.25f * tr, xmin + 20, cWaterLevel - 0.25f * tr);
                g.DrawLine(p, xmin, cWaterLevel - 0.5f * tr, xmin + 20, cWaterLevel - 0.5f * tr);
                g.DrawLine(p, xmin, cWaterLevel - 0.75f * tr, xmin + 20, cWaterLevel - 0.75f * tr);
                g.DrawLine(p, xmin, cWaterLevel - tr, xmax, cWaterLevel - tr);    //x axis

                p.Color = Color.Brown;

                //Draw profiles
                for (int i = 0; i < rows - 1; i++)
                {
                    g.DrawLine(p, (float)data[i, 1], (float)data[i, 0], (float)data[i + 1, 1], (float)data[i + 1, 0]);
                    //g.DrawEllipse(p, (float)data[i, 1], (float)data[i, 0], 0.5f/sx, 0.5f/sx);
                }
            }
            g.TranslateTransform(0, 0);
            g.ScaleTransform(1, 1);            
        }

        public void DrawColor(Graphics g)
        {
            xmin = (float)data[rows - 1, 1];
            xmax = (float)data[0, 1];
            ymin = (float)data[rows - 1, 0];
            ymax = (float)data[0, 0];

            calcTransforms();

            g.TranslateTransform(tx, ty);
            g.ScaleTransform(sx, sy);
            using (Pen p = new Pen(Color.Black, 1 / sx))
            {
                //axis
                g.DrawLine(p, 0, ymin, 0, ymax);
                g.DrawLine(p, xmin, 0, xmax, 0);

                //scales
                float tickX = 5 / sx;
                float tickY = 5 / sy;
                g.DrawLine(p, xmin, ymin, xmax, ymin);    //top
                g.DrawLine(p, xmax, ymin, xmax, ymax);    //side
                for (float i = 0; i > xmin; i -= 100)
                    g.DrawLine(p, i, ymin - tickY, i, ymin + tickY);
                for (float i = 0; i < xmax; i += 100)
                    g.DrawLine(p, i, ymin - tickY, i, ymin + tickY);
                for (float i = 0; i < ymax; i += 10)
                    g.DrawLine(p, xmax - tickX, i, xmax + tickX, i);
                for (float i = 0; i > ymin; i -= 10)
                    g.DrawLine(p, xmax - tickX, i, xmax + tickX, i);
                                                           
                float x, y;
                //Draw profiles
                for (int i = 0; i < rows; i++)
                {
                    x = (float)data[i, 1];
                    y = (float)data[i, 0];
                    if (y < cWaterLevel)
                    {
                        p.Color = Color.Aquamarine;
                        g.DrawLine(p, xmin, y, x, y);
                    }
                    p.Color = Color.Maroon;
                    g.DrawLine(p, x, y, xmax, y);
                    
                }
                
                p.Color = Color.Blue;

                //frame
                g.DrawLine(p, xmin, ymin, xmin, cWaterLevel);    //side
                
                //Water
                g.DrawLine(p, xmin, cWaterLevel, xmax, cWaterLevel);    //x axis
                //g.DrawLine(p, xmin, cWaterLevel - 0.25f * tr, xmin + 20, cWaterLevel - 0.25f * tr);
                //g.DrawLine(p, xmin, cWaterLevel - 0.5f * tr, xmin + 20, cWaterLevel - 0.5f * tr);
                //g.DrawLine(p, xmin, cWaterLevel - 0.75f * tr, xmin + 20, cWaterLevel - 0.75f * tr);
                g.DrawLine(p, xmin, cWaterLevel - tr, xmax, cWaterLevel - tr);    //x axis
                
            }
            g.TranslateTransform(0, 0);
            g.ScaleTransform(1, 1);
        }

        private void calcTransforms()
        {
            tx = (xdmin * xmax - xdmax * xmin) / (xmax - xmin);
            ty = (ydmin * ymax - ydmax * ymin) / (ymax - ymin);
            sx = (xdmax - xdmin) / (xmax - xmin);
            sy = (ydmax - ydmin) / (ymax - ymin);
        }

        public void setDeviceCoords(float xdmin, float xdmax, float ydmin, float ydmax)
        {
            //if(xdmin < xdmax && ydmin > ydmax)
            //{
            this.xdmin = xdmin;
            this.xdmax = xdmax;
            this.ydmin = ydmin;
            this.ydmax = ydmax;
            //}
            calcTransforms();
        }

        //---------------TECTONICS
        public void tectMove()
        {
            if (tectMovement != 0)
            {
                for (int i = 0; i < rows; i++)
                    data[i, 0] += tectMovement;
            }
        }
    }

}
