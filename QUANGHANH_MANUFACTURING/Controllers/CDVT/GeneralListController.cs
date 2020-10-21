using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT
{
    public class GeneralListController : Controller
    {
        [Route("phong-cdvt/ly-lich-thiet-bi")]
        public ActionResult GeneralList()
        {
            return View("/Views/CDVT/GeneralList.cshtml");
        }
    }
}