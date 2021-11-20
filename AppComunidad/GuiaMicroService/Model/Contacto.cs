using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaMicroService.Model
{
    public class Contacto
    {
        [Key]
        public int ContactoId { get; set; }
        public string ContactoInfo { get; set; }
        public int TipoContactoId { get; set; }
        public int BienId { get; set; }

    }
}
