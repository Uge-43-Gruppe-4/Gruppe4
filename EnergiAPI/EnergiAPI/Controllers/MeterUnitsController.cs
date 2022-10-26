using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergiAPI.Data;
using EnergiAPI.Model;
using System.Globalization;

namespace EnergiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterUnitsController : ControllerBase
    {

        public MeterUnitsController(EnergiAPIContext context)
        {
        }

        //// GET: api/MeterUnits
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MeterUnit>>> GetMeterUnit()
        //{

        //}

        // GET: api/MeterUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeterUnit>> GetMeterUnit(DateTime from, DateTime to, string id)
        {
            var root = new MeteringPointRoot();
            root.MeteringPoints = new MeteringPoints();
            root.MeteringPoints.meteringPoint.Add(id);

            string URL = $"https://api.eloverblik.dk/customerapi/api/meterdata/getmeterreadings/{from.ToString("yyyy-MM-dd")}/{to.ToString("yyyy-MM-dd")}";
            string accessToken = GetAccessToken();

            HttpClient client1 = new HttpClient();
            client1.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            var result = await client1.PostAsJsonAsync<MeteringPointRoot>(URL, root);

            var content = result.Content.ReadFromJsonAsync<MeteringDataRoot>().Result!;

            var meterUnit = new MeterUnit();
            meterUnit.MeterDatas = new List<MeterData>();
            meterUnit.MeterUnitID = content.result[0].meteringPointId;
            foreach(var v in content.result)
            {
                foreach(var f in v.readings)
                {
                    var data = new MeterData();
                    data.Value = double.Parse(f.meterReading, new CultureInfo("da-DK"));
                    data.FromDate = DateTime.Parse(f.readingDate);
                    meterUnit.MeterDatas.Add(data);
                }
            }
            return meterUnit;
        }

        private string GetAccessToken()
        {
            string URL = "https://api.eloverblik.dk/customerapi/api/token";
            string refreshToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlblR5cGUiOiJDdXN0b21lckFQSV9SZWZyZXNoIiwidG9rZW5pZCI6IjJkMGY4MTljLTVhNGItNGM5ZC" +
                "04MTQ4LTk3ZjU2NzE0MTA1NyIsIndlYkFwcCI6WyJDdXN0b21lckFwaSIsIkN1c3RvbWVyQXBwQXBpIl0sImp0aSI6IjJkMGY4MTljLTVhNGItNGM5ZC04MTQ4LTk3ZjU2NzE0MTA1NyIsI" +
                "mh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiUElEOjkyMDgtMjAwMi0yLTExNzQ0OTAwMDkzMiIsImh0dHA6" +
                "Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkNocmlzdGluYSBGb2cgU3Rva2LDpmsiLCJsb2dpblR5cGUiOiJLZXlDYXJkIiwi" +
                "cGlkIjoiOTIwOC0yMDAyLTItMTE3NDQ5MDAwOTMyIiwidHlwIjoiUE9DRVMiLCJ1c2VySWQiOiI1ODMwMjEiLCJleHAiOjE2OTgxNDU2NTUsImlzcyI6IkVuZXJnaW5ldCIsInRva2VuTmFtZ" +
                "SI6IkVsRGF0YVRva2VuIiwiYXVkIjoiRW5lcmdpbmV0In0.vEP8YJMC3tu_ODAA6VTW0o637NyZQ6jIbIu8SIuo_Bs";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {refreshToken}");
            var requestResult = client.GetFromJsonAsync<TokenContainer>(URL);
            return requestResult.Result!.result;
        }

    }
}
