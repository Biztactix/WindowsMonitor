using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_TCPIPConfig
    {
		public bool Active { get; private set; }
		public dynamic AlternateDNSServer { get; private set; }
		public dynamic DefaultGateway { get; private set; }
		public bool EnableDHCP { get; private set; }
		public string InstanceName { get; private set; }
		public dynamic IpAddress { get; private set; }
		public uint IPVersions { get; private set; }
		public dynamic PreferredDNSServer { get; private set; }
		public dynamic SubnetMask { get; private set; }
		public bool UseDHCPForDNS { get; private set; }
		public bool UseLinkLocalAddress { get; private set; }

        public static IEnumerable<MSiSCSI_TCPIPConfig> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSI_TCPIPConfig> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_TCPIPConfig> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_TCPIPConfig");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_TCPIPConfig
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AlternateDNSServer = (dynamic) (managementObject.Properties["AlternateDNSServer"]?.Value ?? default(dynamic)),
		 DefaultGateway = (dynamic) (managementObject.Properties["DefaultGateway"]?.Value ?? default(dynamic)),
		 EnableDHCP = (bool) (managementObject.Properties["EnableDHCP"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 IpAddress = (dynamic) (managementObject.Properties["IpAddress"]?.Value ?? default(dynamic)),
		 IPVersions = (uint) (managementObject.Properties["IPVersions"]?.Value ?? default(uint)),
		 PreferredDNSServer = (dynamic) (managementObject.Properties["PreferredDNSServer"]?.Value ?? default(dynamic)),
		 SubnetMask = (dynamic) (managementObject.Properties["SubnetMask"]?.Value ?? default(dynamic)),
		 UseDHCPForDNS = (bool) (managementObject.Properties["UseDHCPForDNS"]?.Value ?? default(bool)),
		 UseLinkLocalAddress = (bool) (managementObject.Properties["UseLinkLocalAddress"]?.Value ?? default(bool))
                };
        }
    }
}