using NetCore21Angular.Database;
using Runtime.Mapper;
using System.Linq;

namespace NetCore21Angular.Resource.Configuration
{
    public class PeopleResource : IPeopleResource
    {
        private NetCore21AngularDbContext netCore21AngularDbContext;

        public PeopleResource(NetCore21AngularDbContext netCore21AngularDbContext)
        {
            this.netCore21AngularDbContext = netCore21AngularDbContext;
        }

        public Person[] List()
        {
            return netCore21AngularDbContext.People.ToArray().DeepCopyTo<Person[]>();
        }

        public void SavePerson(Person person)
        {
            Database.Models.Person dbPerson = netCore21AngularDbContext.People.FirstOrDefault(x => x.Id == person.Id);

            if (dbPerson == null)
            {
                netCore21AngularDbContext.People.Add(dbPerson = new Database.Models.Person() { Id = person.Id });
            }

            Mapper.Map(person, dbPerson);

            netCore21AngularDbContext.SaveChanges();
        }
    }
}