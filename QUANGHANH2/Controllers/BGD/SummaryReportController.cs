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
        // GET: /<controller>/
        [Route("ban-giam-doc")]
        [HttpGet]
        public ActionResult Index()
        {
            DateTime timeEnd = Convert.ToDateTime("2019-09-10");
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            var query = "select *,(table2.TH-table2.KH) as [CHENHLECH],(CASE WHEN KH =0 THEN 100 ELSE ROUND(TH*100/KH,0) end) as [PERCENTAGE], " +
                "0 as [KHDC], 0 as [percentDC],0 as [SUM],0 as [perday], 0 as [BQKHDC],0 as [VATLIEUCHONG],0 AS[DIENTICHDAO],0 as [BC],0 AS[CT] " +
                "from(select MaTieuChi, TenTieuChi, " +
                "Sum(case when ca = 1 and Ngay = @dateEnd then SanLuong else 0  end )as [CA1], " +
                "Sum(case when ca = 2 and Ngay = @dateEnd then SanLuong else 0  end )as [CA2], " +
                "Sum(case when ca = 3 and Ngay = @dateEnd then SanLuong else 0  end )as [CA3], " +
                "Sum(case when Ngay = @dateEnd then SanLuong else 0  end )as [TH], " +
                "Sum(case when Ngay = @dateEnd then KeHoach else 0  end )as [KH], " +
                "SUM(SanLuong) as [LUYKE] " +
                "from(select thuchien.HeaderID, thuchien.MaTieuChi, TieuChi.TenTieuChi, thuchien.SanLuong, thuchien.KeHoach, header_th.Ca, header_th.Ngay, px.department_id, px.isInside from ThucHien_TieuChi_TheoNgay as thuchien " +
                "inner JOIN header_ThucHienTheoNgay as header_th " +
                "on thuchien.HeaderID = header_th.HeaderID and header_th.Ngay >= @dateStart and header_th.Ngay <= @dateEnd " +
                "INNER JOIN Department as px on px.department_id = header_th.MaPhongBan " +
                "INNER JOIN TieuChi on thuchien.MaTieuChi = TieuChi.MaTieuChi) as a " +
                "GROUP BY MaTieuChi,TenTieuChi) as table2 " +
                "ORDER By MaTieuChi ";
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<reportEntity> listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();

            Than Thandaolo = new Than();
            Than Thanlothien = new Than();
            Than Metlodao = new Than();
            Than Metloneo = new Than();
            Than Metloxen = new Than();
            foreach(var item in listReport)
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
            }

            //than dao lo
            Thandaolo.Ton = Thandaolo.KehoachThang - Thandaolo.Luyke;
            Thandaolo.percentDay = Convert.ToInt32(Thandaolo.Thuchien / Thandaolo.Kehoach * 100);
            if (Thandaolo.KehoachThang != 0) Thandaolo.percentMonth = Convert.ToInt32(Thandaolo.Luyke / Thandaolo.KehoachThang * 100);
            else Thandaolo.percentMonth = 0;
            ViewBag.tdl = Thandaolo;

            //than lo thien
            Thanlothien.Ton = Thanlothien.KehoachThang - Thanlothien.Luyke;
            Thanlothien.percentDay = Convert.ToInt32(Thanlothien.Thuchien / Thanlothien.Kehoach * 100);
            if (Thanlothien.KehoachThang != 0) Thanlothien.percentMonth = Convert.ToInt32(Thanlothien.Luyke / Thanlothien.KehoachThang * 100);
            else Thanlothien.percentMonth = 0;
            ViewBag.tlt = Thanlothien;

            //met lo dao
            Metlodao.Ton = Metlodao.KehoachThang - Metlodao.Luyke;
            Metlodao.percentDay = Convert.ToInt32(Metlodao.Thuchien / Metlodao.Kehoach * 100);
            if (Metlodao.KehoachThang != 0) Metlodao.percentMonth = Convert.ToInt32(Metlodao.Luyke / Metlodao.KehoachThang * 100);
            else Metlodao.percentMonth = 0;
            ViewBag.mld = Metlodao;

            //met lo neo
            Metloneo.Ton = Metloneo.KehoachThang - Metloneo.Luyke;
            Metloneo.percentDay = Convert.ToInt32(Metloneo.Thuchien / Metloneo.Kehoach * 100);
            if (Metloneo.KehoachThang != 0) Metloneo.percentMonth = Convert.ToInt32(Metloneo.Luyke / Metloneo.KehoachThang * 100);
            else Metloneo.percentMonth = 0;
            ViewBag.mln = Metloneo;

            //met lo xen
            Metloxen.Ton = Metloxen.KehoachThang - Metloxen.Luyke;
            Metloxen.percentDay = Convert.ToInt32(Metloxen.Thuchien / Metloxen.Kehoach * 100);
            if (Metloxen.KehoachThang != 0) Metloxen.percentMonth = Convert.ToInt32(Metloxen.Luyke / Metloxen.KehoachThang * 100);
            else Metloxen.percentMonth = 0;
            ViewBag.mlx = Metloxen;

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
