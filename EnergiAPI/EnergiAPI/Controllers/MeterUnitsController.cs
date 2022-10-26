using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergiAPI.Data;
using EnergiAPI.Model;

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
        public async Task<ActionResult<MeterUnit>> GetMeterUnit(string id)
        {
            var root = new Root();
            root.MeteringPoints = new MeteringPoints();
            root.MeteringPoints.meteringPoint.Add(id);

            string URL = "";
            
            HttpClient client1 = new HttpClient();
            client1.DefaultRequestHeaders.Add("Authorization", "TOKEN");
            var result = await client1.PostAsJsonAsync<Root>(URL, root);

            return result.Content.ReadFromJsonAsync<MeterUnit>().Result!;
        }

    }
}
