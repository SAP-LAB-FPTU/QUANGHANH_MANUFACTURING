using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Occupation
{
    public class SideOccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-dien-cong-viec")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Occupation/SideOccupation.cshtml");
        }

        //////////////////////////////LIST///////////////////////////////
        [Route("phong-tcld/quan-ly-dien-cong-viec/danh-sach-dien-cong-viec")]
        [HttpGet]
        public ActionResult ListSideOccupation()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var sqlList = (from x in db.DienCongViecs
                               select new { MaDienCongViec = x.MaDienCongViec, DienCongViec = x.DienCongViec1 });
                return Json(new { sqlList = sqlList, success = true }, JsonRequestBehavior.AllowGet);   
            }
        }
    }
}