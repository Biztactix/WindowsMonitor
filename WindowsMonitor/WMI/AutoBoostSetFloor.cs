using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class AutoBoostSetFloor
    {
		public byte BoostFlags { get; private set; }
		public uint Flags { get; private set; }
		public byte IoPriorities { get; private set; }
		public uint Lock { get; private set; }
		public byte NewCpuPriorityFloor { get; private set; }
		public byte OldCpuPriority { get; private set; }
		public uint ThreadId { get; private set; }

        public static IEnumerable<AutoBoostSetFloor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AutoBoostSetFloor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AutoBoostSetFloor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM AutoBoostSetFloor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AutoBoostSetFloor
                {
                     BoostFlags = (byte) (managementObject.Properties["BoostFlags"]?.Value ?? default(byte)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IoPriorities = (byte) (managementObject.Properties["IoPriorities"]?.Value ?? default(byte)),
		 Lock = (uint) (managementObject.Properties["Lock"]?.Value ?? default(uint)),
		 NewCpuPriorityFloor = (byte) (managementObject.Properties["NewCpuPriorityFloor"]?.Value ?? default(byte)),
		 OldCpuPriority = (byte) (managementObject.Properties["OldCpuPriority"]?.Value ?? default(byte)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint))
                };
        }
    }
}