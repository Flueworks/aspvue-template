using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using NodaTime.Extensions;
using School;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            var now = SystemClock.Instance.GetCurrentInstant();
            foreach (var created in ChangeTracker.Entries<ICreated>().Where(c => c.State == EntityState.Added))
            {
                created.Entity.Created = now;
            }

            foreach (var updated in ChangeTracker.Entries<IUpdated>().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added))
            {
                updated.Entity.Updated = now;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
