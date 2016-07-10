using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shiftwise._52cards.mvc.App;
using Shiftwise._52cards.mvc.App.Controllers;

namespace Shiftwise52cards.mvc.App.Tests.Unit_Test
{
    [TestClass]
    public class MvcControllerUnitTest
    {
        public TestContext TestContext { get; set; }  //for trace debuggibg
        
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Mvc_52CardController__52card_ActionResult_returns_ViewResult()
        {
            // Arrange
            _52CardController controller = new _52CardController();
            bool caught = false;
            ViewResult result = null;
            // Act
            try 
	        {	        
                result = controller._52card() as ViewResult;
               //throw new Exception();

	        }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("Mvc_52CardController__52card_ActionResult_returns_ViewResult exception{0}", ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(2, result.ViewEngineCollection.Count);
            //Assert.AreEqual("_52card", result.ViewData["Title"]);
        }

        [TestMethod]
        public void Mvc_52CardController_About_ActionResult_returns_ViewResult()
        {
            // Arrange
            _52CardController controller = new _52CardController();
            bool caught = false;
            ViewResult result = null;
            // Act
            try 
	        {	        
                result = controller.About() as ViewResult;
	        }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("Mvc_52CardController_About_ActionResult_returns_ViewResult exception{0}", ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(2, result.ViewEngineCollection.Count);
            //Assert.AreEqual("_52card", result.ViewData["Title"]);
        }

    }

}
