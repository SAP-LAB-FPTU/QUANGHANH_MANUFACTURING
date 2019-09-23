using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class danhsachtrungdaituController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/trung-dai-tu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/SCTX.cshtml");
        }
    }
}