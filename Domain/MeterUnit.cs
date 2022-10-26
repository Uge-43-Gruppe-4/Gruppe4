using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MeterUnit
    {
        private string meterID;
        private List<string> meterDatas = new List<string>();

        public string MeterID
        {
            get { return meterID; }
            set { meterID = value; }
        }

        public List<string> MeterDatas
        {
            get { return meterDatas; }
        }

        public MeterUnit(string meterID, string meterDatas)
        {
            
        }
    }
}
