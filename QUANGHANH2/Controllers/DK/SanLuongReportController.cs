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
            var query = "select TieuChi.MaTieuChi,TieuChi.TenTieuChi, " +
                "(Case when CA1 IS NULL then CONVERT(float, 0) else CA1 end) as [CA1]," +
                "(Case when CA2 IS NULL then CONVERT(float,0) else CA2 end) as [CA2], " +
                "(Case when CA3 IS NULL then CONVERT(float,0) else CA3 end) as [CA3], " +
                "(Case when TH IS NULL then CONVERT(float,0) else TH end) as TH, " +
                "(Case when LUYKE IS NULL then CONVERT(float,0) else LUYKE end) as LUYKE, " +
                "(Case when KH IS NULL then CONVERT(float,0) else KH end) as KH, " +
                "(Case when CHENHLECH IS NULL then CONVERT(float,0) else CHENHLECH end) as [CHENHLECH], " +
                "(Case when[PERCENTAGE] IS NULL then CONVERT(float,0) else [PERCENTAGE] end) as [PERCENTAGE], " +
                "(Case when KHDC IS NULL then CONVERT(float,0) else KHDC end) as KHDC, " +
                "(Case when percentDC IS NULL then 0 else percentDC end) as percentDC, " +
                "(Case when LUYKE IS NULL then 0 else LUYKE end) as LUYKE, " +
                "(Case when KH IS NULL then 0 else KH end) as KH from TieuChi " +
                "left join (select *,CONVERT(float, 0) as [KH],CONVERT(float, 0) as [CHENHLECH],CONVERT(float, 0) as [PERCENTAGE], CONVERT(float, 0) as [KHDC], CONVERT(float, 0) as [percentDC],CONVERT(float, 0) as [SUM], " +
                "CONVERT(float, 0) as [perday], CONVERT(float, 0) as [BQKHDC] from(select MaTieuChi, " +
                "Sum(case when ca = 1 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA1], Sum(case when ca = 2 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA2], " +
                "Sum(case when ca = 3 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA3], Sum(case when Ngay = '2019-09-10' then SanLuong else 0  end )as [TH],  " +
                "SUM(SanLuong) as [LUYKE] from(select thuchien.HeaderID, thuchien.MaTieuChi, thuchien.SanLuong, header_th.Ca, header_th.Ngay, " +
                "px.department_id, px.isInside from ThucHien_TieuChi_TheoNgay as thuchien " +
                "inner JOIN header_ThucHienTheoNgay as header_th on thuchien.HeaderID = header_th.HeaderID and header_th.Ngay >= '2019-09-1' and header_th.Ngay <= '2019-09-10' " +
                "INNER JOIN Department as px on px.department_id = header_th.MaPhongBan) " +
                "as a GROUP BY MaTieuChi) as table2 ) as table3 " +
                "on table3.MaTieuChi = TieuChi.MaTieuChi";

            var query_KHDC = "select MaTieuChi, SUM(SanLuong) as SanLuong from(select kehoach.* from(Select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung] " +
                "from KeHoach_TieuChi_TheoThang " +
                "group by MaTieuChi, HeaderID) as a inner join KeHoach_TieuChi_TheoThang as kehoach " +
                "on a.HeaderID = kehoach.HeaderID and a.MaTieuChi = kehoach.MaTieuChi and a.ThoiGianNhapCuoiCung = kehoach.ThoiGianNhapCuoiCung) as b " +
                "inner join(select* from header_KeHoachTungThang where ThangKeHoach = @month and NamKeHoach = @year) as header on b.HeaderID = header.HeaderID " +
                "group by MaTieuChi";

            //
            var query_KHDaily = " select MaTieuChi,SUM(KeHoach) as SanLuong from (select kehoach.* from (Select HeaderID,MaTieuChi,Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNgay " +
                "group by MaTieuChi,HeaderID) as a inner join KeHoach_TieuChi_TheoNgay as kehoach " +
                "on a.HeaderID = kehoach.HeaderID and a.MaTieuChi = kehoach.MaTieuChi and a.ThoiGianNhapCuoiCung = kehoach.ThoiGianNhapCuoiCung) as b " +
                "inner join(select * from header_KeHoach_TieuChi_TheoNgay where NgayNhapKH = '2019-09-10') as header on b.HeaderID = header.HeaderID " +
                "group by MaTieuChi";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();
                var list_KHDC = db.Database.SqlQuery<KHDCEntity>(query_KHDC, new SqlParameter("month", 9), new SqlParameter("year", 2019)).ToList();
                var list_KHDaily = db.Database.SqlQuery<KHDCEntity>(query_KHDaily).ToList();

                foreach (var item in listReport)
                {
                    foreach (var elem in list_KHDC)
                    {
                        if (item.MaTieuChi == elem.MaTieuChi)
                        {
                            item.KHDC = elem.SanLuong;
                            item.BQQHDC = item.KHDC / 20;
                            break;
                        }
                    }
                    //
                    foreach (var elem in list_KHDaily)
                    {
                        if (item.MaTieuChi == elem.MaTieuChi)
                        {
                            item.KH = elem.SanLuong;
                            item.BQQHDC = item.KHDC / 20;
                            break;
                        }
                    }
                }
                //
                foreach (var item in listReport)
                {
                    item.chenhlech = item.TH - item.KH;
                    item.percentage = item.KH == 0 ? 100 : item.TH / item.KH;
                    item.percentageDC = item.KHDC == 0 ? 100 : item.luyke / item.KHDC;
                    item.SUM =  item.KHDC - item.luyke;
                    item.perday = item.SUM / 20;
                }
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listReport, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    public class KHDCEntity
    {
        public int MaTieuChi { get; set; }
        public double SanLuong { get; set; }
    }

    public class reportEntity
    {
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public double Ca1 { get; set; }
        public double Ca2 { get; set; }
        public double Ca3 { get; set; }
        public double TH { get; set; }
        public double KH { get; set; }
        public double luyke { get; set; }
        public double chenhlech { get; set; }
        public double percentage { get; set; }
        public double KHDC { get; set; }
        public double percentageDC { get; set; }
        public double SUM { get; set; }
        public double perday { get; set; }

        public double BQQHDC { get; set; }
        public string GhiChu { get; set; }
    }
}