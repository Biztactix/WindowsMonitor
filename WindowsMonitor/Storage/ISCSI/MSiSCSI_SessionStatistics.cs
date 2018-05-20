using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_SessionStatistics
    {
		public bool Active { get; private set; }
		public ulong BytesReceived { get; private set; }
		public ulong BytesSent { get; private set; }
		public string Caption { get; private set; }
		public ulong ConnectionTimeoutErrors { get; private set; }
		public string Description { get; private set; }
		public ulong DigestErrors { get; private set; }
		public ulong FormatErrors { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string InstanceName { get; private set; }
		public string iSCSIName { get; private set; }
		public string Name { get; private set; }
		public ulong PDUCommandsSent { get; private set; }
		public ulong PDUResponsesReceived { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong UniqueAdapterId { get; private set; }
		public ulong USID { get; private set; }

        public static IEnumerable<MSiSCSI_SessionStatistics> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_SessionStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_SessionStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_SessionStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_SessionStatistics
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 BytesReceived = (ulong) (managementObject.Properties["BytesReceived"]?.Value ?? default(ulong)),
		 BytesSent = (ulong) (managementObject.Properties["BytesSent"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConnectionTimeoutErrors = (ulong) (managementObject.Properties["ConnectionTimeoutErrors"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DigestErrors = (ulong) (managementObject.Properties["DigestErrors"]?.Value ?? default(ulong)),
		 FormatErrors = (ulong) (managementObject.Properties["FormatErrors"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 iSCSIName = (string) (managementObject.Properties["iSCSIName"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PDUCommandsSent = (ulong) (managementObject.Properties["PDUCommandsSent"]?.Value ?? default(ulong)),
		 PDUResponsesReceived = (ulong) (managementObject.Properties["PDUResponsesReceived"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 UniqueAdapterId = (ulong) (managementObject.Properties["UniqueAdapterId"]?.Value ?? default(ulong)),
		 USID = (ulong) (managementObject.Properties["USID"]?.Value ?? default(ulong))
                };
        }
    }
}