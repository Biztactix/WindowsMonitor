using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ThreadStartTrace
    {
		public uint ProcessID { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong StackBase { get; private set; }
		public ulong StackLimit { get; private set; }
		public ulong StartAddr { get; private set; }
		public uint ThreadID { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public ulong UserStackBase { get; private set; }
		public ulong UserStackLimit { get; private set; }
		public uint WaitMode { get; private set; }
		public ulong Win32StartAddr { get; private set; }

        public static IEnumerable<ThreadStartTrace> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<ThreadStartTrace> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ThreadStartTrace> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ThreadStartTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ThreadStartTrace
                {
                     ProcessID = (uint) (managementObject.Properties["ProcessID"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 StackBase = (ulong) (managementObject.Properties["StackBase"]?.Value ?? default(ulong)),
		 StackLimit = (ulong) (managementObject.Properties["StackLimit"]?.Value ?? default(ulong)),
		 StartAddr = (ulong) (managementObject.Properties["StartAddr"]?.Value ?? default(ulong)),
		 ThreadID = (uint) (managementObject.Properties["ThreadID"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 UserStackBase = (ulong) (managementObject.Properties["UserStackBase"]?.Value ?? default(ulong)),
		 UserStackLimit = (ulong) (managementObject.Properties["UserStackLimit"]?.Value ?? default(ulong)),
		 WaitMode = (uint) (managementObject.Properties["WaitMode"]?.Value ?? default(uint)),
		 Win32StartAddr = (ulong) (managementObject.Properties["Win32StartAddr"]?.Value ?? default(ulong))
                };
        }
    }
}