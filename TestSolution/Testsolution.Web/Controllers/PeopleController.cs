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
            //used to seeing (perhaps and environement issue, i'm not sure), so 
            //I've resorted to the single line if else above for brievety

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

        //new server side paged endpoint, this could be changed to a post
        //and the parameters moved into the body (I don't like having a route
        //with more than one parameter in the address)
        [HttpGet]
        [Route("GetPage/{index}")]
        public object GetPage(int index, int size = 10)
        {
            return this.personManager.GetPage(index, size);
        }
    }
}
