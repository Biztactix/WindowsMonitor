using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PowerMeterCounter_PowerMeter
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint Power { get; private set; }
        public uint PowerBudget { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_PowerMeterCounter_PowerMeter[] Retrieve(string remote, string username,
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

        public static PerfRawData_PowerMeterCounter_PowerMeter[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PowerMeterCounter_PowerMeter[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PowerMeterCounter_PowerMeter");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PowerMeterCounter_PowerMeter>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PowerMeterCounter_PowerMeter
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Power = (uint) managementObject.Properties["Power"].Value,
                    PowerBudget = (uint) managementObject.Properties["PowerBudget"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}