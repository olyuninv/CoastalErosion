using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    public class SeaInfo
    {
        private int nCycles;
        public int NCycles
        {
            get { return nCycles; }
        }
        private bool constantSea = false;
        public bool ConstantSea
        {
            get { return constantSea; }
        }
        private int seaID;
        public int SeaID
        {
            get { return seaID; }
        }
        private string seaName;
        private int[] time;
        private int[] periods;
        private double[] ranges;
        private double[] durations;

        public SeaInfo (int[] times, int[] periods, double[] ranges, double[] durations)
        {
            seaID = 0;

            this.time = times;
            this.periods = periods;
            this.ranges = ranges;
            this.durations = durations;
        }

        public SeaInfo(DataRow row)
        {
            //no data is checked - it is supposed to be correct!!!

            seaID = (int)row["SeaID"];
            seaName = (string)row["Name"];
            
            //Find nTimes - the number of different cycles and ranges
            if ((int)row["Period0"] == 0)
            {
                nCycles = 0;
                constantSea = true;
            }
            else if ((int)row["Period1"] == 0)
            {
                nCycles = 1;
                constantSea = false;
            }
            else
            {
                nCycles = 2;
                constantSea = false;
            }

            if (constantSea)
            {
                time = new int[2];
                time[0] = (int)row["StartCycle0"];
                time[1] = (int)row["EndTime"];
                //just to make it clear:
                periods = null;
                ranges = null;
                durations = null;
            }
            else
            {
                time = new int[nCycles + 1]; //plus one because we want to record the end time
                periods = new int[nCycles];
                ranges = new double[nCycles];
                durations = new double[4];

                string s = "";
                for (int i = 0; i < nCycles; i++)
                {
                    s = i.ToString();
                    time[i] = (int)row["StartCycle" + s];
                    periods[i] = (int)row["Period" + s];
                    ranges[i] = (double)row["Range" + s];
                }

                time[time.Length - 1] = (int)row["EndTime"];

                durations[0] = (double)row["DurTopStand"];
                durations[1] = (double)row["DurFalling"];
                durations[2] = (double)row["DurBottomStand"];
                durations[3] = (double)row["DurRising"];
            }           

        }

        public int[] getTimes()
        {
            int[] tmp = new int[time.Length];
            for (int i = 0; i < time.Length; i++)
                tmp[i] = time[i];
            return tmp;
        }

        public int[] getPeriods()
        {
            if (periods == null)
                return null;
            int[] tmp = new int[periods.Length];
            for (int i = 0; i < periods.Length; i++)
                tmp[i] = periods[i];
            return tmp;
        }

        public double[] getRanges()
        {
            if (ranges == null)
                return null;
            double[] tmp = new double[ranges.Length];
            for (int i = 0; i < ranges.Length; i++)
                tmp[i] = ranges[i];
            return tmp;
        }

        public double[] getDurations()
        {
            if (durations == null)
                return null;
            double[] tmp = new double[durations.Length];
            for (int i = 0; i < durations.Length; i++)
                tmp[i] = durations[i];
            return tmp;
        }

        public int[] returnSaveIntervals(SaveOption sv)
        {
            int max = 36;
            int[] saveIntervals = new int[max + 1]; //time to previous profile

            int cCycleLength = periods[0];

            saveIntervals[0] = returnInitSave(cCycleLength, sv);

            switch (sv)
            {
                case SaveOption.EVERY500YRS:
                    for (int i = 1; i < max; i++)
                        saveIntervals[i] = 500;
                    return saveIntervals;
                case SaveOption.EVERY1000YRS:
                    for (int i = 1; i < max; i++)
                        saveIntervals[i] = 1000;
                    return saveIntervals;
                case SaveOption.ALL:
                    //do later
                    System.Windows.Forms.MessageBox.Show("SeaInfo: returnSaveIntervals: case ALL: Code not written");
                    break;
                default:
                    int j = 1;
                    int tmp1 = time[0] + saveIntervals[0];
                    int tmp2 = time[0] + saveIntervals[0] + cCycleLength;
                    for (int i = 0; i < nCycles; i++)
                    {
                        while (tmp2 < time[i + 1])   //end of current cycle
                        {
                            saveIntervals[j] = tmp2 - tmp1;
                            tmp1 = tmp2;
                            tmp2 += cCycleLength;
                            j++;
                        }
                        if (j == max - 1)
                            break;
                        cCycleLength = periods[i + 1];  //next cycle
                        tmp2 = time[i + 1] + returnInitSave(cCycleLength, sv);
                    }
                    saveIntervals[j] = 0 - tmp1;  //profile at the end of a run
                    break;
            }

            return saveIntervals;
        }

        private int returnInitSave(int period, SaveOption sv)
        {
            switch (sv)
            {
                case SaveOption.EVERY500YRS:
                    return 0;
                case SaveOption.EVERY1000YRS:
                    return 0;
                case SaveOption.BEFORE_TOP:
                    return 0;
                case SaveOption.AFTER_TOP:
                    return Convert.ToInt32(durations[0] * period);
                case SaveOption.BEFORE_BOTTOM:
                    return Convert.ToInt32((durations[0] + durations[1]) * period);
                case SaveOption.AFTER_BOTTOM:
                    return Convert.ToInt32((durations[0] + durations[1] + durations[2]) * period);
                case SaveOption.ALL:
                    return 0;
                default:
                    return 0;
            }
        }

    }
}
