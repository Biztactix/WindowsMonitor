using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_Printer class represents a device connected to a Win32 computer system that is capable of reproducing a
    ///     visual image on a medium.
    /// </summary>
    public sealed class Printer
    {
        /// <summary>
        ///     The Attributes property indicates the attributes of the Win32 printing device. These attributes are represented
        ///     through a combination of flags. Attributes of the printer include:
        ///     Queued  - Print jobs are buffered and queued.
        ///     Direct  - Specifies that the document should be sent directly to the printer.  This is used if print job are not
        ///     being properly queued.
        ///     Default - The printer is the default printer on the computer.
        ///     Shared - Available as a shared network resource.
        ///     Network - Attached to the network.
        ///     Hidden - Hidden from some users on the network.
        ///     Local - Directly connected to this computer.
        ///     EnableDevQ - Enable the queue on the printer if available.
        ///     KeepPrintedJobs - Specifies that the spooler should not delete documents after they are printed.
        ///     DoCompleteFirst - Start jobs that are finished spooling first.
        ///     WorkOffline - Queue print jobs when printer is not available.
        ///     EnableBIDI - Enable bi-directional printing.
        ///     RawOnly - Allow only raw data type jobs to be spooled.
        ///     Published - Indicates whether the printer is published in the network directory service.
        /// </summary>
        public uint Attributes { get; private set; }

        public ushort Availability { get; private set; }
        public string[] AvailableJobSheets { get; private set; }

        /// <summary>
        ///     The AveragePagesPerMinute property specifies the rate (average number of pages per minute) that the printer is
        ///     capable of sustaining.
        /// </summary>
        public uint AveragePagesPerMinute { get; private set; }

        public ushort[] Capabilities { get; private set; }
        public string[] CapabilityDescriptions { get; private set; }
        public string Caption { get; private set; }
        public string[] CharSetsSupported { get; private set; }

        /// <summary>
        ///     The Comment property specifies the comment of a print queue.
        ///     Example: Color printer
        /// </summary>
        public string Comment { get; private set; }

        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public ushort[] CurrentCapabilities { get; private set; }
        public string CurrentCharSet { get; private set; }
        public ushort CurrentLanguage { get; private set; }
        public string CurrentMimeType { get; private set; }
        public string CurrentNaturalLanguage { get; private set; }
        public string CurrentPaperType { get; private set; }

        /// <summary>
        ///     The Default property indicates whether the printer is the default printer on the computer.
        /// </summary>
        public bool Default { get; private set; }

        public ushort[] DefaultCapabilities { get; private set; }
        public uint DefaultCopies { get; private set; }
        public ushort DefaultLanguage { get; private set; }
        public string DefaultMimeType { get; private set; }
        public uint DefaultNumberUp { get; private set; }
        public string DefaultPaperType { get; private set; }

        /// <summary>
        ///     The DefaultPriority property specifies the default priority value assigned to each print job.
        /// </summary>
        public uint DefaultPriority { get; private set; }

        public string Description { get; private set; }
        public ushort DetectedErrorState { get; private set; }

        /// <summary>
        ///     The DeviceID property contains a string uniquely identifying the printer  with other devices on the system.
        /// </summary>
        public string DeviceID { get; private set; }

        /// <summary>
        ///     The Direct property indicates whether the print jobs should be sent directly to the printer.  This means that no
        ///     spool files are created for the print jobs.
        /// </summary>
        public bool Direct { get; private set; }

        /// <summary>
        ///     The DoCompleteFirst property indicates whether the printer should start jobs that have finished spooling as opposed
        ///     to the order of the job received.
        /// </summary>
        public bool DoCompleteFirst { get; private set; }

        /// <summary>
        ///     The DriverName property specifies the name of the Win32 printer driver.
        ///     Example: Windows NT Fax Driver
        /// </summary>
        public string DriverName { get; private set; }

        /// <summary>
        ///     The EnableBIDI property indicates whether the printer can print bidirectionally.
        /// </summary>
        public bool EnableBIDI { get; private set; }

        /// <summary>
        ///     The EnableDevQueryPrint property indicates whether to hold documents in the queue, if document and printer setups
        ///     do not match
        /// </summary>
        public bool EnableDevQueryPrint { get; private set; }

        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string[] ErrorInformation { get; private set; }

        /// <summary>
        ///     The ExtendedDetectedErrorState property reports standard error information.  Any additional information should be
        ///     recorded in the DetecteErrorState property.
        /// </summary>
        public ushort ExtendedDetectedErrorState { get; private set; }

        /// <summary>
        ///     Status information for a Printer, beyond that specified in the LogicalDevice Availability property. Values include
        ///     "Idle" (3) and an indication that the Device is currently printing (4).
        /// </summary>
        public ushort ExtendedPrinterStatus { get; private set; }

        /// <summary>
        ///     The Hidden property indicates whether the printer is hidden from network users.
        /// </summary>
        public bool Hidden { get; private set; }

        public uint HorizontalResolution { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint JobCountSinceLastReset { get; private set; }

        /// <summary>
        ///     The KeepPrintedJobs property indicates whether the print spooler should not delete the jobs after they are
        ///     completed.
        /// </summary>
        public bool KeepPrintedJobs { get; private set; }

        public ushort[] LanguagesSupported { get; private set; }
        public uint LastErrorCode { get; private set; }

        /// <summary>
        ///     The Local property indicates whether the printer is attached to the network.  A masquerading printer is printer
        ///     that is implemented as local printers but has a port that refers to a remote machine.  From the application
        ///     perspective these hybrid printers should be viewed as printer connections since that is their intended behavior.
        /// </summary>
        public bool Local { get; private set; }

        /// <summary>
        ///     The Location property specifies the physical location of the printer.
        ///     Example: Bldg. 38, Room 1164
        /// </summary>
        public string Location { get; private set; }

        public ushort MarkingTechnology { get; private set; }
        public uint MaxCopies { get; private set; }
        public uint MaxNumberUp { get; private set; }
        public uint MaxSizeSupported { get; private set; }
        public string[] MimeTypesSupported { get; private set; }
        public string Name { get; private set; }
        public string[] NaturalLanguagesSupported { get; private set; }

        /// <summary>
        ///     The Network property indicates whether the printer is a network printer.
        /// </summary>
        public bool Network { get; private set; }

        public ushort[] PaperSizesSupported { get; private set; }
        public string[] PaperTypesAvailable { get; private set; }

        /// <summary>
        ///     The Parameters property specifies optional parameters for the print processor.
        ///     Example: Copies=2
        /// </summary>
        public string Parameters { get; private set; }

        public string PNPDeviceID { get; private set; }

        /// <summary>
        ///     The PortName property identifies the ports that can be used to transmit data to the printer. If a printer is
        ///     connected to more than one port, the names of each port are separated by commas. Under Windows 95, only one port
        ///     can be specified.
        ///     Example: LPT1:, LPT2:, LPT3:
        /// </summary>
        public string PortName { get; private set; }

        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }

        /// <summary>
        ///     The PrinterPaperNames property indicates the list of paper sizes supported by the printer. The printer-specified
        ///     names are used to represent supported paper sizes.
        ///     Example: B5 (JIS).
        /// </summary>
        public string[] PrinterPaperNames { get; private set; }

        /// <summary>
        ///     This property has been deprecated in favor of PrinterStatus, DetectedErrorState and ErrorInformation CIM properties
        ///     that more clearly indicate the state and error status of the printer. The PrinterState property specifies a values
        ///     indicating one of the possible states relating to this printer.
        /// </summary>
        public uint PrinterState { get; private set; }

        public ushort PrinterStatus { get; private set; }

        /// <summary>
        ///     The PrintJobDataType property indicates the default data type that will be used for a print job.
        /// </summary>
        public string PrintJobDataType { get; private set; }

        /// <summary>
        ///     The PrintProcessor property specifies the name of the print spooler that handles print jobs.
        ///     Example: SPOOLSS.DLL.
        /// </summary>
        public string PrintProcessor { get; private set; }

        /// <summary>
        ///     The Priority property specifies the priority of the  printer. The jobs on a higher priority printer are scheduled
        ///     first.
        /// </summary>
        public uint Priority { get; private set; }

        /// <summary>
        ///     The Published property indicates whether the printer is published in the network directory service.
        /// </summary>
        public bool Published { get; private set; }

        /// <summary>
        ///     The Queued property indicates whether the printer buffers and queues print jobs.
        /// </summary>
        public bool Queued { get; private set; }

        /// <summary>
        ///     The RawOnly property indicates whether the printer accepts only raw data to be spooled.
        /// </summary>
        public bool RawOnly { get; private set; }

        /// <summary>
        ///     The SeparatorFile property specifies the name of the file used to create a separator page. This page is used to
        ///     separate print jobs sent to the printer.
        /// </summary>
        public string SeparatorFile { get; private set; }

        /// <summary>
        ///     The ServerName property identifies the server that controls the printer. If this string is NULL, the printer is
        ///     controlled locally.
        /// </summary>
        public string ServerName { get; private set; }

        /// <summary>
        ///     The Shared property indicates whether the printer is available as a shared network resource.
        /// </summary>
        public bool Shared { get; private set; }

        /// <summary>
        ///     The ShareName property indicates the share name of the Win32 printing device.
        ///     Example: \\PRINTSERVER1\PRINTER2
        /// </summary>
        public string ShareName { get; private set; }

        /// <summary>
        ///     The SpoolEnabled property shows whether spooling is enabled for this printer.
        ///     Values:TRUE or FALSE.
        ///     The SpoolEnabled property has been deprecated.  There is no replacementvalue and this property is now considered
        ///     obsolete.
        /// </summary>
        public bool SpoolEnabled { get; private set; }

        /// <summary>
        ///     The StartTime property specifies the earliest time the printer can print a job (if the printer has been limited to
        ///     print only at certain times). This value is expressed as time elapsed since 12:00 AM GMT (Greenwich mean time).
        /// </summary>
        public DateTime StartTime { get; private set; }

        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public DateTime TimeOfLastReset { get; private set; }

        /// <summary>
        ///     The UntilTime property specifies the latest time the printer can print a job (if the printer has been limited to
        ///     print only at certain times). This value is expressed as time elapsed since 12:00 AM GMT (Greenwich mean time).
        /// </summary>
        public DateTime UntilTime { get; private set; }

        public uint VerticalResolution { get; private set; }

        /// <summary>
        ///     The WorkOffline property indicates whether to queue print jobs on the computer if the printer is offline.
        /// </summary>
        public bool WorkOffline { get; private set; }

        public static Printer[] Retrieve(string remote, string username, string password)
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

        public static Printer[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Printer[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Printer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Printer>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Printer
                {
                    Attributes = (uint) managementObject.Properties["Attributes"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    AvailableJobSheets = (string[]) managementObject.Properties["AvailableJobSheets"].Value,
                    AveragePagesPerMinute = (uint) managementObject.Properties["AveragePagesPerMinute"].Value,
                    Capabilities = (ushort[]) managementObject.Properties["Capabilities"].Value,
                    CapabilityDescriptions = (string[]) managementObject.Properties["CapabilityDescriptions"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CharSetsSupported = (string[]) managementObject.Properties["CharSetsSupported"].Value,
                    Comment = (string) managementObject.Properties["Comment"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentCapabilities = (ushort[]) managementObject.Properties["CurrentCapabilities"].Value,
                    CurrentCharSet = (string) managementObject.Properties["CurrentCharSet"].Value,
                    CurrentLanguage = (ushort) managementObject.Properties["CurrentLanguage"].Value,
                    CurrentMimeType = (string) managementObject.Properties["CurrentMimeType"].Value,
                    CurrentNaturalLanguage = (string) managementObject.Properties["CurrentNaturalLanguage"].Value,
                    CurrentPaperType = (string) managementObject.Properties["CurrentPaperType"].Value,
                    Default = (bool) managementObject.Properties["Default"].Value,
                    DefaultCapabilities = (ushort[]) managementObject.Properties["DefaultCapabilities"].Value,
                    DefaultCopies = (uint) managementObject.Properties["DefaultCopies"].Value,
                    DefaultLanguage = (ushort) managementObject.Properties["DefaultLanguage"].Value,
                    DefaultMimeType = (string) managementObject.Properties["DefaultMimeType"].Value,
                    DefaultNumberUp = (uint) managementObject.Properties["DefaultNumberUp"].Value,
                    DefaultPaperType = (string) managementObject.Properties["DefaultPaperType"].Value,
                    DefaultPriority = (uint) managementObject.Properties["DefaultPriority"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DetectedErrorState = (ushort) managementObject.Properties["DetectedErrorState"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    Direct = (bool) managementObject.Properties["Direct"].Value,
                    DoCompleteFirst = (bool) managementObject.Properties["DoCompleteFirst"].Value,
                    DriverName = (string) managementObject.Properties["DriverName"].Value,
                    EnableBIDI = (bool) managementObject.Properties["EnableBIDI"].Value,
                    EnableDevQueryPrint = (bool) managementObject.Properties["EnableDevQueryPrint"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ErrorInformation = (string[]) managementObject.Properties["ErrorInformation"].Value,
                    ExtendedDetectedErrorState = (ushort) managementObject.Properties["ExtendedDetectedErrorState"]
                        .Value,
                    ExtendedPrinterStatus = (ushort) managementObject.Properties["ExtendedPrinterStatus"].Value,
                    Hidden = (bool) managementObject.Properties["Hidden"].Value,
                    HorizontalResolution = (uint) managementObject.Properties["HorizontalResolution"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    JobCountSinceLastReset = (uint) managementObject.Properties["JobCountSinceLastReset"].Value,
                    KeepPrintedJobs = (bool) managementObject.Properties["KeepPrintedJobs"].Value,
                    LanguagesSupported = (ushort[]) managementObject.Properties["LanguagesSupported"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Local = (bool) managementObject.Properties["Local"].Value,
                    Location = (string) managementObject.Properties["Location"].Value,
                    MarkingTechnology = (ushort) managementObject.Properties["MarkingTechnology"].Value,
                    MaxCopies = (uint) managementObject.Properties["MaxCopies"].Value,
                    MaxNumberUp = (uint) managementObject.Properties["MaxNumberUp"].Value,
                    MaxSizeSupported = (uint) managementObject.Properties["MaxSizeSupported"].Value,
                    MimeTypesSupported = (string[]) managementObject.Properties["MimeTypesSupported"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NaturalLanguagesSupported = (string[]) managementObject.Properties["NaturalLanguagesSupported"]
                        .Value,
                    Network = (bool) managementObject.Properties["Network"].Value,
                    PaperSizesSupported = (ushort[]) managementObject.Properties["PaperSizesSupported"].Value,
                    PaperTypesAvailable = (string[]) managementObject.Properties["PaperTypesAvailable"].Value,
                    Parameters = (string) managementObject.Properties["Parameters"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PortName = (string) managementObject.Properties["PortName"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    PrinterPaperNames = (string[]) managementObject.Properties["PrinterPaperNames"].Value,
                    PrinterState = (uint) managementObject.Properties["PrinterState"].Value,
                    PrinterStatus = (ushort) managementObject.Properties["PrinterStatus"].Value,
                    PrintJobDataType = (string) managementObject.Properties["PrintJobDataType"].Value,
                    PrintProcessor = (string) managementObject.Properties["PrintProcessor"].Value,
                    Priority = (uint) managementObject.Properties["Priority"].Value,
                    Published = (bool) managementObject.Properties["Published"].Value,
                    Queued = (bool) managementObject.Properties["Queued"].Value,
                    RawOnly = (bool) managementObject.Properties["RawOnly"].Value,
                    SeparatorFile = (string) managementObject.Properties["SeparatorFile"].Value,
                    ServerName = (string) managementObject.Properties["ServerName"].Value,
                    Shared = (bool) managementObject.Properties["Shared"].Value,
                    ShareName = (string) managementObject.Properties["ShareName"].Value,
                    SpoolEnabled = (bool) managementObject.Properties["SpoolEnabled"].Value,
                    StartTime = (DateTime) managementObject.Properties["StartTime"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TimeOfLastReset = (DateTime) managementObject.Properties["TimeOfLastReset"].Value,
                    UntilTime = (DateTime) managementObject.Properties["UntilTime"].Value,
                    VerticalResolution = (uint) managementObject.Properties["VerticalResolution"].Value,
                    WorkOffline = (bool) managementObject.Properties["WorkOffline"].Value
                });

            return list.ToArray();
        }
    }
}