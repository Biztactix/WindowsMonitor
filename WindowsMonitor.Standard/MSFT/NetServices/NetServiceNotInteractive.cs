using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.NetServices
{
    /// <summary>
    /// </summary>
    public sealed class NetServiceNotInteractive
    {
		public byte[] SecurityDescriptor { get; private set; }
		public string Service { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<NetServiceNotInteractive> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetServiceNotInteractive> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetServiceNotInteractive> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_NetServiceNotInteractive");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetServiceNotInteractive
                {
                     SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Service = (string) (managementObject.Properties["Service"]?.Value ?? default(string)),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}