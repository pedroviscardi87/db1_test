using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DB1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Exercício 2
            routes.MapRoute(
                name: "Exercise2",
                url: "exercicio2",
                defaults: new { controller = "Home", action = "Exercise2", id = UrlParameter.Optional });

            //Exercício 3
            routes.MapRoute(
                name: "Exercise3",
                url: "exercicio3",
                defaults: new { controller = "Home", action = "Exercise3", id = UrlParameter.Optional });

            //Home
            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
