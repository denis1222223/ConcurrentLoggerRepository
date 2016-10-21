using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConcurrentLoggerProject
{
    class Program
    {

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(WriteHello, "WriteHello state");
            ThreadPool.QueueUserWorkItem(WriteBye, "WriteBye state");
            ThreadPool.QueueUserWorkItem(WriteFuck, "WriteFuck state");

            Console.ReadLine();
        }

        private static void WriteBye(object state)
        {
            while (true)
            {
                Console.WriteLine((string)state);
                Thread.Sleep(333);
            }
        }

        private static void WriteFuck(object state)
        {
            while (true)
            {
                Console.WriteLine((string)state);
                Thread.Sleep(333);
            }
        }

        private static void WriteHello(object state)
        {
            while (true)
            {
                Console.WriteLine((string)state);
                Thread.Sleep(333);
            }
        }
    }
}
