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
	public sealed class NTLogEvent
	{
		public UInt16 Category { get; private set; }
public String CategoryString { get; private set; }
public String ComputerName { get; private set; }
public Byte[] Data { get; private set; }
public UInt16 EventCode { get; private set; }
public UInt32 EventIdentifier { get; private set; }
public Byte EventType { get; private set; }
public String[] InsertionStrings { get; private set; }
public String Logfile { get; private set; }
public String Message { get; private set; }
public UInt32 RecordNumber { get; private set; }
public String SourceName { get; private set; }
public DateTime TimeGenerated { get; private set; }
public DateTime TimeWritten { get; private set; }
public String Type { get; private set; }
public String User { get; private set; }
		
		public static NTLogEvent[] Retrieve(string remote, string username, string password)
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

		public static NTLogEvent[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NTLogEvent[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NTLogEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NTLogEvent>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NTLogEvent
				{
					Category = (UInt16) managementObject.Properties["Category"].Value,
CategoryString = (String) managementObject.Properties["CategoryString"].Value,
ComputerName = (String) managementObject.Properties["ComputerName"].Value,
Data = (Byte[]) managementObject.Properties["Data"].Value,
EventCode = (UInt16) managementObject.Properties["EventCode"].Value,
EventIdentifier = (UInt32) managementObject.Properties["EventIdentifier"].Value,
EventType = (Byte) managementObject.Properties["EventType"].Value,
InsertionStrings = (String[]) managementObject.Properties["InsertionStrings"].Value,
Logfile = (String) managementObject.Properties["Logfile"].Value,
Message = (String) managementObject.Properties["Message"].Value,
RecordNumber = (UInt32) managementObject.Properties["RecordNumber"].Value,
SourceName = (String) managementObject.Properties["SourceName"].Value,
TimeGenerated = (DateTime) managementObject.Properties["TimeGenerated"].Value,
TimeWritten = (DateTime) managementObject.Properties["TimeWritten"].Value,
Type = (String) managementObject.Properties["Type"].Value,
User = (String) managementObject.Properties["User"].Value,
				});
            }

			return list.ToArray();
		}
	}
}