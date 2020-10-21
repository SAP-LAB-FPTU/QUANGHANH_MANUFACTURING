using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Oto
{
    public class NhomotoController : Controller
    {
        [Route("phong-cdvt/oto/nhom")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Nhomoto.cshtml");
        }
    }
}