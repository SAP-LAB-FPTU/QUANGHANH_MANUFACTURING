using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Useless
{
    public class ConsumptionController : Controller
    {
        [Route("CDVT/Tieuthu")]
        public ActionResult Consumption()
        {
            return View("/Views/CDVT/Consumption.cshtml");
        }
    }
}