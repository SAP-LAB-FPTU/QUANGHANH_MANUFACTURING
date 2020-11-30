using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.LongCDVT.Oto
{
    public class ChitietOtoController : Controller
    {
        [Route("phong-cdvt/long/oto/chi-tiet")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/Chi-tiet-o-to.cshtml");
        }
    }
}