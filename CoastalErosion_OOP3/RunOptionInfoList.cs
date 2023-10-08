using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CoastalErosion
{
    public class RunOptionInfoList: ArrayList
    {
        public RunOptionInfoList(IDataReader rdr)
        {
            while (rdr.Read())
            {
                RunOptionInfo rrr = new RunOptionInfo(rdr);
                Add(rrr);
            }
        }
    }
}
