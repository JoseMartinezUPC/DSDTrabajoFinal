using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaMicroService.Model
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public bool CategoriaEstado { get; set; }

    }
}
