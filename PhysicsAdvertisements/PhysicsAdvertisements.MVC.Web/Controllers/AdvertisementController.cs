using PhysicsAdvertisements.MVC.Web.ViewModels.AdvertisementViewModels;
using PhysicsAdvertisements.MVC.Web.ViewModels.PartialModulesViewModels;
using PhysicsAdvertisements.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class AdvertisementController : Controller
    {

        private ICategoryRepo _categoryRepo;
        private IPhysicsAreasRepo _physicsAreasRepo;
        private IUserRepo _userRepo;
        private IAdvertisementRepo _advertisementRepo;

        public AdvertisementController(ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo, IUserRepo userRepo, IAdvertisementRepo advertisementRepo)
        {
            this._categoryRepo = categoryRepo;
            this._physicsAreasRepo = physicsAreasRepo;
            this._userRepo = userRepo;
            this._advertisementRepo = advertisementRepo;
        }
        

        // GET: Advertisement
        [HttpGet]
        public ActionResult SearchResult(string category, string physicsArea)        
        {
            SearchResultVM dataVM = new SearchResultVM();
            PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);
            dataVM.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
            dataVM.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();

            if (category==null|| physicsArea == null)
            {
                dataVM.StatusColor = "Red";
                dataVM.Status = "No advertisements was found";
                return View(dataVM);
            }


            
            var result = _advertisementRepo.Table.Where(x => x.Category.Name == category && x.PhysicsAreas.Name == physicsArea)
                                                .ToList()
                                                .Join(_userRepo.Table,
                                                ad => ad.UserId,
                                                u => u.Id,
                                                (ad, u) => new { ad, u }).Select(s => new AdvertisementVM
                                                {
                                                    //Advertisement
                                                    AddedDate = s.ad.AddedDate,
                                                    AdvertisementTitle = s.ad.Title,
                                                    AdvertisementContent = s.ad.Content,
                                                    AdvertisementCategory = s.ad.Category.Name,
                                                    AdvertisementPhysicsArea = s.ad.PhysicsAreas.Name,
                                                    AdvertisementId = s.ad.Id.ToString(),
                                                    //Exhibitor's(user) data
                                                    UserImageUrl = s.u.Gender == (int)Model.User.GenderEnum.Female ? "../../ecommerce-icon-set-freepik/New/avatar%20girl.png" : "../../ecommerce-icon-set-freepik/PNG/avatar.png",
                                                    Name = s.u.Name,
                                                    Surname = s.u.Surname,
                                                    Email = s.u.Email,
                                                    PhoneNumber = s.u.PhoneNumber,
                                                    Birthday = s.u.Birthday,


                                                })
                                                .OrderByDescending(x => x.AddedDate)
                                                .ToList();

            if (!result.Any())
            {
                dataVM.StatusColor = "Red";
                dataVM.Status = "No advertisements was found";
            }
            else
            {
                dataVM.SearchResultData = result;

                dataVM.StatusColor = "Green";
                dataVM.Status = result.Count + " advertisements was found:";
            }

            return View(dataVM);
        }


        public ActionResult Create()
        {
            if (Session["LoggedUserId"] == null) { return RedirectToAction("Index", "Home"); }

            CreateVM dataVM = new CreateVM();
            dataVM.CategoryControlDataSource = GetCategoryControlDataSource();
            dataVM.PhysicsAreaControlDataSource = GetPhysicsAreaControlDataSource();

            PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);
            dataVM.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
            dataVM.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();

            return View(dataVM);
        }

        [HttpPost]
        public ActionResult Create(CreateVM dataVM)
        {
            if (Session["LoggedUserId"] == null) { return RedirectToAction("Index", "Home"); }
            if (!ModelState.IsValid)
            {
                return View(dataVM);
            }
            else
            {
                try
                {
                    Model.Advertisement advertisement = new Model.Advertisement();
                    advertisement.Content = dataVM.Content;
                    advertisement.Title = dataVM.Title;
                    advertisement.AddedDate = DateTime.Now;

                    advertisement.CategoryId = _categoryRepo.Table.Where(x => x.Name == dataVM.SelectedCategory).Select(x => x.Id).First();
                    advertisement.PhysicsAreasId = _physicsAreasRepo.Table.Where(x => x.Name == dataVM.SelectedPhysicsArea).Select(x => x.Id).First();
                    int loggedUserId = (int)Session["LoggedUserId"];
                    advertisement.UserId = _userRepo.Table.Where(x => x.Id == loggedUserId).Select(x => x.Id).First();

                    _advertisementRepo.Insert(advertisement);
                    _advertisementRepo.Save();

                    dataVM = new CreateVM();
                    ModelState.Clear();
                    dataVM.Status = "Changes saved successfully";

                    dataVM.CategoryControlDataSource = GetCategoryControlDataSource();
                    dataVM.PhysicsAreaControlDataSource = GetPhysicsAreaControlDataSource();

                    PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);
                    dataVM.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
                    dataVM.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();


                    return View(dataVM);
                }
                catch (Exception e)
                {
                    //logger implementation
                    return View("Error");
                }
            }

        }
              

        public List<SelectListItem> GetCategoryControlDataSource()
        {
            List<SelectListItem> data = new List<SelectListItem>();

            var categories = _categoryRepo.Table.Select(x => x.Name).ToList();

            foreach (var item in categories)
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

        public ActionResult DeleteAdvertisement(int? advertisementId)
        {
            if (advertisementId == null)
            {
                return View("Error");
            }

            try
            {
                _advertisementRepo.DeleteById((int)advertisementId);
                _advertisementRepo.Save();             
                return Content("<script language='javascript' type='text/javascript'>alert('Advertisement deleted successfully!'); window.location.replace('MyAdvertisements');</script>");

            }
            catch (Exception e)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('There was an error during deleting the row: "+ e +"'); window.location.replace('MyAdvertisements');</script>");
            }

        }


        public ActionResult MyAdvertisements()
        {
            if (Session["LoggedUserId"] == null) { return RedirectToAction("Index", "Home"); }


            MyAdvertisementsVM dataVM = new MyAdvertisementsVM();
            PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);
            dataVM.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
            dataVM.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();

            int loggedUserId = (int)Session["LoggedUserId"];
            List<AdvertisementVM> result = _advertisementRepo.Table.Where(x => x.UserId == loggedUserId)
                                            .ToList()
                                            .Join(_userRepo.Table,
                                            ad => ad.UserId,
                                            u => u.Id,
                                            (ad, u) => new { ad, u }).Select(s => new AdvertisementVM
                                            {
                                                //Advertisement
                                                AddedDate = s.ad.AddedDate,
                                                AdvertisementTitle = s.ad.Title,
                                                AdvertisementContent = s.ad.Content,
                                                AdvertisementCategory = s.ad.Category.Name,
                                                AdvertisementPhysicsArea = s.ad.PhysicsAreas.Name,
                                                AdvertisementId = s.ad.Id.ToString(),
                                                //Exhibitor's(user) data
                                                UserImageUrl = s.u.Gender == (int)Model.User.GenderEnum.Female ? "../../ecommerce-icon-set-freepik/New/avatar%20girl.png" : "../../ecommerce-icon-set-freepik/PNG/avatar.png",
                                                Name = s.u.Name,
                                                Surname = s.u.Surname,
                                                Email = s.u.Email,
                                                PhoneNumber = s.u.PhoneNumber,
                                                Birthday = s.u.Birthday,

                                            })
                                            .OrderByDescending(x => x.AddedDate)
                                            .ToList();

            

            if (!result.Any())
            {
                dataVM.StatusColor = "Red";
                dataVM.Status = "No advertisements was found";
            }
            else
            {
                dataVM.MyAdvertisements = result;

                dataVM.StatusColor = "Green";
                dataVM.Status = result.Count + " advertisements was found:";
            }



            return View(dataVM);
        }




      
    }
}