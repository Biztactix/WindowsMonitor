using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Thread_V3_TypeGroup1
    {
		public uint Affinity { get; private set; }
		public byte BasePriority { get; private set; }
		public uint Flags { get; private set; }
		public byte IoPriority { get; private set; }
		public byte PagePriority { get; private set; }
		public uint ProcessId { get; private set; }
		public uint StackBase { get; private set; }
		public uint StackLimit { get; private set; }
		public uint SubProcessTag { get; private set; }
		public uint TebBase { get; private set; }
		public byte ThreadFlags { get; private set; }
		public uint TThreadId { get; private set; }
		public uint UserStackBase { get; private set; }
		public uint UserStackLimit { get; private set; }
		public uint Win32StartAddr { get; private set; }

        public static IEnumerable<Thread_V3_TypeGroup1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Thread_V3_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Thread_V3_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Thread_V3_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Thread_V3_TypeGroup1
                {
                     Affinity = (uint) (managementObject.Properties["Affinity"]?.Value ?? default(uint)),
		 BasePriority = (byte) (managementObject.Properties["BasePriority"]?.Value ?? default(byte)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IoPriority = (byte) (managementObject.Properties["IoPriority"]?.Value ?? default(byte)),
		 PagePriority = (byte) (managementObject.Properties["PagePriority"]?.Value ?? default(byte)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 StackBase = (uint) (managementObject.Properties["StackBase"]?.Value ?? default(uint)),
		 StackLimit = (uint) (managementObject.Properties["StackLimit"]?.Value ?? default(uint)),
		 SubProcessTag = (uint) (managementObject.Properties["SubProcessTag"]?.Value ?? default(uint)),
		 TebBase = (uint) (managementObject.Properties["TebBase"]?.Value ?? default(uint)),
		 ThreadFlags = (byte) (managementObject.Properties["ThreadFlags"]?.Value ?? default(byte)),
		 TThreadId = (uint) (managementObject.Properties["TThreadId"]?.Value ?? default(uint)),
		 UserStackBase = (uint) (managementObject.Properties["UserStackBase"]?.Value ?? default(uint)),
		 UserStackLimit = (uint) (managementObject.Properties["UserStackLimit"]?.Value ?? default(uint)),
		 Win32StartAddr = (uint) (managementObject.Properties["Win32StartAddr"]?.Value ?? default(uint))
                };
        }
    }
}