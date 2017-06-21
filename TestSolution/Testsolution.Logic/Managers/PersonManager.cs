using System.Collections.Generic;

namespace Testsolution.Logic.Managers
{
    using Data.Entities;
    using Data.Interfaces;
    using System;

    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            if (personRepository != null) this.personRepository = personRepository;
            else throw new ArgumentNullException();
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
