using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class LylichController : Controller
    {
        [Route("phong-cdvt/thiet-bi")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Details.cshtml");
        }
    }
}