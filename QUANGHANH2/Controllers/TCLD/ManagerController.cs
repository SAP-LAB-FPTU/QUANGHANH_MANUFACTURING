using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class ManagerController : Controller
    {
        [Route("phong-tcld/lich-su-thay-doi")]
        public ActionResult ModifiedHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/ModifiedHistory/ModifiedHistory.cshtml");
        }
    }
}