using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Data.Advertisement;
using PhysicsAdvertisements.WebForms.Web.Forms.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement
{
    public interface IMyAdvertisementsPresenter
    {
        void InitializeRepoObjects(ref IUserRepo userRepo,ref IAdvertisementRepo advertisementRepo);
        void DeleteSelectedAdvertisement(int AdvertisementId, IAdvertisementRepo advertisementRepo, System.Web.UI.Page page, int loggedUserId, IUserRepo userRepo);
        void PutDataToSearchResultGridViewControl(System.Web.UI.Page page, int loggedUserId, IUserRepo userRepo, IAdvertisementRepo advertisementRepo);
    }

    public class MyAdvertisementsPresenter: IMyAdvertisementsPresenter
    {
        private IMyAdvertisementsView _myAdvertisementsView;

        public MyAdvertisementsPresenter(IMyAdvertisementsView myAdvertisementsView)
        {
            this._myAdvertisementsView = myAdvertisementsView;
        }


        public void InitializeRepoObjects(ref IUserRepo userRepo, ref IAdvertisementRepo advertisementRepo)
        {
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
            advertisementRepo = ServiceLocator.Current.GetInstance<IAdvertisementRepo>();
        }

        public void DeleteSelectedAdvertisement(int AdvertisementId, IAdvertisementRepo advertisementRepo, System.Web.UI.Page page, int loggedUserId, IUserRepo userRepo)
        {
            try
            {
                advertisementRepo.DeleteById(AdvertisementId);
                advertisementRepo.Save();

                PutDataToSearchResultGridViewControl(page, loggedUserId, userRepo, advertisementRepo);
                _myAdvertisementsView.StatusControl_ForeColor = System.Drawing.Color.Green;
                _myAdvertisementsView.StatusControl_Text = "Deleted row successfully";
                
            }
            catch(Exception e)
            {
                _myAdvertisementsView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _myAdvertisementsView.StatusControl_Text = "There was an error during deleting the row: "+e;
            }
        }


        public void PutDataToSearchResultGridViewControl(System.Web.UI.Page page,int loggedUserId,IUserRepo userRepo, IAdvertisementRepo advertisementRepo)
        {
            List<MyAdvertisementsData> result = advertisementRepo.Table.Where(x => x.UserId == loggedUserId)
                                                       .ToList()
                                                       .Join(userRepo.Table,
                                                       ad => ad.UserId,
                                                       u => u.Id,
                                                       (ad, u) => new { ad, u }).Select(s => new MyAdvertisementsData
                                                       {
                                                        //Advertisement
                                                           AddedDate = s.ad.AddedDate,
                                                           AdvertisementTitle = s.ad.Title,
                                                           AdvertisementContent = s.ad.Content,
                                                           AdvertisementCategory = s.ad.Category.Name,
                                                           AdvertisementPhysicsArea = s.ad.PhysicsAreas.Name,
                                                           AdvertisementId = s.ad.Id.ToString(),
                                                        //Exhibitor's(user) data
                                                        UserImageUrl = s.u.Gender == (int)User.GenderEnum.Female ? "../../ecommerce-icon-set-freepik/New/avatar%20girl.png" : "../../ecommerce-icon-set-freepik/PNG/avatar.png",
                                                           Name = s.u.Name,
                                                           Surname = s.u.Surname,
                                                           Email = s.u.Email,
                                                           PhoneNumber = s.u.PhoneNumber,
                                                           Birthday = s.u.Birthday,

                                                       })
                                                       .OrderByDescending(x => x.AddedDate)
                                                       .ToList();

            if (!result.Any())
            {
                _myAdvertisementsView.StatusControl_ForeColor = System.Drawing.Color.Red;
                _myAdvertisementsView.StatusControl_Text = "No advertisements was found";
            }
            else
            {
                _myAdvertisementsView.MyAdvertisementsGridViewControl_DataSourceWithDataBind = result;

                _myAdvertisementsView.StatusControl_ForeColor = System.Drawing.Color.Green;
                _myAdvertisementsView.StatusControl_Text = result.Count + " advertisements was found:";
            }
        }
    }
}