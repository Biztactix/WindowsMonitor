using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_HBAInformation
    {
		public bool Active { get; private set; }
		public string AsicVersion { get; private set; }
		public bool BiDiScsiCommands { get; private set; }
		public bool CacheValid { get; private set; }
		public string DriverName { get; private set; }
		public string FirmwareVersion { get; private set; }
		public uint FunctionalitySupported { get; private set; }
		public byte[] GenerationalGuid { get; private set; }
		public string InstanceName { get; private set; }
		public bool IntegratedTCPIP { get; private set; }
		public uint MaxCDBLength { get; private set; }
		public bool MultifunctionDevice { get; private set; }
		public uint NumberOfPorts { get; private set; }
		public string OptionRomVersion { get; private set; }
		public bool RequiresBinaryIpAddresses { get; private set; }
		public string SerialNumber { get; private set; }
		public uint Status { get; private set; }
		public ulong UniqueAdapterId { get; private set; }
		public string VendorID { get; private set; }
		public string VendorModel { get; private set; }
		public string VendorVersion { get; private set; }
		public byte VersionMax { get; private set; }
		public byte VersionMin { get; private set; }

        public static IEnumerable<MSiSCSI_HBAInformation> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_HBAInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_HBAInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_HBAInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_HBAInformation
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AsicVersion = (string) (managementObject.Properties["AsicVersion"]?.Value ?? default(string)),
		 BiDiScsiCommands = (bool) (managementObject.Properties["BiDiScsiCommands"]?.Value ?? default(bool)),
		 CacheValid = (bool) (managementObject.Properties["CacheValid"]?.Value ?? default(bool)),
		 DriverName = (string) (managementObject.Properties["DriverName"]?.Value ?? default(string)),
		 FirmwareVersion = (string) (managementObject.Properties["FirmwareVersion"]?.Value ?? default(string)),
		 FunctionalitySupported = (uint) (managementObject.Properties["FunctionalitySupported"]?.Value ?? default(uint)),
		 GenerationalGuid = (byte[]) (managementObject.Properties["GenerationalGuid"]?.Value ?? new byte[0]),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 IntegratedTCPIP = (bool) (managementObject.Properties["IntegratedTCPIP"]?.Value ?? default(bool)),
		 MaxCDBLength = (uint) (managementObject.Properties["MaxCDBLength"]?.Value ?? default(uint)),
		 MultifunctionDevice = (bool) (managementObject.Properties["MultifunctionDevice"]?.Value ?? default(bool)),
		 NumberOfPorts = (uint) (managementObject.Properties["NumberOfPorts"]?.Value ?? default(uint)),
		 OptionRomVersion = (string) (managementObject.Properties["OptionRomVersion"]?.Value ?? default(string)),
		 RequiresBinaryIpAddresses = (bool) (managementObject.Properties["RequiresBinaryIpAddresses"]?.Value ?? default(bool)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint)),
		 UniqueAdapterId = (ulong) (managementObject.Properties["UniqueAdapterId"]?.Value ?? default(ulong)),
		 VendorID = (string) (managementObject.Properties["VendorID"]?.Value ?? default(string)),
		 VendorModel = (string) (managementObject.Properties["VendorModel"]?.Value ?? default(string)),
		 VendorVersion = (string) (managementObject.Properties["VendorVersion"]?.Value ?? default(string)),
		 VersionMax = (byte) (managementObject.Properties["VersionMax"]?.Value ?? default(byte)),
		 VersionMin = (byte) (managementObject.Properties["VersionMin"]?.Value ?? default(byte))
                };
        }
    }
}