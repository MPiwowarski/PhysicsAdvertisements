using PhysicsAdvertisements.MVC.Web.ViewModels.AdvertisementViewModels;
using PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        [HttpGet]
        public ActionResult SearchResult(string category, string physicsArea)        
        {
            SearchResultVM dataVM = new SearchResultVM();
            
            return View(dataVM);
        }


        public ActionResult Create()
        {
            return View();
        }


    }
}