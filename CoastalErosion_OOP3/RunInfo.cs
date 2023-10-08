using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    public class RunInfo
    {
        private int RunID;
        private double initialSlope;
        public double InitSlope
        {
            get { return initialSlope; }
            set { initialSlope = value; }
        }
        private double tidalRange;
        public double TidalRange
        {
            get { return tidalRange; }
            set { 
                if (value > 0)
                    tidalRange = value; 
            }
        }
        private int waveSetID;
        public int WaveSetID
        {
            get { return waveSetID; }
            set { waveSetID = value; }
        }
        private double k;
        public double K
        {
            get { return k; }
            set { k = value; }
        }
        private double sfmin;
        public double Sfmin
        {
            get { return sfmin; }
            set { sfmin = value; }
        }
        private double s;
        public double S
        {
            get { return s; }
            set { s = value; }
        }
        private double M;
        public double getM
        {
            get { return M; }
            set { M = value; }
        }
        private double Q;
        public double getQ
        {
            get { return Q; }
            set { Q = value; }
        }        
        private int seaID;
        public int SeaID
        {
            get { return seaID; }
            set { seaID = value; }
        }
        private double tectMovement;
        public double TectMovement
        {
            get { return tectMovement; }
            set { tectMovement = value; }
        }

        public RunInfo()
        {
            RunID = 0;
            waveSetID = 0;
            seaID = 0;
            tectMovement = 0;
        }
     
        public RunInfo (DataRow rdr)
        {
            RunID = (int) rdr["RunID"];
            initialSlope = (double)rdr["InitialSlope"];
            tidalRange = (double) rdr["TidalRange"];
            waveSetID = (int)rdr["WaveSetID"];
            k = (double)rdr["k"];
            sfmin = (double)rdr["Sfmin"];
            s = (double)rdr["s"];
            M = (double)rdr["M"];
            Q = (double)rdr["Q"];
            seaID = (int)rdr["SeaID"];
            tectMovement = (double)rdr["TectMovement"];
        }

        public string[] ToStringArray()
        {
            string[] values = new string[10];
            values[0] = RunID.ToString();
            values[2] = initialSlope.ToString();
            values[3] = tidalRange.ToString();
            values[4] = waveSetID.ToString();
            values[5] = k.ToString();
            values[6] = sfmin.ToString();
            values[7] = s.ToString();
            values[8] = M.ToString();
            values[9] = Q.ToString();

            return values;
        }

        public bool compareToDataRow(DataRow dr)
        {
            RunInfo tmp = new RunInfo(dr);

            if (this.initialSlope == tmp.initialSlope && this.tidalRange == tmp.tidalRange && this.waveSetID == tmp.waveSetID && this.k == tmp.k && this.s == tmp.s && this.sfmin == tmp.sfmin && this.Q == tmp.Q && this.M == tmp.M && this.seaID == tmp.seaID && this.tectMovement == tmp.tectMovement)
                return true;
            else return false;
        }
    }
}
