using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using Microsoft.Extensions.DependencyInjection;
using School.Entity;

namespace Data.Extensions
{
    public static class DataContextServiceExtensions
    {
        public static IServiceCollection AddEntityFrameworkStorage(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.AddInterceptors(new TimestampInterceptor())
                                                                 .UseSqlServer(connectionString, x => x.UseNodaTime()));

            services.AddScoped<ISchoolDbContext, DataContext>();

            return services;
        }
    }
}