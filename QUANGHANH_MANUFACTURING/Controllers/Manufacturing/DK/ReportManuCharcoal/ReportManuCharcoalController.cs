using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.DK.ReportManuCharcoal
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