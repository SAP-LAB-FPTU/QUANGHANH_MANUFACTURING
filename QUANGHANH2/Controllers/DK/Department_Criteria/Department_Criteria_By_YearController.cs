using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.Department_Criteria
{
    public class Department_Criteria_By_YearController : Controller
    {
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-nam")]
        public ActionResult Index()
        {
            return View("/Views/DK/Department_Criteria/Department_Criteria_By_Year.cshtml");
        }
    }
}