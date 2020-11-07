using NodaTime;
using NodaTime.Extensions;
using School.Entity;

namespace School.Dto
{
    public class TeacherDtoFactory
    {
        private readonly IClock _clock;

        public TeacherDtoFactory(IClock clock)
        {
            _clock = clock;
        }

        public TeacherDto CreateDto(Teacher teacher)
        {
            return new TeacherDto()
            {
                DateOfBirth = teacher.DateOfBirth,
                FamilyName = teacher.FamilyName,
                GivenName = teacher.GivenName,
                TeacherId = teacher.TeacherId,
                Age = teacher.Age(_clock.InTzdbSystemDefaultZone().GetCurrentDate()),
                Address = teacher.Address
            };
        }
    }


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