using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Occupation
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                var sqlList = @"select a.TenNhomCongViec, a.LoaiNhomCongViec, b.TenDienCongViec from NhomCongViec a 
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
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var sqlGetData = @"select * from NhomCongViec where MaNhomCongViec = @manhomcongviec";
                    var listData = db.Database.SqlQuery<NhomCongViec_DienCongViec>(sqlGetData, new SqlParameter("manhomcongviec", manhomcongviec));
                    return Json(new { success = true ,listData = listData });
                }
            } catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        public class NhomCongViec_DienCongViec : NhomCongViec
        {
            public string TenDienCongViec { get; set; }
        }
    }
}