using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.DK
{
    public class DKController : Controller
    {
        [Auther(RightID ="004")]
        [Route("phong-dieu-khien")]
        public ActionResult Index()
        {
            return View("/Views/DK/Index.cshtml");
        }
    }
}