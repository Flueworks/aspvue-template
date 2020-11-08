using School.Entity;

namespace School.Dto
{
    public class SchoolDto
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class SchoolInputDto
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}