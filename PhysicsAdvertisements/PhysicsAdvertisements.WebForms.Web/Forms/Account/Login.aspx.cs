using Microsoft.Practices.ServiceLocation;
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
        #endregion

        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            _loginPresenter.LoginControl_Click();
        }
    }
}