using NetCore21Angular.Database;
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

        public Contract.PeriodicElement[] List()
        {
            // TODO - Resource - Configuration - Use DeepCopyTo<T[]>();
            return netCore21AngularDbContext.PeriodicElement.ToArray().Select(x => new Contract.PeriodicElement
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