using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            // TODO - Web - Use DeepCopyTo<T[]>();
            return periodicElementManager.List().Select(x => new Models.PeriodicElement
            {
                Name = x.Name,
                Position = x.Position,
                Symbol = x.Symbol,
                Weight = x.Weight
            }).ToArray();
        }
    }
}