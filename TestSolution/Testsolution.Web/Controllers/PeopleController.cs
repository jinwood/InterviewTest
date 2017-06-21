namespace Testsolution.Web.Controllers
{
    using System.Web.Http;
    using Logic.Managers;
    using System;

    [RoutePrefix("People")]
    public class PeopleController : ApiController
    {
        private readonly IPersonManager personManager;

        public PeopleController(IPersonManager personManager)
        {
            if (personManager != null) this.personManager = personManager; else throw new ArgumentNullException();
            //this.personManager = personManager ?? throw new ArgumentNullException();
            //is the syntax I'd typically use but this is throwing an error I'm not 
            //used to seeing (perhaps and environement issue, i'm not sure), so I've resorted to the single line if else above

        }

        [HttpGet]
        [Route("GetAll")]
        public object GetAll()
        {
            return this.personManager.GetAll();
        }

        [HttpGet]
        [Route("GetPerson/{id}")]
        public object Get(int id)
        {
            return this.personManager.Get(id);
        }

        [HttpGet]
        [Route("GetPage/{index}")]
        public object GetPage(int index, int size = 10)
        {
            return this.personManager.GetPage(index, size);
        }
    }
}
