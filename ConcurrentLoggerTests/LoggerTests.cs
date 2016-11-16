using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using ConcurrentLoggerProject;
using System.IO;

namespace ConcurrentLoggerTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void TestMethod_TestOneTarget()
        {
            TargetTest testTarget = new TargetTest();
            StringBuilder stringBuilder = new StringBuilder();
            ILoggerTarget[] logTarget = new ILoggerTarget[] { testTarget };
            var logger = new Logger(1, logTarget);

            for (int i = 0; i < 1000; i++)
            {
                logger.Log(new Log(LogLevel.Debug, i.ToString()));
                stringBuilder.Append(i.ToString());
            }

            var writer = new StreamWriter("test.txt", true);
            writer.WriteLine(stringBuilder.ToString());
            writer.WriteLine("-----");
            writer.WriteLine(testTarget.GetMessage());
            writer.Close();
            
            Assert.AreEqual(stringBuilder.ToString(), testTarget.GetMessage());
            testTarget.Close();
        }
    }
}