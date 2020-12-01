//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Newtonsoft.Json;
//using System.Data.SqlClient;
//using System.Web.Script.Serialization;

//namespace QUANGHANH2.Controllers.DK
//{
//    public class Department_Criteria_By_MonthController : Controller
//    {
//        // GET: Department_Criteria
//        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-thang")]
//        public ActionResult Index()
//        {
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                var query = " select * from Department WHERE department_type in (@departmentType_1, @departmentType_2) order by department_name";
//                List<Department> listDepartments = db.Database.SqlQuery<Department>(query,
//                    new SqlParameter("departmentType_1", "Phân xưởng sản xuất chính"),
//                    new SqlParameter("departmentType_2", "Đơn vị sản xuất thuê ngoài")).ToList<Department>();
//                ViewBag.listDepartments = listDepartments;
//                return View("/Views/DK/Department_Criteria/Department_Criteria_By_Month.cshtml");
//            }
//        }

//        /////////////////////////////////LIST/////////////////////////////////////
//        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-thang/lay-thong-tin")]
//        public ActionResult getInformation()
//        {
//            try
//            {
//                var month = Int32.Parse(Request["month"]);
//                var year = Int32.Parse(Request["year"]);
//                var departmentID = Request["department"];
//                List<TieuChiABC> list = new List<TieuChiABC>();
//                List<TieuChi> listTieuChi = new List<TieuChi>();
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var query = " select * from Department WHERE department_type = @departmentType order by department_name";
//                    List<Department> listDepartments = db.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
//                    ViewBag.listDepartments = listDepartments;
//                    //
//                    string sqlPhongBanTieuChi = "select a.MaPhongBan,a.MaTieuChi,b.TenTieuChi from PhongBan_TieuChi a left join TieuChi b on a.MaTieuChi = b.MaTieuChi\n" +
//                                                "where MaPhongBan = @maphongban and Thang = @thang and Nam = @nam";
                    
//                    list = db.Database.SqlQuery<TieuChiABC>(sqlPhongBanTieuChi, new SqlParameter("maphongban", departmentID),
//                        new SqlParameter("thang", month),
//                        new SqlParameter("nam", year)).ToList<TieuChiABC>();

//                    var status = "Month";
//                    var message = "Dữ liệu đang được lấy ra theo tiêu chí của phân xưởng bạn đang chọn.";

//                    //If list PhongBan_TieuChi have no record -> take data from PhongBan_TieuChi_TheoNam
//                    if (list.Count == 0)
//                    {
//                        sqlPhongBanTieuChi = @"select a.MaPhongBan,a.MaTieuChi,b.TenTieuChi from PhongBan_TieuChi_TheoNam a left join TieuChi b on a.MaTieuChi = b.MaTieuChi
//                                                where MaPhongBan = @maphongban and Nam = @nam";
//                        list = db.Database.SqlQuery<TieuChiABC>(sqlPhongBanTieuChi, new SqlParameter("maphongban", departmentID),
//                            new SqlParameter("nam", year)).ToList<TieuChiABC>();

//                        status = "Year";
//                        message = "Hiện tại đang không có dữ liệu tiêu chí cho phân xưởng bạn đang chọn. Dữ liệu hiển thị dưới sẽ được lấy theo tiêu chí dành cho phân xưởng theo năm.";
//                    }
//                    //get list TieuChi
//                    string sqlTieuChi = "select * from TieuChi";
//                    listTieuChi = db.Database.SqlQuery<TieuChi>(sqlTieuChi).ToList<TieuChi>();
//                    return Json(new { listPhongBanTieuChi = list , listTieuChi = listTieuChi, status = status, message = message});
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }
//        [HttpPost]
//        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-thang/lay-thong-tin-thang-truoc")]
        
//        public ActionResult getBeforeInformation()
//        {
//            try
//            {
//                var month = Int32.Parse(Request["month"]);
//                var year = Int32.Parse(Request["year"]);
//                var departmentID = Request["department"];
//                if(month == 1)
//                {
//                    month = 12;
//                    year = year - 1;
//                }
//                else
//                {
//                    month = month - 1;
//                }
//                List<TieuChiABC> list = new List<TieuChiABC>();
//                List<TieuChi> listTieuChi = new List<TieuChi>();
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var query = " select * from Department WHERE department_type =@departmentType order by department_name";
//                    List<Department> listDepartments = db.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
//                    ViewBag.listDepartments = listDepartments;
//                    //
//                    string sqlPhongBanTieuChi = "select a.MaPhongBan,a.MaTieuChi,b.TenTieuChi from PhongBan_TieuChi a left join TieuChi b on a.MaTieuChi = b.MaTieuChi\n" +
//                        "where MaPhongBan = @maphongban and Thang = @thang and Nam = @nam ";
//                    string sqlTieuChi = "select * from TieuChi";
//                    list = db.Database.SqlQuery<TieuChiABC>(sqlPhongBanTieuChi, new SqlParameter("maphongban", departmentID),
//                        new SqlParameter("thang", month),
//                        new SqlParameter("nam", year)).ToList<TieuChiABC>();
//                    listTieuChi = db.Database.SqlQuery<TieuChi>(sqlTieuChi).ToList<TieuChi>();

