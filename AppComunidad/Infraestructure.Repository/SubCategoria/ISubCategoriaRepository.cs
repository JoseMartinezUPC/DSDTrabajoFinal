using Domain.Entities;
using Infraestructure.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface ISubCategoriaRepository : IGenericRepository<SubCategoria>
    {
        Task<SubCategoriaPaginationViewModel> GetPagination(SubCategoriaPaginationFilterViewModel filter);
    }
}
