using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class NegocioPaginationViewModel : Pagination<NegocioViewModel> { }
    public class NegocioPaginationFilterViewModel : BasePagination { }

    public class NegocioViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
