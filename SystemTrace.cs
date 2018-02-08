using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SystemTrace
    {
        public byte[] SECURITY_DESCRIPTOR { get; private set; }
        public ulong TIME_CREATED { get; private set; }

        public static SystemTrace[] Retrieve(string remote, string username, string password)
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

        public static SystemTrace[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SystemTrace[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SystemTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SystemTrace>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SystemTrace
                {
                    SECURITY_DESCRIPTOR = (byte[]) managementObject.Properties["SECURITY_DESCRIPTOR"].Value,
                    TIME_CREATED = (ulong) managementObject.Properties["TIME_CREATED"].Value
                });

            return list.ToArray();
        }
    }
}