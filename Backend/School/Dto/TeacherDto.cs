using NodaTime;

namespace School.Dto
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public LocalDate DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}