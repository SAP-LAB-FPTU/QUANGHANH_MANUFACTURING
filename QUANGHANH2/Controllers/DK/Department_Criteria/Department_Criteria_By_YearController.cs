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
                    string sqlPhongBanTieuChi = "select distinct p.MaPhongBan,p.Nam,p.MaTieuChi,t.TenTieuChi from PhongBan_TieuChi_TheoNam as p,TieuChi t " +
                                                "where p.MaTieuChi = t.MaTieuChi and p.MaPhongBan = @maphongban and p.Nam = @nam";
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
                    string sqlPhongBanTieuChi = "select distinct p.MaPhongBan,p.Nam,p.MaTieuChi,t.TenTieuChi from PhongBan_TieuChi_TheoNam as p,TieuChi t " +
                                                "where p.MaTieuChi = t.MaTieuChi and p.MaPhongBan = @maphongban and p.Nam = @nam";
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
                var year = Convert.ToInt32(Request["year"]);
                var department = Request["department"];
                string sqlDelete = "delete PhongBan_TieuChi_TheoNam where MaPhongBan like N'" + department + "' and MaTieuChi = "+maTieuChi+" and Nam = '"+year+"'";
                
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    header_KeHoach_TieuChi_TheoNam header_KeHoach_TieuChi_TheoNam = db.header_KeHoach_TieuChi_TheoNam.Where(x => x.MaPhongBan.Equals(department) && x.Nam == year).FirstOrDefault<header_KeHoach_TieuChi_TheoNam>();
                    
                    string sqlDeleteKeHoach = "delete KeHoach_TieuChi_TheoNam where headerID = " + header_KeHoach_TieuChi_TheoNam.HeaderID + " and MaTieuChi = " + maTieuChi;
                    db.Database.ExecuteSqlCommand(sqlDeleteKeHoach);
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
            try
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
                    if (listCriteria.Count() > 0)
                    {
                        string sqlQuery = "insert into PhongBan_TieuChi_TheoNam (MaPhongBan,MaTieuChi,Nam) values";
                        for (int i = 0; i < listCriteria.Length; i++)
                        {
                            if (checkDupPbTc(departmentID, listCriteria[i], year) == true)
                            {
                                sqlQuery += " (N'" + departmentID + "'," + listCriteria[i] + ",'" + year + "'),";
                            }
                        }
                        sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
                        db.Database.ExecuteSqlCommand(sqlQuery);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            
            return null;
        }
        private Boolean checkDupPbTc(string department,string criteria,int year)
        {
            QUANGHANHABCEntities dbContext = new QUANGHANHABCEntities();
            PhongBan_TieuChi_TheoNam phongBan_TieuChi_TheoNam = dbContext.PhongBan_TieuChi_TheoNam.Where(x =>x.MaPhongBan.Equals(department) && x.MaTieuChi.ToString().Equals(criteria) && x.Nam == year).FirstOrDefault<PhongBan_TieuChi_TheoNam>(); ;
            
            if(phongBan_TieuChi_TheoNam == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   

    class header_tieu_chi_nam : header_KeHoach_TieuChi_TheoNam
    {
        public string TenTieuChi { get; set; }
        public int MaTieuChi { get; set; }
    }
}