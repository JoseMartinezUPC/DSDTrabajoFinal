using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaMicroService.Model
{
    public class Bien
    {
        [Key]
        public int BienId { get; set; }
        public string BienNombre { get; set; }
        public bool BienEstado { get; set; }
        public int SubCategoriaId { get; set; }
    }
}
