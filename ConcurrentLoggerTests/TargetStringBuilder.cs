using ConcurrentLoggerProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLoggerTests
{
    public class TargetStringBuilder : ILoggerTarget
    {
        private StringBuilder message = new StringBuilder();

        public void Flush(Log log)
        {
            message.Append(log.Message);
        }

        public Task<bool> FlushAsync()
        {
            throw new NotImplementedException();
        }

        public byte[] GetMessage()
        {
            return Encoding.Default.GetBytes(message.ToString());
        }

        public void Close()
        {
            message.Clear();
        }
    }
}
