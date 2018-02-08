using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SecurityDescriptor
    {
        public uint ControlFlags { get; private set; }
        public object[] DACL { get; private set; }
        public object Group { get; private set; }
        public object Owner { get; private set; }
        public object[] SACL { get; private set; }
        public ulong TIME_CREATED { get; private set; }

        public static SecurityDescriptor[] Retrieve(string remote, string username, string password)
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

        public static SecurityDescriptor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SecurityDescriptor[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SecurityDescriptor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SecurityDescriptor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SecurityDescriptor
                {
                    ControlFlags = (uint) managementObject.Properties["ControlFlags"].Value,
                    DACL = (object[]) managementObject.Properties["DACL"].Value,
                    Group = managementObject.Properties["Group"].Value,
                    Owner = managementObject.Properties["Owner"].Value,
                    SACL = (object[]) managementObject.Properties["SACL"].Value,
                    TIME_CREATED = (ulong) managementObject.Properties["TIME_CREATED"].Value
                });

            return list.ToArray();
        }
    }
}