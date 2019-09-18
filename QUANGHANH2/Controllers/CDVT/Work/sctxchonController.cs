using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class sctxchonController : Controller
    {
        [Route("phong-cdvt/trung-dai-tu-chon")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/sctx_va_chon.cshtml");
        }
    }
}