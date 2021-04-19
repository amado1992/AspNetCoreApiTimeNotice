using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TiempoController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetTiempos()
        {
            try
            {
                var url = "https://api.openweathermap.org/data/2.5/forecast?" +
            "q=Texas&" +
            "appid=0fe37288c0b970e6f9e2d99c2a256367";

                var json = new WebClient().DownloadString(url);
                var tiempos = JsonConvert.DeserializeObject(json);
                return Ok(tiempos.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
