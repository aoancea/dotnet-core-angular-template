using NetCoreAngular.Database;
using Runtime.Mapper;
using System.Linq;

namespace NetCoreAngular.Resource.Configuration
{
    public class PeopleResource : IPeopleResource
    {
        private NetCoreAngularDbContext NetCoreAngularDbContext;

        public PeopleResource(NetCoreAngularDbContext NetCoreAngularDbContext)
        {
            this.NetCoreAngularDbContext = NetCoreAngularDbContext;
        }

        public Person[] List()
        {
            return NetCoreAngularDbContext.People.ToArray().DeepCopyTo<Person[]>();
        }

        public void SavePerson(Person person)
        {
            Database.Models.Person dbPerson = NetCoreAngularDbContext.People.FirstOrDefault(x => x.Id == person.Id);

            if (dbPerson == null)
            {
                NetCoreAngularDbContext.People.Add(dbPerson = new Database.Models.Person() { Id = person.Id });
            }

            Mapper.Map(person, dbPerson);

            NetCoreAngularDbContext.SaveChanges();
        }
    }
}