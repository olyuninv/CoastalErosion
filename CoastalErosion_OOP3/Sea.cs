using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    public enum SaveOption
    {
        ALL, BEFORE_TOP, AFTER_TOP, BEFORE_BOTTOM, AFTER_BOTTOM, EVERY500YRS, EVERY1000YRS, NONE
       
    }

    class Sea
    {
        private bool constSea = false;
        public bool ConstSea
        {
            get { return constSea; }
        }

        private double initSeaLevel = 0;
        private double seaLevel;
        public double SeaLevel
        {
            get { return initSeaLevel; }
            set
            {
                initSeaLevel = value;
            }
        }
        private bool saveResult = false;
        public bool SaveResult
        {
            get { return saveResult; }
            set { saveResult = value; }
        }
        private SaveOption saveOpt = SaveOption.AFTER_BOTTOM;
        public SaveOption SaveOpt
        {
            get { return saveOpt; }
            set { saveOpt = value; }
        }
        
        //cycle start times
        private int[] times;
        public int StartTime
        {
            get { return times[0]; }
        }
        public int EndTime
        {
            get { return times[times.Length - 1]; }
        }

        //periods and ranges
        private int[] periods;
        private double[] ranges;
        public double MaxRange
        {           
            get
            {
                if (ranges == null)
                    return 0;
                double tmp = ranges[0];
                for (int i = 0; i < ranges.Length; i++)
                    if (tmp < ranges[i])
                        tmp = ranges[i];
                return tmp;
            }
        }

        private int nCycles = 0;
        private int cCycle = 0;
        private int cBeginCycle;
        private int cEndCycle;
        private int cPeriod;
        private double cRange;
        

        //speed
        private double fallSpeed = 0;
        private double riseSpeed = 0;

        //Cycle stages
        private double[] durations;
        private int interglacialStand;
        private int glacialStand;
        private int fallingSea;
        private int risingSea;

        public Sea()
        {
            constSea = true;
            initSeaLevel = 0;           
        }

        public Sea(double seaLevel)
        {
            constSea = true;
            initSeaLevel = seaLevel;
        }

        public Sea(double seaLevel, SeaInfo seainfo)
        {
            initSeaLevel = seaLevel;

            setVariables(seainfo);
        }

        public void setVariables(SeaInfo si)
        {
            //get times
            nCycles = si.NCycles;
            times = si.getTimes();

            if (si.ConstantSea == true)
            {
                constSea = true;
                periods = null;
                ranges = null;
                durations = null;
            }
            else
            {
                constSea = false;
                periods = si.getPeriods();
                ranges = si.getRanges();
                durations = si.getDurations();
                checkDurations();
            }

            initialiseSea();
        }

        private void checkDurations()
        {
            if (durations == null)
                return;

            double sum = 0; //sum should equal 1

            for (int i = 0; i < durations.Length; i++)
                sum += durations[i];

            if (Math.Abs(sum - 1) > 0.0001)
            {
                durations[0] = 0.03;
                durations[1] = 0.82;
                durations[2] = 0.03;
                durations[3] = 0.12;
            }
        }

        private void initialiseSea()
        {
            seaLevel = initSeaLevel;
            if (constSea == true) //const sea
            {
                riseSpeed = fallSpeed = 0;
                cBeginCycle = times[cCycle];
            }
            else
            {
                assignBounds(periods[0]);
                assignSpeed(ranges[0]);
                cCycle = 0;
                cBeginCycle = times[cCycle];
                cEndCycle = times[cCycle + 1];
                cPeriod = periods[cCycle];
                cRange = ranges[cCycle];
            }
        }

        private void assignBounds(int cycleLength)
        {
            double tmp = durations[0];
            interglacialStand = (int)(tmp * cycleLength);
            tmp += durations[1];
            fallingSea = (int)(tmp * cycleLength);
            tmp += durations[2]; 
            glacialStand = (int)(tmp * cycleLength);
            risingSea = cycleLength;            
        }

        private void assignSpeed(double range)
        {
            fallSpeed = range / (fallingSea - interglacialStand);
            riseSpeed = range / (risingSea - glacialStand);
        }

        public double changeLevel(int time)
        {
            if (constSea)
            {
                saveResult = notifySave(time - cBeginCycle);
                return seaLevel;
            }

            if (time > cEndCycle) //times stores start dates, so in this case we are on to next cycle
            {
                cCycle ++;

                cBeginCycle = times[cCycle];
                cEndCycle = times[cCycle + 1];
                cPeriod = periods[cCycle];
                cRange = ranges[cCycle];

                assignBounds (cPeriod);
                assignSpeed (cRange);
                
            }

            int rest = (time - cBeginCycle)%cPeriod;
            if (rest > interglacialStand && rest < fallingSea)
                seaLevel -= fallSpeed;
            else if (rest > glacialStand && rest < risingSea)
                seaLevel += riseSpeed;
            else if (rest == 0)    //begining of new cycle - zero the sea
                seaLevel = initSeaLevel;

            saveResult = notifySave(rest);

            return seaLevel;              
        }

        private bool notifySave(int rest)
        {
            switch (saveOpt)
            {
                case SaveOption.NONE:
                    return false;
                case SaveOption.ALL:
                    if (rest == 0 ||rest == interglacialStand || rest == fallingSea || rest == glacialStand)
                        return true;
                    break;
                case SaveOption.BEFORE_TOP:
                    if (rest == 0)
                        return true;
                    break;
                case SaveOption.AFTER_TOP:
                    if (rest == interglacialStand)
                        return true;
                    break;
                case SaveOption.BEFORE_BOTTOM:
                    if (rest == fallingSea)
                        return true;
                    break;
                case SaveOption.AFTER_BOTTOM:
                    if (rest == glacialStand)
                        return true;
                    break;
                case SaveOption.EVERY500YRS:
                    if (rest % 500 == 0)
                        return true;
                    break;
                case SaveOption.EVERY1000YRS:
                    if (rest % 1000 == 0)
                        return true;
                    break;
            }
            return false;
        }
    }
}
