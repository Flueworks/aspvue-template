using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School.Entity
{
    public interface ISchoolDbContext
    {
        DbSet<Teacher> Teachers { get; set; }
        DbSet<School> Schools { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}