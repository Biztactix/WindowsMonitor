using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class StackWalk_Event
    {
		public ulong EventTimeStamp { get; private set; }
		public uint Flags { get; private set; }
		public uint Stack1 { get; private set; }
		public uint Stack10 { get; private set; }
		public uint Stack11 { get; private set; }
		public uint Stack12 { get; private set; }
		public uint Stack13 { get; private set; }
		public uint Stack14 { get; private set; }
		public uint Stack15 { get; private set; }
		public uint Stack16 { get; private set; }
		public uint Stack17 { get; private set; }
		public uint Stack18 { get; private set; }
		public uint Stack19 { get; private set; }
		public uint Stack2 { get; private set; }
		public uint Stack20 { get; private set; }
		public uint Stack21 { get; private set; }
		public uint Stack22 { get; private set; }
		public uint Stack23 { get; private set; }
		public uint Stack24 { get; private set; }
		public uint Stack25 { get; private set; }
		public uint Stack26 { get; private set; }
		public uint Stack27 { get; private set; }
		public uint Stack28 { get; private set; }
		public uint Stack29 { get; private set; }
		public uint Stack3 { get; private set; }
		public uint Stack30 { get; private set; }
		public uint Stack31 { get; private set; }
		public uint Stack32 { get; private set; }
		public uint Stack4 { get; private set; }
		public uint Stack5 { get; private set; }
		public uint Stack6 { get; private set; }
		public uint Stack7 { get; private set; }
		public uint Stack8 { get; private set; }
		public uint Stack9 { get; private set; }
		public uint StackProcess { get; private set; }
		public uint StackThread { get; private set; }

        public static IEnumerable<StackWalk_Event> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<StackWalk_Event> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<StackWalk_Event> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM StackWalk_Event");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new StackWalk_Event
                {
                     EventTimeStamp = (ulong) (managementObject.Properties["EventTimeStamp"]?.Value ?? default(ulong)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Stack1 = (uint) (managementObject.Properties["Stack1"]?.Value ?? default(uint)),
		 Stack10 = (uint) (managementObject.Properties["Stack10"]?.Value ?? default(uint)),
		 Stack11 = (uint) (managementObject.Properties["Stack11"]?.Value ?? default(uint)),
		 Stack12 = (uint) (managementObject.Properties["Stack12"]?.Value ?? default(uint)),
		 Stack13 = (uint) (managementObject.Properties["Stack13"]?.Value ?? default(uint)),
		 Stack14 = (uint) (managementObject.Properties["Stack14"]?.Value ?? default(uint)),
		 Stack15 = (uint) (managementObject.Properties["Stack15"]?.Value ?? default(uint)),
		 Stack16 = (uint) (managementObject.Properties["Stack16"]?.Value ?? default(uint)),
		 Stack17 = (uint) (managementObject.Properties["Stack17"]?.Value ?? default(uint)),
		 Stack18 = (uint) (managementObject.Properties["Stack18"]?.Value ?? default(uint)),
		 Stack19 = (uint) (managementObject.Properties["Stack19"]?.Value ?? default(uint)),
		 Stack2 = (uint) (managementObject.Properties["Stack2"]?.Value ?? default(uint)),
		 Stack20 = (uint) (managementObject.Properties["Stack20"]?.Value ?? default(uint)),
		 Stack21 = (uint) (managementObject.Properties["Stack21"]?.Value ?? default(uint)),
		 Stack22 = (uint) (managementObject.Properties["Stack22"]?.Value ?? default(uint)),
		 Stack23 = (uint) (managementObject.Properties["Stack23"]?.Value ?? default(uint)),
		 Stack24 = (uint) (managementObject.Properties["Stack24"]?.Value ?? default(uint)),
		 Stack25 = (uint) (managementObject.Properties["Stack25"]?.Value ?? default(uint)),
		 Stack26 = (uint) (managementObject.Properties["Stack26"]?.Value ?? default(uint)),
		 Stack27 = (uint) (managementObject.Properties["Stack27"]?.Value ?? default(uint)),
		 Stack28 = (uint) (managementObject.Properties["Stack28"]?.Value ?? default(uint)),
		 Stack29 = (uint) (managementObject.Properties["Stack29"]?.Value ?? default(uint)),
		 Stack3 = (uint) (managementObject.Properties["Stack3"]?.Value ?? default(uint)),
		 Stack30 = (uint) (managementObject.Properties["Stack30"]?.Value ?? default(uint)),
		 Stack31 = (uint) (managementObject.Properties["Stack31"]?.Value ?? default(uint)),
		 Stack32 = (uint) (managementObject.Properties["Stack32"]?.Value ?? default(uint)),
		 Stack4 = (uint) (managementObject.Properties["Stack4"]?.Value ?? default(uint)),
		 Stack5 = (uint) (managementObject.Properties["Stack5"]?.Value ?? default(uint)),
		 Stack6 = (uint) (managementObject.Properties["Stack6"]?.Value ?? default(uint)),
		 Stack7 = (uint) (managementObject.Properties["Stack7"]?.Value ?? default(uint)),
		 Stack8 = (uint) (managementObject.Properties["Stack8"]?.Value ?? default(uint)),
		 Stack9 = (uint) (managementObject.Properties["Stack9"]?.Value ?? default(uint)),
		 StackProcess = (uint) (managementObject.Properties["StackProcess"]?.Value ?? default(uint)),
		 StackThread = (uint) (managementObject.Properties["StackThread"]?.Value ?? default(uint))
                };
        }
    }
}