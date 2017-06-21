using System.Collections.Generic;
using Testsolution.Data.Entities;

namespace Testsolution.Logic.Managers
{
    //added interface to allow unit testing
    public interface IPersonManager
    {
        IList<Person> GetAll();
        Person Get(int id);
        IList<Person> GetPage(int index, int size);
    }
}
