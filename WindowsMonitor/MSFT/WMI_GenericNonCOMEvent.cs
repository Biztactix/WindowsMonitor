using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT
{
    /// <summary>
    /// </summary>
    public sealed class WmiGenericNonComEvent
    {
		public uint ProcessId { get; private set; }
		public string[] PropertyNames { get; private set; }
		public string[] PropertyValues { get; private set; }
		public string ProviderName { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<WmiGenericNonComEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiGenericNonComEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiGenericNonComEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_WMI_GenericNonCOMEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiGenericNonComEvent
                {
                     ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 PropertyNames = (string[]) (managementObject.Properties["PropertyNames"]?.Value ?? new string[0]),
		 PropertyValues = (string[]) (managementObject.Properties["PropertyValues"]?.Value ?? new string[0]),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}