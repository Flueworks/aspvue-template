using NodaTime;

namespace School.Entity
{
    public abstract class Person
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }

        public Address Address { get; set; }

        public LocalDate DateOfBirth { get; set; }
        public int Age(LocalDate at) => Period.Between(DateOfBirth, at).Years;

    }
}