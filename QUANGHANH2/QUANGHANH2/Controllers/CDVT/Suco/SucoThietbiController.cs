using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Suco
{
    public class SucoThietbiController : Controller
    {
        [Route("phong-cdvt/su-co/a")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Suco/SucoThietbi.cshtml");
        }
    }
}