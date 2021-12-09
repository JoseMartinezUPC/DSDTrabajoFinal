﻿using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Queries
{
    public class NegocioPaginationViewModel : Pagination<NegocioViewModel> { }
    public class NegocioPaginationFilterViewModel : BasePagination {
        public int UsuarioId { get; set; }
    }

    public class NegocioViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string SubCategoria { get; set; }
        public int TipoRedId { get; set; }
        public string Red { get; set; }
        public string Icon { get; set; }
        public string Recurso { get; set; }
        public string Categoria { get; set; }
        public string Ruta { get; set; }




    }
}
