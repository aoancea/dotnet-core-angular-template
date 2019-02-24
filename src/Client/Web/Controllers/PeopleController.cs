using Microsoft.AspNetCore.Mvc;
using Runtime.Mapper;
using System;

namespace NetCore21Angular.Client.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Manager.Configuration.IPeopleManager peopleManager;

        public PeopleController(Manager.Configuration.IPeopleManager peopleManager)
        {
            this.peopleManager = peopleManager;
        }
        // 
        [HttpGet]
        public Models.Person[] ListPeople()
        {
            return peopleManager.List().DeepCopyTo<Models.Person[]>();
        }

        [HttpPost]
        public Infrastructure.ValidationError[] SavePerson([FromBody]Models.Person person)
        {
            if (person.Id == Guid.Empty)
                person.Id = Guid.NewGuid();

            Manager.Configuration.Person managerPerson = person.DeepCopyTo<Manager.Configuration.Person>();

            return peopleManager.SavePerson(managerPerson);
        }
    }
}