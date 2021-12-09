using Domain.Entities;
using Infraestructure.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IImagenRepository : IGenericRepository<Imagen>
    {
        Task<ImagenPaginationViewModel> GetPagination(ImagenPaginationFilterViewModel filter);
        Task<ImagenPaginationViewModel> GetPaginationId(ImagenPaginationFilterViewModel filter);
    }
}
