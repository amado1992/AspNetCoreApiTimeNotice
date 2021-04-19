using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApi.Models
{
    public class Traza
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string EmailUser { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string UrlNotice{ get; set; }

    }
}
