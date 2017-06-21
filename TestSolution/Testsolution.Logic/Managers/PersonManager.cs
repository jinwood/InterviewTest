using System.Collections.Generic;

namespace Testsolution.Logic.Managers
{
    using Data.Entities;
    using Data.Interfaces;

    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public IList<Person> GetAll()
        {
            return this.personRepository.GetAll();
        }

        public Person Get(int id)
        {
            return this.personRepository.Get(id);
        }

        public IList<Person> GetPage(int index, int size)
        {
            return this.personRepository.GetPage(index, size);
        }
    }
}
