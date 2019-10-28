using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;

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

        public dynamic GetData(int month, int year, string departmentID)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var sqlQuery = "select * from PhongBan_TieuChi where MaPhongBan = @departmentID and Thang = @month and Nam = @year";
                return db.Database.SqlQuery<CacTieuChi>(sqlQuery, new SqlParameter("departmentID", departmentID), new SqlParameter("month", month), new SqlParameter("year", year)).ToList();
            }
        }


        [Route("phong-dieu-khien/nhap-lieu-phong-ban-tieu-chi/lay-thong-tin")]
        public ActionResult getInformation()
        {
            try
            {
                var month = Int32.Parse(Request["month"]);
                var year = Int32.Parse(Request["year"]);
                var departmentID = Request["department"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var listAspectDepartments = (from pbtc in db.PhongBan_TieuChi
                                 .Where(x => x.MaPhongBan == departmentID)
                                                 join tieuchi in db.TieuChis on pbtc.MaTieuChi equals tieuchi.MaTieuChi
                                                 select new
                                                 {
                                                     MaTieuChi = tieuchi.MaTieuChi,
                                                     TenTieuChi = tieuchi.TenTieuChi
                                                 }).ToList();

                    var listAspect = GetData(month, year, departmentID);
                    if (listAspect.Count != 0)
                    {
                        foreach (var item in listAspect)
                        {
                            item.Identify = item.MaTieuChiNull + "-" + item.HeaderID;
                        }
                    }
                    else
                    {
                        header_KeHoachTungThang header = new header_KeHoachTungThang();
                        header.MaPhongBan = departmentID;
                        header.ThangKeHoach = month;
                        header.NamKeHoach = year;
                        header.SoNgayLamViec = 26;
                        db.header_KeHoachTungThang.Add(header);
                        db.SaveChanges();
                        var HearderID = db.header_KeHoachTungThang.Where(x => x.MaPhongBan == departmentID && x.ThangKeHoach == month && x.NamKeHoach == year).Select(x => x.HeaderID).FirstOrDefault();
                        return Json(new { data = listAspect, aspects = listAspectDepartments, totalDays = (26), headerID = HearderID }, JsonRequestBehavior.AllowGet);

                    }
                    return Json(new { data = listAspect, aspects = listAspectDepartments, totalDays = (listAspect == null ? 0 : listAspect[0].SoNgayLamViec), headerID = listAspect == null ? -1 : listAspect[0].HeaderID }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
    }

    public class CacTieuChi : TieuChi
    {
        public Nullable<int> MaTieuChiNull { get; set; }

    }
}