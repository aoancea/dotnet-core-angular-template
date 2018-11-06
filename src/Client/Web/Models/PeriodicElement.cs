using System;

namespace NetCore21Angular.Client.Web.Models
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