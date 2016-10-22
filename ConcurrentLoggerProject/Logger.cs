using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrentLoggerProject
{
    class Logger : ILogger
    {
        int bufferLimit;
        ILoggerTarget[] targets;
        List<Log> logBuffer;

        private object locker = new object();
        private volatile int bufferId = 0;
        private volatile int currentBufferId = 0;

        private class ThreadInfo
        {
            public List<Log> logs;
            public int threadId;
        }

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
                ThreadPool.QueueUserWorkItem(FlushBuffer, new ThreadInfo { logs = logBuffer, threadId = bufferId++ });
                logBuffer = new List<Log>(bufferLimit);
            }
        }

        private void FlushBuffer(object state)
        {
            var threadInfo = (ThreadInfo)state;

            Monitor.Enter(locker);
            try
            {
                while (threadInfo.threadId != currentBufferId)
                    Monitor.Wait(locker);
                foreach (ILoggerTarget target in targets)
                    foreach (Log log in threadInfo.logs)
                        target.Flush(log);
                currentBufferId++;
                Monitor.PulseAll(locker);
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        public void Close()
        {
            ThreadPool.QueueUserWorkItem(FlushBuffer, new ThreadInfo { logs = logBuffer, threadId = bufferId++ });

            Monitor.Enter(locker);
            try
            {
                while (bufferId != currentBufferId)
                    Monitor.Wait(locker);
            }
            finally
            {
                Monitor.Exit(locker);
            }

            foreach (ILoggerTarget target in targets)
            {
                target.Close();
            }
        }
    }
}