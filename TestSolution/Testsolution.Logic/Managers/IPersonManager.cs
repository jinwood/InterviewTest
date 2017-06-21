using System.Collections.Generic;
using Testsolution.Data.Entities;
using Testsolution.Data.Interfaces;

namespace Testsolution.Logic.Managers
{
    public interface IPersonManager
    {
        IList<Person> GetAll();
        Person Get(int id);
        IList<Person> GetPage(int index, int size);
    }
}
