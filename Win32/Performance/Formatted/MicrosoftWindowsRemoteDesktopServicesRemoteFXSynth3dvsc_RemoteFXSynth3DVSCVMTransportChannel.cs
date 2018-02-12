using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel
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

        public static IEnumerable<MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MicrosoftWindowsRemoteDesktopServicesRemoteFXSynth3dvsc_RemoteFXSynth3DVSCVMTransportChannel
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Numberofdataavailableeventwasreset = (uint) (managementObject.Properties["Numberofdataavailableeventwasreset"]?.Value ?? default(uint)),
		 Numberofdataavailableeventwasresetpersecond = (ulong) (managementObject.Properties["Numberofdataavailableeventwasresetpersecond"]?.Value ?? default(ulong)),
		 Numberofdataavailablesignalsreceived = (uint) (managementObject.Properties["Numberofdataavailablesignalsreceived"]?.Value ?? default(uint)),
		 Numberofdataavailablesignalsreceivedpersecond = (ulong) (managementObject.Properties["Numberofdataavailablesignalsreceivedpersecond"]?.Value ?? default(ulong)),
		 Numberofdataavailablesignalssent = (uint) (managementObject.Properties["Numberofdataavailablesignalssent"]?.Value ?? default(uint)),
		 Numberofdataavailablesignalssentpersecond = (ulong) (managementObject.Properties["Numberofdataavailablesignalssentpersecond"]?.Value ?? default(ulong)),
		 Numberofspaceavailableeventwasreset = (uint) (managementObject.Properties["Numberofspaceavailableeventwasreset"]?.Value ?? default(uint)),
		 Numberofspaceavailableeventwasresetpersecond = (ulong) (managementObject.Properties["Numberofspaceavailableeventwasresetpersecond"]?.Value ?? default(ulong)),
		 Numberofspaceavailablesignalsreceived = (uint) (managementObject.Properties["Numberofspaceavailablesignalsreceived"]?.Value ?? default(uint)),
		 Numberofspaceavailablesignalsreceivedpersecond = (ulong) (managementObject.Properties["Numberofspaceavailablesignalsreceivedpersecond"]?.Value ?? default(ulong)),
		 Numberofspaceavailablesignalssent = (uint) (managementObject.Properties["Numberofspaceavailablesignalssent"]?.Value ?? default(uint)),
		 Numberofspaceavailablesignalssentpersecond = (ulong) (managementObject.Properties["Numberofspaceavailablesignalssentpersecond"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}