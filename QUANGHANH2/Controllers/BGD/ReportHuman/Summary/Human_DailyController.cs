using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.ReportHuman
{
    public class ReportHuman_SummaryController : Controller
    {
        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-luc-theo-ngay")]
        public ActionResult Index()
        {
            return View("/Views/BGD/ReportHuman/Summary/Human_Daily.cshtml");
        }
    }
}