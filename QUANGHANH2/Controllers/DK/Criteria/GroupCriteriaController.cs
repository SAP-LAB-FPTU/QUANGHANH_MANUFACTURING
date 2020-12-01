//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.DK.Criteria
//{
//    public class GroupCriteriaController : Controller
//    {
//        [Route("phong-dieu-khien/quan-ly-nhom-tieu-chi")]
//        public ActionResult Index()
//        {
//            return View("/Views/DK/Criteria/GroupCriteria.cshtml");
//        }

//        /////////////////////////////////////////GET DATA TO DATATABLE////////////////////////////////////////
//        [Route("phong-dieu-khien/quan-ly-nhom-tieu-chi/lay-du-lieu")]
//        [HttpGet]
//        public ActionResult getData()
//        {
//            try
//            {
//                //get data's table to paging
//                int start = Convert.ToInt32(Request["start"]);
//                int length = Convert.ToInt32(Request["length"]);
//                string searchValue = Request["search[value]"];
//                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//                string sortDirection = Request["order[0][dir]"];

//                var sqlGetData = @"select * from NhomTieuChi order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var exSql = db.Database.SqlQuery<NhomTieuChi>(sqlGetData).ToList();

//                    int totalrows = db.NhomTieuChis.Count();
//                    int totalrowsafterfiltering = totalrows;
//                    return Json(new { listData = exSql, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        ///////////////////////////////////////////////////ADD//////////////////////////////////////////////////////
//        [Route("phong-dieu-khien/quan-ly-nhom-tieu-chi/them-nhom-tieu-chi")]
//        [HttpPost]
//        public ActionResult Add()
//        {
//            try
//            {
//                var TenNhomTieuChi = Request["TenNhomTieuChi"];
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var data = db.NhomTieuChis.Where(x => x.TenNhomTieuChi.Equals(TenNhomTieuChi)).FirstOrDefault();
//                    if (data == null)
//                    {
//                        data = new NhomTieuChi();
//                        data.TenNhomTieuChi = TenNhomTieuChi;
//                        db.NhomTieuChis.Add(data);
//                        db.SaveChanges();
//                        return Json(new { success = true, title = "Thành công", message = "Thêm nhóm tiêu chí thành công" });
//                    }
//                    else
//                    {
//                        return Json(new { success = false, title = "Có lỗi", message = "Tên nhóm tiêu chí đã tồn tại" });
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { success = false, title = "Có lỗi", message = "Có lỗi xảy ra" });
//            }
//        }


//        //////////////////////////////////////UPDATE//////////////////////////////////////
//        //GET DATA BY MaNhomTieuChi
//        [Route("phong-dieu-khien/quan-ly-nhom-tieu-chi/lay-nhomtieuchi-bang-manhomtieuchi")]
//        [HttpPost]
//        public ActionResult getDataByMaNhomCongViec()
//        {
//            try
//            {
//                var manhomtieuchi = Convert.ToInt32(Request["manhomtieuchi"]);
//                var sqlGet = @"select * from NhomTieuChi where MaNhomTieuChi = @manhomtieuchi";
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var exSql = db.Database.SqlQuery<NhomTieuChi>(sqlGet, new SqlParameter("manhomtieuchi", manhomtieuchi)).FirstOrDefault();
//                    return Json(new { success = true, tennhomtieuchi = exSql.TenNhomTieuChi });
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        /////////////////UPDATE//////////////////
//        [Route("phong-dieu-khien/quan-ly-nhom-tieu-chi/cap-nhat-nhomtieuchi")]
//        [HttpPost]
//        public ActionResult update()
//        {
//            try
//            {
//                var manhomtieuchi = Convert.ToInt32(Request["manhomtieuchi"]);
//                var tennhomtieuchi = Request["tennhomtieuchi"];
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var nhomtieuchi = db.NhomTieuChis.Find(manhomtieuchi);
//                    if (nhomtieuchi != null)
//                    {
//                        nhomtieuchi.TenNhomTieuChi = tennhomtieuchi;
//                        db.SaveChanges();
//                        return Json(new { success = true, title = "Thành công", message = "Cập nhật nhóm tiêu chí thành công" });
//                    }
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        //////////////////DELETE////////////////////
//        [Route("phong-dieu-khien/quan-ly-nhom-tieu-chi/xoa-nhomtieuchi")]
//        [HttpPost]
//        public ActionResult delete()
//        {
//            try
//            {
//                var manhomtieuchi = Convert.ToInt32(Request["manhomtieuchi"]);
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlDelete = @"delete NhomTieuChi where MaNhomTieuChi = @manhomtieuchi";
//                    var exDelete = db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("manhomtieuchi", manhomtieuchi));
//                    db.SaveChanges();
//                    return Json(new { success = true, title = "Thành công", message = "Xóa nhóm tiêu chí thành công" });
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Lỗi", message = "Nhóm tiêu chí đang được sử dụng nên không thể xóa." });
//            }
//        }
//    }
//}