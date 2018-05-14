using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ProcessTrace
    {
		public uint ParentProcessID { get; private set; }
		public uint ProcessID { get; private set; }
		public string ProcessName { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint SessionID { get; private set; }
		public byte[] Sid { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<ProcessTrace> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ProcessTrace> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ProcessTrace> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProcessTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ProcessTrace
                {
                     ParentProcessID = (uint) (managementObject.Properties["ParentProcessID"]?.Value ?? default(uint)),
		 ProcessID = (uint) (managementObject.Properties["ProcessID"]?.Value ?? default(uint)),
		 ProcessName = (string) (managementObject.Properties["ProcessName"]?.Value),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 SessionID = (uint) (managementObject.Properties["SessionID"]?.Value ?? default(uint)),
		 Sid = (byte[]) (managementObject.Properties["Sid"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}