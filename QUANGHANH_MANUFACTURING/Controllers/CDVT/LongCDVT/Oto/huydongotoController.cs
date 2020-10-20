using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.LongCDVT.Oto
{
    public class huydongotoController : Controller
    {

        [Route("phong-cdvt/long/oto/huy-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/Huydongoto.cshtml");
        }
    }
}