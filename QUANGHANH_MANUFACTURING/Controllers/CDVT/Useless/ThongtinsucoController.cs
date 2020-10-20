using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class ThongtinsucoController : Controller
    {
        [Route("phong-cdvt/su-coa")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/SucoThietbi.cshtml");
        }
    }
}