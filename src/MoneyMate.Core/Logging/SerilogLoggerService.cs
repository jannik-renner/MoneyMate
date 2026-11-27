using Serilog;

namespace MoneyMate.Core.Logging
{
    public class SerilogLoggerService : ILoggerService
    {
        private readonly Serilog.ILogger _logger;

        public SerilogLoggerService()
        {
            _logger = Log.Logger;
        }

        public void Information(string message)
            => _logger.Information(message);

        public void Warning(string message)
            => _logger.Warning(message);

        public void Error(string message)
            => _logger.Error(message);

        public void Error(Exception exception, string message)
            => _logger.Error(exception, message);

        public void Debug(string message)
            => _logger.Debug(message);
    }
}
