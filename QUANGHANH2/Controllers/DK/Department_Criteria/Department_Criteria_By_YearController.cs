using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using QUANGHANH2.Models;
namespace QUANGHANH2.Controllers.DK.Department_Criteria
{
    public class Department_Criteria_By_YearController : Controller
    {
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-nam")]
        public ActionResult Index()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var query = " select * from Department WHERE department_type =@departmentType order by department_name";
                List<Department> listDepartments = db.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
                ViewBag.listDepartments = listDepartments;
                return View("/Views/DK/Department_Criteria/Department_Criteria_By_Year.cshtml");
            }
        }
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-nam/lay-thong-tin")]
        public ActionResult getInformation()
        {
            try
            {
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                List<header_tieu_chi_nam> list = new List<header_tieu_chi_nam>();
                List<TieuChi> listTieuChi = new List<TieuChi>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var query = " select * from Department WHERE department_type =@departmentType order by department_name";
                    List<Department> listDepartments = db.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
                    ViewBag.listDepartments = listDepartments;
                    //
                    string sqlPhongBanTieuChi = "select distinct h.HeaderID,h.MaPhongBan,h.Nam,h.GhiChu,k.MaTieuChi,t.TenTieuChi from header_KeHoach_TieuChi_TheoNam as h,KeHoach_TieuChi_TheoNam as k,TieuChi t " +
                                                "where h.HeaderID = k.HeaderID and k.MaTieuChi = t.MaTieuChi and h.MaPhongBan = @maphongban and h.Nam = @nam";
                    string sqlTieuChi = "select * from TieuChi";
                    list = db.Database.SqlQuery<header_tieu_chi_nam>(sqlPhongBanTieuChi, new SqlParameter("maphongban", departmentID),
                        new SqlParameter("nam", year)).ToList<header_tieu_chi_nam>();
                    listTieuChi = db.Database.SqlQuery<TieuChi>(sqlTieuChi).ToList<TieuChi>();
                    return Json(new { listPhongBanTieuChi = list, listTieuChi = listTieuChi });
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        ////////////////////// GET BEFORE INFORMATION //////////////////////
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-nam/lay-thong-tin-nam-truoc")]
        public ActionResult getBeforeInformation()
        {
            try
            {
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                List<header_tieu_chi_nam> list = new List<header_tieu_chi_nam>();
                List<TieuChi> listTieuChi = new List<TieuChi>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var query = " select * from Department WHERE department_type =@departmentType order by department_name";
                    List<Department> listDepartments = db.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
                    ViewBag.listDepartments = listDepartments;
                    //
                    string sqlPhongBanTieuChi = "select distinct h.HeaderID,h.MaPhongBan,h.Nam,h.GhiChu,k.MaTieuChi,t.TenTieuChi from header_KeHoach_TieuChi_TheoNam as h,KeHoach_TieuChi_TheoNam as k,TieuChi t " +
                                                "where h.HeaderID = k.HeaderID and k.MaTieuChi = t.MaTieuChi and h.MaPhongBan = @maphongban and h.Nam = @nam";
                    string sqlTieuChi = "select * from TieuChi";
                    list = db.Database.SqlQuery<header_tieu_chi_nam>(sqlPhongBanTieuChi, new SqlParameter("maphongban", departmentID),
                        new SqlParameter("nam", year-1)).ToList<header_tieu_chi_nam>();
                    listTieuChi = db.Database.SqlQuery<TieuChi>(sqlTieuChi).ToList<TieuChi>();
                    return Json(new { listPhongBanTieuChi = list, listTieuChi = listTieuChi });
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        ///////////////////////////////DELETE///////////////////////////////
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-nam/xoa-tieu-chi-cua-phong-ban")]
        public ActionResult DeleteInformation()
        {
            try
            {
                var maTieuChi = Request["maTieuChi"];
                var headerID = Request["headerID"];
                string sqlDelete = "delete KeHoach_TieuChi_TheoNam where HeaderID = " + headerID + " and MaTieuChi = "+maTieuChi;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Database.ExecuteSqlCommand(sqlDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        //////////////////////////////////INSERT////////////////////////////////////
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi-theo-nam/cap-nhat-thong-tin")]
        public ActionResult InsertInformation()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                header_KeHoach_TieuChi_TheoNam header_KeHoach_TieuChi_TheoNam = db.header_KeHoach_TieuChi_TheoNam.Where(x => x.MaPhongBan.Equals(departmentID) && x.Nam == year).FirstOrDefault<header_KeHoach_TieuChi_TheoNam>();
                int headerID;
                if (header_KeHoach_TieuChi_TheoNam == null)
                {
                    header_KeHoach_TieuChi_TheoNam header_KeHoach_TieuChi_TheoNamAdd = new header_KeHoach_TieuChi_TheoNam();
                    header_KeHoach_TieuChi_TheoNamAdd.MaPhongBan = departmentID;
                    header_KeHoach_TieuChi_TheoNamAdd.Nam = year;
                    db.header_KeHoach_TieuChi_TheoNam.Add(header_KeHoach_TieuChi_TheoNamAdd);
                    db.SaveChanges();
                    headerID = header_KeHoach_TieuChi_TheoNamAdd.HeaderID;

                }
                else
                {
                    headerID = header_KeHoach_TieuChi_TheoNam.HeaderID;
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                var currentSelectedValue = Request["currentSelectedValue"];
                string[] listCriteria = js.Deserialize<string[]>(currentSelectedValue);
                KeHoach_TieuChi_TheoNam keHoach_TieuChi_TheoNam = new KeHoach_TieuChi_TheoNam();
                if(listCriteria.Count() > 0)
                {
                    string sqlQuery = "insert into KeHoach_TieuChi_TheoNam (HeaderID,MaTieuChi,SanLuongKeHoach,ThoiGianNhapCuoiCung) values";
                    for (int i = 0; i < listCriteria.Length; i++)
                    {
                        sqlQuery += " (" + headerID + "," + listCriteria[i] + "," + 0 + ",'" + DateTime.Now + "'),";
                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
                    db.Database.ExecuteSqlCommand(sqlQuery);
                }
                
                db.SaveChanges();
            }
            return null;
        }
    }


    class header_tieu_chi_nam : header_KeHoach_TieuChi_TheoNam
    {
        public string TenTieuChi { get; set; }
        public int MaTieuChi { get; set; }
    }
}