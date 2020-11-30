using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.Navigation
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            return View("/Views/Navigation/Navigation.cshtml");
        }
    }
}