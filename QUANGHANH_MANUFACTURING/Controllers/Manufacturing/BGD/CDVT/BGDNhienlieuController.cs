using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.BGD.CDVT
{
    public class BGDNhienlieuController : Controller
    {
        [Route("ban-giam-doc/bao-cao-nhien-lieu")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/FuelConsumption.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-nhien-lieu/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/nhienlieu.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "nhienlieu.xls");
        }
    }
}