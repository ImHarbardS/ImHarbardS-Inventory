using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Logout",
                url: "Home/Logout",
                new { controller = "Home", action = "Logout"}
            );
            routes.MapRoute(
                name: "EmployeeItems",
                url: "Employee/Index/{id}",
                new { controller = "Employee", action = "Index", Id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ManagerItems",
                url: "Manager/Index/{id}",
                new { controller = "Manager", action = "Index", Id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditEmployeeItems",
                url: "Employee/SaveItems/{id}",
                new { controller = "Employee", action = "SaveItems", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditItems",
                url: "Manager/SaveItems/{id}",
                new { controller = "Manager", action = "SaveItems", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Login"}
            );
        }
    }
}
