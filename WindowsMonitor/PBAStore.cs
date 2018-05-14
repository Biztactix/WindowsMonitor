using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class PbaStore
    {
        public uint AllocSize { get; private set; }
        public string ClientIp { get; private set; }
        public string ClientName { get; private set; }
        public string CompleteTime { get; private set; }
        public string ExpireTime { get; private set; }
        public string Path { get; private set; }
        public string ShareName { get; private set; }
        public string StartTime { get; private set; }
        public string UserName { get; private set; }

        public static IEnumerable<PbaStore> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<PbaStore> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PbaStore> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PBAStore");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PbaStore
                {
                    AllocSize = (uint) (managementObject.Properties["AllocSize"]?.Value ?? default(uint)),
                    ClientIp = (string) (managementObject.Properties["ClientIP"]?.Value),
                    ClientName = (string) (managementObject.Properties["ClientName"]?.Value),
                    CompleteTime = (string) (managementObject.Properties["CompleteTime"]?.Value),
                    ExpireTime = (string) (managementObject.Properties["ExpireTime"]?.Value),
                    Path = (string) (managementObject.Properties["Path"]?.Value),
                    ShareName = (string) (managementObject.Properties["ShareName"]?.Value),
                    StartTime = (string) (managementObject.Properties["StartTime"]?.Value),
                    UserName = (string) (managementObject.Properties["UserName"]?.Value)
                };
        }
    }
}