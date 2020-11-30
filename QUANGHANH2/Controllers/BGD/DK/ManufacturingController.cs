using Newtonsoft.Json;
using QUANGHANH2.Models;
using QUANGHANHCORE.Controllers.CDVT.Suco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.BGD.DK
{
    public class ManufacturingController : Controller
    {
        public class reportEntity
        {
            public int MaTieuChi { get; set; }
            public string TenTieuChi { get; set; }
            public double Ca1 { get; set; }
            public double Ca2 { get; set; }
            public double Ca3 { get; set; }
            public double thuchien { get; set; }
            public double KH { get; set; }
            public double luyke { get; set; }
            public double chenhlech { get; set; }
            public double percentage { get; set; }
            public double KHDC { get; set; }
            public int percentageDC { get; set; }
            public int SUM { get; set; }
            public int perday { get; set; }

            public int BQQHDC { get; set; }
            public int vatlieuchong { get; set; }
            public int dientichdao { get; set; }
            public int bc { get; set; }
            public int ct { get; set; }
        }

        public class Than
        {
            public int percentMonth { get; set; }
            public int percentDay { get; set; }
            public double Thuchien { get; set; }
            public double Kehoach { get; set; }
            public double Luyke { get; set; }
            public double KehoachThang { get; set; }
            public double Ton { get; set; }
        }
        public class ThanLoThien
        {
            public double SanLuong { get; set; }
        }
        public class Tainan_Dasboard : TaiNan
        {
            public string department_name { get; set; }
            public string Ten { get; set; }
        }

        [Route("ban-giam-doc/bao-cao-nhanh-san-xuat")]
        [HttpPost]
        public ActionResult GetData(string date)
        {
            return Index(date);

        }

        [Route("ban-giam-doc/bao-cao-nhanh-san-xuat")]
        [HttpGet]
        public ActionResult Index(string date)
        {
            string[] data = new string[4];
            if (date != null)
            {
                data = date.Split('/');
                date = data[2] + "-" + data[1] + "-" + data[0];
                string day_dashboard = data[0] + "/" + data[1] + "/" + data[2];
                ViewBag.d = day_dashboard;
            }
            else
            {
                DateTime d = DateTime.Today;
                date = d.ToString("dd/MM/yyyy");
                data = date.Split('/');
                date = data[2] + "-" + data[1] + "-" + data[0];
                string day_dashboard = DateTime.Parse(date).AddDays(-2).ToShortDateString();
                string[] day_dashboard1 = day_dashboard.Split('/');
                string day_dashboard2 = day_dashboard1[1] + "/" + day_dashboard1[0] + "/" + day_dashboard1[2];
                ViewBag.d = day_dashboard2;
            }
            string[] data_tmp = data;
            DateTime timeEnd = Convert.ToDateTime(date);
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");

            string query = @"select d.MaTieuChi, (case when a.thuchien is null then 0 else a.thuchien end) as 'thuchien', (case when b.LUYKE is null then 0 else b.LUYKE end) as 'LUYKE', (case when c.KH is null then 0 else c.KH end) as 'KH', d.KHDC
                            from (select a.MaTieuChi, sum(kt.SanLuong) 'KHDC'
		                            from(select  kt.HeaderID, hkt.MaPhongBan, khtt.ThangKeHoach,kt.MaTieuChi,max(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung'
		                            from KeHoach_TieuChi_TheoThang kt inner join header_KeHoachTungThang hkt
		                            on kt.HeaderID = hkt.HeaderID
                                    join KeHoachTungThang khtt on khtt.ThangID = hkt.ThangID
		                            where khtt.ThangKeHoach = @month and khtt.NamKeHoach = @year
		                            group by kt.HeaderID, hkt.MaPhongBan, khtt.ThangKeHoach, kt.MaTieuChi
		                            ) as a inner join KeHoach_TieuChi_TheoThang kt on a.HeaderID = kt.HeaderID and a.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung and a.MaTieuChi = kt.MaTieuChi
		                            group by a.MaTieuChi) as d

                            left outer join (select MaTieuChi, sum(SanLuong) as 'LUYKE' from ThucHien_TieuChi_TheoNgay as th
		                            join (select tht.*,hth.MaPhongBan,hth.HeaderID from header_ThucHienTheoNgay hth join ThucHienTheoNgay tht on hth.NgayID = tht.NgayID where Ngay between @dateStart and @dateEnd) as h on th.HeaderID = h.HeaderID
		                            group by MaTieuChi) as b on d.MaTieuChi = b.MaTieuChi

                            left outer join (select MaTieuChi, sum(SanLuong) as 'thuchien' from ThucHien_TieuChi_TheoNgay as th
		                            join (select tht.*,hth.MaPhongBan,hth.HeaderID from header_ThucHienTheoNgay hth join ThucHienTheoNgay tht on hth.NgayID = tht.NgayID where Ngay = @date) as h on th.HeaderID = h.HeaderID
		                            group by MaTieuChi) as a on d.MaTieuChi = a.MaTieuChi

                            left outer join  (select a.MaTieuChi, sum(kt.KeHoach) 'KH'
		                            from(select  kt.HeaderID, hkt.MaPhongBan, hkt.NgayNhapKH,kt.MaTieuChi,max(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung'
		                            from KeHoach_TieuChi_TheoNgay kt inner join header_KeHoach_TieuChi_TheoNgay hkt
		                            on kt.HeaderID = hkt.HeaderID
		                            where convert(date,hkt.NgayNhapKH) = @date
		                            group by kt.HeaderID, hkt.MaPhongBan, hkt.NgayNhapKH, kt.MaTieuChi
		                            ) as a inner join KeHoach_TieuChi_TheoNgay kt on a.HeaderID = kt.HeaderID and a.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung and a.MaTieuChi = kt.MaTieuChi
		                            group by a.MaTieuChi) as c on d.MaTieuChi = c.MaTieuChi
                            order by d.MaTieuChi";
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<reportEntity> listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("date", date), new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd), new SqlParameter("month", data[1]), new SqlParameter("year", data[2])).ToList();

            Than Thandaolo = new Than();
            Than Thanlothien = new Than();
            Than Metlodao = new Than();
            Than Metloneo = new Than();
            Than Metloxen = new Than();
            Than Thantieuthu = new Than();
            Than Daxitkho = new Than();
            Than Lothien = new Than();
            Than Datdaboc = new Than();
            foreach (var item in listReport)
            {
                //than dao lo
                if (item.MaTieuChi == 1 || item.MaTieuChi == 2)
                {
                    Thandaolo.Thuchien += item.thuchien;
                    Thandaolo.Kehoach += item.KH;

                    Thandaolo.Luyke += item.luyke;
                    Thandaolo.KehoachThang += item.KHDC;
                }

                //than lo thien
                if (item.MaTieuChi == 3 || item.MaTieuChi == 4)
                {
                    Thanlothien.Thuchien += item.thuchien;
                    Thanlothien.Kehoach += item.KH;

                    Thanlothien.Luyke += item.luyke;
                    Thanlothien.KehoachThang += item.KHDC;
                }

                //dat da boc
                if (item.MaTieuChi == 5)
                {
                    Datdaboc.Thuchien += item.thuchien;
                    Datdaboc.Kehoach += item.KH;

                    Datdaboc.Luyke += item.luyke;
                    Datdaboc.KehoachThang += item.KHDC;
                }

                //met lo dao
                if (item.MaTieuChi == 7)
                {
                    Metlodao.Thuchien += item.thuchien;
                    Metlodao.Kehoach += item.KH;

                    Metlodao.Luyke += item.luyke;
                    Metlodao.KehoachThang += item.KHDC;
                }

                //met lo neo
                if (item.MaTieuChi == 9)
                {
                    Metloneo.Thuchien += item.thuchien;
                    Metloneo.Kehoach += item.KH;

                    Metloneo.Luyke += item.luyke;
                    Metloneo.KehoachThang += item.KHDC;
                }

                //met lo xen
                if (item.MaTieuChi == 19)
                {
                    Metloxen.Thuchien += item.thuchien;
                    Metloxen.Kehoach += item.KH;

                    Metloxen.Luyke += item.luyke;
                    Metloxen.KehoachThang += item.KHDC;
                }

                //than tieu thu
                if (item.MaTieuChi >= 21 && item.MaTieuChi <= 29)
                {
                    Thantieuthu.Thuchien += item.thuchien;
                    Thantieuthu.Kehoach += item.KH;

                    Thantieuthu.Luyke += item.luyke;
                    Thantieuthu.KehoachThang += item.KHDC;
                }

                //da xit kho
                if (item.MaTieuChi == 18)
                {
                    Daxitkho.Thuchien += item.thuchien;
                    Daxitkho.Kehoach += item.KH;

                    Daxitkho.Luyke += item.luyke;
                    Daxitkho.KehoachThang += item.KHDC;
                }
            }

            //than dao lo
            Thandaolo.Ton = Thandaolo.KehoachThang - Thandaolo.Luyke;
            if (Thandaolo.Kehoach != 0) Thandaolo.percentDay = Convert.ToInt32(Thandaolo.Thuchien / Thandaolo.Kehoach * 100);
            else Thandaolo.percentDay = 0;
            if (Thandaolo.KehoachThang != 0) Thandaolo.percentMonth = Convert.ToInt32(Thandaolo.Luyke / Thandaolo.KehoachThang * 100);
            else Thandaolo.percentMonth = 0;
            ViewBag.tdl = Thandaolo;

            //than lo thien
            Thanlothien.Ton = Thanlothien.KehoachThang - Thanlothien.Luyke;
            if (Thanlothien.Kehoach != 0) Thanlothien.percentDay = Convert.ToInt32(Thanlothien.Thuchien / Thanlothien.Kehoach * 100);
            else Thanlothien.percentDay = 0;
            if (Thanlothien.KehoachThang != 0) Thanlothien.percentMonth = Convert.ToInt32(Thanlothien.Luyke / Thanlothien.KehoachThang * 100);
            else Thanlothien.percentMonth = 0;
            ViewBag.tlt = Thanlothien;

            //met lo dao
            Metlodao.Ton = Metlodao.KehoachThang - Metlodao.Luyke;
            if (Metlodao.Kehoach != 0) Metlodao.percentDay = Convert.ToInt32(Metlodao.Thuchien / Metlodao.Kehoach * 100);
            else Metlodao.percentDay = 0;
            if (Metlodao.KehoachThang != 0) Metlodao.percentMonth = Convert.ToInt32(Metlodao.Luyke / Metlodao.KehoachThang * 100);
            else Metlodao.percentMonth = 0;
            ViewBag.mld = Metlodao;

            //met lo neo
            Metloneo.Ton = Metloneo.KehoachThang - Metloneo.Luyke;
            if (Metloneo.Kehoach != 0) Metloneo.percentDay = Convert.ToInt32(Metloneo.Thuchien / Metloneo.Kehoach * 100);
            else Metloneo.percentDay = 0;
            if (Metloneo.KehoachThang != 0) Metloneo.percentMonth = Convert.ToInt32(Metloneo.Luyke / Metloneo.KehoachThang * 100);
            else Metloneo.percentMonth = 0;
            ViewBag.mln = Metloneo;

            //met lo xen
            Metloxen.Ton = Metloxen.KehoachThang - Metloxen.Luyke;
            if (Metloxen.Kehoach != 0) Metloxen.percentDay = Convert.ToInt32(Metloxen.Thuchien / Metloxen.Kehoach * 100);
            else Metloxen.percentDay = 0;
            if (Metloxen.KehoachThang != 0) Metloxen.percentMonth = Convert.ToInt32(Metloxen.Luyke / Metloxen.KehoachThang * 100);
            else Metloxen.percentMonth = 0;
            ViewBag.mlx = Metloxen;

            //than tieu thu
            Thantieuthu.Ton = Thantieuthu.KehoachThang - Thantieuthu.Luyke;
            if (Thantieuthu.Kehoach != 0) Thantieuthu.percentDay = Convert.ToInt32(Thantieuthu.Thuchien / Thantieuthu.Kehoach * 100);
            else Thantieuthu.percentDay = 0;
            if (Thantieuthu.KehoachThang != 0) Thantieuthu.percentMonth = Convert.ToInt32(Thantieuthu.Luyke / Thantieuthu.KehoachThang * 100);
            else Thantieuthu.percentMonth = 0;
            ViewBag.ttt = Thantieuthu;

            //da xit kho
            Daxitkho.Ton = Daxitkho.KehoachThang - Daxitkho.Luyke;
            if (Daxitkho.Kehoach != 0) Daxitkho.percentDay = Convert.ToInt32(Daxitkho.Thuchien / Daxitkho.Kehoach * 100);
            else Daxitkho.percentDay = 0;
            if (Daxitkho.KehoachThang != 0) Daxitkho.percentMonth = Convert.ToInt32(Daxitkho.Luyke / Daxitkho.KehoachThang * 100);
            else Daxitkho.percentMonth = 0;
            ViewBag.dxk = Daxitkho;
            //dat da boc
            Datdaboc.Ton = Datdaboc.KehoachThang - Datdaboc.Luyke;
            if (Datdaboc.Kehoach != 0) Datdaboc.percentDay = Convert.ToInt32(Datdaboc.Thuchien / Datdaboc.Kehoach * 100);
            else Datdaboc.percentDay = 0;
            if (Datdaboc.KehoachThang != 0) Datdaboc.percentMonth = Convert.ToInt32(Datdaboc.Luyke / Datdaboc.KehoachThang * 100);
            else Datdaboc.percentMonth = 0;
            ViewBag.ddb = Datdaboc;

            //sự cố
            string[] data2 = date.Split('-');
            string sql = @"SELECT 
                            d.department_name, 
                            i.reason, 
                            DATEDIFF(HOUR, i.start_time, i.end_time) as time_different
                            FROM Incident i
                            inner join Equipment e on e.equipmentId = i.equipmentId
                            inner join Department d on d.department_id = i.department_id
                            where YEAR(i.start_time) = @year and MONTH(i.start_time) = @month and DAY(i.start_time) = @day";
            List<IncidentDB> list = db.Database.SqlQuery<IncidentDB>(sql, new SqlParameter("year", data2[0]),
                                                                            new SqlParameter("month", data2[1]),
                                                                            new SqlParameter("day", data2[2])).ToList();

            ViewBag.listSC = list;
            ViewBag.listSCCount = list.Count();

            //tai nạn
            string sql_tainan = @"SELECT 
                                Department.department_name,
                                NhanVien.Ten,
                                NhanVien.MaNV,
                                TaiNan.LyDo
                                FROM NhanVien 
                                INNER JOIN TaiNan ON NhanVien.MaNV = TaiNan.MaNV
                                INNER JOIN Department ON NhanVien.MaPhongBan = Department.department_id
                                where YEAR(TaiNan.Ngay) = @year and MONTH(TaiNan.Ngay) = @month and DAY(TaiNan.Ngay) = @day";
            List<Tainan_Dasboard> list_tainan = db.Database.SqlQuery<Tainan_Dasboard>(sql_tainan, new SqlParameter("year", data2[0]),
                                                                                                    new SqlParameter("month", data2[1]),
                                                                                                    new SqlParameter("day", data2[2])).ToList();

            ViewBag.listTN = list_tainan;
            ViewBag.listTNCount = list_tainan.Count();

            //lộ thiên
            string sql_LTTL = "select top 1 SanLuong from KeHoach_TieuChi_TheoThang " +
                              " where MaTieuChi = 3 AND YEAR(ThoiGianNhapCuoiCung) = '" + data2[0] + "' and MONTH(ThoiGianNhapCuoiCung) = '" + data2[1] + "' and DAY(ThoiGianNhapCuoiCung) = '" + data2[2] + "'" +
                              " order by ThoiGianNhapCuoiCung DESC ";
            ThanLoThien LTTL = new ThanLoThien();
            LTTL = db.Database.SqlQuery<ThanLoThien>(sql_LTTL).FirstOrDefault<ThanLoThien>();
            string sql_LTTN = "select top 1 SanLuong from KeHoach_TieuChi_TheoThang " +
                           " where MaTieuChi = 4 AND YEAR(ThoiGianNhapCuoiCung) = '" + data2[0] + "' and MONTH(ThoiGianNhapCuoiCung) = '" + data2[1] + "' and DAY(ThoiGianNhapCuoiCung) = '" + data2[2] + "'" +
                           " order by ThoiGianNhapCuoiCung DESC ";
            ThanLoThien LTTN = new ThanLoThien();
            LTTN = db.Database.SqlQuery<ThanLoThien>(sql_LTTL).FirstOrDefault<ThanLoThien>();
            string sql_DDB = "select top 1 SanLuong from KeHoach_TieuChi_TheoThang " +
                         " where MaTieuChi = 5 AND YEAR(ThoiGianNhapCuoiCung) = '" + data2[0] + "' and MONTH(ThoiGianNhapCuoiCung) = '" + data2[1] + "' and DAY(ThoiGianNhapCuoiCung) = '" + data2[2] + "'" +
                         " order by ThoiGianNhapCuoiCung DESC ";
            ThanLoThien DDB = new ThanLoThien();
            DDB = db.Database.SqlQuery<ThanLoThien>(sql_LTTL).FirstOrDefault<ThanLoThien>();
            double heso = 0;
            if (DDB != null && LTTL != null && LTTN != null)
            {
                if ((LTTL.SanLuong + LTTN.SanLuong) != 0)
                {
                    heso = DDB.SanLuong / (LTTL.SanLuong + LTTN.SanLuong);
                }
            }

            double DDBTH = Lothien.Thuchien * heso;
            //da dat boc
            Lothien.Ton = Lothien.KehoachThang - Lothien.Luyke;
            if (Lothien.Kehoach != 0) Lothien.percentDay = Convert.ToInt32(DDBTH / Lothien.Kehoach * 100);
            else Lothien.percentDay = 0;
            if (Lothien.KehoachThang != 0) Lothien.percentMonth = Convert.ToInt32(Lothien.Luyke / Lothien.KehoachThang * 100);
            else Lothien.percentMonth = 0;

            string sql_chart = "select a.MaPhongBan " +
                        "	,(a.KT1 + a.KT2 + a.KT3 + a.CD1 + a.CD2 + a.CD3 + a.QL1 + a.QL2 + a.QL3) as 'dilam' " +
                        "	,(b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) as 'nghi' " +
                        "from (select n.MaPhongBan  " +
                        ", sum(case when nc.MaNhomCongViec = 6 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'KT1' " +
                        ", SUM(case when nc.MaNhomCongViec = 7 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'CD1' " +
                        ", SUM(case when nc.MaNhomCongViec = 10 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'QL1' " +
                        ", sum(case when nc.MaNhomCongViec = 6 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'KT2' " +
                        ", SUM(case when nc.MaNhomCongViec = 7 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'CD2' " +
                        ", SUM(case when nc.MaNhomCongViec = 10 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'QL2' " +
                        ", sum(case when nc.MaNhomCongViec = 6 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'KT3' " +
                        ", SUM(case when nc.MaNhomCongViec = 7 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'CD3' " +
                        ", SUM(case when nc.MaNhomCongViec = 10 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'QL3' " +
                        ", count(n.MaNV) as 'tong_DS', sum(case when nc.MaNhomCongViec = 3 then 1 else 0 end) as 'QL_CTy' " +
                        "from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID " +
                        "    inner join CongViec c on n.MaCongViec = c.MaCongViec " +
                        "    inner join CongViec_NhomCongViec nc on c.MaCongViec = nc.MaCongViec" +
                        "   inner join NhomCongViec ncv on nc.MaNhomCongViec = ncv.MaNhomCongViec " +
                        "where h.NgayDiemDanh = @day group by n.MaPhongBan) a full join  " +
                        "	(select n.MaPhongBan " +
                        "	, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'vld1'    " +
                        "	, sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'om1'    " +
                        "	, SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'p1'  " +
                        "	, SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'khac1'    " +
                        "	, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'vld2'    " +
                        "	, sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'om2'    " +
                        "	, SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'p2'  " +
                        "	, SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'khac2'    " +
                        "	, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'vld3'    " +
                        "	, sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'om3'    " +
                        "	, SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'p3'  " +
                        "	, SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'khac3'    " +
                        "	, SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') then 1 else 0 end) as 'tong_nghidai'  " +
                        "	from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID  " +
                        "	where h.NgayDiemDanh = @day group by n.MaPhongBan) b on a.MaPhongBan = b.MaPhongBan " +
                        "	where a.MaPhongBan in ('ĐL3', 'ĐL5', 'ĐL7', 'ĐL8', 'KT1', 'KT2', 'KT3', 'KT4', 'KT5', 'KT6', 'KT7', 'KT8', 'KT9', 'KT10', 'KT11', 'VTL1', 'VTL2') " +
                        "	order by a.MaPhongBan";
            List<chart> list_chart = db.Database.SqlQuery<chart>(sql_chart, new SqlParameter("day", date)).ToList();
            List<string> donvi = new List<string> { "ĐL3", "ĐL5", "ĐL7", "ĐL8", "KT1", "KT2", "KT3", "KT4", "KT5", "KT6", "KT7", "KT8", "KT9", "KT10", "KT11", "VTL1", "VTL2" };
            string result = JsonConvert.SerializeObject(donvi);
            ViewBag.donvi = result;


            List<int> dilam = new List<int>();
            List<int> nghi = new List<int>();
            for (int i = 0; i < donvi.Count(); i++)
            {
                int temp_dilam = 0;
                int temp_nghi = 0;

                string temp = donvi[i];
                foreach (var item in list_chart)
                {
                    if (item.MaPhongBan.Equals(temp))
                    {
                        temp_dilam = item.dilam;
                        temp_nghi = item.nghi;
                        break;
                    }
                }
                dilam.Add(temp_dilam);
                nghi.Add(temp_nghi);

            }
            string dilam_result = JsonConvert.SerializeObject(dilam);
            string nghi_result = JsonConvert.SerializeObject(nghi);
            ViewBag.dilam = dilam_result;
            ViewBag.nghi = nghi_result;

            string mysql = @"select th.NgaySanXuat, kh.SoNgayLamViec
                            from ThucHienTheoNgay th , KeHoachTungThang kh 
                            where th.Ngay = @day";
            QuickReport qr = db.Database.SqlQuery<QuickReport>(mysql, new SqlParameter("day", date)).FirstOrDefault();
            if (qr != null)
            {
                ViewBag.ngaySXconlai = qr.SoNgayLamViec - qr.NgaySanXuat;
                ViewBag.ngaySXhientai = qr.NgaySanXuat;
                ViewBag.tongNgaySX = qr.SoNgayLamViec;
                double tmp = Convert.ToDouble(qr.NgaySanXuat) / Convert.ToDouble(qr.SoNgayLamViec) * 100;
                ViewBag.tiendoNgay = string.Format("{0:0.##}", tmp);
            }
            else
            {
                ViewBag.ngaySXconlai = "";
                ViewBag.ngaySXhientai = "";
                ViewBag.tongNgaySX = "";
                ViewBag.tiendoNgay = "";
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string new_query = @"--1.Than hầm lò
                            select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                            (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                            from Tieuchi t
                            left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                            left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                            KeHoach_TieuChi_TheoNgay kt
                            group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                            left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                            left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                            where t.MaNhomTieuChi = 1 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                            group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                            inner join 
                            (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                            from Tieuchi t 
                            left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                            left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                            left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                            left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                            where t.MaNhomTieuChi = 1 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                            group by ntc.TenNhomTieuChi, th.Ngay) as b 
                            on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_thanhamlo = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_thanhamlo = kh_sl_thanhamlo;
            ////////////////////////////////////////////////
            new_query = @"--2.Than lộ thiên
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 2 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 2 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_thanlothien = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_thanlothien = kh_sl_thanlothien;
            ////////////////////////////////////////////////
            new_query = @"--3.Mét lò đào
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 5 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 5 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_metlodao = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_metlodao = kh_sl_metlodao;
            ////////////////////////////////////////////////

            new_query = @"--4.Mét lò neo
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 6 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 6 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_metloneo = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_metloneo = kh_sl_metloneo;
            ////////////////////////////////////////////////

            new_query = @"--5.Mét lò xén
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 7 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 7 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_metloxen = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_metloxen = kh_sl_metloxen;
            ////////////////////////////////////////////////
            new_query = @"--6.Than tiêu thụ
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 9 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 9 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_thantieuthu = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_thantieuthu = kh_sl_thantieuthu;
            ////////////////////////////////////////////////
            new_query = @"--7.Đá xít kho
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 11 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 11 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_daxitkho = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_daxitkho = kh_sl_daxitkho;
            ////////////////////////////////////////////////
            new_query = @"--8.Đất đá bóc tự làm
                        select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
                        (select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
                        from Tieuchi t
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
                        left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
                        KeHoach_TieuChi_TheoNgay kt
                        group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
                        left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
                        left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
                        where t.MaNhomTieuChi = 3 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or ht.NgayNhapKH is null) 
                        group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
                        inner join 
                        (select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
                        from Tieuchi t 
                        left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
                        left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
                        left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
                        left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
                        where t.MaNhomTieuChi = 3 and (th.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay or th.Ngay is null)
                        group by ntc.TenNhomTieuChi, th.Ngay) as b 
                        on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay";
            List<KeHoach_SanLuong> kh_sl_datdaboc = db.Database.SqlQuery<KeHoach_SanLuong>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<KeHoach_SanLuong>();
            ViewBag.kh_sl_datdaboc = kh_sl_datdaboc;



            ////////////////////THAN SX////////////////////////////
            new_query = @"select 
                        pb.MaPhongBan as 'MaPhongBan',
						pb.TenPhongBan,
                        ISNULL(th.SanLuongThucHien,0) as 'SanLuongThucHienNgay',
						ISNULL(khn.SanLuongKeHoach,0) as 'SanLuongKeHoachNgay',
                        ISNULL(lk.SanLuongLuyKe,0) as 'SanLuongLuyKeNgay',
                        ISNULL(kht.SanLuongKeHoachThang,0) as 'SanLuongKeHoachThang',
                        (ISNULL(kht.SanLuongKeHoachThang,0) - ISNULL(lk.SanLuongLuyKe,0)) as 'SanLuongConLai',
                        (case when (th.SanLuongThucHien >= khn.SanLuongKeHoach) then N'Đạt' else N'Không đạt' end) as 'TinhTrang'
                        from 
						(select 
						hd.MaPhongBan,
						dp.department_name as 'TenPhongBan',
						dp.[index]
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kh on hd.ThangID = kh.ThangID
						join KeHoach_TieuChi_TheoThang khtc on khtc.HeaderID = hd.HeaderID
						join TieuChi tc on tc.MaTieuChi = khtc.MaTieuChi
						join NhomTieuChi ntc on ntc.MaNhomTieuChi = tc.MaNhomTieuChi
						join Department dp on hd.MaPhongBan = dp.department_id
						where ntc.MaNhomTieuChi in (1,2)
						group by hd.MaPhongBan, dp.department_name, dp.[index]) as pb
						LEFT JOIN
                        (select 
                        hd.MaPhongBan, 
                        ISNULL(SUM(tt.SanLuong),0) as 'SanLuongThucHien' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (1,2) and thn.Ngay = @Ngay
                        group by hd.MaPhongBan) as th on pb.MaPhongBan = th.MaPhongBan
                        LEFT JOIN
                        (select 
						pbtc.MaPhongBan,
						ISNULL(SUM(khtcn.KeHoach), 0) as 'SanLuongKeHoach'
						from
						(select
						hd.MaPhongBan,
						kh.MaTieuChi,
                        MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung'
                        from 
                        header_KeHoach_TieuChi_TheoNgay hd 
                        join KeHoach_TieuChi_TheoNgay kh on hd.HeaderID = kh.HeaderID
                        join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (1,2) and hd.NgayNhapKH = @Ngay
                        group by hd.MaPhongBan, kh.MaTieuChi) as pbtc
						JOIN 
						KeHoach_TieuChi_TheoNgay khtcn on khtcn.MaTieuChi = pbtc.MaTieuChi and khtcn.ThoiGianNhapCuoiCung = pbtc.ThoiGianNhapCuoiCung
						group by pbtc.MaPhongBan) as khn on pb.MaPhongBan = khn.MaPhongBan 
                        LEFT JOIN 
                        (select 
                        hd.MaPhongBan, 
                        ISNULL(SUM(tt.SanLuong),0) as 'SanLuongLuyKe' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (1,2) and thn.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay
                        group by hd.MaPhongBan) as lk on lk.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN
                        (select slkh.MaPhongBan,
						sum(slkh.SanLuong) as 'SanLuongKeHoachThang'
						from
						(select 
						kht.MaPhongBan,
						kht.MaTieuChi,
						sl.SanLuong,
						kht.ThoiGianNhapCuoiCung					 
						from
						(select
						hd.MaPhongBan,
						tc.MaTieuChi,
						MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung' 
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kht on hd.ThangID = kht.ThangID
						join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
						join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
						join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
						where ntc.MaNhomTieuChi in (1,2) and kht.ThangKeHoach = MONTH(@Ngay) and kht.NamKeHoach = YEAR(@Ngay)
						group by hd.MaPhongBan, tc.MaTieuChi) as kht
						left join
						(select 
						MaTieuChi, 
						SanLuong,
						ThoiGianNhapCuoiCung 
						from KeHoach_TieuChi_TheoThang) as sl on kht.MaTieuChi = sl.MaTieuChi and kht.ThoiGianNhapCuoiCung = sl.ThoiGianNhapCuoiCung) as slkh
						group by MaPhongBan) as kht on kht.MaPhongBan = pb.MaPhongBan
						order by pb.[index]";
            List<SanLuong_LuyKe> sl_lk_thansx = db.Database.SqlQuery<SanLuong_LuyKe>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<SanLuong_LuyKe>();
            ViewBag.sl_lk_thansx = sl_lk_thansx;


            ///////////////////MÉT LÒ ĐÀO////////////////////////////
            new_query = @"select 
                        pb.MaPhongBan as 'MaPhongBan',
                        pb.TenPhongBan,
                        ISNULL(th.SanLuongThucHien,0) as 'SanLuongThucHienNgay',
						ISNULL(khn.SanLuongKeHoach,0) as 'SanLuongKeHoachNgay',
                        ISNULL(lk.SanLuongLuyKe,0) as 'SanLuongLuyKeNgay',
                        ISNULL(kht.SanLuongKeHoachThang,0) as 'SanLuongKeHoachThang',
                        (ISNULL(kht.SanLuongKeHoachThang,0) - ISNULL(lk.SanLuongLuyKe,0)) as 'SanLuongConLai',
                        (case when (th.SanLuongThucHien >= khn.SanLuongKeHoach) then N'Đạt' else N'Không đạt' end) as 'TinhTrang'
                        from 
						(select 
						hd.MaPhongBan,
                        dp.department_name as 'TenPhongBan',
						dp.[index]
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kh on hd.ThangID = kh.ThangID
						join KeHoach_TieuChi_TheoThang khtc on khtc.HeaderID = hd.HeaderID
						join TieuChi tc on tc.MaTieuChi = khtc.MaTieuChi
						join NhomTieuChi ntc on ntc.MaNhomTieuChi = tc.MaNhomTieuChi
                        join Department dp on hd.MaPhongBan = dp.department_id
						where ntc.MaNhomTieuChi = 5
						group by hd.MaPhongBan, dp.department_name, dp.[index]) as pb
						LEFT JOIN
                        (select 
                        hd.MaPhongBan, 
                        ISNULL(SUM(tt.SanLuong),0) as 'SanLuongThucHien' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi = 5 and thn.Ngay = @Ngay
                        group by hd.MaPhongBan) as th on pb.MaPhongBan = th.MaPhongBan
                        LEFT JOIN
                        (select 
                        hd.MaPhongBan,
                        ISNULL(SUM(kh.KeHoach),0) as 'SanLuongKeHoach',
                        MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung'
                        from 
                        header_KeHoach_TieuChi_TheoNgay hd 
                        join KeHoach_TieuChi_TheoNgay kh on hd.HeaderID = kh.HeaderID
                        join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi = 5 and hd.NgayNhapKH = @Ngay
                        group by hd.MaPhongBan, hd.NgayNhapKH) as khn on pb.MaPhongBan = khn.MaPhongBan 
                        LEFT JOIN 
                        (select 
                        hd.MaPhongBan, 
                        ISNULL(SUM(tt.SanLuong),0) as 'SanLuongLuyKe' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi = 5 and thn.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay
                        group by hd.MaPhongBan) as lk on lk.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN
                        (select slkh.MaPhongBan,
						sum(slkh.SanLuong) as 'SanLuongKeHoachThang'
						from
						(select 
						kht.MaPhongBan,
						kht.MaTieuChi,
						sl.SanLuong,
						kht.ThoiGianNhapCuoiCung					 
						from
						(select
						hd.MaPhongBan,
						tc.MaTieuChi,
						MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung' 
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kht on hd.ThangID = kht.ThangID
						join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
						join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
						join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
						where ntc.MaNhomTieuChi = 5 and kht.ThangKeHoach = MONTH(@Ngay) and kht.NamKeHoach = YEAR(@Ngay)
						group by hd.MaPhongBan, tc.MaTieuChi) as kht
						left join
						(select 
						MaTieuChi, 
						SanLuong,
						ThoiGianNhapCuoiCung 
						from KeHoach_TieuChi_TheoThang) as sl on kht.MaTieuChi = sl.MaTieuChi and kht.ThoiGianNhapCuoiCung = sl.ThoiGianNhapCuoiCung) as slkh
						group by MaPhongBan) as kht on kht.MaPhongBan = pb.MaPhongBan
						order by pb.[index]";
            List<SanLuong_LuyKe> sl_lk_metlo = db.Database.SqlQuery<SanLuong_LuyKe>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<SanLuong_LuyKe>();
            ViewBag.sl_lk_metlo = sl_lk_metlo;


            ///////////////////ĐẤT ĐÁ BÓC////////////////////////////
            new_query = @"select 
                        pb.MaPhongBan as 'MaPhongBan',
                        pb.TenPhongBan,
                        ISNULL(th.SanLuongThucHien,0) as 'SanLuongThucHienNgay',
						ISNULL(khn.SanLuongKeHoach,0) as 'SanLuongKeHoachNgay',
                        ISNULL(lk.SanLuongLuyKe,0) as 'SanLuongLuyKeNgay',
                        ISNULL(kht.SanLuongKeHoachThang,0) as 'SanLuongKeHoachThang',
                        (ISNULL(kht.SanLuongKeHoachThang,0) - ISNULL(lk.SanLuongLuyKe,0)) as 'SanLuongConLai',
                        (case when (th.SanLuongThucHien >= khn.SanLuongKeHoach) then N'Đạt' else N'Không đạt' end) as 'TinhTrang'
                        from 
						(select 
						hd.MaPhongBan,
                        dp.department_name as 'TenPhongBan',
						dp.[index]
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kh on hd.ThangID = kh.ThangID
						join KeHoach_TieuChi_TheoThang khtc on khtc.HeaderID = hd.HeaderID
						join TieuChi tc on tc.MaTieuChi = khtc.MaTieuChi
						join NhomTieuChi ntc on ntc.MaNhomTieuChi = tc.MaNhomTieuChi
                        join Department dp on hd.MaPhongBan = dp.department_id
						where ntc.MaNhomTieuChi = 3
						group by hd.MaPhongBan, dp.department_name, dp.[index]) as pb
						LEFT JOIN
                        (select 
                        hd.MaPhongBan, 
                        ISNULL(SUM(tt.SanLuong),0) as 'SanLuongThucHien' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi = 3 and thn.Ngay = @Ngay
                        group by hd.MaPhongBan) as th on pb.MaPhongBan = th.MaPhongBan
                        LEFT JOIN
                        (select 
                        hd.MaPhongBan,
                        ISNULL(SUM(kh.KeHoach),0) as 'SanLuongKeHoach',
                        MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung'
                        from 
                        header_KeHoach_TieuChi_TheoNgay hd 
                        join KeHoach_TieuChi_TheoNgay kh on hd.HeaderID = kh.HeaderID
                        join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi = 3 and hd.NgayNhapKH = @Ngay
                        group by hd.MaPhongBan, hd.NgayNhapKH) as khn on pb.MaPhongBan = khn.MaPhongBan 
                        LEFT JOIN 
                        (select 
                        hd.MaPhongBan, 
                        ISNULL(SUM(tt.SanLuong),0) as 'SanLuongLuyKe' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi = 3 and thn.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay
                        group by hd.MaPhongBan) as lk on lk.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN
                        (select slkh.MaPhongBan,
						sum(slkh.SanLuong) as 'SanLuongKeHoachThang'
						from
						(select 
						kht.MaPhongBan,
						kht.MaTieuChi,
						sl.SanLuong,
						kht.ThoiGianNhapCuoiCung					 
						from
						(select
						hd.MaPhongBan,
						tc.MaTieuChi,
						MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung' 
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kht on hd.ThangID = kht.ThangID
						join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
						join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
						join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
						where ntc.MaNhomTieuChi = 3 and kht.ThangKeHoach = MONTH(@Ngay) and kht.NamKeHoach = YEAR(@Ngay)
						group by hd.MaPhongBan, tc.MaTieuChi) as kht
						left join
						(select 
						MaTieuChi, 
						SanLuong,
						ThoiGianNhapCuoiCung 
						from KeHoach_TieuChi_TheoThang) as sl on kht.MaTieuChi = sl.MaTieuChi and kht.ThoiGianNhapCuoiCung = sl.ThoiGianNhapCuoiCung) as slkh
						group by MaPhongBan) as kht on kht.MaPhongBan = pb.MaPhongBan
						order by pb.[index]";
            List<SanLuong_LuyKe> sl_lk_datda = db.Database.SqlQuery<SanLuong_LuyKe>(new_query,
                new SqlParameter("@Ngay", timeEnd)).ToList<SanLuong_LuyKe>();
            ViewBag.sl_lk_datda = sl_lk_datda;
            //get the rest days in year
            int totalDayOfYear = new DateTime(DateTime.Now.Year, 12, 31).DayOfYear;
            int currentDayOfYear = DateTime.Now.DayOfYear;
            int restDayOfYear = totalDayOfYear - currentDayOfYear;
            Session["restDayOfYear"] = restDayOfYear;
            return View("/Views/BGD/DK/Manufacturing.cshtml");
        }

        public class SanLuong_LuyKe
        {
            public string MaPhongBan { get; set; }
            public string TenPhongBan { get; set; }
            public double? SanLuongThucHienNgay { get; set; }
            public double? SanLuongKeHoachNgay { get; set; }
            public double? SanLuongLuyKeNgay { get; set; }
            public double? SanLuongKeHoachThang { get; set; }
            public double? SanLuongConLai { get; set; }
            public string TinhTrang { get; set; }
        }

        public class KeHoach_SanLuong
        {
            public string TenNhomTieuChi { get; set; }
            public DateTime Ngay { get; set; }
            public double KeHoach { get; set; }
            public double SanLuong { get; set; }
        }
        public class QuickReport
        {
            public int NgaySanXuat { get; set; }
            public int SoNgayLamViec { get; set; }
        }

        public class chart
        {
            public string MaPhongBan { get; set; }
            public int dilam { get; set; }
            public int nghi { get; set; }
        }
    }
}