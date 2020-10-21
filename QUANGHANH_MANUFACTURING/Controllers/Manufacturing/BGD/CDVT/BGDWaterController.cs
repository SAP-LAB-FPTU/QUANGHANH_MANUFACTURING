using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.BGD.CDVT
{
    public class BGDWaterController : Controller
    {
        [Route("ban-giam-doc/bao-cao-thoat-nuoc")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/WaterReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-thoat-nuoc/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/thoatnuoc.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "thoatnuoc.xls");
        }
    }
}