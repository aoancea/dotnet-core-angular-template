namespace NetCore21Angular.Engine.Validation.Contract
{
    public interface IPeriodicElementValidationEngine
    {
        Infrastructure.ValidationError[] ValidatePeriodicElement(PeriodicElement periodicElement);
    }
}