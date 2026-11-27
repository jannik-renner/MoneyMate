using Microsoft.Extensions.DependencyInjection;
using MoneyMate.Core.Logging;

namespace MoneyMate.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, string logPath, string applicationName)
        {
            LoggingConfiguration.Configure(logPath, applicationName);
            services.AddSingleton<ILoggerService, SerilogLoggerService>();

            return services;
        }
    }
}
