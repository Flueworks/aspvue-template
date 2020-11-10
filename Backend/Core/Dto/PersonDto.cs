using System.ComponentModel.DataAnnotations;
using Core.Entities;
using NodaTime;

namespace Core.Dto
{
    public record PersonDto(string GivenName, string FamilyName, Address Address, LocalDate DateOfBirth, int Age);

    public record PersonInputDto
    {
        [Required]
        public string GivenName { get; init; }

        [Required]
        public string FamilyName { get; init; }

        [Required]
        public LocalDate DateOfBirth { get; init; }

        public Address Address { get; init; }
    }
}