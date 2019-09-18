using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class sctxController : Controller
    {
        [Route("phong-cdvt/trung-dai-tu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/sctx.cshtml");
        }
    }
}