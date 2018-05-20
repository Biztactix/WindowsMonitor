using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage
{
    /// <summary>
    /// </summary>
    public sealed class FolderRedirectionUserConfiguration
    {
		public dynamic AppDataRoaming { get; private set; }
		public dynamic Contacts { get; private set; }
		public dynamic Desktop { get; private set; }
		public dynamic Documents { get; private set; }
		public dynamic Downloads { get; private set; }
		public dynamic Favorites { get; private set; }
		public bool IsConfiguredByWMI { get; private set; }
		public dynamic Links { get; private set; }
		public dynamic Music { get; private set; }
		public dynamic Pictures { get; private set; }
		public bool PrimaryComputerEnabled { get; private set; }
		public dynamic SavedGames { get; private set; }
		public dynamic Searches { get; private set; }
		public dynamic StartMenu { get; private set; }
		public dynamic Videos { get; private set; }

        public static IEnumerable<FolderRedirectionUserConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FolderRedirectionUserConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FolderRedirectionUserConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_FolderRedirectionUserConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FolderRedirectionUserConfiguration
                {
                     AppDataRoaming = (dynamic) (managementObject.Properties["AppDataRoaming"]?.Value ?? default(dynamic)),
		 Contacts = (dynamic) (managementObject.Properties["Contacts"]?.Value ?? default(dynamic)),
		 Desktop = (dynamic) (managementObject.Properties["Desktop"]?.Value ?? default(dynamic)),
		 Documents = (dynamic) (managementObject.Properties["Documents"]?.Value ?? default(dynamic)),
		 Downloads = (dynamic) (managementObject.Properties["Downloads"]?.Value ?? default(dynamic)),
		 Favorites = (dynamic) (managementObject.Properties["Favorites"]?.Value ?? default(dynamic)),
		 IsConfiguredByWMI = (bool) (managementObject.Properties["IsConfiguredByWMI"]?.Value ?? default(bool)),
		 Links = (dynamic) (managementObject.Properties["Links"]?.Value ?? default(dynamic)),
		 Music = (dynamic) (managementObject.Properties["Music"]?.Value ?? default(dynamic)),
		 Pictures = (dynamic) (managementObject.Properties["Pictures"]?.Value ?? default(dynamic)),
		 PrimaryComputerEnabled = (bool) (managementObject.Properties["PrimaryComputerEnabled"]?.Value ?? default(bool)),
		 SavedGames = (dynamic) (managementObject.Properties["SavedGames"]?.Value ?? default(dynamic)),
		 Searches = (dynamic) (managementObject.Properties["Searches"]?.Value ?? default(dynamic)),
		 StartMenu = (dynamic) (managementObject.Properties["StartMenu"]?.Value ?? default(dynamic)),
		 Videos = (dynamic) (managementObject.Properties["Videos"]?.Value ?? default(dynamic))
                };
        }
    }
}