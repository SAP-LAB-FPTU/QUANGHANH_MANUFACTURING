using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Controllers
{
    public class MachineController : Controller
    {
        public IActionResult Details()
        {
            return View("Views/CDVT/Machine/Details.cshtml");
        }
        public IActionResult Maintenance()
        {
            return View("Views/CDVT/Machine/Maintenance.cshtml");
        }
    }
}