
using Infraestructure.Repository;

namespace Infraestructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMenuRepository MenuRepository { get; }
    }
}
