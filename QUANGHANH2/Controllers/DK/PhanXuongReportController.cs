using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class PhanXuongReportController : Controller
    {
        // GET: PhanXuongReport
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/bao-cao-phan-xuong-phong-ban")]
        public ActionResult ReportIncident()
        {
            return View("/Views/DK/PhanXuongReport.cshtml");
        }
    }
}