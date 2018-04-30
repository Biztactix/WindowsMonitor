using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.WmiProviders
{
    /// <summary>
    /// </summary>
    public sealed class CancelQueryPost
    {
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public string Locale { get; private set; }
		public string Namespace { get; private set; }
		public string Provider { get; private set; }
		public uint QueryId { get; private set; }
		public uint Result { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public ulong TimeCreated { get; private set; }
		public string TransactionIdentifer { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<CancelQueryPost> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CancelQueryPost> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CancelQueryPost> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_CancelQuery_Post");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CancelQueryPost
                {
                     HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value ?? default(string)),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value ?? default(string)),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value ?? default(string)),
		 Provider = (string) (managementObject.Properties["provider"]?.Value ?? default(string)),
		 QueryId = (uint) (managementObject.Properties["QueryId"]?.Value ?? default(uint)),
		 Result = (uint) (managementObject.Properties["Result"]?.Value ?? default(uint)),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionIdentifer = (string) (managementObject.Properties["TransactionIdentifer"]?.Value ?? default(string)),
		 User = (string) (managementObject.Properties["User"]?.Value ?? default(string))
                };
        }
    }
}