using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Oto
{
    public class DanhsachController : Controller
    {
        [Route("phong-cdvt/oto/ly-lich")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Danhsachoto.cshtml");
        }
    }
}