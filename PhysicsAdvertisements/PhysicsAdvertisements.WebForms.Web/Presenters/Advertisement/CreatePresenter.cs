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
        void InitializeObjects(ref IAdvertisementRepo advertisementRepo, ref IPhysicsAreasRepo physicsAreasRepo, ref ICategoryRepo categoryRepo);

        void SubmitControl_Click(Page page, IAdvertisementRepo advertisementRepo, IPhysicsAreasRepo physicsAreasRepo, ICategoryRepo categoryRepo, CreateVM data);
    }

    public class CreatePresenter : ICreatePresenter
    {
        private ICreateView _createView;

        public CreatePresenter(ICreateView createView)
        {
            this._createView = createView;
        }

        public void InitializeObjects(ref IAdvertisementRepo advertisementRepo, ref IPhysicsAreasRepo physicsAreasRepo, ref ICategoryRepo categoryRepo)
        {
            advertisementRepo = ServiceLocator.Current.GetInstance<IAdvertisementRepo>();
            physicsAreasRepo = ServiceLocator.Current.GetInstance<IPhysicsAreasRepo>();
            categoryRepo = ServiceLocator.Current.GetInstance<ICategoryRepo>();
        }

        public void SubmitControl_Click(Page page, IAdvertisementRepo advertisementRepo, IPhysicsAreasRepo physicsAreasRepo, ICategoryRepo categoryRepo, CreateVM data)
        {
            if (page.IsValid)
            {
                try
                {
                    Model.Advertisement advertisement = new Model.Advertisement();
                    advertisement = Mapper.Map<Model.Advertisement>(data);
                    advertisement.Category = categoryRepo.Table.Where(x=>x.Name==data.Category).First();
                    advertisement.PhysicsAreas = physicsAreasRepo.Table.Where(x => x.Name == data.PhysicsArea).First();

                    advertisementRepo.Insert(advertisement);
                    advertisementRepo.Save();

                    _createView.StatusControl_ForeColor = System.Drawing.Color.Green;
                    _createView.StatusControl_Text = "Changes saved successfully";

                }
                catch (Exception e)
                {
                    //logger implementation
                }
            }
        }
    }
}