﻿using Newtonsoft.Json;
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

        public reportEntity addUp(reportEntity item1, reportEntity item2)
        {
            item1.Ca1 += item2.Ca1;
            item1.Ca2 += item2.Ca2;
            item1.Ca3 += item2.Ca3;
            item1.TH += item2.TH;
            item1.KH += item2.KH;
            item1.luyke += item2.luyke;
            item1.chenhlech += item2.chenhlech;
            item1.SUM += item2.SUM;
            item1.BQQHDC += item2.BQQHDC;
            item1.KHDC += item2.KHDC;
            item1.perday += item2.perday;
            //
            item1.percentage = item1.KH == 0 ? 100 : Math.Round(item1.TH / item1.KH, 2, MidpointRounding.ToEven);
            item1.percentageDC = item1.KHDC == 0 ? 100 : Math.Round(item1.luyke / item1.KHDC, 2, MidpointRounding.ToEven);
            return item1;
        }

        [HttpPost]
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty")]
        public ActionResult getReport()
        {
            DateTime timeEnd = Convert.ToDateTime("2019-09-10");
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            //
            var query = "select TieuChi.MaTieuChi,TieuChi.TenTieuChi, TieuChi.MaNhomTieuChi,NhomTieuChi.TenNhomTieuChi,MaPhongBan," +
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
                "left join (select * ,CONVERT(float, 0) as [KH]," +
                "CONVERT(float, 0) as [CHENHLECH],CONVERT(float, 0) as [PERCENTAGE], " +
                "CONVERT(float, 0) as [KHDC], CONVERT(float, 0) as [percentDC], " +
                "CONVERT(float, 0) as [SUM], CONVERT(float, 0) as [perday],  " +
                "CONVERT(float, 0) as [BQKHDC] from(select MaTieuChi, MaPhongBan, " +
                "Sum(case when ca = 1 and Ngay = @dateEnd then SanLuong else 0  end )as [CA1], " +
                "Sum(case when ca = 2 and Ngay = @dateEnd then SanLuong else 0  end )as [CA2], " +
                "Sum(case when ca = 3 and Ngay = @dateEnd then SanLuong else 0  end )as [CA3], " +
                "Sum(case when Ngay = @dateEnd then SanLuong else 0  end )as [TH],  " +
                "SUM(SanLuong) as [LUYKE] from(" +
                "select header_th.MaPhongBan, thuchien.HeaderID, thuchien.MaTieuChi, thuchien.SanLuong, header_th.Ca, header_th.Ngay, px.department_id, px.isInside " +
                "from ThucHien_TieuChi_TheoNgay as thuchien inner JOIN header_ThucHienTheoNgay as header_th " +
                "on thuchien.HeaderID = header_th.HeaderID and header_th.Ngay >= @dateStart and header_th.Ngay <= @dateEnd " +
                "INNER JOIN Department as px on px.department_id = header_th.MaPhongBan) as a GROUP BY MaTieuChi,MaPhongBan) as table2 ) " +
                "as table3 on table3.MaTieuChi = TieuChi.MaTieuChi " +
                "inner join NhomTieuChi on TieuChi.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi " +
                "order by MaTieuChi";

            var query_KHDC = "select (case when table1.SanLuong is null then 0 else table1.SanLuong end) as SanLuong," +
                "(case when table1.MaPhongBan is null then '' else table1.MaPhongBan end) as MaPhongBan,TieuChi.MaTieuChi from (select MaTieuChi, SUM(SanLuong) as SanLuong,header.MaPhongBan from(" +
                "select kehoach.*from(Select HeaderID, MaTieuChi,Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung] from KeHoach_TieuChi_TheoThang group by MaTieuChi, HeaderID) as a " +
                "inner join KeHoach_TieuChi_TheoThang as kehoach " +
                "on a.HeaderID = kehoach.HeaderID and a.MaTieuChi = kehoach.MaTieuChi and a.ThoiGianNhapCuoiCung = kehoach.ThoiGianNhapCuoiCung) as b " +
                "inner join(select* from header_KeHoachTungThang where ThangKeHoach = @month and NamKeHoach = @year) as header " +
                "on b.HeaderID = header.HeaderID " +
                "group by MaTieuChi,MaPhongBan) as table1 " +
                "right join TieuChi on table1.MaTieuChi = TieuChi.MaTieuChi " +
                "order by MaTieuChi";

            var query_KHDaily = "select (case when table1.SanLuong is null then 0 else table1.SanLuong end) as SanLuong," +
                "(case when table1.MaPhongBan is null then '' else table1.MaPhongBan end) as MaPhongBan,TieuChi.MaTieuChi " +
                "from (select MaTieuChi,SUM(KeHoach) as SanLuong, header.MaPhongBan from (" +
                "select kehoach.*from(Select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung] " +
                "from KeHoach_TieuChi_TheoNgay group by MaTieuChi, HeaderID) as a " +
                "inner join KeHoach_TieuChi_TheoNgay as kehoach " +
                "on a.HeaderID = kehoach.HeaderID and a.MaTieuChi = kehoach.MaTieuChi and a.ThoiGianNhapCuoiCung = kehoach.ThoiGianNhapCuoiCung) as b " +
                "inner join(select* from header_KeHoach_TieuChi_TheoNgay where NgayNhapKH = @date) as header on b.HeaderID = header.HeaderID " +
                "group by MaTieuChi,MaPhongBan)  as table1 " +
                "right join TieuChi on table1.MaTieuChi = TieuChi.MaTieuChi " +
                "order by MaTieuChi";

            String[] headers = {"Than Sản Xuất","Than Hầm Lò","Than Lộ Thiên","Đất Đá Bóc", "Nhập Dương Huy", "Tổng Mét Lò CBSX", "Mét Lò CBSX Tự Làm",
                "Mét Lò CBSX Thuê Ngoài", "Mét Lò Xén", "Than Sàng Tuyển", "Than Tiêu Thụ", "Doanh Thu", "Đá Xít Sau Sàng Tuyển"};
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();
                var list_KHDC = db.Database.SqlQuery<KHDCEntity>(query_KHDC, new SqlParameter("month", timeEnd.Month), new SqlParameter("year", timeEnd.Year)).ToList();
                var list_KHDaily = db.Database.SqlQuery<KHDCEntity>(query_KHDaily, new SqlParameter("date", timeEnd)).ToList();
                //
                for (var index = 0; index < listReport.Count; index++)
                {
                    listReport[index].KHDC = list_KHDC[index].SanLuong;
                    listReport[index].BQQHDC = Math.Round(listReport[index].KHDC / 20, 2, MidpointRounding.ToEven);
                    listReport[index].KH = list_KHDaily[index].SanLuong;
                }
                //
                foreach (var item in listReport)
                {
                    item.chenhlech = item.TH - item.KH;
                    item.percentage = item.KH == 0 ? 100 : Math.Round(item.TH / item.KH, 2, MidpointRounding.ToEven);
                    item.percentageDC = item.KHDC == 0 ? 100 : Math.Round(item.luyke / item.KHDC, 2, MidpointRounding.ToEven);
                    item.SUM = item.KHDC - item.luyke;
                    item.perday = Math.Round(item.SUM / 20, 2, MidpointRounding.ToEven);
                }
                //
                List<reportEntity> reports = new List<reportEntity>();
                foreach (var header in headers)
                {
                    reportEntity rp = new reportEntity();
                    rp.TenTieuChi = header;
                    rp.isHeader = true;
                    reports.Add(rp);
                    int previousTieuChi = -1;
                    var headerInDB = header;
                    if (header == "Mét Lò CBSX Tự Làm")
                    {
                        foreach (var item in listReport)
                        {
                            reportEntity rp2 = new reportEntity();
                            if (item.TenNhomTieuChi == "Mét Lò Đào" || item.TenNhomTieuChi == "Mét Lò Neo")
                            {
                                //
                                if (item.MaPhongBan != "PXDL1" && item.MaPhongBan != "PXDL2")
                                {
                                    if (item.TenNhomTieuChi == "Mét Lò Đào")
                                    {
                                        rp = addUp(rp, item);
                                    }
                                    //
                                    if (item.MaTieuChi != previousTieuChi)
                                    {
                                        rp2 = item;
                                        //
                                        previousTieuChi = item.MaTieuChi;
                                        if (rp2.TenTieuChi.ToUpper() != header.ToUpper())
                                        {
                                            reports.Add(rp2);
                                        }
                                    }
                                    else
                                    {
                                        reports[reports.Count - 1] = addUp(reports[reports.Count - 1], item);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (header == "Mét Lò CBSX Thuê Ngoài")
                        {
                            foreach (var item in listReport)
                            {
                                reportEntity rp2 = new reportEntity();
                                if (item.TenNhomTieuChi == "Mét Lò Đào" || item.TenNhomTieuChi == "Mét Lò Neo")
                                {
                                    //
                                    if (item.MaPhongBan == "PXDL1" || item.MaPhongBan == "PXDL2")
                                    {
                                        if (item.TenNhomTieuChi == "Mét Lò Đào")
                                        {
                                            rp = addUp(rp, item);
                                        }
                                        //
                                        if (item.MaTieuChi != previousTieuChi)
                                        {
                                            rp2 = item;
                                            //
                                            previousTieuChi = item.MaTieuChi;
                                            if (rp2.TenTieuChi.ToUpper() != header.ToUpper())
                                            {
                                                reports.Add(rp2);
                                            }
                                        }
                                        else
                                        {
                                            reports[reports.Count - 1] = addUp(reports[reports.Count - 1], item);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in listReport)
                            {
                                reportEntity rp2 = new reportEntity();
                                if (item.TenNhomTieuChi == header)
                                {
                                    //
                                    rp = addUp(rp, item);
                                    //
                                    if (item.MaTieuChi != previousTieuChi)
                                    {
                                        rp2 = item;
                                        //
                                        previousTieuChi = item.MaTieuChi;
                                        if (rp2.TenTieuChi.ToUpper() != header.ToUpper())
                                        {
                                            reports.Add(rp2);
                                        }
                                    }
                                    else
                                    {
                                        reports[reports.Count - 1] = addUp(reports[reports.Count - 1], item);
                                    }
                                }
                            }
                        }
                    }
                }
                // Than San Xuat = Than Ham Lo + Than Lo Thien
                reports[0] = addUp(reports[0], reports[1]);
                reports[0] = addUp(reports[0], reports[4]);
                // Tong met lo CBSX = Met Lo Tu Lam + Met Lo Thue Ngoai
                reports[11] = addUp(reports[11], reports[12]);
                reports[11] = addUp(reports[11], reports[15]);
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(reports, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    public class KHDCEntity
    {
        public int MaTieuChi { get; set; }
        public double SanLuong { get; set; }
        public string MaPhongBan { get; set; }
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
        public string TenPhongBan { get; set; }
        public bool isHeader { get; set; }
        public int MaNhomTieuChi { get; set; }
        public string TenNhomTieuChi { get; set; }
        public string MaPhongBan { get; set; }
    }
}