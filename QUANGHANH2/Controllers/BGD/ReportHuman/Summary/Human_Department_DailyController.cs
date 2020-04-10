using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.BGD.ReportHuman.Summary
{
    public class Human_Department_DailyController : Controller
    {
        [Route("ban-giam-doc/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-theo-phan-xuong-theo-ngay")]
        public ActionResult Index()
        {
            return View("/Views/BGD/ReportHuman/Summary/Human_Department_Daily.cshtml");
        }
    }
}