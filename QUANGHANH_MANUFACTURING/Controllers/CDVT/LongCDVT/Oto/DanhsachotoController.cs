using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.LongCDVT.Oto
{
    public class DanhsachotoController : Controller
    {
        [Route("phong-cdvt/long/oto/ly-lich")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/Danhsachoto.cshtml");
        }
    }
}