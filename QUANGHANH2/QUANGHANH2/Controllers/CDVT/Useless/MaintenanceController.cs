using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class MaintenanceController : Controller
    {
        [Route("CDVT/Bd")]
        public ActionResult Maintenance()
        {
            return View("/Views/CDVT/Maintenance.cshtml");
        }
    }
}