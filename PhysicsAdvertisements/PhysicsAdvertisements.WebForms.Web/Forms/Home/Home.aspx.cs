﻿using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
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
        //string FeedbackContent_Text { get; set; }
    }

    public partial class Home : System.Web.UI.Page, IHomeView
    {
        private IHomePresenter _homePresenter;

        //Repositories
        private IUserRepo _userRepo;


        //UserControls
        private AdvertisementsSearchPresenter _advertisementsSearchPresenter;
        private IAdvertisementsSearchView _avertisementsSearchView;

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            //Init HomePresenter
            _homePresenter = new HomePresenter(this);

            //Init repositories
            _userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();

            ////Init
            //_avertisementsSearchView = (IAdvertisementsSearchView)AdvertisementsSearchControl;
            //_advertisementsSearchPresenter = new AdvertisementsSearchPresenter(_avertisementsSearchView);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //_homePresenter.SendFeedback_Click();

        }

        #endregion


        #region **********************************   Controls events   **********************************
        //protected void SearchBtn_Click_Event(object sender, EventArgs e)
        //{
        //    _advertisementsSearchPresenter.SearchBtn_Click();
        //}

        protected void SendFeedbackControl_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region **********************************   Accessors   **********************************
        //public string FeedbackContent_Text
        //{
        //    get
        //    {
        //        return FeedbackContentControl.Text;
        //    }
        //    set
        //    {
        //        FeedbackContentControl.Text = value;
        //    }
        //}

        #endregion

    }
}