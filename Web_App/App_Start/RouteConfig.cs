using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
      name: "TCLDHome",
      url: "TCLD/{action}",
      defaults: new { controller = "TCLD", action = "Index", id = UrlParameter.Optional }
  );

            routes.MapRoute(
    name: "TCLDAction",
    url: "TCLD/{controller}/{action}",
    defaults: new { controller = "TestBriefs", action = "List", id = UrlParameter.Optional }
);

            routes.MapRoute(
                name: "KCSHome",
                url: "KCS/{action}",
                defaults: new { controller = "KCS", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "KCSAction",
                url: "KCS/{controller}/{action}",
                defaults: new { controller = "", action = "List", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Provinces",
                url: "provinces",
                defaults: new { controller = "Provinces", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
