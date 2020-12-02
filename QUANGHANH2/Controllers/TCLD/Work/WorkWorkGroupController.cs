//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.TCLD
//{
//    public class WorkWorkGroupController : Controller
//    {
//        // GET: Occupation_GroupOccupation
//        [Route("phong-tcld/cong-viec-nhom-cong-viec")]
//        public ActionResult Index()
//        {
//            getData_CongViec();
//            return View("/Views/TCLD/Occupation/Occupation_GroupOccupation.cshtml");
//        }

//        /////////////////////////////GET DATA FROM CONGVIEC/////////////////////////////
//        public void getData_CongViec()
//        {
//            try
//            {
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    //get data from CongViec
//                    var sqlGetData_CongViec = @"select * from CongViec";
//                    var listCongViec = db.Database.SqlQuery<CongViec>(sqlGetData_CongViec).ToList();

//                    //get data from NhomCongViec
//                    var sqlGetData_NhomCongViec = @"select * from NhomCongViec";
//                    var listNhomCongViec = db.Database.SqlQuery<NhomCongViec>(sqlGetData_NhomCongViec).ToList();

//                    //add 2 lists to Viewbag
//                    ViewBag.listCongViec = listCongViec;
//                    ViewBag.listNhomCongViec = listNhomCongViec;
//                }
//            }
//            catch (Exception e)
//            {

//            }
//        }

//        ////////////////////////////////////LIST////////////////////////////////////////
//        [Route("phong-tcld/cong-viec-nhom-cong-viec/danh-sach-cong-viec-nhom-cong-viec")]
//        [HttpGet]
//        public ActionResult list()
//        {
//            try
//            {
//                List<CongViec_NhomCong_ChiTiet> listCongViec_NhomCongViec = new List<CongViec_NhomCong_ChiTiet>();
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    //get data's table to paging
//                    int start = Convert.ToInt32(Request["start"]);
//                    int length = Convert.ToInt32(Request["length"]);
//                    string searchValue = Request["search[value]"];
//                    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//                    string sortDirection = Request["order[0][dir]"];

//                    var sqlList = @"select ncv_cv.*, c.TenNhomCongViec from (select a.*, b.TenCongViec  from CongViec_NhomCongViec a 
//                                left outer join CongViec b on a.MaCongViec = b.MaCongViec) as ncv_cv
//                                left outer join NhomCongViec c on ncv_cv.MaNhomCongViec = c.MaNhomCongViec 
//                                order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
//                    listCongViec_NhomCongViec = db.Database.SqlQuery<CongViec_NhomCong_ChiTiet>(sqlList).ToList();

//                    int totalrows = db.CongViec_NhomCongViec.Count();
//                    int totalrowsafterfiltering = totalrows;

//                    return Json(new { listCongViec_NhomCongViec = listCongViec_NhomCongViec, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        //////////////////////////////////////ADD///////////////////////////////////////
//        [Route("phong-tcld/cong-viec-nhom-cong-viec/them-cong-viec-nhom-cong-viec")]
//        [HttpPost]
//        public ActionResult add()
//        {
//            try
//            {
//                var macongviec = Request["macongviec"];
//                var manhomcongviec = Request["manhomcongviec"];

//                if (macongviec == "" && manhomcongviec == "")
//                {
//                    return Json(new { error = true, title = "Có lỗi", message = "Công việc và nhóm công việc không thể đồng thời để trống." });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        //parse to int
//                        int? mcv = (macongviec == "") ? null : (int?)Convert.ToInt32(macongviec);
//                        int? mncv = (manhomcongviec == "") ? null : (int?)Convert.ToInt32(manhomcongviec);

