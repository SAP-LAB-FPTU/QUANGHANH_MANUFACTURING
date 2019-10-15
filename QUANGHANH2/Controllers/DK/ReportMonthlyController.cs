using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class ReportMonthlyController : Controller
    {
        // GET: ReportMonthly
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-thang-quy")]
        public ActionResult getView()
        {
            return View("/Views/DK/MonthlyQuarterlyReport.cshtml");
        }
    }
}