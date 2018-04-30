using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SmsAiInstalledSoftwareSetPropertyValue
    {
        public string EntryNameKey { get; private set; }
        public bool IfRegistryCheckPositive { get; private set; }
        public string PropertyConverter { get; private set; }
        public string PropertyName { get; private set; }
        public string PropertyValue { get; private set; }
        public string SoftwareMatch { get; private set; }
        public string WhenRegData { get; private set; }
        public string WhenRegRoot { get; private set; }
        public string WhenRegSubKey { get; private set; }

        public static IEnumerable<SmsAiInstalledSoftwareSetPropertyValue> Retrieve(string remote, string username,
            string password)
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

        public static IEnumerable<SmsAiInstalledSoftwareSetPropertyValue> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SmsAiInstalledSoftwareSetPropertyValue> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SMS_AI_InstalledSoftwareSetPropertyValue");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SmsAiInstalledSoftwareSetPropertyValue
                {
                    EntryNameKey = (string) (managementObject.Properties["EntryNameKey"]?.Value ?? default(string)),
                    IfRegistryCheckPositive =
                        (bool) (managementObject.Properties["IfRegistryCheckPositive"]?.Value ?? default(bool)),
                    PropertyConverter =
                        (string) (managementObject.Properties["PropertyConverter"]?.Value ?? default(string)),
                    PropertyName = (string) (managementObject.Properties["PropertyName"]?.Value ?? default(string)),
                    PropertyValue = (string) (managementObject.Properties["PropertyValue"]?.Value ?? default(string)),
                    SoftwareMatch = (string) (managementObject.Properties["SoftwareMatch"]?.Value ?? default(string)),
                    WhenRegData = (string) (managementObject.Properties["WhenRegData"]?.Value ?? default(string)),
                    WhenRegRoot = (string) (managementObject.Properties["WhenRegRoot"]?.Value ?? default(string)),
                    WhenRegSubKey = (string) (managementObject.Properties["WhenRegSubKey"]?.Value ?? default(string))
                };
        }
    }
}