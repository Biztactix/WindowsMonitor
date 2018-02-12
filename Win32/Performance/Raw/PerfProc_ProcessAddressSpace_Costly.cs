using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class PerfProc_ProcessAddressSpace_Costly
    {
		public ulong BytesFree { get; private set; }
		public ulong BytesImageFree { get; private set; }
		public ulong BytesImageReserved { get; private set; }
		public ulong BytesReserved { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong IDProcess { get; private set; }
		public ulong ImageSpaceExecReadOnly { get; private set; }
		public ulong ImageSpaceExecReadPerWrite { get; private set; }
		public ulong ImageSpaceExecutable { get; private set; }
		public ulong ImageSpaceExecWriteCopy { get; private set; }
		public ulong ImageSpaceNoAccess { get; private set; }
		public ulong ImageSpaceReadOnly { get; private set; }
		public ulong ImageSpaceReadPerWrite { get; private set; }
		public ulong ImageSpaceWriteCopy { get; private set; }
		public ulong MappedSpaceExecReadOnly { get; private set; }
		public ulong MappedSpaceExecReadPerWrite { get; private set; }
		public ulong MappedSpaceExecutable { get; private set; }
		public ulong MappedSpaceExecWriteCopy { get; private set; }
		public ulong MappedSpaceNoAccess { get; private set; }
		public ulong MappedSpaceReadOnly { get; private set; }
		public ulong MappedSpaceReadPerWrite { get; private set; }
		public ulong MappedSpaceWriteCopy { get; private set; }
		public string Name { get; private set; }
		public ulong ReservedSpaceExecReadOnly { get; private set; }
		public ulong ReservedSpaceExecReadPerWrite { get; private set; }
		public ulong ReservedSpaceExecutable { get; private set; }
		public ulong ReservedSpaceExecWriteCopy { get; private set; }
		public ulong ReservedSpaceNoAccess { get; private set; }
		public ulong ReservedSpaceReadOnly { get; private set; }
		public ulong ReservedSpaceReadPerWrite { get; private set; }
		public ulong ReservedSpaceWriteCopy { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong UnassignedSpaceExecReadOnly { get; private set; }
		public ulong UnassignedSpaceExecReadPerWrite { get; private set; }
		public ulong UnassignedSpaceExecutable { get; private set; }
		public ulong UnassignedSpaceExecWriteCopy { get; private set; }
		public ulong UnassignedSpaceNoAccess { get; private set; }
		public ulong UnassignedSpaceReadOnly { get; private set; }
		public ulong UnassignedSpaceReadPerWrite { get; private set; }
		public ulong UnassignedSpaceWriteCopy { get; private set; }

        public static IEnumerable<PerfProc_ProcessAddressSpace_Costly> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfProc_ProcessAddressSpace_Costly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfProc_ProcessAddressSpace_Costly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfProc_ProcessAddressSpace_Costly
                {
                     BytesFree = (ulong) (managementObject.Properties["BytesFree"]?.Value ?? default(ulong)),
		 BytesImageFree = (ulong) (managementObject.Properties["BytesImageFree"]?.Value ?? default(ulong)),
		 BytesImageReserved = (ulong) (managementObject.Properties["BytesImageReserved"]?.Value ?? default(ulong)),
		 BytesReserved = (ulong) (managementObject.Properties["BytesReserved"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IDProcess = (ulong) (managementObject.Properties["IDProcess"]?.Value ?? default(ulong)),
		 ImageSpaceExecReadOnly = (ulong) (managementObject.Properties["ImageSpaceExecReadOnly"]?.Value ?? default(ulong)),
		 ImageSpaceExecReadPerWrite = (ulong) (managementObject.Properties["ImageSpaceExecReadPerWrite"]?.Value ?? default(ulong)),
		 ImageSpaceExecutable = (ulong) (managementObject.Properties["ImageSpaceExecutable"]?.Value ?? default(ulong)),
		 ImageSpaceExecWriteCopy = (ulong) (managementObject.Properties["ImageSpaceExecWriteCopy"]?.Value ?? default(ulong)),
		 ImageSpaceNoAccess = (ulong) (managementObject.Properties["ImageSpaceNoAccess"]?.Value ?? default(ulong)),
		 ImageSpaceReadOnly = (ulong) (managementObject.Properties["ImageSpaceReadOnly"]?.Value ?? default(ulong)),
		 ImageSpaceReadPerWrite = (ulong) (managementObject.Properties["ImageSpaceReadPerWrite"]?.Value ?? default(ulong)),
		 ImageSpaceWriteCopy = (ulong) (managementObject.Properties["ImageSpaceWriteCopy"]?.Value ?? default(ulong)),
		 MappedSpaceExecReadOnly = (ulong) (managementObject.Properties["MappedSpaceExecReadOnly"]?.Value ?? default(ulong)),
		 MappedSpaceExecReadPerWrite = (ulong) (managementObject.Properties["MappedSpaceExecReadPerWrite"]?.Value ?? default(ulong)),
		 MappedSpaceExecutable = (ulong) (managementObject.Properties["MappedSpaceExecutable"]?.Value ?? default(ulong)),
		 MappedSpaceExecWriteCopy = (ulong) (managementObject.Properties["MappedSpaceExecWriteCopy"]?.Value ?? default(ulong)),
		 MappedSpaceNoAccess = (ulong) (managementObject.Properties["MappedSpaceNoAccess"]?.Value ?? default(ulong)),
		 MappedSpaceReadOnly = (ulong) (managementObject.Properties["MappedSpaceReadOnly"]?.Value ?? default(ulong)),
		 MappedSpaceReadPerWrite = (ulong) (managementObject.Properties["MappedSpaceReadPerWrite"]?.Value ?? default(ulong)),
		 MappedSpaceWriteCopy = (ulong) (managementObject.Properties["MappedSpaceWriteCopy"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ReservedSpaceExecReadOnly = (ulong) (managementObject.Properties["ReservedSpaceExecReadOnly"]?.Value ?? default(ulong)),
		 ReservedSpaceExecReadPerWrite = (ulong) (managementObject.Properties["ReservedSpaceExecReadPerWrite"]?.Value ?? default(ulong)),
		 ReservedSpaceExecutable = (ulong) (managementObject.Properties["ReservedSpaceExecutable"]?.Value ?? default(ulong)),
		 ReservedSpaceExecWriteCopy = (ulong) (managementObject.Properties["ReservedSpaceExecWriteCopy"]?.Value ?? default(ulong)),
		 ReservedSpaceNoAccess = (ulong) (managementObject.Properties["ReservedSpaceNoAccess"]?.Value ?? default(ulong)),
		 ReservedSpaceReadOnly = (ulong) (managementObject.Properties["ReservedSpaceReadOnly"]?.Value ?? default(ulong)),
		 ReservedSpaceReadPerWrite = (ulong) (managementObject.Properties["ReservedSpaceReadPerWrite"]?.Value ?? default(ulong)),
		 ReservedSpaceWriteCopy = (ulong) (managementObject.Properties["ReservedSpaceWriteCopy"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 UnassignedSpaceExecReadOnly = (ulong) (managementObject.Properties["UnassignedSpaceExecReadOnly"]?.Value ?? default(ulong)),
		 UnassignedSpaceExecReadPerWrite = (ulong) (managementObject.Properties["UnassignedSpaceExecReadPerWrite"]?.Value ?? default(ulong)),
		 UnassignedSpaceExecutable = (ulong) (managementObject.Properties["UnassignedSpaceExecutable"]?.Value ?? default(ulong)),
		 UnassignedSpaceExecWriteCopy = (ulong) (managementObject.Properties["UnassignedSpaceExecWriteCopy"]?.Value ?? default(ulong)),
		 UnassignedSpaceNoAccess = (ulong) (managementObject.Properties["UnassignedSpaceNoAccess"]?.Value ?? default(ulong)),
		 UnassignedSpaceReadOnly = (ulong) (managementObject.Properties["UnassignedSpaceReadOnly"]?.Value ?? default(ulong)),
		 UnassignedSpaceReadPerWrite = (ulong) (managementObject.Properties["UnassignedSpaceReadPerWrite"]?.Value ?? default(ulong)),
		 UnassignedSpaceWriteCopy = (ulong) (managementObject.Properties["UnassignedSpaceWriteCopy"]?.Value ?? default(ulong))
                };
        }
    }
}