using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_RADIUSConfig
    {
		public bool Active { get; private set; }
		public dynamic BackupRADIUSServer { get; private set; }
		public string InstanceName { get; private set; }
		public dynamic RADIUSServer { get; private set; }
		public uint Reserved { get; private set; }
		public byte[] SharedSecret { get; private set; }
		public uint SharedSecretSizeInBytes { get; private set; }
		public bool UseRADIUSForCHAP { get; private set; }

        public static IEnumerable<MSiSCSI_RADIUSConfig> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSI_RADIUSConfig> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_RADIUSConfig> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_RADIUSConfig");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_RADIUSConfig
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 BackupRADIUSServer = (dynamic) (managementObject.Properties["BackupRADIUSServer"]?.Value ?? default(dynamic)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 RADIUSServer = (dynamic) (managementObject.Properties["RADIUSServer"]?.Value ?? default(dynamic)),
		 Reserved = (uint) (managementObject.Properties["Reserved"]?.Value ?? default(uint)),
		 SharedSecret = (byte[]) (managementObject.Properties["SharedSecret"]?.Value ?? new byte[0]),
		 SharedSecretSizeInBytes = (uint) (managementObject.Properties["SharedSecretSizeInBytes"]?.Value ?? default(uint)),
		 UseRADIUSForCHAP = (bool) (managementObject.Properties["UseRADIUSForCHAP"]?.Value ?? default(bool))
                };
        }
    }
}