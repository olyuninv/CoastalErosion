using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace CoastalErosion
{
    public class TideInfo
    {
        private const int nTideLevels = 5;
        private int tideID;
        public int TideID
        {
            get { return tideID; }
        }
        private double[] tidalDurations;

        public TideInfo(ListViewItem lvi)
        {
            ListViewItem lv = lvi;
            tideID = Convert.ToInt32 (lvi.SubItems[0].Text);
            tidalDurations = new double[nTideLevels];
            tidalDurations[0] = Convert.ToDouble(lvi.SubItems[1].Text);
            tidalDurations[1] = Convert.ToDouble(lvi.SubItems[2].Text);
            tidalDurations[2] = Convert.ToDouble(lvi.SubItems[3].Text);
            tidalDurations[3] = Convert.ToDouble(lvi.SubItems[4].Text);
            tidalDurations[4] = Convert.ToDouble(lvi.SubItems[5].Text);
        }

        public TideInfo(DataRow dr)
        {
            tideID = (int)dr["TideID"];
            tidalDurations = new double[nTideLevels];
            tidalDurations[0] = (double)dr["MHWS"];
            tidalDurations[1] = (double)dr["MHWN"];
            tidalDurations[2] = (double)dr["MT"];
            tidalDurations[3] = (double)dr["MLWN"];
            tidalDurations[4] = (double)dr["MLWS"];
        }

        public string ConvertToLabel()
        {
            string tmp = "Tide ";
            tmp += tideID.ToString();
            tmp += " : { ";
            for (int i = 0; i < nTideLevels - 1; i++)
            {
                tmp += tidalDurations[i].ToString();
                tmp += ", ";
            }

            tmp += tidalDurations[nTideLevels - 1].ToString();
            tmp += " }";
            return tmp;
        }

        public string ConvertToLabelShort()
        {
            string tmp = tideID.ToString();
            tmp += " (";
            for (int i = 0; i < 2; i++)
            {
                tmp += tidalDurations[i].ToString();
                tmp += "%, ";
            }

            tmp += tidalDurations[2].ToString();
            tmp += "%)";
            return tmp;
        }

        public string[] ToStringArray()
        {
            string[] tmp = new string [nTideLevels + 1];
            tmp[0] = tideID.ToString();
            for (int i = 0; i < nTideLevels; i++)
                tmp[i + 1] = tidalDurations[i].ToString();
            return tmp;
        }

        public double[] getTidalDurations()
        {
            double[] tmp = new double[nTideLevels];
            for (int i = 0; i < nTideLevels; i++)
                tmp[i] = tidalDurations[i];
            return tmp;
        }
    }
}
