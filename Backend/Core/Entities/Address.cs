using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [Owned]
    public record Address(string Lines, string PostalCode, string PostalPlace);
}