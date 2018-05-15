using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WindowsMonitor.Service.Controllers
{
    [Produces("application/json")]
    //[Route("system")]
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return Json(WindowsMonitor.Win32.OperatingSystem.Retrieve());
        }

        public IActionResult Fans()
        {
            return Json(WindowsMonitor.Win32.Hardware.Cooling.Fan.Retrieve());
        }
    }
}