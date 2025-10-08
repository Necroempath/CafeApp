using System.Configuration;
using System.Data;
using System.Windows;
using CafeApp.Configurations;
using CafeApp.Data;
using CafeApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        
        services.AddDbContext<AppDbContext>(options =>
        {
            var configuration = JsonConfigurator.GetBuilder();

            var connectionString = configuration.GetConnectionString("Default");

            options.UseSqlServer(connectionString);
        });
        
        services.AddSingleton<MainWindow>();
        
        services.AddSingleton<MainViewModel>();
        
        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}