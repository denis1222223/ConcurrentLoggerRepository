
namespace ConcurrentLoggerProject
{
    enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    interface ILogger
    {
        void Log(LogLevel level, string message);
    }
}
