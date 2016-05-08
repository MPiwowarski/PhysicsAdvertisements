using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
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
                var categories = categoryRepo.Table.Select(x => x.Name).ToList();
                _advertisementsSearchView.CategoryControl_DataSourceWithDataBind = categories;

                var physicsAreas= physicsAreasRepo.Table.Select(x => x.Name).ToList();
                _advertisementsSearchView.PhysicsAreaControl_DataSourceWithDataBind = physicsAreas;
            }
        }

        //TODO: move complex queries to repo
        public void SearchBtnControl_Click(System.Web.UI.UserControl userControl, string selectedCategory, string selectedPhysicsArea, IAdvertisementRepo advertisementRepo, IUserRepo userRepo)
        {
            List<MyAdvertisementsData> advertisementsSearchResultData = new List<MyAdvertisementsData>();

            advertisementsSearchResultData = advertisementRepo.Table.Where(x => x.Category.Name == selectedCategory && x.PhysicsAreas.Name == selectedPhysicsArea)
                                                .ToList()
                                                .Join(userRepo.Table,
                                                ad=>ad.UserId,
                                                u=> u.Id,
                                                (ad, u) => new { ad,u }).Select(s=>new MyAdvertisementsData
                                                { 
                                                    //Advertisement
                                                    AddedDate=s.ad.AddedDate,
                                                    AdvertisementTitle=s.ad.Title,
                                                    AdvertisementContent=s.ad.Content,
                                                    AdvertisementCategory= s.ad.Category.Name,
                                                    AdvertisementPhysicsArea=s.ad.PhysicsAreas.Name,
                                                    AdvertisementId=s.ad.Id.ToString(),
                                                    //Exhibitor's(user) data
                                                    UserImageUrl = s.u.Gender== (int)User.GenderEnum.Female ? "../../ecommerce-icon-set-freepik/New/avatar%20girl.png" : "../../ecommerce-icon-set-freepik/PNG/avatar.png",
                                                    Name = s.u.Name,
                                                    Surname = s.u.Surname,
                                                    Email=  s.u.Email,
                                                    PhoneNumber=s.u.PhoneNumber,
                                                    Birthday = s.u.Birthday,
                                                    
                                                    
                                                 })
                                                .OrderByDescending(x => x.AddedDate)
                                                .ToList();

            userControl.Session["AdvertisementsSearchResultData"] = advertisementsSearchResultData;

            userControl.Response.Redirect("~/Advertisement/Search-Result");
        }

        

    }
}