using Microsoft.AspNetCore.Mvc;
using Runtime.Mapper;

namespace NetCore21Angular.Web.Controllers
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
    }
}