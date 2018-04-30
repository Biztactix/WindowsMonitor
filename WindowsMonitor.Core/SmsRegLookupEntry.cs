using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SmsRegLookupEntry
    {
        public string LookupEntryKey { get; private set; }
        public string Match { get; private set; }
        public string PropertyName { get; private set; }
        public string RegKey { get; private set; }
        public string RegRoot { get; private set; }
        public string RegValue { get; private set; }

        public static IEnumerable<SmsRegLookupEntry> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SmsRegLookupEntry> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SmsRegLookupEntry> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SMS_RegLookupEntry");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SmsRegLookupEntry
                {
                    LookupEntryKey = (string) (managementObject.Properties["LookupEntryKey"]?.Value ?? default(string)),
                    Match = (string) (managementObject.Properties["Match"]?.Value ?? default(string)),
                    PropertyName = (string) (managementObject.Properties["PropertyName"]?.Value ?? default(string)),
                    RegKey = (string) (managementObject.Properties["RegKey"]?.Value ?? default(string)),
                    RegRoot = (string) (managementObject.Properties["RegRoot"]?.Value ?? default(string)),
                    RegValue = (string) (managementObject.Properties["RegValue"]?.Value ?? default(string))
                };
        }
    }
}