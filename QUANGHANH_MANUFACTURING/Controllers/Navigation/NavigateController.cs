using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.Navigation
{
    public class NavigateController : Controller
    {
        // GET: Navigate
        public ActionResult Index()
        {
            return View("/Views/Navigation/Navigate.cshtml");
        }
    }
}