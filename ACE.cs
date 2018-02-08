using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ACE
    {
        public uint AccessMask { get; private set; }
        public uint AceFlags { get; private set; }
        public uint AceType { get; private set; }
        public string GuidInheritedObjectType { get; private set; }
        public string GuidObjectType { get; private set; }
        public ulong TIME_CREATED { get; private set; }
        public object Trustee { get; private set; }

        public static ACE[] Retrieve(string remote, string username, string password)
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

        public static ACE[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ACE[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ACE");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ACE>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ACE
                {
                    AccessMask = (uint) managementObject.Properties["AccessMask"].Value,
                    AceFlags = (uint) managementObject.Properties["AceFlags"].Value,
                    AceType = (uint) managementObject.Properties["AceType"].Value,
                    GuidInheritedObjectType = (string) managementObject.Properties["GuidInheritedObjectType"].Value,
                    GuidObjectType = (string) managementObject.Properties["GuidObjectType"].Value,
                    TIME_CREATED = (ulong) managementObject.Properties["TIME_CREATED"].Value,
                    Trustee = managementObject.Properties["Trustee"].Value
                });

            return list.ToArray();
        }
    }
}