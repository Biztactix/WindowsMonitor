using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class VideoModeDescriptor
    {
		public byte CompositePolarityType { get; private set; }
		public ushort HorizontalActivePixels { get; private set; }
		public ushort HorizontalBlankingPixels { get; private set; }
		public ushort HorizontalBorder { get; private set; }
		public ushort HorizontalImageSize { get; private set; }
		public byte HorizontalPolarityType { get; private set; }
		public uint HorizontalRefreshRateDenominator { get; private set; }
		public uint HorizontalRefreshRateNumerator { get; private set; }
		public ushort HorizontalSyncOffset { get; private set; }
		public ushort HorizontalSyncPulseWidth { get; private set; }
		public bool IsInterlaced { get; private set; }
		public byte IsSerrationRequired { get; private set; }
		public byte IsSyncOnRGB { get; private set; }
		public byte Origin { get; private set; }
		public uint PixelClockRate { get; private set; }
		public byte StereoModeType { get; private set; }
		public byte SyncSignalType { get; private set; }
		public byte TimingType { get; private set; }
		public ushort VerticalActivePixels { get; private set; }
		public ushort VerticalBlankingPixels { get; private set; }
		public ushort VerticalBorder { get; private set; }
		public ushort VerticalImageSize { get; private set; }
		public byte VerticalPolarityType { get; private set; }
		public uint VerticalRefreshRateDenominator { get; private set; }
		public uint VerticalRefreshRateNumerator { get; private set; }
		public ushort VerticalSyncOffset { get; private set; }
		public ushort VerticalSyncPulseWidth { get; private set; }
		public byte VideoStandardType { get; private set; }

        public static IEnumerable<VideoModeDescriptor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<VideoModeDescriptor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<VideoModeDescriptor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM VideoModeDescriptor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new VideoModeDescriptor
                {
                     CompositePolarityType = (byte) (managementObject.Properties["CompositePolarityType"]?.Value ?? default(byte)),
		 HorizontalActivePixels = (ushort) (managementObject.Properties["HorizontalActivePixels"]?.Value ?? default(ushort)),
		 HorizontalBlankingPixels = (ushort) (managementObject.Properties["HorizontalBlankingPixels"]?.Value ?? default(ushort)),
		 HorizontalBorder = (ushort) (managementObject.Properties["HorizontalBorder"]?.Value ?? default(ushort)),
		 HorizontalImageSize = (ushort) (managementObject.Properties["HorizontalImageSize"]?.Value ?? default(ushort)),
		 HorizontalPolarityType = (byte) (managementObject.Properties["HorizontalPolarityType"]?.Value ?? default(byte)),
		 HorizontalRefreshRateDenominator = (uint) (managementObject.Properties["HorizontalRefreshRateDenominator"]?.Value ?? default(uint)),
		 HorizontalRefreshRateNumerator = (uint) (managementObject.Properties["HorizontalRefreshRateNumerator"]?.Value ?? default(uint)),
		 HorizontalSyncOffset = (ushort) (managementObject.Properties["HorizontalSyncOffset"]?.Value ?? default(ushort)),
		 HorizontalSyncPulseWidth = (ushort) (managementObject.Properties["HorizontalSyncPulseWidth"]?.Value ?? default(ushort)),
		 IsInterlaced = (bool) (managementObject.Properties["IsInterlaced"]?.Value ?? default(bool)),
		 IsSerrationRequired = (byte) (managementObject.Properties["IsSerrationRequired"]?.Value ?? default(byte)),
		 IsSyncOnRGB = (byte) (managementObject.Properties["IsSyncOnRGB"]?.Value ?? default(byte)),
		 Origin = (byte) (managementObject.Properties["Origin"]?.Value ?? default(byte)),
		 PixelClockRate = (uint) (managementObject.Properties["PixelClockRate"]?.Value ?? default(uint)),
		 StereoModeType = (byte) (managementObject.Properties["StereoModeType"]?.Value ?? default(byte)),
		 SyncSignalType = (byte) (managementObject.Properties["SyncSignalType"]?.Value ?? default(byte)),
		 TimingType = (byte) (managementObject.Properties["TimingType"]?.Value ?? default(byte)),
		 VerticalActivePixels = (ushort) (managementObject.Properties["VerticalActivePixels"]?.Value ?? default(ushort)),
		 VerticalBlankingPixels = (ushort) (managementObject.Properties["VerticalBlankingPixels"]?.Value ?? default(ushort)),
		 VerticalBorder = (ushort) (managementObject.Properties["VerticalBorder"]?.Value ?? default(ushort)),
		 VerticalImageSize = (ushort) (managementObject.Properties["VerticalImageSize"]?.Value ?? default(ushort)),
		 VerticalPolarityType = (byte) (managementObject.Properties["VerticalPolarityType"]?.Value ?? default(byte)),
		 VerticalRefreshRateDenominator = (uint) (managementObject.Properties["VerticalRefreshRateDenominator"]?.Value ?? default(uint)),
		 VerticalRefreshRateNumerator = (uint) (managementObject.Properties["VerticalRefreshRateNumerator"]?.Value ?? default(uint)),
		 VerticalSyncOffset = (ushort) (managementObject.Properties["VerticalSyncOffset"]?.Value ?? default(ushort)),
		 VerticalSyncPulseWidth = (ushort) (managementObject.Properties["VerticalSyncPulseWidth"]?.Value ?? default(ushort)),
		 VideoStandardType = (byte) (managementObject.Properties["VideoStandardType"]?.Value ?? default(byte))
                };
        }
    }
}