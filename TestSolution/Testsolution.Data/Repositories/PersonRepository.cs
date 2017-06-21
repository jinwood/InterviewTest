namespace Testsolution.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Entities;
    using Interfaces;
    using Newtonsoft.Json;

    public class PersonRepository : IPersonRepository
    {
        public List<Person> personRepo = new List<Person>();
        public PersonRepository()
        {
            LoadRepo();
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
            var result = personRepo.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            return result;
        }

        private void LoadRepo()
        {
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(@"~/bin/Data/MOCK_DATA.json")))
            {
                var json = reader.ReadToEnd();
                personRepo = JsonConvert.DeserializeObject<List<Person>>(json);
            }
        }

    }
}
