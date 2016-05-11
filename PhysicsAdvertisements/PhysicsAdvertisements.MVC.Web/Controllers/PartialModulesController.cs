using PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels;
using PhysicsAdvertisements.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class PartialModulesController : Controller
    {
        private ICategoryRepo _categoryRepo;
        private IPhysicsAreasRepo _physicsAreasRepo;


        public PartialModulesController(ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo)
        {
            this._categoryRepo = categoryRepo;
            this._physicsAreasRepo = physicsAreasRepo;
        }

        // GET: PartialModules
        public ActionResult AdvertisementsSearch(AdvertisementsSearchVM data)
        {

            return RedirectToAction("SearchResult", "Advertisement", new { category = data.SelectedCategory, physicsArea = data.SelectedPhysicsArea });
        }


        public List<SelectListItem> GetCategoryControlDataSource()
        {
            List<SelectListItem> data = new List<SelectListItem>();

            var categories = _categoryRepo.Table.Select(x => x.Name).ToList();
           
            foreach(var item in categories)
            {
                data.Add(new SelectListItem() { Text = item });
            }

            return data;

        }


        public List<SelectListItem> GetPhysicsAreaControlDataSource()
        {
            List<SelectListItem> data = new List<SelectListItem>();

            var physicsAreas = _physicsAreasRepo.Table.Select(x => x.Name).ToList();

            foreach (var item in physicsAreas)
            {
                data.Add(new SelectListItem() { Text = item });
            }

            return data;

        }
    }
}