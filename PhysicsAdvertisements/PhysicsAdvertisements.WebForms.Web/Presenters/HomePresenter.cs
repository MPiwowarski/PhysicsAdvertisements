using PhysicsAdvertisements.WebForms.Web.Forms.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters
{
    public interface IHomePresenter
    {
        bool SendFeedback_Click();
    }

    public class HomePresenter : IHomePresenter
    {
        private IHomeView _homeView;

        public HomePresenter(IHomeView homeView)
        {
            this._homeView = homeView;
        }

        public bool SendFeedback_Click()
        {
            //wiadomosc wyslano pomyslnie
            return true;
        }
    }
}