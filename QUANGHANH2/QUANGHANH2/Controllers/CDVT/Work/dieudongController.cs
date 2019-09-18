using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class dieudongController : Controller
    {
        [Route("phong-cdvt/dieu-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/dieu_dong.cshtml");
        }
    }
}