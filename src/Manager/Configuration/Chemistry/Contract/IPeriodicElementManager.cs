using System;

namespace NetCore21Angular.Manager.Configuration.Chemistry.Contract
{
    public interface IPeriodicElementManager
    {
        PeriodicElement[] List();

        PeriodicElement GetPeriodicElementByPosition(int position);

        PeriodicElement DetailPeriodicElementByID(Guid periodicElementID);

        Infrastructure.ValidationError[] CreatePeriodicElement(PeriodicElement periodicElement);

        Infrastructure.ValidationError[] UpdatePeriodicElement(PeriodicElement periodicElement);
    }
}