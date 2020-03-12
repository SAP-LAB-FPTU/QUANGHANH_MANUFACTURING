using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;
using QUANGHANHCORE.Controllers.CDVT.Suco;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.BGD
{
    public class SummaryReportController : Controller
    {
        //public class reportEntity
        //{
        //    public int MaTieuChi { get; set; }
        //    public string TenTieuChi { get; set; }
        //    public double Ca1 { get; set; }
        //    public double Ca2 { get; set; }
        //    public double Ca3 { get; set; }
        //    public double thuchien { get; set; }
        //    public double KH { get; set; }
        //    public double luyke { get; set; }
        //    public double chenhlech { get; set; }
        //    public double percentage { get; set; }
        //    public double KHDC { get; set; }
        //    public int percentageDC { get; set; }
        //    public int SUM { get; set; }
        //    public int perday { get; set; }

        //    public int BQQHDC { get; set; }
        //    public int vatlieuchong { get; set; }
        //    public int dientichdao { get; set; }
        //    public int bc { get; set; }
        //    public int ct { get; set; }
        //}

        //public class Than
        //{
        //    public int percentMonth { get; set; }
        //    public int percentDay { get; set; }
        //    public double Thuchien { get; set; }
        //    public double Kehoach { get; set; }
        //    public double Luyke { get; set; }
        //    public double KehoachThang { get; set; }
        //    public double Ton { get; set; }
        //}
        //public class ThanLoThien
        //{
        //    public double SanLuong { get; set; }
        //}
        //public class Tainan_Dasboard : TaiNan
        //{
        //    public string Ten { get; set; }
        //}
        //// GET: /<controller>/
        //[Auther(RightID = "005")]
        //[Route("ban-giam-doc")]
        //[HttpPost]
        //public ActionResult GetData(string date)
        //{
        //    return Index(date);

        //}

        //[Auther(RightID = "005")]
        //[Route("ban-giam-doc")]
        //[HttpGet]
        //public ActionResult Index(string date)
        //{
        //    string[] data = new string[4];
        //    if(date != null)
        //    {
        //        data = date.Split('/');
        //        date = data[2] + "-" + data[1] + "-" + data[0];
        //    }
        //    else
        //    {
        //        DateTime d = DateTime.Today;
        //        date = d.ToString("dd/MM/yyyy");
        //        data = date.Split('/');
        //        date = data[2] + "-" + data[1] + "-" + data[0];
        //    }
        //    string[] data_tmp = data;
        //    DateTime timeEnd = Convert.ToDateTime(date);
        //    var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");

        //    string query = @"select d.MaTieuChi, (case when a.thuchien is null then 0 else a.thuchien end) as 'thuchien', b.LUYKE, (case when c.KH is null then 0 else c.KH end) as 'KH', d.KHDC
        //                    from (select a.MaTieuChi, sum(kt.SanLuong) 'KHDC'
        //                      from(select  kt.HeaderID, hkt.MaPhongBan, hkt.ThangKeHoach,kt.MaTieuChi,max(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung'
        //                      from KeHoach_TieuChi_TheoThang kt inner join header_KeHoachTungThang hkt
        //                      on kt.HeaderID = hkt.HeaderID
        //                      where hkt.ThangKeHoach = @month and hkt.NamKeHoach = @year
        //                      group by kt.HeaderID, hkt.MaPhongBan, hkt.ThangKeHoach, kt.MaTieuChi
        //                      ) as a inner join KeHoach_TieuChi_TheoThang kt on a.HeaderID = kt.HeaderID and a.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung and a.MaTieuChi = kt.MaTieuChi
        //                      group by a.MaTieuChi) as d

        //                    join (select MaTieuChi, sum(SanLuong) as 'LUYKE' from ThucHien_TieuChi_TheoNgay as th
        //                      join (select *from header_ThucHienTheoNgay where Ngay between @dateStart and @dateEnd) as h on th.HeaderID = h.HeaderID
        //                      group by MaTieuChi) as b on d.MaTieuChi = b.MaTieuChi

        //                    left outer join (select MaTieuChi, sum(SanLuong) as 'thuchien' from ThucHien_TieuChi_TheoNgay as th
        //                      join (select *from header_ThucHienTheoNgay where Ngay = @date) as h on th.HeaderID = h.HeaderID
        //                      group by MaTieuChi) as a on d.MaTieuChi = a.MaTieuChi

        //                    left outer join  (select a.MaTieuChi, sum(kt.KeHoach) 'KH'
        //                      from(select  kt.HeaderID, hkt.MaPhongBan, hkt.NgayNhapKH,kt.MaTieuChi,max(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung'
        //                      from KeHoach_TieuChi_TheoNgay kt inner join header_KeHoach_TieuChi_TheoNgay hkt
        //                      on kt.HeaderID = hkt.HeaderID
        //                      where convert(date,hkt.NgayNhapKH) = @date
        //                      group by kt.HeaderID, hkt.MaPhongBan, hkt.NgayNhapKH, kt.MaTieuChi
        //                      ) as a inner join KeHoach_TieuChi_TheoNgay kt on a.HeaderID = kt.HeaderID and a.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung and a.MaTieuChi = kt.MaTieuChi
        //                      group by a.MaTieuChi) as c on d.MaTieuChi = c.MaTieuChi

        //                    order by d.MaTieuChi";
        //    QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        //    List<reportEntity> listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("date", date), new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd), new SqlParameter("month", data[1]), new SqlParameter("year", data[2]) ).ToList();

        //    Than Thandaolo = new Than();
        //    Than Thanlothien = new Than();
        //    Than Metlodao = new Than();
        //    Than Metloneo = new Than();
        //    Than Metloxen = new Than();
        //    Than Thantieuthu = new Than();
        //    Than Daxitkho = new Than();
        //    Than Lothien = new Than();
        //    Than Datdaboc = new Than();
        //    foreach (var item in listReport)
        //    {
        //        //than dao lo
        //        if(item.MaTieuChi == 1 || item.MaTieuChi == 2)
        //        {
        //            Thandaolo.Thuchien += item.thuchien;
        //            Thandaolo.Kehoach += item.KH;

        //            Thandaolo.Luyke += item.luyke;
        //            Thandaolo.KehoachThang += item.KHDC;
        //        }

        //        //than lo thien
        //        if(item.MaTieuChi == 3 || item.MaTieuChi == 4)
        //        {
        //            Thanlothien.Thuchien += item.thuchien;
        //            Thanlothien.Kehoach += item.KH;

        //            Thanlothien.Luyke += item.luyke;
        //            Thanlothien.KehoachThang += item.KHDC;
        //        }

        //        //dat da boc
        //        if (item.MaTieuChi == 5)
        //        {
        //            Datdaboc.Thuchien += item.thuchien;
        //            Datdaboc.Kehoach += item.KH;

        //            Datdaboc.Luyke += item.luyke;
        //            Datdaboc.KehoachThang += item.KHDC;
        //        }

        //        //met lo dao
        //        if (item.MaTieuChi == 7)
        //        {
        //            Metlodao.Thuchien += item.thuchien;
        //            Metlodao.Kehoach += item.KH;

        //            Metlodao.Luyke += item.luyke;
        //            Metlodao.KehoachThang += item.KHDC;
        //        }

        //        //met lo neo
        //        if (item.MaTieuChi == 9)
        //        {
        //            Metloneo.Thuchien += item.thuchien;
        //            Metloneo.Kehoach += item.KH;

        //            Metloneo.Luyke += item.luyke;
        //            Metloneo.KehoachThang += item.KHDC;
        //        }

        //        //met lo xen
        //        if (item.MaTieuChi == 19)
        //        {
        //            Metloxen.Thuchien += item.thuchien;
        //            Metloxen.Kehoach += item.KH;

        //            Metloxen.Luyke += item.luyke;
        //            Metloxen.KehoachThang += item.KHDC;
        //        }

        //        //than tieu thu
        //        if (item.MaTieuChi >= 21 && item.MaTieuChi <= 29)
        //        {
        //            Thantieuthu.Thuchien += item.thuchien;
        //            Thantieuthu.Kehoach += item.KH;

        //            Thantieuthu.Luyke += item.luyke;
        //            Thantieuthu.KehoachThang += item.KHDC;
        //        }

        //        //da xit kho
        //        if (item.MaTieuChi == 18)
        //        {
        //            Daxitkho.Thuchien += item.thuchien;
        //            Daxitkho.Kehoach += item.KH;

        //            Daxitkho.Luyke += item.luyke;
        //            Daxitkho.KehoachThang += item.KHDC;
        //        }
        //    }

        //    //than dao lo
        //    Thandaolo.Ton = Thandaolo.KehoachThang - Thandaolo.Luyke;
        //    if (Thandaolo.Kehoach != 0) Thandaolo.percentDay = Convert.ToInt32(Thandaolo.Thuchien / Thandaolo.Kehoach * 100);
        //    else Thandaolo.percentDay = 0;
        //    if (Thandaolo.KehoachThang != 0) Thandaolo.percentMonth = Convert.ToInt32(Thandaolo.Luyke / Thandaolo.KehoachThang * 100);
        //    else Thandaolo.percentMonth = 0;
        //    ViewBag.tdl = Thandaolo;

        //    //than lo thien
        //    Thanlothien.Ton = Thanlothien.KehoachThang - Thanlothien.Luyke;
        //    if (Thanlothien.Kehoach != 0) Thanlothien.percentDay = Convert.ToInt32(Thanlothien.Thuchien / Thanlothien.Kehoach * 100);
        //    else Thanlothien.percentDay = 0;
        //    if (Thanlothien.KehoachThang != 0) Thanlothien.percentMonth = Convert.ToInt32(Thanlothien.Luyke / Thanlothien.KehoachThang * 100);
        //    else Thanlothien.percentMonth = 0;
        //    ViewBag.tlt = Thanlothien;

        //    //met lo dao
        //    Metlodao.Ton = Metlodao.KehoachThang - Metlodao.Luyke;
        //    if (Metlodao.Kehoach != 0) Metlodao.percentDay = Convert.ToInt32(Metlodao.Thuchien / Metlodao.Kehoach * 100);
        //    else Metlodao.percentDay = 0;
        //    if (Metlodao.KehoachThang != 0) Metlodao.percentMonth = Convert.ToInt32(Metlodao.Luyke / Metlodao.KehoachThang * 100);
        //    else Metlodao.percentMonth = 0;
        //    ViewBag.mld = Metlodao;

        //    //met lo neo
        //    Metloneo.Ton = Metloneo.KehoachThang - Metloneo.Luyke;
        //    if (Metloneo.Kehoach != 0) Metloneo.percentDay = Convert.ToInt32(Metloneo.Thuchien / Metloneo.Kehoach * 100);
        //    else Metloneo.percentDay = 0;
        //    if (Metloneo.KehoachThang != 0) Metloneo.percentMonth = Convert.ToInt32(Metloneo.Luyke / Metloneo.KehoachThang * 100);
        //    else Metloneo.percentMonth = 0;
        //    ViewBag.mln = Metloneo;

        //    //met lo xen
        //    Metloxen.Ton = Metloxen.KehoachThang - Metloxen.Luyke;
        //    if (Metloxen.Kehoach != 0) Metloxen.percentDay = Convert.ToInt32(Metloxen.Thuchien / Metloxen.Kehoach * 100);
        //    else Metloxen.percentDay = 0;
        //    if (Metloxen.KehoachThang != 0) Metloxen.percentMonth = Convert.ToInt32(Metloxen.Luyke / Metloxen.KehoachThang * 100);
        //    else Metloxen.percentMonth = 0;
        //    ViewBag.mlx = Metloxen;

        //    //than tieu thu
        //    Thantieuthu.Ton = Thantieuthu.KehoachThang - Thantieuthu.Luyke;
        //    if (Thantieuthu.Kehoach != 0) Thantieuthu.percentDay = Convert.ToInt32(Thantieuthu.Thuchien / Thantieuthu.Kehoach * 100);
        //    else Thantieuthu.percentDay = 0;
        //    if (Thantieuthu.KehoachThang != 0) Thantieuthu.percentMonth = Convert.ToInt32(Thantieuthu.Luyke / Thantieuthu.KehoachThang * 100);
        //    else Thantieuthu.percentMonth = 0;
        //    ViewBag.ttt = Thantieuthu;

        //    //da xit kho
        //    Daxitkho.Ton = Daxitkho.KehoachThang - Daxitkho.Luyke;
        //    if (Daxitkho.Kehoach != 0) Daxitkho.percentDay = Convert.ToInt32(Daxitkho.Thuchien / Daxitkho.Kehoach * 100);
        //    else Daxitkho.percentDay = 0;
        //    if (Daxitkho.KehoachThang != 0) Daxitkho.percentMonth = Convert.ToInt32(Daxitkho.Luyke / Daxitkho.KehoachThang * 100);
        //    else Daxitkho.percentMonth = 0;
        //    ViewBag.dxk = Daxitkho;
        //    //dat da boc
        //    Datdaboc.Ton = Datdaboc.KehoachThang - Datdaboc.Luyke;
        //    if (Datdaboc.Kehoach != 0) Datdaboc.percentDay = Convert.ToInt32(Datdaboc.Thuchien / Datdaboc.Kehoach * 100);
        //    else Datdaboc.percentDay = 0;
        //    if (Datdaboc.KehoachThang != 0) Datdaboc.percentMonth = Convert.ToInt32(Datdaboc.Luyke / Datdaboc.KehoachThang * 100);
        //    else Datdaboc.percentMonth = 0;
        //    ViewBag.ddb = Datdaboc;

        //    //sự cố
        //    string[] data2 = date.Split('-');
        //    string sql = "SELECT e.equipment_name, d.department_name, i.*, DATEDIFF(HOUR, i.start_time, i.end_time) as time_different " +
        //                    " FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId " +
        //                    "                 inner join Department d on d.department_id = i.department_id " +
        //                    " where YEAR(i.start_time) = '" + data2[0] + "' and MONTH(i.start_time) = '" + data2[1] + "' and DAY(i.start_time) = '" + data2[2] + "'";
        //    List<IncidentDB> list = db.Database.SqlQuery<IncidentDB>(sql).ToList();

        //    ViewBag.listSC = list;
        //    ViewBag.listSCCount = list.Count();

        //    //tai nạn
        //    string sql_tainan = " SELECT NhanVien.MaNV, NhanVien.Ten, TaiNan.LyDo, TaiNan.Ngay, TaiNan.Loai " +
        //                        " FROM NhanVien INNER JOIN TaiNan ON NhanVien.MaNV = TaiNan.MaNV " +
        //                        " where YEAR(TaiNan.Ngay) = '" + data2[0] + "' and MONTH(TaiNan.Ngay) = '" + data2[1] + "' and DAY(TaiNan.Ngay) = '" + data2[2] + "'";
        //   List<Tainan_Dasboard> list_tainan = db.Database.SqlQuery<Tainan_Dasboard>(sql_tainan).ToList();

        //    ViewBag.listTN = list_tainan;
        //    ViewBag.listTNCount = list_tainan.Count();
        //    string day_dashboard = data2[2] + "/" + data2[1] + "/" + data2[0];
        //    ViewBag.d = day_dashboard;

        //    //lộ thiên
        //    string sql_LTTL = "select top 1 SanLuong from KeHoach_TieuChi_TheoThang " +
        //                      " where MaTieuChi = 3 AND YEAR(ThoiGianNhapCuoiCung) = '" + data2[0] + "' and MONTH(ThoiGianNhapCuoiCung) = '" + data2[1] + "' and DAY(ThoiGianNhapCuoiCung) = '" + data2[2] + "'"+
        //                      " order by ThoiGianNhapCuoiCung DESC ";
        //    ThanLoThien LTTL = new ThanLoThien();
        //    LTTL = db.Database.SqlQuery<ThanLoThien>(sql_LTTL).FirstOrDefault<ThanLoThien>();
        //    string sql_LTTN = "select top 1 SanLuong from KeHoach_TieuChi_TheoThang " +
        //                   " where MaTieuChi = 4 AND YEAR(ThoiGianNhapCuoiCung) = '" + data2[0] + "' and MONTH(ThoiGianNhapCuoiCung) = '" + data2[1] + "' and DAY(ThoiGianNhapCuoiCung) = '" + data2[2] + "'" +
        //                   " order by ThoiGianNhapCuoiCung DESC ";
        //    ThanLoThien LTTN = new ThanLoThien();
        //    LTTN = db.Database.SqlQuery<ThanLoThien>(sql_LTTL).FirstOrDefault<ThanLoThien>();
        //    string sql_DDB = "select top 1 SanLuong from KeHoach_TieuChi_TheoThang " +
        //                 " where MaTieuChi = 5 AND YEAR(ThoiGianNhapCuoiCung) = '" + data2[0] + "' and MONTH(ThoiGianNhapCuoiCung) = '" + data2[1] + "' and DAY(ThoiGianNhapCuoiCung) = '" + data2[2] + "'" +
        //                 " order by ThoiGianNhapCuoiCung DESC ";
        //    ThanLoThien DDB = new ThanLoThien();
        //    DDB = db.Database.SqlQuery<ThanLoThien>(sql_LTTL).FirstOrDefault<ThanLoThien>();
        //    double heso = 0;
        //    if(DDB != null && LTTL != null && LTTN != null)
        //    {
        //        if ((LTTL.SanLuong + LTTN.SanLuong) != 0)
        //        {
        //            heso = DDB.SanLuong / (LTTL.SanLuong + LTTN.SanLuong);
        //        }
        //    }

        //    double DDBTH = Lothien.Thuchien * heso;
        //    //da dat boc
        //    Lothien.Ton = Lothien.KehoachThang - Lothien.Luyke;
        //    if (Lothien.Kehoach != 0) Lothien.percentDay = Convert.ToInt32(DDBTH / Lothien.Kehoach * 100);
        //    else Lothien.percentDay = 0;
        //    if (Lothien.KehoachThang != 0) Lothien.percentMonth = Convert.ToInt32(Lothien.Luyke / Lothien.KehoachThang * 100);
        //    else Lothien.percentMonth = 0;

        //    string sql_chart = "select a.MaPhongBan " +
        //                "	,(a.KT1 + a.KT2 + a.KT3 + a.CD1 + a.CD2 + a.CD3 + a.QL1 + a.QL2 + a.QL3) as 'dilam' " +
        //                "	,(b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) as 'nghi' " +
        //                "from (select n.MaPhongBan  "+
        //                ", sum(case when nc.MaNhomCongViec = 6 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'KT1' "+
        //                ", SUM(case when nc.MaNhomCongViec = 7 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'CD1' " +
        //                ", SUM(case when nc.MaNhomCongViec = 10 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'QL1' " +
        //                ", sum(case when nc.MaNhomCongViec = 6 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'KT2' " +
        //                ", SUM(case when nc.MaNhomCongViec = 7 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'CD2' " +
        //                ", SUM(case when nc.MaNhomCongViec = 10 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'QL2' " +
        //                ", sum(case when nc.MaNhomCongViec = 6 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'KT3' " +
        //                ", SUM(case when nc.MaNhomCongViec = 7 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'CD3' " +
        //                ", SUM(case when nc.MaNhomCongViec = 10 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'QL3' " +
        //                ", count(n.MaNV) as 'tong_DS', sum(case when nc.MaNhomCongViec = 3 then 1 else 0 end) as 'QL_CTy' " +
        //                "from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID " +
        //                "    inner join CongViec c on n.MaCongViec = c.MaCongViec " +
        //                "    inner join CongViec_NhomCongViec nc on c.MaCongViec = nc.MaCongViec" +
        //                "   inner join NhomCongViec ncv on nc.MaNhomCongViec = ncv.MaNhomCongViec " +
        //                "where h.NgayDiemDanh = @day group by n.MaPhongBan) a full join  " +
        //                "	(select n.MaPhongBan " +
        //                "	, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'vld1'    " +
        //                "	, sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'om1'    " +
        //                "	, SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'p1'  " +
        //                "	, SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'khac1'    " +
        //                "	, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'vld2'    " +
        //                "	, sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'om2'    " +
        //                "	, SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'p2'  " +
        //                "	, SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'khac2'    " +
        //                "	, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'vld3'    " +
        //                "	, sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'om3'    " +
        //                "	, SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'p3'  " +
        //                "	, SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'khac3'    " +
        //                "	, SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') then 1 else 0 end) as 'tong_nghidai'  " +
        //                "	from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID  " +
        //                "	where h.NgayDiemDanh = @day group by n.MaPhongBan) b on a.MaPhongBan = b.MaPhongBan " +
        //                "	where a.MaPhongBan in ('PXDL3', 'PXDL5', 'PXDL7', 'PXDL8', 'PXKT1', 'PXKT2', 'PXKT3', 'PXKT4', 'PXKT5', 'PXKT6', 'PXKT7', 'PXKT8', 'PXKT9', 'PXKT10', 'PXKT11', 'PXVT1', 'PXVT2') " +
        //                "	order by a.MaPhongBan";
        //    List<chart> list_chart = db.Database.SqlQuery<chart>(sql_chart, new SqlParameter("day", date)).ToList();
        //    List<string> donvi = new List<string> { "PXDL3", "PXDL5", "PXDL7", "PXDL8", "PXKT1", "PXKT2", "PXKT3", "PXKT4", "PXKT5", "PXKT6", "PXKT7", "PXKT8", "PXKT9", "PXKT10", "PXKT11", "PXVT1", "PXVT2" };
        //    string result = JsonConvert.SerializeObject(donvi);
        //    ViewBag.donvi = result;


        //    List<int> dilam = new List<int>();
        //    List<int> nghi = new List<int>();
        //    for (int i = 0; i < donvi.Count(); i++)
        //    {
        //        int temp_dilam = 0;
        //        int temp_nghi = 0;

        //        string temp = donvi[i];
        //        foreach(var item in list_chart)
        //        {
        //            if (item.MaPhongBan.Equals(temp))
        //            {
        //                temp_dilam = item.dilam;
        //                temp_nghi = item.nghi;
        //                break;
        //            }
        //        }
        //        dilam.Add(temp_dilam);
        //        nghi.Add(temp_nghi);

        //    }
        //    string dilam_result = JsonConvert.SerializeObject(dilam);
        //    string nghi_result = JsonConvert.SerializeObject(nghi);
        //    ViewBag.dilam = dilam_result;
        //    ViewBag.nghi = nghi_result;

        //    return View("/Views/BGD/Dashboard.cshtml");
        //}

        //public class chart
        //{
        //    public string MaPhongBan { get; set; }
        //    public int dilam { get; set; }
        //    public int nghi { get; set; }
        //}

        [Auther(RightID = "005")]
        [Route("ban-giam-doc")]
        public ActionResult Dashboard()
        {
            int soLuotHuyDong = 0;
            int vuTaiNan = 0;
            int nghiVLD = 0;
            int hetHanChungChi = 0;
            int tren82 = 0;
            int duoi82 = 0;
            List<NghiVLD> listNghiVLD = new List<NghiVLD>();
            List<NhanLuc> listNhanLuc = new List<NhanLuc>();
            SanLuong sanluong = new SanLuong();
            int temp = 0;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                ////////////////////////////GET so luot huy dong////////////////////////////////
                string sql = "select (case when count(MaQuyetDinh)  is null then 0 else count(MaQuyetDinh) end ) as SoLuotHuyDong from quyetdinh\n" +
                "where maquyetdinh in\n" +
                "(SELECT  distinct dd.MaQuyetDinh FROM DIEUDONG_NHANVIEN dd,QuyetDinh qd where dd.MaQuyetDinh=qd.MaQuyetDinh and qd.SoQuyetDinh<>'' )\n" +
                "AND NgayQuyetDinh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))";
                try
                {
                    temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                    soLuotHuyDong = temp != null ? temp : 0;
                }
                catch (Exception e)
                {

                }
                ////////////////////////////GET SO LUONG TAI NAN///////////////////////////////////////////
                sql = "select (case when Count(tn.MaNV) is null then 0 else Count(tn.MaNV) end )  from \n" +
                      "(select MaNV, Ngay from TaiNan where\n" +
                      "Ngay = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))) as tn";
                try
                {
                    temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                    vuTaiNan = temp != null ? temp : 0;
                }
                catch (Exception e)
                {
                }
                ///////////////////////////////GET SO LUONG HET HAN CC///////////////////////////////////////////
                sql = "select (case when sum(th.st)  is null then 0 else sum(th.st) end ) \n" +
                          "from(select cn.MaNV, cn.NgayCap, cc.ThoiHan, (case\n" +
                          "when DATEADD(MONTH, cc.ThoiHan, cn.NgayCap) <= GETDATE()\n" +
                          "then 1 else 0 end) as st\n" +
                          "from ChungChi_NhanVien cn join ChungChi cc on cn.MaChungChi = cc.MaChungChi) as th";
                try
                {
                    temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                    hetHanChungChi = temp != null ? temp : 0;
                }
                catch (Exception e)
                {

                }
                ////////////////////////////GET SO LUONG NGHI VLD///////////////////////////////////////////
                sql = @"select case when Count(b.MaNV) is null then 0 else count(b.MaNV) end 'SoLuongNhanVien' from Header_DiemDanh_NangSuat_LaoDong a join DiemDanh_NangSuatLaoDong b on a.HeaderID = b.HeaderID
                        where a.NgayDiemDanh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101)) and b.LyDoVangMat = N'Vô lý do'
                        group by a.NgayDiemDanh, b.LyDoVangMat";

                try
                {
                    temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                    nghiVLD = temp != null ? temp : 0;
                }
                catch (Exception e)
                {
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////GET TI LE HUY DONG////////////////////////////////////////
                DateTime currentDate = DateTime.Now.Date.AddDays(-1);
                int currentMonth = currentDate.Month;
                try
                {
                    sql = @"select a.department_id, a.QL, (a.KT + a.CD) as Tong, a.KT, a.CD, 0 as 'HSTT', 
                                a.dilam, (a.vld + a.om + a.khac + a.phep) as vang, 
                                a.vld,a.om,a.phep,a.khac, 
                                (case when (a.KT+ a.CD) = 0 then 0 else round(Convert(float,a.dilam)/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as tile, 
                                b.than, b.metlo, b.xen,b.diemluong,a.tong_nghidai,a.nghidai_om,a.nghidai_thld,a.nghidai_vld 
                                from 
                                (select a.department_id, a.QL, a.KT, a.CD, 
                                sum(case when d.DiLam = 1 and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as dilam, 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'vld', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'om', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'phep', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'khac', 
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'tong_nghidai', 
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_vld', 
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_thld', 
                                SUM(case when d.LyDoVangMat in (N'Ốm dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_om' 
                                 from(select a.department_id, 
                                sum(case when ncv.MaNhomCongViec = 10 then  1 else 0 end) as QL, 
                                sum(case when ncv.MaNhomCongViec = 6 then  1 else 0 end) as KT, 
                                sum(case when ncv.MaNhomCongViec = 7 then  1 else 0 end) as CD 
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id 
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                                where a.department_type like N'%chính%' and (a.department_id like N'%ĐL%' or a.department_id like N'%VTL%' or a.department_id like N'%KT%') 
                                group by a.department_id) 
                                 as a left outer join Header_DiemDanh_NangSuat_LaoDong h 
                                on a.department_id = h.MaPhongBan left outer join DiemDanh_NangSuatLaoDong d 
                                on h.HeaderID = d.HeaderID 
                                group by a.department_id, a.QL, a.KT, a.CD) as a inner join 
                                ( select a.department_id, 
                                sum(case when h.ThanThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.ThanThucHien else 0 end) as 'than', 
                                sum(case when h.MetLoThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.MetLoThucHien else 0 end) as 'metlo', 
                                sum(case when h.XenThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.XenThucHien else 0 end) as 'xen', 
                                sum(case when h.TotalEffort is not null and h.NgayDiemDanh = @NgayDiemDanh then h.TotalEffort else 0 end) as 'diemluong' 
                                from Department a left outer join Header_DiemDanh_NangSuat_LaoDong h 
                                on a.department_id = h.MaPhongBan 
                                group by a.department_id 
                                ) as b on a.department_id = b.department_id";
                    List<BaoCaoNgayDB> listTLHD = db.Database.SqlQuery<BaoCaoNgayDB>(sql, new SqlParameter("NgayDiemDanh", currentDate)).ToList();
                    for (int i = 0; i < listTLHD.Count; i++)
                    {
                        if (listTLHD[i].tile > 82)
                        {
                            tren82++;
                        }
                        else
                        {
                            duoi82++;
                        }
                    }
                }
                catch (Exception e)
                {

                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////GET NV NGHI VLD////////////////////////////////////////
                sql = "select n.MaNV, n.Ten as HoTen,Department.department_name as TenDonVi\n" +
                "from Department, Header_DiemDanh_NangSuat_LaoDong hd inner join DiemDanh_NangSuatLaoDong d\n" +
                "on hd.HeaderID = d.HeaderID and hd.NgayDiemDanh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101)) and d.LyDoVangMat like N'Vô lý do' inner join NhanVien n\n" +
                "on d.MaNV = n.MaNV\n" +
                "where Department.department_id = hd.MaPhongBan";
                try
                {
                    listNghiVLD = db.Database.SqlQuery<NghiVLD>(sql).ToList<NghiVLD>();
                }
                catch (Exception e)
                {
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////GET DATA NHAN LUC////////////////////////////////////////////////
                sql = "select tb1.department_id as MaDonVi,\n" +
                        "(case when tb2.soluong is null then 0 else tb2.soluong end) as SoLuong\n" +
                        "from\n" +
                        "(select * from Department where department_id in\n" +
                        "('KT1', 'KT2', 'KT3', 'KT4', 'KT5', 'KT6', 'KT7', 'KT8', 'KT9', 'KT10', 'KT11',\n" +
                        "'ĐL3', 'ĐL5', 'ĐL7', 'ĐL8', 'VTL1', 'VTL2')) tb1\n" +
                        "left join\n" +
                        "(select hd.MaPhongBan, count(d.MaNV) as soluong from Header_DiemDanh_NangSuat_LaoDong hd inner\n" +
                         "                                               join DiemDanh_NangSuatLaoDong d\n" +
                        "on hd.HeaderID = d.HeaderID\n" +
                        "where hd.NgayDiemDanh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101)) and DiLam = 1\n" +
                        "group by hd.MaPhongBan) tb2\n" +
                        "on tb1.department_id = tb2.MaPhongBan\n" +
                        "group by tb1.department_id,tb2.soluong";
                try
                {
                    listNhanLuc = db.Database.SqlQuery<NhanLuc>(sql).ToList<NhanLuc>();
                }
                catch (Exception e)
                {
                }

                ///////////////////////////////////////GET DATA SAN LUONG///////////////////////////////////////////////
                sql = @"select 
                        convert(float,0,2) as 'SLKH',
                        convert(float,0,2) as 'MLKH',
                        convert(float,sum(case when hd.ThanThucHien is NULL then 0 else hd.ThanThucHien end),2) as 'LKSL', 
                        convert(float,sum(case when hd.MetLoThucHien is NULL then 0 else hd.MetLoThucHien end),2) as 'LKML' 
                        from Header_DiemDanh_NangSuat_LaoDong hd where MONTH(NgayDiemDanh) = @ThangDiemDanh and NgayDiemDanh = @NgayDiemDanh";
                try
                {
                    sanluong = db.Database.SqlQuery<SanLuong>(sql,
                        new SqlParameter("ThangDiemDanh", currentMonth),
                        new SqlParameter("NgayDiemDanh", currentDate)).FirstOrDefault();
                }
                catch (Exception e)
                {

                }

            }

            ViewBag.soLuotHuyDong = soLuotHuyDong;
            ViewBag.hetHanChungChi = hetHanChungChi;
            ViewBag.vuTaiNan = vuTaiNan;
            ViewBag.nghiVLD = nghiVLD;
            ViewBag.tren82 = tren82;
            ViewBag.duoi82 = duoi82;
            ViewBag.listNghiVLD = listNghiVLD;
            ViewBag.listNhanLuc = listNhanLuc;
            ViewBag.sanluong = sanluong;
            return View("/Views/BGD/Dashboard.cshtml");
        }

        /// <summary>
        /// The GetData
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [Route("ban-giam-doc/get-data")]
        [HttpPost]
        public ActionResult GetData()
        {
            try
            {
                string date = Request["date"];
                date = date.Split('/')[2] + "/" + date.Split('/')[1] + "/" + date.Split('/')[0];
                int soLuotHuyDong = 0;
                int vuTaiNan = 0;
                int nghiVLD = 0;
                int hetHanChungChi = 0;
                int tren82 = 0;
                int duoi82 = 0;
                List<NghiVLD> listNghiVLD = new List<NghiVLD>();
                List<NhanLuc> listNhanLuc = new List<NhanLuc>();
                SanLuong sanluong = new SanLuong();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    ////////////////////////////GET so luot huy dong////////////////////////////////

                    db.Configuration.LazyLoadingEnabled = false;
                    string sql = "select (case when count(MaQuyetDinh) is null then 0 else count(MaQuyetDinh) end ) as SoLuotHuyDong from quyetdinh\n" +
                                "where maquyetdinh in\n" +
                                "(SELECT  distinct dd.MaQuyetDinh FROM DIEUDONG_NHANVIEN dd,QuyetDinh qd where dd.MaQuyetDinh=qd.MaQuyetDinh and qd.SoQuyetDinh<>'' )\n" +
                                "AND NgayQuyetDinh = @NgayQuyetDinh";
                    try
                    {
                        soLuotHuyDong = db.Database.SqlQuery<int>(sql,
                                                new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    }
                    catch (Exception e)
                    {

                    }


                    ////////////////////////////GET SO LUONG TAI NAN//////////////////////////////
                    sql = "select (case when Count(tn.MaNV) is null then 0 else Count(tn.MaNV) end )  from \n" +
                          "(select MaNV, Ngay from TaiNan where\n" +
                          "Ngay = @NgayQuyetDinh) as tn";
                    try
                    {
                        vuTaiNan = db.Database.SqlQuery<int>(sql,
                       new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    }
                    catch (Exception e)
                    {

                    }

                    //////////////////////////////////////////////////////////////////////////////

                    /// ////////////////////////////GET SO LUONG HET HAN CC//////////////////////////////
                    sql = "select (case when sum(th.st)  is null then 0 else sum(th.st) end ) \n" +
                          "from(select cn.MaNV, cn.NgayCap, cc.ThoiHan, (case\n" +
                          "when DATEADD(MONTH, cc.ThoiHan, cn.NgayCap) <= @NgayQuyetDinh\n" +
                          "then 1 else 0 end) as st\n" +
                          "from ChungChi_NhanVien cn join ChungChi cc on cn.MaChungChi = cc.MaChungChi) as th";
                    try
                    {
                        hetHanChungChi = db.Database.SqlQuery<int>(sql, new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    }
                    catch (Exception e)
                    {

                    }


                    //////////////////////////////////////////////////////////////////////////////

                    /// ////////////////////////////GET SO LUONG NGHI VLD//////////////////////////////
                    sql = @"select case when Count(b.MaNV) is null then 0 else count(b.MaNV) end 'SoLuongNhanVien' from Header_DiemDanh_NangSuat_LaoDong a join DiemDanh_NangSuatLaoDong b on a.HeaderID = b.HeaderID
                            where a.NgayDiemDanh = (SELECT CONVERT(VARCHAR(10), @NgayDiemDanh, 101)) and b.LyDoVangMat = N'Vô lý do'
                            group by a.NgayDiemDanh, b.LyDoVangMat";
                    try
                    {
                        nghiVLD = db.Database.SqlQuery<int>(sql,
                                        new SqlParameter("NgayDiemDanh", DateTime.Parse(date))).ToList<int>()[0];
                    }
                    catch (Exception e)
                    {

                    }


                    //////////////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////GET TI LE HUY DONG////////////////////////////////////////
                    string tempDate = date.Split('/')[0] + "/" + date.Split('/')[1] + "/" + date.Split('/')[2];
                    try
                    {
                        sql = @"select a.department_id, a.QL, (a.KT + a.CD) as Tong, a.KT, a.CD, 0 as 'HSTT', 
                                a.dilam, (a.vld + a.om + a.khac + a.phep) as vang, 
                                a.vld,a.om,a.phep,a.khac, 
                                (case when (a.KT+ a.CD) = 0 then 0 else round(Convert(float,a.dilam)/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as tile, 
                                b.than, b.metlo, b.xen,b.diemluong,a.tong_nghidai,a.nghidai_om,a.nghidai_thld,a.nghidai_vld 
                                from 
                                (select a.department_id, a.QL, a.KT, a.CD, 
                                sum(case when d.DiLam = 1 and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'dilam', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'vld', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'om', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'phep', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'khac', 
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'tong_nghidai', 
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_vld', 
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_thld', 
                                SUM(case when d.LyDoVangMat in (N'Ốm dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_om' 
                                 from(select a.department_id, 
                                sum(case when ncv.MaNhomCongViec = 10 then  1 else 0 end) as QL, 
                                sum(case when ncv.MaNhomCongViec = 6 then  1 else 0 end) as KT, 
                                sum(case when ncv.MaNhomCongViec = 7 then  1 else 0 end) as CD 
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id 
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                                where a.department_type like N'%chính%' and (a.department_id like N'%ĐL%' or a.department_id like N'%VTL%' or a.department_id like N'%KT%') 
                                group by a.department_id) 
                                 as a left outer join Header_DiemDanh_NangSuat_LaoDong h 
                                on a.department_id = h.MaPhongBan left outer join DiemDanh_NangSuatLaoDong d 
                                on h.HeaderID = d.HeaderID 
                                group by a.department_id, a.QL, a.KT, a.CD) as a inner join 
                                ( select a.department_id, 
                                sum(case when h.ThanThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.ThanThucHien else 0 end) as 'than', 
                                sum(case when h.MetLoThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.MetLoThucHien else 0 end) as 'metlo', 
                                sum(case when h.XenThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.XenThucHien else 0 end) as 'xen', 
                                sum(case when h.TotalEffort is not null and h.NgayDiemDanh = @NgayDiemDanh then h.TotalEffort else 0 end) as 'diemluong' 
                                from Department a left outer join Header_DiemDanh_NangSuat_LaoDong h 
                                on a.department_id = h.MaPhongBan 
                                group by a.department_id 
                                ) as b on a.department_id = b.department_id";
                        List<BaoCaoNgayDB> listTLHD = db.Database.SqlQuery<BaoCaoNgayDB>(sql, new SqlParameter("NgayDiemDanh", tempDate)).ToList();
                        for (int i = 0; i < listTLHD.Count; i++)
                        {
                            if (listTLHD[i].tile >= 82)
                            {
                                tren82++;
                            }
                            else
                            {
                                duoi82++;
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////GET NV NGHI VLD////////////////////////////////////////
                    sql = "select n.MaNV, n.Ten as HoTen,Department.department_name as TenDonVi\n" +
                           "from Department, Header_DiemDanh_NangSuat_LaoDong hd inner join DiemDanh_NangSuatLaoDong d\n" +
                           "on hd.HeaderID = d.HeaderID and hd.NgayDiemDanh = @NgayDiemDanh and d.LyDoVangMat like N'Vô lý do' inner join NhanVien n\n" +
                           "on d.MaNV = n.MaNV\n" +
                           "where Department.department_id = hd.MaPhongBan";
                    try
                    {
                        listNghiVLD = db.Database.SqlQuery<NghiVLD>(sql, new SqlParameter("NgayDiemDanh", date)).ToList<NghiVLD>();
                    }
                    catch (Exception e)
                    {

                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////GET DATA NHAN LUC////////////////////////////////////////////////
                    sql = "select tb1.department_id as MaDonVi,\n" +
                            "(case when tb2.soluong is null then 0 else tb2.soluong end) as SoLuong\n" +
                            "from\n" +
                            "(select * from Department where department_id in\n" +
                            "('KT1', 'KT2', 'KT3', 'KT4', 'KT5', 'KT6', 'KT7', 'KT8', 'KT9', 'KT10', 'KT11',\n" +
                            "'ĐL3', 'ĐL5', 'ĐL7', 'ĐL8', 'VTL1', 'VTL2')) tb1\n" +
                            "left join\n" +
                            "(select hd.MaPhongBan, count(d.MaNV) as soluong from Header_DiemDanh_NangSuat_LaoDong hd inner\n" +
                             "                                               join DiemDanh_NangSuatLaoDong d\n" +
                            "on hd.HeaderID = d.HeaderID\n" +
                            "where hd.NgayDiemDanh = @NgayDiemDanh and DiLam = 1\n" +
                            "group by hd.MaPhongBan) tb2\n" +
                            "on tb1.department_id = tb2.MaPhongBan\n" +
                            "group by tb1.department_id,tb2.soluong";
                    try
                    {
                        listNhanLuc = db.Database.SqlQuery<NhanLuc>(sql, new SqlParameter("NgayDiemDanh", date)).ToList<NhanLuc>();
                    }
                    catch (Exception e)
                    {

                    }
                    ///////////////////////////////////////GET DATA SAN LUONG///////////////////////////////////////////////
                    sql = "select (select (case when sum(tc_kh.SanLuongKeHoach) is null then 0 else sum(tc_kh.SanLuongKeHoach) end) from (select tc.MaTieuChi, tc.DonViDo, kh.SanLuongKeHoach, kh.ThangKeHoach, kh.NamKeHoach from KeHoach_TieuChi kh join TieuChi tc on kh.MaTieuChi = tc.MaTieuChi) as tc_kh where tc_kh.MaTieuChi in (1,2,3,4) and  tc_kh.ThangKeHoach = @Thang1 and tc_kh.NamKeHoach = @Nam1) 'SLKH',\n" +
                        "(select(case when sum(tc_kh.SanLuongKeHoach) is null then 0 else sum(tc_kh.SanLuongKeHoach) end) from(select tc.MaTieuChi, tc.DonViDo, kh.SanLuongKeHoach, kh.ThangKeHoach, kh.NamKeHoach from KeHoach_TieuChi kh join TieuChi tc on kh.MaTieuChi = tc.MaTieuChi) as tc_kh where tc_kh.MaTieuChi in (7, 8) and tc_kh.ThangKeHoach = @Thang2 and tc_kh.NamKeHoach = @Nam2) 'MLKH',\n" +
                        "(select(case when sum(tc_th.SanLuongThucHien) is null then 0 else sum(tc_th.SanLuongThucHien) end) from(select tc.MaTieuChi, tc.DonViDo, th.SanLuongThucHien, th.NgayThucHien from ThucHien_TieuChi th join TieuChi tc on th.MaTieuChi = tc.MaTieuChi) as tc_th where tc_th.MaTieuChi in (1, 2, 3, 4) and MONTH(tc_th.NgayThucHien) = @Thang3  and YEAR(tc_th.NgayThucHien) = @Nam3) 'LKSL',\n" +
                        "(select(case when sum(tc_th.SanLuongThucHien) is null then 0 else sum(tc_th.SanLuongThucHien) end) from(select tc.MaTieuChi, tc.DonViDo, th.SanLuongThucHien, th.NgayThucHien from ThucHien_TieuChi th join TieuChi tc on th.MaTieuChi = tc.MaTieuChi) as tc_th where tc_th.MaTieuChi in (7, 8) and MONTH(tc_th.NgayThucHien) = @Thang4  and YEAR(tc_th.NgayThucHien) = @Nam4) 'LKML'";

                    try
                    {
                        sanluong = db.Database.SqlQuery<SanLuong>(sql,
                                                new SqlParameter("Thang1", date.Split('/')[1]),
                                                new SqlParameter("Thang2", date.Split('/')[1]),
                                                new SqlParameter("Thang3", date.Split('/')[1]),
                                                new SqlParameter("Thang4", date.Split('/')[1]),
                                                new SqlParameter("Nam1", date.Split('/')[0]),
                                                new SqlParameter("Nam2", date.Split('/')[0]),
                                                new SqlParameter("Nam3", date.Split('/')[0]),
                                                new SqlParameter("Nam4", date.Split('/')[0])
                                                ).ToList<SanLuong>()[0];
                    }
                    catch (Exception e)
                    {
                    }
                }
                return Json(new { success = true, tren82 = tren82, duoi82 = duoi82, soLuongHuyDong = soLuotHuyDong, vuTaiNan = vuTaiNan, nghiVLD = nghiVLD, hetHanChungChi = hetHanChungChi, listNghiVLD = listNghiVLD, listNhanLuc = listNhanLuc, sanluong = sanluong }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("ban-giam-doc/bao-cao-nhanh-cong-tac-san-xuat")]
        public ActionResult QuickReportTCLD()
        {
            return View("/Views/BGD/QuickReport/bao-cao-nhanh-tcld.cshtml");
        }

        [Route("ban-giam-doc/bao-cao-nhanh-quan-ly-vat-tu")]
        public ActionResult QuickReportCDVT()
        {
            return View("/Views/BGD/QuickReport/bao-cao-nhanh-cdvt.cshtml");
        }
    }

    public class NhanLuc
    {
        public string MaDonVi { get; set; }
        public int SoLuong { get; set; }
    }
    public class NghiVLD
    {
        /// <summary>
        /// Gets or sets the MaNV
        /// </summary>
        public string MaNV { get; set; }

        /// <summary>
        /// Gets or sets the HoTen
        /// </summary>
        public string HoTen { get; set; }

        /// <summary>
        /// Gets or sets the TenDonVi
        /// </summary>
        public string TenDonVi { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NghiVLD"/> class.
        /// </summary>
        public NghiVLD()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NghiVLD"/> class.
        /// </summary>
        /// <param name="maNV">The maNV<see cref="string"/></param>
        /// <param name="hoTen">The hoTen<see cref="string"/></param>
        /// <param name="tenDonVi">The tenDonVi<see cref="string"/></param>
        public NghiVLD(string maNV, string hoTen, string tenDonVi)
        {
            MaNV = maNV;
            HoTen = hoTen;
            TenDonVi = tenDonVi;
        }

    }

    public class SanLuong
    {
        public double? SLKH { get; set; }
        public double? MLKH { get; set; }
        public double? LKSL { get; set; }
        public double? LKML { get; set; }
    }
}
