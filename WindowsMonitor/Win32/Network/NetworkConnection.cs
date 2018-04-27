using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Network
{
    /// <summary>
    /// </summary>
    public sealed class NetworkConnection
    {
		public uint AccessMask { get; private set; }
		public string Caption { get; private set; }
		public string Comment { get; private set; }
		public string ConnectionState { get; private set; }
		public string ConnectionType { get; private set; }
		public string Description { get; private set; }
		public string DisplayType { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string LocalName { get; private set; }
		public string Name { get; private set; }
		public bool Persistent { get; private set; }
		public string ProviderName { get; private set; }
		public string RemoteName { get; private set; }
		public string RemotePath { get; private set; }
		public string ResourceType { get; private set; }
		public string Status { get; private set; }
		public string UserName { get; private set; }

        public static IEnumerable<NetworkConnection> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetworkConnection> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetworkConnection> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkConnection");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetworkConnection
                {
                     AccessMask = (uint) (managementObject.Properties["AccessMask"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Comment = (string) (managementObject.Properties["Comment"]?.Value ?? default(string)),
		 ConnectionState = (string) (managementObject.Properties["ConnectionState"]?.Value ?? default(string)),
		 ConnectionType = (string) (managementObject.Properties["ConnectionType"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DisplayType = (string) (managementObject.Properties["DisplayType"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LocalName = (string) (managementObject.Properties["LocalName"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Persistent = (bool) (managementObject.Properties["Persistent"]?.Value ?? default(bool)),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value ?? default(string)),
		 RemoteName = (string) (managementObject.Properties["RemoteName"]?.Value ?? default(string)),
		 RemotePath = (string) (managementObject.Properties["RemotePath"]?.Value ?? default(string)),
		 ResourceType = (string) (managementObject.Properties["ResourceType"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 UserName = (string) (managementObject.Properties["UserName"]?.Value ?? default(string))
                };
        }
    }
}