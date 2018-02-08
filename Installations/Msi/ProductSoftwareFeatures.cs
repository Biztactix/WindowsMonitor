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
	public sealed class ProductSoftwareFeatures
	{
		public String Component { get; private set; }
public String Product { get; private set; }
		
		public static ProductSoftwareFeatures[] Retrieve(string remote, string username, string password)
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

		public static ProductSoftwareFeatures[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ProductSoftwareFeatures[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProductSoftwareFeatures");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ProductSoftwareFeatures>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ProductSoftwareFeatures
				{
					Component = (String) managementObject.Properties["Component"].Value,
Product = (String) managementObject.Properties["Product"].Value,
				});
            }

			return list.ToArray();
		}
	}
}