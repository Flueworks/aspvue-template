using Core.Dto;
using Core.Entities;
using NodaTime;
using NodaTime.Extensions;
using School.Entity;

namespace School.Dto
{
    public record TeacherDto(int TeacherId, string GivenName, string FamilyName, Address Address, LocalDate DateOfBirth, int Age) : PersonDto(GivenName, FamilyName, Address, DateOfBirth, Age);

    public record TeacherInputDto : PersonInputDto
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
            return new TeacherDto(
                teacher.TeacherId,
                teacher.GivenName,
                teacher.FamilyName,
                teacher.Address,
                teacher.DateOfBirth,
                teacher.Age(_clock.InTzdbSystemDefaultZone().GetCurrentDate())
            );
        }
    }
}