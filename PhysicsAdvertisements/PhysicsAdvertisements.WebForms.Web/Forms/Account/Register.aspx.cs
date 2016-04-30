using Microsoft.Practices.ServiceLocation;
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
        string StatusControl_Text { get; set; }
        System.Drawing.Color StatusControl_ForeColor { set; }

        RegisterVM RegisterVMFormData { get;}
    }

    public partial class Register : System.Web.UI.Page, IRegisterView
    {
        //Presenters
        private IRegisterPresenter _registerPresenter;

        //Repositories
        private IUserRepo _userRepo;


        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            //Init HomePresenter
            _registerPresenter = new RegisterPresenter(this);

            //Init repositories
            _userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();

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
            if (this.Page.IsValid)
            {
                if(_registerPresenter.CheckIsPasswordsAndPasswordConfirmationAreTheSame())
                {
                    _registerPresenter.Register(_userRepo, RegisterVMFormData);
                    Response.AddHeader("REFRESH", "1;URL=/Account/Login");


                }

            }
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
            get
            {
                return StatusControl.Text;
            }
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