using System;

namespace NetCore21Angular.Manager.Configuration.Chemistry.Contract
{
    public class PeriodicElement
    {
        public Guid ID { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public string Symbol { get; set; }
    }
}