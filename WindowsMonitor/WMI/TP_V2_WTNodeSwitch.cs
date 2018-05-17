using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TP_V2_WTNodeSwitch
    {
		public ushort CurrentGroup { get; private set; }
		public uint CurrentNode { get; private set; }
		public uint CurrentWorkerCount { get; private set; }
		public ushort NextGroup { get; private set; }
		public uint NextNode { get; private set; }
		public uint NextWorkerCount { get; private set; }
		public uint PoolId { get; private set; }

        public static IEnumerable<TP_V2_WTNodeSwitch> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TP_V2_WTNodeSwitch> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TP_V2_WTNodeSwitch> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TP_V2_WTNodeSwitch");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TP_V2_WTNodeSwitch
                {
                     CurrentGroup = (ushort) (managementObject.Properties["CurrentGroup"]?.Value ?? default(ushort)),
		 CurrentNode = (uint) (managementObject.Properties["CurrentNode"]?.Value ?? default(uint)),
		 CurrentWorkerCount = (uint) (managementObject.Properties["CurrentWorkerCount"]?.Value ?? default(uint)),
		 NextGroup = (ushort) (managementObject.Properties["NextGroup"]?.Value ?? default(ushort)),
		 NextNode = (uint) (managementObject.Properties["NextNode"]?.Value ?? default(uint)),
		 NextWorkerCount = (uint) (managementObject.Properties["NextWorkerCount"]?.Value ?? default(uint)),
		 PoolId = (uint) (managementObject.Properties["PoolId"]?.Value ?? default(uint))
                };
        }
    }
}