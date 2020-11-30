using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
namespace QUANGHANH2.Controllers.DK
{
    public class InputPlan_YearController : Controller
    {
        QuangHanhManufacturingEntities dbContext = new QuangHanhManufacturingEntities();
        // GET: KHSXNam
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam")]
        public ActionResult Index()
        {
            List<TieuChi> listTieuChi = dbContext.Database.SqlQuery<TieuChi>("select * from TieuChi").ToList<TieuChi>();
            var query = " select * from Department WHERE department_type in (@departmentType_1, @departmentType_2) order by department_name";
            List<Department> listDepartments = dbContext.Database.SqlQuery<Department>(query,
                new SqlParameter("departmentType_1", "Phân xưởng sản xuất chính"),
                new SqlParameter("departmentType_2", "Đơn vị sản xuất thuê ngoài")).ToList<Department>();
            ViewBag.listTC = listTieuChi;
            ViewBag.listDepartments = listDepartments;
            return View("/Views/DK/InputPlan/InputPlan_Year.cshtml");
        }
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam")]
        [HttpPost]
        public ActionResult Add(string department, string year, string jsonname, string noteNam)
        {
            if (department == null)
            {
                return Json(new { message = "ErrorDepart" }, JsonRequestBehavior.AllowGet);
            }
            if (noteNam == null)
            {
                return Json(new { message = "ErrorYear" }, JsonRequestBehavior.AllowGet);
            }

            JObject input = JObject.Parse(jsonname);
            JArray kehoach = (JArray)input["data"];

            var query = " select * from Department WHERE department_type =@departmentType order by department_name";
            List<Department> listDepartments = dbContext.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
            ViewBag.listDepartments = listDepartments;
            try
            {
                using (DbContextTransaction transaction = dbContext.Database.BeginTransaction())
                {
                    int year1 = parseYear(year);
                    header_KeHoach_TieuChi_TheoNam header_KeHoach_TieuChi_TheoNam = dbContext.header_KeHoach_TieuChi_TheoNam.Where(x => x.MaPhongBan.Equals(department) && x.Nam == year1).FirstOrDefault<header_KeHoach_TieuChi_TheoNam>();
                    header_KeHoach_TieuChi_TheoNam.GhiChu = noteNam;
                    List<string> listCheck = new List<string>();
                    foreach (var item in kehoach)
                    {
                        string tieuchiId = (string)item["0"];
                        string after = (string)item["1"];
                        string note = (string)item["2"];
                        KeHoach_TieuChi_TheoNam KHSXNam = new KeHoach_TieuChi_TheoNam();
                        KHSXNam.HeaderID = header_KeHoach_TieuChi_TheoNam.HeaderID;

                        if (tieuchiId == "-1")
                        {
                            return Json(new { message = "ErrorTieuChi" }, JsonRequestBehavior.AllowGet);
                        }
                        if (listCheck.Contains(tieuchiId))
                        {
                            return Json(new { message = "DupliTieuChi" }, JsonRequestBehavior.AllowGet);
                        }
                        KHSXNam.MaTieuChi = Int32.Parse(tieuchiId);
                        KHSXNam.ThoiGianNhapCuoiCung = DateTime.Now;
                        try
                        {
                            KHSXNam.SanLuongKeHoach = Double.Parse(after);
                        }
                        catch
                        {
                            return Json(new { message = "ErrorNumber" }, JsonRequestBehavior.AllowGet);
                        }
                        KHSXNam.GhiChu = note;
                        listCheck.Add(tieuchiId);
                        dbContext.KeHoach_TieuChi_TheoNam.Add(KHSXNam);
                    }
                    transaction.Commit();
                    dbContext.SaveChanges();
                }

            }
            catch (Exception)
            {

            }



            return View("/Views/DK/InputPlan/InputPlan_Year.cshtml");
        }

