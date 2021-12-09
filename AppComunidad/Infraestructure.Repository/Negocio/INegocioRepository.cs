using Domain.Entities;
using Infraestructure.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface INegocioRepository : IGenericRepository<Negocio>
    {
        Task<NegocioPaginationViewModel> NegocioUsuarioId(NegocioPaginationFilterViewModel filter);
        Task<NegocioPaginationViewModel> NegocioCategoriasUsuarioId(NegocioPaginationFilterViewModel filter);
        Task<NegocioPaginationViewModel> NegocioRedesUsuarioId(NegocioPaginationFilterViewModel filter);
        
    }
}
