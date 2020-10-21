using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.DK.ReportManuCharcoal
{
    public class DetailManuReportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-chi-tiet-san-xuat-theo-ngay")]
        public ActionResult Daily()
        {
            return View("/Views/DK/ReportManuCharcoal/DetailManuReport/Daily.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-chi-tiet-san-xuat-theo-tuan")]
        public ActionResult Week()
        {
            return View("/Views/DK/ReportManuCharcoal/DetailManuReport/Week.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-chi-tiet-san-xuat-theo-thang")]
        public ActionResult MonthlyOrQuarter()
        {
            return View("/Views/DK/ReportManuCharcoal/DetailManuReport/MonthlyOrQuarter.cshtml");
        }
       
    }
}