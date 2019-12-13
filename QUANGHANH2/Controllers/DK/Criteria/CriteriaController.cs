using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.Criteria
{
    public class CriteriaController : Controller
    {
        [Route("phong-dieu-khien/quan-ly-tieu-chi")]
        public ActionResult Index()
        {
            return View("/Views/DK/Criteria/Criteria.cshtml");
        }
    }
}