using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Report
{
    public class KiemdinhController : Controller
    {
        [Route("phong-cdvt/bao-cao/kiem-dinh")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Report/bao_cao_kiem_dinh.cshtml");
        }
        [Route("phong-cdvt/bao-cao/kiem-dinh/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/kiemdinh.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "kiemdinh.xls");
        }
    }
}