using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class ConsumptionController : Controller
    {
        public IActionResult Consumption()
        {
            return View("Views/CDVT/Consumption.cshtml");
        }
    }
}