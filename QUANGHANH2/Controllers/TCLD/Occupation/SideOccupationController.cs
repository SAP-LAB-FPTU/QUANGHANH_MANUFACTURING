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
                db.Configuration.LazyLoadingEnabled = true;
                try
                {
                    var sqlList = (from x in db.DienCongViecs
                                   select new { MaDienCongViec = x.MaDienCongViec, TenDienCongViec = x.TenDienCongViec }).ToList();
                    return Json(new { sqlList = sqlList, success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {

                }
            }
            return null;
        }

        //////////////////////////////ADD////////////////////////////////
        [Route("phong-tcld/quan-ly-dien-cong-viec/them-dien-cong-viec")]
        [HttpPost]
        public ActionResult Add()
        {
            try
            {
                var tenDienCongViec = Request["TenDienCongViec"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    DienCongViec dcv = db.DienCongViecs.Where(x => x.TenDienCongViec.Equals(tenDienCongViec)).FirstOrDefault();
                    if (dcv == null)
                    {
                        dcv = new DienCongViec();
                        dcv.TenDienCongViec = tenDienCongViec;
                        db.DienCongViecs.Add(dcv);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Thao tác thành công." });
                    } else
                    {
                        return Json(new { success = false, message = "Đã có tên diện công việc." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra." });
            }
        }
    }
}