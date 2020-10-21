using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class MaintenanceController : Controller
    {
        [Route("CDVT/Bd")]
        public ActionResult Maintenance()
        {
            return View("/Views/CDVT/Maintenance.cshtml");
        }
    }
}