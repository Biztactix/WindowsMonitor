using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.PnP
{
    /// <summary>
    /// </summary>
    public sealed class PnPDevicePropertyUint8
    {
		public byte Data { get; private set; }
		public string DeviceID { get; private set; }
		public string key { get; private set; }
		public string KeyName { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<PnPDevicePropertyUint8> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PnPDevicePropertyUint8> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PnPDevicePropertyUint8> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPDevicePropertyUint8");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PnPDevicePropertyUint8
                {
                     Data = (byte) (managementObject.Properties["Data"]?.Value ?? default(byte)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 key = (string) (managementObject.Properties["key"]?.Value ?? default(string)),
		 KeyName = (string) (managementObject.Properties["KeyName"]?.Value ?? default(string)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}