using Autofac;
using Autofac.Integration.WebApi;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
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

            var asd = BuildManager.GetReferencedAssemblies().Cast<Assembly>();            

            //Configures ADO data access and repositories dependencies
            ConfigureADODependencies();

            //var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            //foreach (var assembly in assemblies)
            //{
            //    //TODO: filter assemblies
            //    builder.RegisterAssemblyTypes(assembly);
            //}

            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Configures ADO data access and repositories dependencies
        /// </summary>
        protected void ConfigureADODependencies()
        {
            var sd = asd.First(x => x.FullName.Contains("Persistence.ADO"));

            builder.RegisterAssemblyTypes(sd)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();

            builder.RegisterType(typeof(Common.Persistence.ADO.Storage))
                .WithParameter(new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings["default"].ToString()));
        }
    }
}
