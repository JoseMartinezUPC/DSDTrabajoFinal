
using Infraestructure.Repository;

namespace Infraestructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMenuRepository MenuRepository { get; }
        ITipoDocumentoRepository TipoDocumentoRepository { get; }
        ITipoUsuarioRepository TipoUsuarioRepository { get; }
    }
}
