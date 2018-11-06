using NetCore21Angular.Database;
using Runtime.Mapper;
using System;
using System.Linq;

namespace NetCore21Angular.Resource.Configuration.Chemistry
{
    public class PeriodicElementResource : Contract.IPeriodicElementResource
    {
        private NetCore21AngularDbContext netCore21AngularDbContext;

        public PeriodicElementResource(NetCore21AngularDbContext netCore21AngularDbContext)
        {
            this.netCore21AngularDbContext = netCore21AngularDbContext;
        }

        public Contract.PeriodicElementHeader DetailPeriodicElementHeaderByPosition(int position)
        {
            return netCore21AngularDbContext.PeriodicElements.FirstOrDefault(x => x.Position == position).DeepCopyTo<Contract.PeriodicElementHeader>();
        }

        public Contract.PeriodicElement[] List()
        {
            Database.Models.PeriodicElement[] dbPeriodicElements = netCore21AngularDbContext.PeriodicElements.ToArray();

            // Logic for fetching data is the resposibility of the Resource => thus we have this here!
            if (dbPeriodicElements.Length == 0)
            {
                return new Contract.PeriodicElement[]
                {
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 1, Name = "Hydrogen", Weight = 1.0079M, Symbol = "H" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 2, Name = "Helium", Weight = 4.0026M, Symbol = "He" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 3, Name = "Lithium", Weight = 6.941M, Symbol = "Li" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 4, Name = "Beryllium", Weight = 9.0122M, Symbol = "Be" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 5, Name = "Boron", Weight = 10.811M, Symbol = "B" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 6, Name = "Carbon", Weight = 12.0107M, Symbol = "C" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 7, Name = "Nitrogen", Weight = 14.0067M, Symbol = "N" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 8, Name = "Oxygen", Weight = 15.9994M, Symbol = "O" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 9, Name = "Fluorine", Weight = 18.9984M, Symbol = "F" },
                    new Contract.PeriodicElement { ID = Guid.NewGuid(), Position = 10, Name = "Neon", Weight = 20.1797M, Symbol = "Ne" },
                };
            }

            return netCore21AngularDbContext.PeriodicElements.ToArray().DeepCopyTo<Contract.PeriodicElement[]>();
        }

        public Contract.PeriodicElement DetailPeriodicElementByID(Guid periodicElementID)
        {
            Contract.PeriodicElement resourcePeriodicElement = netCore21AngularDbContext.PeriodicElements.FirstOrDefault(x => x.ID == periodicElementID).DeepCopyTo<Contract.PeriodicElement>();

            // TODO - Attach Isotopes

            return resourcePeriodicElement;
        }

        public void SavePeriodicElement(Contract.PeriodicElement periodicElement)
        {
            Database.Models.PeriodicElement dbPeriodicElement = netCore21AngularDbContext.PeriodicElements.FirstOrDefault(x => x.ID == periodicElement.ID);

            if (dbPeriodicElement == null)
            {
                netCore21AngularDbContext.PeriodicElements.Add(dbPeriodicElement = new Database.Models.PeriodicElement() { ID = periodicElement.ID });
            }

            Mapper.Map(periodicElement, dbPeriodicElement);

            foreach (Contract.Isotope isotope in periodicElement.Isotopes)
            {
                Database.Models.Isotope dbIsotope = netCore21AngularDbContext.Isotopes.FirstOrDefault(x => x.ID == isotope.ID);

                if (dbIsotope == null)
                {
                    netCore21AngularDbContext.Isotopes.Add(dbIsotope = new Database.Models.Isotope() { ID = isotope.ID });
                }

                Mapper.Map(isotope, dbIsotope);
            }

            netCore21AngularDbContext.SaveChanges();
        }
    }
}