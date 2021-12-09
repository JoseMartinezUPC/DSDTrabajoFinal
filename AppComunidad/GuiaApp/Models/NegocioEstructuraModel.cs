using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class NegocioEstructuraModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string SubCategoria { get; set; }
        public int TipoRedId { get; set; }
        public string Red { get; set; }
        public string Icon { get; set; }
        public string Recurso { get; set; }
        public string Categoria { get; set; }
        public string Ruta { get; set; }

    }

    public class NegocioFilter : BasePagination
    {
        public int UsuarioId { get; set; }
    }
    public class NegocioPagination : Pagination<NegocioEstructuraModel>
    {
    }
}
