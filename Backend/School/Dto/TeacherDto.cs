using Core.Dto;
using Core.Entities;
using NodaTime;
using NodaTime.Extensions;
using School.Entity;

namespace School.Dto
{
    public class TeacherDto : PersonDto
    {
        public int TeacherId { get; set; }
        
    }

    public class TeacherInputDto : PersonInputDto
    {

    }

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
}