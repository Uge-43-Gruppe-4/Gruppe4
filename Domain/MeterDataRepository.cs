using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MeterDataRepository
    {
        private List<MeterUnit> meterList = new List<MeterUnit>();

        public List<MeterUnit> MeterList
        {
            get { return meterList; }
        }

        public MeterDataRepository()
        {
            //
        }
    }
}
