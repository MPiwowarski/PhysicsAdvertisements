using AutoMapper;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Model.Utils;
using PhysicsAdvertisements.MVC.Web.ViewModels.AccountViewModels;
using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicsAdvertisements.MVC.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepo _userRepo;

        public AccountController(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
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
            return RedirectToAction("Login");

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



        public ActionResult UserData()
        {
            if (Session["LoggedUserId"] == null) { Response.Redirect("/Home"); }

            return View();
        }


    }
}