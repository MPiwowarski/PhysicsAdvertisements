using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.MVC.Web.ViewModels.AccountViewModels
{
    public class RegisterVM 
    {
        [Required(ErrorMessage = "Field required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Given value is different than Password")] //this attribute will not work properly in Validatable lib.    
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Date, ErrorMessage = "Inavalid date")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Field required")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Inavalid email address")]
        [EmailAddress]
        public string Email { get; set; }


        public string Status { get; set; }

    }
}