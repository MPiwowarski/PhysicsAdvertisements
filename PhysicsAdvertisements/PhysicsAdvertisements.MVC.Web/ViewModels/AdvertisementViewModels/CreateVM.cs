using PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.ViewModels.AdvertisementViewModels
{
    public class CreateVM 
    {
        public CreateVM()
        {
            this.AdvertisementsSearchPartial = new AdvertisementsSearchVM();
            this.CategoryControlDataSource = new List<SelectListItem>();
            this.PhysicsAreaControlDataSource = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "Field required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Content { get; set; }

        public string SelectedCategory { get; set; }
        public string SelectedPhysicsArea { get; set; }

        public List<SelectListItem> PhysicsAreaControlDataSource { get; set; }
        public List<SelectListItem> CategoryControlDataSource { get; set; }

        public AdvertisementsSearchVM AdvertisementsSearchPartial { get; set; }

        public string Status { get; set; }
    }
}