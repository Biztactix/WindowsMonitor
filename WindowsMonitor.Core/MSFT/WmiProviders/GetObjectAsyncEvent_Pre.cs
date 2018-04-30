using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.WmiProviders
{
    /// <summary>
    /// </summary>
    public sealed class GetObjectAsyncEventPre
    {
		public uint Flags { get; private set; }
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public string Locale { get; private set; }
		public string Namespace { get; private set; }
		public string ObjectPath { get; private set; }
		public string Provider { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public ulong TimeCreated { get; private set; }
		public string TransactionIdentifer { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<GetObjectAsyncEventPre> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<GetObjectAsyncEventPre> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<GetObjectAsyncEventPre> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_GetObjectAsyncEvent_Pre");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new GetObjectAsyncEventPre
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value ?? default(string)),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value ?? default(string)),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value ?? default(string)),
		 ObjectPath = (string) (managementObject.Properties["ObjectPath"]?.Value ?? default(string)),
		 Provider = (string) (managementObject.Properties["provider"]?.Value ?? default(string)),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionIdentifer = (string) (managementObject.Properties["TransactionIdentifer"]?.Value ?? default(string)),
		 User = (string) (managementObject.Properties["User"]?.Value ?? default(string))
                };
        }
    }
}