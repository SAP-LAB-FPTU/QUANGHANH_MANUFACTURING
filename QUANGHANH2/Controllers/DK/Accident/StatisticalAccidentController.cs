using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.Accident
{
    public class StatisticalAccidentController : Controller
    {
        [Route("phong-dieu-khien/thong-ke-tai-nan")]
        public ActionResult Index()
        {
            return View("/Views/DK/Accident/StatisticalAccident.cshtml");
        }
    }
}