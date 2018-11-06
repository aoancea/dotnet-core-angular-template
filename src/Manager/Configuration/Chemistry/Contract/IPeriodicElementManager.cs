using System;

namespace NetCore21Angular.Manager.Configuration.Chemistry.Contract
{
    public interface IPeriodicElementManager
    {
        PeriodicElement DetailPeriodicElementByPosition(int position);

        PeriodicElement[] List();

        PeriodicElement DetailPeriodicElementByID(Guid periodicElementID);

        Infrastructure.ValidationError[] CreatePeriodicElement(PeriodicElement periodicElement);

        Infrastructure.ValidationError[] UpdatePeriodicElement(PeriodicElement periodicElement);
    }
}