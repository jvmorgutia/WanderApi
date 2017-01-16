using System.Web.Http;

namespace jvmorgutia.Wander.WebApi
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
                routeTemplate: "WanderApi/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
