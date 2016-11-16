using ConcurrentLoggerProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLoggerTests
{
    public class TargetTest : ILoggerTarget
    {
        private StringBuilder message = new StringBuilder();

        public string GetMessage()
        {
            return message.ToString();
        }

        public bool Flush(Log log)
        {
            message.Append(log.Message);
            return true;
        }

        public Task<bool> FlushAsync(Log log)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
