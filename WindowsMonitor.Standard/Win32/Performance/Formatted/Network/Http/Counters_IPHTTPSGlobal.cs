using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_IPHTTPSGlobal
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong DropsNeighborresolutiontimeouts { get; private set; }
		public ulong ErrorsAuthenticationErrors { get; private set; }
		public ulong ErrorsReceiveerrorsontheserver { get; private set; }
		public ulong ErrorsTransmiterrorsontheserver { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong InTotalbytesreceived { get; private set; }
		public ulong InTotalpacketsreceived { get; private set; }
		public string Name { get; private set; }
		public ulong OutTotalbytesforwarded { get; private set; }
		public ulong OutTotalbytessent { get; private set; }
		public ulong OutTotalpacketssent { get; private set; }
		public ulong SessionsTotalsessions { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_IPHTTPSGlobal> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_IPHTTPSGlobal> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_IPHTTPSGlobal> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_IPHTTPSGlobal");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_IPHTTPSGlobal
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DropsNeighborresolutiontimeouts = (ulong) (managementObject.Properties["DropsNeighborresolutiontimeouts"]?.Value ?? default(ulong)),
		 ErrorsAuthenticationErrors = (ulong) (managementObject.Properties["ErrorsAuthenticationErrors"]?.Value ?? default(ulong)),
		 ErrorsReceiveerrorsontheserver = (ulong) (managementObject.Properties["ErrorsReceiveerrorsontheserver"]?.Value ?? default(ulong)),
		 ErrorsTransmiterrorsontheserver = (ulong) (managementObject.Properties["ErrorsTransmiterrorsontheserver"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InTotalbytesreceived = (ulong) (managementObject.Properties["InTotalbytesreceived"]?.Value ?? default(ulong)),
		 InTotalpacketsreceived = (ulong) (managementObject.Properties["InTotalpacketsreceived"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OutTotalbytesforwarded = (ulong) (managementObject.Properties["OutTotalbytesforwarded"]?.Value ?? default(ulong)),
		 OutTotalbytessent = (ulong) (managementObject.Properties["OutTotalbytessent"]?.Value ?? default(ulong)),
		 OutTotalpacketssent = (ulong) (managementObject.Properties["OutTotalpacketssent"]?.Value ?? default(ulong)),
		 SessionsTotalsessions = (ulong) (managementObject.Properties["SessionsTotalsessions"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}