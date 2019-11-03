using System;

namespace NetCoreAngular.Manager.Configuration
{
    public interface IPeopleManager
    {
        Person[] List();

        Infrastructure.ValidationError[] SavePerson(Person person);
    }

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