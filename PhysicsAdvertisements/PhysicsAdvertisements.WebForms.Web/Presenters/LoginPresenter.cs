using PhysicsAdvertisements.WebForms.Web.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters
{
    public interface ILoginPresenter
    {
        bool LoginControl_Click();
    }


    public class LoginPresenter: ILoginPresenter
    {
        private ILoginView _homeView;

        public LoginPresenter(ILoginView homeView)
        {
            this._homeView = homeView;
        }

        public bool LoginControl_Click()
        {
            //Log in successfully

            return true;
        }
    }
}