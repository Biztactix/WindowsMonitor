using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Trustee
    {
        public string Domain { get; private set; }
        public string Name { get; private set; }
        public byte[] SID { get; private set; }
        public uint SidLength { get; private set; }
        public string SIDString { get; private set; }
        public ulong TIME_CREATED { get; private set; }

        public static Trustee[] Retrieve(string remote, string username, string password)
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

        public static Trustee[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Trustee[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Trustee");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Trustee>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Trustee
                {
                    Domain = (string) managementObject.Properties["Domain"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SID = (byte[]) managementObject.Properties["SID"].Value,
                    SidLength = (uint) managementObject.Properties["SidLength"].Value,
                    SIDString = (string) managementObject.Properties["SIDString"].Value,
                    TIME_CREATED = (ulong) managementObject.Properties["TIME_CREATED"].Value
                });

            return list.ToArray();
        }
    }
}