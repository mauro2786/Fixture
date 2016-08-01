using Autofac;
using Autofac.Integration.WebApi;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

namespace API
{
    public class AutofacConfig
    {
        private const string PersistenceObjectPostFix = "Repository";
        private const string ServiceObjectPostFix = "Service";
        private const string DefaultConnectionString = "default";

        private static ContainerBuilder builder;

        public static void Register(HttpConfiguration config)
        {
            builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            //Configures Ado data access and repositories dependencies
            ConfigureAdoDependencies(assemblies);

            //Configures Services dependencies
            ConfigureServicesDependencies(assemblies);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Configures Ado data access and repositories dependencies
        /// </summary>
        private static void ConfigureAdoDependencies(IEnumerable<Assembly> assemblies)
        {
            const string AdoPersistenceAssemblyName = "Fixture.Persistence.Ado";

            var persistenceAssembly = assemblies.First(x => x.FullName.Contains(AdoPersistenceAssemblyName));

            builder.RegisterAssemblyTypes(persistenceAssembly)
               .Where(t => t.Name.EndsWith(PersistenceObjectPostFix))
               .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            builder.RegisterType(typeof(Common.Persistence.Ado.Storage))
                .WithParameter(new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings[DefaultConnectionString].ToString()));
        }

        /// <summary>
        /// Configures Services dependencies
        /// </summary>
        private static void ConfigureServicesDependencies(IEnumerable<Assembly> assemblies)
        {
            const string ServicesImplAssemblyName = "Fixture.ServicesImpl";

            var servicesImplAssembly = assemblies.First(x => x.FullName.Contains(ServicesImplAssemblyName));

            builder.RegisterAssemblyTypes(servicesImplAssembly)
                .Where(t => t.Name.EndsWith(ServiceObjectPostFix))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}