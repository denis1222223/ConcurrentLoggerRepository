using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLoggerProject.LoggerTargets
{
    class TargetTextFile : ILoggerTarget
    {
        StreamWriter writer;

        public TargetTextFile(string path)
        {
            writer = new StreamWriter(path, true);
        }

        public void Flush(Log log)
        {
            writer.WriteLine(log.ToString());
        }

        public Task<bool> FlushAsync()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            writer.Close();
        }
    }
}
