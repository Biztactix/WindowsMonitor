using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class RoamingProfileUserConfiguration
    {
        public string[] DirectoriesToSyncAtLogonLogoff { get; private set; }
        public string[] ExcludedProfileDirs { get; private set; }
        public bool IsConfiguredByWMI { get; private set; }

        public static RoamingProfileUserConfiguration[] Retrieve(string remote, string username, string password)
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

        public static RoamingProfileUserConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static RoamingProfileUserConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RoamingProfileUserConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<RoamingProfileUserConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new RoamingProfileUserConfiguration
                {
                    DirectoriesToSyncAtLogonLogoff =
                        (string[]) managementObject.Properties["DirectoriesToSyncAtLogonLogoff"].Value,
                    ExcludedProfileDirs = (string[]) managementObject.Properties["ExcludedProfileDirs"].Value,
                    IsConfiguredByWMI = (bool) managementObject.Properties["IsConfiguredByWMI"].Value
                });

            return list.ToArray();
        }
    }
}