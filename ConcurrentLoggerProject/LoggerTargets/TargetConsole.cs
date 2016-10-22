using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLoggerProject.LoggerTargets
{
    class TargetConsole : ILoggerTarget
    {

        public void Flush(Log log)
        {
            Console.WriteLine(log.ToString());
        }

        public Task<bool> FlushAsync()
        {
            throw new NotImplementedException();
        }

        public void Close() { }
    }
}
