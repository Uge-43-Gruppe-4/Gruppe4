using EnergiAPI.Model;

namespace EnergiAPI.Repository
{
    public class MeterDataRepository
    {
        public List<MeterUnit> MeterList { get; set; }

        public MeterDataRepository()
        {
            MeterList = new List<MeterUnit>();
        }

        public List<MeterData> GetMeterReadings(DateTime Date, string UnitID)
        {
            string URL = "";
            HttpClient client = new HttpClient();

            var result = client.GetFromJsonAsync<MeterUnit>(URL).Result!.MeterDatas;

            return result;
        }

        public List<MeterData> GetMeterReadings(DateTime FromDate, DateTime ToTime, string UnitID)
        {
            string URL = "";
            HttpClient client = new HttpClient();

            var result = client.GetFromJsonAsync<MeterUnit>(URL).Result!.MeterDatas;

            return result;
        }
    }
}
