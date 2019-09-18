using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class ThanhliController : Controller
    {
        [Route("phong-cdvt/thanh-li")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/thanhli.cshtml");
        }
    }
}