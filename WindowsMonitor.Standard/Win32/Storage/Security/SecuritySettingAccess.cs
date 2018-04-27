using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class SecuritySettingAccess
    {
		public uint AccessMask { get; private set; }
		public string GuidInheritedObjectType { get; private set; }
		public string GuidObjectType { get; private set; }
		public uint Inheritance { get; private set; }
		public short SecuritySetting { get; private set; }
		public short Trustee { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<SecuritySettingAccess> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SecuritySettingAccess> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SecuritySettingAccess> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SecuritySettingAccess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SecuritySettingAccess
                {
                     AccessMask = (uint) (managementObject.Properties["AccessMask"]?.Value ?? default(uint)),
		 GuidInheritedObjectType = (string) (managementObject.Properties["GuidInheritedObjectType"]?.Value ?? default(string)),
		 GuidObjectType = (string) (managementObject.Properties["GuidObjectType"]?.Value ?? default(string)),
		 Inheritance = (uint) (managementObject.Properties["Inheritance"]?.Value ?? default(uint)),
		 SecuritySetting = (short) (managementObject.Properties["SecuritySetting"]?.Value ?? default(short)),
		 Trustee = (short) (managementObject.Properties["Trustee"]?.Value ?? default(short)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}