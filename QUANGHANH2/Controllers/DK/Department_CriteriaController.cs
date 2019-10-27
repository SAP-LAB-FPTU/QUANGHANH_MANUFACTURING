using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class Department_CriteriaController : Controller
    {
        // GET: Department_Criteria
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi")]
        public ActionResult Index()
        {
            return View("/Views/DK/Department_Criteria.cshtml");
        }
    }
}