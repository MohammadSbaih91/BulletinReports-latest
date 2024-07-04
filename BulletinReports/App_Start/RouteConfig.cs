using System.Web.Mvc;
using System.Web.Routing;

namespace BulletinReports
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{lang}/{controller}/{action}/{id}",
                constraints: new { lang = @"ar|en" },
                defaults: new { lang = "ar", id = UrlParameter.Optional });


            //routes.MapRoute(
            //    name: "QuickOnlineAssessment",
            //    url: "{lang}/{controller}/{action}/{type}/{subType}",
            //    constraints: new { lang = @"ar|en" },
            //    defaults: new { lang = "ar", type = UrlParameter.Optional , subType = UrlParameter.Optional });


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional });
        }
    }
}
