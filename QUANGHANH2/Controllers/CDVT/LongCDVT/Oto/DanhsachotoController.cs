using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.LongCDVT.Oto
{
    public class DanhsachotoController : Controller
    {
        [Route("phong-cdvt/long/oto/ly-lich")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/LongCDVT/Car/Danhsachoto.cshtml");
        }
    }
}