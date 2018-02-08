using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_TeredoClient
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

        public static PerfFormattedData_Counters_TeredoClient[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_TeredoClient[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_TeredoClient[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_TeredoClient");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_TeredoClient>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_TeredoClient
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InTeredoBubble = (uint) managementObject.Properties["InTeredoBubble"].Value,
                    InTeredoData = (ulong) managementObject.Properties["InTeredoData"].Value,
                    InTeredoDataKernelMode = (ulong) managementObject.Properties["InTeredoDataKernelMode"].Value,
                    InTeredoDataUserMode = (ulong) managementObject.Properties["InTeredoDataUserMode"].Value,
                    InTeredoInvalid = (uint) managementObject.Properties["InTeredoInvalid"].Value,
                    InTeredoRouterAdvertisement = (uint) managementObject.Properties["InTeredoRouterAdvertisement"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutTeredoBubble = (uint) managementObject.Properties["OutTeredoBubble"].Value,
                    OutTeredoData = (ulong) managementObject.Properties["OutTeredoData"].Value,
                    OutTeredoDataKernelMode = (ulong) managementObject.Properties["OutTeredoDataKernelMode"].Value,
                    OutTeredoDataUserMode = (ulong) managementObject.Properties["OutTeredoDataUserMode"].Value,
                    OutTeredoRouterSolicitation = (uint) managementObject.Properties["OutTeredoRouterSolicitation"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}