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

        public bool Flush(Log log)
        {
            writer.WriteLine(log.ToString());
            return true;
        }

        public async Task<bool> FlushAsync(Log log)
        {
            await writer.WriteLineAsync(log.ToString());
            return true;
        }

        public void Close()
        {
            writer.Close();
        }
    }
}