using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class CategoriaModel
    {
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public bool CategoriaEstado { get; set; }

        public string CategoriaFilter { get; set; }
    }
}
