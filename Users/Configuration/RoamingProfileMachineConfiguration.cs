using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class RoamingProfileMachineConfiguration
    {
        public bool AddAdminGroupToRUPEnabled { get; private set; }
        public bool AllowCrossForestUserPolicy { get; private set; }
        public object BackgroundUploadParams { get; private set; }
        public ushort DeleteProfilesOlderDays { get; private set; }
        public bool DeleteRoamingCacheEnabled { get; private set; }
        public bool DetectSlowLinkDisabled { get; private set; }
        public bool ForceUnloadDisabled { get; private set; }
        public bool IsConfiguredByWMI { get; private set; }
        public string MachineProfilePath { get; private set; }
        public bool OnlyAllowLocalProfiles { get; private set; }
        public bool OwnerCheckDisabled { get; private set; }
        public bool PrimaryComputerEnabled { get; private set; }
        public bool ProfileUploadDisabled { get; private set; }
        public object SlowLinkTimeOutParams { get; private set; }
        public bool SlowLinkUIEnabled { get; private set; }
        public bool TempProfileLogonBlocked { get; private set; }
        public ushort WaitForNetworkInSec { get; private set; }
        public bool WaitForRemoteProfile { get; private set; }

        public static RoamingProfileMachineConfiguration[] Retrieve(string remote, string username, string password)
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

        public static RoamingProfileMachineConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static RoamingProfileMachineConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RoamingProfileMachineConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<RoamingProfileMachineConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new RoamingProfileMachineConfiguration
                {
                    AddAdminGroupToRUPEnabled = (bool) managementObject.Properties["AddAdminGroupToRUPEnabled"].Value,
                    AllowCrossForestUserPolicy = (bool) managementObject.Properties["AllowCrossForestUserPolicy"].Value,
                    BackgroundUploadParams = managementObject.Properties["BackgroundUploadParams"].Value,
                    DeleteProfilesOlderDays = (ushort) managementObject.Properties["DeleteProfilesOlderDays"].Value,
                    DeleteRoamingCacheEnabled = (bool) managementObject.Properties["DeleteRoamingCacheEnabled"].Value,
                    DetectSlowLinkDisabled = (bool) managementObject.Properties["DetectSlowLinkDisabled"].Value,
                    ForceUnloadDisabled = (bool) managementObject.Properties["ForceUnloadDisabled"].Value,
                    IsConfiguredByWMI = (bool) managementObject.Properties["IsConfiguredByWMI"].Value,
                    MachineProfilePath = (string) managementObject.Properties["MachineProfilePath"].Value,
                    OnlyAllowLocalProfiles = (bool) managementObject.Properties["OnlyAllowLocalProfiles"].Value,
                    OwnerCheckDisabled = (bool) managementObject.Properties["OwnerCheckDisabled"].Value,
                    PrimaryComputerEnabled = (bool) managementObject.Properties["PrimaryComputerEnabled"].Value,
                    ProfileUploadDisabled = (bool) managementObject.Properties["ProfileUploadDisabled"].Value,
                    SlowLinkTimeOutParams = managementObject.Properties["SlowLinkTimeOutParams"].Value,
                    SlowLinkUIEnabled = (bool) managementObject.Properties["SlowLinkUIEnabled"].Value,
                    TempProfileLogonBlocked = (bool) managementObject.Properties["TempProfileLogonBlocked"].Value,
                    WaitForNetworkInSec = (ushort) managementObject.Properties["WaitForNetworkInSec"].Value,
                    WaitForRemoteProfile = (bool) managementObject.Properties["WaitForRemoteProfile"].Value
                });

            return list.ToArray();
        }
    }
}