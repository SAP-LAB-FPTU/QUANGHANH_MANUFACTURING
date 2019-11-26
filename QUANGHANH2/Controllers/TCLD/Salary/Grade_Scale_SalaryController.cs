using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Salary
{
    public class Grade_Scale_SalaryController : Controller
    {
        // GET: Grade_Scale_Salary
        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Salary/Grade_Scale_Salary.cshtml");
        }
    }
}