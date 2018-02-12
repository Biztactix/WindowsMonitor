using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ProcessStopTrace
    {
		public uint ExitStatus { get; private set; }
		public uint ParentProcessID { get; private set; }
		public uint ProcessID { get; private set; }
		public string ProcessName { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint SessionID { get; private set; }
		public byte[] Sid { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<ProcessStopTrace> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ProcessStopTrace> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ProcessStopTrace> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProcessStopTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ProcessStopTrace
                {
                     ExitStatus = (uint) (managementObject.Properties["ExitStatus"]?.Value ?? default(uint)),
		 ParentProcessID = (uint) (managementObject.Properties["ParentProcessID"]?.Value ?? default(uint)),
		 ProcessID = (uint) (managementObject.Properties["ProcessID"]?.Value ?? default(uint)),
		 ProcessName = (string) (managementObject.Properties["ProcessName"]?.Value ?? default(string)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 SessionID = (uint) (managementObject.Properties["SessionID"]?.Value ?? default(uint)),
		 Sid = (byte[]) (managementObject.Properties["Sid"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}