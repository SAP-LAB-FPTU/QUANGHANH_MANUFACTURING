using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class ThanhliController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/thanh-li")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Quyet_dinh_thanh_li.cshtml");
        }
    }
}