using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint NumberofconnectedVMTchannels { get; private set; }
        public uint NumberofcreatedVMTchannels { get; private set; }
        public uint NumberofdisconnectedVMTchannels { get; private set; }
        public uint NumberofRDVGMrestartednotifications { get; private set; }
        public uint NumberofwaitingVMTchannels { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalnumberofcreatedVMTchannels { get; private set; }

        public static PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice[]
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

        public static PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice[]
            Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice[]
            Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list =
                new List<PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice
                >();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(
                    new PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice
                    {
                        Caption = (string) managementObject.Properties["Caption"].Value,
                        Description = (string) managementObject.Properties["Description"].Value,
                        Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                        Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                        Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                        Name = (string) managementObject.Properties["Name"].Value,
                        NumberofconnectedVMTchannels =
                            (uint) managementObject.Properties["NumberofconnectedVMTchannels"].Value,
                        NumberofcreatedVMTchannels =
                            (uint) managementObject.Properties["NumberofcreatedVMTchannels"].Value,
                        NumberofdisconnectedVMTchannels =
                            (uint) managementObject.Properties["NumberofdisconnectedVMTchannels"].Value,
                        NumberofRDVGMrestartednotifications = (uint) managementObject
                            .Properties["NumberofRDVGMrestartednotifications"].Value,
                        NumberofwaitingVMTchannels =
                            (uint) managementObject.Properties["NumberofwaitingVMTchannels"].Value,
                        Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                        Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                        Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                        TotalnumberofcreatedVMTchannels =
                            (uint) managementObject.Properties["TotalnumberofcreatedVMTchannels"].Value
                    });

            return list.ToArray();
        }
    }
}