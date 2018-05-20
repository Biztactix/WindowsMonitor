using WindowsMonitor.Hardware.Drives.DiskDrives;
using WindowsMonitor.Windows;
using Microsoft.AspNetCore.Mvc;

namespace WindowsMonitor.Service.Controllers
{
    [Produces("application/json")]
    //[Route("system")]
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return Json(Win32OperatingSystem.Retrieve());
        }

        public IActionResult Drives()
        {
            return Json(DiskDrive.Retrieve());
        }

        public IActionResult Partitions()
        {
            return Json(DiskPartition.Retrieve());
        }

        public IActionResult Quotas()
        {
            return Json(DiskQuota.Retrieve());
        }
    }
}