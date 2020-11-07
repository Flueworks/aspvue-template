using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School.Entity.School>
    {
        public void Configure(EntityTypeBuilder<School.Entity.School> builder)
        {
            builder.HasKey(school => school.SchoolId);
        }
    }
}