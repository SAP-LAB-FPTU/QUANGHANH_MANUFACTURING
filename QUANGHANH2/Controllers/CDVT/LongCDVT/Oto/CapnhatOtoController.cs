using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.LongCDVT.Oto
{
    public class CapnhatOtoController : Controller
    {
        [Route("phong-cdvt/long/oto/cap-nhat")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/LichsuOto.cshtml");
        }
    }
}