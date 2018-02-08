using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class
        PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint Numberofdataavailableeventwasreset { get; private set; }
        public ulong Numberofdataavailableeventwasresetpersecond { get; private set; }
        public uint Numberofdataavailablesignalsreceived { get; private set; }
        public ulong Numberofdataavailablesignalsreceivedpersecond { get; private set; }
        public uint Numberofdataavailablesignalssent { get; private set; }
        public ulong Numberofdataavailablesignalssentpersecond { get; private set; }
        public uint Numberofspaceavailableeventwasreset { get; private set; }
        public ulong Numberofspaceavailableeventwasresetpersecond { get; private set; }
        public uint Numberofspaceavailablesignalsreceived { get; private set; }
        public ulong Numberofspaceavailablesignalsreceivedpersecond { get; private set; }
        public uint Numberofspaceavailablesignalssent { get; private set; }
        public ulong Numberofspaceavailablesignalssentpersecond { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static
            PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel[]
            Retrieve(string remote, string username, string password)
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

        public static
            PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel[]
            Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static
            PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel[]
            Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list =
                new List<
                    PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel
                >();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(
                    new
                        PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel
                        {
                            Caption = (string) managementObject.Properties["Caption"].Value,
                            Description = (string) managementObject.Properties["Description"].Value,
                            Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                            Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                            Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                            Name = (string) managementObject.Properties["Name"].Value,
                            Numberofdataavailableeventwasreset = (uint) managementObject
                                .Properties["Numberofdataavailableeventwasreset"].Value,
                            Numberofdataavailableeventwasresetpersecond = (ulong) managementObject
                                .Properties["Numberofdataavailableeventwasresetpersecond"].Value,
                            Numberofdataavailablesignalsreceived = (uint) managementObject
                                .Properties["Numberofdataavailablesignalsreceived"].Value,
                            Numberofdataavailablesignalsreceivedpersecond = (ulong) managementObject
                                .Properties["Numberofdataavailablesignalsreceivedpersecond"].Value,
                            Numberofdataavailablesignalssent = (uint) managementObject
                                .Properties["Numberofdataavailablesignalssent"].Value,
                            Numberofdataavailablesignalssentpersecond = (ulong) managementObject
                                .Properties["Numberofdataavailablesignalssentpersecond"].Value,
                            Numberofspaceavailableeventwasreset = (uint) managementObject
                                .Properties["Numberofspaceavailableeventwasreset"].Value,
                            Numberofspaceavailableeventwasresetpersecond = (ulong) managementObject
                                .Properties["Numberofspaceavailableeventwasresetpersecond"].Value,
                            Numberofspaceavailablesignalsreceived = (uint) managementObject
                                .Properties["Numberofspaceavailablesignalsreceived"].Value,
                            Numberofspaceavailablesignalsreceivedpersecond = (ulong) managementObject
                                .Properties["Numberofspaceavailablesignalsreceivedpersecond"].Value,
                            Numberofspaceavailablesignalssent = (uint) managementObject
                                .Properties["Numberofspaceavailablesignalssent"].Value,
                            Numberofspaceavailablesignalssentpersecond = (ulong) managementObject
                                .Properties["Numberofspaceavailablesignalssentpersecond"].Value,
                            Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                            Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                            Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                        });

            return list.ToArray();
        }
    }
}