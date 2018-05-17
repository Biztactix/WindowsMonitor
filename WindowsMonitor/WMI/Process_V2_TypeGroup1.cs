using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Process_V2_TypeGroup1
    {
		public string CommandLine { get; private set; }
		public int ExitStatus { get; private set; }
		public uint Flags { get; private set; }
		public string ImageFileName { get; private set; }
		public uint ParentId { get; private set; }
		public uint ProcessId { get; private set; }
		public uint SessionId { get; private set; }
		public uint UniqueProcessKey { get; private set; }
		public dynamic UserSID { get; private set; }

        public static IEnumerable<Process_V2_TypeGroup1> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<Process_V2_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Process_V2_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Process_V2_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Process_V2_TypeGroup1
                {
                     CommandLine = (string) (managementObject.Properties["CommandLine"]?.Value ?? default(string)),
		 ExitStatus = (int) (managementObject.Properties["ExitStatus"]?.Value ?? default(int)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ImageFileName = (string) (managementObject.Properties["ImageFileName"]?.Value ?? default(string)),
		 ParentId = (uint) (managementObject.Properties["ParentId"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 SessionId = (uint) (managementObject.Properties["SessionId"]?.Value ?? default(uint)),
		 UniqueProcessKey = (uint) (managementObject.Properties["UniqueProcessKey"]?.Value ?? default(uint)),
		 UserSID = (dynamic) (managementObject.Properties["UserSID"]?.Value ?? default(dynamic))
                };
        }
    }
}