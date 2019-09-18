using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Thietbi
{
    public class NhomthietbiController : Controller
    {
        [Route("phong-cdvt/thiet-bi/nhom")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Nhomthietbi.cshtml");
        }
    }
}