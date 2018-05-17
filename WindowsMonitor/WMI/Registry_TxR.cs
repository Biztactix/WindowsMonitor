using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_TxR
    {
		public uint Flags { get; private set; }
		public string Hive { get; private set; }
		public ulong OperationTime { get; private set; }
		public uint Status { get; private set; }
		public dynamic TxrGUID { get; private set; }
		public uint UowCount { get; private set; }

        public static IEnumerable<Registry_TxR> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_TxR> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_TxR> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_TxR");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_TxR
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Hive = (string) (managementObject.Properties["Hive"]?.Value ?? default(string)),
		 OperationTime = (ulong) (managementObject.Properties["OperationTime"]?.Value ?? default(ulong)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint)),
		 TxrGUID = (dynamic) (managementObject.Properties["TxrGUID"]?.Value ?? default(dynamic)),
		 UowCount = (uint) (managementObject.Properties["UowCount"]?.Value ?? default(uint))
                };
        }
    }
}