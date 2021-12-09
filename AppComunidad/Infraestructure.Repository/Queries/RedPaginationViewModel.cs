using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class RedPaginationViewModel : Pagination<RedViewModel> { }
    public class RedPaginationFilterViewModel : BasePagination
    {
        public int Id { get; set; }
    }

    public class RedViewModel
    {
        public int Id { get; set; }
        public int TipoRedId { get; set; }
        public string TipoRed { get; set; }
        public string Recurso { get; set; }
        public int UsuarioId { get; set; }
    }
}
