using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infraestructure.Repository.Queries;

namespace Infraestructure.Repository
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<MenuPaginationViewModel> GetPagination(MenuPaginationFilterViewModel filter);
    }
}
