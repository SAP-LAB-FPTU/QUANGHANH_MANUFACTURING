using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Report
{
    public class MaintainReportController : Controller
    {
        [Route("phong-cdvt/bao-cao/bao-duong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Report/MaintainReport.cshtml");
        }
        [Route("phong-cdvt/bao-cao/bao-duong/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/baoduong.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "baoduong.xls");
        }
    }
}