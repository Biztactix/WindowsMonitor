using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WmiMonitorID
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public ushort[] ManufacturerName { get; private set; }
		public ushort[] ProductCodeID { get; private set; }
		public ushort[] SerialNumberID { get; private set; }
		public ushort[] UserFriendlyName { get; private set; }
		public ushort UserFriendlyNameLength { get; private set; }
		public byte WeekOfManufacture { get; private set; }
		public ushort YearOfManufacture { get; private set; }

        public static IEnumerable<WmiMonitorID> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiMonitorID> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiMonitorID> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WmiMonitorID");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiMonitorID
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 ManufacturerName = (ushort[]) (managementObject.Properties["ManufacturerName"]?.Value ?? new ushort[0]),
		 ProductCodeID = (ushort[]) (managementObject.Properties["ProductCodeID"]?.Value ?? new ushort[0]),
		 SerialNumberID = (ushort[]) (managementObject.Properties["SerialNumberID"]?.Value ?? new ushort[0]),
		 UserFriendlyName = (ushort[]) (managementObject.Properties["UserFriendlyName"]?.Value ?? new ushort[0]),
		 UserFriendlyNameLength = (ushort) (managementObject.Properties["UserFriendlyNameLength"]?.Value ?? default(ushort)),
		 WeekOfManufacture = (byte) (managementObject.Properties["WeekOfManufacture"]?.Value ?? default(byte)),
		 YearOfManufacture = (ushort) (managementObject.Properties["YearOfManufacture"]?.Value ?? default(ushort))
                };
        }
    }
}