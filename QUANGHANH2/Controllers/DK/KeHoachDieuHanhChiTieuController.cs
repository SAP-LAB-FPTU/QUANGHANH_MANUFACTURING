using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class KeHoachDieuHanhChiTieuController : Controller
    {
        // GET: KeHoachDieuHanhChiTieu
        [Route("phong-dieu-khien/ke-hoach-dieu-hanh-chi-tieu")]
        public ActionResult Index()
        {
            ViewBag.thisyear = DateTime.Now.Year;
            return View("/Views/DK/KeHoachDieuHanhChiTieu.cshtml");
        }
        [Route("phong-dieu-khien/ke-hoach-dieu-hanh-chi-tieu/lay-du-lieu")]
        public ActionResult GetData(int year)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}