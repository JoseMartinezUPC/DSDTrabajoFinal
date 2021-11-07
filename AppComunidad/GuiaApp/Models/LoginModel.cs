using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class LoginModel
    {
        [Required]
        public string usuario { get; set; }

        [Required]
        public string password { get; set; }
    }
}
