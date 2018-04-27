using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
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

        public static IEnumerable<Office365ProPlusConfigurations> Retrieve(string remote, string username, string password)
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
                     AutoUpgrade = (string) (managementObject.Properties["AutoUpgrade"]?.Value ?? default(string)),
		 CcmManaged = (string) (managementObject.Properties["CCMManaged"]?.Value ?? default(string)),
		 CdnBaseUrl = (string) (managementObject.Properties["CDNBaseUrl"]?.Value ?? default(string)),
		 CfgUpdateChannel = (string) (managementObject.Properties["cfgUpdateChannel"]?.Value ?? default(string)),
		 ClientCulture = (string) (managementObject.Properties["ClientCulture"]?.Value ?? default(string)),
		 ClientFolder = (string) (managementObject.Properties["ClientFolder"]?.Value ?? default(string)),
		 GpoChannel = (string) (managementObject.Properties["GPOChannel"]?.Value ?? default(string)),
		 GpoOfficeMgmtCom = (string) (managementObject.Properties["GPOOfficeMgmtCOM"]?.Value ?? default(string)),
		 InstallationPath = (string) (managementObject.Properties["InstallationPath"]?.Value ?? default(string)),
		 KeyName = (string) (managementObject.Properties["KeyName"]?.Value ?? default(string)),
		 LastScenario = (string) (managementObject.Properties["LastScenario"]?.Value ?? default(string)),
		 LastScenarioResult = (string) (managementObject.Properties["LastScenarioResult"]?.Value ?? default(string)),
		 OfficeMgmtCom = (string) (managementObject.Properties["OfficeMgmtCOM"]?.Value ?? default(string)),
		 Platform = (string) (managementObject.Properties["Platform"]?.Value ?? default(string)),
		 SharedComputerLicensing = (string) (managementObject.Properties["SharedComputerLicensing"]?.Value ?? default(string)),
		 UpdateChannel = (string) (managementObject.Properties["UpdateChannel"]?.Value ?? default(string)),
		 UpdatePath = (string) (managementObject.Properties["UpdatePath"]?.Value ?? default(string)),
		 UpdatesEnabled = (string) (managementObject.Properties["UpdatesEnabled"]?.Value ?? default(string)),
		 UpdateUrl = (string) (managementObject.Properties["UpdateUrl"]?.Value ?? default(string)),
		 VersionToReport = (string) (managementObject.Properties["VersionToReport"]?.Value ?? default(string))
                };
        }
    }
}