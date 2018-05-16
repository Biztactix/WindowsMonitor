using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software
{
    /// <summary>
    /// </summary>
    public sealed class ProductResource
    {
		public short Product { get; private set; }
		public short Resource { get; private set; }

        public static IEnumerable<ProductResource> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ProductResource> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ProductResource> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProductResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ProductResource
                {
                     Product = (short) (managementObject.Properties["Product"]?.Value ?? default(short)),
		 Resource = (short) (managementObject.Properties["Resource"]?.Value ?? default(short))
                };
        }
    }
}