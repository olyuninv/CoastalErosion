using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    public class OptionInfo
    {
        private int runID;
        public int RunID
        {
            get { return runID; }
        }
        private int optionID;
        public int OptionID
        {
            get { return optionID; }
        }
        private int erMode;
        public int ErMode
        {
            get { return erMode; }
            set { erMode = value; }
        }
        private int tideID;
        public int TideID
        {
            get { return tideID; }
            set { tideID = value; }
        }
        private double accuracy;
        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }
        private string saveOptions;
        public string SaveOptions
        {
            get { return saveOptions;}
            
            set { saveOptions = value; }
        }

        public OptionInfo()
        {
            runID = 0;
            optionID = 0;
        }

        public OptionInfo(DataRow rdr)
        {
            runID = (int)rdr["RunID"];
            optionID = (int)rdr["OptionID"];
            erMode = (int)rdr["ErosionMode"];
            tideID = (int)rdr["TideID"];
            accuracy = (double)rdr["Accuracy"];
            saveOptions = (string)rdr["SaveProfiles"];
        }

        public bool compareToDataRow(DataRow dr)
        {
            OptionInfo tmp = new OptionInfo(dr);

            if (this.erMode == tmp.erMode && this.tideID == tmp.tideID && this.accuracy == tmp.accuracy && this.saveOptions == tmp.saveOptions)
                return true;
            else return false;
        }

        public SaveOption returnSaveOption()
        {
            switch (saveOptions)
            {
                case ("ALL"):
                    return SaveOption.ALL;
                case ("BEFORE_TOP"):
                    return SaveOption.BEFORE_TOP;
                case ("AFTER_TOP"):
                    return SaveOption.AFTER_TOP;
                case ("BEFORE_BOTTOM"):
                    return SaveOption.BEFORE_BOTTOM;
                case ("AFTER_BOTTOM"):
                    return SaveOption.AFTER_BOTTOM;
                case ("EVERY500YRS"):
                    return SaveOption.EVERY500YRS;
                case ("EVERY1000YRS"):
                    return SaveOption.EVERY1000YRS;
                case ("NONE"):
                    return SaveOption.NONE;
                default:
                    return SaveOption.NONE;
            }
        }
    }
}
