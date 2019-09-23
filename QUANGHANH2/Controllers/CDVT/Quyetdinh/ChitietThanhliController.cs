using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class ChitietThanhliController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/thanh-li-chi-tiet")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_thanh_li.cshtml");
        }
    }
}