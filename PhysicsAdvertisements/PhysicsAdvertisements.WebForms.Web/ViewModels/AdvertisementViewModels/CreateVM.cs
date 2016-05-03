using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.ViewModels.AdvertisementViewModels
{
    public class CreateVM : Validatable.Validatable<CreateVM>
    {
        [Required(ErrorMessage = "Field required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Field required")]
        public int Category { get; set; }

        [Required(ErrorMessage = "Field required")]
        public int PhysicsArea { get; set; }


    }
}