using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhysicsAdvertisements.WebForms.Web.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using PhysicsAdvertisements.WebForms.Web.Forms.Home;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.ControlTemplates;
using Moq;

namespace PhysicsAdvertisements.Tests.PhysicsAdvertisements.WebForms.WebTests.FormsTests.HomeTests
{

    [TestClass]
    public class HomeTest
    {
        [TestMethod]
        public void CheckIfMessageSendProperly_GivenSampleText_ReturnsTrue()
        {
            Mock<IHomeView> _homeView=new Mock<IHomeView>();
           
            HomePresenter _homePresenter = new HomePresenter(_homeView.Object);


            _homeView.Setup(x => x.FeedbackContent_Text).Returns("sample text");
            var result = false;

            if (_homeView.Object.FeedbackContent_Text != "")
            {
                result = _homePresenter.SendFeedback_Click();
            }

            Assert.IsTrue(result);
        }
    }
}
