using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK
{
    public class KeHoachDieuHanhChiTieuController : Controller
    {
        // GET: KeHoachDieuHanhChiTieu
        [Route("phong-dieu-khien/ke-hoach-dieu-hanh-chi-tieu")]
        public ActionResult Index()
        {
            ViewBag.thisyear = DateTime.Now.Year;
            return View("/Views/DK/KeHoachDieuHanhChiTieu.cshtml");
        }

        public ActionResult GetData(string yearStr)
        {
            int yearNum;
            try
            {
                yearNum = int.Parse(yearStr);
                DateTime dateNow = DateTime.Now;
                //DateTime dateNumberNow = DateTime.Now.Date;
                string queryTC = @"select t.MaTieuChi,n.MaNhomTieuChi,t.TenTieuChi,n.TenNhomTieuChi from TieuChi t inner join NhomTieuChi n on t.MaNhomTieuChi = n.MaNhomTieuChi order by n.MaNhomTieuChi";

                //string queryYear = @"select TieuChi.MaTieuChi,TieuChi.TenTieuChi, 
                //                    (case when table3.TongSLKH is NULL then 0 else table3.TongSLKH end) as TongSLKH,
                //                    (case when table3.LKDenThang1 is NULL then 0 else table3.LKDenThang1 end) as LKDenThang1,
                //                    (case when table3.BQConLai1Thang is NULL then 0 else table3.BQConLai1Thang end) as BQConLai1Thang from (									
                //                    select table1.MaTieuChi,TongSLKH,TongThucHien as LKDenThang1, ROUND((TongSLKH - TongThucHien),0) as BQConLai1Thang , table1.Nam
                //                    from (select a.HeaderID,a.MaTieuChi, b.Nam ,sum(a.SanLuongKeHoach) as TongSLKH from KeHoach_TieuChi_TheoNam as a INNER JOIN
                //                    (select table1a.HeaderID, table1a.MaTieuChi, table1a.Nam, max(table1a.ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung from
                //                    (select k.HeaderID, k.MaTieuChi, hk.Nam, k.ThoiGianNhapCuoiCung from header_KeHoach_TieuChi_TheoNam hk inner join KeHoach_TieuChi_TheoNam k
                //                    on hk.HeaderID = k.HeaderID) table1a group by table1a.HeaderID, table1a.MaTieuChi, table1a.Nam) b ON a.ThoiGianNhapCuoiCung = b.ThoiGianNhapCuoiCung and a.HeaderID = b.HeaderID 
                //                    and a.MaTieuChi = b.MaTieuChi group by a.MaTieuChi,a.HeaderID,b.Nam) as table1 FULL OUTER JOIN 
                //                    (SELECT dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi, sum(dbo.ThucHien_TieuChi_TheoNgay.SanLuong) as TongThucHien
                //                    FROM dbo.ThucHien_TieuChi_TheoNgay INNER JOIN
                //                    dbo.header_ThucHienTheoNgay ON dbo.ThucHien_TieuChi_TheoNgay.HeaderID = dbo.header_ThucHienTheoNgay.HeaderID INNER JOIN
                //                    dbo.ThucHienTheoNgay ON dbo.header_ThucHienTheoNgay.NgayID = dbo.ThucHienTheoNgay.NgayID INNER JOIN
                //                    dbo.TieuChi ON dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi = dbo.TieuChi.MaTieuChi
                //                    where month(dbo.ThucHienTheoNgay.Ngay) = 1 and year(dbo.ThucHienTheoNgay.Ngay) = @year
                //                    group by dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi,dbo.TieuChi.TenTieuChi) as table2
                //                    on table1.MaTieuChi = table2.MaTieuChi) as table3 INNER JOIN TieuChi 
                //                    on table3.MaTieuChi = TieuChi.MaTieuChi
                //                    where table3.Nam = @year";

                string queryYear = @"select TieuChi.MaTieuChi,TieuChi.TenTieuChi, table3.Nam,
                                    (case when table3.TongSLKH is NULL then 0 else table3.TongSLKH end) as TongSLKH,
                                    (case when table3.LKDenThang1 is NULL then 0 else table3.LKDenThang1 end) as LKDenThang1,
                                    (case when table3.BQConLai1Thang is NULL then 0 else table3.BQConLai1Thang end) as BQConLai1Thang from (									
                                    select 
									(case when table1.MaTieuChi is NULL then table2.MaTieuChi else table1.MaTieuChi end) as MaTieuChi,
									(case when table1.Nam is NULL then table2.Nam else table1.Nam end) as Nam,
									TongSLKH,TongThucHien as LKDenThang1, ROUND((TongSLKH - TongThucHien),0) as BQConLai1Thang from (
									select a.HeaderID,a.MaTieuChi, b.Nam ,sum(a.SanLuongKeHoach) as TongSLKH from KeHoach_TieuChi_TheoNam as a INNER JOIN
                                    (select table1a.HeaderID, table1a.MaTieuChi, table1a.Nam, max(table1a.ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung from
                                    (select k.HeaderID, k.MaTieuChi, hk.Nam, k.ThoiGianNhapCuoiCung from header_KeHoach_TieuChi_TheoNam hk inner join KeHoach_TieuChi_TheoNam k
                                    on hk.HeaderID = k.HeaderID) table1a group by table1a.HeaderID, table1a.MaTieuChi, table1a.Nam) b ON a.ThoiGianNhapCuoiCung = b.ThoiGianNhapCuoiCung and a.HeaderID = b.HeaderID 
                                    and a.MaTieuChi = b.MaTieuChi group by a.MaTieuChi,a.HeaderID,b.Nam) as table1 
									FULL OUTER JOIN
                                    (SELECT dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi, sum(dbo.ThucHien_TieuChi_TheoNgay.SanLuong) as TongThucHien, year(dbo.ThucHienTheoNgay.Ngay) as Nam
									FROM dbo.ThucHien_TieuChi_TheoNgay INNER JOIN
									dbo.header_ThucHienTheoNgay ON dbo.ThucHien_TieuChi_TheoNgay.HeaderID = dbo.header_ThucHienTheoNgay.HeaderID INNER JOIN
									dbo.ThucHienTheoNgay ON dbo.header_ThucHienTheoNgay.NgayID = dbo.ThucHienTheoNgay.NgayID INNER JOIN
									dbo.TieuChi ON dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi = dbo.TieuChi.MaTieuChi
									where month(dbo.ThucHienTheoNgay.Ngay) = 1 and year(dbo.ThucHienTheoNgay.Ngay) = @year
									group by dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi,dbo.TieuChi.TenTieuChi , year(dbo.ThucHienTheoNgay.Ngay)) as table2
                                    on table1.MaTieuChi = table2.MaTieuChi) as table3 INNER JOIN TieuChi 
                                    on table3.MaTieuChi = TieuChi.MaTieuChi where table3.Nam = @year ";

                //string queryMonth = @"select ThangKeHoach,MaTieuChi,TenTieuChi,KeHoachThang,SL, ROUND((KeHoachThang - SL) ,0) as BQConLai1Ngay from
                //                    (SELECT sum(SanLuong) as KeHoachThang ,dbo.KeHoachTungThang.ThangKeHoach,dbo.header_KeHoachTungThang.ThangID
                //                    FROM dbo.KeHoach_TieuChi_TheoThang INNER JOIN
                //                    dbo.header_KeHoachTungThang ON dbo.KeHoach_TieuChi_TheoThang.HeaderID = dbo.header_KeHoachTungThang.HeaderID INNER JOIN
                //                    dbo.KeHoachTungThang ON dbo.header_KeHoachTungThang.ThangID = dbo.KeHoachTungThang.ThangID INNER JOIN
                //                    dbo.TieuChi ON dbo.KeHoach_TieuChi_TheoThang.MaTieuChi = dbo.TieuChi.MaTieuChi INNER JOIN
                //                    dbo.Department ON dbo.header_KeHoachTungThang.MaPhongBan = dbo.Department.department_id
                //                    where dbo.KeHoachTungThang.NamKeHoach = @year
                //                    group by dbo.header_KeHoachTungThang.ThangID,dbo.KeHoachTungThang.ThangKeHoach) as table3
                //                    inner join 
                //                    (SELECT dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi,dbo.TieuChi.TenTieuChi, sum(dbo.ThucHien_TieuChi_TheoNgay.SanLuong) as SL , month(dbo.ThucHienTheoNgay.Ngay) as ThangX
                //                    FROM dbo.ThucHien_TieuChi_TheoNgay INNER JOIN
                //                    dbo.header_ThucHienTheoNgay ON dbo.ThucHien_TieuChi_TheoNgay.HeaderID = dbo.header_ThucHienTheoNgay.HeaderID INNER JOIN
                //                    dbo.ThucHienTheoNgay ON dbo.header_ThucHienTheoNgay.NgayID = dbo.ThucHienTheoNgay.NgayID INNER JOIN
                //                    dbo.TieuChi ON dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi = dbo.TieuChi.MaTieuChi
                //                    where dbo.ThucHienTheoNgay.Ngay < @date
                //                    group by dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi,dbo.TieuChi.TenTieuChi ,month(dbo.ThucHienTheoNgay.Ngay)) as table4
                //                    on table3.ThangKeHoach = table4.ThangX
                //                    order by ThangKeHoach";
                string queryMonth = @"select ThangKeHoach,table3.MaTieuChi,TenTieuChi,KeHoachThang,SL, ROUND((KeHoachThang - SL) ,0) as BQConLai1Ngay from
                                    (select sum(a.SanLuong) as KeHoachThang, a.ThangKeHoach,a.MaTieuChi from(
									SELECT DISTINCT SanLuong,t.MaTieuChi,khtt.ThangKeHoach ,
									FIRST_VALUE(ThoiGianNhapCuoiCung) OVER (PARTITION BY t.MaTieuChi,khtt.ThangKeHoach ORDER BY khtt.ThangKeHoach) as ThoiGianNhapCuoiCung
									FROM dbo.KeHoach_TieuChi_TheoThang ktt INNER JOIN
                                    dbo.header_KeHoachTungThang hktt ON ktt.HeaderID = hktt.HeaderID INNER JOIN
                                    dbo.KeHoachTungThang khtt ON hktt.ThangID = khtt.ThangID INNER JOIN
                                    dbo.TieuChi t ON ktt.MaTieuChi = t.MaTieuChi
									where khtt.NamKeHoach = @year) a
									group by a.ThangKeHoach,a.MaTieuChi) as table3
                                    inner join 
                                    
									(SELECT dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi,dbo.TieuChi.TenTieuChi, sum(dbo.ThucHien_TieuChi_TheoNgay.SanLuong) as SL , month(dbo.ThucHienTheoNgay.Ngay) as ThangX
                                    FROM dbo.ThucHien_TieuChi_TheoNgay INNER JOIN
                                    dbo.header_ThucHienTheoNgay ON dbo.ThucHien_TieuChi_TheoNgay.HeaderID = dbo.header_ThucHienTheoNgay.HeaderID INNER JOIN
                                    dbo.ThucHienTheoNgay ON dbo.header_ThucHienTheoNgay.NgayID = dbo.ThucHienTheoNgay.NgayID INNER JOIN
                                    dbo.TieuChi ON dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi = dbo.TieuChi.MaTieuChi
                                    where dbo.ThucHienTheoNgay.Ngay < @date
                                    group by dbo.ThucHien_TieuChi_TheoNgay.MaTieuChi,dbo.TieuChi.TenTieuChi ,month(dbo.ThucHienTheoNgay.Ngay)) as table4
                                    on table3.ThangKeHoach = table4.ThangX and table3.MaTieuChi = table4.MaTieuChi
                                    order by ThangKeHoach";

                string queryDateWorkingInfo = @"select ThangKeHoach, (SoNgayLamViec - NgaySanXuat) as SoNgayConLai, NgayCuoi from 
                                            (select ThangKeHoach,SoNgayLamViec from KeHoachTungThang where NamKeHoach = 2020) as tb3
                                            inner join 
                                            (select day(Ngay) as NgayCuoi ,NgaySanXuat,month(Ngay) as Thang from ThucHienTheoNgay tb1 inner join 
                                            (select max(Ngay) as lastdate from ThucHienTheoNgay
                                            where year(Ngay) = @year and Ngay <= @date
                                            group by month(Ngay)) as tb2 on tb1.Ngay = tb2.lastdate) as tb4
                                            on tb3.ThangKeHoach = tb4.Thang";
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    List <TCEntities> listTC = db.Database.SqlQuery<TCEntities>(queryTC).ToList();
                    List <displayTC> listTCdisplay = new List<displayTC>();
                    List <CriteriaYear> listYear = db.Database.SqlQuery<CriteriaYear>(queryYear, new SqlParameter("year", yearNum)).ToList();
                    List <CriteriaMonth> listMonth = db.Database.SqlQuery<CriteriaMonth>(queryMonth
                        , new SqlParameter("year", yearNum)
                        , new SqlParameter("date", dateNow)).ToList();
                    List <DateWorkingInfo> listInfo = db.Database.SqlQuery<DateWorkingInfo>(queryDateWorkingInfo
                        , new SqlParameter("year", yearNum)
                        , new SqlParameter("date", dateNow)).ToList();
                    handlingDisplayTC(listTC, listTCdisplay);

                    //update yearNum
                    ViewBag.thisyear = yearNum;
                    return Json(new { success = true, listInfo = listInfo ,listYear = listYear , listMonth = listMonth , listTC = listTCdisplay, year = yearNum}, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        private void handlingDisplayTC(List<TCEntities> listTC, List<displayTC> listTCdisplay)
        {
            int oldGroupCriteria = 0;
            int TT = 1;
            int smallTT = 1;
            //add fixed data.
            
            string[] specialCase = new string[] {"Than SX","Than Hầm Lò", "Than Lộ Thiên","Đất Đá Bóc","Nhập Dương Huy", "Mét Lò Đào", "Mét Lò Neo", "Mét Lò Xén", "Doanh Thu", "Đá Xít Sau Sàng Tuyển" };
            listTCdisplay.Add(new displayTC("1", specialCase[0], 1));

            foreach (TCEntities item in listTC)
            {
                //displayTC newDisplayTC = new displayTC();
                //handling case ThanSX.
                if (item.TenNhomTieuChi.Equals(specialCase[1]) || item.TenNhomTieuChi.Equals(specialCase[2]))
                {
                    //compare new with oldGroupCrit.

                    //diff => addGroupCrit 
                    if (item.MaNhomTieuChi != oldGroupCriteria)
                    {
                        //addGroupCrit 
                        displayTC newDisplayTC = new displayTC();
                        newDisplayTC.TT = "" + TT + "." + (smallTT++); 
                        newDisplayTC.HangTieuChi = 2;
                        newDisplayTC.NoiDung = item.TenNhomTieuChi;

                        displayTC newDisplayTC2 = new displayTC();
                        newDisplayTC2.TT = "-";
                        newDisplayTC2.HangTieuChi = 3;
                        newDisplayTC2.NoiDung = item.TenTieuChi;
                        newDisplayTC2.MaTieuChi = item.MaTieuChi;

                        listTCdisplay.Add(newDisplayTC);
                        listTCdisplay.Add(newDisplayTC2);
                    } 
                    else
                    // equal => addCrit
                    {
                        displayTC newDisplayTC = new displayTC();
                        newDisplayTC.TT = "-";
                        newDisplayTC.HangTieuChi = 3;
                        newDisplayTC.NoiDung = item.TenTieuChi;
                        newDisplayTC.MaTieuChi = item.MaTieuChi;
                        listTCdisplay.Add(newDisplayTC);
                    }
                } 
                else if (item.TenNhomTieuChi.Equals(specialCase[9]) || item.TenNhomTieuChi.Equals(specialCase[3]) || item.TenNhomTieuChi.Equals(specialCase[4])
                    || item.TenNhomTieuChi.Equals(specialCase[5]) || item.TenNhomTieuChi.Equals(specialCase[6]) || item.TenNhomTieuChi.Equals(specialCase[7])
                    || item.TenNhomTieuChi.Equals(specialCase[8]))
                {
                     displayTC newDisplayTC = new displayTC();
                     TT += 1;
                     smallTT = 1;
                     newDisplayTC.TT = "" + TT;
                     newDisplayTC.HangTieuChi = 1;
                     newDisplayTC.NoiDung = item.TenNhomTieuChi;
                     listTCdisplay.Add(newDisplayTC);
                } 
                else 
                {
                    //compare new with oldGroupCrit.
                    if (item.MaNhomTieuChi != oldGroupCriteria)
                    {
                        //addGroupCrit 
                        displayTC newDisplayTC = new displayTC();
                        TT += 1;
                        smallTT = 1;
                        newDisplayTC.TT = "" + TT ;
                        newDisplayTC.HangTieuChi = 1;
                        newDisplayTC.NoiDung = item.TenNhomTieuChi;

                        displayTC newDisplayTC2 = new displayTC();
                        newDisplayTC2.TT = "" + TT + "." + (smallTT++);
                        newDisplayTC2.HangTieuChi = 2;
                        newDisplayTC2.NoiDung = item.TenTieuChi;
                        newDisplayTC2.MaTieuChi = item.MaTieuChi;

                        listTCdisplay.Add(newDisplayTC);
                        listTCdisplay.Add(newDisplayTC2);
                    } 
                    else
                    {
                        displayTC newDisplayTC = new displayTC();
                        newDisplayTC.TT = "" + TT + "." + (smallTT++);
                        newDisplayTC.HangTieuChi = 2;
                        newDisplayTC.NoiDung = item.TenTieuChi;
                        newDisplayTC.MaTieuChi = item.MaTieuChi;
                        listTCdisplay.Add(newDisplayTC);
                    }
                }
                oldGroupCriteria = (int)item.MaNhomTieuChi;
            }
        }

        [Route("phong-dieu-khien/ke-hoach-dieu-hanh-chi-tieu/lay-du-lieu")]
        public ActionResult ProcessRequest()
        {
            string year = Request["year"];
            return GetData(year);
        }

        
    }
    public class CriteriaYear
    {
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public double TongSLKH { get; set; }
        public double LKDenThang1 { get; set; }
        public double BQConLai1Thang { get; set; }
    }

    public class CriteriaMonth
    {
        public int ThangKeHoach { get; set; }
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        //
        public double KeHoachThang { get; set; }
        public double SL { get; set; }
        public double BQConLai1Ngay { get; set; }
    }
    public class DateWorkingInfo
    {
        public int ThangKeHoach { get; set; }
        public int SoNgayConLai { get; set; }
        public int NgayCuoi { get; set; }
    }

    public class TCEntities : TieuChi
    {
        public string TenNhomTieuChi { get; set; }
    }

    public class displayTC
    {
        public displayTC()
        {

        }

        public displayTC(string TT,string NoiDung,int HangTieuChi)
        {
            this.TT = TT;
            this.NoiDung = NoiDung;
            this.HangTieuChi = HangTieuChi;
        }
        public string TT { get; set; }
        public string NoiDung { get; set; }
        public int HangTieuChi { get; set; }
        public int MaTieuChi { get; set; }
    }
}