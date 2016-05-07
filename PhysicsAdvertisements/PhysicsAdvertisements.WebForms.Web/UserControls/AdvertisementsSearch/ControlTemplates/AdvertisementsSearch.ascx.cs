using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.ControlTemplates
{
    public partial class AdvertisementsSearch : System.Web.UI.UserControl, IAdvertisementsSearchView
    {
        public AdvertisementsSearch()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (SearchBtn_Click_Event != null)
            {
                SearchBtn_Click_Event(sender, e);
            }

            //Response.Redirect("~/Advertisement/Search-Result");
        }


        #region **********************************   Accessors   **********************************
        public string PhysicAreaName_Text
        {
            get
            {
                return PhysicsAreaControl.Text;
            }
            set
            {
                PhysicsAreaControl.Text = value;
            }
        }

        public string CategoryName_Text
        {
            get
            {
                return CategoryControl.Text;
            }
            set
            {
                CategoryControl.Text = value;
            }
        }
        #endregion

        public event EventHandler SearchBtn_Click_Event;
    }
}