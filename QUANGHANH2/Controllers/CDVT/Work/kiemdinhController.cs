using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class kiemdinhController : Controller
    {
        [Route("phong-cdvt/kiem-dinh")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/kiemdinh.cshtml");
        }
    }
}