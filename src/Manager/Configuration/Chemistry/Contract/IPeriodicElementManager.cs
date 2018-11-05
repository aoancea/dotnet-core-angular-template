namespace NetCore21Angular.Manager.Configuration.Chemistry.Contract
{
    public interface IPeriodicElementManager
    {
        PeriodicElement[] List();

        PeriodicElement GetPeriodicElementByPosition(int position);

        Infrastructure.ValidationError[] CreatePeriodicElement(PeriodicElement periodicElement);
    }
}