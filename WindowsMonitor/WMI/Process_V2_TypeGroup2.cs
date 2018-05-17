using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Process_V2_TypeGroup2
    {
		public uint Flags { get; private set; }
		public uint HandleCount { get; private set; }
		public uint PageFaultCount { get; private set; }
		public dynamic PagefileUsage { get; private set; }
		public dynamic PeakPagefileUsage { get; private set; }
		public dynamic PeakVirtualSize { get; private set; }
		public dynamic PeakWorkingSetSize { get; private set; }
		public dynamic PrivatePageCount { get; private set; }
		public uint ProcessId { get; private set; }
		public dynamic QuotaNonPagedPoolUsage { get; private set; }
		public dynamic QuotaPagedPoolUsage { get; private set; }
		public dynamic QuotaPeakNonPagedPoolUsage { get; private set; }
		public dynamic QuotaPeakPagedPoolUsage { get; private set; }
		public uint Reserved { get; private set; }
		public dynamic VirtualSize { get; private set; }
		public dynamic WorkingSetSize { get; private set; }

        public static IEnumerable<Process_V2_TypeGroup2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Process_V2_TypeGroup2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Process_V2_TypeGroup2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Process_V2_TypeGroup2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Process_V2_TypeGroup2
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HandleCount = (uint) (managementObject.Properties["HandleCount"]?.Value ?? default(uint)),
		 PageFaultCount = (uint) (managementObject.Properties["PageFaultCount"]?.Value ?? default(uint)),
		 PagefileUsage = (dynamic) (managementObject.Properties["PagefileUsage"]?.Value ?? default(dynamic)),
		 PeakPagefileUsage = (dynamic) (managementObject.Properties["PeakPagefileUsage"]?.Value ?? default(dynamic)),
		 PeakVirtualSize = (dynamic) (managementObject.Properties["PeakVirtualSize"]?.Value ?? default(dynamic)),
		 PeakWorkingSetSize = (dynamic) (managementObject.Properties["PeakWorkingSetSize"]?.Value ?? default(dynamic)),
		 PrivatePageCount = (dynamic) (managementObject.Properties["PrivatePageCount"]?.Value ?? default(dynamic)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 QuotaNonPagedPoolUsage = (dynamic) (managementObject.Properties["QuotaNonPagedPoolUsage"]?.Value ?? default(dynamic)),
		 QuotaPagedPoolUsage = (dynamic) (managementObject.Properties["QuotaPagedPoolUsage"]?.Value ?? default(dynamic)),
		 QuotaPeakNonPagedPoolUsage = (dynamic) (managementObject.Properties["QuotaPeakNonPagedPoolUsage"]?.Value ?? default(dynamic)),
		 QuotaPeakPagedPoolUsage = (dynamic) (managementObject.Properties["QuotaPeakPagedPoolUsage"]?.Value ?? default(dynamic)),
		 Reserved = (uint) (managementObject.Properties["Reserved"]?.Value ?? default(uint)),
		 VirtualSize = (dynamic) (managementObject.Properties["VirtualSize"]?.Value ?? default(dynamic)),
		 WorkingSetSize = (dynamic) (managementObject.Properties["WorkingSetSize"]?.Value ?? default(dynamic))
                };
        }
    }
}