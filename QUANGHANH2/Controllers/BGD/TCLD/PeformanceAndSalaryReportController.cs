using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.BGD.TCLD
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
