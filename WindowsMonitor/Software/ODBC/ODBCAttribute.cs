using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software.ODBC
{
    /// <summary>
    /// </summary>
    public sealed class ODBCAttribute
    {
		public string Attribute { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string Driver { get; private set; }
		public string SettingID { get; private set; }
		public string Value { get; private set; }

        public static IEnumerable<ODBCAttribute> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ODBCAttribute> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ODBCAttribute> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ODBCAttribute");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ODBCAttribute
                {
                     Attribute = (string) (managementObject.Properties["Attribute"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Driver = (string) (managementObject.Properties["Driver"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value),
		 Value = (string) (managementObject.Properties["Value"]?.Value)
                };
        }
    }
}