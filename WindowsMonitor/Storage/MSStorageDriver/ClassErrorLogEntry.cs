using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ClassErrorLogEntry
    {
		public bool errorPaging { get; private set; }
		public byte errorReserved { get; private set; }
		public bool errorRetried { get; private set; }
		public bool errorUnhandled { get; private set; }
		public DateTime eventTime { get; private set; }
		public uint portNumber { get; private set; }
		public byte[] reserved { get; private set; }
		public dynamic senseData { get; private set; }
		public dynamic srb { get; private set; }
		public ulong tickCount { get; private set; }

        public static IEnumerable<ClassErrorLogEntry> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ClassErrorLogEntry> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ClassErrorLogEntry> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSStorageDriver_ClassErrorLogEntry");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ClassErrorLogEntry
                {
                     errorPaging = (bool) (managementObject.Properties["errorPaging"]?.Value ?? default(bool)),
		 errorReserved = (byte) (managementObject.Properties["errorReserved"]?.Value ?? default(byte)),
		 errorRetried = (bool) (managementObject.Properties["errorRetried"]?.Value ?? default(bool)),
		 errorUnhandled = (bool) (managementObject.Properties["errorUnhandled"]?.Value ?? default(bool)),
		 eventTime = (DateTime) (managementObject.Properties["eventTime"]?.Value ?? default(DateTime)),
		 portNumber = (uint) (managementObject.Properties["portNumber"]?.Value ?? default(uint)),
		 reserved = (byte[]) (managementObject.Properties["reserved"]?.Value ?? new byte[0]),
		 senseData = (dynamic) (managementObject.Properties["senseData"]?.Value ?? default(dynamic)),
		 srb = (dynamic) (managementObject.Properties["srb"]?.Value ?? default(dynamic)),
		 tickCount = (ulong) (managementObject.Properties["tickCount"]?.Value ?? default(ulong))
                };
        }
    }
}