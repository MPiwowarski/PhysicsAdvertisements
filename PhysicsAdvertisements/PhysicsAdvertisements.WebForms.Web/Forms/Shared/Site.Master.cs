using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOutControl_Click(object sender, EventArgs e)
        {
            Session["LoggedUserId"] = null;
            Response.Redirect("/Home");
        }
    }
}