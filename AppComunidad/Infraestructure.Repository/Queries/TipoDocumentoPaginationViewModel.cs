using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Repository.Queries
{
    public class TipoDocumentoPaginationViewModel : Pagination<TipoDocumentoViewModel> { }
    public class TipoDocumentoPaginationFilterViewModel : BasePagination { }

    public class TipoDocumentoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }   
}
