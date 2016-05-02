using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Global
{
    public interface ILoggedUserPresenter
    {
  
    }

    public class LoggedUserPresenter : ILoggedUserPresenter
    {
        public static void CheckIsUserLooged(System.Web.UI.Page page)
        {
            if (page.Session["LoggedUserId"] == null)
            {
                page.Response.Redirect("/Home");
            }
        }

        
    }
}