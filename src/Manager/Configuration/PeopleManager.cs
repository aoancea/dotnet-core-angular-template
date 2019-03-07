using Runtime.Mapper;

namespace NetCore21Angular.Manager.Configuration
{
    public class PeopleManager : IPeopleManager
    {
        private readonly Resource.Configuration.IPeopleResource peopleResource;

        public PeopleManager(Resource.Configuration.IPeopleResource peopleResource)
        {
            this.peopleResource = peopleResource;
        }

        public Person[] List()
        {
            return peopleResource.List().DeepCopyTo<Person[]>();
        }

        public Infrastructure.ValidationError[] SavePerson(Person person)
        {
            peopleResource.SavePerson(person.DeepCopyTo<Resource.Configuration.Person>());

            return new Infrastructure.ValidationError[0];
        }
    }
}