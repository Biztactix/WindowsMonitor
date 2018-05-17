using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SpinLock
    {
		public byte AcquireDepth { get; private set; }
		public ulong AcquireTime { get; private set; }
		public uint CallerAddress { get; private set; }
		public byte Flag { get; private set; }
		public uint Flags { get; private set; }
		public uint InterruptCount { get; private set; }
		public byte Irql { get; private set; }
		public ulong ReleaseTime { get; private set; }
		public byte[] Reserved { get; private set; }
		public uint SpinCount { get; private set; }
		public uint SpinLockAddress { get; private set; }
		public uint ThreadId { get; private set; }
		public uint WaitTimeInCycles { get; private set; }

        public static IEnumerable<SpinLock> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SpinLock> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SpinLock> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SpinLock");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SpinLock
                {
                     AcquireDepth = (byte) (managementObject.Properties["AcquireDepth"]?.Value ?? default(byte)),
		 AcquireTime = (ulong) (managementObject.Properties["AcquireTime"]?.Value ?? default(ulong)),
		 CallerAddress = (uint) (managementObject.Properties["CallerAddress"]?.Value ?? default(uint)),
		 Flag = (byte) (managementObject.Properties["Flag"]?.Value ?? default(byte)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InterruptCount = (uint) (managementObject.Properties["InterruptCount"]?.Value ?? default(uint)),
		 Irql = (byte) (managementObject.Properties["Irql"]?.Value ?? default(byte)),
		 ReleaseTime = (ulong) (managementObject.Properties["ReleaseTime"]?.Value ?? default(ulong)),
		 Reserved = (byte[]) (managementObject.Properties["Reserved"]?.Value ?? new byte[0]),
		 SpinCount = (uint) (managementObject.Properties["SpinCount"]?.Value ?? default(uint)),
		 SpinLockAddress = (uint) (managementObject.Properties["SpinLockAddress"]?.Value ?? default(uint)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint)),
		 WaitTimeInCycles = (uint) (managementObject.Properties["WaitTimeInCycles"]?.Value ?? default(uint))
                };
        }
    }
}