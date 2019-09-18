using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Vattu
{
    public class XincapvattuController : Controller
    {
        [Route("phong-cdvt/xin-cap-vat-tu-sctx")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/Xincapvattu.cshtml");
        }
    }
}