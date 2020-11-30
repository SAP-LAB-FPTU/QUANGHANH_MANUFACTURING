using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class AccreditationController : Controller
    {
        [Route("CDVT/Car/Accreditation")]
        public ActionResult Accreditation()
        {
            return View("/Views/CDVT/Car/Accreditation.cshtml");
        }
    }
}