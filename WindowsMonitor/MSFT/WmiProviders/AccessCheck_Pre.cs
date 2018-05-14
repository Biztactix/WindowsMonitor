using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.WmiProviders
{
    /// <summary>
    /// </summary>
    public sealed class AccessCheckPre
    {
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public string Locale { get; private set; }
		public string Namespace { get; private set; }
		public string Provider { get; private set; }
		public string Query { get; private set; }
		public string QueryLanguage { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public byte[] Sid { get; private set; }
		public ulong TimeCreated { get; private set; }
		public string TransactionIdentifer { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<AccessCheckPre> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AccessCheckPre> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AccessCheckPre> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_AccessCheck_Pre");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AccessCheckPre
                {
                     HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value),
		 Provider = (string) (managementObject.Properties["provider"]?.Value),
		 Query = (string) (managementObject.Properties["Query"]?.Value),
		 QueryLanguage = (string) (managementObject.Properties["QueryLanguage"]?.Value),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Sid = (byte[]) (managementObject.Properties["Sid"]?.Value ?? new byte[0]),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionIdentifer = (string) (managementObject.Properties["TransactionIdentifer"]?.Value),
		 User = (string) (managementObject.Properties["User"]?.Value)
                };
        }
    }
}