using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_InitiatorLoginStatistics
    {
		public bool Active { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string InstanceName { get; private set; }
		public uint LoginAcceptRsps { get; private set; }
		public uint LoginAuthenticateFails { get; private set; }
		public uint LoginAuthFailRsps { get; private set; }
		public uint LoginFailures { get; private set; }
		public uint LoginNegotiateFails { get; private set; }
		public uint LoginOtherFailRsps { get; private set; }
		public uint LoginRedirectRsps { get; private set; }
		public uint LogoutNormals { get; private set; }
		public uint LogoutOtherCodes { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong UniqueAdapterId { get; private set; }

        public static IEnumerable<MSiSCSI_InitiatorLoginStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSI_InitiatorLoginStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_InitiatorLoginStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_InitiatorLoginStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_InitiatorLoginStatistics
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 LoginAcceptRsps = (uint) (managementObject.Properties["LoginAcceptRsps"]?.Value ?? default(uint)),
		 LoginAuthenticateFails = (uint) (managementObject.Properties["LoginAuthenticateFails"]?.Value ?? default(uint)),
		 LoginAuthFailRsps = (uint) (managementObject.Properties["LoginAuthFailRsps"]?.Value ?? default(uint)),
		 LoginFailures = (uint) (managementObject.Properties["LoginFailures"]?.Value ?? default(uint)),
		 LoginNegotiateFails = (uint) (managementObject.Properties["LoginNegotiateFails"]?.Value ?? default(uint)),
		 LoginOtherFailRsps = (uint) (managementObject.Properties["LoginOtherFailRsps"]?.Value ?? default(uint)),
		 LoginRedirectRsps = (uint) (managementObject.Properties["LoginRedirectRsps"]?.Value ?? default(uint)),
		 LogoutNormals = (uint) (managementObject.Properties["LogoutNormals"]?.Value ?? default(uint)),
		 LogoutOtherCodes = (uint) (managementObject.Properties["LogoutOtherCodes"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 UniqueAdapterId = (ulong) (managementObject.Properties["UniqueAdapterId"]?.Value ?? default(ulong))
                };
        }
    }
}