using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class NegocioIndexModel
    {
        public IEnumerable<NegocioModel> negocios { get; set; }
        public IEnumerable<CategoriaModel> categorias { get; set; }
    }
}
