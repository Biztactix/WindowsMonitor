using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_TeredoClient
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint InTeredoBubble { get; private set; }
		public ulong InTeredoData { get; private set; }
		public ulong InTeredoDataKernelMode { get; private set; }
		public ulong InTeredoDataUserMode { get; private set; }
		public uint InTeredoInvalid { get; private set; }
		public uint InTeredoRouterAdvertisement { get; private set; }
		public string Name { get; private set; }
		public uint OutTeredoBubble { get; private set; }
		public ulong OutTeredoData { get; private set; }
		public ulong OutTeredoDataKernelMode { get; private set; }
		public ulong OutTeredoDataUserMode { get; private set; }
		public uint OutTeredoRouterSolicitation { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_TeredoClient> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_TeredoClient> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_TeredoClient> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_TeredoClient");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_TeredoClient
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InTeredoBubble = (uint) (managementObject.Properties["InTeredoBubble"]?.Value ?? default(uint)),
		 InTeredoData = (ulong) (managementObject.Properties["InTeredoData"]?.Value ?? default(ulong)),
		 InTeredoDataKernelMode = (ulong) (managementObject.Properties["InTeredoDataKernelMode"]?.Value ?? default(ulong)),
		 InTeredoDataUserMode = (ulong) (managementObject.Properties["InTeredoDataUserMode"]?.Value ?? default(ulong)),
		 InTeredoInvalid = (uint) (managementObject.Properties["InTeredoInvalid"]?.Value ?? default(uint)),
		 InTeredoRouterAdvertisement = (uint) (managementObject.Properties["InTeredoRouterAdvertisement"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OutTeredoBubble = (uint) (managementObject.Properties["OutTeredoBubble"]?.Value ?? default(uint)),
		 OutTeredoData = (ulong) (managementObject.Properties["OutTeredoData"]?.Value ?? default(ulong)),
		 OutTeredoDataKernelMode = (ulong) (managementObject.Properties["OutTeredoDataKernelMode"]?.Value ?? default(ulong)),
		 OutTeredoDataUserMode = (ulong) (managementObject.Properties["OutTeredoDataUserMode"]?.Value ?? default(ulong)),
		 OutTeredoRouterSolicitation = (uint) (managementObject.Properties["OutTeredoRouterSolicitation"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}