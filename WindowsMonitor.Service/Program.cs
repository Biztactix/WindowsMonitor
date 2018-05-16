using System;
using System.Collections;
using System.Linq;
using System.Management;
using System.Reflection;
using WindowsMonitor.Win32.Hardware;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WindowsMonitor.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var i = 213;
            var types = typeof(Processor).Assembly.GetTypes().Skip(i).ToArray();

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
                        break;
                    }
                    System.Diagnostics.Debug.WriteLine(type.Name);
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine(type.Name);
                    //throw new Exception(type.Name);
                }
                catch (Exception e)
                {
                    var n = e.GetType().Name;
                   //Console.WriteLine(n);
                }

                i++;
                Console.WriteLine($"{i} / {types.Length}");
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
