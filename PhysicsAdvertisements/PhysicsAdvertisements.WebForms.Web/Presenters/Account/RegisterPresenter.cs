using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Model.Utils;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Forms.Account;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Validatable;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Account
{
    public interface IRegisterPresenter
    {
        void InitializeRepoObjects(ref IUserRepo userRepo);

        void SubmitControl_Click(System.Web.UI.Page page, IUserRepo userRepo, RegisterVM registerVMFormData);

        bool CheckIsPasswordsAndPasswordConfirmationAreTheSame();
        bool CheckIsLoginFree(IUserRepo userRepo);

        void Register(IUserRepo userRepo, RegisterVM data);
    }

    public class RegisterPresenter:IRegisterPresenter
    {
        private IRegisterView _registerView;

        public RegisterPresenter(IRegisterView registerView)
        {
            this._registerView = registerView;
        }

        public bool CheckIsPasswordsAndPasswordConfirmationAreTheSame()
        {
            if (_registerView.PasswordControl_Text.Equals(_registerView.PasswordConfirmationControl_Text))
            {
                return true;
            }
            else
            {
                _registerView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _registerView.StatusControl_Text = "Password confirmation is not the same as password";
                return false;
            }
        }

        public void Register(IUserRepo userRepo, RegisterVM data)
        {
            try
            {
                User user = new User();
                user.Password = (new HashingContext()).EncryptPhrase(user.Password);
                user = Mapper.Map<User>(data);
                userRepo.Insert(user);
                userRepo.Save();
                     
                _registerView.StatusControl_ForeColor = System.Drawing.Color.Green;
                _registerView.StatusControl_Text = "Registration passed successfully";
                
            }
            catch (Exception e)
            {
                //logger implementation
            }
            
        }

        public void InitializeRepoObjects(ref IUserRepo userRepo)
        {
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
        }

        //TODO: Check if Login is occupied by someone
        public void SubmitControl_Click(System.Web.UI.Page page, IUserRepo userRepo, RegisterVM registerVMFormData)
        {
            if (page.IsValid)
            {
                if (CheckIsPasswordsAndPasswordConfirmationAreTheSame() && CheckIsLoginFree(userRepo))
                {
                    Register(userRepo, registerVMFormData);
                    page.Response.AddHeader("REFRESH", "1;URL=/Account/Login");
                }

            }
        }


        public bool CheckIsLoginFree(IUserRepo userRepo)
        {
            if (userRepo.Table.Where(x => x.Login == _registerView.LoginControl_Text).FirstOrDefault() == null)
            {
                return true;
            }
            else
            {
                _registerView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _registerView.StatusControl_Text = "Given login is already occupied. Choose another.";
                return false;
            }
        }
    }
}