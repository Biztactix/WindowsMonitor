using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software
{
    /// <summary>
    /// </summary>
    public sealed class ProductCheck
    {
		public short Check { get; private set; }
		public short Product { get; private set; }

        public static IEnumerable<ProductCheck> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ProductCheck> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ProductCheck> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProductCheck");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ProductCheck
                {
                     Check = (short) (managementObject.Properties["Check"]?.Value ?? default(short)),
		 Product = (short) (managementObject.Properties["Product"]?.Value ?? default(short))
                };
        }
    }
}