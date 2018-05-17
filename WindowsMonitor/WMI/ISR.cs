using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ISR
    {
		public uint Flags { get; private set; }
		public dynamic InitialTime { get; private set; }
		public byte Reserved { get; private set; }
		public byte ReturnValue { get; private set; }
		public uint Routine { get; private set; }
		public ushort Vector { get; private set; }

        public static IEnumerable<ISR> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISR> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISR> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISR");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISR
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InitialTime = (dynamic) (managementObject.Properties["InitialTime"]?.Value ?? default(dynamic)),
		 Reserved = (byte) (managementObject.Properties["Reserved"]?.Value ?? default(byte)),
		 ReturnValue = (byte) (managementObject.Properties["ReturnValue"]?.Value ?? default(byte)),
		 Routine = (uint) (managementObject.Properties["Routine"]?.Value ?? default(uint)),
		 Vector = (ushort) (managementObject.Properties["Vector"]?.Value ?? default(ushort))
                };
        }
    }
}