using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.PnP
{
    /// <summary>
    /// </summary>
    public sealed class PnPDevicePropertyReal32Array
    {
		public float[] Data { get; private set; }
		public string DeviceID { get; private set; }
		public string key { get; private set; }
		public string KeyName { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<PnPDevicePropertyReal32Array> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PnPDevicePropertyReal32Array> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PnPDevicePropertyReal32Array> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPDevicePropertyReal32Array");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PnPDevicePropertyReal32Array
                {
                     Data = (float[]) (managementObject.Properties["Data"]?.Value ?? new float[0]),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value),
		 key = (string) (managementObject.Properties["key"]?.Value),
		 KeyName = (string) (managementObject.Properties["KeyName"]?.Value),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}