using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Vattu
{
    public class TonghopvattuController : Controller
    {
        [Route("phong-cdvt/tong-hop-vat-tu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/Tonghopvattu.cshtml");
        }


    }
}