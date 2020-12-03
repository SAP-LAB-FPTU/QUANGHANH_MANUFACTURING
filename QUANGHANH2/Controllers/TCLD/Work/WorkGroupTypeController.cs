//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.TCLD
//{
//    public class WorkGroupTypeController : Controller
//    {
//        [Route("phong-tcld/quan-ly-dien-cong-viec")]
//        public ActionResult index()
//        {
//            return View("/Views/TCLD/Occupation/SideOccupation.cshtml");
//        }

//        //////////////////////////////LIST///////////////////////////////
//        [Route("phong-tcld/quan-ly-dien-cong-viec/danh-sach-dien-cong-viec")]
//        [HttpGet]
//        public ActionResult listSideOccupation()
//        {
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                db.Configuration.LazyLoadingEnabled = true;
//                try
//                {
//                    var sqlList = (from x in db.DienCongViecs
//                                   select new { MaDienCongViec = x.MaDienCongViec, TenDienCongViec = x.TenDienCongViec }).ToList();
//                    return Json(new { sqlList = sqlList, success = true }, JsonRequestBehavior.AllowGet);
//                }
//                catch (Exception e)
//                {

//                }
//            }
//            return null;
//        }

//        //////////////////////////////ADD////////////////////////////////
//        [Route("phong-tcld/quan-ly-dien-cong-viec/them-dien-cong-viec")]
//        [HttpPost]
//        public ActionResult add()
//        {
//            try
//            {
//                var TenDienCongViec = Request["TenDienCongViec"];
//                if (TenDienCongViec == null || TenDienCongViec == "")
//                {
//                    return Json(new { error = true, message = "Tên diện công việc không thể để trống." });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        DienCongViec dcv = db.DienCongViecs.Where(x => x.TenDienCongViec.Equals(TenDienCongViec)).FirstOrDefault();
//                        if (dcv == null)
//                        {
//                            dcv = new DienCongViec();
//                            dcv.TenDienCongViec = TenDienCongViec;
//                            db.DienCongViecs.Add(dcv);
//                            db.SaveChanges();
//                            return Json(new { success = true, message = "Thao tác thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, message = "Đã có tên diện công việc." });
//                        }
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, message = "Có lỗi xảy ra." });
//            }
//        }

//        ///////////////////////////////GET TenDienCongViec By MaDienCongViec/////////////////////////////////
//        [Route("phong-tcld/quan-ly-dien-cong-viec/lay-tendiencongviec-theo-madiencongviec")]
//        [HttpPost]
//        public ActionResult getData()
//        {
//            try
//            {
//                var MaDienCongViec = Request["MaDienCongViec"];
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlGet = @"select * from DienCongViec where MaDienCongViec = @madiencongviec";
//                    var TenDienCongViec = db.Database.SqlQuery<DienCongViec>(sqlGet, new SqlParameter("madiencongviec", MaDienCongViec)).FirstOrDefault();
//                    return Json(new { success = true, TenDienCongViec = TenDienCongViec.TenDienCongViec });
//                };
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, message = "Có lỗi xảy ra." });
//            }
//        }

//        /////////////////////////////////////////////UPDATE///////////////////////////////////////////////
//        [Route("phong-tcld/quan-ly-dien-cong-viec/cap-nhat-tendiencongviec")]
//        [HttpPost]
//        public ActionResult update()
//        {
//            try
//            {
//                var MaDienCongViec = Request["MaDienCongViec"];
//                var TenDienCongViec = Request["TenDienCongViec"];
//                if (TenDienCongViec == null || TenDienCongViec == "")
//                {
//                    return Json(new { error = true, message = "Tên diện công việc không thể để trống." });
//                }
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlUpdate = @"update DienCongViec 
//                                      set TenDienCongViec = @tendiencongviec 
//                                      where MaDienCongViec = @madiencongviec";
//                    db.Database.ExecuteSqlCommand(sqlUpdate, new SqlParameter("tendiencongviec", TenDienCongViec), new SqlParameter("madiencongviec", MaDienCongViec));
//                    db.SaveChanges();
//                    return Json(new { success = true, message = "Cập nhật thành công." });
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, message = "Có lỗi xảy ra." });
//            }
//        }

//        //////////////////////////////////DELETE/////////////////////////////////////////
//        [Route("phong-tcld/quan-ly-dien-cong-viec/xoa-diencongviec")]
//        [HttpPost]
//        public ActionResult delete()
//        {
//            try
//            {
//                var MaDienCongViec = Request["MaDienCongViec"];
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlDelete = @"delete DienCongViec where MaDienCongViec = @madiencongviec";
//                    db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("madiencongviec", MaDienCongViec));
//                    db.SaveChanges();
//                    return Json(new { success = true, message = "Xóa thành công." });
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, message = "Có lỗi xảy ra." });
//            }
//        }
//    }
//}