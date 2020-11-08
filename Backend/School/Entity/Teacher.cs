using Core;
using Core.Entities;
using NodaTime;

namespace School.Entity
{
    public class Teacher : Person, ICreated, IUpdated
    {
        public int TeacherId { get; set; }
        

        public int? SchoolId { get; set; }
        public School School { get; set; }


        public Instant Created { get; set; }
        public Instant Updated { get; set; }
    }
}