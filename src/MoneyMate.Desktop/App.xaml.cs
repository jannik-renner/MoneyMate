using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyMate.Core;
using MoneyMate.Core.Logging;
using MoneyMate.Desktop.ViewModels;
using MoneyMate.Desktop.Views;
using MoneyMate.Infrastructure;
using MoneyMate.Infrastructure.DbContextSettings;
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

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register infrastructure dependencies
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
            var databaseInitializer = _applicationScope
                .ServiceProvider
                .GetRequiredService<DatabaseInitializer>();

            await databaseInitializer.InitializeAsync();

            // Resolve MainWindow through DI
            var mainWindow = _applicationScope
                .ServiceProvider
                .GetRequiredService<MainWindow>();

            MainWindow = mainWindow;
            mainWindow.DataContext = new MainWindowViewModel();
            mainWindow.Show();

            base.OnStartup(e);
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
