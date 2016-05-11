using PhysicsAdvertisements.MVC.Web.ViewModels.HomeViewModels;
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
        private ICategoryRepo _categoryRepo;
        private IPhysicsAreasRepo _physicsAreasRepo;

        public HomeController(IUserRepo userRepo, ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo)
        {
            this._userRepo = userRepo;
            this._categoryRepo = categoryRepo;
            this._physicsAreasRepo = physicsAreasRepo;
        }


        public ActionResult Index()
        {
            IndexVM data = new IndexVM();
            PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);          
            data.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
            data.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();

            return View(data);
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