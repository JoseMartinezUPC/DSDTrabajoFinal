using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class TipoUsuarioModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Usuario")]
        public string Descripcion { get; set; }
    }
}
