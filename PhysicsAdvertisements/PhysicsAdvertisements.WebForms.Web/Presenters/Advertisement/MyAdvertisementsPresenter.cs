using Microsoft.Practices.ServiceLocation;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Forms.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement
{
    public interface IMyAdvertisementsPresenter
    {
        void InitializeRepoObjects(ref IUserRepo userRepo);
    }

    public class MyAdvertisementsPresenter: IMyAdvertisementsPresenter
    {
        private IMyAdvertisementsView _myAdvertisements;

        public MyAdvertisementsPresenter(IMyAdvertisementsView myAdvertisements)
        {
            this._myAdvertisements = myAdvertisements;
        }


        public void InitializeRepoObjects(ref IUserRepo userRepo)
        {
            userRepo = ServiceLocator.Current.GetInstance<IUserRepo>();
        }
    }
}