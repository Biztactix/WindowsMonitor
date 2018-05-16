using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Storage
{
    /// <summary>
    /// </summary>
    public sealed class LogicalShareAccess
    {
		public uint AccessMask { get; private set; }
		public string GuidInheritedObjectType { get; private set; }
		public string GuidObjectType { get; private set; }
		public uint Inheritance { get; private set; }
		public short SecuritySetting { get; private set; }
		public short Trustee { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<LogicalShareAccess> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LogicalShareAccess> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LogicalShareAccess> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalShareAccess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LogicalShareAccess
                {
                     AccessMask = (uint) (managementObject.Properties["AccessMask"]?.Value ?? default(uint)),
		 GuidInheritedObjectType = (string) (managementObject.Properties["GuidInheritedObjectType"]?.Value),
		 GuidObjectType = (string) (managementObject.Properties["GuidObjectType"]?.Value),
		 Inheritance = (uint) (managementObject.Properties["Inheritance"]?.Value ?? default(uint)),
		 SecuritySetting = (short) (managementObject.Properties["SecuritySetting"]?.Value ?? default(short)),
		 Trustee = (short) (managementObject.Properties["Trustee"]?.Value ?? default(short)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}