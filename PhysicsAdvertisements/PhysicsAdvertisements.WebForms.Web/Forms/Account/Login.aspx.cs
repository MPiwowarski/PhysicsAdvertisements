using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Presenters.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Account
{
    public interface ILoginView
    {
        string LoginControl_Text { get; set; }
        string PasswordControl_Text { get; set; }
        string StatusControl_Text { set; }
        System.Drawing.Color StatusControl_ForeColor { set; }

    }

    public partial class Login : System.Web.UI.Page, ILoginView
    {
        private ILoginPresenter _loginPresenter;

        //Repositories
        private IUserRepo _userRepo;

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            //Init HomePresenter
            _loginPresenter = new LoginPresenter(this);

            //Init repositories
            _userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        #endregion


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

        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            Session["LoggedUserId"] = _loginPresenter.LoginControl_Click(_userRepo, LoginControl_Text, PasswordControl_Text);

            if (Session["LoggedUserId"] != null)
            {
                StatusControl_ForeColor = System.Drawing.Color.Green;
                StatusControl_Text = "Logged successfully";
                Response.AddHeader("REFRESH", "1;URL=/Account/User-Data");
            }
            else
            {
                _loginPresenter.ClearForm();
                StatusControl_ForeColor = System.Drawing.Color.Red;
                StatusControl_Text = "Wrong login or password";
            }
        }
    }
}