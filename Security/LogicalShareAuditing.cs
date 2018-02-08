using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LogicalShareAuditing
    {
        public uint AuditedAccessMask { get; private set; }
        public string GuidInheritedObjectType { get; private set; }
        public string GuidObjectType { get; private set; }
        public uint Inheritance { get; private set; }
        public string SecuritySetting { get; private set; }
        public string Trustee { get; private set; }
        public uint Type { get; private set; }

        public static LogicalShareAuditing[] Retrieve(string remote, string username, string password)
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

        public static LogicalShareAuditing[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LogicalShareAuditing[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalShareAuditing");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LogicalShareAuditing>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LogicalShareAuditing
                {
                    AuditedAccessMask = (uint) managementObject.Properties["AuditedAccessMask"].Value,
                    GuidInheritedObjectType = (string) managementObject.Properties["GuidInheritedObjectType"].Value,
                    GuidObjectType = (string) managementObject.Properties["GuidObjectType"].Value,
                    Inheritance = (uint) managementObject.Properties["Inheritance"].Value,
                    SecuritySetting = (string) managementObject.Properties["SecuritySetting"].Value,
                    Trustee = (string) managementObject.Properties["Trustee"].Value,
                    Type = (uint) managementObject.Properties["Type"].Value
                });

            return list.ToArray();
        }
    }
}