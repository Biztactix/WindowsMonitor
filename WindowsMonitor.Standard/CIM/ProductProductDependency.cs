using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class ProductProductDependency
    {
		public short DependentProduct { get; private set; }
		public short RequiredProduct { get; private set; }
		public ushort TypeOfDependency { get; private set; }

        public static IEnumerable<ProductProductDependency> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ProductProductDependency> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ProductProductDependency> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ProductProductDependency");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ProductProductDependency
                {
                     DependentProduct = (short) (managementObject.Properties["DependentProduct"]?.Value ?? default(short)),
		 RequiredProduct = (short) (managementObject.Properties["RequiredProduct"]?.Value ?? default(short)),
		 TypeOfDependency = (ushort) (managementObject.Properties["TypeOfDependency"]?.Value ?? default(ushort))
                };
        }
    }
}