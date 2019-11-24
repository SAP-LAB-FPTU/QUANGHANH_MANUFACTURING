using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class OccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-cong-viec")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Occupation/Occupation.cshtml");
        }

        ////////////////////////////LIST/////////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/danh-sach-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = true;

                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                try
                {
                    List<CongViec> congviec_list = new List<CongViec>();
                    var sqlList = "select * from CongViec order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                    congviec_list = db.Database.SqlQuery<CongViec>(sqlList).ToList();
                    int totalrows = db.CongViecs.Count();

                    int totalrowsafterfiltering = totalrows;
                    return Json(new { congviec_list = congviec_list, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }

        ///////////////////////ADD///////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/them-cong-viec")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                var tencongviec = Request["tencongviec"];
                var thangluong = Request["thangluong"];
                var phucap = Request["phucap"];

                if (tencongviec == null || tencongviec == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Tên công việc không thể để trống." });
                }
                else if (!((Regex.Match(phucap, @"(^[0-9]*$)")).Success))
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Phụ cấp chỉ chứa số." });
                }
                else
                {
                    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                    {
                        CongViec cv = db.CongViecs.Where(x => x.TenCongViec.Equals(tencongviec)).FirstOrDefault();
                        if (cv == null)
                        {
                            cv = new CongViec();
                            cv.TenCongViec = tencongviec;
                            cv.ThangLuong = thangluong;
                            cv.PhuCap = float.Parse(phucap);
                            db.CongViecs.Add(cv);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Đã có tên công việc." });
                        }
                    }
                }
            }
            catch
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        ///////////////////////////////////EDIT///////////////////////////////////
        ////////GET DATA BY MACONGVIEC////////
        [Route("phong-tcld/quan-ly-cong-viec/lay-du-lieu-theo-macongviec")]
        [HttpPost]
        public ActionResult getData()
        {
            try
            {
                var macongviec = Request["macongviec"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var sqlGetData = @"select * from CongViec where MaCongViec = @macongviec";
                    var congviec = db.Database.SqlQuery<CongViec>(sqlGetData, new SqlParameter("macongviec", macongviec)).FirstOrDefault();
                    return Json(new { success = true, tencongviec = congviec.TenCongViec, thangluong = congviec.ThangLuong, phucap = congviec.PhuCap });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }
        /////////////UPDATE//////////////
        [Route("phong-tcld/quan-ly-cong-viec/cap-nhat-cong-viec")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                var macongviec = Request["macongviec"];
                var tencongviec = Request["tencongviec"];
                var thangluong = Request["thangluong"];
                var phucap = Request["phucap"];

                if (tencongviec == null || tencongviec == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Tên công việc không thể để trống." });
                }
                else if (!((Regex.Match(phucap, @"(^[0-9]*$)")).Success))
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Phụ cấp chỉ chứa số." });
                }
                else
                {
                    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                    {
                        CongViec cv = db.CongViecs.Where(x => x.TenCongViec.Equals(tencongviec)).FirstOrDefault();
                        if (cv == null)
                        {
                            var sqlUpdate = @"update CongViec
                                            set TenCongViec = @tencongviec,
                                                ThangLuong = @thangluong,
                                                PhuCap = @phucap
                                            where MaCongViec = @macongviec";
                            db.Database.ExecuteSqlCommand(sqlUpdate, new SqlParameter("tencongviec", tencongviec),
                                                                        new SqlParameter("thangluong", thangluong),
                                                                        new SqlParameter("phucap", phucap),
                                                                        new SqlParameter("macongviec", macongviec));
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Cập nhật công việc thành công." });
                        } else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Đã có tên công việc." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        /////////////////////////////////////////DELETE///////////////////////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/xoa-cong-viec")]
        [HttpPost]
        public ActionResult delete()
        {
            try {
                int macongviec = Convert.ToInt32(Request["macongviec"]);
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    //check data exist related to
                    if (check_exist_data(macongviec))
                    {
                        //access delete by macongviec
                        var sqlDelete = @"delete CongViec where MaCongViec = @macongviec";
                        db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("macongviec", macongviec));
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Xóa công việc thành công." });
                    } else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về công việc hiện tại đang còn tồn tại trên các bảng khác." });
                    }
                }
            } catch(Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        ///////////////////CHECK DATA EXIST RELATED TO//////////////////////
        public Boolean check_exist_data(int macongviec)
        {
            bool flag = false;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var sqlCheckExistData = @"select c.MaCongViec from 
                                        (select a.MaCongViec from NhanVien a left outer join CongViec b on a.MaCongViec = b.MaCongViec) as c
                                        join (select d.MaCongViec from CongViec_NhomCongViec d left outer join CongViec e on d.MaCongViec = e.MaCongViec) as f 
                                        on c.MaCongViec = f.MaCongViec
                                        where c.MaCongViec = @macongviec";
                var exSql = db.Database.SqlQuery<int>(sqlCheckExistData, new SqlParameter("macongviec", macongviec)).Count();
                if (exSql == 0)
                {
                    flag = true;
                } else
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
