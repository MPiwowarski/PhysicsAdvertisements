using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Forms.Advertisement;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AdvertisementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement
{
    public interface ICreatePresenter
    {
        void InitializeObjects(ref IAdvertisementRepo advertisementRepo, ref IPhysicsAreasRepo physicsAreasRepo, ref ICategoryRepo categoryRepo,ref IUserRepo userRepo);

        void SubmitControl_Click(Page page, IAdvertisementRepo advertisementRepo, IPhysicsAreasRepo physicsAreasRepo, ICategoryRepo categoryRepo, IUserRepo userRepo, CreateVM data);

        void PutDataToControlsDataSource(Page page,ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo);
    }

    public class CreatePresenter : ICreatePresenter
    {
        private ICreateView _createView;

        public CreatePresenter(ICreateView createView)
        {
            this._createView = createView;
        }

        public void InitializeObjects(ref IAdvertisementRepo advertisementRepo, ref IPhysicsAreasRepo physicsAreasRepo, ref ICategoryRepo categoryRepo, ref IUserRepo userRepo)
        {
            advertisementRepo = ServiceLocator.Current.GetInstance<IAdvertisementRepo>();
            physicsAreasRepo = ServiceLocator.Current.GetInstance<IPhysicsAreasRepo>();
            categoryRepo = ServiceLocator.Current.GetInstance<ICategoryRepo>();
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
        }

        public void SubmitControl_Click(Page page, IAdvertisementRepo advertisementRepo, IPhysicsAreasRepo physicsAreasRepo, ICategoryRepo categoryRepo, IUserRepo userRepo, CreateVM data)
        {
            if (page.IsValid)
            {
                try
                {
                    Model.Advertisement advertisement = new Model.Advertisement();
                    advertisement.Content = data.Content;
                    advertisement.Title = data.Title;
                    advertisement.AddedDate = DateTime.Now;

                    advertisement.CategoryId = categoryRepo.Table.Where(x=>x.Name==data.Category).Select(x=>x.Id).First();
                    advertisement.PhysicsAreasId = physicsAreasRepo.Table.Where(x => x.Name == data.PhysicsArea).Select(x => x.Id).First();
                    int loggedUserId = (int)page.Session["LoggedUserId"];
                    advertisement.UserId = userRepo.Table.Where(x => x.Id ==loggedUserId).Select(x => x.Id).First();

                    advertisementRepo.Insert(advertisement);
                    advertisementRepo.Save();

                    _createView.StatusControl_ForeColor = System.Drawing.Color.Green;
                    _createView.StatusControl_Text = "Changes saved successfully";
                    _createView.ContentControl_Text = "";
                    _createView.TitleControl_Text = "";

                }
                catch (Exception e)
                {
                    _createView.StatusControl_ForeColor = System.Drawing.Color.Red;
                    _createView.StatusControl_Text = "Error during Saving:" + e.Message;
                    //logger implementation
                }
            }
        }

        public void PutDataToControlsDataSource(Page page,ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo)
        {
            if (!page.IsPostBack)
            {
                _createView.CategoryControl_DataSourceWithDataBind = categoryRepo.Table.Select(x => x.Name).ToList();
                _createView.PhysicsAreaControl_DataSourceWithDataBind = physicsAreasRepo.Table.Select(x => x.Name).ToList();
            }
        }
    }
}