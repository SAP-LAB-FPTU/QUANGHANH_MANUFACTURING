using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.DK
{
    public class ReportManuCharcoalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-nhanh")]
        public ActionResult QuickReport()
        {
            return View("/Views/DK/ReportManuCharcoal/QuickReport.cshtml");
        }
    }
}