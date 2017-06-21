using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testsolution.Data.Interfaces;
using System.IO;
using Testsolution.Data.Repositories;
using System.Text;
using System.Linq;

namespace TestSolution.Test.Repositories
{
    [TestClass]
    public class PersonRepository_TestFixtures
    {
        private const string _testData = "[{\"id\":1,\"firstname\":\"Fletch\",\"lastname\":\"Sirey\",\"email\":\"fsirey0 @wunderground.com\",\"company\":\"Photolist\",\"country\":\"China\"},{ \"id\":2,\"firstname\":\"Hamlin\",\"lastname\":\"Bakes\",\"email\":\"hbakes1@gizmodo.com\",\"company\":\"Youspan\",\"country\":\"Brazil\"},{\"id\":3,\"firstname\":\"Rivy\",\"lastname\":\"Lotherington\",\"email\":\"rlotherington2@chronoengine.com\",\"company\":\"Buzzster\",\"country\":\"Brazil\"},{\"id\":4,\"firstname\":\"Othilie\",\"lastname\":\"Guidoni\",\"email\":\"oguidoni3@answers.com\",\"company\":\"Jabbercube\",\"country\":\"Sweden\"},{\"id\":5,\"firstname\":\"Bellina\",\"lastname\":\"Tudhope\",\"email\":\"btudhope4@amazon.co.uk\",\"company\":\"Realfire\",\"country\":\"Philippines\"}]";
        private IPersonRepository _personRepository;

        public PersonRepository_TestFixtures()
        {
            _personRepository = new PersonRepository(new TestStreamProvider());
        }

        [TestMethod]
        public void PersonRepository_GetPersonById_MustGetPersonById()
        {
            //arrange
            const int id = 1;

            //act
            var result = _personRepository.Get(id);

            //assert
            Assert.AreEqual("Fletch", result.FirstName);
        }

        [TestMethod]
        public void PersonRepository_GetAll_MustReturnAllEntities()
        {
            //act
            var result = _personRepository.GetAll();

            //assert
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void PersonRepository_GetPageWithIndex0Size1_ReturnsCorrectEntitiy()
        {
            //arrange
            const int index = 0;
            const int size = 2;

            //act
            var result = _personRepository.GetPage(index, size);

            //assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Fletch", result.FirstOrDefault().FirstName);
            Assert.AreEqual("Hamlin", result.LastOrDefault().FirstName);
        }
        

        public class TestStreamProvider : IStreamProvider
        {
            public StreamReader GetStreamReader()
            {
                var byteArray = Encoding.ASCII.GetBytes(_testData);
                return new StreamReader(new MemoryStream(byteArray));
            }
        }
    }
}
