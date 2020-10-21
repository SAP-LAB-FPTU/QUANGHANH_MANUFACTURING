using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Oto
{
    public class DanhsachController : Controller
    {
        [Route("phong-cdvt/oto/ly-lich")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Danhsachoto.cshtml");
        }
    }
}