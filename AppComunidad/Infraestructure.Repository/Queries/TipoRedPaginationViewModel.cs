using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class TipoRedPaginationViewModel : Pagination<TipoRedViewModel> { }
    public class TipoRedPaginationFilterViewModel : BasePagination { }

    public class TipoRedViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
