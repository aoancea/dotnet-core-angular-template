using System.Collections.Generic;

namespace NetCore21Angular.Engine.Validation.Configuration
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
            List<Infrastructure.ValidationError> errors = new List<Infrastructure.ValidationError>();

            Resource.Configuration.Chemistry.Contract.PeriodicElementHeader resourcePeriodicElementHeader = periodicElementResource.DetailPeriodicElementHeaderByPosition(periodicElement.Position);

            if (periodicElement.Position < 1)
            {
                errors.Add(new Infrastructure.ValidationError { Message = $"Position can't be lower than 1. Actual value {periodicElement.Position}" });
            }
            else if (periodicElement.Position > 118)
            {
                errors.Add(new Infrastructure.ValidationError { Message = $"Position can't be greater than 118. Actual value {periodicElement.Position}" });
            }

            if (resourcePeriodicElementHeader != null && resourcePeriodicElementHeader.ID != periodicElement.ID)
                errors.Add(new Infrastructure.ValidationError { Message = $"There's already a periodic element on position {periodicElement.Position}" });

            return errors.ToArray();
        }
    }
}