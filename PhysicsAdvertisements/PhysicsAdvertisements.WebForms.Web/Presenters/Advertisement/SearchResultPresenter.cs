using PhysicsAdvertisements.WebForms.Web.Data.Advertisement;
using PhysicsAdvertisements.WebForms.Web.Forms.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement
{
    public interface ISearchResultPresenter
    {
        void PutDataToSearchResultGridViewControl(System.Web.UI.Page page);
    }

    public class SearchResultPresenter:ISearchResultPresenter
    {
        private ISearchResultView _searchResultView;

        public SearchResultPresenter(ISearchResultView searchResultView)
        {
            this._searchResultView = searchResultView;
        }

        public void PutDataToSearchResultGridViewControl(System.Web.UI.Page page)
        {
            if(page.Session["AdvertisementsSearchResultData"] == null)
            {
                _searchResultView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _searchResultView.StatusControl_Text = "No advertisements was found";
            }
            else
            {
                List<MyAdvertisementsData> result = (List<MyAdvertisementsData>)page.Session["AdvertisementsSearchResultData"];
                _searchResultView.MyAdvertisementsGridViewControl_DataSourceWithDataBind = result;
                _searchResultView.StatusControl_ForeColor = System.Drawing.Color.Green;
                _searchResultView.StatusControl_Text = result.Count+" advertisements was found:";
            }
        }

    }
}