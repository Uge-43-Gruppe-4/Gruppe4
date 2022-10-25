namespace EnergiAPI.Model
{
    public class MeterData
    {
        public int MeterDataID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double Value { get; set; }
    }
}
