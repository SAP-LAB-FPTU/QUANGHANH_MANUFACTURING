//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.TCLD
//{
//    public class OccupationController : Controller
//    {
//        [Route("phong-tcld/quan-ly-cong-viec")]
//        public ActionResult Index()
//        {
//            //get data from ThangLuong table to fill to select > option
//            getData_ThangLuong();
//            return View("/Views/TCLD/Occupation/Occupation.cshtml");
//        }

//        ////////////////////////////LIST/////////////////////////////
//        [Route("phong-tcld/quan-ly-cong-viec/danh-sach-cong-viec")]
//        [HttpGet]
//        public ActionResult list()
//        {
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                db.Configuration.LazyLoadingEnabled = true;

//                //get data's table to paging
//                int start = Convert.ToInt32(Request["start"]);
//                int length = Convert.ToInt32(Request["length"]);
//                string searchValue = Request["search[value]"];
//                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//                string sortDirection = Request["order[0][dir]"];

//                try
//                {
//                    List<CongViec_ThangLuong> congviec_thangluong_list = new List<CongViec_ThangLuong>();
//                    var sqlList = @"select a.MaCongViec, a.TenCongViec, a.PhuCap, b.MucThangLuong from CongViec a left outer join ThangLuong b on a.MaThangLuong = b.MaThangLuong order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
//                    congviec_thangluong_list = db.Database.SqlQuery<CongViec_ThangLuong>(sqlList).ToList();

//                    int totalrows = db.CongViecs.Count();
//                    int totalrowsafterfiltering = totalrows;
//                    return Json(new { congviec_thangluong_list = congviec_thangluong_list, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
//                }
//                catch (Exception e)
//                {

//                }
//                return null;
//            }
//        }

//        ///////////////////////ADD///////////////////////////
//        [Route("phong-tcld/quan-ly-cong-viec/them-cong-viec")]
//        [HttpPost]
//        public ActionResult add()
//        {
//            try
//            {
//                var tencongviec = Request["tencongviec"];
//                var phucap = Request["phucap"];
//                var mathangluong = Request["mathangluong"];

//                if (tencongviec == null || tencongviec == "")
//                {
//                    return Json(new { error = true, title = "Có lỗi", message = "Tên công việc thể để trống." });
//                }
//                else if (!((Regex.Match(phucap, @"(^[0-9]*$)")).Success))
//                {
//                    return Json(new { error = true, title = "Có lỗi", message = "Phụ cấp chỉ chứa số." });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        CongViec cv = db.CongViecs.Where(x => x.TenCongViec.Equals(tencongviec)).FirstOrDefault();
//                        if (cv == null)
//                        {
//                            cv = new CongViec();
//                            cv.TenCongViec = tencongviec;
//                            cv.MaThangLuong = (mathangluong == "") ? null : (int?)Convert.ToInt32(mathangluong);
//                            cv.PhuCap = (phucap == "") ? null : (double?)Convert.ToDouble(phucap);
//                            db.CongViecs.Add(cv);
//                            db.SaveChanges();
//                            return Json(new { success = true, title = "Thành công", message = "Thêm thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, title = "Có lỗi", message = "Đã có tên công việc." });
//                        }
//                    }
//                }
//            }
//            catch
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        //////////////////////////////////////GET DATA FROM THANGLUONG///////////////////////////////////////
//        public void getData_ThangLuong()
//        {
//            try
//            {
//                List<ThangLuong> listThangLuong = new List<ThangLuong>();
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlGetData_ThangLuong = @"select * from ThangLuong";
//                    listThangLuong = db.Database.SqlQuery<ThangLuong>(sqlGetData_ThangLuong).ToList();
//                    ViewBag.listThangLuong = listThangLuong;
//                }
//            }
//            catch (Exception e)
//            {

//            }
//        }


