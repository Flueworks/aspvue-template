using System.ComponentModel.DataAnnotations;
using Core.Entities;
using NodaTime;

namespace Core.Dto
{
    public class PersonDto
    {
        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public Address Address { get; set; }

        public LocalDate DateOfBirth { get; set; }

        public int Age { get; set; }
    }

    public class PersonInputDto
    {
        [Required]
        public string GivenName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public LocalDate DateOfBirth { get; set; }


        public Address Address { get; set; }
    }
}