using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.DK
{
    public class Department_CriteriaController : Controller
    {
        // GET: Department_Criteria
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi")]
        public ActionResult Index()
        {
            return View("/Views/DK/Department_Criteria.cshtml");
        }

        /////////////////////////////////LIST/////////////////////////////////////
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi/lay-thong-tin")]
        public ActionResult getInformation()
        {
            try
            {
                var month = Int32.Parse(Request["month"]);
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                List<TieuChiABC> list = new List<TieuChiABC>();
                List<TieuChi> listTieuChi = new List<TieuChi>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string sqlPhongBanTieuChi = "select a.MaPhongBan,a.MaTieuChi,b.TenTieuChi from PhongBan_TieuChi a left join TieuChi b on a.MaTieuChi = b.MaTieuChi\n" +
                        "where MaPhongBan = @maphongban and Thang = @thang and Nam = @nam ";
                    string sqlTieuChi = "select * from TieuChi";
                    list = db.Database.SqlQuery<TieuChiABC>(sqlPhongBanTieuChi, new SqlParameter("maphongban", departmentID),
                        new SqlParameter("thang", month),
                        new SqlParameter("nam", year)).ToList<TieuChiABC>();
                    listTieuChi = db.Database.SqlQuery<TieuChi>(sqlTieuChi).ToList<TieuChi>();
                    return Json(new { listPhongBanTieuChi = list , listTieuChi = listTieuChi});
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        //////////////////////////////////INSERT////////////////////////////////////
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi/cap-nhat-thong-tin")]
        public ActionResult InsertInformation()
        {
            try
            {
                var month = Int32.Parse(Request["month"]);
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                var currentSelectedValue = Request["currentSelectedValue"];
                JavaScriptSerializer js = new JavaScriptSerializer();
                string[] listCriteria = js.Deserialize<string[]>(currentSelectedValue);
                string sqlQuery = "insert into PhongBan_TieuChi(MaPhongBan, MaTieuChi, Thang, Nam) values";
                for(int i = 0; i < listCriteria.Length; i++)
                {
                    sqlQuery += " ('" + departmentID + "'," + listCriteria[i] + "," + month + "," + year + "),";
                }
                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
                using(QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Database.ExecuteSqlCommand(sqlQuery);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        ///////////////////////////////DELETE///////////////////////////////
        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi/xoa-tieu-chi-cua-phong-ban")]
        public ActionResult DeleteInformation()
        {
            try
            {
                var month = Int32.Parse(Request["month"]);
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                var criteria = Request["crỉteria"];
                string sqlDelete = "Delete PhongBan_TieuChi where MaTieuChi = "+ criteria +" and MaPhongBan = '"+ departmentID +"' and Thang = "+ month +" and Nam = "+ year +"";
                using (QUANGHANHABCEntities db =  new QUANGHANHABCEntities())
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
    }
    public class TieuChiABC : TieuChi
    {
        public string MaPhongBan { get; set; }
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
    }
}