﻿using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
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
    public interface ILoginView
    {
        string LoginControl_Text { get; set; }
        string PasswordControl_Text { get; set; }
        string StatusControl_Text { set; }
        System.Drawing.Color StatusControl_ForeColor { set; }

        IUserRepo UserRepo { get; set; }
        bool IsPageValid { get; set; }
    }

    public partial class Login : System.Web.UI.Page, ILoginView
    {
        private ILoginPresenter _loginPresenter;

        //Repositories
        private IUserRepo _userRepo;

        private bool _isPageValid;

        public bool IsPageValid
        {
            get { return this.IsValid; }
            set { _isPageValid = value; }
        }
        

        public IUserRepo UserRepo
        {
            get { return _userRepo; }
            set { _userRepo = value; }
        }


        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            //Init Presenters
            _loginPresenter = new LoginPresenter(this);

            //Init Objects
            _loginPresenter.InitializeObjects(ref _userRepo);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        #endregion
        protected void GetTypeName(object sender, EventArgs e)
        {
            DataAnnotationValidator validator = (DataAnnotationValidator)sender;
            validator.SourceTypeName = new LoginVM().EntityType.AssemblyQualifiedName;
        }

        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            _loginPresenter.SubmitControl_Click(this, LoginControl_Text, PasswordControl_Text);
        }


        #region **********************************   Accessors   **********************************
        public string LoginControl_Text
        {
            get
            {
                return LoginControl.Text;
            }
            set
            {
                LoginControl.Text = value;
            }
              
        }

        public string PasswordControl_Text
        {
            get
            {
                return PasswordControl.Text;
            }
            set
            {
                PasswordControl.Text = value;
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
        #endregion

       
    }
}