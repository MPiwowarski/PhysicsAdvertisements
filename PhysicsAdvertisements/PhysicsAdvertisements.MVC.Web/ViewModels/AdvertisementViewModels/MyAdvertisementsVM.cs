using PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.MVC.Web.ViewModels.AdvertisementViewModels
{
    public class MyAdvertisementsVM
    {
        public MyAdvertisementsVM()
        {
            this.MyAdvertisements = new List<AdvertisementVM>();
            this.AdvertisementsSearchPartial = new AdvertisementsSearchVM();
        }

        public List<AdvertisementVM> MyAdvertisements { get; set; }

        public string StatusColor{ get; set; }
        public string Status { get; set; }

        public AdvertisementsSearchVM AdvertisementsSearchPartial { get; set; }
    }
}