        private int parseYear(string year)
        {
            string strYear = year.Split(' ')[1];
            return Convert.ToInt32(strYear);
        }
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam/lay-thong-tin")]
        public ActionResult getInformation()
        {
            var year = Int32.Parse(Request["year"]);
            var department = Request["department"];
            string query = @"select
                            hdkh.MaPhongBan,
                            hdkh.MaTieuChi,
                            hdkh.TenTieuChi,
                            hdkh.DonViDo, 
                            ISNUll(khtc.SanLuongKeHoach,convert(float,0)) as 'SanLuong',
                            ISNULL(khtc.GhiChu, '') as 'GhiChu',
                            ISNULL(khtc.ThoiGianNhapCuoiCung, 0) as 'ThoiGianNhapCuoiCung'
                            from 
                            (select hd.*,pbtc.MaTieuChi, tc.TenTieuChi, tc.DonViDo 
                            from header_KeHoach_TieuChi_TheoNam hd 
                            join PhongBan_TieuChi_TheoNam pbtc on hd.MaPhongBan = pbtc.MaPhongBan and hd.Nam = pbtc.Nam
                            join TieuChi tc on tc.MaTieuChi = pbtc.MaTieuChi
                            where hd.MaPhongBan = @departmentID and hd.Nam = @year) as hdkh 
                            left join 
							(select
							khtc1.HeaderID, khtc1.MaTieuChi, khtc2.SanLuongKeHoach, khtc2.GhiChu, khtc1.ThoiGianNhapCuoiCung 
							from 
							(select 
                            kh.HeaderID, 
                            kh.MaTieuChi, 
                            max(kh.ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung
                            from KeHoach_TieuChi_TheoNam kh
                            join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                            group by kh.HeaderID, kh.MaTieuChi) as khtc1
							join KeHoach_TieuChi_TheoNam as khtc2 on khtc1.HeaderID = khtc2.HeaderID 
							and khtc1.MaTieuChi = khtc2.MaTieuChi 
							and khtc1.ThoiGianNhapCuoiCung = khtc2.ThoiGianNhapCuoiCung) as khtc
                            on hdkh.HeaderID = khtc.HeaderID and hdkh.MaTieuChi = khtc.MaTieuChi";
            List<TieuChiCu> tieuChiCuList = dbContext.Database.SqlQuery<TieuChiCu>(query,
                                            new SqlParameter("departmentID", department),
                                            new SqlParameter("year", year)).ToList<TieuChiCu>();
            if (tieuChiCuList.Count == 0)
            {
                query = @"select 
                        hd.MaPhongBan,
                        tc.MaTieuChi,
                        tc.TenTieuChi,
                        tc.DonViDo,
                        CONVERT(float,0) as SanLuong,
                        '' as GhiChu
                        from 
                        header_KeHoach_TieuChi_TheoNam hd
                        join PhongBan_TieuChi_TheoNam pbtc on pbtc.MaPhongBan = hd.MaPhongBan and pbtc.Nam = hd.Nam
                        join TieuChi tc on tc.MaTieuChi = pbtc.MaTieuChi
                        where hd.MaPhongBan = @departmentID and hd.Nam = @year";
                tieuChiCuList = dbContext.Database.SqlQuery<TieuChiCu>(query,
                                                new SqlParameter("departmentID", department),
                                                new SqlParameter("year", year)).ToList<TieuChiCu>();
            }

            string quertNote = "select top 1 * " +
                               "from header_KeHoach_TieuChi_TheoNam a " +
                               "where a.MaPhongBan = @maphongban " +
                               "order by a.HeaderID DESC ";
            //header_KeHoach_TieuChi_TheoNam GhiChu = dbContext.Database.SqlQuery<header_KeHoach_TieuChi_TheoNam>(quertNote,new SqlParameter("maphongban",department)).FirstOrDefault<header_KeHoach_TieuChi_TheoNam>();
            header_KeHoach_TieuChi_TheoNam GhiChu = dbContext.header_KeHoach_TieuChi_TheoNam.Where(x => x.MaPhongBan.Equals(department) && x.Nam == year).FirstOrDefault<header_KeHoach_TieuChi_TheoNam>();
            return Json(new { tieuChiCuList = tieuChiCuList, note = GhiChu.GhiChu });
        }
    }
    public class TieuChiCu
    {
        string MaPhongBan { get; set; }
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public double SanLuong { get; set; }
        public string GhiChu { get; set; }
    }
}