using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class TransferController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen")]
        public ActionResult Select()
        {
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/Process.cshtml");
        }
        [Route("phong-tcld/dieu-chuyen/lich-su-dieu-chuyen")]
        public ActionResult History()
        {
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/History.cshtml");
        }
    }
}