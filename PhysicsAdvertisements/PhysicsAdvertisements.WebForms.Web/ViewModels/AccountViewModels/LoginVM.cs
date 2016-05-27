using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels
{
    public class LoginVM: Validatable.Validatable<LoginVM>
    {
        [Required(ErrorMessage = "Field required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}