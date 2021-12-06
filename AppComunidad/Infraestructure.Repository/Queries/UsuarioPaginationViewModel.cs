using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class UsuarioPaginationViewModel : Pagination<UsuarioViewModel> { }
    public class UsuarioPaginationFilterViewModel : BasePagination {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }   
        public bool Acceso { get; set; }
    }
}
