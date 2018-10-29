using Microsoft.AspNetCore.Mvc;

namespace NetCore21Angular.Web.Controllers
{
    public class PeriodicElementController : Controller
    {
        public Models.PeriodicElement[] ListPeriodicElements()
        {
            return new Models.PeriodicElement[]
            {
                new Models.PeriodicElement { Position = 1, Name = "Hydrogen", Weight = 1.0079M, Symbol = "H" },
                new Models.PeriodicElement { Position = 2, Name = "Helium", Weight = 4.0026M, Symbol = "He" },
                new Models.PeriodicElement { Position = 3, Name = "Lithium", Weight = 6.941M, Symbol = "Li" },
                new Models.PeriodicElement { Position = 4, Name = "Beryllium", Weight = 9.0122M, Symbol = "Be" },
                new Models.PeriodicElement { Position = 5, Name = "Boron", Weight = 10.811M, Symbol = "B" },
                new Models.PeriodicElement { Position = 6, Name = "Carbon", Weight = 12.0107M, Symbol = "C" },
                new Models.PeriodicElement { Position = 7, Name = "Nitrogen", Weight = 14.0067M, Symbol = "N" },
                new Models.PeriodicElement { Position = 8, Name = "Oxygen", Weight = 15.9994M, Symbol = "O" },
                new Models.PeriodicElement { Position = 9, Name = "Fluorine", Weight = 18.9984M, Symbol = "F" },
                new Models.PeriodicElement { Position = 10, Name = "Neon", Weight = 20.1797M, Symbol = "Ne" },
            };
        }
    }
}