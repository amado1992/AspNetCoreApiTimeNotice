using AspNetCoreApi.Configuracion;
using AspNetCoreApi.Models;
using AspNetCoreApi.Models.Dto.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TrazaController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly AppDbContext _context;

        public TrazaController(AppDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //[Authorize(Roles = UserRole.Admin)]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Trazas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = UserRole.Admin)]
        [HttpPost]
        public IActionResult Post(TrazaDto trazaDto)
        {
            try
            { 
                //string userId = User.Claims.First(c => c.Type == "UserID").Value;

                //var user = await _userManager.FindByIdAsync(userId);
                trazaDto.Fecha = DateTime.Now;
                //trazaDto.EmailUser = user.Email;

                var traza = new Traza {
                EmailUser = trazaDto.EmailUser,
                Fecha = trazaDto.Fecha,
                UrlNotice = trazaDto.UrlNotice
                };
                _context.Trazas.Add(traza);
                _context.SaveChanges();

                return Ok(trazaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
