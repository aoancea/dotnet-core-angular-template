using System;

namespace NetCoreAngular.Client.Web.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public BloodType? BloodType { get; set; }

        public BloodTypePH? BloodTypePH { get; set; }
    }

    public enum BloodType
    {
        A,
        B,
        AB,
        Zero
    }

    public enum BloodTypePH
    {
        Negative,
        Positive
    }
}