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
    public class ReportMonthlyController : Controller
    {
        // GET: ReportMonthly
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-thang-quy")]
        public ActionResult getView()
        {
            return View("/Views/DK/MonthlyQuarterlyReport.cshtml");
        }
        //
        [HttpPost]
        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-thang-quy")]
        public ActionResult getDataFromDB()
        {
            int year = Int32.Parse(Request["years"]);
            var query = "select d.*,department.department_name as TenPhongBan,NhomTieuChi.TenNhomTieuChi from (select c.*, (Jan + Feb + March + April) as [Q1],(May + June + July + Aug) as [Q2],(Sep + Oct + Nov + [Dec]) as [Q3] from " +
                "(select MaNhomTieuChi, MaPhongBan, SUM(Jan) as [Jan], SUM([Feb]) as [Feb], SUM([March]) as [March],SUM([April]) as [April], SUM([May]) as [May],SUM([June]) as [June],SUM([July]) as [July],SUM([Aug]) as [Aug], " +
                "SUM([Sep]) as [Sep],SUM([Oct]) as [Oct],SUM([Nov]) as [Nov],SUM([Dec]) as [Dec] " +
                "FROM(select MaNhomTieuChi, MaPhongBan, " +
                "Sum(case when a.Ngay between @startJan and @endJan then SanLuong else 0 end) as [Jan]," +
                "Sum(case when a.Ngay between @startFeb and @endFeb then SanLuong else 0 end) as [Feb]," +
                "Sum(case when a.Ngay between @startMar and @endMar then SanLuong else 0 end) as [March]," +
                "Sum(case when a.Ngay between @startApril and @endApril then SanLuong else 0 end) as [April]," +
                "Sum(case when a.Ngay between @startMay and @endMay then SanLuong else 0 end) as [May]," +
                "Sum(case when a.Ngay between @startJune and @endJune then SanLuong else 0 end) as [June]," +
                "Sum(case when a.Ngay between @startJuly and @endJuly then SanLuong else 0 end) as [July]," +
                "Sum(case when a.Ngay between @startAug and @endAug then SanLuong else 0 end) as [Aug]," +
                "Sum(case when a.Ngay between @startSep and @endSep then SanLuong else 0 end) as [Sep]," +
                "Sum(case when a.Ngay between @startOct and @endOct then SanLuong else 0 end) as [Oct]," +
                "Sum(case when a.Ngay between @startNov and @endNov then SanLuong else 0 end) as [Nov]," +
                "Sum(case when a.Ngay between @startDec and @endDec then SanLuong else 0 end) as [Dec] " +
                "from (select th.SanLuong, header.MaPhongBan, header.Ngay, TieuChi.MaNhomTieuChi from ThucHien_TieuChi_TheoNgay as th " +
                "inner join (select* from header_ThucHienTheoNgay where header_ThucHienTheoNgay.Ngay between '2019-01-01' and '2019-12-31' )as header " +
                "on th.HeaderID = header.HeaderID inner join TieuChi on th.MaTieuChi = TieuChi.MaTieuChi ) as a group by MaNhomTieuChi, MaPhongBan) as b " +
                "group by MaNhomTieuChi, MaPhongBan) as c ) as d " +
                "inner join Department on d.MaPhongBan = Department.department_id " +
                "inner join NhomTieuChi on d.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi order by MaPhongBan, MaNhomTieuChi";
            var endDays =new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
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
                var listSanLuong = db.Database.SqlQuery<SanLuongTheoThangQuy>(query, 
                    new SqlParameter("startJan", startDates[0]), new SqlParameter("endJan", endDates[0]),
                    new SqlParameter("startFeb", startDates[0]), new SqlParameter("endFeb", endDates[1]),
                    new SqlParameter("startMar", startDates[0]), new SqlParameter("endMar", endDates[2]),
                    new SqlParameter("startApril", startDates[0]), new SqlParameter("endApril", endDates[3]),
                    new SqlParameter("startMay", startDates[0]), new SqlParameter("endMay", endDates[4]),
                    new SqlParameter("startJune", startDates[0]), new SqlParameter("endJune", endDates[5]),
                    new SqlParameter("startJuly", startDates[0]), new SqlParameter("endJuly", endDates[6]),
                    new SqlParameter("startAug", startDates[0]), new SqlParameter("endAug", endDates[7]),
                    new SqlParameter("startSep", startDates[0]), new SqlParameter("endSep", endDates[8]),
                    new SqlParameter("startOct", startDates[0]), new SqlParameter("endOct", endDates[9]),
                    new SqlParameter("startNov", startDates[0]), new SqlParameter("endNov", endDates[10]),
                    new SqlParameter("startDec", startDates[0]), new SqlParameter("endDec", endDates[11])
                    ).ToList();
                //Thu Tu In Ra Theo Ten Phong Ban
                var departmentName = new string[] { "Phân xưởng khai thác 1", "Phân xưởng khai thác 2", "Phân xưởng khai thác 3", "Phân xưởng khai thác 4","Phân xưởng khai thác 5",
                                                    "Phân xưởng khai thác 6", "Phân xưởng khai thác 7", "Phân xưởng khai thác 8", "Phân xưởng khai thác 9","Phân xưởng khai thác 10",
                                                    "Phân xưởng khai thác 11", "Phân xưởng đào lò 3", "Phân xưởng đào lò 5", "Phân xưởng đào lò 7","Phân xưởng đào lò 7","Phân xưởng đào lò 8",
                                                    "Công Ty Dương Huy","Phân xưởng sàng tuyển","Phân xưởng lộ thiên","Công ty Xây lắp mỏ - TKV","Liên doanh nhà thầu Công ty CP thương mại - công nghệ CT Thăng Long và Công ty tư vấn Công ty Thăng Long"};
                //
                List<ChiTietBaoCao_Object> listBaoCao = new List<ChiTietBaoCao_Object>();
                for(var index =0; index < departmentName.Length; index++)
                {
                    ChiTietBaoCao_Object bcHeader = new ChiTietBaoCao_Object();
                    bcHeader.TenPhongBan = departmentName[index];
                    bcHeader.isHeader = true;
                    listBaoCao.Add(bcHeader);
                    foreach (var itemTH in listSanLuong)
                    {
                        if (itemTH.TenPhongBan == departmentName[index])
                        {
                            ChiTietBaoCao_Object bc = new ChiTietBaoCao_Object();
                            bc.Jan = itemTH.Jan;
                            bc.Feb = itemTH.Feb;
                            bc.March = itemTH.March;
                            bc.April = itemTH.April;
                            bc.June = itemTH.June;
                            bc.July = itemTH.July;
                            bc.Aug = itemTH.Aug;
                            bc.Sep = itemTH.Sep;
                            bc.Oct = itemTH.Oct;
                            bc.Nov = itemTH.Nov;
                            bc.Dec = itemTH.Dec;
                            bc.Q1 = itemTH.Q1;
                            bc.Q2 = itemTH.Q2;
                            bc.Q3 = itemTH.Q3;
                            bc.isHeader = false;
                            bc.TenNhomTieuChi = itemTH.TenNhomTieuChi;
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
    }
}