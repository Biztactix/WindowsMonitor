using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT
{
    /// <summary>
    /// </summary>
    public sealed class WmiCancelNotificationSink
    {
		public string Namespace { get; private set; }
		public string Query { get; private set; }
		public string QueryLanguage { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public ulong Sink { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<WmiCancelNotificationSink> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiCancelNotificationSink> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiCancelNotificationSink> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_WmiCancelNotificationSink");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiCancelNotificationSink
                {
                     Namespace = (string) (managementObject.Properties["Namespace"]?.Value),
		 Query = (string) (managementObject.Properties["Query"]?.Value),
		 QueryLanguage = (string) (managementObject.Properties["QueryLanguage"]?.Value),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Sink = (ulong) (managementObject.Properties["Sink"]?.Value ?? default(ulong)),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}