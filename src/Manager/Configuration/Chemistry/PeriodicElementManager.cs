using Runtime.Mapper;

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
            return periodicElementResource.List().DeepCopyTo<Contract.PeriodicElement[]>();
        }

        public Contract.PeriodicElement GetPeriodicElementByPosition(int position)
        {
            return periodicElementResource.DetailPeriodicElementByPosition(position).DeepCopyTo<Contract.PeriodicElement>();
        }
    }
}