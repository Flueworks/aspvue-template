using System.Reflection;
using Microsoft.EntityFrameworkCore;
using School.Entity;

namespace Data
{
    public class DataContext : DbContext, ISchoolDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbContext Context => this;

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School.Entity.School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
