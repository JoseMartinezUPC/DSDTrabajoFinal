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

    }
}
