using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Software.ODBC
{
    /// <summary>
    /// </summary>
    public sealed class ODBCSourceAttribute
    {
		public string Attribute { get; private set; }
		public string Caption { get; private set; }
		public string DataSource { get; private set; }
		public string Description { get; private set; }
		public string SettingID { get; private set; }
		public string Value { get; private set; }

        public static IEnumerable<ODBCSourceAttribute> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ODBCSourceAttribute> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ODBCSourceAttribute> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ODBCSourceAttribute");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ODBCSourceAttribute
                {
                     Attribute = (string) (managementObject.Properties["Attribute"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 DataSource = (string) (managementObject.Properties["DataSource"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value),
		 Value = (string) (managementObject.Properties["Value"]?.Value)
                };
        }
    }
}