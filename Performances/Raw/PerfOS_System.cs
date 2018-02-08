using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PerfOS_System
    {
        public uint AlignmentFixupsPersec { get; private set; }
        public string Caption { get; private set; }
        public uint ContextSwitchesPersec { get; private set; }
        public string Description { get; private set; }
        public uint ExceptionDispatchesPersec { get; private set; }
        public ulong FileControlBytesPersec { get; private set; }
        public uint FileControlOperationsPersec { get; private set; }
        public uint FileDataOperationsPersec { get; private set; }
        public ulong FileReadBytesPersec { get; private set; }
        public uint FileReadOperationsPersec { get; private set; }
        public ulong FileWriteBytesPersec { get; private set; }
        public uint FileWriteOperationsPersec { get; private set; }
        public uint FloatingEmulationsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint PercentRegistryQuotaInUse { get; private set; }
        public uint PercentRegistryQuotaInUse_Base { get; private set; }
        public uint Processes { get; private set; }
        public uint ProcessorQueueLength { get; private set; }
        public uint SystemCallsPersec { get; private set; }
        public ulong SystemUpTime { get; private set; }
        public uint Threads { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_PerfOS_System[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PerfOS_System[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PerfOS_System[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfOS_System");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PerfOS_System>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PerfOS_System
                {
                    AlignmentFixupsPersec = (uint) managementObject.Properties["AlignmentFixupsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContextSwitchesPersec = (uint) managementObject.Properties["ContextSwitchesPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExceptionDispatchesPersec = (uint) managementObject.Properties["ExceptionDispatchesPersec"].Value,
                    FileControlBytesPersec = (ulong) managementObject.Properties["FileControlBytesPersec"].Value,
                    FileControlOperationsPersec = (uint) managementObject.Properties["FileControlOperationsPersec"]
                        .Value,
                    FileDataOperationsPersec = (uint) managementObject.Properties["FileDataOperationsPersec"].Value,
                    FileReadBytesPersec = (ulong) managementObject.Properties["FileReadBytesPersec"].Value,
                    FileReadOperationsPersec = (uint) managementObject.Properties["FileReadOperationsPersec"].Value,
                    FileWriteBytesPersec = (ulong) managementObject.Properties["FileWriteBytesPersec"].Value,
                    FileWriteOperationsPersec = (uint) managementObject.Properties["FileWriteOperationsPersec"].Value,
                    FloatingEmulationsPersec = (uint) managementObject.Properties["FloatingEmulationsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentRegistryQuotaInUse = (uint) managementObject.Properties["PercentRegistryQuotaInUse"].Value,
                    PercentRegistryQuotaInUse_Base =
                        (uint) managementObject.Properties["PercentRegistryQuotaInUse_Base"].Value,
                    Processes = (uint) managementObject.Properties["Processes"].Value,
                    ProcessorQueueLength = (uint) managementObject.Properties["ProcessorQueueLength"].Value,
                    SystemCallsPersec = (uint) managementObject.Properties["SystemCallsPersec"].Value,
                    SystemUpTime = (ulong) managementObject.Properties["SystemUpTime"].Value,
                    Threads = (uint) managementObject.Properties["Threads"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}