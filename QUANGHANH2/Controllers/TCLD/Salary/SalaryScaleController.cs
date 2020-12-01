//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using QUANGHANH2.Models;
//namespace QUANGHANH2.Controllers.TCLD.Salary
//{
//    public class SalaryScaleController : Controller
//    {

//        // GET: SalaryScale
//        private List<ThangLuong> thangluong_list;

//        [Route("phong-tcld/quan-ly-thang-luong")]
//        public ActionResult Index()
//        {

//            return View("/Views/TCLD/Salary/SalaryScale.cshtml");
//        }

//        [Route("phong-tcld/quan-ly-thang-luong/danh-sach-thang-luong")]
//        [HttpPost]
//        public ActionResult getThangluong()
//        {
//            int start = Convert.ToInt32(Request["start"]);
//            int length = Convert.ToInt32(Request["length"]);
//            string searchValue = Request["search[value]"];
//            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//            string sortDirection = Request["order[0][dir]"];

//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                try
//                {
//                    List<ThangLuong> thangluong_list = new List<ThangLuong>();
//                    var sqlList = @" select * from ThangLuong order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
//                    thangluong_list = db.Database.SqlQuery<ThangLuong>(sqlList).ToList();

//                    int totalrows = db.ThangLuongs.Count();
//                    int totalrowsafterfiltering = totalrows;
//                    return Json(new { thangluong_list = thangluong_list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering });
//                }
//                catch (Exception e)
//                {

//                }
//                return null;
//            }
//        }


//        [Route("phong-tcld/quan-ly-thang-luong/them-thang-luong")]
//        [HttpPost]
//        public object add()
//        {
//            try
//            {
//                var tenThangLuong = Request["tenthangluong"];

//                if (tenThangLuong == null || tenThangLuong == "")
//                {
//                    return Json(new { error = true, tittle = "Có lỗi xảy ra", message = "Mức Thang Lương không được trống" });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        ThangLuong tl = db.ThangLuongs.Where(x => x.MucThangLuong.Equals(tenThangLuong)).FirstOrDefault();
//                        if (tl == null)
//                        {
//                            tl = new ThangLuong();
//                            tl.MucThangLuong = tenThangLuong;
//                            db.ThangLuongs.Add(tl);
//                            db.SaveChanges();
//                            return Json(new { success = true, title = "Thành công", message = "Thêm thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, title = "Thêm thất bại", message = "Mức Thang Lương đã tồn tại." });
//                        }
//                    }
//                }
//            }
//            catch
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Thêm thất bại" });
//            }
//        }

//        [Route("phong-tcld/quan-ly-thang-luong/lay-du-lieu-theo-ma-thang-luong")]
//        [HttpPost]
//        public ActionResult getData()
//        {
//            try
//            {
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var ma_thang_luong = Request["mathangluong"];
//                    if (ma_thang_luong != null)
//                    {
//                        var query = @"Select * from ThangLuong where MaThangLuong = @mathangluong ";
//                        ThangLuong tl = db.Database.SqlQuery<ThangLuong>(query, new SqlParameter("mathangluong", ma_thang_luong)).FirstOrDefault();
//                        //ThangLuong tl = (ThangLuong)db.ThangLuongs.Where(x => x.MaThangLuong == Convert.ToInt32(ma_thang_luong)).FirstOrDefault();
//                        return Json(new { success = true, mathangluong = tl.MaThangLuong, mucthangluong = tl.MucThangLuong });
//                    }
//                    else
//                    {
//                        return Json(new { error = true, tittle = "Có lỗi", message = "Có lỗi xảy ra" });
//                    }
//                }
//            }
//            catch
//            {
//                return Json(new { error = true, tittle = "Có lỗi", message = "Có lỗi xảy ra" });
//            }
//        }
//        [Route("phong-tcld/quan-ly-cong-viec/cap-nhat-thang-luong")]
//        [HttpPost]
//        public ActionResult update()
//        {
//            try
//            {
//                var mathangluong = Request["mathangluong"];
//                var mucthangluong = Request["mucthangluong"];
//                if (mucthangluong == null || mucthangluong == "")
//                {
//                    return Json(new { error = true, tittle = "Có lỗi", message = "Có lỗi xảy ra" });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        ThangLuong tl = db.ThangLuongs.Where(x => x.MucThangLuong.Equals(mucthangluong)).FirstOrDefault();
//                        if (tl == null)
//                        {
//                            var sqlUpdate = @"update ThangLuong
//                                set MucThangLuong = @mucthangluong
//                                where MaThangLuong = @mathangluong ";
//                            db.Database.ExecuteSqlCommand(sqlUpdate, new SqlParameter("mucthangluong", mucthangluong),
//                                                                        new SqlParameter("mathangluong", mathangluong)
//                                                                        );
//                            db.SaveChanges();
//                            return Json(new { success = true, title = "Thành công", message = "Cập nhật thang lương thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, title = "Có lỗi", message = "Đã có mức thang lương." });
//                        }
//                    }

//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        [Route("phong-tcld/quan-ly-cong-viec/xoa-thang-luong")]
//        [HttpPost]
//        public ActionResult delete()
//        {
//            try
//            {
//                int mathangluong = Convert.ToInt32(Request["mathangluong"]);
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    //check data exist related to
//                    if ((BacLuong_ThangLuong_MucLuong)db.BacLuong_ThangLuong_MucLuong.Where(x => x.MaThangLuong== mathangluong).FirstOrDefault() == null
//                        && (CongViec) db.CongViecs.Where(x => x.MaThangLuong == mathangluong).FirstOrDefault() == null
//                        )
//                    {
                        
//                        //access delete by macongviec
//                        var sqlDelete = @"delete from ThangLuong where MaThangLuong = @mathangluong";
//                        db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("mathangluong", mathangluong));
//                        db.SaveChanges();
//                        return Json(new { success = true, title = "Thành công", message = "Xóa công việc thành công." });
//                    }
//                    else
//                    {
//                        return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về công việc hiện tại đang còn tồn tại trên các bảng khác." });
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }
//    }
//}

