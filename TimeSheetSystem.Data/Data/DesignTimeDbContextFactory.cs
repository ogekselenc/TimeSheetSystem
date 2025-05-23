using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TimeSheetSystem.Data.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TimeSheetDbContext>
{
    public TimeSheetDbContext CreateDbContext(string[] args)
    {
        // Build configuration
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TimeSheetSystem.Api"))
            .AddJsonFile("appsettings.json")
            .Build();

        // Configure DbContext
        var builder = new DbContextOptionsBuilder<TimeSheetDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine("Using connection string: " + connectionString);

        builder.UseNpgsql(connectionString, npgsqlOptionsAction =>
        {
            // 👇 Force __EFMigrationsHistory to go into the correct schema
            npgsqlOptionsAction.MigrationsHistoryTable("__EFMigrationsHistory", "TimeSheetSystem");
        });

        return new TimeSheetDbContext(builder.Options);
    }
}
