using System;
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
                    BuildId = (string) managementObject.Properties["BuildID"]?.Value,
                    BuildName = (string) managementObject.Properties["BuildName"]?.Value,
                    BuildVersion = (string) managementObject.Properties["BuildVersion"]?.Value,
                    CaptureMethod = (string) managementObject.Properties["CaptureMethod"]?.Value,
                    CaptureOsdAdvertisementId =
                        (string) managementObject.Properties["CaptureOSDAdvertisementID"]?.Value,
                    CaptureOsdPackageId =
                        (string) managementObject.Properties["CaptureOSDPackageID"]?.Value,
                    CaptureOsdProgramName =
                        (string) managementObject.Properties["CaptureOSDProgramName"]?.Value,
                    CaptureTaskSequenceId =
                        (string) managementObject.Properties["CaptureTaskSequenceID"]?.Value,
                    CaptureTaskSequenceName =
                        (string) managementObject.Properties["CaptureTaskSequenceName"]?.Value,
                    CaptureTaskSequenceVersion =
                        (string) managementObject.Properties["CaptureTaskSequenceVersion"]?.Value,
                    CaptureTimestamp =
                        ManagementDateTimeConverter.ToDateTime(
                            managementObject.Properties["CaptureTimestamp"]?.Value as string ??
                            "00010102000000.000000+060"),
                    CaptureToolkitVersion =
                        (string) managementObject.Properties["CaptureToolkitVersion"]?.Value,
                    DeploymentMethod =
                        (string) managementObject.Properties["DeploymentMethod"]?.Value,
                    DeploymentSource =
                        (string) managementObject.Properties["DeploymentSource"]?.Value,
                    DeploymentTimestamp =
                        ManagementDateTimeConverter.ToDateTime(
                            managementObject.Properties["DeploymentTimestamp"]?.Value as string ??
                            "00010102000000.000000+060"),
                    DeploymentToolkitVersion =
                        (string) managementObject.Properties["DeploymentToolkitVersion"]?.Value,
                    DeploymentType = (string) managementObject.Properties["DeploymentType"]?.Value,
                    InstanceKey = (string) managementObject.Properties["InstanceKey"]?.Value,
                    OsdAdvertisementId =
                        (string) managementObject.Properties["OSDAdvertisementID"]?.Value,
                    OsdPackageId = (string) managementObject.Properties["OSDPackageID"]?.Value,
                    OsdProgramName = (string) managementObject.Properties["OSDProgramName"]?.Value,
                    TaskSequenceId = (string) managementObject.Properties["TaskSequenceID"]?.Value,
                    TaskSequenceName =
                        (string) managementObject.Properties["TaskSequenceName"]?.Value,
                    TaskSequenceVersion =
                        (string) managementObject.Properties["TaskSequenceVersion"]?.Value
                };
        }
    }
}