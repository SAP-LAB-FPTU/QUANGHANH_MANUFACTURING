using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class AccidentController : Controller
    {
        [Route("CDVT/Su-co")]
        public ActionResult Accident()
        {
            return View("/Views/CDVT/Accident.cshtml");
        }
    }
}