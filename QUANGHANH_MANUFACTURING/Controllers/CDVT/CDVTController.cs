using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT
{
    public class CDVTController : Controller
    {
        [Route("phong-cdvt/ly-lich-thiet-bi")]

        public ActionResult generalList ()
        {
            return View("/Views/CDVT/GeneralList.cshtml");
        }
    }
}