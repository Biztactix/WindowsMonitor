using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FltIoFailure
    {
		public uint CallbackDataPtr { get; private set; }
		public uint FileContext { get; private set; }
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public uint IrpPtr { get; private set; }
		public uint MajorFunction { get; private set; }
		public uint RoutineAddr { get; private set; }
		public uint Status { get; private set; }

        public static IEnumerable<FltIoFailure> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FltIoFailure> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FltIoFailure> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FltIoFailure");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FltIoFailure
                {
                     CallbackDataPtr = (uint) (managementObject.Properties["CallbackDataPtr"]?.Value ?? default(uint)),
		 FileContext = (uint) (managementObject.Properties["FileContext"]?.Value ?? default(uint)),
		 FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IrpPtr = (uint) (managementObject.Properties["IrpPtr"]?.Value ?? default(uint)),
		 MajorFunction = (uint) (managementObject.Properties["MajorFunction"]?.Value ?? default(uint)),
		 RoutineAddr = (uint) (managementObject.Properties["RoutineAddr"]?.Value ?? default(uint)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint))
                };
        }
    }
}