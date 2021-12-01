using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(int id);
        
        Task<int> Add(T entity);

        Task<int> AddDefaultAsync(T entity);

        Task<bool> Update(T entity);

        Task<bool> UpdateDefaultAsync(T entity);

        Task<bool> Delete(T entity);

    }
}
