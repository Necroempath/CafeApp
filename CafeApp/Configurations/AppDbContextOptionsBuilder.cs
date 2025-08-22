using CafeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CafeApp.Configurations;

public static class AppDbContextOptionsBuilder
{
    public static DbContextOptions<AppDbContext> GetOptions()
    {
        return new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsetings.json").Build()
                .GetConnectionString("Default"))
            .Options;

    }
}