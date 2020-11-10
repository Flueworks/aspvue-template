using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot _configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Web.Api"))
                .AddJsonFile("appsettings.json") // Production
                .AddJsonFile("appsettings.Development.json") // Development
                .AddJsonFile($"appsettings.{environment}.json", optional: true) // Optional (Docker, Azure)
                .AddEnvironmentVariables() // Override
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();

            var connectionString = _configuration.GetConnectionString("DataContext");

            builder.AddInterceptors(new TimestampInterceptor())
                   .UseSqlServer(connectionString, o => o.UseNodaTime());
            return new DataContext(builder.Options);
        }
    }
}