namespace NetCore21Angular.Engine.Validation.Configuration.Contract
{
    public interface IPeriodicElementValidationEngine
    {
        Infrastructure.ValidationError[] ValidatePeriodicElement(PeriodicElement periodicElement);
    }
}