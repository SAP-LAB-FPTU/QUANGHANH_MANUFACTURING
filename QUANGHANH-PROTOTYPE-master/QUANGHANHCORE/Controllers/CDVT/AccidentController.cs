using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Views.CDVT
{
    public class AccidentController : Controller
    {
        [Route("CDVT/Accident")]
        public IActionResult Accident()
        {
            return View("Views/CDVT/Accident.cshtml");
        }
    }
}