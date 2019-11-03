using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Runtime.Mapper;
using System;

namespace NetCoreAngular.Client.Web
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PeriodicElementController : Controller
    {
        private readonly Manager.Configuration.Chemistry.Contract.IPeriodicElementManager periodicElementManager;

        public PeriodicElementController(Manager.Configuration.Chemistry.Contract.IPeriodicElementManager periodicElementManager)
        {
            this.periodicElementManager = periodicElementManager;
        }

        [HttpGet]
        public Models.PeriodicElementHeader DetailPeriodicElementHeaderByPosition(int position)
        {
            return periodicElementManager.DetailPeriodicElementHeaderByPosition(position).DeepCopyTo<Models.PeriodicElementHeader>();
        }

        [HttpGet]
        public Models.PeriodicElement[] ListPeriodicElements()
        {
            return periodicElementManager.List().DeepCopyTo<Models.PeriodicElement[]>();
        }

        [HttpGet]
        public Models.PeriodicElementForEdit LoadForEdit(Guid? periodicElementID)
        {
            return periodicElementManager.LoadForEdit(periodicElementID).DeepCopyTo<Models.PeriodicElementForEdit>();
        }

        [HttpPost]
        public Infrastructure.ValidationError[] SavePeriodicElement([FromBody]Models.PeriodicElement periodicElement)
        {
            if (periodicElement.ID == Guid.Empty)
                periodicElement.ID = Guid.NewGuid();

            Manager.Configuration.Chemistry.Contract.PeriodicElement managerPeriodicElement = periodicElement.DeepCopyTo<Manager.Configuration.Chemistry.Contract.PeriodicElement>();
            managerPeriodicElement.Isotopes = new Manager.Configuration.Chemistry.Contract.Isotope[0];

            return periodicElementManager.SavePeriodicElement(managerPeriodicElement);
        }

        [HttpDelete]
        public void DeletePeriodicElement(Guid periodicElementID)
        {
            periodicElementManager.DeletePeriodicElement(periodicElementID);
        }
    }
}