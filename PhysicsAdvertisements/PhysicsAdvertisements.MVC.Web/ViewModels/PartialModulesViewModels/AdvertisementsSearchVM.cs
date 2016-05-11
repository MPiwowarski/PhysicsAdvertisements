using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels
{
    public class AdvertisementsSearchVM
    {
        public string SelectedCategory { get; set; }
        public string SelectedPhysicsArea { get; set; }

        public List<SelectListItem> PhysicsAreaControlDataSource { get; set; }
        public List<SelectListItem> CategoryControlDataSource { get; set; }
    }
}