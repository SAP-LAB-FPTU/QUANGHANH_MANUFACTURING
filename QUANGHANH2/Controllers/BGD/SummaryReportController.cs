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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.BGD
{
    public class SummaryReportController : Controller
    {
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
        public class Tainan_Dasboard : TaiNan
        {
            public string Ten { get; set; }
        }
        // GET: /<controller>/
        [Route("ban-giam-doc")]
        [HttpPost]
        public ActionResult GetData(string date)
        {
            return Index(date);

        }

        [Route("ban-giam-doc")]
        [HttpGet]
        public ActionResult Index(string date)
        {
            string[] data;
            if(date != null)
            {
                data = date.Split('/');
                date = data[2] + "-" + data[1] + "-" + data[0];
            }
            else
            {
                DateTime d = DateTime.Today;
                date = d.ToString("yyyy-MM-dd");
            }

            DateTime timeEnd = Convert.ToDateTime(date);
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            var query = "select a.MaTieuChi,t.TenTieuChi,a.CA1,a.CA2,a.CA3,a.TH,a.LUYKE, "+
                            "(case when b.SanLuong is null then 0 else b.SanLuong end) as 'KHDC', "+
                            "(case when c.KeHoach is null then 0 else c.KeHoach end) as 'KH' "+
                            "from(select MaTieuChi, "+
                                        "Sum(case when ca = 1 and Ngay = @dateEnd then SanLuong else 0  end )as [CA1], "+
                                        "Sum(case when ca = 2 and Ngay = @dateEnd then SanLuong else 0  end )as [CA2], " +
                                        "Sum(case when ca = 3 and Ngay = @dateEnd then SanLuong else 0  end )as [CA3], " +
                                        "Sum(case when Ngay = @dateEnd then SanLuong else 0  end )as [TH], " +
                                        "SUM(SanLuong) as [LUYKE] " +

                                    "from header_ThucHienTheoNgay a inner join ThucHien_TieuChi_TheoNgay b on a.HeaderID = b.HeaderID and a.Ngay >= @dateStart and a.Ngay <= @dateEnd " +

                                    "group by MaTieuChi) a " +
                                    "full join(select k.MaTieuChi, k.SanLuong, k.ThoiGianNhapCuoiCung " +

                                        "from KeHoach_TieuChi_TheoThang k inner join (select k.MaTieuChi, MAX(k.ThoiGianNhapCuoiCung) as 'thoigian' from KeHoach_TieuChi_TheoThang k group by k.MaTieuChi) a " +
                                         "on k.MaTieuChi = a.MaTieuChi and k.ThoiGianNhapCuoiCung = a.thoigian) b on a.MaTieuChi = b.MaTieuChi " +

                                    "full join(select k.MaTieuChi, k.KeHoach, k.ThoiGianNhapCuoiCung " +
                                        "from KeHoach_TieuChi_TheoNgay k inner join (select k.MaTieuChi, MAX(k.ThoiGianNhapCuoiCung) as 'thoigian' from KeHoach_TieuChi_TheoNgay k group by k.MaTieuChi) a " +
                                         "on k.MaTieuChi = a.MaTieuChi and k.ThoiGianNhapCuoiCung = a.thoigian) c on a.MaTieuChi = c.MaTieuChi " +

                                    "inner join TieuChi t on a.MaTieuChi = t.MaTieuChi " +
                            "order by a.MaTieuChi asc";
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<reportEntity> listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();

            Than Thandaolo = new Than();
            Than Thanlothien = new Than();
            Than Metlodao = new Than();
            Than Metloneo = new Than();
            Than Metloxen = new Than();
            Than Thantieuthu = new Than();
            Than Daxitkho = new Than();
            foreach (var item in listReport)
            {
                //than dao lo
                if(item.MaTieuChi == 1 || item.MaTieuChi == 2)
                {
                    Thandaolo.Thuchien += item.TH;
                    Thandaolo.Kehoach += item.KH;

                    Thandaolo.Luyke += item.luyke;
                    Thandaolo.KehoachThang += item.KHDC;
                }

                //than lo thien
                if(item.MaTieuChi == 3 || item.MaTieuChi == 4)
                {
                    Thanlothien.Thuchien += item.TH;
                    Thanlothien.Kehoach += item.KH;

                    Thanlothien.Luyke += item.luyke;
                    Thanlothien.KehoachThang += item.KHDC;
                }

                //met lo dao
                if(item.MaTieuChi == 7)
                {
                    Metlodao.Thuchien += item.TH;
                    Metlodao.Kehoach += item.KH;

                    Metlodao.Luyke += item.luyke;
                    Metlodao.KehoachThang += item.KHDC;
                }

                //met lo neo
                if (item.MaTieuChi == 9)
                {
                    Metloneo.Thuchien += item.TH;
                    Metloneo.Kehoach += item.KH;

                    Metloneo.Luyke += item.luyke;
                    Metloneo.KehoachThang += item.KHDC;
                }

                //met lo xen
                if (item.MaTieuChi == 19)
                {
                    Metloxen.Thuchien += item.TH;
                    Metloxen.Kehoach += item.KH;

                    Metloxen.Luyke += item.luyke;
                    Metloxen.KehoachThang += item.KHDC;
                }

                //than tieu thu
                if (item.MaTieuChi >= 21 && item.MaTieuChi <= 29)
                {
                    Thantieuthu.Thuchien += item.TH;
                    Thantieuthu.Kehoach += item.KH;

                    Thantieuthu.Luyke += item.luyke;
                    Thantieuthu.KehoachThang += item.KHDC;
                }

                //da xit kho
                if (item.MaTieuChi == 18)
                {
                    Daxitkho.Thuchien += item.TH;
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
            //sự cố
            string[] data2 = date.Split('-');
            string sql = "SELECT e.equipment_name, d.department_name, i.*, DATEDIFF(HOUR, i.start_time, i.end_time) as time_different " +
                            " FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId " +
                            "                 inner join Department d on d.department_id = i.department_id " +
                            " where YEAR(i.start_time) = '" + data2[0] + "' and MONTH(i.start_time) = '" + data2[1] + "' and DAY(i.start_time) = '" + data2[2] + "'";
            List<IncidentDB> list = db.Database.SqlQuery<IncidentDB>(sql).ToList();

            ViewBag.listSC = list;
            ViewBag.listSCCount = list.Count();

            //tai nạn
            string sql_tainan = " SELECT NhanVien.MaNV, NhanVien.Ten, TaiNan.LyDo, TaiNan.Ngay, TaiNan.Loai " +
                                " FROM NhanVien INNER JOIN TaiNan ON NhanVien.MaNV = TaiNan.MaNV " +
                                " where YEAR(TaiNan.Ngay) = '" + data2[0] + "' and MONTH(TaiNan.Ngay) = '" + data2[1] + "' and DAY(TaiNan.Ngay) = '" + data2[2] + "'";
           List<Tainan_Dasboard> list_tainan = db.Database.SqlQuery<Tainan_Dasboard>(sql_tainan).ToList();

            ViewBag.listTN = list_tainan;
            ViewBag.listTNCount = list_tainan.Count();
            string day_dashboard = data2[2] + "/" + data2[1] + "/" + data2[0];
            ViewBag.d = day_dashboard;
            return View("/Views/BGD/Dashboard.cshtml");
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
}
