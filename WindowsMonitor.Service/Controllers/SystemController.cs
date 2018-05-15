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

        public IActionResult Fans()
        {
            return Json(Win32.Hardware.DiskDrives.DiskDrivePhysicalMedia.Retrieve());
        }
    }
}