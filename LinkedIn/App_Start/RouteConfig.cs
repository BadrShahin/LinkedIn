using LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LinkedIn
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            LinkedInDBContext Context = new LinkedInDBContext();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //if (Context.Members.FirstOrDefault(x=>x.email_address != "badr@gmail.com") != null)
            //{
            //    routes.Ignore("Admin/index");
            //}
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "welcome", id = UrlParameter.Optional }
            );
        }
    }
}
