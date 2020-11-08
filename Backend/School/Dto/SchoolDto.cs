using System.ComponentModel.DataAnnotations;
using Core.Entities;
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
        [Required]
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class SchoolDtoFactory
    {
        public SchoolDto CreateDto(Entity.School school)
        {
            return new SchoolDto()
            {
                Address = school.Address,
                Name = school.Name,
                SchoolId = school.SchoolId,
            };
        }
    }
}