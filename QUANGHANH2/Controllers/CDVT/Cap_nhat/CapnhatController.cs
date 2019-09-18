using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Cap_nhat
{
    public class CapnhatController : Controller
    {

        [Route("phong-cdvt/cap-nhat/quyet-dinh")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Cap_nhat/DSQD.cshtml");
        }
    }
}