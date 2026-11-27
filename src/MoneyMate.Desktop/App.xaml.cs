using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyMate.Core;
using MoneyMate.Core.Logging;
using MoneyMate.Infrastructure;
using MoneyMate.Infrastructure.DbContextSettings;
using System.Globalization;
using System.IO;
using System.Windows;

namespace MoneyMate.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private IServiceScope? _applicationScope;
        private ILoggerService _logger;


        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register dependencies
                    services.AddCore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MoneyMate", "logs"), "DesktopApp");
                    services.AddInfrastructure(DatabaseSetup.DatabaseDesktopPath);

                    // Register application windows
                    services.AddTransient<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            _applicationScope = _host.Services.CreateScope();

            // Initialize database
            var databaseInitializer = _applicationScope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            // await databaseInitializer.InitializeAsync();

            // Resolve MainWindow through DI
            var mainWindow = _applicationScope.ServiceProvider.GetRequiredService<MainWindow>();

            MainWindow = mainWindow;
            mainWindow.Show();

            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE"); 
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");

            _logger = _applicationScope.ServiceProvider.GetRequiredService<ILoggerService>();
            _logger.Information("MoneyMate Desktop app started");
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            _applicationScope?.Dispose();

            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
