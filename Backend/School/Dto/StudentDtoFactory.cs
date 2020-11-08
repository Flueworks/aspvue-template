using NodaTime;
using NodaTime.Extensions;
using School.Entity;

namespace School.Dto
{
    public class StudentDtoFactory
    {
        private readonly IClock _clock;

        public StudentDtoFactory(IClock clock)
        {
            _clock = clock;
        }

        public StudentDto CreateDto(Student student)
        {
            return new StudentDto()
            {
                DateOfBirth = student.DateOfBirth,
                FamilyName = student.FamilyName,
                GivenName = student.GivenName,
                StudentId = student.StudentId,
                Age = student.Age(_clock.InTzdbSystemDefaultZone().GetCurrentDate()),
                Address = student.Address
            };
        }
    }
}