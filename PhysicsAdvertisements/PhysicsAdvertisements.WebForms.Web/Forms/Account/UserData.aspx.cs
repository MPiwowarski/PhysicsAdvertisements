using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Account
{
    public partial class UserData : System.Web.UI.Page
    {

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["LoggedUserId"] == null)
            {
                Response.Redirect("/Home");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion
       
    }
}