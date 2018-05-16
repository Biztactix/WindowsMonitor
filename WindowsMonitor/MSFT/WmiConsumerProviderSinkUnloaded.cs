using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT
{
    /// <summary>
    /// </summary>
    public sealed class WmiConsumerProviderSinkUnloaded
    {
		public string Consumer { get; private set; }
		public string Machine { get; private set; }
		public string Namespace { get; private set; }
		public string ProviderName { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<WmiConsumerProviderSinkUnloaded> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiConsumerProviderSinkUnloaded> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiConsumerProviderSinkUnloaded> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_WmiConsumerProviderSinkUnloaded");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiConsumerProviderSinkUnloaded
                {
                     Consumer =  (managementObject.Properties["Consumer"]?.Value?.ToString()),
		 Machine = (string) (managementObject.Properties["Machine"]?.Value),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}