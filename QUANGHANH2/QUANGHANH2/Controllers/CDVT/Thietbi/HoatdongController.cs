using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Thietbi
{
    public class HoatdongController : Controller
    {
        [Route("phong-cdvt/huy-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Hoat_dong.cshtml");
        }

    }
}