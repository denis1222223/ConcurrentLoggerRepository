using System;
using System.Collections.Generic;

namespace ConcurrentLoggerProject
{
    class Logger : ILogger
    {
        int bufferLimit;
        ILoggerTarget[] targets;
        List<Log> logBuffer;

        public Logger(int bufferLimit, ILoggerTarget[] targets)
        {
            this.bufferLimit = bufferLimit;
            this.targets = targets;
            logBuffer = new List<Log>(bufferLimit);
        }

        public void Log(Log newLog)
        {
            logBuffer.Add(newLog);
            if (logBuffer.Count == bufferLimit)
            {
                FlushBuffer();
                logBuffer = new List<Log>(bufferLimit);
            }
        }

        private void FlushBuffer()
        {
            foreach (ILoggerTarget target in targets)
            {
                foreach (Log log in logBuffer)
                {
                    target.Flush(log);
                }
            }
        }

        public void Close()
        {
            FlushBuffer();
            foreach (ILoggerTarget target in targets)
            {
                target.Close();
            }
        }
    }
}
