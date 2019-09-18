using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class DieudongchonController : Controller
    {
        [Route("phong-cdvt/dieu-dong-chon")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/dieu_dong_va_chon.cshtml");
        }

    }
}