//                    var status = "BeforeMonth";
//                    var message = "Hiện tại đang không có dữ liệu tiêu chí cho phân xưởng bạn đang chọn. Dữ liệu hiển thị dưới sẽ được lấy theo tiêu chí dành cho phân xưởng theo tháng trước.";
//                    return Json(new { listPhongBanTieuChi = list, listTieuChi = listTieuChi , status = status, message = message});
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        //////////////////////////////////INSERT////////////////////////////////////
//        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-thang/cap-nhat-thong-tin")]
//        public ActionResult InsertInformation()
//        {
//            try
//            {
//                var month = Int32.Parse(Request["month"]);
//                var year = Int32.Parse(Request["year"]);
//                var departmentID = Request["department"];
//                var currentSelectedValue = Request["currentSelectedValue"];
//                JavaScriptSerializer js = new JavaScriptSerializer();
//                string[] listCriteria = js.Deserialize<string[]>(currentSelectedValue);
//                if (listCriteria.Length != 0)
//                {
//                    string sqlQuery = "insert into PhongBan_TieuChi(MaPhongBan, MaTieuChi, Thang, Nam) values";
//                    for (int i = 0; i < listCriteria.Length; i++)
//                    {
//                        sqlQuery += " (N'" + departmentID + "'," + listCriteria[i] + "," + month + "," + year + "),";
//                    }
//                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
//                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                    {
//                        db.Database.ExecuteSqlCommand(sqlQuery);
//                        db.SaveChanges();
//                    }
//                } else
//                {
//                    return null;
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }

//        ///////////////////////////////DELETE///////////////////////////////
//        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-thang/xoa-tieu-chi-cua-phong-ban")]
//        public ActionResult DeleteInformation()
//        {
//            try
//            {
//                var month = Int32.Parse(Request["month"]);
//                var year = Int32.Parse(Request["year"]);
//                var departmentID = Request["department"];
//                var criteria = Request["criteria"];
//                string sqlDelete = "Delete PhongBan_TieuChi where MaTieuChi = "+ criteria +" and MaPhongBan = N'"+ departmentID +"' and Thang = "+ month +" and Nam = "+ year;
//                using (QuangHanhManufacturingEntities db =  new QuangHanhManufacturingEntities())
//                {
//                    KeHoachTungThang keHoachTungThang = db.KeHoachTungThangs.Where(x => x.ThangKeHoach == month && x.NamKeHoach == year).FirstOrDefault<KeHoachTungThang>();
//                    header_KeHoachTungThang header_KeHoachTungThang = null;
//                    if (keHoachTungThang != null)
//                    {
//                        header_KeHoachTungThang = db.header_KeHoachTungThang.Where(x => x.ThangID == keHoachTungThang.ThangID && x.MaPhongBan.Equals(departmentID)).FirstOrDefault<header_KeHoachTungThang>();
//                    }
//                    if (header_KeHoachTungThang != null)
//                    {
//                        string sqlDeleteKHTCT = "Delete KeHoach_TieuChi_TheoThang  where headerID = " + header_KeHoachTungThang.HeaderID + " and MaTieuChi = " + criteria;
//                        db.Database.ExecuteSqlCommand(sqlDeleteKHTCT);
//                        KeHoach_TieuChi_TheoThang keHoach_TieuChi_TheoThang = db.KeHoach_TieuChi_TheoThang.Where(x => x.HeaderID == header_KeHoachTungThang.HeaderID).FirstOrDefault<KeHoach_TieuChi_TheoThang>();

//                        if(keHoach_TieuChi_TheoThang == null)
//                        {
//                            if (keHoachTungThang != null)
//                            {
//                                string sqlDeleteHKHTT = "Delete header_KeHoachTungThang  where MaPhongBan = N'" + departmentID + "' and ThangID = " + keHoachTungThang.ThangID;
//                                db.Database.ExecuteSqlCommand(sqlDeleteHKHTT);
//                                header_KeHoachTungThang header_KeHoachTungThangCheck = db.header_KeHoachTungThang.Where(x => x.ThangID == keHoachTungThang.ThangID).FirstOrDefault<header_KeHoachTungThang>();
//                                if(header_KeHoachTungThangCheck == null)
//                                {
//                                    string sqlDeleteKHTT = "Delete KeHoachTungThang where ThangKeHoach = " + month + " and NamKeHoach = " + year;
//                                    db.Database.ExecuteSqlCommand(sqlDeleteKHTT);
//                                }
//                            }
//                        }
//                    }

//                    db.Database.ExecuteSqlCommand(sqlDelete);
//                    db.SaveChanges();
//                }
//            }
//            catch (Exception e)
//            {

//            }
//            return null;
//        }
//    }

//    public class TieuChiABC : TieuChi
//    {
//        public string MaPhongBan { get; set; }
//        //public int MaTieuChi { get; set; }
//        //public string TenTieuChi { get; set; }
//    }
//}