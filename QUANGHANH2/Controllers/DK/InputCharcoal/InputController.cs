using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.InputCharcoal
{
    public class InputController : Controller
    {
        // GET: Input
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/nhap-lieu-san-xuat")]
        public ActionResult InputCharcoal()
        {
            return View("/Views/DK/InputCharcoal/InputCharcoal.cshtml");
        }

        [Route("phong-dieu-khien/nhap-lieu-ke-hoach")]
        public ActionResult InputPlan()
        {
            return View("/Views/DK/InputCharcoal/InputPlan.cshtml");
        }
    }
}