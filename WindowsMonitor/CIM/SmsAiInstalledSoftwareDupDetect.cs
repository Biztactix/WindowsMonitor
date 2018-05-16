using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SmsAiInstalledSoftwareDupDetect
    {
        public string EntryNameKey { get; private set; }
        public string Software1 { get; private set; }
        public string Software2 { get; private set; }

        public static IEnumerable<SmsAiInstalledSoftwareDupDetect> Retrieve(string remote, string username,
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

        public static IEnumerable<SmsAiInstalledSoftwareDupDetect> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SmsAiInstalledSoftwareDupDetect> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SMS_AI_InstalledSoftwareDupDetect");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SmsAiInstalledSoftwareDupDetect
                {
                    EntryNameKey = (string) managementObject.Properties["EntryNameKey"]?.Value,
                    Software1 = (string) managementObject.Properties["Software1"]?.Value,
                    Software2 = (string) managementObject.Properties["Software2"]?.Value
                };
        }
    }
}