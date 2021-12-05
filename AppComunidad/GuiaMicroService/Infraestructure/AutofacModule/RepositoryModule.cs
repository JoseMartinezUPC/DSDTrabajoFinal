using Autofac;
using Infraestructure.UnitOfWork;

namespace AppComunidad.Servicios.Infraestructure.AutofacModule
{
    public class RepositoryModule : Autofac.Module
    {
        public string _queriesConnectionString { get; }
        public RepositoryModule(string queriesConnectionString) => _queriesConnectionString = queriesConnectionString;
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UnitOfWork(_queriesConnectionString)).As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
