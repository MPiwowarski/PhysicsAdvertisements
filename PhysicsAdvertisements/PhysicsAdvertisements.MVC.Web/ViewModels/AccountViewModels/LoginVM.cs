using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.MVC.Web.ViewModels.AccountViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Field required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Password { get; set; }

        public string Status { get; set; }
        public string StatusColor { get; set; }
    }
}