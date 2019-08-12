using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Views.CDVT
{
    public class ActivitiesController : Controller
    {
        [Route("CDVT/Activities")]
        public IActionResult Index()
        {
            return View("Views/CDVT/Activities.cshtml");
        }
    }
}