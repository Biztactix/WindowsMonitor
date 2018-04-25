using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class NFS
    {
		public bool AttributeCaching { get; private set; }
		public ushort AttributeCachingForDirectoriesMax { get; private set; }
		public ushort AttributeCachingForDirectoriesMin { get; private set; }
		public ushort AttributeCachingForRegularFilesMax { get; private set; }
		public ushort AttributeCachingForRegularFilesMin { get; private set; }
		public ulong AvailableSpace { get; private set; }
		public ulong BlockSize { get; private set; }
		public string Caption { get; private set; }
		public bool CasePreserved { get; private set; }
		public bool CaseSensitive { get; private set; }
		public ushort[] CodeSet { get; private set; }
		public string CompressionMethod { get; private set; }
		public string CreationClassName { get; private set; }
		public string CSCreationClassName { get; private set; }
		public string CSName { get; private set; }
		public string Description { get; private set; }
		public string EncryptionMethod { get; private set; }
		public ulong FileSystemSize { get; private set; }
		public bool ForegroundMount { get; private set; }
		public bool HardMount { get; private set; }
		public DateTime InstallDate { get; private set; }
		public bool Interrupt { get; private set; }
		public uint MaxFileNameLength { get; private set; }
		public ushort MountFailureRetries { get; private set; }
		public string Name { get; private set; }
		public ulong ReadBufferSize { get; private set; }
		public bool ReadOnly { get; private set; }
		public ushort RetransmissionAttempts { get; private set; }
		public uint RetransmissionTimeout { get; private set; }
		public string Root { get; private set; }
		public uint ServerCommunicationPort { get; private set; }
		public string Status { get; private set; }
		public ulong WriteBufferSize { get; private set; }

        public static IEnumerable<NFS> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NFS> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NFS> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_NFS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NFS
                {
                     AttributeCaching = (bool) (managementObject.Properties["AttributeCaching"]?.Value ?? default(bool)),
		 AttributeCachingForDirectoriesMax = (ushort) (managementObject.Properties["AttributeCachingForDirectoriesMax"]?.Value ?? default(ushort)),
		 AttributeCachingForDirectoriesMin = (ushort) (managementObject.Properties["AttributeCachingForDirectoriesMin"]?.Value ?? default(ushort)),
		 AttributeCachingForRegularFilesMax = (ushort) (managementObject.Properties["AttributeCachingForRegularFilesMax"]?.Value ?? default(ushort)),
		 AttributeCachingForRegularFilesMin = (ushort) (managementObject.Properties["AttributeCachingForRegularFilesMin"]?.Value ?? default(ushort)),
		 AvailableSpace = (ulong) (managementObject.Properties["AvailableSpace"]?.Value ?? default(ulong)),
		 BlockSize = (ulong) (managementObject.Properties["BlockSize"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CasePreserved = (bool) (managementObject.Properties["CasePreserved"]?.Value ?? default(bool)),
		 CaseSensitive = (bool) (managementObject.Properties["CaseSensitive"]?.Value ?? default(bool)),
		 CodeSet = (ushort[]) (managementObject.Properties["CodeSet"]?.Value ?? new ushort[0]),
		 CompressionMethod = (string) (managementObject.Properties["CompressionMethod"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 EncryptionMethod = (string) (managementObject.Properties["EncryptionMethod"]?.Value ?? default(string)),
		 FileSystemSize = (ulong) (managementObject.Properties["FileSystemSize"]?.Value ?? default(ulong)),
		 ForegroundMount = (bool) (managementObject.Properties["ForegroundMount"]?.Value ?? default(bool)),
		 HardMount = (bool) (managementObject.Properties["HardMount"]?.Value ?? default(bool)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Interrupt = (bool) (managementObject.Properties["Interrupt"]?.Value ?? default(bool)),
		 MaxFileNameLength = (uint) (managementObject.Properties["MaxFileNameLength"]?.Value ?? default(uint)),
		 MountFailureRetries = (ushort) (managementObject.Properties["MountFailureRetries"]?.Value ?? default(ushort)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ReadBufferSize = (ulong) (managementObject.Properties["ReadBufferSize"]?.Value ?? default(ulong)),
		 ReadOnly = (bool) (managementObject.Properties["ReadOnly"]?.Value ?? default(bool)),
		 RetransmissionAttempts = (ushort) (managementObject.Properties["RetransmissionAttempts"]?.Value ?? default(ushort)),
		 RetransmissionTimeout = (uint) (managementObject.Properties["RetransmissionTimeout"]?.Value ?? default(uint)),
		 Root = (string) (managementObject.Properties["Root"]?.Value ?? default(string)),
		 ServerCommunicationPort = (uint) (managementObject.Properties["ServerCommunicationPort"]?.Value ?? default(uint)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 WriteBufferSize = (ulong) (managementObject.Properties["WriteBufferSize"]?.Value ?? default(ulong))
                };
        }
    }
}