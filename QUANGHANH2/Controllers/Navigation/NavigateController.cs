using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.Navigation
{
    public class NavigateController : Controller
    {
        // GET: Navigate
        public ActionResult Index()
        {
            return View("/Views/Navigation/Navigate.cshtml");
        }
    }
}