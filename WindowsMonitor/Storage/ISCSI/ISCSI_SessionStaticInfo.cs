using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_SessionStaticInfo
    {
		public ushort ConnectionCount { get; private set; }
		public dynamic[] ConnectionsList { get; private set; }
		public bool DataPduInOrder { get; private set; }
		public bool DataSequenceInOrder { get; private set; }
		public byte ErrorRecoveryLevel { get; private set; }
		public uint FirstBurstLength { get; private set; }
		public bool ImmediateData { get; private set; }
		public bool InitialR2t { get; private set; }
		public string InitiatoriSCSIName { get; private set; }
		public byte[] ISID { get; private set; }
		public uint MaxBurstLength { get; private set; }
		public uint MaxConnections { get; private set; }
		public uint MaxOutstandingR2t { get; private set; }
		public string TargetiSCSIName { get; private set; }
		public ushort TSID { get; private set; }
		public byte Type { get; private set; }
		public ulong UniqueSessionId { get; private set; }

        public static IEnumerable<ISCSI_SessionStaticInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_SessionStaticInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_SessionStaticInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_SessionStaticInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_SessionStaticInfo
                {
                     ConnectionCount = (ushort) (managementObject.Properties["ConnectionCount"]?.Value ?? default(ushort)),
		 ConnectionsList = (dynamic[]) (managementObject.Properties["ConnectionsList"]?.Value ?? new dynamic[0]),
		 DataPduInOrder = (bool) (managementObject.Properties["DataPduInOrder"]?.Value ?? default(bool)),
		 DataSequenceInOrder = (bool) (managementObject.Properties["DataSequenceInOrder"]?.Value ?? default(bool)),
		 ErrorRecoveryLevel = (byte) (managementObject.Properties["ErrorRecoveryLevel"]?.Value ?? default(byte)),
		 FirstBurstLength = (uint) (managementObject.Properties["FirstBurstLength"]?.Value ?? default(uint)),
		 ImmediateData = (bool) (managementObject.Properties["ImmediateData"]?.Value ?? default(bool)),
		 InitialR2t = (bool) (managementObject.Properties["InitialR2t"]?.Value ?? default(bool)),
		 InitiatoriSCSIName = (string) (managementObject.Properties["InitiatoriSCSIName"]?.Value ?? default(string)),
		 ISID = (byte[]) (managementObject.Properties["ISID"]?.Value ?? new byte[0]),
		 MaxBurstLength = (uint) (managementObject.Properties["MaxBurstLength"]?.Value ?? default(uint)),
		 MaxConnections = (uint) (managementObject.Properties["MaxConnections"]?.Value ?? default(uint)),
		 MaxOutstandingR2t = (uint) (managementObject.Properties["MaxOutstandingR2t"]?.Value ?? default(uint)),
		 TargetiSCSIName = (string) (managementObject.Properties["TargetiSCSIName"]?.Value ?? default(string)),
		 TSID = (ushort) (managementObject.Properties["TSID"]?.Value ?? default(ushort)),
		 Type = (byte) (managementObject.Properties["Type"]?.Value ?? default(byte)),
		 UniqueSessionId = (ulong) (managementObject.Properties["UniqueSessionId"]?.Value ?? default(ulong))
                };
        }
    }
}