using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class AccreditationController : Controller
    {
        [Route("CDVT/Car/Accreditation")]
        public ActionResult Accreditation()
        {
            return View("/Views/CDVT/Car/Accreditation.cshtml");
        }
    }
}