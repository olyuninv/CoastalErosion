using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    public class WaveInfo
    {
        private const int nWaves = 5;
        private int waveSetID;
        public int WaveSetID
        {
            get { return waveSetID; }
        }
        private double[] waveHeight;
        private double[] waveFreq;
        private double[] wavePeriod;

        public WaveInfo(double[] waveHeight, double[] waveFreq, double[] wavePeriod)
        {
            if (waveHeight.Length == nWaves && waveFreq.Length==nWaves && wavePeriod.Length == nWaves)
            {
                waveSetID = 0;
                this.waveHeight = waveHeight;
                this.waveFreq = waveFreq;
                this.wavePeriod = wavePeriod;
            }
        }

        public WaveInfo(DataRow wr)
        {
            waveSetID = (int)wr["WaveSetID"];
            waveHeight = new double[nWaves];
            waveFreq = new double[nWaves];
            wavePeriod = new double[nWaves];

            string s = "";
            for (int i = 0; i < nWaves; i++)
            {
                s = i.ToString();
                waveHeight[i] = (double) wr ["WaveHeight"+s];
                waveFreq[i] = (double) wr ["WaveFrequency"+s];
                wavePeriod[i] = (double)wr["WavePeriod" + s];

            }
        }

        public double[] getWaveHeight()
        {
            double[] tmp = new double[nWaves];
            for (int i = 0; i < nWaves; i++)
                tmp[i] = waveHeight[i];
            return tmp;
        }

        public double[] getWaveFrequency()
        {
            double[] tmp = new double[nWaves];
            for (int i = 0; i < nWaves; i++)
                tmp[i] = waveFreq[i];
            return tmp;
        }

        public double[] getWavePeriod()
        {
            double[] tmp = new double[nWaves];
            for (int i = 0; i < nWaves; i++)
                tmp[i] = wavePeriod[i];
            return tmp;
        }
    }
}
