using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters
{
    public interface IAdvertisementsSearchPresenter
    {
        void SearchBtn_Click();
    }

    public class AdvertisementsSearchPresenter
    {
        protected IAdvertisementsSearchView _advertisementsSearchView;

        public AdvertisementsSearchPresenter(IAdvertisementsSearchView advertisementsSearchView)
        {
            this._advertisementsSearchView = advertisementsSearchView;
        }

        public void SearchBtn_Click()
        {
            


        }
    }
}