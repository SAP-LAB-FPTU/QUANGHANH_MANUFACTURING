using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.History
{
    public class LichsuOtoController : Controller
    {
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/History/LichsuOto.cshtml");
        }
    }
}