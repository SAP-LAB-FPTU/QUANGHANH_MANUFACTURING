using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class DashController : Controller
    {
        [Route("phong-cdvt")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Dashboard.cshtml");
        }
    }
}