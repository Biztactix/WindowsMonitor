using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_TapiSrv_Telephony
    {
        public uint ActiveLines { get; private set; }
        public uint ActiveTelephones { get; private set; }
        public string Caption { get; private set; }
        public uint ClientApps { get; private set; }
        public uint CurrentIncomingCalls { get; private set; }
        public uint CurrentOutgoingCalls { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IncomingCallsPersec { get; private set; }
        public uint Lines { get; private set; }
        public string Name { get; private set; }
        public uint OutgoingCallsPersec { get; private set; }
        public uint TelephoneDevices { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_TapiSrv_Telephony[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_TapiSrv_Telephony[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_TapiSrv_Telephony[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_TapiSrv_Telephony");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_TapiSrv_Telephony>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_TapiSrv_Telephony
                {
                    ActiveLines = (uint) managementObject.Properties["ActiveLines"].Value,
                    ActiveTelephones = (uint) managementObject.Properties["ActiveTelephones"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClientApps = (uint) managementObject.Properties["ClientApps"].Value,
                    CurrentIncomingCalls = (uint) managementObject.Properties["CurrentIncomingCalls"].Value,
                    CurrentOutgoingCalls = (uint) managementObject.Properties["CurrentOutgoingCalls"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IncomingCallsPersec = (uint) managementObject.Properties["IncomingCallsPersec"].Value,
                    Lines = (uint) managementObject.Properties["Lines"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutgoingCallsPersec = (uint) managementObject.Properties["OutgoingCallsPersec"].Value,
                    TelephoneDevices = (uint) managementObject.Properties["TelephoneDevices"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}