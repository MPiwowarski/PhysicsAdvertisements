using PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.ViewModels.HomeViewModels
{
    public class IndexVM
    {
        public IndexVM()
        {
            this.AdvertisementsSearchPartial = new AdvertisementsSearchVM();
        }

        public AdvertisementsSearchVM AdvertisementsSearchPartial { get; set; }
       

    }
}