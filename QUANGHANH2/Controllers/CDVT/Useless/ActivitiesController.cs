using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Views.CDVT
{
    public class ActivitiesController : Controller
    {
        [Route("CDVT/Activities")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Activities.cshtml");
        }
    }
}