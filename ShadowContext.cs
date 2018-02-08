using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ShadowContext
    {
        public string Caption { get; private set; }
        public bool ClientAccessible { get; private set; }
        public string Description { get; private set; }
        public bool Differential { get; private set; }
        public bool ExposedLocally { get; private set; }
        public bool ExposedRemotely { get; private set; }
        public bool HardwareAssisted { get; private set; }
        public bool Imported { get; private set; }
        public string Name { get; private set; }
        public bool NoAutoRelease { get; private set; }
        public bool NotSurfaced { get; private set; }
        public bool NoWriters { get; private set; }
        public bool Persistent { get; private set; }
        public bool Plex { get; private set; }
        public string SettingID { get; private set; }
        public bool Transportable { get; private set; }

        public static ShadowContext[] Retrieve(string remote, string username, string password)
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

        public static ShadowContext[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ShadowContext[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShadowContext");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ShadowContext>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ShadowContext
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClientAccessible = (bool) managementObject.Properties["ClientAccessible"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Differential = (bool) managementObject.Properties["Differential"].Value,
                    ExposedLocally = (bool) managementObject.Properties["ExposedLocally"].Value,
                    ExposedRemotely = (bool) managementObject.Properties["ExposedRemotely"].Value,
                    HardwareAssisted = (bool) managementObject.Properties["HardwareAssisted"].Value,
                    Imported = (bool) managementObject.Properties["Imported"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NoAutoRelease = (bool) managementObject.Properties["NoAutoRelease"].Value,
                    NotSurfaced = (bool) managementObject.Properties["NotSurfaced"].Value,
                    NoWriters = (bool) managementObject.Properties["NoWriters"].Value,
                    Persistent = (bool) managementObject.Properties["Persistent"].Value,
                    Plex = (bool) managementObject.Properties["Plex"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    Transportable = (bool) managementObject.Properties["Transportable"].Value
                });

            return list.ToArray();
        }
    }
}