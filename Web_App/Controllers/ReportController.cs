using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
        //
        public ActionResult TimeKeeping()
        {
            return View();
        }
    }
}
