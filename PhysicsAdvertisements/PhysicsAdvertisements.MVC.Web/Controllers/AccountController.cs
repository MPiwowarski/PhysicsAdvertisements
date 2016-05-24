using AutoMapper;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Model.Utils;
using PhysicsAdvertisements.MVC.Web.ViewModels.AccountViewModels;
using PhysicsAdvertisements.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class AccountController : Controller
    {
        //Repositories
        private readonly IUserRepo _userRepo;
        private ICategoryRepo _categoryRepo;
        private IPhysicsAreasRepo _physicsAreasRepo;

        public AccountController(IUserRepo userRepo, ICategoryRepo categoryRepo, IPhysicsAreasRepo physicsAreasRepo)
        {
            this._userRepo = userRepo;
            this._categoryRepo = categoryRepo;
            this._physicsAreasRepo = physicsAreasRepo;
        }
        

        // GET: Account
        public ActionResult Login()
        {
            LoginVM data = new LoginVM();

            return View(data);
        }

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }


            Session["LoggedUserId"] = CheckIfUserWithGivenLoginAndPasswordExistsInDb(data.Login, data.Password);

            if (Session["LoggedUserId"] != null)
            {
                return RedirectToAction("UserData");
            }
            else
            {
                LoginVM ErrorData = new LoginVM();
                ErrorData.Status = "Wrong login or password";
                ErrorData.Login = "";
                ErrorData.Password = "";
                return View(ErrorData);
            }
        }

        public int? CheckIfUserWithGivenLoginAndPasswordExistsInDb(string login, string password)
        {
            password = (new HashingContext()).EncryptPhrase(password);
            int? id = _userRepo.Table.Where(x => x.Login.Equals(login) && x.Password.Equals(password)).Select(x => x.Id).FirstOrDefault();
            if (id != 0)
                return id;
            else
                return null;
        }


        // GET: Register
        public ActionResult Register()
        {
            RegisterVM data = new RegisterVM();

            return View(data);
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(RegisterVM data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            if (!IsLoginFree(data.Login))
            {
                data.Status = "Given login is already occupied. Choose another.";
                return View(data);
            }
            try
            {
                User user = new User();
                user = Mapper.Map<User>(data);
                user.Password = (new HashingContext()).EncryptPhrase(user.Password);
                _userRepo.Insert(user);
                _userRepo.Save();
                return Content("<script language='javascript' type='text/javascript'>alert('You registered successfully!'); window.location.replace('Login');</script>");
            }
            catch (Exception e)
            {
                //logger implementation
                return View("Error");

            }
            //return RedirectToAction("Login");

        }

        public bool IsLoginFree(string login)
        {
            if (_userRepo.Table.Where(x => x.Login == login).FirstOrDefault() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public ActionResult Logout()
        {
            Session["LoggedUserId"] = null;
            return RedirectToAction("Index","Home");
        }

        public ActionResult UserData()
        {
            if (Session["LoggedUserId"] == null) { return RedirectToAction("Index", "Home"); }
            User user = _userRepo.GetById((int)Session["LoggedUserId"]);
            UserDataVM dataVM = new UserDataVM();

            dataVM.Login= user.Login;
            dataVM.Name = user.Name;
            dataVM.Surname =user.Surname;
            //user.Birthday = data.Birthday;
            dataVM.Gender = user.Gender;
            dataVM.PhoneNumber = user.PhoneNumber;
            dataVM.Email = user.Email;


            PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);
            dataVM.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
            dataVM.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();


            return View(dataVM);
        }

        [HttpPost]
        public ActionResult UserData(UserDataVM data)
        {
            if (Session["LoggedUserId"] == null) { return RedirectToAction("Index", "Home"); }
            if (!ModelState.IsValid)
            {
                PartialModulesController partialModulesController = new PartialModulesController(_categoryRepo, _physicsAreasRepo);
                data.AdvertisementsSearchPartial.CategoryControlDataSource = partialModulesController.GetCategoryControlDataSource();
                data.AdvertisementsSearchPartial.PhysicsAreaControlDataSource = partialModulesController.GetPhysicsAreaControlDataSource();
                return View(data);
            }

            try
            {
                User user = _userRepo.GetById((int)Session["LoggedUserId"]);

                user.Login = data.Login;
                user.Password = (new HashingContext()).EncryptPhrase(data.Password);
                user.Name = data.Name;
                user.Surname = data.Surname;
                //user.Birthday = data.Birthday;
                user.Gender = data.Gender;
                user.PhoneNumber = data.PhoneNumber;
                user.Email = data.Email;
                _userRepo.Update(user);
                _userRepo.Save();


                //_userDataView.StatusControl_ForeColor = System.Drawing.Color.Green;
                //_userDataView.StatusControl_Text = "Changes saved successfully";

                data.Status = "Changes saved successfully";
                data.Password = "";
                data.PasswordConfirmation = "";

                return View(data);

            }
            catch (Exception e)
            {
                //_userDataView.StatusControl_ForeColor = System.Drawing.Color.Red;
                //_userDataView.StatusControl_Text = "There was an error during saving " + e;
                //logger implementation
                return View("Error");
            }

            
        }
    }
}