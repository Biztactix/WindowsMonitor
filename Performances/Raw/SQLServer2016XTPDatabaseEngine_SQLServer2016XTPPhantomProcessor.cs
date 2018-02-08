using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint DustycornerscanretriesPersecPhantomissued { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint PhantomexpiredrowsremovedPersec { get; private set; }
        public uint PhantomexpiredrowstouchedPersec { get; private set; }
        public uint PhantomexpiringrowstouchedPersec { get; private set; }
        public uint PhantomrowstouchedPersec { get; private set; }
        public uint PhantomscansstartedPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor[] Retrieve(
            string remote, string username, string password)
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPPhantomProcessor
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DustycornerscanretriesPersecPhantomissued = (uint) managementObject
                        .Properties["DustycornerscanretriesPersecPhantomissued"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PhantomexpiredrowsremovedPersec =
                        (uint) managementObject.Properties["PhantomexpiredrowsremovedPersec"].Value,
                    PhantomexpiredrowstouchedPersec =
                        (uint) managementObject.Properties["PhantomexpiredrowstouchedPersec"].Value,
                    PhantomexpiringrowstouchedPersec =
                        (uint) managementObject.Properties["PhantomexpiringrowstouchedPersec"].Value,
                    PhantomrowstouchedPersec = (uint) managementObject.Properties["PhantomrowstouchedPersec"].Value,
                    PhantomscansstartedPersec = (uint) managementObject.Properties["PhantomscansstartedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}