using PhysicsAdvertisements.WebForms.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PhysicsAdvertisements.WebForms.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            UnityWebFormsBootstrapper.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}