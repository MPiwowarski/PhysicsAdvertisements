using Microsoft.Practices.ServiceLocation;
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
        void InitializeObjects(ref IUserRepo userRepo);

        void SubmitControl_Click(System.Web.UI.Page page, IUserRepo userRepo, string login, string password);

        int? CheckIfUserWithGivenLoginAndPasswordExistsInDb(IUserRepo _userRepo, string login, string password);
        void ClearForm();
    }


    public class LoginPresenter : ILoginPresenter
    {
        private ILoginView _loginView;

        public LoginPresenter(ILoginView loginView)
        {
            this._loginView = loginView;
        }

        public int? CheckIfUserWithGivenLoginAndPasswordExistsInDb(IUserRepo userRepo, string login, string password)
        {
            
            int? id= userRepo.Context.User.Where(x => x.Login.Equals(login) && x.Password.Equals(password)).Select(x => x.Id).FirstOrDefault();
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


        public void SubmitControl_Click(System.Web.UI.Page page, IUserRepo userRepo, string login, string password)
        {
            page.Session["LoggedUserId"] = CheckIfUserWithGivenLoginAndPasswordExistsInDb(userRepo, login, password);

            if (page.Session["LoggedUserId"] != null)
            {
                _loginView.StatusControl_ForeColor = System.Drawing.Color.Green;
                _loginView.StatusControl_Text = "Logged successfully";
                page.Response.Redirect("/Account/User-Data");
            }
            else
            {
                ClearForm();
                _loginView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _loginView.StatusControl_Text = "Wrong login or password";
            }
        }


        public void InitializeObjects(ref IUserRepo userRepo)
        {
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
        }
    }
}