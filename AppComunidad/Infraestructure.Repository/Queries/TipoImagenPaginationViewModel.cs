using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class TipoImagenPaginationViewModel : Pagination<TipoImagenViewModel> { }
    public class TipoImagenPaginationFilterViewModel : BasePagination { }

    public class TipoImagenViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
