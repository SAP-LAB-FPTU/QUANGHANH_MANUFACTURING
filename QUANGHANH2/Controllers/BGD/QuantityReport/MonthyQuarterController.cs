using Newtonsoft.Json;
using QUANGHANH2.Controllers.DK;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.BGD.QuantityReport
{
    public class MonthyQuarterController : Controller
    {
        // GET: ReportMonthly
        [Route("ban-giam-doc/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-thang-quy")]
        public ActionResult getView()
        {
            return View("/Views/BGD/QuantityReport/MonthyQuarterly.cshtml");
        }
        //
        [HttpPost]
        [Route("ban-giam-doc/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-thang-quy")]
        public ActionResult getDataFromDB()
        {
            int year = Int32.Parse(Request["years"]);
            var query = @"select tmp5.*,Department.department_name as TenPhongBan,NhomTieuChi.TenNhomTieuChi from (
                            select tmp4.*, (Jan + Feb + March + April) as [Q1],(May + June + July + Aug) as [Q2],(Sep + Oct + Nov + [Dec]) as [Q3],(Jan + Feb + March + April + May + June + July + Aug + Sep + Oct + Nov + [Dec]) as [totalYear] from 
                            (select MaNhomTieuChi, MaPhongBan, 
                            SUM(Jan) as [Jan], SUM([Feb]) as [Feb],SUM([March]) as [March],SUM([April]) as [April], 
                            SUM([May]) as [May],SUM([June]) as [June],SUM([July]) as [July],SUM([Aug]) as [Aug],  SUM([Sep]) as [Sep],SUM([Oct]) as [Oct],SUM([Nov]) as [Nov],SUM([Dec]) as [Dec] 
                            FROM( select MaNhomTieuChi, MaPhongBan, 
                            Sum(case when tmp2.Ngay between @startJan and @endJan then SanLuong else 0 end) as [Jan], 
                            Sum(case when tmp2.Ngay between @startFeb and @endFeb then SanLuong else 0 end) as [Feb], 
                            Sum(case when tmp2.Ngay between @startMar and @endMar then SanLuong else 0 end) as [March], 
                            Sum(case when tmp2.Ngay between @startApril and @endApril then SanLuong else 0 end) as [April], 
                            Sum(case when tmp2.Ngay between @startMay and @endMay then SanLuong else 0 end) as [May], 
                            Sum(case when tmp2.Ngay between @startJune and @endJune then SanLuong else 0 end) as [June], 
                            Sum(case when tmp2.Ngay between @startJuly and @endJuly then SanLuong else 0 end) as [July], 
                            Sum(case when tmp2.Ngay between @startAug and @endAug then SanLuong else 0 end) as [Aug], 
                            Sum(case when tmp2.Ngay between @startSep and @endSep then SanLuong else 0 end) as [Sep], 
                            Sum(case when tmp2.Ngay between @startOct and @endOct then SanLuong else 0 end) as [Oct], 
                            Sum(case when tmp2.Ngay between @startNov and @endNov then SanLuong else 0 end) as [Nov], 
                            Sum(case when tmp2.Ngay between @startDec and @endDec then SanLuong else 0 end) as [Dec] 
                            from(
                            select tmp1.* , TieuChi.MaNhomTieuChi from (select mutualCitirias.MaPhongBan, mutualCitirias.MaTieuChi, 
                            (Case when performance.Ngay IS NULL then @startJan else performance.Ngay end) as [Ngay], 
                            (Case when performance.SanLuong IS NULL then 0 else performance.SanLuong end) as [SanLuong] from 
                            (select distinct MaTieuChi, MaPhongBan from ThucHien_TieuChi_TheoNgay as a 
                            inner join(select h.* from header_ThucHienTheoNgay h join ThucHienTheoNgay tht on h.NgayID = tht.NgayID where Ngay  between @startJan and @endDec) as b 
                            on a.HeaderID = b.HeaderID union 
                            select distinct MaTieuChi, MaPhongBan from PhongBan_TieuChi 
                            where Nam = @year 
                            union select distinct MaTieuChi, MaPhongBan from(select * from header_KeHoach_TieuChi_TheoNam where Nam = @year) as c 
                            inner join(select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join( 
                            select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam 
                            group by HeaderID, MaTieuChi) as maxTime 
                            on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as d 
                            on c.HeaderID = d.HeaderID) mutualCitirias left join 
                            (select MaPhongBan, Ngay, MaTieuChi, SanLuong from 
                            (select h.*, tht.Ngay from header_ThucHienTheoNgay h join ThucHienTheoNgay tht on h.NgayID = tht.NgayID where Ngay  between @startJan and @endDec) as header 
                            left join ThucHien_TieuChi_TheoNgay on ThucHien_TieuChi_TheoNgay.HeaderID = header.HeaderID) as performance 
                            on mutualCitirias.MaPhongBan = performance.MaPhongBan and mutualCitirias.MaTieuChi = performance.MaTieuChi) as tmp1 
                            inner join TieuChi on tmp1.MaTieuChi = TieuChi.MaTieuChi) as tmp2 group by MaNhomTieuChi, MaPhongBan ) as tmp3 
                            group by MaNhomTieuChi, MaPhongBan) as tmp4 ) as tmp5 
                            inner join Department on tmp5.MaPhongBan = Department.department_id 
                            inner join NhomTieuChi on tmp5.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi 
                            order by MaPhongBan,MaNhomTieuChi";
            //
            var queryKH = @"select MaPhongBan,MaNhomTieuChi,
                            SUM(case when tmp6.ThangKeHoach = 1 then SanLuong else 0 end) as [Jan],SUM(case when tmp6.ThangKeHoach = 2 then SanLuong else 0 end) as [Feb], 
                            SUM(case when tmp6.ThangKeHoach = 3 then SanLuong else 0 end) as [March], SUM(case when tmp6.ThangKeHoach = 4 then SanLuong else 0 end) as [April], 
                            SUM(case when((tmp6.ThangKeHoach = 4) or(tmp6.ThangKeHoach = 1) or(tmp6.ThangKeHoach = 2) or(tmp6.ThangKeHoach = 3)) then SanLuong else 0 end) as [Q1],
                            SUM(case when tmp6.ThangKeHoach = 5 then SanLuong else 0 end) as [May], SUM(case when tmp6.ThangKeHoach = 6 then SanLuong else 0 end) as [June],
                            SUM(case when tmp6.ThangKeHoach = 7 then SanLuong else 0 end) as [July], SUM(case when tmp6.ThangKeHoach = 8 then SanLuong else 0 end) as [Aug], 
                            SUM(case when((tmp6.ThangKeHoach = 5) or(tmp6.ThangKeHoach = 6) or(tmp6.ThangKeHoach = 7) or(tmp6.ThangKeHoach = 8)) then SanLuong else 0 end) as [Q2], 
                            SUM(case when tmp6.ThangKeHoach = 9 then SanLuong else 0 end) as [Sep],SUM(case when tmp6.ThangKeHoach = 10 then SanLuong else 0 end) as [Oct],
                            SUM(case when tmp6.ThangKeHoach = 11 then SanLuong else 0 end) as [Nov],SUM(case when tmp6.ThangKeHoach = 12 then SanLuong else 0 end) as [Dec], 
                            SUM(case when((tmp6.ThangKeHoach = 9) or(tmp6.ThangKeHoach = 10) or(tmp6.ThangKeHoach = 11) or(tmp6.ThangKeHoach = 12)) then SanLuong else 0 end) as [Q3] 
                            from (select MaPhongBan, SanLuong, ThangKeHoach, MaNhomTieuChi from 
                            (select tmp3.MaPhongBan, tmp3.MaTieuChi, (case when tmp4.SanLuong is null then 0 else tmp4.SanLuong end) as [SanLuong],(case when tmp4.ThangKeHoach is null then 1 else tmp4.ThangKeHoach end) as [ThangKeHoach] from( 
                            select distinct MaTieuChi, MaPhongBan from ThucHien_TieuChi_TheoNgay as a 
                            inner join(select h.*, tht.Ngay from header_ThucHienTheoNgay h join ThucHienTheoNgay tht on h.NgayID = tht.NgayID where Ngay  between @startJan and @endDec) as b 
                            on a.HeaderID = b.HeaderID 
                            union 
                            select distinct MaTieuChi, MaPhongBan from PhongBan_TieuChi where Nam = @year 
                            union 
                            select distinct MaTieuChi, MaPhongBan from(select * from header_KeHoach_TieuChi_TheoNam where Nam = @year) as c 
                            inner join(select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join(
                            select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam 
                            group by HeaderID, MaTieuChi) as maxTime 
                            on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as d 
                            on c.HeaderID = d.HeaderID) as tmp3 
                            left join 
                            (select MaPhongBan, MaTieuChi, SanLuong, ThangKeHoach from 
                            (select monthlyplan.*from KeHoach_TieuChi_TheoThang as monthlyplan inner join(
                            select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoThang 
                            group by HeaderID,MaTieuChi ) as maxTime 
                            on monthlyplan.HeaderID = maxTime.HeaderID and monthlyplan.MaTieuChi = maxTime.MaTieuChi and monthlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as tmp1 
                            inner join (select k.*, kh.ThangKeHoach from header_KeHoachTungThang k join KeHoachTungThang kh on k.ThangID = kh.ThangID where NamKeHoach = @year) as tmp2 on tmp1.HeaderID = tmp2.HeaderID) as tmp4 
                            on tmp3.MaPhongBan = tmp4.MaPhongBan and tmp3.MaTieuChi = tmp4.MaTieuChi) as tmp5 
                            inner join TieuChi on tmp5.MaTieuChi = TieuChi.MaTieuChi) as tmp6 
                            group by MaPhongBan,MaNhomTieuChi
                            order by MaPhongBan";
            var yearlyPlanQuery = @"Select MaPhongBan,MaNhomTieuChi,SUM(SanLuong) as [SanLuong] from (select MaPhongBan, TieuChi.MaNhomTieuChi, SanLuong from( 
                            select tmp3.MaTieuChi, tmp3.MaPhongBan, (Case when SanLuong IS NULL then 0 else SanLuong end) as [SanLuong] from 
                            (select distinct MaTieuChi, MaPhongBan from ThucHien_TieuChi_TheoNgay as a 
                            inner join(select h.* from header_ThucHienTheoNgay h join ThucHienTheoNgay tht on h.NgayID = tht.NgayID where Ngay  between @startJan and @endDec) as b 
                            on a.HeaderID = b.HeaderID 
                            union 
                            select distinct MaTieuChi, MaPhongBan from PhongBan_TieuChi 
                            where Nam = @year 
                            union 
                            select distinct MaTieuChi, MaPhongBan from(select * from header_KeHoach_TieuChi_TheoNam where Nam = @year) as c 
                            inner join(select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join( 
                            select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam 
                            group by HeaderID, MaTieuChi) as maxTime 
                            on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as d 
                            on c.HeaderID = d.HeaderID) as tmp3 
                            left join 
                            (select MaPhongBan, MaTieuChi, [SanLuongKeHoach] as [SanLuong] from (select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan 
                            inner join( select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam 
                            group by HeaderID, MaTieuChi) as maxTime on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as tmp1 
                            inner join (select* from header_KeHoach_TieuChi_TheoNam where Nam = @year) as tmp2 
                            on tmp1.HeaderID = tmp2.HeaderID) as tmp4 on tmp3.MaPhongBan = tmp4.MaPhongBan and tmp3.MaTieuChi = tmp4.MaTieuChi ) as tmp5 
                            inner join TieuChi on tmp5.MaTieuChi = TieuChi.MaTieuChi ) as tmp6 
                            group by MaPhongBan,MaNhomTieuChi
                            order by MaPhongBan";

            var queryKHDC = @"select MaPhongBan,MaNhomTieuChi,KHBD,KHDC from
                            (select h.* from header_KeHoach_TieuChi_TheoNam h where h.Nam = @year) as headerMonthlyPlan 
                            inner join 
                            (select HeaderID, MaNhomTieuChi, 
                            SUM(Case when ThoiGianNhapCuoiCung = ThoiGianNhapBanDau then SanLuongKeHoach else 0 end) as [KHBD], 
                            SUM(Case when ThoiGianNhapCuoiCung = ThoiGianNhapCuoiCung_compare then SanLuongKeHoach else 0 end) as [KHDC] 
                            from 
                            (select monthlyPlan.*, maxTime.ThoiGianNhapBanDau, maxTime.ThoiGianNhapCuoiCung as [ThoiGianNhapCuoiCung_compare] from (select k.*, t.MaNhomTieuChi from KeHoach_TieuChi_TheoNam k join TieuChi t on k.MaTieuChi = t.MaTieuChi) as monthlyPlan 
                            inner join 
                            (select HeaderID, MaNhomTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung], Min(ThoiGianNhapCuoiCung) as [ThoiGianNhapBanDau] from KeHoach_TieuChi_TheoNam k join TieuChi t on k.MaTieuChi = t.MaTieuChi
                            group by HeaderID, MaNhomTieuChi) as maxTime 
                            on maxTime.HeaderID = monthlyPlan.HeaderID and maxTime.MaNhomTieuChi = monthlyPlan.MaNhomTieuChi and(maxTime.ThoiGianNhapCuoiCung = monthlyPlan.ThoiGianNhapCuoiCung or maxTime.ThoiGianNhapBanDau = monthlyPlan.ThoiGianNhapCuoiCung)) as tmp1 
                            group by HeaderID,MaNhomTieuChi) as tmp2 
                            on headerMonthlyPlan.HeaderID = tmp2.HeaderID 
                            
                            union
                            select d.department_id, n.MaNhomTieuChi, 0 as KHBD, 0 as KHDC
                            from (
                            select distinct pt.MaPhongBan, nt.MaNhomTieuChi
							from PhongBan_TieuChi pt join TieuChi t on pt.MaTieuChi = t.MaTieuChi join NhomTieuChi nt on t.MaNhomTieuChi = nt.MaNhomTieuChi
							where Nam = @year
							except
							select distinct h.MaPhongBan,t.MaNhomTieuChi from header_KeHoach_TieuChi_TheoNam h join KeHoach_TieuChi_TheoNam k on h.HeaderID = k.HeaderID join TieuChi t on k.MaTieuChi = t.MaTieuChi where h.Nam = @year
							) a join Department d on a.MaPhongBan = d.department_id join NhomTieuChi n on a.MaNhomTieuChi = n.MaNhomTieuChi
                            order by MaPhongBan";

            var endDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            List<DateTime> endDates = new List<DateTime>();
            List<DateTime> startDates = new List<DateTime>();
            for (var i = 1; i <= 12; i++)
            {
                startDates.Add(Convert.ToDateTime(year + "-" + i + "-1"));
                endDates.Add(Convert.ToDateTime(year + "-" + i + "-" + endDays[i - 1]));
            }
            if (year % 4 == 0 || year % 400 == 0)
            {
                // Nam Nhuan ngay ket thuc thang 2 tu 28 sang 29
                endDates[1] = endDates[1].AddDays(1);
            }
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listTH = db.Database.SqlQuery<SanLuongTheoThangQuy>(query,
                    new SqlParameter("startJan", startDates[0]), new SqlParameter("endJan", endDates[0]),
                    new SqlParameter("startFeb", startDates[1]), new SqlParameter("endFeb", endDates[1]),
                    new SqlParameter("startMar", startDates[2]), new SqlParameter("endMar", endDates[2]),
                    new SqlParameter("startApril", startDates[3]), new SqlParameter("endApril", endDates[3]),
                    new SqlParameter("startMay", startDates[4]), new SqlParameter("endMay", endDates[4]),
                    new SqlParameter("startJune", startDates[5]), new SqlParameter("endJune", endDates[5]),
                    new SqlParameter("startJuly", startDates[6]), new SqlParameter("endJuly", endDates[6]),
                    new SqlParameter("startAug", startDates[7]), new SqlParameter("endAug", endDates[7]),
                    new SqlParameter("startSep", startDates[8]), new SqlParameter("endSep", endDates[8]),
                    new SqlParameter("startOct", startDates[9]), new SqlParameter("endOct", endDates[9]),
                    new SqlParameter("startNov", startDates[10]), new SqlParameter("endNov", endDates[10]),
                    new SqlParameter("startDec", startDates[11]), new SqlParameter("endDec", endDates[11]), new SqlParameter("year", year)
                    ).ToList();
                //
                var listKH = db.Database.SqlQuery<SanLuongTheoThangQuy>(queryKH, new SqlParameter("year", year), new SqlParameter("startJan", startDates[0]), new SqlParameter("endDec", endDates[11])).ToList();
                //
                var listYearlyPlan = db.Database.SqlQuery<yearlyPlan>(yearlyPlanQuery, new SqlParameter("year", year), new SqlParameter("startJan", startDates[0]), new SqlParameter("endDec", endDates[11])).ToList();
                //
                var listKHDC_BD = db.Database.SqlQuery<KHDCDepartmentEntity>(queryKHDC, new SqlParameter("year", year)).ToList();
                //         if(listKHDC_BD.Count < listTH.Count)
                //         {
                //             queryKHDC = @"select MaPhongBan,MaNhomTieuChi,KHBD,KHDC from
                //                     (select h.* from header_KeHoach_TieuChi_TheoNam h where h.Nam = @year) as headerMonthlyPlan 
                //                     inner join 
                //                     (select HeaderID, MaNhomTieuChi, 
                //                     SUM(Case when ThoiGianNhapCuoiCung = ThoiGianNhapBanDau then SanLuongKeHoach else 0 end) as [KHBD], 
                //                     SUM(Case when ThoiGianNhapCuoiCung = ThoiGianNhapCuoiCung_compare then SanLuongKeHoach else 0 end) as [KHDC] 
                //                     from 
                //                     (select monthlyPlan.*, maxTime.ThoiGianNhapBanDau, maxTime.ThoiGianNhapCuoiCung as [ThoiGianNhapCuoiCung_compare] from (select k.*, t.MaNhomTieuChi from KeHoach_TieuChi_TheoNam k join TieuChi t on k.MaTieuChi = t.MaTieuChi) as monthlyPlan 
                //                     inner join 
                //                     (select HeaderID, MaNhomTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung], Min(ThoiGianNhapCuoiCung) as [ThoiGianNhapBanDau] from KeHoach_TieuChi_TheoNam k join TieuChi t on k.MaTieuChi = t.MaTieuChi
                //                     group by HeaderID, MaNhomTieuChi) as maxTime 
                //                     on maxTime.HeaderID = monthlyPlan.HeaderID and maxTime.MaNhomTieuChi = monthlyPlan.MaNhomTieuChi and(maxTime.ThoiGianNhapCuoiCung = monthlyPlan.ThoiGianNhapCuoiCung or maxTime.ThoiGianNhapBanDau = monthlyPlan.ThoiGianNhapCuoiCung)) as tmp1 
                //                     group by HeaderID,MaNhomTieuChi) as tmp2 
                //                     on headerMonthlyPlan.HeaderID = tmp2.HeaderID 

                //                     union
                //                     select d.department_id, n.MaNhomTieuChi, 0 as KHBD, 0 as KHDC
                //                     from (
                //                     select distinct pt.MaPhongBan, nt.MaNhomTieuChi
                //from PhongBan_TieuChi pt join TieuChi t on pt.MaTieuChi = t.MaTieuChi join NhomTieuChi nt on t.MaNhomTieuChi = nt.MaNhomTieuChi
                //where Nam = @year
                //except
                //select distinct h.MaPhongBan,t.MaNhomTieuChi from header_KeHoach_TieuChi_TheoNam h join KeHoach_TieuChi_TheoNam k on h.HeaderID = k.HeaderID join TieuChi t on k.MaTieuChi = t.MaTieuChi where h.Nam = @year
                //) a join Department d on a.MaPhongBan = d.department_id join NhomTieuChi n on a.MaNhomTieuChi = n.MaNhomTieuChi
                //                     order by MaPhongBan";
                //             listKHDC_BD = db.Database.SqlQuery<KHDCDepartmentEntity>(queryKHDC, new SqlParameter("year", year)).ToList();
                //             //string script = @"select d.department_name, n.TenNhomTieuChi
                //             //                from (
                //             //                select distinct h.MaPhongBan,t.MaNhomTieuChi from header_KeHoachTungThang h join KeHoach_TieuChi_TheoThang k on h.HeaderID = k.HeaderID join KeHoachTungThang kh on h.ThangID = kh.ThangID join TieuChi t on k.MaTieuChi = t.MaTieuChi where kh.NamKeHoach = @year
                //             //                except
                //             //                select distinct h.MaPhongBan,t.MaNhomTieuChi from header_KeHoach_TieuChi_TheoNam h join KeHoach_TieuChi_TheoNam k on h.HeaderID = k.HeaderID join TieuChi t on k.MaTieuChi = t.MaTieuChi where h.Nam = @year
                //             //                ) a join Department d on a.MaPhongBan = d.department_id join NhomTieuChi n on a.MaNhomTieuChi = n.MaNhomTieuChi";
                //             //var list_thieu = db.Database.SqlQuery<tieuchi_thieu>(script, new SqlParameter("year", year)).ToList();
                //             //JsonSerializerSettings jss2 = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                //             //var result2 = JsonConvert.SerializeObject(list_thieu, Formatting.Indented, jss2);
                //             //return Json(new { success = false, mess = "chưa nhập kế hoạch năm", thieu = result2 }, JsonRequestBehavior.AllowGet);
                //         }
                //Thu Tu In Ra Theo Ten Phong Ban
                //
                var departmentName = new string[] { "Phân xưởng khai thác 1", "Phân xưởng khai thác 2", "Phân xưởng khai thác 3", "Phân xưởng khai thác 4","Phân xưởng khai thác 5",
                                                    "Phân xưởng khai thác 6", "Phân xưởng khai thác 7", "Phân xưởng khai thác 8", "Phân xưởng khai thác 9","Phân xưởng khai thác 10",
                                                    "Phân xưởng khai thác 11", "Phân xưởng đào lò 3", "Phân xưởng đào lò 5", "Phân xưởng đào lò 7","Phân xưởng đào lò 8",
                                                    "Phân xưởng chế biến than","Phân xưởng vận tải lò 1","Phân xưởng vận tải lò 2"};
                //
                List<ChiTietBaoCao_Object> listBaoCao = new List<ChiTietBaoCao_Object>();
                for (var index = 0; index < departmentName.Length; index++)
                {
                    ChiTietBaoCao_Object bcHeader = new ChiTietBaoCao_Object();
                    bcHeader.TenPhongBan = departmentName[index];
                    bcHeader.isHeader = true;
                    listBaoCao.Add(bcHeader);
                    for (var index2 = 0; index2 < listTH.Count; index2++)
                    {
                        if (listTH[index2].TenPhongBan == departmentName[index])
                        {
                            ChiTietBaoCao_Object bc = new ChiTietBaoCao_Object();
                            bc.Jan = listTH[index2].Jan;
                            bc.Feb = listTH[index2].Feb;
                            bc.March = listTH[index2].March;
                            bc.April = listTH[index2].April;
                            bc.May = listTH[index2].May;
                            bc.June = listTH[index2].June;
                            bc.July = listTH[index2].July;
                            bc.Aug = listTH[index2].Aug;
                            bc.Sep = listTH[index2].Sep;
                            bc.Oct = listTH[index2].Oct;
                            bc.Nov = listTH[index2].Nov;
                            bc.Dec = listTH[index2].Dec;
                            bc.Q1 = listTH[index2].Q1;
                            bc.Q2 = listTH[index2].Q2;
                            bc.Q3 = listTH[index2].Q3;
                            bc.totalYear = listTH[index2].totalYear;
                            bc.isHeader = false;
                            bc.TenNhomTieuChi = listTH[index2].TenNhomTieuChi;
                            //
                            bc.JanKH = listKH[index2].Jan;
                            bc.FebKH = listKH[index2].Feb;
                            bc.MarchKH = listKH[index2].March;
                            bc.AprilKH = listKH[index2].April;
                            bc.MayKH = listKH[index2].May;
                            bc.JuneKH = listKH[index2].June;
                            bc.JulyKH = listKH[index2].July;
                            bc.AugKH = listKH[index2].Aug;
                            bc.SepKH = listKH[index2].Sep;
                            bc.OctKH = listKH[index2].Oct;
                            bc.NovKH = listKH[index2].Nov;
                            bc.DecKH = listKH[index2].Dec;
                            bc.Q1KH = listKH[index2].Q1;
                            bc.Q2KH = listKH[index2].Q2;
                            bc.Q3KH = listKH[index2].Q3;
                            //
                            bc.adjustedPlan = listKHDC_BD[index2].KHDC;
                            bc.firstPlan = listKHDC_BD[index2].KHBD;
                            //
                            bc.totalYearKH = listYearlyPlan[index2].SanLuong;
                            //
                            if (bc.JanKH != 0)
                            {
                                bc.JanPor = string.Format("{0:0.00}", 100 * bc.Jan / bc.JanKH);
                            }
                            if (bc.FebKH != 0)
                            {
                                bc.FebPor = string.Format("{0:0.00}", 100 * bc.Feb / bc.FebKH);
                            }
                            if (bc.MarchKH != 0)
                            {
                                bc.MarchPor = string.Format("{0:0.00}", 100 * bc.March / bc.MarchKH);
                            }
                            if (bc.AprilKH != 0)
                            {
                                bc.AprilPor = string.Format("{0:0.00}", 100 * bc.Jan / bc.JanKH);
                            }
                            if (bc.MayKH != 0)
                            {
                                bc.MayPor = string.Format("{0:0.00}", 100 * bc.May / bc.MayKH);
                            }
                            if (bc.JuneKH != 0)
                            {
                                bc.JunePor = string.Format("{0:0.00}", 100 * bc.June / bc.JuneKH);
                            }
                            if (bc.JulyKH != 0)
                            {
                                bc.JulyPor = string.Format("{0:0.00}", 100 * bc.July / bc.JulyKH);
                            }
                            if (bc.AugKH != 0)
                            {
                                bc.AugPor = string.Format("{0:0.00}", 100 * bc.Aug / bc.AugKH);
                            }
                            if (bc.SepKH != 0)
                            {
                                bc.SepPor = string.Format("{0:0.00}", 100 * bc.Sep / bc.SepKH);
                            }
                            if (bc.OctKH != 0)
                            {
                                bc.OctPor = string.Format("{0:0.00}", 100 * bc.Oct / bc.OctKH);
                            }
                            if (bc.NovKH != 0)
                            {
                                bc.NovPor = string.Format("{0:0.00}", 100 * bc.Nov / bc.NovKH);
                            }
                            if (bc.DecKH != 0)
                            {
                                bc.DecPor = string.Format("{0:0.00}", 100 * bc.Dec / bc.DecKH);
                            }
                            if (bc.Q1KH != 0)
                            {
                                bc.Q1Por = string.Format("{0:0.00}", 100 * bc.Q1 / bc.Q1KH);
                            }
                            if (bc.Q2KH != 0)
                            {
                                bc.Q2Por = string.Format("{0:0.00}", 100 * bc.Q2 / bc.Q1KH);
                            }
                            if (bc.Q3KH != 0)
                            {
                                bc.Q3Por = string.Format("{0:0.00}", 100 * bc.Q3 / bc.Q1KH);
                            }
                            if (bc.totalYearKH != 0)
                            {
                                bc.totalYearPor = string.Format("{0:0.00}", 100 * bc.totalYear / bc.totalYearKH);
                            }
                            listBaoCao.Add(bc);
                        }
                    }
                }
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listBaoCao, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    public class header_SanLuongTheoThangQuy
    {
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public string TenNhomTieuChi { get; set; }

        public int MaNhomTieuChi { get; set; }
        public bool isHeader { get; set; }
    }

    public class SanLuongTheoThangQuy : header_SanLuongTheoThangQuy
    {
        public double Jan { get; set; }
        public double Feb { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double Aug { get; set; }
        public double Sep { get; set; }
        public double Oct { get; set; }
        public double Nov { get; set; }
        public double Dec { get; set; }
        public double Q1 { get; set; }
        public double Q2 { get; set; }
        public double Q3 { get; set; }
        public double totalYear { get; set; }
    }
    //
    public class SanLuongKHTheoThangQuy : header_SanLuongTheoThangQuy
    {
        public double JanKH { get; set; }
        public double FebKH { get; set; }
        public double MarchKH { get; set; }
        public double AprilKH { get; set; }
        public double MayKH { get; set; }
        public double JuneKH { get; set; }
        public double JulyKH { get; set; }
        public double AugKH { get; set; }
        public double SepKH { get; set; }
        public double OctKH { get; set; }
        public double NovKH { get; set; }
        public double DecKH { get; set; }
        public double Q1KH { get; set; }
        public double Q2KH { get; set; }
        public double Q3KH { get; set; }
        public double totalYearKH { get; set; }
    }

    public class ChiTietBaoCao_Object : header_SanLuongTheoThangQuy
    {
        public double Jan { get; set; }
        public double Feb { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double Aug { get; set; }
        public double Sep { get; set; }
        public double Oct { get; set; }
        public double Nov { get; set; }
        public double Dec { get; set; }
        public double Q1 { get; set; }
        public double Q2 { get; set; }
        public double Q3 { get; set; }
        public double JanKH { get; set; }
        public double FebKH { get; set; }
        public double MarchKH { get; set; }
        public double AprilKH { get; set; }
        public double MayKH { get; set; }
        public double JuneKH { get; set; }
        public double JulyKH { get; set; }
        public double AugKH { get; set; }
        public double SepKH { get; set; }
        public double OctKH { get; set; }
        public double NovKH { get; set; }
        public double DecKH { get; set; }
        public double Q1KH { get; set; }
        public double Q2KH { get; set; }
        public double Q3KH { get; set; }
        public double totalYear { get; set; }
        public double totalYearKH { get; set; }
        public string totalYearPor { get; set; }
        public string JanPor { get; set; }
        public string FebPor { get; set; }
        public string MarchPor { get; set; }
        public string AprilPor { get; set; }
        public string MayPor { get; set; }
        public string JunePor { get; set; }
        public string JulyPor { get; set; }
        public string AugPor { get; set; }
        public string SepPor { get; set; }
        public string OctPor { get; set; }
        public string NovPor { get; set; }
        public string DecPor { get; set; }
        public string Q1Por { get; set; }
        public string Q2Por { get; set; }
        public string Q3Por { get; set; }

        public double firstPlan { get; set; }
        public double adjustedPlan { get; set; }
    }

    public class yearlyPlan : header_SanLuongTheoThangQuy
    {
        public double SanLuong { get; set; }
    }

    public class tieuchi_thieu
    {
        public string department_name { get; set; }
        public string TenNhomTieuChi { get; set; }
    }
}