using System.Collections.Generic; 
namespace EnergiAPI.Model{ 

    public class Result
    {
        public bool success { get; set; }
        public int errorCode { get; set; }
        public string errorText { get; set; }
        public string id { get; set; }
        public string stackTrace { get; set; }
        public Result result { get; set; }
        public string meteringPointId { get; set; }
        public List<Reading> readings { get; set; }
    }

}