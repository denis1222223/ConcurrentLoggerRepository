using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConcurrentLoggerProject.LoggerTargets;

namespace ConcurrentLoggerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerTarget[] targets = new ILoggerTarget[] { new TargetConsole(), new TargetTextFile("log.txt") };
            Logger logger = new Logger(5, targets);

            for (int i = 0; i < 5; i++)
            {
                logger.Log(new Log(LogLevel.Warning, " event №" + i.ToString()));
            }
            logger.Close();

            Console.ReadLine();
        }
    }
}
