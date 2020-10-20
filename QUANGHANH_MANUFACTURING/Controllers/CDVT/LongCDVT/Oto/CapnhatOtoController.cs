using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.LongCDVT.Oto
{
    public class CapnhatOtoController : Controller
    {
        [Route("phong-cdvt/long/oto/cap-nhat")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/LichsuOto.cshtml");
        }
    }
}