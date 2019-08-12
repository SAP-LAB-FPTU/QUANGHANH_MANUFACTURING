using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class GeneralListController : Controller
    {
        [Route("CDVT/GeneralList")]
        public IActionResult GeneralList()
        {
            return View("Views/CDVT/GeneralList.cshtml");
        }
    }
}