using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.LongCDVT.Oto
{
    public class huydongotoController : Controller
    {

        [Route("phong-cdvt/long/oto/huy-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/Huydongoto.cshtml");
        }
    }
}