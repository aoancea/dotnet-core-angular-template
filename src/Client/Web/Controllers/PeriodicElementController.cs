﻿using Microsoft.AspNetCore.Mvc;
using Runtime.Mapper;
using System;

namespace NetCore21Angular.Client.Web.Controllers
{
    public class PeriodicElementController : Controller
    {
        private readonly Manager.Configuration.Chemistry.Contract.IPeriodicElementManager periodicElementManager;

        public PeriodicElementController(Manager.Configuration.Chemistry.Contract.IPeriodicElementManager periodicElementManager)
        {
            this.periodicElementManager = periodicElementManager;
        }

        public Models.PeriodicElement[] ListPeriodicElements()
        {
            return periodicElementManager.List().DeepCopyTo<Models.PeriodicElement[]>();
        }

        public Models.PeriodicElement DetailPeriodicElementByPosition(int position)
        {
            return periodicElementManager.DetailPeriodicElementByPosition(position).DeepCopyTo<Models.PeriodicElement>();
        }

        public Models.PeriodicElement GetPeriodicElementByID(Guid periodicElementID)
        {
            return periodicElementManager.DetailPeriodicElementByID(periodicElementID).DeepCopyTo<Models.PeriodicElement>();
        }

        [HttpPost]
        public Infrastructure.ValidationError[] CreatePeriodicElement([FromBody]Models.PeriodicElement periodicElement)
        {
            Manager.Configuration.Chemistry.Contract.PeriodicElement managerPeriodicElement = periodicElement.DeepCopyTo<Manager.Configuration.Chemistry.Contract.PeriodicElement>();
            managerPeriodicElement.ID = Guid.NewGuid();
            managerPeriodicElement.Isotopes = new Manager.Configuration.Chemistry.Contract.Isotope[0];

            return periodicElementManager.CreatePeriodicElement(managerPeriodicElement);
        }

        [HttpPost]
        public Infrastructure.ValidationError[] UpdatePeriodicElement([FromBody]Models.PeriodicElement periodicElement)
        {
            Manager.Configuration.Chemistry.Contract.PeriodicElement managerPeriodicElement = periodicElement.DeepCopyTo<Manager.Configuration.Chemistry.Contract.PeriodicElement>();
            managerPeriodicElement.Isotopes = new Manager.Configuration.Chemistry.Contract.Isotope[0];

            return periodicElementManager.UpdatePeriodicElement(managerPeriodicElement);
        }
    }
}