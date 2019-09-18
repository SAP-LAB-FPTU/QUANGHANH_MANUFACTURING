using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class ChiTietQuyetDInhController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/dieu-dong-chi-tiet")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_Quyet_dinh.cshtml");
        }
    }
}