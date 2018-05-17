using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class CSwitch_V2
    {
		public uint Flags { get; private set; }
		public uint NewThreadId { get; private set; }
		public sbyte NewThreadPriority { get; private set; }
		public uint NewThreadWaitTime { get; private set; }
		public uint OldThreadId { get; private set; }
		public sbyte OldThreadPriority { get; private set; }
		public sbyte OldThreadState { get; private set; }
		public sbyte OldThreadWaitIdealProcessor { get; private set; }
		public sbyte OldThreadWaitMode { get; private set; }
		public sbyte OldThreadWaitReason { get; private set; }
		public byte PreviousCState { get; private set; }
		public uint Reserved { get; private set; }
		public sbyte SpareByte { get; private set; }

        public static IEnumerable<CSwitch_V2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CSwitch_V2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CSwitch_V2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CSwitch_V2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CSwitch_V2
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 NewThreadId = (uint) (managementObject.Properties["NewThreadId"]?.Value ?? default(uint)),
		 NewThreadPriority = (sbyte) (managementObject.Properties["NewThreadPriority"]?.Value ?? default(sbyte)),
		 NewThreadWaitTime = (uint) (managementObject.Properties["NewThreadWaitTime"]?.Value ?? default(uint)),
		 OldThreadId = (uint) (managementObject.Properties["OldThreadId"]?.Value ?? default(uint)),
		 OldThreadPriority = (sbyte) (managementObject.Properties["OldThreadPriority"]?.Value ?? default(sbyte)),
		 OldThreadState = (sbyte) (managementObject.Properties["OldThreadState"]?.Value ?? default(sbyte)),
		 OldThreadWaitIdealProcessor = (sbyte) (managementObject.Properties["OldThreadWaitIdealProcessor"]?.Value ?? default(sbyte)),
		 OldThreadWaitMode = (sbyte) (managementObject.Properties["OldThreadWaitMode"]?.Value ?? default(sbyte)),
		 OldThreadWaitReason = (sbyte) (managementObject.Properties["OldThreadWaitReason"]?.Value ?? default(sbyte)),
		 PreviousCState = (byte) (managementObject.Properties["PreviousCState"]?.Value ?? default(byte)),
		 Reserved = (uint) (managementObject.Properties["Reserved"]?.Value ?? default(uint)),
		 SpareByte = (sbyte) (managementObject.Properties["SpareByte"]?.Value ?? default(sbyte))
                };
        }
    }
}