using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Presenters.Account;
using PhysicsAdvertisements.WebForms.Web.Presenters.Global;
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
    public interface IUserDataView
    {
        string PasswordControl_Text { get; }
        string PasswordConfirmationControl_Text { get; }
        string StatusControl_Text { set; }

        System.Drawing.Color StatusControl_ForeColor { set; }

        UserDataVM UserDataVMFormData { get; }

        string LoginControl_Text { set; }
        string NameControl_Text { set; }
        string SurnameControl_Text { set; }
        DateTime BirthdayControl_Text { set; }
        User.GenderEnum GenderControl_Text { set; }
        string PhoneNumberControl_Text { set; }
        string EmailControl_Text { set; }

    }


    public partial class UserData : System.Web.UI.Page, IUserDataView
    {
        //Presenters
        private IUserDataPresenter _userDataPresenter;

        //Repositories
        private IUserRepo _userRepo;



        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            LoggedUserPresenter.CheckIsUserLooged(this);

            //Init HomePresenter
            _userDataPresenter = new UserDataPresenter(this);

            //Init Objects
            _userDataPresenter.InitializeObjects(ref _userRepo);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _userDataPresenter.FillFormFieldsWithUserData(_userRepo, (int)Session["LoggedUserId"]);
        }
        #endregion


        protected void GetTypeName(object sender, EventArgs e)
        {
            DataAnnotationValidator validator = (DataAnnotationValidator)sender;
            validator.SourceTypeName = new UserDataVM().EntityType.AssemblyQualifiedName;
        }

        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            _userDataPresenter.SubmitControl_Click(this, _userRepo, UserDataVMFormData);           
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

        public UserDataVM UserDataVMFormData
        {
            get
            {
                return new UserDataVM()
                {
                    Login = LoginControl.Text,
                    Password = PasswordControl.Text,
                    PasswordConfirmation = PasswordConfirmationControl.Text,
                    Name = NameControl.Text,
                    Surname = SurnameControl.Text,
                    Birthday= DateTime.ParseExact(BirthdayControl.Text, "dd-MM-yyyy", null),              
                    Gender = Convert.ToInt32(GenderControl.Text),
                    PhoneNumber = PhoneNumberControl.Text,
                    Email = EmailControl.Text
                };

            }

        }


        public string LoginControl_Text
        {
            set
            {
                LoginControl.Text = value;
            }
        }
        public string NameControl_Text
        {
            set
            {
                NameControl.Text = value;
            }
        }
        public string SurnameControl_Text
        {
            set
            {
                SurnameControl.Text = value;
            }
        }
        public DateTime BirthdayControl_Text
        {
            set
            {
                BirthdayControl.Text = value.ToString("dd-MM-yyyy");
            }
        }
        public User.GenderEnum GenderControl_Text
        {
            set
            {
                GenderControl.SelectedValue = value.ToString();
            }
        }
        public string PhoneNumberControl_Text
        {
            set
            {
                PhoneNumberControl.Text = value;
            }
        }
        public string EmailControl_Text
        {
            set
            {
                EmailControl.Text = value;
            }
        }
        #endregion

    }
}