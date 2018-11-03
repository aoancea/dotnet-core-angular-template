namespace NetCore21Angular.Resource.Configuration.Chemistry.Contract
{
    // we might even need to rename this to ChemistryResource
    public interface IPeriodicElementResource
    {
        PeriodicElement[] List();

        PeriodicElement DetailPeriodicElementByPosition(int position);

        void SavePeriodicElement(PeriodicElement periodicElement);
    }
}
