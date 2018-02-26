using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Evolent.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("Contact", "v1/contacts/{id}", new { controller = "contacts", id = RouteParameter.Optional });

        }
    }
}
