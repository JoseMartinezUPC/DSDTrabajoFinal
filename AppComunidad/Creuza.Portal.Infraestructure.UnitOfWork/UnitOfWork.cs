using Infraestructure.Repository;

namespace Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMenuRepository MenuRepository { get; private set; }
       
        public UnitOfWork(string connectionString)
        {
            MenuRepository = new MenuRepository(connectionString);           
        }
    }
}
