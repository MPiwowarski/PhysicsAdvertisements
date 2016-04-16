using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace PhysicsAdvertisements.WebForms.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("homeIndex", "Home/Index.aspx", "~/Forms/Home/Home.aspx");
            routes.MapPageRoute("homeHome", "Home/Home.aspx", "~/Forms/Home/Home.aspx");
            routes.MapPageRoute("home", "Home/", "~/Forms/Home/Home.aspx");

        }
    }
}