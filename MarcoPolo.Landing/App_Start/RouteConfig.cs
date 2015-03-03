using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarcoPolo.Landing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "sign",
                url: "signup",
                defaults: new { controller = "Home", action = "SignUp", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "terms",
              url: "terms",
              defaults: new { controller = "Home", action = "Terms", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}