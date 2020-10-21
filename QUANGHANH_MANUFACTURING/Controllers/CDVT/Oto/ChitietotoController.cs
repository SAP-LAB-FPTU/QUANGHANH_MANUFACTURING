using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Oto
{
    public class ChitietotoController : Controller
    {
        [Route("phong-cdvt/oto/chi-tiet")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Chi-tiet-o-to.cshtml");
        }
    }
}