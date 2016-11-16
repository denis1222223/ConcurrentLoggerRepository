using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLoggerProject.LoggerTargets
{
    class TargetConsole : ILoggerTarget
    {

        public bool Flush(Log log)
        {
            Console.WriteLine(log.ToString());
            return true;
        }

        public Task<bool> FlushAsync(Log log)
        {
            throw new NotImplementedException();
        }

        public void Close() { }
    }
}
