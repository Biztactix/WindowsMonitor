using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class WmiProvider_Counters
    {
		public ulong ProviderOperation_AccessCheck { get; private set; }
		public ulong ProviderOperation_CancelQuery { get; private set; }
		public ulong ProviderOperation_CreateClassEnumAsync { get; private set; }
		public ulong ProviderOperation_CreateInstanceEnumAsync { get; private set; }
		public ulong ProviderOperation_CreateRefreshableEnum { get; private set; }
		public ulong ProviderOperation_CreateRefreshableObject { get; private set; }
		public ulong ProviderOperation_CreateRefresher { get; private set; }
		public ulong ProviderOperation_DeleteClassAsync { get; private set; }
		public ulong ProviderOperation_DeleteInstanceAsync { get; private set; }
		public ulong ProviderOperation_ExecMethodAsync { get; private set; }
		public ulong ProviderOperation_ExecQueryAsync { get; private set; }
		public ulong ProviderOperation_FindConsumer { get; private set; }
		public ulong ProviderOperation_GetObjectAsync { get; private set; }
		public ulong ProviderOperation_GetObjects { get; private set; }
		public ulong ProviderOperation_GetProperty { get; private set; }
		public ulong ProviderOperation_NewQuery { get; private set; }
		public ulong ProviderOperation_ProvideEvents { get; private set; }
		public ulong ProviderOperation_PutClassAsync { get; private set; }
		public ulong ProviderOperation_PutInstanceAsync { get; private set; }
		public ulong ProviderOperation_PutProperty { get; private set; }
		public ulong ProviderOperation_QueryInstances { get; private set; }
		public ulong ProviderOperation_SetRegistrationObject { get; private set; }
		public ulong ProviderOperation_StopRefreshing { get; private set; }
		public ulong ProviderOperation_ValidateSubscription { get; private set; }

        public static IEnumerable<WmiProvider_Counters> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiProvider_Counters> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiProvider_Counters> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_Counters");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiProvider_Counters
                {
                     ProviderOperation_AccessCheck = (ulong) (managementObject.Properties["ProviderOperation_AccessCheck"]?.Value ?? default(ulong)),
		 ProviderOperation_CancelQuery = (ulong) (managementObject.Properties["ProviderOperation_CancelQuery"]?.Value ?? default(ulong)),
		 ProviderOperation_CreateClassEnumAsync = (ulong) (managementObject.Properties["ProviderOperation_CreateClassEnumAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_CreateInstanceEnumAsync = (ulong) (managementObject.Properties["ProviderOperation_CreateInstanceEnumAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_CreateRefreshableEnum = (ulong) (managementObject.Properties["ProviderOperation_CreateRefreshableEnum"]?.Value ?? default(ulong)),
		 ProviderOperation_CreateRefreshableObject = (ulong) (managementObject.Properties["ProviderOperation_CreateRefreshableObject"]?.Value ?? default(ulong)),
		 ProviderOperation_CreateRefresher = (ulong) (managementObject.Properties["ProviderOperation_CreateRefresher"]?.Value ?? default(ulong)),
		 ProviderOperation_DeleteClassAsync = (ulong) (managementObject.Properties["ProviderOperation_DeleteClassAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_DeleteInstanceAsync = (ulong) (managementObject.Properties["ProviderOperation_DeleteInstanceAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_ExecMethodAsync = (ulong) (managementObject.Properties["ProviderOperation_ExecMethodAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_ExecQueryAsync = (ulong) (managementObject.Properties["ProviderOperation_ExecQueryAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_FindConsumer = (ulong) (managementObject.Properties["ProviderOperation_FindConsumer"]?.Value ?? default(ulong)),
		 ProviderOperation_GetObjectAsync = (ulong) (managementObject.Properties["ProviderOperation_GetObjectAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_GetObjects = (ulong) (managementObject.Properties["ProviderOperation_GetObjects"]?.Value ?? default(ulong)),
		 ProviderOperation_GetProperty = (ulong) (managementObject.Properties["ProviderOperation_GetProperty"]?.Value ?? default(ulong)),
		 ProviderOperation_NewQuery = (ulong) (managementObject.Properties["ProviderOperation_NewQuery"]?.Value ?? default(ulong)),
		 ProviderOperation_ProvideEvents = (ulong) (managementObject.Properties["ProviderOperation_ProvideEvents"]?.Value ?? default(ulong)),
		 ProviderOperation_PutClassAsync = (ulong) (managementObject.Properties["ProviderOperation_PutClassAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_PutInstanceAsync = (ulong) (managementObject.Properties["ProviderOperation_PutInstanceAsync"]?.Value ?? default(ulong)),
		 ProviderOperation_PutProperty = (ulong) (managementObject.Properties["ProviderOperation_PutProperty"]?.Value ?? default(ulong)),
		 ProviderOperation_QueryInstances = (ulong) (managementObject.Properties["ProviderOperation_QueryInstances"]?.Value ?? default(ulong)),
		 ProviderOperation_SetRegistrationObject = (ulong) (managementObject.Properties["ProviderOperation_SetRegistrationObject"]?.Value ?? default(ulong)),
		 ProviderOperation_StopRefreshing = (ulong) (managementObject.Properties["ProviderOperation_StopRefreshing"]?.Value ?? default(ulong)),
		 ProviderOperation_ValidateSubscription = (ulong) (managementObject.Properties["ProviderOperation_ValidateSubscription"]?.Value ?? default(ulong))
                };
        }
    }
}