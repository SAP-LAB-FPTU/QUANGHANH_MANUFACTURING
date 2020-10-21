using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.DK
{
    public class ReportIncidentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/bao-cao-su-co")]
        public ActionResult ReportIncident()
        {
            return View("/Views/DK/ReportIncident.cshtml");
        }
    }
}