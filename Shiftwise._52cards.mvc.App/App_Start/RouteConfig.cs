using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shiftwise._52cards.mvc.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                 url: "{controller}/{action}/{id}",
               defaults: new { controller = "_52Card", action = "_52Card", id = UrlParameter.Optional }
            );
        }
    }
}
