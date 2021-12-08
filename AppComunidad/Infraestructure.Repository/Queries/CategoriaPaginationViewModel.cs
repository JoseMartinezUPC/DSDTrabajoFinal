using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class CategoriaPaginationViewModel : Pagination<CategoriaViewModel> { }
    public class CategoriaPaginationFilterViewModel : BasePagination { }

    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
