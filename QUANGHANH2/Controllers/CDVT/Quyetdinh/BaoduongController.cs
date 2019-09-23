using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class BaoduongController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/bao-duong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Quyet_dinh_bao_duong.cshtml");
        }
    }
}