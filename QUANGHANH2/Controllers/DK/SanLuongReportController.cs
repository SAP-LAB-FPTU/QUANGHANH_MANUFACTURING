using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class SanLuongReportController : Controller
    {
        // GET: SanLuongReport
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty")]
        public ActionResult Index()
        {
            return View("/Views/DK/SanLuongReport.cshtml");
        }
    }
}