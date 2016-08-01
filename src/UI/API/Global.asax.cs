using Autofac;
using Autofac.Integration.WebApi;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Collections.Generic;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private const string PersistenceObjectPostFix = "Repository";
        private const string ServiceObjectPostFix = "Service";
        private const string DefaultConnectionString = "default";

        private ContainerBuilder builder;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureAutofac();
        }

        protected void ConfigureAutofac()
        {
            builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            //Configures ADO data access and repositories dependencies
            ConfigureADODependencies(assemblies);

            //Configures Services dependencies
            ConfigureServicesDependencies(assemblies);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Configures ADO data access and repositories dependencies
        /// </summary>
        private void ConfigureADODependencies(IEnumerable<Assembly> assemblies)
        {
            const string ADOPersistenceAssemblyName = "Fixture.Persistence.ADO";

            var persistenceAssembly = assemblies.First(x => x.FullName.Contains(ADOPersistenceAssemblyName));

            builder.RegisterAssemblyTypes(persistenceAssembly)
               .Where(t => t.Name.EndsWith(PersistenceObjectPostFix))
               .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            builder.RegisterType(typeof(Common.Persistence.ADO.Storage))
                .WithParameter(new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings[DefaultConnectionString].ToString()));
        }

        /// <summary>
        /// Configures Services dependencies
        /// </summary>
        private void ConfigureServicesDependencies(IEnumerable<Assembly> assemblies)
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
