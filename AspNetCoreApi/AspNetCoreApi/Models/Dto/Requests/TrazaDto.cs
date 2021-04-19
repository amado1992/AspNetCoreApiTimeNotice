using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApi.Models.Dto.Requests
{
    public class TrazaDto
    {
        public string EmailUser { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string UrlNotice { get; set; }
    }
}
