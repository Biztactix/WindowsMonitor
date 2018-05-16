using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class Sql2012
    {
        public bool IsReadOnly { get; private set; }
        public uint PropertyIndex { get; private set; }
        public string PropertyName { get; private set; }
        public uint PropertyNumValue { get; private set; }
        public string PropertyStrValue { get; private set; }
        public uint PropertyValueType { get; private set; }
        public string ServiceName { get; private set; }
        public uint SqlServiceType { get; private set; }

        public static IEnumerable<Sql2012> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Sql2012> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Sql2012> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SQL_2012");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Sql2012
                {
                    IsReadOnly = (bool) (managementObject.Properties["IsReadOnly"]?.Value ?? default(bool)),
                    PropertyIndex = (uint) (managementObject.Properties["PropertyIndex"]?.Value ?? default(uint)),
                    PropertyName = (string) managementObject.Properties["PropertyName"]?.Value,
                    PropertyNumValue = (uint) (managementObject.Properties["PropertyNumValue"]?.Value ?? default(uint)),
                    PropertyStrValue =
                        (string) managementObject.Properties["PropertyStrValue"]?.Value,
                    PropertyValueType =
                        (uint) (managementObject.Properties["PropertyValueType"]?.Value ?? default(uint)),
                    ServiceName = (string) managementObject.Properties["ServiceName"]?.Value,
                    SqlServiceType = (uint) (managementObject.Properties["SqlServiceType"]?.Value ?? default(uint))
                };
        }
    }
}