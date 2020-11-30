using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.DK
{
    public class ReportIncidentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/bao-cao-su-co")]
        public ActionResult ReportIncident()
        {
            return View("/Views/DK/ReportIncident.cshtml");
        }
    }
}