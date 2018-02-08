using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ShadowCopy
    {
        public string Caption { get; private set; }
        public bool ClientAccessible { get; private set; }
        public uint Count { get; private set; }
        public string Description { get; private set; }
        public string DeviceObject { get; private set; }
        public bool Differential { get; private set; }
        public bool ExposedLocally { get; private set; }
        public string ExposedName { get; private set; }
        public string ExposedPath { get; private set; }
        public bool ExposedRemotely { get; private set; }
        public bool HardwareAssisted { get; private set; }
        public string ID { get; private set; }
        public bool Imported { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public bool NoAutoRelease { get; private set; }
        public bool NotSurfaced { get; private set; }
        public bool NoWriters { get; private set; }
        public string OriginatingMachine { get; private set; }
        public bool Persistent { get; private set; }
        public bool Plex { get; private set; }
        public string ProviderID { get; private set; }
        public string ServiceMachine { get; private set; }
        public string SetID { get; private set; }
        public uint State { get; private set; }
        public string Status { get; private set; }
        public bool Transportable { get; private set; }
        public string VolumeName { get; private set; }

        public static ShadowCopy[] Retrieve(string remote, string username, string password)
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

        public static ShadowCopy[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ShadowCopy[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShadowCopy");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ShadowCopy>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ShadowCopy
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClientAccessible = (bool) managementObject.Properties["ClientAccessible"].Value,
                    Count = (uint) managementObject.Properties["Count"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceObject = (string) managementObject.Properties["DeviceObject"].Value,
                    Differential = (bool) managementObject.Properties["Differential"].Value,
                    ExposedLocally = (bool) managementObject.Properties["ExposedLocally"].Value,
                    ExposedName = (string) managementObject.Properties["ExposedName"].Value,
                    ExposedPath = (string) managementObject.Properties["ExposedPath"].Value,
                    ExposedRemotely = (bool) managementObject.Properties["ExposedRemotely"].Value,
                    HardwareAssisted = (bool) managementObject.Properties["HardwareAssisted"].Value,
                    ID = (string) managementObject.Properties["ID"].Value,
                    Imported = (bool) managementObject.Properties["Imported"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NoAutoRelease = (bool) managementObject.Properties["NoAutoRelease"].Value,
                    NotSurfaced = (bool) managementObject.Properties["NotSurfaced"].Value,
                    NoWriters = (bool) managementObject.Properties["NoWriters"].Value,
                    OriginatingMachine = (string) managementObject.Properties["OriginatingMachine"].Value,
                    Persistent = (bool) managementObject.Properties["Persistent"].Value,
                    Plex = (bool) managementObject.Properties["Plex"].Value,
                    ProviderID = (string) managementObject.Properties["ProviderID"].Value,
                    ServiceMachine = (string) managementObject.Properties["ServiceMachine"].Value,
                    SetID = (string) managementObject.Properties["SetID"].Value,
                    State = (uint) managementObject.Properties["State"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    Transportable = (bool) managementObject.Properties["Transportable"].Value,
                    VolumeName = (string) managementObject.Properties["VolumeName"].Value
                });

            return list.ToArray();
        }
    }
}