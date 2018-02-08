using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfProc_ProcessAddressSpace_Costly
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

        public static PerfFormattedData_PerfProc_ProcessAddressSpace_Costly[] Retrieve(string remote, string username,
            string password)
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

        public static PerfFormattedData_PerfProc_ProcessAddressSpace_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfProc_ProcessAddressSpace_Costly[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_ProcessAddressSpace_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfProc_ProcessAddressSpace_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfProc_ProcessAddressSpace_Costly
                {
                    BytesFree = (ulong) managementObject.Properties["BytesFree"].Value,
                    BytesImageFree = (ulong) managementObject.Properties["BytesImageFree"].Value,
                    BytesImageReserved = (ulong) managementObject.Properties["BytesImageReserved"].Value,
                    BytesReserved = (ulong) managementObject.Properties["BytesReserved"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IDProcess = (ulong) managementObject.Properties["IDProcess"].Value,
                    ImageSpaceExecReadOnly = (ulong) managementObject.Properties["ImageSpaceExecReadOnly"].Value,
                    ImageSpaceExecReadPerWrite =
                        (ulong) managementObject.Properties["ImageSpaceExecReadPerWrite"].Value,
                    ImageSpaceExecutable = (ulong) managementObject.Properties["ImageSpaceExecutable"].Value,
                    ImageSpaceExecWriteCopy = (ulong) managementObject.Properties["ImageSpaceExecWriteCopy"].Value,
                    ImageSpaceNoAccess = (ulong) managementObject.Properties["ImageSpaceNoAccess"].Value,
                    ImageSpaceReadOnly = (ulong) managementObject.Properties["ImageSpaceReadOnly"].Value,
                    ImageSpaceReadPerWrite = (ulong) managementObject.Properties["ImageSpaceReadPerWrite"].Value,
                    ImageSpaceWriteCopy = (ulong) managementObject.Properties["ImageSpaceWriteCopy"].Value,
                    MappedSpaceExecReadOnly = (ulong) managementObject.Properties["MappedSpaceExecReadOnly"].Value,
                    MappedSpaceExecReadPerWrite = (ulong) managementObject.Properties["MappedSpaceExecReadPerWrite"]
                        .Value,
                    MappedSpaceExecutable = (ulong) managementObject.Properties["MappedSpaceExecutable"].Value,
                    MappedSpaceExecWriteCopy = (ulong) managementObject.Properties["MappedSpaceExecWriteCopy"].Value,
                    MappedSpaceNoAccess = (ulong) managementObject.Properties["MappedSpaceNoAccess"].Value,
                    MappedSpaceReadOnly = (ulong) managementObject.Properties["MappedSpaceReadOnly"].Value,
                    MappedSpaceReadPerWrite = (ulong) managementObject.Properties["MappedSpaceReadPerWrite"].Value,
                    MappedSpaceWriteCopy = (ulong) managementObject.Properties["MappedSpaceWriteCopy"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReservedSpaceExecReadOnly = (ulong) managementObject.Properties["ReservedSpaceExecReadOnly"].Value,
                    ReservedSpaceExecReadPerWrite =
                        (ulong) managementObject.Properties["ReservedSpaceExecReadPerWrite"].Value,
                    ReservedSpaceExecutable = (ulong) managementObject.Properties["ReservedSpaceExecutable"].Value,
                    ReservedSpaceExecWriteCopy =
                        (ulong) managementObject.Properties["ReservedSpaceExecWriteCopy"].Value,
                    ReservedSpaceNoAccess = (ulong) managementObject.Properties["ReservedSpaceNoAccess"].Value,
                    ReservedSpaceReadOnly = (ulong) managementObject.Properties["ReservedSpaceReadOnly"].Value,
                    ReservedSpaceReadPerWrite = (ulong) managementObject.Properties["ReservedSpaceReadPerWrite"].Value,
                    ReservedSpaceWriteCopy = (ulong) managementObject.Properties["ReservedSpaceWriteCopy"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UnassignedSpaceExecReadOnly = (ulong) managementObject.Properties["UnassignedSpaceExecReadOnly"]
                        .Value,
                    UnassignedSpaceExecReadPerWrite =
                        (ulong) managementObject.Properties["UnassignedSpaceExecReadPerWrite"].Value,
                    UnassignedSpaceExecutable = (ulong) managementObject.Properties["UnassignedSpaceExecutable"].Value,
                    UnassignedSpaceExecWriteCopy = (ulong) managementObject.Properties["UnassignedSpaceExecWriteCopy"]
                        .Value,
                    UnassignedSpaceNoAccess = (ulong) managementObject.Properties["UnassignedSpaceNoAccess"].Value,
                    UnassignedSpaceReadOnly = (ulong) managementObject.Properties["UnassignedSpaceReadOnly"].Value,
                    UnassignedSpaceReadPerWrite = (ulong) managementObject.Properties["UnassignedSpaceReadPerWrite"]
                        .Value,
                    UnassignedSpaceWriteCopy = (ulong) managementObject.Properties["UnassignedSpaceWriteCopy"].Value
                });

            return list.ToArray();
        }
    }
}