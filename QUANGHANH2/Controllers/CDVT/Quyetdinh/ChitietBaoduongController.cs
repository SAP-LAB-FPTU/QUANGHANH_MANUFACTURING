using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class ChitietBaoduongController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/bao-duong-chi-tiet")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_bao_duong.cshtml");
        }
    }
}