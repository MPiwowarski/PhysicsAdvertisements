using PhysicsAdvertisements.MVC.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            LoginVM data = new LoginVM();
            data.Status = "sdfdsfasdf";
            data.StatusColor = "green";
            return View(data);
        }

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {

            return View();
        }

        public ActionResult UserData()
        {
            if (Session["LoggedUserId"] == null) { Response.Redirect("/Home"); }



            return View();
        }

      

        

    }
}