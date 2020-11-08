using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [Owned]
    public class Address
    {
        public string Lines { get; set; }
        public string PostalCode { get; set; }
        public string PostalPlace { get; set; }
    }
}