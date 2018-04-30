using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.NetServices
{
    /// <summary>
    /// </summary>
    public sealed class DifferentPidConnected
    {
		public uint ActualPid { get; private set; }
		public uint ExpectedPid { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public string Service { get; private set; }
		public ulong TimeCreated { get; private set; }

        public static IEnumerable<DifferentPidConnected> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DifferentPidConnected> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DifferentPidConnected> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_NetServiceDifferentPIDConnected");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DifferentPidConnected
                {
                     ActualPid = (uint) (managementObject.Properties["ActualPID"]?.Value ?? default(uint)),
		 ExpectedPid = (uint) (managementObject.Properties["ExpectedPID"]?.Value ?? default(uint)),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Service = (string) (managementObject.Properties["Service"]?.Value ?? default(string)),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}