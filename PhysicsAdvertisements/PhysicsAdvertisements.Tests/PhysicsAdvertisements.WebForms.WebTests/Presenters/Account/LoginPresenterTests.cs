using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhysicsAdvertisements.WebForms.Web.Presenters.Account;
using Moq;
using PhysicsAdvertisements.WebForms.Web.Forms.Account;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using System.Collections.Generic;
using PhysicsAdvertisements.Model;

namespace PhysicsAdvertisements.Tests.PhysicsAdvertisements.WebForms.WebTests.Presenters.Account
{



    [TestClass]
    public class LoginPresenterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<User> sampleUserTable = new List<User>()
            {
                new User()
                {
                    Login="Login1"              
                },
                new User()
                {
                    Login="Login2"
                }
            };

            Mock<ILoginView> loginView = new Mock<ILoginView>();

            LoginPresenter loginPresenter = new LoginPresenter(loginView.Object);


            loginView.Setup(x => x.LoginControl_Text).Returns("r");
            loginView.Setup(x => x.PasswordControl_Text).Returns("r");

            var result = false;

            if (loginPresenter.CheckIfUserWithGivenLoginAndPasswordExistsInDb(loginView.Object.LoginControl_Text, loginView.Object.PasswordControl_Text) != null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Mock<LoginVM> loginVM = new Mock<LoginVM>();


            loginVM.Setup(x => x.Login).Returns("r");
            loginVM.Setup(x => x.Password).Returns("r");

            var result = false;

            Assert.IsTrue(result);
        }


        [TestClass]
        public class TblUserRepositoryTest
        {
            //[TestMethod]
            //public void AddNewUserTest()
            //{
            //    var mockSet = new Mock<DbSet<tblUser>>();

            //    var mockContext = new Mock<GoWithMeDBContext>();
            //    mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            //    var repo = new TblUserRepository(mockContext.Object);

            //    tblUser newUser = new tblUser();
            //    newUser.Email = "email@wp.pl";
            //    newUser.Login = "login";
            //    newUser.Password = "Password";
            //    newUser.Name = "Name";
            //    newUser.Surname = "Surname";
            //    newUser.PhoneNumber = "999888777";
            //    newUser.RegistrationDate = DateTime.Now;

            //    repo.AddNewUser(newUser);

            //    mockSet.Verify(m => m.Add(It.IsAny<tblUser>()), Times.Once());
            //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
            //}

            //[TestMethod]
            //public void GetUsersTest()
            //{
            //    var users = new List<tblUser>
            //{
            //    new tblUser
            //    {
            //        Email = "email@wp.pl",
            //        Login = "login",
            //        Password = "Password",
            //        Name = "Name",
            //        Surname = "Surname",
            //        PhoneNumber = "999888777",
            //        RegistrationDate = DateTime.Now
            //    },

            //    new tblUser
            //    {
            //    Email = "email2@wp.pl",
            //    Login = "login2",
            //    Password = "Password2",
            //    Name = "Name2",
            //    Surname = "Surname2",
            //    PhoneNumber = "9998887772",
            //    RegistrationDate = DateTime.Now
            //    },
            //    }.AsQueryable();

            //    var mockSet = new Mock<DbSet<tblUser>>();
            //    mockSet.As<IQueryable<tblUser>>().Setup(m => m.Provider).Returns(users.Provider);
            //    mockSet.As<IQueryable<tblUser>>().Setup(m => m.Expression).Returns(users.Expression);
            //    mockSet.As<IQueryable<tblUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
            //    mockSet.As<IQueryable<tblUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());


            //    var mockContext = new Mock<GoWithMeDBContext>();
            //    mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            //    var repo = new TblUserRepository(mockContext.Object);
            //    var usersDB = repo.GetUsers();

            //    Assert.AreEqual(2, usersDB.Count);
            //    Assert.AreEqual("login", usersDB[0].Login);
            //    Assert.AreEqual("login2", usersDB[1].Login);

            //}




        }
    }
}
