using Runtime.Mapper;
using System;
using System.Linq;

namespace NetCore21Angular.Manager.Configuration.Chemistry
{
    public class PeriodicElementManager : Contract.IPeriodicElementManager
    {
        private readonly Resource.Configuration.Chemistry.Contract.IPeriodicElementResource periodicElementResource;
        private readonly Engine.Validation.Configuration.Contract.IPeriodicElementValidationEngine periodicElementValidationEngine;

        public PeriodicElementManager(
            Resource.Configuration.Chemistry.Contract.IPeriodicElementResource periodicElementResource,
            Engine.Validation.Configuration.Contract.IPeriodicElementValidationEngine periodicElementValidationEngine)
        {
            this.periodicElementResource = periodicElementResource;
            this.periodicElementValidationEngine = periodicElementValidationEngine;
        }

        public Contract.PeriodicElementHeader DetailPeriodicElementHeaderByPosition(int position)
        {
            return periodicElementResource.DetailPeriodicElementHeaderByPosition(position).DeepCopyTo<Contract.PeriodicElementHeader>();
        }

        public Contract.PeriodicElement[] List()
        {
            return periodicElementResource.List().DeepCopyTo<Contract.PeriodicElement[]>();
        }

        public Contract.PeriodicElement DetailPeriodicElementByID(Guid periodicElementID)
        {
            return periodicElementResource.DetailPeriodicElementByID(periodicElementID).DeepCopyTo<Contract.PeriodicElement>();
        }

        public Infrastructure.ValidationError[] CreatePeriodicElement(Contract.PeriodicElement periodicElement)
        {
            Infrastructure.ValidationError[] validationErrors = periodicElementValidationEngine.ValidatePeriodicElement(periodicElement.DeepCopyTo<Engine.Validation.Configuration.Contract.PeriodicElement>());

            if (validationErrors.Any())
                return validationErrors;

            periodicElementResource.SavePeriodicElement(periodicElement.DeepCopyTo<Resource.Configuration.Chemistry.Contract.PeriodicElement>());

            return new Infrastructure.ValidationError[0];
        }

        public Infrastructure.ValidationError[] UpdatePeriodicElement(Contract.PeriodicElement periodicElement)
        {
            Infrastructure.ValidationError[] validationErrors = periodicElementValidationEngine.ValidatePeriodicElement(periodicElement.DeepCopyTo<Engine.Validation.Configuration.Contract.PeriodicElement>());

            if (validationErrors.Any())
                return validationErrors;

            periodicElementResource.SavePeriodicElement(periodicElement.DeepCopyTo<Resource.Configuration.Chemistry.Contract.PeriodicElement>());

            return new Infrastructure.ValidationError[0];
        }
    }
}