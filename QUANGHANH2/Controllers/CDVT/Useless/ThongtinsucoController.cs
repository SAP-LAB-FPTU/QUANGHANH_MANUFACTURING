using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class ThongtinsucoController : Controller
    {
        [Route("phong-cdvt/su-coa")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/SucoThietbi.cshtml");
        }
    }
}