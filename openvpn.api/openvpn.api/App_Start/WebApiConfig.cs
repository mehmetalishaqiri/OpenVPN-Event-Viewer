using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using openvpn.api.core.formatters;
using openvpn.api.core.handlers;

namespace openvpn.api
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //config.Routes.MapHttpRoute(
            //    name: "UserOpenVpnEvents",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { controller = "events", action = "GetUserEvents", id = RouteParameter.Optional }
            //);

            // make sure browsers get JSON without compromising content negotiation from clients that actually want XML.
            config.Formatters.Add(new BrowserJsonFormatter());

            config.MessageHandlers.Add(new WrappingHandler());
        }
    }
}
