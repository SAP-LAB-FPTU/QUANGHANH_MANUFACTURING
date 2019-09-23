using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Cap_nhat
{
    public class CapnhatsucoController : Controller
    {
        [Route("phong-cdvt/cap-nhat/su-co")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Cap_nhat/UpdateIncident.cshtml");
        }
    }
}