//        ///////////////////////////////////EDIT///////////////////////////////////
//        ////////GET DATA BY MACONGVIEC////////
//        [Route("phong-tcld/quan-ly-cong-viec/lay-du-lieu-theo-macongviec")]
//        [HttpPost]
//        public ActionResult getData()
//        {
//            try
//            {
//                int macongviec = Convert.ToInt32(Request["macongviec"]);
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlGetData = @"select a.MaCongViec ,a.TenCongViec, a.PhuCap, a.MaThangLuong from CongViec a left outer join ThangLuong b on a.MaThangLuong = b.MaThangLuong where a.MaCongViec = @macongviec";
//                    var listCongViec_ThangLuong = db.Database.SqlQuery<CongViec_ThangLuong>(sqlGetData, new SqlParameter("macongviec", macongviec)).FirstOrDefault();
//                    return Json(new { success = true, listCongViec_ThangLuong = listCongViec_ThangLuong });
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }
//        /////////////UPDATE//////////////
//        [Route("phong-tcld/quan-ly-cong-viec/cap-nhat-cong-viec")]
//        [HttpPost]
//        public ActionResult update()
//        {
//            try
//            {
//                int macongviec = Convert.ToInt32(Request["macongviec"]);
//                var tencongviec = Request["tencongviec"];
//                var mathangluong = Request["mathangluong"];
//                var phucap = Request["phucap"];

//                if (tencongviec == null || tencongviec == "")
//                {
//                    return Json(new { error = true, title = "Có lỗi", message = "Tên công việc không thể để trống." });
//                }
//                else if (!((Regex.Match(phucap, @"(^[0-9]*$)")).Success))
//                {
//                    return Json(new { error = true, title = "Có lỗi", message = "Phụ cấp chỉ chứa số." });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        CongViec cv = db.CongViecs.Where(y => !y.MaCongViec.Equals(macongviec) && y.TenCongViec.Equals(tencongviec)).FirstOrDefault();
//                        if (cv == null)
//                        {
//                            var sqlUpdate = db.CongViecs.Find(macongviec);
//                            sqlUpdate.TenCongViec = tencongviec;
//                            sqlUpdate.PhuCap = (phucap == "") ? null : (double?)Convert.ToDouble(phucap);
//                            sqlUpdate.MaThangLuong = (mathangluong == "") ? null : (int?)Convert.ToInt32(mathangluong);
//                            db.SaveChanges();
//                            return Json(new { success = true, title = "Thành công", message = "Cập nhật công việc thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, title = "Có lỗi", message = "Đã có tên công việc." });
//                        }
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        /////////////////////////////////////////DELETE///////////////////////////////////////////
//        [Route("phong-tcld/quan-ly-cong-viec/xoa-cong-viec")]
//        [HttpPost]
//        public ActionResult delete()
//        {
//            try
//            {
//                int macongviec = Convert.ToInt32(Request["macongviec"]);
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    //check data exist related to
//                    if (check_exist_data(macongviec))
//                    {
//                        //access delete by macongviec
//                        var sqlDelete = @"delete CongViec where MaCongViec = @macongviec";
//                        db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("macongviec", macongviec));
//                        db.SaveChanges();
//                        return Json(new { success = true, title = "Thành công", message = "Xóa công việc thành công." });
//                    }
//                    else
//                    {
//                        return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về công việc hiện tại đang còn tồn tại trên các bản ghi khác." });
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        ///////////////////CHECK DATA EXIST RELATED TO//////////////////////
//        public Boolean check_exist_data(int macongviec)
//        {
//            bool flag = false;
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                var sqlCheckExistData = @"select c.MaCongViec from 
//                                        (select a.MaCongViec from NhanVien a left outer join CongViec b on a.MaCongViec = b.MaCongViec) as c
//                                        join (select d.MaCongViec from CongViec_NhomCongViec d left outer join CongViec e on d.MaCongViec = e.MaCongViec) as f 
//                                        on c.MaCongViec = f.MaCongViec
//                                        where c.MaCongViec = @macongviec";
//                var exSql = db.Database.SqlQuery<int>(sqlCheckExistData, new SqlParameter("macongviec", macongviec)).Count();
//                flag = (exSql == 0) ? true : false;
//            }
//            return flag;
//        }

//        public class CongViec_ThangLuong : CongViec
//        {
//            public string MucThangLuong { get; set; }
//        }
//    }
//}
