using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class CSwitch_V1
    {
		public uint Flags { get; private set; }
		public uint NewThreadId { get; private set; }
		public sbyte NewThreadPriority { get; private set; }
		public sbyte NewThreadQuantum { get; private set; }
		public uint OldThreadId { get; private set; }
		public sbyte OldThreadPriority { get; private set; }
		public sbyte OldThreadQuantum { get; private set; }
		public sbyte OldThreadState { get; private set; }
		public sbyte OldThreadWaitIdealProcessor { get; private set; }
		public sbyte OldThreadWaitMode { get; private set; }
		public sbyte OldThreadWaitReason { get; private set; }

        public static IEnumerable<CSwitch_V1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CSwitch_V1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CSwitch_V1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CSwitch_V1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CSwitch_V1
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 NewThreadId = (uint) (managementObject.Properties["NewThreadId"]?.Value ?? default(uint)),
		 NewThreadPriority = (sbyte) (managementObject.Properties["NewThreadPriority"]?.Value ?? default(sbyte)),
		 NewThreadQuantum = (sbyte) (managementObject.Properties["NewThreadQuantum"]?.Value ?? default(sbyte)),
		 OldThreadId = (uint) (managementObject.Properties["OldThreadId"]?.Value ?? default(uint)),
		 OldThreadPriority = (sbyte) (managementObject.Properties["OldThreadPriority"]?.Value ?? default(sbyte)),
		 OldThreadQuantum = (sbyte) (managementObject.Properties["OldThreadQuantum"]?.Value ?? default(sbyte)),
		 OldThreadState = (sbyte) (managementObject.Properties["OldThreadState"]?.Value ?? default(sbyte)),
		 OldThreadWaitIdealProcessor = (sbyte) (managementObject.Properties["OldThreadWaitIdealProcessor"]?.Value ?? default(sbyte)),
		 OldThreadWaitMode = (sbyte) (managementObject.Properties["OldThreadWaitMode"]?.Value ?? default(sbyte)),
		 OldThreadWaitReason = (sbyte) (managementObject.Properties["OldThreadWaitReason"]?.Value ?? default(sbyte))
                };
        }
    }
}