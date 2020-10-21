using System.Web.Mvc;
using QUANGHANH_MANUFACTURING.SupportClass;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANH_MANUFACTURING.Controllers.BGD
{
    public class AccidentReportController : Controller
    {
        // GET: /<controller>/
        [Auther(RightID = "005")]
        [Route("ban-giam-doc/bao-cao-su-co")]
        public ActionResult Index()
        {
            return View("/Views/BGD/ReportIncident.cshtml");
        }
    }
}
