using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class TipoUsuarioPaginationViewModel : Pagination<TipoUsuarioViewModel> { }
    public class TipoUsuarioPaginationFilterViewModel : BasePagination { }

    public class TipoUsuarioViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
