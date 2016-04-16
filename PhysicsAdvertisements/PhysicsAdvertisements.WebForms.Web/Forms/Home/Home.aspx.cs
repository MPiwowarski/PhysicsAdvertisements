using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Home
{
    public interface IHomeView
    {
        string FeedbackContent_Text { get; set; }
    }

    public partial class Home : System.Web.UI.Page, IHomeView
    {
        private HomePresenter _homePresenter;

        //Repo
        private IUserRepo _userRepo;
        private IPhysicsAreasDictionaryRepo _physicsAreasDictionaryRepo;

        public Home()
        {
            //Init HomePresenter
            _homePresenter = new HomePresenter(this);

            //Init repositories
            _userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
            _physicsAreasDictionaryRepo = ServiceLocator.Current.GetInstance<IPhysicsAreasDictionaryRepo>();
            


            PhysicsAreasDictionary tmp = new PhysicsAreasDictionary() { Name = "Tomek" };
            _userRepo.Context.PhysicsAreasDictionary.Add(tmp);
            _userRepo.Save();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (FeedbackContent_Text != "")
            {
                _homePresenter.SendFeedback_Click();
            }
        }

        protected void SendFeedbackControl_Click(object sender, EventArgs e)
        {

        }

        public string FeedbackContent_Text
        {
            get
            {
                return FeedbackContentControl.Text;
            }
            set
            {
                FeedbackContentControl.Text = value;
            }
        }


    }
}