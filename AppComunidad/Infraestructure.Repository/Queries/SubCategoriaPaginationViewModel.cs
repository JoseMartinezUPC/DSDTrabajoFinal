using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{

    public class SubCategoriaPaginationViewModel : Pagination<SubCategoriaViewModel> { }
    public class SubCategoriaPaginationFilterViewModel : BasePagination { }

    public class SubCategoriaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
