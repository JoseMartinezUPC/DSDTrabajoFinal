
using Infraestructure.Repository;

namespace Infraestructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMenuRepository MenuRepository { get; }
        ITipoDocumentoRepository TipoDocumentoRepository { get; }
        ITipoUsuarioRepository TipoUsuarioRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        ITipoImagenRepository TipoImagenRepository { get; }
        IImagenRepository ImagenRepository { get; }
        ITipoRedRepository TipoRedRepository { get;}
        IRedRepository RedRepository { get; }
    }
}
