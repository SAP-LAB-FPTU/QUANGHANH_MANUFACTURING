using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class ThuhoiController : Controller
    {
        [Route("phong-cdvt/thu-hoi")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/thuhoi.cshtml");
        }

    }
}