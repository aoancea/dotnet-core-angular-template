namespace NetCore21Angular.Engine.Validation
{
    public class PeriodicElementValidationEngine : Contract.IPeriodicElementValidationEngine
    {
        private readonly Resource.Configuration.Chemistry.Contract.IPeriodicElementResource periodicElementResource;

        public PeriodicElementValidationEngine(Resource.Configuration.Chemistry.Contract.IPeriodicElementResource periodicElementResource)
        {
            this.periodicElementResource = periodicElementResource;
        }

        public Infrastructure.ValidationError[] ValidatePeriodicElement(Contract.PeriodicElement periodicElement)
        {
            Resource.Configuration.Chemistry.Contract.PeriodicElementHeader periodicElementHeader = periodicElementResource.DetailPeriodicElementHeaderByPosition(periodicElement.Position);

            if (periodicElementHeader != null && periodicElementHeader.ID != periodicElement.ID)
                return new Infrastructure.ValidationError[1] { new Infrastructure.ValidationError { Message = $"There's already a periodic element on position {periodicElement.Position}" } };

            return new Infrastructure.ValidationError[0];
        }
    }
}