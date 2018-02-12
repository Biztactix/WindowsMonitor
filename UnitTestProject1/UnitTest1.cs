using System;
using System.Reflection;
using WindowsMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var types = typeof(__ACE).Assembly.GetTypes();

            foreach (var type in types)
            {
                MethodInfo info = type.GetMethod("Retrieve",
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                info.Invoke(null, new object[] {});
            }
        }
    }
}
