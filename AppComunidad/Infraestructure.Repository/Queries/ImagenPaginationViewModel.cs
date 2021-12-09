using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class ImagenPaginationViewModel : Pagination<ImagenViewModel> { }
    public class ImagenPaginationFilterViewModel : BasePagination {
        public int Id { get; set; }
    }

    public class ImagenViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int TipoImagenId { get; set; }
        public string TipoImagen { get; set; }
        public string Extension { get; set; }
        public int UsuarioId { get; set; }
    }
}
