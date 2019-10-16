using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class SanLuongReportController : Controller
    {
        // GET: SanLuongReport
        [HttpGet]
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty")]
        public ActionResult Index()
        {
            return View("/Views/DK/SanLuongReport.cshtml");
        }

        [HttpPost]
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty")]
        public ActionResult getReport()
        {
            DateTime timeEnd = Convert.ToDateTime("2019-09-10");
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            //
            var query = "select *,CONVERT(float,0)  as [CHENHLECH],CONVERT(float,0)  as [PERCENTAGE], " +
                "0 as [KHDC], 0 as [percentDC],0 as [SUM],0 as [perday], 0 as [BQKHDC],0 as [VATLIEUCHONG],0 AS[DIENTICHDAO],0 as [BC],0 AS[CT] " +
                "from(select MaTieuChi, TenTieuChi, " +
                "Sum(case when ca = 1 and Ngay = @dateEnd then SanLuong else 0  end )as [CA1], " +
                "Sum(case when ca = 2 and Ngay = @dateEnd then SanLuong else 0  end )as [CA2], " +
                "Sum(case when ca = 3 and Ngay = @dateEnd then SanLuong else 0  end )as [CA3], " +
                "Sum(case when Ngay = @dateEnd then SanLuong else 0  end )as [TH], " +
                //"Sum(case when Ngay = @dateEnd then KeHoach else 0  end )as [KH], " +
                "SUM(SanLuong) as [LUYKE] " +
                "from(select thuchien.HeaderID, thuchien.MaTieuChi, TieuChi.TenTieuChi, thuchien.SanLuong, header_th.Ca, header_th.Ngay, px.department_id, px.isInside from ThucHien_TieuChi_TheoNgay as thuchien " +
                "inner JOIN header_ThucHienTheoNgay as header_th " +
                "on thuchien.HeaderID = header_th.HeaderID and header_th.Ngay >= @dateStart and header_th.Ngay <= @dateEnd " +
                "INNER JOIN Department as px on px.department_id = header_th.MaPhongBan " +
                "INNER JOIN TieuChi on thuchien.MaTieuChi = TieuChi.MaTieuChi) as a " +
                "GROUP BY MaTieuChi,TenTieuChi) as table2 " +
                "ORDER By MaTieuChi ";
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listReport = db.Database.SqlQuery<reportEntity>(query,new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listReport, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }
    
    public class reportEntity
    {
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public double Ca1 { get; set; }
        public double Ca2 { get; set; }
        public double Ca3 { get; set; }
        public double TH { get; set; }
        //public double KH { get; set; }
        public double luyke { get; set; }
        public double chenhlech { get; set; }
        public double percentage { get; set; }
        public int KHDC { get; set; }
        public int percentageDC { get; set; }
        public int SUM { get; set; }
        public int perday { get; set; }

        public int BQQHDC { get; set; }
        public int vatlieuchong { get; set; }
        public int dientichdao { get; set; }
        public int bc { get; set; }
        public int ct { get; set; }
    }
}