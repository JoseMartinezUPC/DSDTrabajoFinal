using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaMicroService.Model
{
    public class TipoContacto
    {
        [Key]
        public int TipoContactoId { get; set; }
        public string TipoContactoNombre { get; set; }
        public bool TipoContactoEstado { get; set; }

    }
}
