using Evolent.Service.Infrastructure;
using System.Web.Http;
using Unity;

namespace Evolent.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            BootStrapper.Execute(container);
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Contact", "v1/contacts/{id}", new { controller = "contacts", id = RouteParameter.Optional });
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
