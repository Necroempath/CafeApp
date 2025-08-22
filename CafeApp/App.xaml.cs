using System.Configuration;
using System.Data;
using System.Windows;
using CafeApp.Configurations;
using CafeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace CafeApp;

public partial class App : Application
{
    public static Container Container = new();

    protected override void OnStartup(StartupEventArgs e)
    {
        Register();
    }

    private void Register()
    {
        Container.RegisterSingleton<AppDbContext>(() =>
        {
            var options = AppDbContextOptionsBuilder.GetOptions();
            
            return new AppDbContext(options);
        });
    }
}