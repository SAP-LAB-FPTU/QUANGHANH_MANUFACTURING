using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.BGD.CDVT
{
    public class BGDMaintainReportController : Controller
    {
        [Route("ban-giam-doc/bao-cao-bao-duong")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/MaintainReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-bao-duong/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/baoduong.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "baoduong.xls");
        }
    }
}