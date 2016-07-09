using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shiftwise._52cards.mvc.WebApi;
using Shiftwise._52cards.mvc.WebApi.Controllers;

namespace Shiftwise._52cards.mvc.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
