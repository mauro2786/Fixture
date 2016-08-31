using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                name: "GetApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DeletePutApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete, HttpMethod.Put) }
            );

            ConfigureSerializer(config);
        }

        private static void ConfigureSerializer(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        }
    }
}
