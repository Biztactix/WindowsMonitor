using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_PortEvent
    {
		public bool Active { get; private set; }
		public uint EventType { get; private set; }
		public uint FabricPortId { get; private set; }
		public string InstanceName { get; private set; }
		public byte[] PortWWN { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<MSFC_PortEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_PortEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_PortEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_PortEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_PortEvent
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 EventType = (uint) (managementObject.Properties["EventType"]?.Value ?? default(uint)),
		 FabricPortId = (uint) (managementObject.Properties["FabricPortId"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 PortWWN = (byte[]) (managementObject.Properties["PortWWN"]?.Value ?? new byte[0]),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}