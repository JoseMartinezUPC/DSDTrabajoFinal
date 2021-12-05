using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class UsuarioModel : AuditoriaModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [Display(Name = "Nombre de Aliado ó Nombre Comercial de Asociado  ")]
        [Required(ErrorMessage = "Debe ingresar el nombre.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido de Aliado ó Razon Social de Asociado ")]
        [Required(ErrorMessage = "Debe ingresar el Apellido ó Razon Social.")]
        public string Apellido { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "Debe seleccionar un Tipo de Documento.")]
        public int TipoDocumentoId { get; set; }

        [Display(Name = "Numero de Documento")]
        [Required(ErrorMessage = "Debe ingresar el Numero de documento.")]
        public string NroDocumento { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required(ErrorMessage = "Debe seleccionar un Tipo de Usuario.")]
        public int TipoUsuarioId { get; set; }

        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Longitud entre 1 y 50 caracteres.", MinimumLength = 1)]
        [RegularExpression(@"^(([a-z_\-A-Z0-9]+(\.[a-z_\-A-Z0-9]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "No debe ingresar un formato válido de correo")]
        public string Correo { get; set; }

    }
}
