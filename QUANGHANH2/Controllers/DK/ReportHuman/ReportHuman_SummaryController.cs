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
            return View("/Views/DK/ReportHuman/Summary/Human_Daily.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-theo-phan-xuong-theo-ngay")]
        public ActionResult Index_2()
        {
            return View("/Views/DK/ReportHuman/Summary/Human_Department_Daily.cshtml");
        }
    }
}