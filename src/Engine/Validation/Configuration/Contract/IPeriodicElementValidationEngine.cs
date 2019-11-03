namespace NetCoreAngular.Engine.Validation.Configuration.Contract
{
    public interface IPeriodicElementValidationEngine
    {
        Infrastructure.ValidationError[] ValidatePeriodicElement(PeriodicElement periodicElement);
    }
}