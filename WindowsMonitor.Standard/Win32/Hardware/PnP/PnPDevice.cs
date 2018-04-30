using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.PnP
{
    /// <summary>
    /// </summary>
    public sealed class PnPDevice
    {
		public short SameElement { get; private set; }
		public short SystemElement { get; private set; }

        public static IEnumerable<PnPDevice> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PnPDevice> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PnPDevice> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPDevice");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PnPDevice
                {
                     SameElement = (short) (managementObject.Properties["SameElement"]?.Value ?? default(short)),
		 SystemElement = (short) (managementObject.Properties["SystemElement"]?.Value ?? default(short))
                };
        }
    }
}