using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Oto
{
    public class NhomotoController : Controller
    {
        [Route("phong-cdvt/oto/nhom")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Nhomoto.cshtml");
        }
    }
}