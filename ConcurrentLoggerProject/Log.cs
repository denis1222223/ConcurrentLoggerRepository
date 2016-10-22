using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLoggerProject
{
    enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    class Log
    {
        public LogLevel LogLevel { get; private set; }
        public string Message { get; private set; }
        DateTime dateTime;

        public Log(LogLevel logLevel, string message)
        {
            LogLevel = logLevel;
            Message = message;
            dateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return "[ " + dateTime.ToString() + " ]   " + LogLevel.ToString() + " " + Message;
        }
    }
}