using PhysicsAdvertisements.WebForms.Web.Presenters.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Shared
{

    public interface ISiteView
    {

    }

    public partial class Site : System.Web.UI.MasterPage, ISiteView
    {
        private ISitePresenter _sitePresenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            //Init Presenters
            _sitePresenter = new SitePresenter(this);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOutControl_Click(object sender, EventArgs e)
        {
            _sitePresenter.LogOutControl_Click(this);          
        }
    }
}