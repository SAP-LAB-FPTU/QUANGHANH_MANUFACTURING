using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class BaoCaoDemoController : Controller
    {
        // GET: BaoCaoDemo
        [Route("phong-dieu-khien/bao-cao-ngay-trong-thang")]
        public ActionResult Index()
        {
            string thisMonthYear = "Tháng " + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString();
            ViewBag.month = DateTime.Today.Month;
            ViewBag.year = DateTime.Today.Year;
            ViewBag.thisMonthYear = thisMonthYear;
            return View("/Views/DK/BaoCaoDemo.cshtml");
        }

        public ActionResult getData(string monthYear)
        {
            if (monthYear == null || monthYear.Equals(""))
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            var endDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthYearArr = monthYear.Split('-');
            string[] monthArr = monthYearArr[0].Split(' ');
            DateTime startDate = DateTime.Parse(monthYearArr[1].ToString() + '/' + monthArr[1].ToString() + '/' + '1');
            DateTime endDate = DateTime.Parse(monthYearArr[1].ToString() + '/' + monthArr[1].ToString() + '/' + endDays[int.Parse(monthArr[1]) - 1].ToString());


            var queryKH = @"select department_id,SUM(case when view5.MaTieuChi = 1 then SanLuong else 0 end) as [DAOLO],
                            SUM(case when view5.MaTieuChi = 2 then SanLuong else 0 end) as [KHAITHAC],
                            SUM(case when view5.MaTieuChi = 7 or view5.MaTieuChi = 9 then SanLuong else 0 end) as [METLO],
                            SUM(case when view5.MaTieuChi = 19 then SanLuong else 0 end) as [XEN], 
                            SUM(case when view5.MaTieuChi = 3 or view5.MaTieuChi = 4 then SanLuong else 0 end) as [LOTHIEN], 
                            SUM(case when t.MaNhomTieuChi = 9 then SanLuong else 0 end) as [TIEUTHU], 
                            SUM(case when view5.MaTieuChi = 30 then SanLuong else 0 end) as [DOANHTHU],
                            SUM(case when (view5.MaTieuChi = 7 or view5.MaTieuChi = 9) and isInside = 1 then SanLuong else 0 end) as [TRONG],
                            SUM(case when (view5.MaTieuChi = 7 or view5.MaTieuChi = 9) and isInside = 0 then SanLuong else 0 end) as [NGOAI],
                            SUM(case when view5.MaTieuChi = 6 then SanLuong else 0 end) as [DUONGHUY]
                            from(select tmp.* from( 
                            select header.MaPhongBan, kh.MaTieuChi, kh.SanLuong from 
                            (select h.*, kh.SoNgayLamViec from header_KeHoachTungThang h join KeHoachTungThang kh on h.ThangID = kh.ThangID where ThangKeHoach = @month and NamKeHoach = @year) as header 
                            inner join (select v2.* from 
                            (select HeaderID, MaTieuChi, MAX(ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung from KeHoach_TieuChi_TheoThang 
                            group by HeaderID, MaTieuChi) as v1 
                            inner join KeHoach_TieuChi_TheoThang as v2 
                            on v1.HeaderID = v2.HeaderID and v1.MaTieuChi = v2.MaTieuChi and v1.ThoiGianNhapCuoiCung = v2.ThoiGianNhapCuoiCung) as kh 
                            on header.HeaderID = kh.HeaderID) as tmp 
                            inner join(select * from PhongBan_TieuChi where Thang = @month and Nam = @year) as pbtc on 
                            tmp.MaPhongBan = pbtc.MaPhongBan and tmp.MaTieuChi = pbtc.MaTieuChi) as view5
                            inner join TieuChi t on view5.MaTieuChi = t.MaTieuChi							
                            right join Department on MaPhongBan = department_id
							where department_id in (N'ĐL1',N'ĐL3',N'ĐL5',N'ĐL7',N'ĐL8',N'KT1',N'KT2',N'KT3',N'KT4',N'KT5',N'KT6',N'KT7',N'KT8',N'KT9',N'KT10',N'KT11')
                            group by department_id
							order by
								case department_id
								when N'ĐL1' then 1
								when N'ĐL3' then 2
								when N'ĐL5' then 3
								when N'ĐL7' then 4
								when N'ĐL8' then 5
								when N'KT1' then 6
								when N'KT2' then 7
								when N'KT3' then 8
								when N'KT4' then 9
								when N'KT5' then 10
								when N'KT6' then 11
								when N'KT7' then 12
								when N'KT8' then 13
								when N'KT9' then 14
								when N'KT10' then 15
								when N'KT11' then 16
							end";
            //
            var queryDaily = @"select [date],SUM(case when MaPhongBan = N'ĐL1' and MaTieuChi = 1 and Ngay = [date] then SanLuong else 0 end) as PXDL1_THANTH,
                            SUM(case when MaPhongBan = N'ĐL1' and MaTieuChi = 1 then SanLuong else 0 end) as PXDL1_THANLK,
                            SUM(case when(MaPhongBan = N'ĐL1' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19) and Ngay = [date] then SanLuong else 0 end) as PXDL1_MLTH,
                            SUM(case when(MaPhongBan = N'ĐL1' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19)  then SanLuong else 0 end) as PXDL1_MLLK,
                            SUM(case when MaPhongBan = N'ĐL3' and MaTieuChi = 1 and Ngay = [date] then SanLuong else 0 end) as PXDL3_THANTH,
                            SUM(case when MaPhongBan = N'ĐL3' and MaTieuChi = 1  then SanLuong else 0 end) as PXDL3_THANLK,
                            SUM(case when(MaPhongBan = N'ĐL3' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19) and Ngay = [date] then SanLuong else 0 end) as PXDL3_MLTH,
                            SUM(case when(MaPhongBan = N'ĐL3' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19)  then SanLuong else 0 end) as PXDL3_MLLK,
                            SUM(case when MaPhongBan = N'ĐL5' and MaTieuChi = 1 and Ngay = [date] then SanLuong else 0 end) as PXDL5_THANTH,
                            SUM(case when MaPhongBan = N'ĐL5' and MaTieuChi = 1  then SanLuong else 0 end) as PXDL5_THANLK,
                            SUM(case when(MaPhongBan = N'ĐL5' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19) and Ngay = [date] then SanLuong else 0 end) as PXDL5_MLTH,
                            SUM(case when(MaPhongBan = N'ĐL5' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19)  then SanLuong else 0 end) as PXDL5_MLLK,
                            SUM(case when MaPhongBan = N'ĐL7' and MaTieuChi = 1  and Ngay = [date]then SanLuong else 0 end) as PXDL7_THANTH,
                            SUM(case when MaPhongBan = N'ĐL7' and MaTieuChi = 1  then SanLuong else 0 end) as PXDL7_THANLK,
                            SUM(case when(MaPhongBan = N'ĐL7' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19) and Ngay = [date] then SanLuong else 0 end) as PXDL7_MLTH,
                            SUM(case when(MaPhongBan = N'ĐL7' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19)  then SanLuong else 0 end) as PXDL7_MLLK,
                            SUM(case when MaPhongBan = N'ĐL8' and MaTieuChi = 1  and Ngay = [date]then SanLuong else 0 end) as PXDL8_THANTH,
                            SUM(case when MaPhongBan = N'ĐL8' and MaTieuChi = 1  then SanLuong else 0 end) as PXDL8_THANLK,
                            SUM(case when(MaPhongBan = N'ĐL8' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19) and Ngay = [date] then SanLuong else 0 end) as PXDL8_MLTH,
                            SUM(case when(MaPhongBan = N'ĐL8' and MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19)  then SanLuong else 0 end) as PXDL8_MLLK,
                            SUM(case when MaPhongBan = 'KT1' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT1_THANTH,
                            SUM(case when MaPhongBan = 'KT1' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT1_THANLK,
                            SUM(case when MaPhongBan = 'KT2' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT2_THANTH,
                            SUM(case when MaPhongBan = 'KT2' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT2_THANLK,
                            SUM(case when MaPhongBan = 'KT3' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT3_THANTH,
                            SUM(case when MaPhongBan = 'KT3' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT3_THANLK,
                            SUM(case when MaPhongBan = 'KT4' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT4_THANTH,
                            SUM(case when MaPhongBan = 'KT4' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT4_THANLK,
                            SUM(case when MaPhongBan = 'KT5' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT5_THANTH,
                            SUM(case when MaPhongBan = 'KT5' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT5_THANLK,
                            SUM(case when MaPhongBan = 'KT6' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT6_THANTH,
                            SUM(case when MaPhongBan = 'KT6' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT6_THANLK,
                            SUM(case when MaPhongBan = 'KT7' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT7_THANTH,
                            SUM(case when MaPhongBan = 'KT7' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT7_THANLK,
                            SUM(case when MaPhongBan = 'KT8' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT8_THANTH,
                            SUM(case when MaPhongBan = 'KT8' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT8_THANLK,
                            SUM(case when MaPhongBan = 'KT9' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT9_THANTH,
                            SUM(case when MaPhongBan = 'KT9' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT9_THANLK,
                            SUM(case when MaPhongBan = 'KT10' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT10_THANTH,
                            SUM(case when MaPhongBan = 'KT10' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT10_THANLK,
                            SUM(case when MaPhongBan = 'KT11' and MaTieuChi = 2 and Ngay = [date] then SanLuong else 0 end) as PXKT11_THANTH,
                            SUM(case when MaPhongBan = 'KT11' and MaTieuChi = 2  then SanLuong else 0 end) as PXKT11_THANLK,
                            SUM(case when MaTieuChi = 30 and Ngay = [date]  then SanLuong else 0 end) as DOANHTHU_TH,
                            SUM(case when MaTieuChi = 30  then SanLuong else 0 end) as DOANHTHU_LK,
                            SUM(case when(MaTieuChi = 2 or MaTieuChi = 1 or MaTieuChi = 4 or MaTieuChi = 3) and Ngay = [date] then SanLuong else 0 end) as SX_THANTH,
                            SUM(case when(MaTieuChi = 2 or MaTieuChi = 1 or MaTieuChi = 4 or MaTieuChi = 3)  then SanLuong else 0 end) as SX_THANLK,
                            SUM(case when(MaTieuChi = 1 or MaTieuChi = 2) and Ngay = [date] then SanLuong else 0 end) as DL_THANTH,
                            SUM(case when(MaTieuChi = 1 or MaTieuChi = 2) and Ngay = [date] then SanLuong else 0 end) as DL_THANLK,
                            SUM(case when(MaTieuChi = 3 or MaTieuChi = 4) and Ngay = [date] then SanLuong else 0 end) as LT_THANTH,
                            SUM(case when(MaTieuChi = 3 or MaTieuChi = 4) and Ngay = [date] then SanLuong else 0 end) as LT_THANLK,
                            SUM(case when(MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19) and Ngay = [date] then SanLuong else 0 end) as ML_TH,
                            SUM(case when(MaTieuChi = 7 or MaTieuChi = 9 and MaTieuChi = 19)  then SanLuong else 0 end) as ML_LK,
                            SUM(case when(MaTieuChi = 6) and Ngay = [date] then SanLuong else 0 end) as DH_TH,
                            SUM(case when(MaTieuChi = 6)  then SanLuong else 0 end) as DH_LK,
                            SUM(case when(MaTieuChi = 21 or MaTieuChi = 22 or MaTieuChi = 23 or MaTieuChi = 24 or MaTieuChi = 25 or MaTieuChi = 26 or MaTieuChi = 27 or MaTieuChi = 28) and Ngay = [date] then SanLuong else 0 end) as TieuThu_TH,
                            SUM(case when(MaTieuChi = 21 or MaTieuChi = 22 or MaTieuChi = 23 or MaTieuChi = 24 or MaTieuChi = 25 or MaTieuChi = 26 or MaTieuChi = 27 or MaTieuChi = 28)  then SanLuong else 0 end) as TieuThu_LK 
                            from(select * from(select a.* from( 
                            select MaTieuChi, Sum(SanLuong) as SanLuong, MaPhongBan, Ngay from ThucHien_TieuChi_TheoNgay as th 
                            right join (select h.*,ttt.Ngay from header_ThucHienTheoNgay h join ThucHienTheoNgay ttt on h.NgayID = ttt.NgayID where Ngay >= @startDate  and Ngay <= @endDate) as header 
                            on th.HeaderID = header.HeaderID group by MaTieuChi, MaPhongBan, Ngay) as a right join 
                            (select * from PhongBan_TieuChi where Thang = @month and Nam = @year) as pbtc 
                            on a.MaPhongBan = pbtc.MaPhongBan and a.MaTieuChi = pbtc.MaTieuChi) as view1 
                            right join (Select * from (SELECT[date] = DATEADD(Day, Number - 1, @startDate) 
                            FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0)) a(n), 
                            (VALUES(0), (0), (0), (0), (0), (0)) b(n)) as a) as b where b.[date] <= @endDate) as view2 
                            on view1.Ngay <= view2.[date]) as view3 group by[date] order by[date]";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listKH = db.Database.SqlQuery<KHEntities>(queryKH, new SqlParameter("month", monthArr[1]), new SqlParameter("year", monthYearArr[1])).ToList();
                var listTH = db.Database.SqlQuery<DailyEntity>(queryDaily, new SqlParameter("month", monthArr[1]), new SqlParameter("year", monthYearArr[1]), new SqlParameter("startDate", startDate), new SqlParameter("endDate", endDate)).ToList();
                return Json(new { success = true, listKH = listKH, listTH = listTH, year = monthYearArr[1], month = monthArr[1] }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-dieu-khien/bao-cao-ngay-trong-thang/lay-du-lieu")]
        public ActionResult ProcessRequest()
        {
            string month = Request["month"];
            //int year = int.Parse(Request["year"]);
            return getData(month);
        }
    }

    public class KHEntities
    {
        public string department_id { get; set; }
        public double DAOLO { get; set; }
        public double KHAITHAC { get; set; }
        public double METLO { get; set; }
        public double XEN { get; set; }
        public double LOTHIEN { get; set; }
        public double TIEUTHU { get; set; }
        public double DOANHTHU { get; set; }
        public double TRONG { get; set; }
        public double NGOAI { get; set; }
        public double DUONGHUY { get; set; }
    }

    public class DailyEntity
    {
        public DateTime date { get; set; }
        public double PXDL1_THANTH { get; set; }
        public double PXDL1_THANLK { get; set; }
        public double PXDL1_MLTH { get; set; }
        public double PXDL1_MLLK { get; set; }
        public double PXDL3_THANTH { get; set; }
        public double PXDL3_THANLK { get; set; }
        public double PXDL3_MLTH { get; set; }
        public double PXDL3_MLLK { get; set; }
        //public double PXDL4_THANTH { get; set; }
        //public double PXDL4_THANLK { get; set; }
        //public double PXDL4_MLTH { get; set; }
        //public double PXDL4_MLLK { get; set; }
        public double PXDL5_THANTH { get; set; }
        public double PXDL5_THANLK { get; set; }
        public double PXDL5_MLTH { get; set; }
        public double PXDL5_MLLK { get; set; }
        public double PXDL7_THANTH { get; set; }
        public double PXDL7_THANLK { get; set; }
        public double PXDL7_MLTH { get; set; }
        public double PXDL7_MLLK { get; set; }
        public double PXDL8_THANTH { get; set; }
        public double PXDL8_THANLK { get; set; }
        public double PXDL8_MLTH { get; set; }
        public double PXDL8_MLLK { get; set; }
        public double PXKT1_THANTH { get; set; }
        public double PXKT1_THANLK { get; set; }
        public double PXKT2_THANTH { get; set; }
        public double PXKT2_THANLK { get; set; }
        public double PXKT3_THANTH { get; set; }
        public double PXKT3_THANLK { get; set; }
        public double PXKT4_THANTH { get; set; }
        public double PXKT4_THANLK { get; set; }
        public double PXKT5_THANTH { get; set; }
        public double PXKT5_THANLK { get; set; }
        public double PXKT6_THANTH { get; set; }
        public double PXKT6_THANLK { get; set; }
        public double PXKT7_THANTH { get; set; }
        public double PXKT7_THANLK { get; set; }
        public double PXKT8_THANTH { get; set; }
        public double PXKT8_THANLK { get; set; }
        public double PXKT9_THANTH { get; set; }
        public double PXKT9_THANLK { get; set; }
        public double PXKT10_THANTH { get; set; }
        public double PXKT10_THANLK { get; set; }
        public double PXKT11_THANTH { get; set; }
        public double PXKT11_THANLK { get; set; }
        public double DOANHTHU_TH { get; set; }
        public double DOANHTHU_LK { get; set; }
        public double SX_THANTH { get; set; }
        public double SX_THANLK { get; set; }
        public double DL_THANTH { get; set; }
        public double DL_THANLK { get; set; }
        public double LT_THANTH { get; set; }
        public double LT_THANLK { get; set; }
        public double ML_TH { get; set; }
        public double ML_LK { get; set; }
        public double DH_TH { get; set; }
        public double DH_LK { get; set; }
        public double TieuThu_TH { get; set; }
        public double TieuThu_LK { get; set; }
    }
}