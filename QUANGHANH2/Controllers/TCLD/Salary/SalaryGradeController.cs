using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Salary
{
    public class SalaryGradeController : Controller
    {
        // GET: SalaryGrade
        [Route("phong-tcld/quan-ly-bac-luong")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Salary/SalaryGrade.cshtml");
        }
    }
}