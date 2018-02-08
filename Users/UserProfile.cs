using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class UserProfile
    {
        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected AppData\Roaming folder.
        /// </summary>
        public object AppDataRoaming { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Contacts folder.
        /// </summary>
        public object Contacts { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Desktop folder.
        /// </summary>
        public object Desktop { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Documents folder.
        /// </summary>
        public object Documents { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Downloads folder.
        /// </summary>
        public object Downloads { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Favorites folder.
        /// </summary>
        public object Favorites { get; private set; }

        /// <summary>
        ///     The health status of this profile, based on the values that were set in the Win32_RoamingUserHealthConfiguration
        ///     properties.
        /// </summary>
        public byte HealthStatus { get; private set; }

        /// <summary>
        ///     If the profile is a roaming profile, this property is a DATETIME value that indicates the last time an attempt was
        ///     made to download the profile from the server, even if it was unsuccessful. If the profile is a local profile, this
        ///     property is zero.
        /// </summary>
        public DateTime LastAttemptedProfileDownloadTime { get; private set; }

        /// <summary>
        ///     If the profile is a roaming profile, this property is a DATETIME value that indicates the last time an attempt was
        ///     made to upload the profile to the server, even if it was unsuccessful.
        /// </summary>
        public DateTime LastAttemptedProfileUploadTime { get; private set; }

        /// <summary>
        ///     If this profile is a roaming profile, this property is a DATETIME value that indicates the last time the profile's
        ///     registry hive was uploaded to the server.
        /// </summary>
        public DateTime LastBackgroundRegistryUploadTime { get; private set; }

        public DateTime LastDownloadTime { get; private set; }
        public DateTime LastUploadTime { get; private set; }
        public DateTime LastUseTime { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Links folder.
        /// </summary>
        public object Links { get; private set; }

        public bool Loaded { get; private set; }
        public string LocalPath { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Music folder.
        /// </summary>
        public object Music { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Pictures folder.
        /// </summary>
        public object Pictures { get; private set; }

        public uint RefCount { get; private set; }
        public bool RoamingConfigured { get; private set; }
        public string RoamingPath { get; private set; }
        public bool RoamingPreference { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Saved Games folder.
        /// </summary>
        public object SavedGames { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Searches folder.
        /// </summary>
        public object Searches { get; private set; }

        public string SID { get; private set; }
        public bool Special { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Start Menu folder.
        /// </summary>
        public object StartMenu { get; private set; }

        public uint Status { get; private set; }

        /// <summary>
        ///     A Win32_FolderRedirectionHealth object that represents the health of the user's redirected Videos folder.
        /// </summary>
        public object Videos { get; private set; }

        public static UserProfile[] Retrieve(string remote, string username, string password)
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

        public static UserProfile[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static UserProfile[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_UserProfile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<UserProfile>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new UserProfile
                {
                    AppDataRoaming = managementObject.Properties["AppDataRoaming"].Value,
                    Contacts = managementObject.Properties["Contacts"].Value,
                    Desktop = managementObject.Properties["Desktop"].Value,
                    Documents = managementObject.Properties["Documents"].Value,
                    Downloads = managementObject.Properties["Downloads"].Value,
                    Favorites = managementObject.Properties["Favorites"].Value,
                    HealthStatus = (byte) managementObject.Properties["HealthStatus"].Value,
                    LastAttemptedProfileDownloadTime =
                        (DateTime) managementObject.Properties["LastAttemptedProfileDownloadTime"].Value,
                    LastAttemptedProfileUploadTime =
                        (DateTime) managementObject.Properties["LastAttemptedProfileUploadTime"].Value,
                    LastBackgroundRegistryUploadTime =
                        (DateTime) managementObject.Properties["LastBackgroundRegistryUploadTime"].Value,
                    LastDownloadTime = (DateTime) managementObject.Properties["LastDownloadTime"].Value,
                    LastUploadTime = (DateTime) managementObject.Properties["LastUploadTime"].Value,
                    LastUseTime = (DateTime) managementObject.Properties["LastUseTime"].Value,
                    Links = managementObject.Properties["Links"].Value,
                    Loaded = (bool) managementObject.Properties["Loaded"].Value,
                    LocalPath = (string) managementObject.Properties["LocalPath"].Value,
                    Music = managementObject.Properties["Music"].Value,
                    Pictures = managementObject.Properties["Pictures"].Value,
                    RefCount = (uint) managementObject.Properties["RefCount"].Value,
                    RoamingConfigured = (bool) managementObject.Properties["RoamingConfigured"].Value,
                    RoamingPath = (string) managementObject.Properties["RoamingPath"].Value,
                    RoamingPreference = (bool) managementObject.Properties["RoamingPreference"].Value,
                    SavedGames = managementObject.Properties["SavedGames"].Value,
                    Searches = managementObject.Properties["Searches"].Value,
                    SID = (string) managementObject.Properties["SID"].Value,
                    Special = (bool) managementObject.Properties["Special"].Value,
                    StartMenu = managementObject.Properties["StartMenu"].Value,
                    Status = (uint) managementObject.Properties["Status"].Value,
                    Videos = managementObject.Properties["Videos"].Value
                });

            return list.ToArray();
        }
    }
}