using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Views.CDVT
{
    public class AccidentController : Controller
    {
        [Route("CDVT/Su-co")]
        public ActionResult Accident()
        {
            return View("/Views/CDVT/Accident.cshtml");
        }
    }
}