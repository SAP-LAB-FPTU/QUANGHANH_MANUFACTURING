using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Salary
{
    public class SalaryGradeController : Controller
    {
        // GET: SalaryGrade
        [Route("phong-tcld/quan-ly-bac-luong")]
        public ActionResult Index()
        {

            return View("/Views/TCLD/Salary/SalaryGrade.cshtml");
        }


        [Route("phong-tcld/quan-ly-bac-luong/danh-sach-bac-luong")]
        [HttpPost]
        public ActionResult getList()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                //db.Configuration.LazyLoadingEnabled = true;
                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                try
                {
                    var query = @"select * from BacLuong order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                    var listBacLuong = db.Database.SqlQuery<BacLuong>(query).ToList();

                    int totalrows = db.BacLuongs.Count();
                    int totalrowsafterfiltering = totalrows;

                    //listBacLuong = listBacLuong.OrderBy(sortColumnName + " " + sortDirection).ToList<BacLuong>();
                    //listBacLuong = listBacLuong.Skip(start).Take(length).ToList<BacLuong>();

                    return Json(new { list = listBacLuong, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }


        //-------------------  Add  --------------------------
        [Route("phong-tcld/quan-ly-bac-luong/them-bac-luong")]
        [HttpPost]

        public ActionResult add()
        {
            try
            {
                var mucBacLuong = Request["MucBacLuong"];
                if (mucBacLuong == null || mucBacLuong == "")
                {
                    return Json(new { error = true, message = "Mức bậc lương không được trống !" });
                }
                else
                {
                    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                    {
                        BacLuong bl = db.BacLuongs.Where(x => x.MucBacLuong.Equals(mucBacLuong)).FirstOrDefault();
                        if (bl == null)
                        {
                            bl = new BacLuong();
                            bl.MucBacLuong = mucBacLuong;
                            db.BacLuongs.Add(bl);
                            db.SaveChanges();
                            return Json(new { success = true, message = "Thêm thành công !" });
                        }
                        else
                        {
                            return Json(new { error = true, message = "Đã có bậc lương này !" });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Có lỗi xảy ra !" });
            }
        }


        // --------------   Edit    --------------------------

        //  get mabacluong by mabacluong
        [Route("phong-tcld/quan-ly-bac-luong/lay-mucbacluong-theo-mabacluong")]
        [HttpPost]

        public ActionResult getMucBacLuong()
        {
            try
            {
                var maBacLuong = Request["MaBacLuong"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var query = @"Select * From BacLuong Where MaBacLuong = @mbl";
                    var BacLuong = db.Database.SqlQuery<BacLuong>(query, new SqlParameter("mbl", maBacLuong)).FirstOrDefault();
                    return Json(new { success = true, MucBacLuong = BacLuong.MucBacLuong });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Có lỗi xảy ra !" });
            }
        }

        // Update
        [Route("phong-tcld/quan-ly-bac-luong/sua-bac-luong")]
        [HttpPost]
        public ActionResult edit()
        {
            try
            {
                var MaBacLuong = Request["maBacLuong"];
                var MucBacLuong = Request["mucBacLuong"];
                if (MucBacLuong == null || MucBacLuong == "")
                {
                    return Json(new { error = true, message = "Mức bậc lương không được để trống !" });
                }
                else
                {
                    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                    {
                        BacLuong bl = db.BacLuongs.Where(x => x.MucBacLuong.Equals(MucBacLuong)).FirstOrDefault();
                        if (bl == null)
                        {
                            var query = @"Update BacLuong
                                         Set MucBacLuong = @mucBL
                                        Where MaBacLuong = @maBL";
                            db.Database.ExecuteSqlCommand(query, new SqlParameter("mucBL", MucBacLuong)
                                                                    , new SqlParameter("maBL", MaBacLuong));
                            db.SaveChanges();
                            return Json(new { success = true, message = "Sửa thành công !" });
                        }
                        else
                        {
                            return Json(new { error = true, message = "Mức bậc lương đã có !" });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Có lỗi xảy ra !" });
            }
        }



        //   Delete
        [Route("phong-tcld/quan-ly-bac-luong/xoa-bac-luong")]
        [HttpPost]

        public ActionResult delete()
        {
            try
            {
                int MaBacLuong = Convert.ToInt32(Request["MaBacLuong"]);
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    BacLuong_ThangLuong_MucLuong blm = db.BacLuong_ThangLuong_MucLuong.Where(x => x.MaBacLuong == MaBacLuong).FirstOrDefault();
                    
                    //var query = @"Select * From BacLuong_ThangLuong_MucLuong Where MaBacLuong = @mbl";
                    //var blm = db.Database.SqlQuery<BacLuong_ThangLuong_MucLuong>(query, new SqlParameter("mbl", MaBacLuong)).FirstOrDefault();
                    
                    if(blm != null)
                    {
                        return Json(new { error = true, message = "Bậc lương này vẫn đang được sử dụng !" });
                    }
                    var sql = @"Delete From BacLuong
                                Where MaBacLuong = @mbl";
                    db.Database.ExecuteSqlCommand(sql, new SqlParameter("mbl", MaBacLuong));
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xóa thành công !" });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Có lỗi xảy ra !" });
            }
        }
    }
}