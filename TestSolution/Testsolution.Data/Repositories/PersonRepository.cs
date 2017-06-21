namespace Testsolution.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Entities;
    using Interfaces;
    using Newtonsoft.Json;

    public class PersonRepository : IPersonRepository
    {
        private readonly IStreamProvider _streamProvider;

        public List<Person> personRepo = new List<Person>();

        public PersonRepository(IStreamProvider streamProvider)
        {
            if (streamProvider != null) _streamProvider = streamProvider; else throw new ArgumentNullException();

            //split out the stream implementation so that the test project
            //can use its own data source
            personRepo = LoadRepo(_streamProvider.GetStreamReader());
        }

        public Person Get(int id)
        {
            return personRepo.FirstOrDefault(x => x.Id == id);
        }

        public IList<Person> GetAll()
        {
            return personRepo;
        }

        public IList<Person> GetPage(int pageIndex, int pageSize)
        {
            return personRepo.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        //stream reader implementation is now passed in instead of being hard coded
        private List<Person> LoadRepo(StreamReader reader)
        {
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }
    }
}
