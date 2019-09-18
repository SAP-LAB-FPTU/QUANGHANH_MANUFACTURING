using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class BaoduongchonController : Controller
    {
        [Route("phong-cdvt/bao-duong-chon")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/baoduong_va_chon.cshtml");
        }
    }
}