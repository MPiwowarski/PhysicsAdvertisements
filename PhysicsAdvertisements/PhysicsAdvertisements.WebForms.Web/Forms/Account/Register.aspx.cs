﻿using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Presenters.Account;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validatable;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Account
{
    public interface IRegisterView
    {
        string PasswordControl_Text { get;  }
        string PasswordConfirmationControl_Text { get; }
        string StatusControl_Text { set; }
        System.Drawing.Color StatusControl_ForeColor { set; }

        RegisterVM RegisterVMFormData { get; }

        string LoginControl_Text { get; }

        IUserRepo UserRepo { get; set; }
    }

    public partial class Register : System.Web.UI.Page, IRegisterView
    {
        //Presenters
        private IRegisterPresenter _registerPresenter;

        //Repositories
        private IUserRepo _userRepo;

        public IUserRepo UserRepo
        {
            get { return _userRepo; }
            set { _userRepo = value; }
        }

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            //Init Presenters
            _registerPresenter = new RegisterPresenter(this);

            //Init repositories
            _registerPresenter.InitializeRepoObjects(ref _userRepo);          

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        #endregion
        

        protected void GetTypeName(object sender, EventArgs e)
        {
            DataAnnotationValidator validator = (DataAnnotationValidator)sender;
            validator.SourceTypeName = new RegisterVM().EntityType.AssemblyQualifiedName;
        }    


        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            _registerPresenter.SubmitControl_Click(this,_userRepo,RegisterVMFormData);         
        }
        

        #region **********************************   Accessors   **********************************
        public string PasswordControl_Text
        {
            get
            {
                return PasswordControl.Text;
            }
           
        }

        public string PasswordConfirmationControl_Text
        {
            get
            {
                return PasswordConfirmationControl.Text;
            }
        }

        public string StatusControl_Text
        {
            set
            {
                StatusControl.Text = value;
            }
        }

        public System.Drawing.Color StatusControl_ForeColor
        {
            set
            {
                StatusControl.ForeColor = value;
            }
        }

        public string LoginControl_Text
        {
            get
            {
                return LoginControl.Text;
            }
        }

        public RegisterVM RegisterVMFormData
        {
            get
            {
                return new RegisterVM()
                {
                    Login = LoginControl.Text,
                    Password = PasswordControl.Text,
                    PasswordConfirmation = PasswordConfirmationControl.Text,
                    Name = NameControl.Text,
                    Surname = SurnameControl.Text,
                    Birthday = Convert.ToDateTime(BirthdayControl.Text),
                    Gender = Convert.ToInt32(GenderControl.Text),
                    PhoneNumber = PhoneNumberControl.Text,
                    Email = EmailControl.Text
                };

            }
        }
        #endregion


    }
}