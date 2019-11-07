using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Occupation
{
    public class GroupOccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-nhom-cong-viec")]
        public ActionResult View()
        {
            return View("/Views/TCLD/Occupation/GroupOccupation.cshtml");
        }

        ////////////////////////////////List////////////////////////////////////
        [Route("phong-tcld/quan-ly-nhom-cong-viec/danh-sach-nhom-cong-viec")]
        [HttpGet]
        public ActionResult List()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var sqlList = (from x in db.NhomCongViecs
                               select new { LoaiNhomCongViec = x.LoaiNhomCongViec, TenNhomCongViec = x.TenNhomCongViec }).ToList();
                return Json(new { sqlList = sqlList, success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}