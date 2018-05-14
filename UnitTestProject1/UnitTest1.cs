using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using WindowsMonitor.Win32.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BulkTest()
        {
            var types = typeof(Processor).Assembly.GetTypes();

            foreach (var type in types)
            {
                var info = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                var method = info.FirstOrDefault(x => x.Name == "Retrieve" && x.GetParameters().Length == 0);

                try
                {
                    if (method == null) continue;
                    var res = method.Invoke(null, new object[] { }) as IEnumerable;

                    foreach (var item in res)
                    {

                    }
                    System.Diagnostics.Debug.WriteLine(type.Name);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    var n = e.GetType().Name;
                    Console.WriteLine(n);
                }
            }
        }
    }
}
