using NodaTime;
using School.Entity;

namespace School.Dto
{
    public class GradeDto
    {
        public int GradeId { get; set; }

        public int StudentId { get; set; }

        public GradeType Value { get; set; }

        public string Course { get; set; }

        public int GradingTeacherId { get; set; }


        public Instant Created { get; set; }
        public Instant Updated { get; set; }
    }
}