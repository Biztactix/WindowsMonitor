using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ScsiRequestBlock
    {
		public byte[] cdb { get; private set; }
		public byte cdbLength { get; private set; }
		public ulong dataBuffer { get; private set; }
		public uint dataTransferLength { get; private set; }
		public byte function { get; private set; }
		public uint internalStatus { get; private set; }
		public ushort length { get; private set; }
		public byte lun { get; private set; }
		public ulong nextSRB { get; private set; }
		public ulong originalRequest { get; private set; }
		public byte pathID { get; private set; }
		public byte queueAction { get; private set; }
		public byte queueTag { get; private set; }
		public uint reserved { get; private set; }
		public byte scsiStatus { get; private set; }
		public ulong senseInfoBuffer { get; private set; }
		public byte senseInfoBufferLength { get; private set; }
		public ulong srbExtension { get; private set; }
		public uint srbFlags { get; private set; }
		public byte srbStatus { get; private set; }
		public byte targetID { get; private set; }
		public uint timeOutValue { get; private set; }

        public static IEnumerable<ScsiRequestBlock> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ScsiRequestBlock> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ScsiRequestBlock> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSStorageDriver_ScsiRequestBlock");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ScsiRequestBlock
                {
                     cdb = (byte[]) (managementObject.Properties["cdb"]?.Value ?? new byte[0]),
		 cdbLength = (byte) (managementObject.Properties["cdbLength"]?.Value ?? default(byte)),
		 dataBuffer = (ulong) (managementObject.Properties["dataBuffer"]?.Value ?? default(ulong)),
		 dataTransferLength = (uint) (managementObject.Properties["dataTransferLength"]?.Value ?? default(uint)),
		 function = (byte) (managementObject.Properties["function"]?.Value ?? default(byte)),
		 internalStatus = (uint) (managementObject.Properties["internalStatus"]?.Value ?? default(uint)),
		 length = (ushort) (managementObject.Properties["length"]?.Value ?? default(ushort)),
		 lun = (byte) (managementObject.Properties["lun"]?.Value ?? default(byte)),
		 nextSRB = (ulong) (managementObject.Properties["nextSRB"]?.Value ?? default(ulong)),
		 originalRequest = (ulong) (managementObject.Properties["originalRequest"]?.Value ?? default(ulong)),
		 pathID = (byte) (managementObject.Properties["pathID"]?.Value ?? default(byte)),
		 queueAction = (byte) (managementObject.Properties["queueAction"]?.Value ?? default(byte)),
		 queueTag = (byte) (managementObject.Properties["queueTag"]?.Value ?? default(byte)),
		 reserved = (uint) (managementObject.Properties["reserved"]?.Value ?? default(uint)),
		 scsiStatus = (byte) (managementObject.Properties["scsiStatus"]?.Value ?? default(byte)),
		 senseInfoBuffer = (ulong) (managementObject.Properties["senseInfoBuffer"]?.Value ?? default(ulong)),
		 senseInfoBufferLength = (byte) (managementObject.Properties["senseInfoBufferLength"]?.Value ?? default(byte)),
		 srbExtension = (ulong) (managementObject.Properties["srbExtension"]?.Value ?? default(ulong)),
		 srbFlags = (uint) (managementObject.Properties["srbFlags"]?.Value ?? default(uint)),
		 srbStatus = (byte) (managementObject.Properties["srbStatus"]?.Value ?? default(byte)),
		 targetID = (byte) (managementObject.Properties["targetID"]?.Value ?? default(byte)),
		 timeOutValue = (uint) (managementObject.Properties["timeOutValue"]?.Value ?? default(uint))
                };
        }
    }
}