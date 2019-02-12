using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Log4Net.Tests
{
    [TestClass]
    public class LoggingSetup
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            ILog LOG = LogManager.GetLogger(typeof(LoggingSetup));
        }

        [TestMethod]
        public void TestSimple()
        {
            log.Info("Hello from test case!");
            Assert.IsTrue(true);

        }
    }
}
