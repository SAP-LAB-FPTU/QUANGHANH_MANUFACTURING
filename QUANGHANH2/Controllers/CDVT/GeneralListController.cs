using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class GeneralListController : Controller
    {
        [Route("phong-cdvt/ly-lich-thiet-bi")]
        public ActionResult GeneralList()
        {
            return View("/Views/CDVT/GeneralList.cshtml");
        }
    }
}