//                        CongViec_NhomCongViec cv_ncv = db.CongViec_NhomCongViec.Where(x => x.MaCongViec == mcv && x.MaNhomCongViec == mncv).FirstOrDefault();
//                        if (cv_ncv == null)
//                        {
//                            cv_ncv = new CongViec_NhomCongViec()
//                            {
//                                MaCongViec = mcv,
//                                MaNhomCongViec = mncv
//                            };
//                            db.CongViec_NhomCongViec.Add(cv_ncv);
//                            db.SaveChanges();
//                            return Json(new { success = true, title = "Thành công", message = "Thêm công viêc - nhóm công việc thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, title = "Có lỗi", message = "Công việc ứng với Nhóm công việc chọn đã tồn tại." });
//                        }
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        /////////////////////////////////////////////////EDIT//////////////////////////////////////////////////
//        /////////GET DATA BY MACONGVIEC_NHOMCONGVIEC
//        [Route("phong-tcld/cong-viec-nhom-cong-viec/lay-du-lieu-theo-macongviec-nhomcongviec")]
//        [HttpGet]
//        public ActionResult getDataBy_MaCongViec_NhomCongViec()
//        {
//            try
//            {
//                var macongviec_nhomcongviec = Convert.ToInt32(Request["macongviec_nhomcongviec"]);
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlGetData = @"select ncv_cv.*, c.TenNhomCongViec from (select a.*, b.TenCongViec  from CongViec_NhomCongViec a 
//                                left outer join CongViec b on a.MaCongViec = b.MaCongViec) as ncv_cv
//                                left outer join NhomCongViec c on ncv_cv.MaNhomCongViec = c.MaNhomCongViec where ncv_cv.MaCongViec_NhomCongViec = @macongviec_nhomcongviec";
//                    var listCongViec_NhomCongViec_by_MaCongViec_NhomCongViec = db.Database.SqlQuery<CongViec_NhomCong_ChiTiet>(sqlGetData, new SqlParameter("macongviec_nhomcongviec", macongviec_nhomcongviec)).FirstOrDefault();
//                    return Json(new { listCongViec_NhomCongViec_by_MaCongViec_NhomCongViec = listCongViec_NhomCongViec_by_MaCongViec_NhomCongViec }, JsonRequestBehavior.AllowGet);
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        ////////////UPDATE
//        [Route("phong-tcld/cong-viec-nhom-cong-viec/cap-nhat-cong-viec-nhom-cong-viec")]
//        [HttpPost]
//        public ActionResult update()
//        {
//            try
//            {
//                var macongviec_nhomcongviec = Request["macongviec_nhomcongviec"];
//                var macongviec = Request["macongviec"];
//                var manhomcongviec = Request["manhomcongviec"];

//                if (macongviec == "" && manhomcongviec == "")
//                {
//                    return Json(new { error = true, title = "Có lỗi", message = "Công việc và nhóm công việc không thể đồng thời để trống." });
//                }
//                else
//                {
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        int? mcv_ncv = Convert.ToInt32(macongviec_nhomcongviec);
//                        int? mcv = (macongviec == "") ? null : (int?)Convert.ToInt32(macongviec);
//                        int? mncv = (manhomcongviec == "") ? null : (int?)Convert.ToInt32(manhomcongviec);

//                        CongViec_NhomCongViec list_cv_ncv = db.CongViec_NhomCongViec.Where(x => !(x.MaCongViec_NhomCongViec == mcv_ncv) && (x.MaCongViec == mcv && x.MaNhomCongViec == mncv)).FirstOrDefault();
//                        if (list_cv_ncv == null)
//                        {
//                            var cv_mcv = db.CongViec_NhomCongViec.Find(mcv_ncv);
//                            cv_mcv.MaCongViec = mcv;
//                            cv_mcv.MaNhomCongViec = mncv;
//                            db.SaveChanges();
//                            return Json(new { success = true, title = "Thành công", message = "Cập nhật công việc - nhóm công việc thành công." });
//                        }
//                        else
//                        {
//                            return Json(new { error = true, title = "Có lỗi", message = "Công việc và Nhóm công việc đã tồn tại." });
//                        }
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        /////////////////////////////////////////////////DELETE/////////////////////////////////////////////////////
//        [Route("phong-tcld/cong-viec-nhom-cong-viec/xoa-cong-viec-nhom-cong-viec")]
//        [HttpPost]
//        public ActionResult delete()
//        {
//            try
//            {
//                int macongviec_nhomcongviec = Convert.ToInt32(Request["macongviec_nhomcongviec"]);
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var sqlDelete = @"delete CongViec_NhomCongViec where MaCongViec_NhomCongViec = @macongviec_nhomcongviec";
//                    var exSql = db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("macongviec_nhomcongviec", macongviec_nhomcongviec));
//                    db.SaveChanges();
//                    return Json(new { success = true, title = "Thành công", message = "Xóa công việc - nhóm công việc thành công." });
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }

//        public class CongViec_NhomCong_ChiTiet : CongViec_NhomCongViec
//        {
//            public string TenCongViec { get; set; }
//            public string TenNhomCongViec { get; set; }
//        }
//    }
//}