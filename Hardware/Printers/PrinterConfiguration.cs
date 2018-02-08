using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_PrinterConfiguration class defines the configuration for a printer device.  This includes capabilities
    ///     such as resolution, color, fonts, and orientation.
    /// </summary>
    public sealed class PrinterConfiguration
    {
        /// <summary>
        ///     The BitsPerPel property contains the number of bits per pixel for the output device Win32 printer.  This member is
        ///     used by display drivers and not by printer drivers.
        ///     Example: 8.
        ///     This property has been deprecated because it is not applicable to printers.  There is no replacement value.
        /// </summary>
        public uint BitsPerPel { get; private set; }

        public string Caption { get; private set; }

        /// <summary>
        ///     The Collate property specifies whether to collate the pages that are printed. To collate is to print out the entire
        ///     document before printing the next copy, as opposed to printing out each page of the document the required number
        ///     times. This property is ignored unless the printer driver indicates support for collation.
        ///     Values: TRUE or FALSE. If TRUE, the printer collates all documents.
        /// </summary>
        public bool Collate { get; private set; }

        /// <summary>
        ///     The Color property indicates whether the document is to be printed in color or monochrome.  Some color printers
        ///     have the capability to print using true black instead of a combination of Yellow, Cyan, and Magenta.  This usually
        ///     creates darker and sharper text for documents.  This option is only useful for color printers that support true
        ///     black printing.
        /// </summary>
        public uint Color { get; private set; }

        /// <summary>
        ///     The Copies property indicates the number of copies to be printed. The printer driver must support printing
        ///     multi-page copies.
        ///     Example: 2
        /// </summary>
        public uint Copies { get; private set; }

        public string Description { get; private set; }

        /// <summary>
        ///     The DeviceName property specifies the friendly name of the printer.  This name is unique to the type of printer and
        ///     may be truncated because of the limitations of the string from which it is derived.
        ///     Example PCL/HP LaserJet
        /// </summary>
        public string DeviceName { get; private set; }

        /// <summary>
        ///     The DisplayFlags property contains two bits of information about the display. This member communicates whether the
        ///     display device is monochrome or colored, and interlaced or non-interlaced, by masking its value with the
        ///     DM_GRAYSCALE and DM_INTERLACED masks respectively.
        ///     This property has been deprecated because it is not applicable to printers.  There is no replacement value.
        /// </summary>
        public uint DisplayFlags { get; private set; }

        /// <summary>
        ///     The DisplayFrequency property indicates the refresh frequency of the display The refresh frequency for a monitor is
        ///     the number of times the screen is redrawn per second.
        ///     This property has been deprecated because it is not applicable to printers.  There is no replacement value.
        /// </summary>
        public uint DisplayFrequency { get; private set; }

        /// <summary>
        ///     The DitherType property indicates the dither type of the printer.  This member can assume predefined values of 1 to
        ///     5, or driver-defined values from 6 to 256.  Line art dithering is a special dithering method that produces well
        ///     defined borders between black, white, and gray scalings.  It is not suitable for images that include continuous
        ///     graduations in intensity and hue such as scanned photographs.
        /// </summary>
        public uint DitherType { get; private set; }

        /// <summary>
        ///     The DriverVersion property indicates the version number of the Win32 printer driver.  The version numbers are
        ///     created and maintained by the driver manufacturer.
        /// </summary>
        public uint DriverVersion { get; private set; }

        /// <summary>
        ///     The Duplex property indicates whether printing is done on one or both sides.
        ///     Values: TRUE or FALSE. If TRUE, printing is done on both sides.
        /// </summary>
        public bool Duplex { get; private set; }

        /// <summary>
        ///     The FormName property indicates the name of the form used for the print job.  This property is used only on Windows
        ///     NT/Windows 2000 systems.
        ///     Example: Legal
        /// </summary>
        public string FormName { get; private set; }

        /// <summary>
        ///     The HorizontalResolution property indicates the print resolution along the X axis (width) of the print job. This
        ///     value is only set when the PrintQuality property of this class is positive and is similar to the XResolution
        ///     property.
        /// </summary>
        public uint HorizontalResolution { get; private set; }

        /// <summary>
        ///     The ICMIntent (Image Color Matching Intent) property indicates the specific value of one of the three possible
        ///     color matching methods (called intents) that should be used by default.  ICM applications establish intents by
        ///     using the ICM functions.  This property can assume predefined values of 1 to 3, or driver-defined values from 4 to
        ///     256.  Non-ICM applications can use this value to determine how the printer handles color printing jobs.
        /// </summary>
        public uint ICMIntent { get; private set; }

        /// <summary>
        ///     The ICMMethod (Image Color Matching Method) property specifies how ICM is handled.  For a non-ICM application, this
        ///     property determines if ICM is enabled or disabled.  For ICM applications, the system examines this property to
        ///     determine which part of the computer system handles ICM support.
        /// </summary>
        public uint ICMMethod { get; private set; }

        /// <summary>
        ///     The LogPixels property contains the number of pixels per logical inch.  This member is valid only with devices that
        ///     work with pixels (this excludes devices such as printers).
        ///     This property has been deprecated because it is not applicable to printers.  There is no replacement value.
        /// </summary>
        public uint LogPixels { get; private set; }

        /// <summary>
        ///     The MediaType property specifies the type of media being printed on. The property can be set to a predefined value
        ///     or a driver-defined value greater than or equal to 256. For Windows 95 and later; Windows 2000.
        /// </summary>
        public uint MediaType { get; private set; }

        /// <summary>
        ///     The Name property indicates the name of the printer with which this configuration is associated.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     The Orientation property indicates the printing orientation of the paper.
        /// </summary>
        public uint Orientation { get; private set; }

        /// <summary>
        ///     The PaperLength property indicates the length of the paper.
        ///     Example: 2794
        /// </summary>
        public uint PaperLength { get; private set; }

        /// <summary>
        ///     The PaperSize property indicates the size of the paper.
        ///     Example: A4 or Letter
        /// </summary>
        public string PaperSize { get; private set; }

        /// <summary>
        ///     The PaperWidth property indicates the width of the paper.
        ///     Example: 2159
        /// </summary>
        public uint PaperWidth { get; private set; }

        /// <summary>
        ///     The PelsHeight property indicates the height of the displayable surface.
        ///     This property has been deprecated because it is not applicable to printers.  There is no replacement value.
        /// </summary>
        public uint PelsHeight { get; private set; }

        /// <summary>
        ///     The PelsWidth property indicates the width of the displayable surface.
        ///     This property has been deprecated because it is not applicable to printers.  There is no replacement value.
        /// </summary>
        public uint PelsWidth { get; private set; }

        /// <summary>
        ///     The PrintQuality property indicates one of four quality levels of the print job.  If a positive value is specified,
        ///     the quality is measured in dots per inch.
        ///     Example: Draft
        /// </summary>
        public uint PrintQuality { get; private set; }

        /// <summary>
        ///     The Scale property specifies the factor by which the printed output is to be scaled.  For example a scale of 75
        ///     reduces the print output to 3/4 its original height and width.
        /// </summary>
        public uint Scale { get; private set; }

        public string SettingID { get; private set; }

        /// <summary>
        ///     The SpecificationVersion property indicates the version number of the initialization data for the device associated
        ///     with the Win32 printer.
        /// </summary>
        public uint SpecificationVersion { get; private set; }

        /// <summary>
        ///     The TTOption property specifies how TrueType(r) fonts should be printed.  There are 3 possible values:
        ///     Bitmap -  Prints TrueType fonts as graphics. This is the default action for dot-matrix printers.
        ///     Download -  Downloads TrueType fonts as soft fonts. This is the default action for printers that use the Printer
        ///     Control Language (PCL).
        ///     Substitute -  Substitutes device fonts for TrueType fonts. This is the default action for PostScript(r) printers.
        /// </summary>
        public uint TTOption { get; private set; }

        /// <summary>
        ///     The VerticalResolution property indicates the print resolution along the Y axis (height) of the print job. This
        ///     value is only set when the PrintQuality property of this class is positive, and is similar to the YResolution
        ///     property.
        /// </summary>
        public uint VerticalResolution { get; private set; }

        /// <summary>
        ///     The XResolution property has been deprecated to theHorizontalResolution property.  Please refer to the description
        ///     of that property.
        /// </summary>
        public uint XResolution { get; private set; }

        /// <summary>
        ///     The YResolution property has been deprecated to theVerticalResolution property.  Please refer to the description of
        ///     that property.
        /// </summary>
        public uint YResolution { get; private set; }

        public static PrinterConfiguration[] Retrieve(string remote, string username, string password)
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

        public static PrinterConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrinterConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrinterConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrinterConfiguration
                {
                    BitsPerPel = (uint) managementObject.Properties["BitsPerPel"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Collate = (bool) managementObject.Properties["Collate"].Value,
                    Color = (uint) managementObject.Properties["Color"].Value,
                    Copies = (uint) managementObject.Properties["Copies"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceName = (string) managementObject.Properties["DeviceName"].Value,
                    DisplayFlags = (uint) managementObject.Properties["DisplayFlags"].Value,
                    DisplayFrequency = (uint) managementObject.Properties["DisplayFrequency"].Value,
                    DitherType = (uint) managementObject.Properties["DitherType"].Value,
                    DriverVersion = (uint) managementObject.Properties["DriverVersion"].Value,
                    Duplex = (bool) managementObject.Properties["Duplex"].Value,
                    FormName = (string) managementObject.Properties["FormName"].Value,
                    HorizontalResolution = (uint) managementObject.Properties["HorizontalResolution"].Value,
                    ICMIntent = (uint) managementObject.Properties["ICMIntent"].Value,
                    ICMMethod = (uint) managementObject.Properties["ICMMethod"].Value,
                    LogPixels = (uint) managementObject.Properties["LogPixels"].Value,
                    MediaType = (uint) managementObject.Properties["MediaType"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Orientation = (uint) managementObject.Properties["Orientation"].Value,
                    PaperLength = (uint) managementObject.Properties["PaperLength"].Value,
                    PaperSize = (string) managementObject.Properties["PaperSize"].Value,
                    PaperWidth = (uint) managementObject.Properties["PaperWidth"].Value,
                    PelsHeight = (uint) managementObject.Properties["PelsHeight"].Value,
                    PelsWidth = (uint) managementObject.Properties["PelsWidth"].Value,
                    PrintQuality = (uint) managementObject.Properties["PrintQuality"].Value,
                    Scale = (uint) managementObject.Properties["Scale"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    SpecificationVersion = (uint) managementObject.Properties["SpecificationVersion"].Value,
                    TTOption = (uint) managementObject.Properties["TTOption"].Value,
                    VerticalResolution = (uint) managementObject.Properties["VerticalResolution"].Value,
                    XResolution = (uint) managementObject.Properties["XResolution"].Value,
                    YResolution = (uint) managementObject.Properties["YResolution"].Value
                });

            return list.ToArray();
        }
    }
}