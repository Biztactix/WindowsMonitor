using Microsoft.AspNetCore.Mvc;

namespace WindowsMonitor.Service.Controllers
{
    [Produces("application/json")]
    //[Route("system")]
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return Json(Win32.OperatingSystem.Retrieve());
        }

        public IActionResult Drives()
        {
            return Json(Win32.Hardware.DiskDrives.DiskDrive.Retrieve());
        }

        public IActionResult Partitions()
        {
            return Json(Win32.Hardware.DiskDrives.DiskPartition.Retrieve());
        }

        public IActionResult Quotas()
        {
            return Json(Win32.Hardware.DiskDrives.DiskQuota.Retrieve());
        }
    }
}