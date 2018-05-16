using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT
{
    /// <summary>
    /// </summary>
    public sealed class WmiThreadPoolEvent
    {
		public byte[] SecurityDescriptor { get; private set; }
		public uint ThreadId { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<WmiThreadPoolEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiThreadPoolEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiThreadPoolEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_WmiThreadPoolEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiThreadPoolEvent
                {
                     SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint)),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}