using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class BaoCaoDemoController : Controller
    {
        // GET: BaoCaoDemo
        [Route("phong-dieu-khien/bao-cao-demo")]
        public ActionResult Index()
        {
            return View("/Views/DK/BaoCaoDemo.cshtml");
        }
    }
}