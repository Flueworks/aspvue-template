using Core;
using NodaTime;

namespace School.Entity
{
    public class Teacher : ICreated, IUpdated
    {
        public int TeacherId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public LocalDate DateOfBirth { get; set; }

        public int Age(LocalDate at) => Period.Between(DateOfBirth, at).Years;


        public int? SchoolId { get; set; }
        public School School { get; set; }


        public Instant Created { get; set; }
        public Instant Updated { get; set; }
    }
}