using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class SucoOtoController : Controller
    {
        [Route("phong-cdvt/su-co-oto")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Suco/SucoOto.cshtml");
        }
    }
}