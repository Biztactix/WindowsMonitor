using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Hardware.SystemConfig.V3
{
    /// <summary>
    /// </summary>
    public sealed class IRQ
    {
		public string DeviceDescription { get; private set; }
		public uint DeviceDescriptionLen { get; private set; }
		public uint Flags { get; private set; }
		public ulong IRQAffinity { get; private set; }
		public ushort IRQGroup { get; private set; }
		public uint IRQNum { get; private set; }
		public ushort Reserved { get; private set; }

        public static IEnumerable<IRQ> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<IRQ> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IRQ> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V3_IRQ");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IRQ
                {
                     DeviceDescription = (string) (managementObject.Properties["DeviceDescription"]?.Value ?? default(string)),
		 DeviceDescriptionLen = (uint) (managementObject.Properties["DeviceDescriptionLen"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IRQAffinity = (ulong) (managementObject.Properties["IRQAffinity"]?.Value ?? default(ulong)),
		 IRQGroup = (ushort) (managementObject.Properties["IRQGroup"]?.Value ?? default(ushort)),
		 IRQNum = (uint) (managementObject.Properties["IRQNum"]?.Value ?? default(uint)),
		 Reserved = (ushort) (managementObject.Properties["Reserved"]?.Value ?? default(ushort))
                };
        }
    }
}