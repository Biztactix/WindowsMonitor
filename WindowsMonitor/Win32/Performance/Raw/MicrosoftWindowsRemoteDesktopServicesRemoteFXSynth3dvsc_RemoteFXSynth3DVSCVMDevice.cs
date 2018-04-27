using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice
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

        public static IEnumerable<MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMDevice
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofconnectedVMTchannels = (uint) (managementObject.Properties["NumberofconnectedVMTchannels"]?.Value ?? default(uint)),
		 NumberofcreatedVMTchannels = (uint) (managementObject.Properties["NumberofcreatedVMTchannels"]?.Value ?? default(uint)),
		 NumberofdisconnectedVMTchannels = (uint) (managementObject.Properties["NumberofdisconnectedVMTchannels"]?.Value ?? default(uint)),
		 NumberofRDVGMrestartednotifications = (uint) (managementObject.Properties["NumberofRDVGMrestartednotifications"]?.Value ?? default(uint)),
		 NumberofwaitingVMTchannels = (uint) (managementObject.Properties["NumberofwaitingVMTchannels"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalnumberofcreatedVMTchannels = (uint) (managementObject.Properties["TotalnumberofcreatedVMTchannels"]?.Value ?? default(uint))
                };
        }
    }
}