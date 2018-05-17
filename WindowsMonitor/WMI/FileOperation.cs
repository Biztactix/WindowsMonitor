using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FileOperation
    {
		public uint AccessToken { get; private set; }
		public byte CreateOnExisting { get; private set; }
		public string FileName { get; private set; }
		public ulong FileObject { get; private set; }
		public uint Flags { get; private set; }
		public byte IsDirectory { get; private set; }
		public byte IsFastIO { get; private set; }
		public byte IsPagingIO { get; private set; }
		public long LastAccessTime { get; private set; }
		public byte MinorOperation { get; private set; }
		public byte Operation { get; private set; }
		public byte[] OperationalParameters { get; private set; }
		public uint ParametersLength { get; private set; }
		public byte[] PreviousValue { get; private set; }
		public uint PreviousValueLength { get; private set; }
		public long ProcessCreateTime { get; private set; }
		public uint ProcessId { get; private set; }
		public byte[] ResultData { get; private set; }
		public uint ResultLength { get; private set; }
		public uint SequenceNumber { get; private set; }
		public uint SessionId { get; private set; }
		public uint SidLength { get; private set; }
		public long StartTime { get; private set; }
		public uint Status { get; private set; }
		public dynamic UserSID { get; private set; }
		public string VolumeDosName { get; private set; }
		public string VolumeGuidName { get; private set; }
		public string VolumeName { get; private set; }
		public ulong WindowStation { get; private set; }

        public static IEnumerable<FileOperation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FileOperation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FileOperation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FileOperation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FileOperation
                {
                     AccessToken = (uint) (managementObject.Properties["AccessToken"]?.Value ?? default(uint)),
		 CreateOnExisting = (byte) (managementObject.Properties["CreateOnExisting"]?.Value ?? default(byte)),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 FileObject = (ulong) (managementObject.Properties["FileObject"]?.Value ?? default(ulong)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IsDirectory = (byte) (managementObject.Properties["IsDirectory"]?.Value ?? default(byte)),
		 IsFastIO = (byte) (managementObject.Properties["IsFastIO"]?.Value ?? default(byte)),
		 IsPagingIO = (byte) (managementObject.Properties["IsPagingIO"]?.Value ?? default(byte)),
		 LastAccessTime = (long) (managementObject.Properties["LastAccessTime"]?.Value ?? default(long)),
		 MinorOperation = (byte) (managementObject.Properties["MinorOperation"]?.Value ?? default(byte)),
		 Operation = (byte) (managementObject.Properties["Operation"]?.Value ?? default(byte)),
		 OperationalParameters = (byte[]) (managementObject.Properties["OperationalParameters"]?.Value ?? new byte[0]),
		 ParametersLength = (uint) (managementObject.Properties["ParametersLength"]?.Value ?? default(uint)),
		 PreviousValue = (byte[]) (managementObject.Properties["PreviousValue"]?.Value ?? new byte[0]),
		 PreviousValueLength = (uint) (managementObject.Properties["PreviousValueLength"]?.Value ?? default(uint)),
		 ProcessCreateTime = (long) (managementObject.Properties["ProcessCreateTime"]?.Value ?? default(long)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 ResultData = (byte[]) (managementObject.Properties["ResultData"]?.Value ?? new byte[0]),
		 ResultLength = (uint) (managementObject.Properties["ResultLength"]?.Value ?? default(uint)),
		 SequenceNumber = (uint) (managementObject.Properties["SequenceNumber"]?.Value ?? default(uint)),
		 SessionId = (uint) (managementObject.Properties["SessionId"]?.Value ?? default(uint)),
		 SidLength = (uint) (managementObject.Properties["SidLength"]?.Value ?? default(uint)),
		 StartTime = (long) (managementObject.Properties["StartTime"]?.Value ?? default(long)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint)),
		 UserSID = (dynamic) (managementObject.Properties["UserSID"]?.Value ?? default(dynamic)),
		 VolumeDosName = (string) (managementObject.Properties["VolumeDosName"]?.Value ?? default(string)),
		 VolumeGuidName = (string) (managementObject.Properties["VolumeGuidName"]?.Value ?? default(string)),
		 VolumeName = (string) (managementObject.Properties["VolumeName"]?.Value ?? default(string)),
		 WindowStation = (ulong) (managementObject.Properties["WindowStation"]?.Value ?? default(ulong))
                };
        }
    }
}