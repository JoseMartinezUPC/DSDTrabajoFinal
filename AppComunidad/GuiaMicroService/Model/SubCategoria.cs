using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaMicroService.Model
{
    public class SubCategoria
    {
        [Key]
        public int SubCategoriaId { get; set; }
        public string SubCategoriaNombre { get; set; }
        public bool SubCategoriaEstado { get; set; }
        public int CategoriaId{ get; set; }

    }
}
