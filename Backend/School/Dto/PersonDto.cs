using NodaTime;
using School.Entity;

namespace School.Dto
{
    public class PersonDto
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }

        public Address Address { get; set; }

        public LocalDate DateOfBirth { get; set; }

        public int Age { get; set; }
    }

    public class PersonInputDto
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }

        public Address Address { get; set; }

        public LocalDate DateOfBirth { get; set; }
    }
}