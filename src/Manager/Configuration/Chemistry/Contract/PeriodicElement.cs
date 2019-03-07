﻿using System;

namespace NetCore21Angular.Manager.Configuration.Chemistry.Contract
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

    public class PeriodicElementForEdit
    {
        public PeriodicElement PeriodicElement { get; set; }
    }
}