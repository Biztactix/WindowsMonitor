using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PhyDisk
    {
		public char[] BootDriveLetter { get; private set; }
		public uint BytesPerSector { get; private set; }
		public ulong Cylinders { get; private set; }
		public uint DiskNumber { get; private set; }
		public uint Flags { get; private set; }
		public char[] Manufacturer { get; private set; }
		public byte Pad { get; private set; }
		public uint PartitionCount { get; private set; }
		public uint SCSILun { get; private set; }
		public uint SCSIPath { get; private set; }
		public uint SCSIPort { get; private set; }
		public uint SCSITarget { get; private set; }
		public uint SectorsPerTrack { get; private set; }
		public char[] Spare { get; private set; }
		public uint TracksPerCylinder { get; private set; }
		public byte WriteCacheEnabled { get; private set; }

        public static IEnumerable<PhyDisk> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PhyDisk> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PhyDisk> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V2_PhyDisk");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PhyDisk
                {
                     BootDriveLetter = (char[]) (managementObject.Properties["BootDriveLetter"]?.Value ?? new char[0]),
		 BytesPerSector = (uint) (managementObject.Properties["BytesPerSector"]?.Value ?? default(uint)),
		 Cylinders = (ulong) (managementObject.Properties["Cylinders"]?.Value ?? default(ulong)),
		 DiskNumber = (uint) (managementObject.Properties["DiskNumber"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Manufacturer = (char[]) (managementObject.Properties["Manufacturer"]?.Value ?? new char[0]),
		 Pad = (byte) (managementObject.Properties["Pad"]?.Value ?? default(byte)),
		 PartitionCount = (uint) (managementObject.Properties["PartitionCount"]?.Value ?? default(uint)),
		 SCSILun = (uint) (managementObject.Properties["SCSILun"]?.Value ?? default(uint)),
		 SCSIPath = (uint) (managementObject.Properties["SCSIPath"]?.Value ?? default(uint)),
		 SCSIPort = (uint) (managementObject.Properties["SCSIPort"]?.Value ?? default(uint)),
		 SCSITarget = (uint) (managementObject.Properties["SCSITarget"]?.Value ?? default(uint)),
		 SectorsPerTrack = (uint) (managementObject.Properties["SectorsPerTrack"]?.Value ?? default(uint)),
		 Spare = (char[]) (managementObject.Properties["Spare"]?.Value ?? new char[0]),
		 TracksPerCylinder = (uint) (managementObject.Properties["TracksPerCylinder"]?.Value ?? default(uint)),
		 WriteCacheEnabled = (byte) (managementObject.Properties["WriteCacheEnabled"]?.Value ?? default(byte))
                };
        }
    }
}