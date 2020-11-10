using Core.Dto;
using Core.Entities;
using NodaTime;
using NodaTime.Extensions;
using School.Entity;

namespace School.Dto
{
    public record StudentDto(int StudentId, string GivenName, string FamilyName, Address Address, LocalDate DateOfBirth, int Age) : PersonDto(GivenName, FamilyName, Address, DateOfBirth, Age);

    public record StudentInputDto : PersonInputDto
    {

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
            return new StudentDto(
                student.StudentId,
                student.GivenName,
                student.FamilyName,
                student.Address,
                student.DateOfBirth,
                student.Age(_clock.InTzdbSystemDefaultZone().GetCurrentDate())
            );
        }
    }
}