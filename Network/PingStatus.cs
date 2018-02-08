using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
        /// <summary>
        /// 
        /// </summary>
	public sealed class PingStatus
	{
		public String Address { get; private set; }
public UInt32 BufferSize { get; private set; }
public Boolean NoFragmentation { get; private set; }
public UInt32 PrimaryAddressResolutionStatus { get; private set; }
public String ProtocolAddress { get; private set; }
public String ProtocolAddressResolved { get; private set; }
public UInt32 RecordRoute { get; private set; }
public Boolean ReplyInconsistency { get; private set; }
public UInt32 ReplySize { get; private set; }
public Boolean ResolveAddressNames { get; private set; }
public UInt32 ResponseTime { get; private set; }
public UInt32 ResponseTimeToLive { get; private set; }
public String[] RouteRecord { get; private set; }
public String[] RouteRecordResolved { get; private set; }
public String SourceRoute { get; private set; }
public UInt32 SourceRouteType { get; private set; }
public UInt32 StatusCode { get; private set; }
public UInt32 Timeout { get; private set; }
public UInt32[] TimeStampRecord { get; private set; }
public String[] TimeStampRecordAddress { get; private set; }
public String[] TimeStampRecordAddressResolved { get; private set; }
public UInt32 TimestampRoute { get; private set; }
public UInt32 TimeToLive { get; private set; }
public UInt32 TypeofService { get; private set; }
		
		public static PingStatus[] Retrieve(string remote, string username, string password)
		{
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"),options);
            managementScope.Connect();

			return Retrieve(managementScope);
		}

		public static PingStatus[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PingStatus[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PingStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PingStatus>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PingStatus
				{
					Address = (String) managementObject.Properties["Address"].Value,
BufferSize = (UInt32) managementObject.Properties["BufferSize"].Value,
NoFragmentation = (Boolean) managementObject.Properties["NoFragmentation"].Value,
PrimaryAddressResolutionStatus = (UInt32) managementObject.Properties["PrimaryAddressResolutionStatus"].Value,
ProtocolAddress = (String) managementObject.Properties["ProtocolAddress"].Value,
ProtocolAddressResolved = (String) managementObject.Properties["ProtocolAddressResolved"].Value,
RecordRoute = (UInt32) managementObject.Properties["RecordRoute"].Value,
ReplyInconsistency = (Boolean) managementObject.Properties["ReplyInconsistency"].Value,
ReplySize = (UInt32) managementObject.Properties["ReplySize"].Value,
ResolveAddressNames = (Boolean) managementObject.Properties["ResolveAddressNames"].Value,
ResponseTime = (UInt32) managementObject.Properties["ResponseTime"].Value,
ResponseTimeToLive = (UInt32) managementObject.Properties["ResponseTimeToLive"].Value,
RouteRecord = (String[]) managementObject.Properties["RouteRecord"].Value,
RouteRecordResolved = (String[]) managementObject.Properties["RouteRecordResolved"].Value,
SourceRoute = (String) managementObject.Properties["SourceRoute"].Value,
SourceRouteType = (UInt32) managementObject.Properties["SourceRouteType"].Value,
StatusCode = (UInt32) managementObject.Properties["StatusCode"].Value,
Timeout = (UInt32) managementObject.Properties["Timeout"].Value,
TimeStampRecord = (UInt32[]) managementObject.Properties["TimeStampRecord"].Value,
TimeStampRecordAddress = (String[]) managementObject.Properties["TimeStampRecordAddress"].Value,
TimeStampRecordAddressResolved = (String[]) managementObject.Properties["TimeStampRecordAddressResolved"].Value,
TimestampRoute = (UInt32) managementObject.Properties["TimestampRoute"].Value,
TimeToLive = (UInt32) managementObject.Properties["TimeToLive"].Value,
TypeofService = (UInt32) managementObject.Properties["TypeofService"].Value,
				});
            }

			return list.ToArray();
		}
	}
}