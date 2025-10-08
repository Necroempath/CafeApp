using Microsoft.Extensions.Configuration;

namespace CafeApp.Configurations;

public class JsonConfigurator
{
    public static IConfigurationRoot GetBuilder()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }
}