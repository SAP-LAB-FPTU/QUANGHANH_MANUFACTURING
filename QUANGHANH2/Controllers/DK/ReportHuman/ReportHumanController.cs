using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.DK.ReportHuman
{
    public class ReportHumanController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-ngay")]
        public ActionResult Daily()
        {
            return View("/Views/DK/ReportHuman/Daily.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-thang")]
        public ActionResult Monthly()
        {
            return View("/Views/DK/ReportHuman/Monthly.cshtml");
        }
    }
}