using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Cap_nhat
{
    public class CapnhathoatdongController : Controller
    {
        [Route("phong-cdvt/cap-nhat/hoat-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Cap_nhat/Capnhathoatdong.cshtml");
        }
    }
}