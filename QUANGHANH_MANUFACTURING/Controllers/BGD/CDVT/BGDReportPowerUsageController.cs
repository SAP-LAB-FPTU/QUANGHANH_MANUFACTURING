using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.BGD.CDVT
{
    public class BGDReportPowerUsageController : Controller
    {
        [Route("ban-giam-doc/bao-cao-dien-nang")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/QuarterPowerUsage.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-dien-nang/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/diennang.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "diennang.xls");
        }
    }
}