using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class LoginModel
    {
        [Display(Name = "Usuario ")]
        [Required(ErrorMessage = "Debe un Usuario.")]
        public string usuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Debe ingresar el Password.")]
        public string password { get; set; }
    }
}
