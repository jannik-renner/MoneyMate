using Serilog;

namespace MoneyMate.Core.Logging
{
    public static class LoggingConfiguration
    {
        public static void Configure(string logPath, string applicationName)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss}] " +
                    "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(Path.Combine(logPath, $"{applicationName}-.log"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss}] " +
                    "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
