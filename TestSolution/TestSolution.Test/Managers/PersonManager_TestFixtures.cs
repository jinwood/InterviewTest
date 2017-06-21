using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Testsolution.Data.Entities;
using Testsolution.Data.Interfaces;
using Testsolution.Logic.Managers;

namespace TestSolution.Test.Managers
{
    [TestClass]
    public class PersonManager_TestFixtures
    {
        private IPersonManager _personManager;
        private readonly Mock<IPersonRepository> _mockRepository = new Mock<IPersonRepository>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonManager_NullRespository_ThrowsArgumentNullException()
        {
            //act
            _personManager = new PersonManager(null);
        }

        [TestMethod]
        public void GetAll_CallsPersonRepository()
        {
            //arrange
            _mockRepository.ResetCalls();
            _mockRepository.Setup(x => x.GetAll()).Returns(new List<Person>());

            //act
            var result = _mockRepository.Object.GetAll();

            //assert
            _mockRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetPerson_CallsPersonRepository()
        {
            //arrange
            const int id = 1;
            _mockRepository.ResetCalls();
            _mockRepository.Setup(x => x.Get(id)).Returns(new Person());

            //act
            var result = _mockRepository.Object.Get(id);

            //assert
            _mockRepository.Verify(x => x.Get(id), Times.Once);
        }

        [TestMethod]
        public void GetPage_CallsPersonRepository()
        {
            //arrange
            const int index = 0;
            const int size = 10;
            _mockRepository.ResetCalls();
            _mockRepository.Setup(x => x.GetPage(index, size)).Returns(new List<Person>());

            //act
            var result = _mockRepository.Object.GetPage(index, size);

            //assert
            _mockRepository.Verify(x => x.GetPage(index, size), Times.Once);
        }
    }
}
