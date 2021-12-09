using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class TipoImagenModel
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de Imagen")]
        public string Descripcion { get; set; }
    }
}
