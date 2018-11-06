using System;

namespace NetCore21Angular.Resource.Configuration.Chemistry.Contract
{
    // we might even need to rename this to ChemistryResource
    public interface IPeriodicElementResource
    {
        PeriodicElement[] List();

        // TODO - Switch to load by ID instead
        PeriodicElement DetailPeriodicElementByPosition(int position);

        PeriodicElementHeader DetailPeriodicElementHeaderByPosition(int position);

        PeriodicElement DetailPeriodicElementByID(Guid periodicElementID);

        void SavePeriodicElement(PeriodicElement periodicElement);
    }
}