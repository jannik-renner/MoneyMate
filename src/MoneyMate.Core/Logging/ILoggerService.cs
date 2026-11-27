
namespace MoneyMate.Core.Logging
{
    public interface ILoggerService
    {
        void Information(string message);
        void Warning(string message);
        void Error(string message);
        void Error(Exception exception, string message);
        void Debug(string message);
    }
}
