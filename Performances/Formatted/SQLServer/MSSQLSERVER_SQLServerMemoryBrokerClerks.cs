using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong Internalbenefit { get; private set; }
        public ulong Memorybrokerclerksize { get; private set; }
        public string Name { get; private set; }
        public ulong Periodicevictionspages { get; private set; }
        public ulong PressureevictionspagesPersec { get; private set; }
        public ulong Simulationbenefit { get; private set; }
        public ulong Simulationsize { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerMemoryBrokerClerks
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Internalbenefit = (ulong) managementObject.Properties["Internalbenefit"].Value,
                    Memorybrokerclerksize = (ulong) managementObject.Properties["Memorybrokerclerksize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Periodicevictionspages = (ulong) managementObject.Properties["Periodicevictionspages"].Value,
                    PressureevictionspagesPersec = (ulong) managementObject.Properties["PressureevictionspagesPersec"]
                        .Value,
                    Simulationbenefit = (ulong) managementObject.Properties["Simulationbenefit"].Value,
                    Simulationsize = (ulong) managementObject.Properties["Simulationsize"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}