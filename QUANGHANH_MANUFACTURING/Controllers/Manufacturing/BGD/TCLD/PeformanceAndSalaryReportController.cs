using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANH_MANUFACTURING.Controllers.BGD.TCLD
{
    public class PeformanceAndSalaryReportController : Controller
    {
		// GET: /<controller>/
		[Route("ban-giam-doc/nang-suat-tien-luong")]
		public ActionResult Index()
        {
            return View("/Views/BGD/TCLD/Monthly.cshtml");
        }
    }
}
