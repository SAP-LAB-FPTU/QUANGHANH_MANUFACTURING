using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.BGD.CDVT
{
    public class BGDRepairReportController : Controller
    {
        [Route("ban-giam-doc/bao-cao-sua-chua")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/RepairReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-sua-chua/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/suachua.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "suachua.xls");
        }
    }
}