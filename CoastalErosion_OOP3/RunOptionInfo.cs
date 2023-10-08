using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    class RunOptionInfo
    {
        private int RunID;
        private int Option;
        private double initialSlope;
        private double tidalRange;
        private int waveSetID;
        private double k;
        private double sfmin;
        private double s;
        private double M;
        private double Q;
        private double seaID;
        private string seaName;
        private double tectMovement;
        private int erMode;
        private int tideID;
        private double accuracy;
        private string saveOptions;
     
        public RunOptionInfo (IDataReader rdr)
        {
            RunID = (int) rdr["RunID"];
            Option = (int)rdr["OptionID"];
            initialSlope = (double)rdr["InitialSlope"];
            tidalRange = (double) rdr["TidalRange"];
            waveSetID = (int)rdr["WaveSetID"];
            k = (double)rdr["k"];
            sfmin = (double)rdr["Sfmin"];
            s = (double)rdr["s"];
            M = (double)rdr["M"];
            Q = (double)rdr["Q"];
            seaID = (int)rdr["SeaID"];
            seaName = (string)rdr["Name"];
            tectMovement = (double)rdr["TectMovement"];
            erMode = (int)rdr["ErosionMode"];
            tideID = (int)rdr["TideID"];
            accuracy = (double)rdr["Accuracy"];
            saveOptions = (string)rdr["SaveProfiles"];
        }

        public string[] ToStringArray()
        {
            string[] values = new string[16];
            values[0] = RunID.ToString();
            values[1] = Option.ToString();
            values[2] = initialSlope.ToString();
            values[3] = tidalRange.ToString();
            values[4] = waveSetID.ToString();
            values[5] = k.ToString();
            values[6] = sfmin.ToString();
            values[7] = s.ToString();
            values[8] = M.ToString();
            values[9] = Q.ToString();
            values[10] = seaName;
            values[11] = tectMovement.ToString();
            values[12] = erMode.ToString();
            values[13] = tideID.ToString();
            values[14] = accuracy.ToString();
            values[15] = saveOptions;

            return values;
        }

    }

}
