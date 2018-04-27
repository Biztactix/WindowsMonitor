using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class MicrosoftBddInfo
    {
		public string BuildId { get; private set; }
		public string BuildName { get; private set; }
		public string BuildVersion { get; private set; }
		public string CaptureMethod { get; private set; }
		public string CaptureOsdAdvertisementId { get; private set; }
		public string CaptureOsdPackageId { get; private set; }
		public string CaptureOsdProgramName { get; private set; }
		public string CaptureTaskSequenceId { get; private set; }
		public string CaptureTaskSequenceName { get; private set; }
		public string CaptureTaskSequenceVersion { get; private set; }
		public DateTime CaptureTimestamp { get; private set; }
		public string CaptureToolkitVersion { get; private set; }
		public string DeploymentMethod { get; private set; }
		public string DeploymentSource { get; private set; }
		public DateTime DeploymentTimestamp { get; private set; }
		public string DeploymentToolkitVersion { get; private set; }
		public string DeploymentType { get; private set; }
		public string InstanceKey { get; private set; }
		public string OsdAdvertisementId { get; private set; }
		public string OsdPackageId { get; private set; }
		public string OsdProgramName { get; private set; }
		public string TaskSequenceId { get; private set; }
		public string TaskSequenceName { get; private set; }
		public string TaskSequenceVersion { get; private set; }

        public static IEnumerable<MicrosoftBddInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MicrosoftBddInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MicrosoftBddInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Microsoft_BDD_Info");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MicrosoftBddInfo
                {
                     BuildId = (string) (managementObject.Properties["BuildID"]?.Value ?? default(string)),
		 BuildName = (string) (managementObject.Properties["BuildName"]?.Value ?? default(string)),
		 BuildVersion = (string) (managementObject.Properties["BuildVersion"]?.Value ?? default(string)),
		 CaptureMethod = (string) (managementObject.Properties["CaptureMethod"]?.Value ?? default(string)),
		 CaptureOsdAdvertisementId = (string) (managementObject.Properties["CaptureOSDAdvertisementID"]?.Value ?? default(string)),
		 CaptureOsdPackageId = (string) (managementObject.Properties["CaptureOSDPackageID"]?.Value ?? default(string)),
		 CaptureOsdProgramName = (string) (managementObject.Properties["CaptureOSDProgramName"]?.Value ?? default(string)),
		 CaptureTaskSequenceId = (string) (managementObject.Properties["CaptureTaskSequenceID"]?.Value ?? default(string)),
		 CaptureTaskSequenceName = (string) (managementObject.Properties["CaptureTaskSequenceName"]?.Value ?? default(string)),
		 CaptureTaskSequenceVersion = (string) (managementObject.Properties["CaptureTaskSequenceVersion"]?.Value ?? default(string)),
		 CaptureTimestamp = (DateTime) (managementObject.Properties["CaptureTimestamp"]?.Value ?? default(DateTime)),
		 CaptureToolkitVersion = (string) (managementObject.Properties["CaptureToolkitVersion"]?.Value ?? default(string)),
		 DeploymentMethod = (string) (managementObject.Properties["DeploymentMethod"]?.Value ?? default(string)),
		 DeploymentSource = (string) (managementObject.Properties["DeploymentSource"]?.Value ?? default(string)),
		 DeploymentTimestamp = (DateTime) (managementObject.Properties["DeploymentTimestamp"]?.Value ?? default(DateTime)),
		 DeploymentToolkitVersion = (string) (managementObject.Properties["DeploymentToolkitVersion"]?.Value ?? default(string)),
		 DeploymentType = (string) (managementObject.Properties["DeploymentType"]?.Value ?? default(string)),
		 InstanceKey = (string) (managementObject.Properties["InstanceKey"]?.Value ?? default(string)),
		 OsdAdvertisementId = (string) (managementObject.Properties["OSDAdvertisementID"]?.Value ?? default(string)),
		 OsdPackageId = (string) (managementObject.Properties["OSDPackageID"]?.Value ?? default(string)),
		 OsdProgramName = (string) (managementObject.Properties["OSDProgramName"]?.Value ?? default(string)),
		 TaskSequenceId = (string) (managementObject.Properties["TaskSequenceID"]?.Value ?? default(string)),
		 TaskSequenceName = (string) (managementObject.Properties["TaskSequenceName"]?.Value ?? default(string)),
		 TaskSequenceVersion = (string) (managementObject.Properties["TaskSequenceVersion"]?.Value ?? default(string))
                };
        }
    }
}