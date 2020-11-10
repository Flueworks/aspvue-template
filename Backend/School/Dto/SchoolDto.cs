using System.ComponentModel.DataAnnotations;
using Core.Entities;
using School.Entity;

namespace School.Dto
{
    public record SchoolDto(int SchoolId, string Name, Address Address);

    public record SchoolInputDto([Required]string Name, Address Address);

    public class SchoolDtoFactory
    {
        public SchoolDto CreateDto(Entity.School school)
        {
            return new SchoolDto(school.SchoolId, school.Name, school.Address);
        }
    }
}