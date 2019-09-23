using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    [Route("phong-cdvt/quyet-dinh/sua-chua-thuong-xuyen-chi-tiet")]
    public class chitietsctxController : Controller
    {
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_SCTX.cshtml");
        }
    }
}