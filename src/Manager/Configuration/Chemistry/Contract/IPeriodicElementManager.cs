using System;

namespace NetCore21Angular.Manager.Configuration.Chemistry.Contract
{
    public interface IPeriodicElementManager
    {
        PeriodicElementHeader DetailPeriodicElementHeaderByPosition(int position);

        PeriodicElement[] List();

        PeriodicElementForEdit LoadForEdit(Guid? periodicElementID);

        Infrastructure.ValidationError[] SavePeriodicElement(PeriodicElement periodicElement);

        void DeletePeriodicElement(Guid periodicElementID);
    }
}