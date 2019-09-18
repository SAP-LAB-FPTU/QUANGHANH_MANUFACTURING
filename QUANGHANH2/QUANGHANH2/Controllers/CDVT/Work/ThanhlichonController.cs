using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class ThanhlichonController : Controller
    {
        [Route("phong-cdvt/thanh-li-chon")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/thanhli_va_chon.cshtml");
        }
    }
}