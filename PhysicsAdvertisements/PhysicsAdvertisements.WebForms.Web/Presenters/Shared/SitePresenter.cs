using PhysicsAdvertisements.WebForms.Web.Forms.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Shared
{
    public interface ISitePresenter
    {
        void LogOutControl_Click(System.Web.UI.MasterPage page);
    }

    public class SitePresenter:ISitePresenter
    {
        private ISiteView _siteView;

        public SitePresenter(ISiteView siteView)
        {
            this._siteView = siteView;
        }

        public void LogOutControl_Click(System.Web.UI.MasterPage page)
        {
            page.Session["LoggedUserId"] = null;
            page.Response.Redirect("/Home");
        }

    }
}