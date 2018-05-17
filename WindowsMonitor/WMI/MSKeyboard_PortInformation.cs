using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSKeyboard_PortInformation
    {
		public bool Active { get; private set; }
		public uint ConnectorType { get; private set; }
		public uint DataQueueSize { get; private set; }
		public uint ErrorCount { get; private set; }
		public uint FunctionKeys { get; private set; }
		public uint Indicators { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<MSKeyboard_PortInformation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSKeyboard_PortInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSKeyboard_PortInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSKeyboard_PortInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSKeyboard_PortInformation
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 ConnectorType = (uint) (managementObject.Properties["ConnectorType"]?.Value ?? default(uint)),
		 DataQueueSize = (uint) (managementObject.Properties["DataQueueSize"]?.Value ?? default(uint)),
		 ErrorCount = (uint) (managementObject.Properties["ErrorCount"]?.Value ?? default(uint)),
		 FunctionKeys = (uint) (managementObject.Properties["FunctionKeys"]?.Value ?? default(uint)),
		 Indicators = (uint) (managementObject.Properties["Indicators"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}