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
    public class NoticiaController : ControllerBase
    {

        // GET: api/<NoticiaController>
        [HttpGet]
        public ActionResult GetNoticias()
        {
            try
            {
                var url = "https://newsapi.org/v2/everything?" +
            "q=Texas&" +
            "apiKey=31902a41859b4c528bf5540aedd6dd9d";

            var json = new WebClient().DownloadString(url);
                var noticias = JsonConvert.DeserializeObject(json);
                return Ok(noticias.ToString());
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
