using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.LongCDVT.Oto
{
    public class ChitietOtoController : Controller
    {
        [Route("phong-cdvt/long/oto/chi-tiet")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/Chi-tiet-o-to.cshtml");
        }
    }
}