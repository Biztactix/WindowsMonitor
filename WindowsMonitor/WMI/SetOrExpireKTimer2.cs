using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SetOrExpireKTimer2
    {
		public uint Callback { get; private set; }
		public uint CallbackContext { get; private set; }
		public ulong DueTime { get; private set; }
		public uint Flags { get; private set; }
		public ulong MaximumDueTime { get; private set; }
		public ulong Period { get; private set; }
		public uint Timer { get; private set; }
		public byte TimerFlags { get; private set; }

        public static IEnumerable<SetOrExpireKTimer2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SetOrExpireKTimer2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SetOrExpireKTimer2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SetOrExpireKTimer2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SetOrExpireKTimer2
                {
                     Callback = (uint) (managementObject.Properties["Callback"]?.Value ?? default(uint)),
		 CallbackContext = (uint) (managementObject.Properties["CallbackContext"]?.Value ?? default(uint)),
		 DueTime = (ulong) (managementObject.Properties["DueTime"]?.Value ?? default(ulong)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 MaximumDueTime = (ulong) (managementObject.Properties["MaximumDueTime"]?.Value ?? default(ulong)),
		 Period = (ulong) (managementObject.Properties["Period"]?.Value ?? default(ulong)),
		 Timer = (uint) (managementObject.Properties["Timer"]?.Value ?? default(uint)),
		 TimerFlags = (byte) (managementObject.Properties["TimerFlags"]?.Value ?? default(byte))
                };
        }
    }
}