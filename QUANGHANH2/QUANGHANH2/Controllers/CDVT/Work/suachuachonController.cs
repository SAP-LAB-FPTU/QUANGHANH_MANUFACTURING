using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class suachuachonController : Controller
    {
        [Route("phong-cdvt/sua-chua-chon")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/suachuachon.cshtml");
        }

    }
}