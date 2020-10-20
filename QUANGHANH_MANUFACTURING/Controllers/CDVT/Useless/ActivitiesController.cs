using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class ActivitiesController : Controller
    {
        [Route("CDVT/Activities")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Activities.cshtml");
        }
    }
}