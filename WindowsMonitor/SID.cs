using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SID
    {
		public string AccountName { get; private set; }
		public byte[] BinaryRepresentation { get; private set; }
		public string ReferencedDomainName { get; private set; }
		public string Value { get; private set; }
		public uint SidLength { get; private set; }

        public static IEnumerable<SID> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SID> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SID> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SID");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SID
                {
                     AccountName = (string) (managementObject.Properties["AccountName"]?.Value),
		 BinaryRepresentation = (byte[]) (managementObject.Properties["BinaryRepresentation"]?.Value ?? new byte[0]),
		 ReferencedDomainName = (string) (managementObject.Properties["ReferencedDomainName"]?.Value),
		 Value = (string) (managementObject.Properties["SID"]?.Value),
		 SidLength = (uint) (managementObject.Properties["SidLength"]?.Value ?? default(uint))
                };
        }
    }
}