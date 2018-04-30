using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.NetServices
{
    /// <summary>
    /// </summary>
    public sealed class NetServiceStopControlSuccess
    {
		public string Comment { get; private set; }
		public string Control { get; private set; }
		public string Reason { get; private set; }
		public string ReasonText { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public string Service { get; private set; }
		public string Sid { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<NetServiceStopControlSuccess> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetServiceStopControlSuccess> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetServiceStopControlSuccess> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_NetServiceStopControlSuccess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetServiceStopControlSuccess
                {
                     Comment = (string) (managementObject.Properties["Comment"]?.Value ?? default(string)),
		 Control = (string) (managementObject.Properties["Control"]?.Value ?? default(string)),
		 Reason = (string) (managementObject.Properties["Reason"]?.Value ?? default(string)),
		 ReasonText = (string) (managementObject.Properties["ReasonText"]?.Value ?? default(string)),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Service = (string) (managementObject.Properties["Service"]?.Value ?? default(string)),
		 Sid = (string) (managementObject.Properties["sid"]?.Value ?? default(string)),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}