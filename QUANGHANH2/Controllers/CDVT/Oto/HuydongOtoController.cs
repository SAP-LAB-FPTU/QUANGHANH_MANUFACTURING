using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Oto
{
    public class HuydongOtoController : Controller
    {
        
        [Route("phong-cdvt/oto/huy-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Huydongoto.cshtml");
        }
    }
}