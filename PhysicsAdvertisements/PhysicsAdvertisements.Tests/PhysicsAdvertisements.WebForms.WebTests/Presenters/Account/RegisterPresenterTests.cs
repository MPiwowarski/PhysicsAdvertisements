using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PhysicsAdvertisements.Model;
using Moq;
using PhysicsAdvertisements.WebForms.Web.Forms.Account;
using PhysicsAdvertisements.WebForms.Web.Presenters.Account;
using PhysicsAdvertisements.Repository.Repo;
using System.Data.Entity;
using System.Linq;
using PhysicsAdvertisements.WebForms.Web.App_Start;
using NUnit.Framework;

namespace PhysicsAdvertisements.Tests.PhysicsAdvertisements.WebForms.WebTests.Presenters.Account
{
    [TestFixture]
    public class RegisterPresenterTests
    {
        [TestCase("Login1")]
        [TestCase("Login2")]
        [TestCase("tmp")]
        public void CheckIfLoginIsLoginFree_GivenTwoSampleRecordsInUserTable_ReturnsFalse(string givenLogin)
        {
            //Arrange
            var sampleUserTable = new List<User>()
            {
                new User()
                {
                    Login="Login1"
                },
                new User()
                {
                    Login="Login2"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(sampleUserTable.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(sampleUserTable.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(sampleUserTable.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(sampleUserTable.GetEnumerator());
          
            Mock<IRegisterView> registerView = new Mock<IRegisterView>();
            var userRepo = new Mock<IUserRepo>();                  
            userRepo.Setup(x => x.Table).Returns(mockSet.Object);                    
            RegisterPresenter registerPresenter = new RegisterPresenter(registerView.Object);
        
            registerView.Setup(x => x.UserRepo).Returns(userRepo.Object);
            registerView.Setup(x => x.LoginControl_Text).Returns(givenLogin);

            bool result = false;

            //Act
            UnityWebFormsBootstrapper.Initialize();
            if (registerPresenter.CheckIsLoginFree())
            {
                result = true;
            }

            //Assert
            NUnit.Framework.Assert.IsFalse(result);

        }
    }
}
