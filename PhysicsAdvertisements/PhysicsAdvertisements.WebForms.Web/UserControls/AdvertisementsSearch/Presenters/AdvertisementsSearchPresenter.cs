using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Data.Advertisement;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters
{
    public interface IAdvertisementsSearchPresenter
    {
        void InitializeRepoObjects(ref IAdvertisementRepo advertisementRepo, ref ICategoryRepo categoryRepo, ref IPhysicsAreasRepo physicsAreasRepo,ref IUserRepo userRepo);
        void PutDataToControlsDataSource(ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo);

        void SearchBtnControl_Click(System.Web.UI.UserControl userControl, string selectedCategory, string selectedPhysicsArea, IAdvertisementRepo advertisementRepo, IUserRepo userRepo);

    }

    public class AdvertisementsSearchPresenter
    {
        protected IAdvertisementsSearchView _advertisementsSearchView;

        public AdvertisementsSearchPresenter(IAdvertisementsSearchView advertisementsSearchView)
        {
            this._advertisementsSearchView = advertisementsSearchView;
        }


        public void InitializeRepoObjects(ref IAdvertisementRepo advertisementRepo, ref ICategoryRepo categoryRepo, ref IPhysicsAreasRepo physicsAreasRepo, ref IUserRepo userRepo)
        {
            advertisementRepo = ServiceLocator.Current.GetInstance<IAdvertisementRepo>();
            categoryRepo = ServiceLocator.Current.GetInstance<ICategoryRepo>();
            physicsAreasRepo = ServiceLocator.Current.GetInstance<IPhysicsAreasRepo>();
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
        }

        public void PutDataToControlsDataSource(System.Web.UI.UserControl userControl,ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo)
        {
            if (!userControl.IsPostBack)
            {
                _advertisementsSearchView.CategoryControl_DataSourceWithDataBind = categoryRepo.Table.Select(x => x.Name).ToList();
                _advertisementsSearchView.PhysicsAreaControl_DataSourceWithDataBind = physicsAreasRepo.Table.Select(x => x.Name).ToList();
            }
        }

        public void SearchBtnControl_Click(System.Web.UI.UserControl userControl, string selectedCategory, string selectedPhysicsArea, IAdvertisementRepo advertisementRepo, IUserRepo userRepo)
        {
            List<MyAdvertisementsData> advertisementsSearchResultData = new List<MyAdvertisementsData>();          

            userControl.Session["AdvertisementsSearchResultData"] = advertisementsSearchResultData;

            userControl.Response.Redirect("~/Advertisement/Search-Result");
        }

    }
}