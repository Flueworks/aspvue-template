using NodaTime;

namespace School.Dto
{
    public class TeacherInputDto
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public LocalDate DateOfBirth { get; set; }
    }
}