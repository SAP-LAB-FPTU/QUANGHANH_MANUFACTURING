using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Salary
{
    public class Grade_Scale_SalaryController : Controller
    {
        // GET: Grade_Scale_Salary
        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong")]
        public ActionResult Index()
        {
            getdata_from_salarygradeandlevelgrade();
            return View("/Views/TCLD/Salary/Grade_Scale_Salary.cshtml");
        }

        ////////////////////////////////LIST////////////////////////////////////
        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong/danhsach")]
        [HttpGet]
        public ActionResult list()
        {

            List<BacLuong_MucLuong_ThangLuong_ChiTiet> listData = new List<BacLuong_MucLuong_ThangLuong_ChiTiet>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                var sqlList = @"select a.MaBacLuong_ThangLuong_MucLuong,b.MucBacLuong,c.MucThangLuong,a.MucLuong from BacLuong_ThangLuong_MucLuong as a 
                                inner join BacLuong as b on a.MaBacLuong =b.MaBacLuong 
                                inner join ThangLuong as c on a.MaThangLuong=c.MaThangLuong
                            order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                listData = db.Database.SqlQuery<BacLuong_MucLuong_ThangLuong_ChiTiet>(sqlList, JsonRequestBehavior.AllowGet).ToList();

                int totalrows = db.BacLuong_ThangLuong_MucLuong.Count();
                int totalrowsafterfiltering = totalrows;

                return Json(new { listData = listData, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
        //get data from salary grade
        public void getdata_from_salarygradeandlevelgrade()
        {
            try
            {
                List<BacLuong> listbacluongs = new List<BacLuong>();
                List<ThangLuong> listthangLuongs = new List<ThangLuong>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqllistbacluong = @"select * from BacLuong";
                    var sqllistthangluong = @"select *from ThangLuong";
                    listbacluongs = db.Database.SqlQuery<BacLuong>(sqllistbacluong).ToList<BacLuong>();
                    listthangLuongs = db.Database.SqlQuery<ThangLuong>(sqllistthangluong).ToList<ThangLuong>();
                    ViewBag.listbacluong = listbacluongs;
                    ViewBag.listsalarysacle = listthangLuongs;
                }
            }
            catch
            {

            }


        }

        ////////////////////////ADD////////////////////////////////
        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong/them-muc-luong")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {

                    int mabacluong = Convert.ToInt32(Request["mabacluong"]);
                    int mathangluong = Convert.ToInt32(Request["mathangluong"]);
                    string mucluong = Request["mucluong"].ToString();
                    if (!(Regex.Match(mucluong, @"^[0-9]*$").Success))
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Mức lương chỉ được nhập kí tự số" });
                    }
                    var validate = db.BacLuong_ThangLuong_MucLuong.Where(m => m.MaBacLuong == mabacluong).Where(m => m.MaThangLuong == mathangluong).Where(m => m.MucLuong.Equals(mucluong)).FirstOrDefault();
                    if (validate == null)
                    {
                        BacLuong_ThangLuong_MucLuong bacLuong_ThangLuong_MucLuong = new BacLuong_ThangLuong_MucLuong();
                        bacLuong_ThangLuong_MucLuong.MaThangLuong = mathangluong;
                        bacLuong_ThangLuong_MucLuong.MaBacLuong = mabacluong;
                        bacLuong_ThangLuong_MucLuong.MucLuong = mucluong;
                        db.BacLuong_ThangLuong_MucLuong.Add(bacLuong_ThangLuong_MucLuong);
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Thêm nhóm công viêc thành công." });
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Mức bậc lương hoặc mức thang lương hoặc mức lương đã có không thể trùng" });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }
        ///////////////// Get Value for edit popup /////////////////////////

        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong/lay-du-lieu-theo-mamucluong")]
        [HttpPost]
        public ActionResult GetEditSalary()
        {
            try
            {
                int mamucluong = Convert.ToInt32(Request["mamucluong"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string sql = @"select * from BacLuong_ThangLuong_MucLuong where MaBacLuong_ThangLuong_MucLuong = @mamucluong";
                    BacLuong_ThangLuong_MucLuong item = db.Database.SqlQuery<BacLuong_ThangLuong_MucLuong>(sql, new SqlParameter("mamucluong", mamucluong)).FirstOrDefault();
                    return Json(new { success = true, item = item });
                }

            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Có lỗi xảy ra." });
            }
        }
        ////////////////////////////  DELETE  ///////////////////////////////
        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong/xoa-luong")]
        [HttpPost]
        public ActionResult delete()
        {
            try
            {
                string maluong = Request["maluong"];
                int idluong = Convert.ToInt32(maluong);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var mysql = @"select * from
                                (select btm.* from BacLuong_ThangLuong_MucLuong btm 
                                join NhanVien nv on nv.MaBacLuong_ThangLuong_MucLuong = btm.MaBacLuong_ThangLuong_MucLuong where btm.MaBacLuong_ThangLuong_MucLuong = @idluong) as btm_nv
                                left outer join DieuDong_NhanVien dd_nv on dd_nv.MaBacLuong_ThangLuong_MucLuongMoi = btm_nv.MaBacLuong_ThangLuong_MucLuong or dd_nv.MaBacLuong_ThangLuong_MucLuongMoi = btm_nv.MaBacLuong_ThangLuong_MucLuong";
                    var check = db.Database.SqlQuery<BacLuong_ThangLuong_MucLuong>(mysql, new SqlParameter("idluong",idluong)).FirstOrDefault<BacLuong_ThangLuong_MucLuong>();
                    //BacLuong_ThangLuong_MucLuong delete_item = db.BacLuong_ThangLuong_MucLuong.Where(s => s.MaBacLuong_ThangLuong_MucLuong == idluong).FirstOrDefault<BacLuong_ThangLuong_MucLuong>();
                    if(check == null)
                    {
                        BacLuong_ThangLuong_MucLuong delete_item = db.BacLuong_ThangLuong_MucLuong.Where(s => s.MaBacLuong_ThangLuong_MucLuong == idluong).FirstOrDefault<BacLuong_ThangLuong_MucLuong>(); 
                        db.BacLuong_ThangLuong_MucLuong.Remove(delete_item);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Xóa thành công." });
                    }
                    else
                    {
                        return Json(new { error = true, message = "Giá trị Bậc - Thang - Mức lương đang được sử dụng tại các bảng khác." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Đã có lỗi xảy ra." });
            }
        }


        public class BacLuong_MucLuong_ThangLuong_ChiTiet : BacLuong_ThangLuong_MucLuong
        {
            public string MucBacLuong { get; set; }
            public string MucThangLuong { get; set; }

        }

        //Update
        [Route("phong-tcld/quan-ly-bacluong-thangluong-mucluong/chinhsua-muc-luong")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    int mabacluong = Convert.ToInt32(Request["mabacluong"]);
                    int mathangluong = Convert.ToInt32(Request["mathangluong"]);
                    string mucluong = Request["mucluong"].ToString();
                    //
                    if (!(Regex.Match(mucluong, @"^[0-9]*$").Success))
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Mức lương chỉ được nhập kí tự số" });
                    }
                    //CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    //mucluong = double.Parse(mucluong).ToString("#,###", cul.NumberFormat);
                    //if (mucluong.Contains("e") || mucluong.Contains("E")) return Json(new { error = true, title = "Có lỗi", message = "Mức bậc lương hoặc mức thang lương hoặc mức lương đã có không thể trùng" });
                    int mamucluong = Convert.ToInt32(Request["mamucluong"]);
                    var validate = db.BacLuong_ThangLuong_MucLuong.Where(m => m.MaThangLuong == mathangluong && m.MaBacLuong == mabacluong && m.MucLuong.Equals(mucluong) && m.MaBacLuong_ThangLuong_MucLuong != mamucluong).FirstOrDefault();
                    if (validate == null)
                    {
                        var bacLuong_ThangLuong_MucLuong = db.BacLuong_ThangLuong_MucLuong.Where(m => m.MaBacLuong_ThangLuong_MucLuong == mamucluong);
                        foreach (var item in bacLuong_ThangLuong_MucLuong)
                        {
                            item.MaThangLuong = mathangluong;
                            item.MaBacLuong = mabacluong;
                            item.MucLuong = mucluong;

                        }
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Chỉnh sửa thành công" });
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Mức bậc lương hoặc mức thang lương hoặc mức lương đã có không thể trùng" });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }


    }
}