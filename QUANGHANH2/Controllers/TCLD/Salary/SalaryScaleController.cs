using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Salary
{
    public class SalaryScaleController : Controller
    {
        // GET: SalaryScale
        [Route("phong-tcld/quan-ly-thang-luong")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Salary/SalaryScale.cshtml");
        }
    }
}