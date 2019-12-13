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
    public class KHSXNamController : Controller
    {
        QUANGHANHABCEntities dbContext = new QUANGHANHABCEntities();
        // GET: KHSXNam
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam")]
        public ActionResult Index()
        {
            List<TieuChi> listTieuChi = dbContext.Database.SqlQuery<TieuChi>("select * from TieuChi").ToList<TieuChi>();
            ViewBag.listTC = listTieuChi;
            return View("/Views/DK/KHSXNam.cshtml");
        }
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam")]
        [HttpPost]
        public ActionResult Add(string department, string year, string jsonname,string noteNam)
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

            using (DbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                header_KeHoach_TieuChi_TheoNam header_KHSXNam = new header_KeHoach_TieuChi_TheoNam();
                header_KHSXNam.MaPhongBan = department;
                header_KHSXNam.Nam = parseYear(year);
                header_KHSXNam.GhiChu = noteNam;
                dbContext.header_KeHoach_TieuChi_TheoNam.Add(header_KHSXNam);

                List<string> listCheck = new List<string>();
                foreach (var item in kehoach)
                {
                    string tieuchiId = (string)item["0"];
                    string after = (string)item["1"];
                    string note = (string)item["2"];
                    KeHoach_TieuChi_TheoNam KHSXNam = new KeHoach_TieuChi_TheoNam();
                    KHSXNam.HeaderID = header_KHSXNam.HeaderID;

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


            return View("/Views/DK/KHSXNam.cshtml");
        }
       
        private int parseYear(string year)
        {
            string strYear = year.Split(' ')[1];
            return Int32.Parse(strYear);
        }
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam/lay-thong-tin")]
        public ActionResult getInformation()
        {
            var year = Int32.Parse(Request["year"]);
            var department = Request["department"];
            string query = "select kh.MaTieuChi, kh.SanLuongKeHoach, kh.GhiChu "+
                            "from(select hks.MaPhongBan, kh.MaTieuChi, max(kh.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' "+
                            "from header_KeHoach_TieuChi_TheoNam hks inner "+
                            "join KeHoach_TieuChi_TheoNam kh "+
                            "on hks.HeaderID = kh.HeaderID "+
                            "where hks.Nam = @Nam and hks.MaPhongBan = @maphongban "+
                            "group by hks.MaPhongBan, kh.MaTieuChi) as a inner join KeHoach_TieuChi_TheoNam kh on a.ThoiGianNhapCuoiCung = kh.ThoiGianNhapCuoiCung "+
                            "and a.MaTieuChi = kh.MaTieuChi";
            List<TieuChiCu> tieuChiCuList = dbContext.Database.SqlQuery<TieuChiCu>(query, new SqlParameter("Nam", year),
                                                                                         new SqlParameter("maphongban", department)).ToList<TieuChiCu>();

            string quertNote = "select top 1 * " +
                               "from header_KeHoach_TieuChi_TheoNam a " +
                               "where a.MaPhongBan = @maphongban " +
                               "order by a.HeaderID DESC ";
            header_KeHoach_TieuChi_TheoNam GhiChu = dbContext.Database.SqlQuery<header_KeHoach_TieuChi_TheoNam>(quertNote,new SqlParameter("maphongban",department)).FirstOrDefault<header_KeHoach_TieuChi_TheoNam>();
            if(GhiChu == null)
            {
                return Json(new { tieuChiCuList = tieuChiCuList, note = "" });
            }
            else
            {
                return Json(new { tieuChiCuList = tieuChiCuList, note = GhiChu.GhiChu });
            }
           
        }
       
    }
    public class TieuChiCu
    {
        public int MaTieuChi { get; set; }
        public double SanLuongKeHoach { get; set; }
        public string GhiChu { get; set; }
    }
}