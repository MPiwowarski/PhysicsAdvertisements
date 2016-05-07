using PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Advertisement
{

    public interface ISearchResultView
    {
        string StatusControl_Text { set; }
        System.Drawing.Color StatusControl_ForeColor { set; }
        object MyAdvertisementsGridViewControl_DataSourceWithDataBind { set; }
    }

    public partial class SearchResult : System.Web.UI.Page, ISearchResultView
    {
        private ISearchResultPresenter _searchResultPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _searchResultPresenter = new SearchResultPresenter(this);
            _searchResultPresenter.PutDataToSearchResultGridViewControl(this);
        }



        #region **********************************   Accessors   **********************************
        public object MyAdvertisementsGridViewControl_DataSourceWithDataBind
        {
            set
            {
                SearchResultGridViewControl.DataSource = value;
                SearchResultGridViewControl.DataBind();
            }
        }

        public string StatusControl_Text
        {
            set
            {
                StatusControl.Text = value;
            }
        }

        public Color StatusControl_ForeColor
        {
            set
            {
                StatusControl.ForeColor = value;
            }
        }
        #endregion

    }
}