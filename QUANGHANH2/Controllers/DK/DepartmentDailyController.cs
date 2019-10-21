using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.Controllers.DK;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace QUANGHANH2.Controllers.DK
{
    public class DepartmentDailyController : Controller
    {
        // GET: DepartmentDaily
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-phan-xuong")]
        public ActionResult Index()
        {
            return View("/Views/DK/DepartmentDaily.cshtml");
        }
        //
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-phan-xuong")]
        [HttpPost]
        public ActionResult GetData()
        {
            DateTime timeEnd = Convert.ToDateTime("2019-09-10");
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            var query = "select b.*, TenTieuChi,department_name as TenPhongBan from(select MaPhongBan, MaTieuChi," +
                "SUM(Case when Ca = 1 and Ngay = @dateEnd then SanLuong else convert(float, 0) end) as [Ca1]," +
                "SUM(Case when Ca = 2 and Ngay = @dateEnd then SanLuong else convert(float, 0) end) as [Ca2]," +
                "SUM(Case when Ca = 3 and Ngay = @dateEnd  then SanLuong else convert(float, 0) end) as [Ca3]," +
                "SUM(Case when Ngay = @dateEnd  then SanLuong else convert(float, 0) end) as [TH]," +
                "SUM(SanLuong) as [LUYKE] " +
                "from(select header.HeaderID, th.MaTieuChi, th.SanLuong, header.MaPhongBan, header.Ca, header.Ngay from ThucHien_TieuChi_TheoNgay as th " +
                "inner join(select * from header_ThucHienTheoNgay where Ngay <= @dateEnd and Ngay >= @dateStart) as header " +
                "on th.HeaderID = header.HeaderID) as a " +
                "group by MaPhongBan,MaTieuChi ) as b inner join TieuChi on b.MaTieuChi = TieuChi.MaTieuChi " +
                "inner join Department on b.MaPhongBan = Department.department_id " +
                "order by MaPhongBan";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();
                var departmentName = new string[] { "Phân xưởng khai thác 1", "Phân xưởng khai thác 2", "Phân xưởng khai thác 3", "Phân xưởng khai thác 4","Phân xưởng khai thác 5",
                                                    "Phân xưởng khai thác 6", "Phân xưởng khai thác 7", "Phân xưởng khai thác 8", "Phân xưởng khai thác 9","Phân xưởng khai thác 10",
                                                    "Phân xưởng khai thác 11", "Phân xưởng đào lò 3", "Phân xưởng đào lò 5", "Phân xưởng đào lò 7","Phân xưởng đào lò 7","Phân xưởng đào lò 8",
                                                    "Công Ty Dương Huy","Phân xưởng sàng tuyển","Phân xưởng lộ thiên","Công ty Xây lắp mỏ - TKV","Liên doanh nhà thầu Công ty CP thương mại - công nghệ CT Thăng Long và Công ty tư vấn Công ty Thăng Long"};
                List<reportEntity> reports = new List<reportEntity>();
                foreach(var name in departmentName)
                {
                    reportEntity rp = new reportEntity();
                    rp.TenPhongBan = name;
                    rp.isHeader = true;
                    reports.Add(rp);
                    foreach (var report in listReport) {
                        if (report.TenPhongBan == name)
                        {
                            report.isHeader = false;
                            reports.Add(report);
                        }
                    }
                }
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(reports, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}