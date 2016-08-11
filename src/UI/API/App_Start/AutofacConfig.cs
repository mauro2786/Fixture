using Autofac;
using Autofac.Integration.WebApi;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

namespace API
{
    public class AutofacConfig
    {
        private const string PersistenceObjectPostfix = "Repository";
        private const string ServiceObjectPostfix = "Service";
        private const string DefaultConnectionString = "default";

        private static ContainerBuilder builder;

        public static void Register(HttpConfiguration config)
        {
            builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            //Configures Ado data access and repositories dependencies
            //ConfigureAdoDependencies(assemblies);

            //Configures Ado data access and repositories dependencies
            ConfigureEntityDependencies(assemblies);

            //Configures Services dependencies
            ConfigureServicesDependencies(assemblies);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Configures Services dependencies
        /// </summary>
        private static void ConfigureServicesDependencies(IEnumerable<Assembly> assemblies)
        {
            const string ServicesImplAssemblyName = "Fixture.ServicesImpl";

            var servicesImplAssembly = assemblies.First(x => x.FullName.Contains(ServicesImplAssemblyName));

            builder.RegisterAssemblyTypes(servicesImplAssembly)
                .Where(t => t.Name.EndsWith(ServiceObjectPostfix))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Configures Ado data access and repositories dependencies
        /// </summary>
        private static void ConfigureAdoDependencies(IEnumerable<Assembly> assemblies)
        {
            const string AdoPersistenceAssemblyName = "Fixture.Persistence.Ado";

            var persistenceAssembly = assemblies.First(x => x.FullName.Contains(AdoPersistenceAssemblyName));

            builder.RegisterAssemblyTypes(persistenceAssembly)
               .Where(t => t.Name.EndsWith(PersistenceObjectPostfix))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            builder.RegisterType(typeof(Common.Persistence.Ado.Storage))
                .WithParameter(new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings[DefaultConnectionString].ToString()));
        }

        /// <summary>
        /// Configures Entity Framework data access and repositories dependencies
        /// </summary>
        private static void ConfigureEntityDependencies(IEnumerable<Assembly> assemblies)
        {
            const string EntityPersistenceAssemblyName = "Fixture.Persistence.Entity";

            var persistenceAssembly = assemblies.First(x => x.FullName.Contains(EntityPersistenceAssemblyName));

            builder.RegisterAssemblyTypes(persistenceAssembly)
               .Where(t => t.Name.EndsWith(PersistenceObjectPostfix))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            builder.RegisterType(typeof(Fixture.Persistence.Entity.Context))
                .As<DbContext>()
                .WithParameter(new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings[DefaultConnectionString].ToString()))
                .InstancePerRequest();
        }
    }
}