using System;

namespace NetCoreAngular.Database.Models
{
    public class Isotope
    {
        public Guid ID { get; set; }

        public Guid PeriodicElementID { get; set; }

        public string NuclideSymbol { get; set; }

        public int Z { get; set; }

        public int N { get; set; }

        public string IsotopicMass { get; set; }

        public string DecayModes { get; set; }

        public string DaughterIsotope { get; set; }

        public string NuclearSpinAndParity { get; set; }
    }
}