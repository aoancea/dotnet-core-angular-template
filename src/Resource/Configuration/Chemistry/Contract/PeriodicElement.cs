using System;

namespace NetCoreAngular.Resource.Configuration.Chemistry.Contract
{
    public class PeriodicElementHeader
    {
        public Guid ID { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public string Symbol { get; set; }
    }

    public class PeriodicElement : PeriodicElementHeader
    {
        public Isotope[] Isotopes { get; set; }
    }
}