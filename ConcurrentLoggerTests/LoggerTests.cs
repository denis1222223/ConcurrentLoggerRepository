using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using ConcurrentLoggerProject;

namespace ConcurrentLoggerTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void TestMethod_TestOneTarget()
        {
            int bufferLimit = 1;
            TargetStringBuilder testTarget = new TargetStringBuilder();

            StringBuilder stringBuilder = new StringBuilder();
            ILoggerTarget[] targets = new ILoggerTarget[] { testTarget };
            Logger logger = new Logger(bufferLimit, targets);

            for (int i = 0; i < 1000; i++)
            {
                stringBuilder.Append(i);
                logger.Log(new Log(LogLevel.Debug, i.ToString()));
            }

            CollectionAssert.AreEqual(Encoding.Default.GetBytes(stringBuilder.ToString()), testTarget.GetMessage());
            testTarget.Close();
        }
    }
}