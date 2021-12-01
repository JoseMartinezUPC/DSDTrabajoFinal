using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class MenuPaginationViewModel : Pagination<MenuViewModel> { }
    public class MenuPaginationFilterViewModel : BasePagination { }

    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
