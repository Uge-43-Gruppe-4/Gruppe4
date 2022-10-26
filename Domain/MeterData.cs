using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MeterData
    {
        private double value;
        private DateTime toDate;
        private DateTime fromDate;

        public double Value
        {
            get { return value; }
            set { value = value; }
        }
        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
       
    }
}
