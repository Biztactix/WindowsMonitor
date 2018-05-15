using System;
using System.Management;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WindowsMonitor.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var date = ManagementDateTimeConverter.ToDmtfDateTime(DateTime.MinValue + TimeSpan.FromDays(1));
            var parsed = ManagementDateTimeConverter.ToDateTime(date);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
