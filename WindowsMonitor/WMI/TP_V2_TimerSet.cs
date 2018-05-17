using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TP_V2_TimerSet
    {
		public uint Absolute { get; private set; }
		public ulong DueTime { get; private set; }
		public uint Period { get; private set; }
		public uint SubQueue { get; private set; }
		public uint Timer { get; private set; }
		public uint WindowLength { get; private set; }

        public static IEnumerable<TP_V2_TimerSet> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TP_V2_TimerSet> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TP_V2_TimerSet> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TP_V2_TimerSet");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TP_V2_TimerSet
                {
                     Absolute = (uint) (managementObject.Properties["Absolute"]?.Value ?? default(uint)),
		 DueTime = (ulong) (managementObject.Properties["DueTime"]?.Value ?? default(ulong)),
		 Period = (uint) (managementObject.Properties["Period"]?.Value ?? default(uint)),
		 SubQueue = (uint) (managementObject.Properties["SubQueue"]?.Value ?? default(uint)),
		 Timer = (uint) (managementObject.Properties["Timer"]?.Value ?? default(uint)),
		 WindowLength = (uint) (managementObject.Properties["WindowLength"]?.Value ?? default(uint))
                };
        }
    }
}