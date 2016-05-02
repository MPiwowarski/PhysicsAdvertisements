using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Forms.Account;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Account
{
    public interface IUserDataPresenter
    {
        void InitializeObjects(ref IUserRepo userRepo);
        void SubmitControl_Click(System.Web.UI.Page page, IUserRepo userRepo, UserDataVM userDataVMFormData);
        bool CheckIsPasswordsAndPasswordConfirmationAreTheSame();
        void FillFormFieldsWithUserData(IUserRepo userRepo, int loggedUserId);
        void EditUserData(IUserRepo userRepo, UserDataVM data, int loggedUserId);
    }

    public class UserDataPresenter: IUserDataPresenter
    {
        private IUserDataView _userDataView;

        public UserDataPresenter(IUserDataView userDataView)
        {
            this._userDataView = userDataView;
        }

        public bool CheckIsPasswordsAndPasswordConfirmationAreTheSame()
        {
            if (_userDataView.PasswordControl_Text.Equals(_userDataView.PasswordConfirmationControl_Text))
            {
                return true;
            }
            else
            {
                _userDataView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _userDataView.StatusControl_Text = "Password confirmation is not the same as password";
                return false;
            }
        }


        public void EditUserData(IUserRepo userRepo, UserDataVM data,int loggedUserId)
        {
            try
            {
                User user = userRepo.GetById(loggedUserId);
                user = Mapper.Map<User>(data);
                userRepo.Save();


                _userDataView.StatusControl_ForeColor = System.Drawing.Color.Green;
                _userDataView.StatusControl_Text = "Changes saved successfully";

            }
            catch (Exception e)
            {
                //logger implementation
            }
        }

        public void FillFormFieldsWithUserData(IUserRepo userRepo, int loggedUserId)
        {
            User user = userRepo.GetById(loggedUserId);

            _userDataView.LoginControl_Text = user.Login;
            _userDataView.NameControl_Text = user.Name;
            _userDataView.SurnameControl_Text = user.Surname;
            _userDataView.BirthdayControl_Text = user.Birthday;
            _userDataView.GenderControl_Text = (User.GenderEnum)user.Gender;
            _userDataView.PhoneNumberControl_Text = user.PhoneNumber;
            _userDataView.EmailControl_Text = user.Email;

        }

        public void InitializeObjects(ref IUserRepo userRepo)
        {
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
        }

        public void SubmitControl_Click(System.Web.UI.Page page, IUserRepo userRepo, UserDataVM userDataVMFormData)
        {
            if (page.IsValid)
            {
                if (CheckIsPasswordsAndPasswordConfirmationAreTheSame())
                {
                    EditUserData(userRepo, userDataVMFormData, (int)page.Session["LoggedUserId"]);
                }

            }
        }
    }
}