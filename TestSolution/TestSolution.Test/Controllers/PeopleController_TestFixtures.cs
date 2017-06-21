using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Testsolution.Data.Entities;
using Testsolution.Logic.Managers;
using Testsolution.Web.Controllers;

namespace TestSolution.Test.Controllers
{
    [TestClass]
    public class PeopleController_TestFixtures
    {
        PeopleController controller;
        private readonly Mock<IPersonManager> _mockPersonManager = new Mock<IPersonManager>();

        [TestInitialize]
        public void Initialize()
        {
            controller = ControllerHelper.GetInitializedPeopleController(_mockPersonManager.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PeopleController_NullRepository_ThrowsException()
        {
            //act
            controller = new PeopleController(null);
        }

        [TestMethod]
        public void GetAll_CallsPersonManager_()
        {
            //arrange
            _mockPersonManager.ResetCalls();
            _mockPersonManager.Setup(x => x.GetAll()).Returns(new List<Person>());

            //act
            var result = controller.GetAll();

            //assert
            _mockPersonManager.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetPerson_CallsPersonManager_()
        {
            //arrange
            const int id = 1;
            _mockPersonManager.ResetCalls();
            _mockPersonManager.Setup(x => x.Get(id)).Returns(new Person());

            //act
            var result = controller.GetAll();

            //assert
            _mockPersonManager.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetPage_CallsPersonManager_()
        {
            //arrange
            const int index = 0;
            const int size = 10;
            _mockPersonManager.ResetCalls();
            _mockPersonManager.Setup(x => x.GetPage(index, size)).Returns(new List<Person>());

            //act
            var result = controller.GetAll();

            //assert
            _mockPersonManager.Verify(x => x.GetAll(), Times.Once);
        }
    }

    public class ControllerHelper
    {
        private const string Url = "http://localhost/";

        public static PeopleController GetInitializedPeopleController(IPersonManager manager)
        {
            var controller = new PeopleController(manager)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri(Url) },
                Configuration = new HttpConfiguration()
            };

            controller.Configuration.MapHttpAttributeRoutes();
            controller.Configuration.EnsureInitialized();

            return controller;
        }
    }
}
