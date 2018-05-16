using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM.Hardware.Video
{
    /// <summary>
    /// </summary>
    public sealed class VideoBiosFeatureVideoBiosElements
    {
		public string GroupComponent { get; private set; }
		public string PartComponent { get; private set; }

        public static IEnumerable<VideoBiosFeatureVideoBiosElements> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<VideoBiosFeatureVideoBiosElements> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<VideoBiosFeatureVideoBiosElements> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_VideoBIOSFeatureVideoBIOSElements");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new VideoBiosFeatureVideoBiosElements
                {
                     GroupComponent = (string) (managementObject.Properties["GroupComponent"]?.Value ?? default(string)),
		 PartComponent = (string) (managementObject.Properties["PartComponent"]?.Value ?? default(string))
                };
        }
    }
}