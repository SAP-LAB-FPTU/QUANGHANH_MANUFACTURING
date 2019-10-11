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
        [Route("change")]
        [HttpPost]
        public JsonResult Change(string px_value, string to_value, string date)
        {
            ViewBag.px = px_value;

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}