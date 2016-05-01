using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Account
{
    public interface ILoginPresenter
    {
        int? LoginControl_Click(IUserRepo _userRepo, string login, string password);
        void ClearForm();
    }


    public class LoginPresenter : ILoginPresenter
    {
        private ILoginView _loginView;

        public LoginPresenter(ILoginView loginView)
        {
            this._loginView = loginView;
        }

        public int? LoginControl_Click(IUserRepo _userRepo, string login, string password)
        {
            
            int? id= _userRepo.Context.User.Where(x => x.Login.Equals(login) && x.Password.Equals(password)).Select(x => x.Id).FirstOrDefault();
            if (id != 0)
                return id;
            else
                return null;    
        }

        public void ClearForm()
        {
            _loginView.LoginControl_Text = "";
            _loginView.PasswordControl_Text = "";
        }
    }
}