using System.Reflection;
using Autofac;
using ifsc.tcc.Portal.Application;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using ifsc.tcc.Portal.Infra.Data.EF.Repositories;
using ifsc.tcc.Portal.Infra.Data.EF.UnitOfWork;
using Nest;
using Module = Autofac.Module;

namespace ifsc.tcc.Portal.Api.DependencyResolution
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var appServices = Assembly.GetAssembly(typeof(BaseAppService<>));
            var repositoriesInterfaces = Assembly.GetAssembly(typeof(IAddRepository<>));
            var repositoriesImplementations = Assembly.GetAssembly(typeof(GenericRepository<>));

            builder.RegisterType<UnitOfWork>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterType<ElasticClient>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterType<IFSCContext>()
                    .AsSelf()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(appServices, repositoriesInterfaces, repositoriesImplementations)
                   .Where(t => t.Name.EndsWith("AppService") || t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
