using System.Linq;

namespace NetCore21Angular.Manager.Configuration.Chemistry
{
    public class PeriodicElementManager : Contract.IPeriodicElementManager
    {
        private readonly Resource.Configuration.Chemistry.Contract.IPeriodicElementResource periodicElementResource;

        public PeriodicElementManager(Resource.Configuration.Chemistry.Contract.IPeriodicElementResource periodicElementResource)
        {
            this.periodicElementResource = periodicElementResource;
        }

        public Contract.PeriodicElement[] List()
        {
            // TODO - Manager - Configuration - Use DeepCopyTo<T[]>();
            return periodicElementResource.List().Select(x => new Contract.PeriodicElement
            {
                ID = x.ID,
                Name = x.Name,
                Position = x.Position,
                Symbol = x.Symbol,
                Weight = x.Weight
            }).ToArray();
        }
    }
}