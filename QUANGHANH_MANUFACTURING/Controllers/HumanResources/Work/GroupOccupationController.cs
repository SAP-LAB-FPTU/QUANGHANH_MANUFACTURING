using QUANGHANH_MANUFACTURING.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.TCLD.Occupation
{
    public class GroupOccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-nhom-cong-viec")]
        public ActionResult view()
        {
            getData_From_DienCongViec();
            return View("/Views/TCLD/Occupation/GroupOccupation.cshtml");
        }

        ////////////////////////////////LIST////////////////////////////////////
        [Route("phong-tcld/quan-ly-nhom-cong-viec/danh-sach-nhom-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {

            List<NhomCongViec_DienCongViec> listData = new List<NhomCongViec_DienCongViec>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                var sqlList = @"select a.MaNhomCongViec, a.TenNhomCongViec, a.LoaiNhomCongViec, b.TenDienCongViec from NhomCongViec a 
                            left outer join DienCongViec b on a.MaDienCongViec = b.MaDienCongViec
                            order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                listData = db.Database.SqlQuery<NhomCongViec_DienCongViec>(sqlList).ToList();

                int totalrows = db.NhomCongViecs.Count();
                int totalrowsafterfiltering = totalrows;


                return Json(new { listData = listData, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        //GET DATA FROM DIENCONGVIEC TABLE
        public void getData_From_DienCongViec()
        {
            try
            {
                List<DienCongViec> listDienCongViec = new List<DienCongViec>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlListData_DienCongViec = @"select * from DienCongViec";
                    listDienCongViec = db.Database.SqlQuery<DienCongViec>(sqlListData_DienCongViec).ToList<DienCongViec>();
                    ViewBag.listDienCongViec = listDienCongViec;
                }
            }
            catch (Exception e)
            {

            }
        }

        //ADD
        [Route("phong-tcld/quan-ly-nhom-cong-viec/them-nhom-cong-viec")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                var tennhomcongviec = Request["tennhomcongviec"];
                var loainhomcongviec = Request["loainhomcongviec"];
                var madiencongviec = Request["madiencongviec"];

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlCheck_Dupicate = @"select TenNhomCongViec, LoaiNhomCongViec from NhomCongViec where TenNhomCongViec = @tennhomcongviec or LoaiNhomCongViec = @loainhomcongviec";
                    var check_duplicate = db.Database.SqlQuery<NhomCongViec_DienCongViec>(sqlCheck_Dupicate, new SqlParameter("tennhomcongviec", tennhomcongviec), new SqlParameter("loainhomcongviec", loainhomcongviec)).FirstOrDefault();

                    if (check_duplicate == null)
                    {
                        //madiencongviec is null
                        if (madiencongviec == "")
                        {
                            NhomCongViec ncv = new NhomCongViec();
                            ncv.TenNhomCongViec = tennhomcongviec;
                            ncv.LoaiNhomCongViec = loainhomcongviec;
                            db.NhomCongViecs.Add(ncv);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm nhóm công viêc thành công." });
                        }
                        else
                        {
                            NhomCongViec ncv = new NhomCongViec();
                            ncv.TenNhomCongViec = tennhomcongviec;
                            ncv.LoaiNhomCongViec = loainhomcongviec;
                            ncv.MaDienCongViec = Convert.ToInt32(madiencongviec);
                            db.NhomCongViecs.Add(ncv);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm nhóm công viêc thành công." });
                        }
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Tên nhóm công việc hoặc Loại nhóm công viêc đã có không thể trùng" });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //GET DATA BY MANHOMCONGVIEC
        [Route("phong-tcld/quan-ly-nhom-cong-viec/lay-du-lieu-theo-manhomcongviec")]
        [HttpPost]
        public ActionResult getData()
        {
            try
            {
                var manhomcongviec = Request["manhomcongviec"];
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlGetData = @"select a.MaNhomCongViec, a.TenNhomCongViec, a.LoaiNhomCongViec, b.MaDienCongViec, b.TenDienCongViec from NhomCongViec a left outer join DienCongViec b on a.MaDienCongViec = b.MaDienCongViec where MaNhomCongViec = @manhomcongviec";
                    var listData = db.Database.SqlQuery<NhomCongViec_DienCongViec>(sqlGetData, new SqlParameter("manhomcongviec", manhomcongviec)).FirstOrDefault();
                    return Json(new { success = true, listData = listData });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //UPDATE
        [Route("phong-tcld/quan-ly-nhom-cong-viec/cap-nhat-nhomcongviec")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                int manhomcongviec = Convert.ToInt32(Request["manhomcongviec"]);
                var tennhomcongviec = Request["tennhomcongviec"];
                var loainhomcongviec = Request["loainhomcongviec"];
                var madiencongviec = Request["madiencongviec"];

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    NhomCongViec ncv = db.NhomCongViecs.Where(x => !(x.MaNhomCongViec == manhomcongviec) && (x.TenNhomCongViec.Equals(tennhomcongviec) || x.LoaiNhomCongViec.Equals(loainhomcongviec))).FirstOrDefault();
                    if (ncv == null)
                    {
                        var sqlUpdate = db.NhomCongViecs.Find(manhomcongviec);
                        sqlUpdate.TenNhomCongViec = tennhomcongviec;
                        sqlUpdate.LoaiNhomCongViec = loainhomcongviec;
                        sqlUpdate.MaDienCongViec = (madiencongviec == "") ? null : (int?)Convert.ToInt32(madiencongviec);
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Cập nhật nhóm công việc thành công." });
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Tên nhóm công viêc hoặc Loại nhóm công việc đã có." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //DELETE
        [Route("phong-tcld/quan-ly-nhom-cong-viec/xoa-nhomcongviec")]
        [HttpPost]
        public ActionResult delete()
        {
            try
            {
                int manhomcongviec = Convert.ToInt32(Request["manhomcongviec"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (check_Exist_Data(manhomcongviec))
                    {
                        var sqlDelete = @"delete NhomCongViec where MaNhomCongViec = @manhomcongviec";
                        db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("manhomcongviec", manhomcongviec));
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Xóa nhóm công việc thành công." });
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về nhóm công việc hiện tại đang còn tồn tại ở các bản ghi khác." });
                    }

                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //CHECK EXIST DATA RELATED TO OTHER TABLE
        public Boolean check_Exist_Data(int manhomcongviec)
        {
            bool flag = false;
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlCheck = @"select a.MaNhomCongViec from NhomCongViec a right outer join CongViec_NhomCongViec b on a.MaNhomCongViec = b.MaNhomCongViec
                                where a.MaNhomCongViec = @manhomcongviec";
                    var exSql = db.Database.SqlQuery<int>(sqlCheck, new SqlParameter("manhomcongviec", manhomcongviec)).Count();
                    flag = (exSql == 0) ? true : false;
                }
            }
            catch (Exception e)
            {

            }
            return flag;
        }

        public class NhomCongViec_DienCongViec : NhomCongViec
        {
            public string TenDienCongViec { get; set; }
        }

    }
}