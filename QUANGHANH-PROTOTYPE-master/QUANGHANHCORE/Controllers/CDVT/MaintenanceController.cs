using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class MaintenanceController : Controller
    {
        [Route("CDVT/Maintenance")]
        public IActionResult Maintenance()
        {
            return View("Views/CDVT/Maintenance.cshtml");
        }
    }
}