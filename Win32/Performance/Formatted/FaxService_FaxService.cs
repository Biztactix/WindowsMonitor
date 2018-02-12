using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class FaxService_FaxService
    {
		public uint Bytesreceived { get; private set; }
		public uint Bytessent { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint Failedfaxestransmissions { get; private set; }
		public uint Failedoutgoingconnections { get; private set; }
		public uint Failedreceptions { get; private set; }
		public uint Faxessent { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint Minutesreceiving { get; private set; }
		public uint Minutessending { get; private set; }
		public string Name { get; private set; }
		public uint Pagessent { get; private set; }
		public uint Receivedfaxes { get; private set; }
		public uint Receivedpages { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint Totalbytes { get; private set; }
		public uint Totalfaxessentandreceived { get; private set; }
		public uint Totalminutessendingandreceiving { get; private set; }
		public uint Totalpages { get; private set; }

        public static IEnumerable<FaxService_FaxService> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FaxService_FaxService> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FaxService_FaxService> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_FaxService_FaxService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FaxService_FaxService
                {
                     Bytesreceived = (uint) (managementObject.Properties["Bytesreceived"]?.Value ?? default(uint)),
		 Bytessent = (uint) (managementObject.Properties["Bytessent"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Failedfaxestransmissions = (uint) (managementObject.Properties["Failedfaxestransmissions"]?.Value ?? default(uint)),
		 Failedoutgoingconnections = (uint) (managementObject.Properties["Failedoutgoingconnections"]?.Value ?? default(uint)),
		 Failedreceptions = (uint) (managementObject.Properties["Failedreceptions"]?.Value ?? default(uint)),
		 Faxessent = (uint) (managementObject.Properties["Faxessent"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Minutesreceiving = (uint) (managementObject.Properties["Minutesreceiving"]?.Value ?? default(uint)),
		 Minutessending = (uint) (managementObject.Properties["Minutessending"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Pagessent = (uint) (managementObject.Properties["Pagessent"]?.Value ?? default(uint)),
		 Receivedfaxes = (uint) (managementObject.Properties["Receivedfaxes"]?.Value ?? default(uint)),
		 Receivedpages = (uint) (managementObject.Properties["Receivedpages"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 Totalbytes = (uint) (managementObject.Properties["Totalbytes"]?.Value ?? default(uint)),
		 Totalfaxessentandreceived = (uint) (managementObject.Properties["Totalfaxessentandreceived"]?.Value ?? default(uint)),
		 Totalminutessendingandreceiving = (uint) (managementObject.Properties["Totalminutessendingandreceiving"]?.Value ?? default(uint)),
		 Totalpages = (uint) (managementObject.Properties["Totalpages"]?.Value ?? default(uint))
                };
        }
    }
}