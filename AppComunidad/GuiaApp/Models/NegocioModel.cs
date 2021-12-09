using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class NegocioModel
    {
        public string Ruta { get; set; }
        public string Nombre { get; set; }
        public string Filter { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int SubCategoriaId { get; set; }
        public IEnumerable<NegocioEstructuraModel> Redes { get; set; }
    }
}
