using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class Providers
    {
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public uint HostProcessIdentifier { get; private set; }
		public string Locale { get; private set; }
		public string Namespace { get; private set; }
		public string Provider { get; private set; }
		public ulong ProviderOperationAccessCheck { get; private set; }
		public ulong ProviderOperationCancelQuery { get; private set; }
		public ulong ProviderOperationCreateClassEnumAsync { get; private set; }
		public ulong ProviderOperationCreateInstanceEnumAsync { get; private set; }
		public ulong ProviderOperationCreateRefreshableEnum { get; private set; }
		public ulong ProviderOperationCreateRefreshableObject { get; private set; }
		public ulong ProviderOperationCreateRefresher { get; private set; }
		public ulong ProviderOperationDeleteClassAsync { get; private set; }
		public ulong ProviderOperationDeleteInstanceAsync { get; private set; }
		public ulong ProviderOperationExecMethodAsync { get; private set; }
		public ulong ProviderOperationExecQueryAsync { get; private set; }
		public ulong ProviderOperationFindConsumer { get; private set; }
		public ulong ProviderOperationGetObjectAsync { get; private set; }
		public ulong ProviderOperationGetObjects { get; private set; }
		public ulong ProviderOperationGetProperty { get; private set; }
		public ulong ProviderOperationNewQuery { get; private set; }
		public ulong ProviderOperationProvideEvents { get; private set; }
		public ulong ProviderOperationPutClassAsync { get; private set; }
		public ulong ProviderOperationPutInstanceAsync { get; private set; }
		public ulong ProviderOperationPutProperty { get; private set; }
		public ulong ProviderOperationQueryInstances { get; private set; }
		public ulong ProviderOperationSetRegistrationObject { get; private set; }
		public ulong ProviderOperationStopRefreshing { get; private set; }
		public ulong ProviderOperationValidateSubscription { get; private set; }
		public string TransactionIdentifier { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<Providers> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Providers> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Providers> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_Providers");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Providers
                {
                     HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 HostProcessIdentifier = (uint) (managementObject.Properties["HostProcessIdentifier"]?.Value ?? default(uint)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value),
		 Provider = (string) (managementObject.Properties["provider"]?.Value),
		 ProviderOperationAccessCheck = (ulong) (managementObject.Properties["ProviderOperation_AccessCheck"]?.Value ?? default(ulong)),
		 ProviderOperationCancelQuery = (ulong) (managementObject.Properties["ProviderOperation_CancelQuery"]?.Value ?? default(ulong)),
		 ProviderOperationCreateClassEnumAsync = (ulong) (managementObject.Properties["ProviderOperation_CreateClassEnumAsync"]?.Value ?? default(ulong)),
		 ProviderOperationCreateInstanceEnumAsync = (ulong) (managementObject.Properties["ProviderOperation_CreateInstanceEnumAsync"]?.Value ?? default(ulong)),
		 ProviderOperationCreateRefreshableEnum = (ulong) (managementObject.Properties["ProviderOperation_CreateRefreshableEnum"]?.Value ?? default(ulong)),
		 ProviderOperationCreateRefreshableObject = (ulong) (managementObject.Properties["ProviderOperation_CreateRefreshableObject"]?.Value ?? default(ulong)),
		 ProviderOperationCreateRefresher = (ulong) (managementObject.Properties["ProviderOperation_CreateRefresher"]?.Value ?? default(ulong)),
		 ProviderOperationDeleteClassAsync = (ulong) (managementObject.Properties["ProviderOperation_DeleteClassAsync"]?.Value ?? default(ulong)),
		 ProviderOperationDeleteInstanceAsync = (ulong) (managementObject.Properties["ProviderOperation_DeleteInstanceAsync"]?.Value ?? default(ulong)),
		 ProviderOperationExecMethodAsync = (ulong) (managementObject.Properties["ProviderOperation_ExecMethodAsync"]?.Value ?? default(ulong)),
		 ProviderOperationExecQueryAsync = (ulong) (managementObject.Properties["ProviderOperation_ExecQueryAsync"]?.Value ?? default(ulong)),
		 ProviderOperationFindConsumer = (ulong) (managementObject.Properties["ProviderOperation_FindConsumer"]?.Value ?? default(ulong)),
		 ProviderOperationGetObjectAsync = (ulong) (managementObject.Properties["ProviderOperation_GetObjectAsync"]?.Value ?? default(ulong)),
		 ProviderOperationGetObjects = (ulong) (managementObject.Properties["ProviderOperation_GetObjects"]?.Value ?? default(ulong)),
		 ProviderOperationGetProperty = (ulong) (managementObject.Properties["ProviderOperation_GetProperty"]?.Value ?? default(ulong)),
		 ProviderOperationNewQuery = (ulong) (managementObject.Properties["ProviderOperation_NewQuery"]?.Value ?? default(ulong)),
		 ProviderOperationProvideEvents = (ulong) (managementObject.Properties["ProviderOperation_ProvideEvents"]?.Value ?? default(ulong)),
		 ProviderOperationPutClassAsync = (ulong) (managementObject.Properties["ProviderOperation_PutClassAsync"]?.Value ?? default(ulong)),
		 ProviderOperationPutInstanceAsync = (ulong) (managementObject.Properties["ProviderOperation_PutInstanceAsync"]?.Value ?? default(ulong)),
		 ProviderOperationPutProperty = (ulong) (managementObject.Properties["ProviderOperation_PutProperty"]?.Value ?? default(ulong)),
		 ProviderOperationQueryInstances = (ulong) (managementObject.Properties["ProviderOperation_QueryInstances"]?.Value ?? default(ulong)),
		 ProviderOperationSetRegistrationObject = (ulong) (managementObject.Properties["ProviderOperation_SetRegistrationObject"]?.Value ?? default(ulong)),
		 ProviderOperationStopRefreshing = (ulong) (managementObject.Properties["ProviderOperation_StopRefreshing"]?.Value ?? default(ulong)),
		 ProviderOperationValidateSubscription = (ulong) (managementObject.Properties["ProviderOperation_ValidateSubscription"]?.Value ?? default(ulong)),
		 TransactionIdentifier = (string) (managementObject.Properties["TransactionIdentifier"]?.Value),
		 User = (string) (managementObject.Properties["User"]?.Value)
                };
        }
    }
}