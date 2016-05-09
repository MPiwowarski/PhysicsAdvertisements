using PhysicsAdvertisements.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        //Repositories
        private readonly IUserRepo _userRepo;

        public HomeController(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
        }


        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}