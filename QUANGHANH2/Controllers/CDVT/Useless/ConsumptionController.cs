using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class ConsumptionController : Controller
    {
        [Route("CDVT/Tieuthu")]
        public ActionResult Consumption()
        {
            return View("/Views/CDVT/Consumption.cshtml");
        }
    }
}