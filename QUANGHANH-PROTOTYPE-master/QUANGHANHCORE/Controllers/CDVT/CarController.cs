using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Views.CDVT
{
    public class CarController : Controller
    {
        public IActionResult Details()
        {
            return View("Views/CDVT/Car/Details.cshtml");
        }
        public IActionResult Maintenance()
        {
            return View("Views/CDVT/Car/Maintenance.cshtml");
        }
    }
}