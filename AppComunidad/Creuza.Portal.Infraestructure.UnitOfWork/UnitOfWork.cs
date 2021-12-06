using Infraestructure.Repository;

namespace Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMenuRepository MenuRepository { get; private set; }
        public ITipoDocumentoRepository TipoDocumentoRepository { get; private set; }

        public ITipoUsuarioRepository TipoUsuarioRepository { get; private set; }
        public IUsuarioRepository UsuarioRepository { get; private set; }
        public ICategoriaRepository CategoriaRepository { get; }

        public UnitOfWork(string connectionString)
        {
            MenuRepository = new MenuRepository(connectionString);
            TipoDocumentoRepository = new TipoDocumentoRepository(connectionString);
            TipoUsuarioRepository = new TipoUsuarioRepository(connectionString);
            UsuarioRepository = new UsuarioRepository(connectionString);
            CategoriaRepository = new CategoriaRepository(connectionString);
        }
    }
}
