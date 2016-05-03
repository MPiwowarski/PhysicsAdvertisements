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
            
            routes.MapPageRoute("homeContact", "Home/Contact.aspx", "~/Forms/Home/Contact.aspx");
            routes.MapPageRoute("Contact", "Home/Contact", "~/Forms/Home/Contact.aspx");

            routes.MapPageRoute("homeHelp", "Home/Help.aspx", "~/Forms/Home/Help.aspx");
            routes.MapPageRoute("Help", "Home/Help", "~/Forms/Home/Help.aspx");

            //*****     ACCOUNT     *****
            routes.MapPageRoute("accountRegister", "Account/Register.aspx", "~/Forms/Account/Register.aspx");
            routes.MapPageRoute("Register", "Account/Register", "~/Forms/Account/Register.aspx");

            routes.MapPageRoute("accountLogin", "Account/Login.aspx", "~/Forms/Account/Login.aspx");
            routes.MapPageRoute("Login", "Account/Login", "~/Forms/Account/Login.aspx");

            routes.MapPageRoute("accountUserData", "Account/UserData.aspx", "~/Forms/Account/UserData.aspx");
            routes.MapPageRoute("UserData", "Account/User-Data", "~/Forms/Account/UserData.aspx");

            //*****     ADVERTISEMENT     *****
            routes.MapPageRoute("advertisementCreate", "Advertisement/Create.aspx", "~/Forms/Advertisement/Create.aspx");
            routes.MapPageRoute("Create", "Advertisement/Create", "~/Forms/Advertisement/Create.aspx");

            routes.MapPageRoute("advertisementMyAdvertisements", "Advertisement/MyAdvertisements.aspx", "~/Forms/Advertisement/MyAdvertisements.aspx");
            routes.MapPageRoute("MyAdvertisements", "Advertisement/My-Advertisements", "~/Forms/Advertisement/MyAdvertisements.aspx");

            routes.MapPageRoute("advertisementSearchResult", "Advertisement/SearchResult.aspx", "~/Forms/Advertisement/SearchResult.aspx");
            routes.MapPageRoute("SearchResult", "Advertisement/Search-Result", "~/Forms/Advertisement/SearchResult.aspx");

        }
    }
}