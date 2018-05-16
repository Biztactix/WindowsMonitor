using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM.Office
{
    /// <summary>
    /// </summary>
    public sealed class Office365ProPlusConfigurations
    {
        public string AutoUpgrade { get; private set; }
        public string CcmManaged { get; private set; }
        public string CdnBaseUrl { get; private set; }
        public string CfgUpdateChannel { get; private set; }
        public string ClientCulture { get; private set; }
        public string ClientFolder { get; private set; }
        public string GpoChannel { get; private set; }
        public string GpoOfficeMgmtCom { get; private set; }
        public string InstallationPath { get; private set; }
        public string KeyName { get; private set; }
        public string LastScenario { get; private set; }
        public string LastScenarioResult { get; private set; }
        public string OfficeMgmtCom { get; private set; }
        public string Platform { get; private set; }
        public string SharedComputerLicensing { get; private set; }
        public string UpdateChannel { get; private set; }
        public string UpdatePath { get; private set; }
        public string UpdatesEnabled { get; private set; }
        public string UpdateUrl { get; private set; }
        public string VersionToReport { get; private set; }

        public static IEnumerable<Office365ProPlusConfigurations> Retrieve(string remote, string username,
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

        public static IEnumerable<Office365ProPlusConfigurations> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Office365ProPlusConfigurations> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Office365ProPlusConfigurations");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Office365ProPlusConfigurations
                {
                    AutoUpgrade = (string) managementObject.Properties["AutoUpgrade"]?.Value,
                    CcmManaged = (string) managementObject.Properties["CCMManaged"]?.Value,
                    CdnBaseUrl = (string) managementObject.Properties["CDNBaseUrl"]?.Value,
                    CfgUpdateChannel =
                        (string) managementObject.Properties["cfgUpdateChannel"]?.Value,
                    ClientCulture = (string) managementObject.Properties["ClientCulture"]?.Value,
                    ClientFolder = (string) managementObject.Properties["ClientFolder"]?.Value,
                    GpoChannel = (string) managementObject.Properties["GPOChannel"]?.Value,
                    GpoOfficeMgmtCom =
                        (string) managementObject.Properties["GPOOfficeMgmtCOM"]?.Value,
                    InstallationPath =
                        (string) managementObject.Properties["InstallationPath"]?.Value,
                    KeyName = (string) managementObject.Properties["KeyName"]?.Value,
                    LastScenario = (string) managementObject.Properties["LastScenario"]?.Value,
                    LastScenarioResult =
                        (string) managementObject.Properties["LastScenarioResult"]?.Value,
                    OfficeMgmtCom = (string) managementObject.Properties["OfficeMgmtCOM"]?.Value,
                    Platform = (string) managementObject.Properties["Platform"]?.Value,
                    SharedComputerLicensing =
                        (string) managementObject.Properties["SharedComputerLicensing"]?.Value,
                    UpdateChannel = (string) managementObject.Properties["UpdateChannel"]?.Value,
                    UpdatePath = (string) managementObject.Properties["UpdatePath"]?.Value,
                    UpdatesEnabled = (string) managementObject.Properties["UpdatesEnabled"]?.Value,
                    UpdateUrl = (string) managementObject.Properties["UpdateUrl"]?.Value,
                    VersionToReport =
                        (string) managementObject.Properties["VersionToReport"]?.Value
                };
        }
    }
}