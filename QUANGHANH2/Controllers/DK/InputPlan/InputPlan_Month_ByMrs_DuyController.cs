//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Newtonsoft.Json;
//using System.Data.SqlClient;

//namespace QUANGHANH2.Controllers.DK.InputPlan
//{
//    public class InputPlan_Month_ByMrs_DuyController : Controller
//    {
//        // GET: InputPlan_Month
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang")]
//        public ActionResult Index()
//        {
//            return View("/Views/DK/InputPlan/InputPlan_Month.cshtml");
//        }

//        public dynamic GetData(int month, int year, string departmentID)
//        {
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {

//                //var sqlQuery = " select table1.* from (select header_kh.HeaderID,TieuChi.TenTieuChi,kehoach.SanLuong," +
//                //    "header_kh.SoNgayLamViec,[kehoach].MaTieuChi as MaTieuChiNull," +
//                //    "TieuChi.DonViDo,[kehoach].GhiChu from " +
//                //    "(select* from header_KeHoachTungThang as header " +
//                //    "where header.MaPhongBan = @departmentID and header.ThangKeHoach = @month and " +
//                //    "header.NamKeHoach = @year) as header_kh left join(" +
//                //    "select b.*from(SELECT[HeaderID],[MaTieuChi],Max([ThoiGianNhapCuoiCung]) as [ThoiGianNhapCuoiCung] " +
//                //    "FROM[QUANGHANHABC].[dbo].[KeHoach_TieuChi_TheoThang] " +
//                //    "GROUP BY MaTieuChi, HeaderID) as a inner join [KeHoach_TieuChi_TheoThang] as b on " +
//                //    "a.HeaderID = b.HeaderID and a.MaTieuChi = b.MaTieuChi " +
//                //    "and a.ThoiGianNhapCuoiCung = b.ThoiGianNhapCuoiCung) as kehoach " +
//                //    "on header_kh.HeaderID = kehoach.HeaderID left join TieuChi " +
//                //    "on kehoach.MaTieuChi = TieuChi.MaTieuChi) as table1 right join (select * from PhongBan_TieuChi where MaPhongBan = @departmentID and Thang = @month and Nam = @year) as table2 " +
//                //    "on table1.MaTieuChiNull = table2.MaTieuChi";
//                var sqlQuery = @"select pb_tc.MaPhongBan, ISNULL(kh_th.SoNgayLamViec, 0) as SoNgayLamViec, pb_tc.MaTieuChi, pb_tc.TenTieuChi, pb_tc.DonViDo, ISNULL(kh_th.SanLuong, 0) as SanLuong, kh_th.GhiChu from
//                                ((select a.MaTieuChi, b.TenTieuChi, b.DonViDo, a.MaPhongBan from PhongBan_TieuChi a left outer join TieuChi b on a.MaTieuChi = b.MaTieuChi
//                                where a.Thang = @month and a.Nam = @year and a.MaPhongBan = @departmentID) as pb_tc
//                                left outer join
//                                (select kh_a.MaPhongBan, kh_b.SoNgayLamViec, kh_a.MaTieuChi, kh_b.SanLuong, kh_a.ThoiGianNhapCuoiCung, kh_b.GhiChu  
//                                from ((select a.MaPhongBan, b.MaTieuChi, Max(b.ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung 
//                                from header_KeHoachTungThang a join KeHoach_TieuChi_TheoThang b 
//                                on a.HeaderID = b.HeaderID 
//                                where a.ThangKeHoach = @month and a.NamKeHoach = @year and a.MaPhongBan = @departmentID
//                                group by a.MaPhongBan, b.MaTieuChi) as kh_a 
//                                left outer join  
//                                (select a.MaPhongBan, b.MaTieuChi, a.SoNgayLamViec, b.SanLuong, b.ThoiGianNhapCuoiCung, b.GhiChu 
//                                from header_KeHoachTungThang a join KeHoach_TieuChi_TheoThang b 
//                                on a.HeaderID = b.HeaderID) as kh_b
//                                on kh_a.MaTieuChi = kh_b.MaTieuChi and kh_a.MaPhongBan = kh_b.MaPhongBan and kh_a.ThoiGianNhapCuoiCung = kh_b.ThoiGianNhapCuoiCung)) as kh_th
//                                on pb_tc.MaTieuChi = kh_th.MaTieuChi and pb_tc.MaPhongBan = kh_th.MaPhongBan)";
//                return db.Database.SqlQuery<ChiTietTieuChi>(sqlQuery, new SqlParameter("departmentID", departmentID), new SqlParameter("month", month), new SqlParameter("year", year)).ToList();
//            }
//        }
//        //
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/lay-thong-tin")]
//        public ActionResult getInformation()
//        {
//            try
//            {
//                var month = Int32.Parse(Request["month"]);
//                var year = Int32.Parse(Request["year"]);
//                var departmentID = Request["department"];
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    var listAspectDepartments = (from pbtc in db.PhongBan_TieuChi
//                                                    .Where(x => x.MaPhongBan == departmentID && x.Thang == month && x.Nam == year)
//                                                 join tieuchi in db.TieuChis on pbtc.MaTieuChi equals tieuchi.MaTieuChi
//                                                 select new
//                                                 {
//                                                     MaTieuChi = tieuchi.MaTieuChi,
//                                                     TenTieuChi = tieuchi.TenTieuChi
//                                                 }).ToList();
//                    var listAspect2 = new List<ChiTietTieuChi>();
//                    var listAspect = GetData(month, year, departmentID);
//                    if (listAspect.Count > 0)
//                    {
//                        foreach (var item in listAspect)
//                        {
//                            if (item.MaTieuChiNull != null)
//                            {
//                                item.Identify = item.MaTieuChiNull + "-" + item.HeaderID;
//                                listAspect2.Add(item);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        header_KeHoachTungThang header = new header_KeHoachTungThang();
//                        header.MaPhongBan = departmentID;
//                        header.ThangKeHoach = month;
//                        header.NamKeHoach = year;
//                        header.SoNgayLamViec = 26;
//                        db.header_KeHoachTungThang.Add(header);
//                        db.SaveChanges();
//                        var HearderID = db.header_KeHoachTungThang.Where(x => x.MaPhongBan == departmentID && x.ThangKeHoach == month && x.NamKeHoach == year).Select(x => x.HeaderID).FirstOrDefault();
//                        return Json(new { data = listAspect, aspects = listAspectDepartments, totalDays = (26), headerID = HearderID }, JsonRequestBehavior.AllowGet);

//                    }
//                    return Json(new { data = listAspect2, aspects = listAspectDepartments, totalDays = (listAspect.Count == 0 ? 0 : listAspect[0].SoNgayLamViec), headerID = listAspect.Count == 0 ? -1 : listAspect[0].HeaderID }, JsonRequestBehavior.AllowGet);
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
//                return new HttpStatusCodeResult(400);
//            }
//        }
//        //
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/cap-nhat-thong-tin")]
//        public ActionResult UpdteInformation()
//        {
//            var month = Int32.Parse(Request["month"]);
//            var year = Int32.Parse(Request["year"]);
//            var departmentID = Request["department"];
//            var headerID = Int32.Parse(Request["headerID"]);
//            var totalDays = Int32.Parse(Request["totalDays"]);
//            var data = Request["data"];

//            List<KeHoach_TieuChi_TheoThang> listUpdate = JsonConvert.DeserializeObject<List<KeHoach_TieuChi_TheoThang>>(data);
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                var listAspectDepartments = (from pbtc in db.PhongBan_TieuChi
//                            .Where(x => x.MaPhongBan == departmentID)
//                                             join tieuchi in db.TieuChis on pbtc.MaTieuChi equals tieuchi.MaTieuChi
//                                             select new
//                                             {
//                                                 MaTieuChi = tieuchi.MaTieuChi,
//                                                 TenTieuChi = tieuchi.TenTieuChi
//                                             }).ToList();

//                DateTime currentTime = DateTime.Now;
//                db.Configuration.ValidateOnSaveEnabled = true;
//                foreach (var item in listUpdate)
//                {
//                    item.ThoiGianNhapCuoiCung = currentTime;

//                    db.KeHoach_TieuChi_TheoThang.Add(item);
//                }

//                db.SaveChanges();
//                var listAspect = GetData(month, year, departmentID);
//                if (listAspect.Count != 0)
//                {
//                    foreach (var item in listAspect)
//                    {
//                        item.Identify = item.MaTieuChiNull + "-" + item.HeaderID;
//                    }
//                }
//                //
//                return Json(new { data = listAspect, aspects = listAspectDepartments });
//            }
//        }
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/returnunit")]
//        [HttpPost]
//        public JsonResult returnUnit(int MaTieuChi)
//        {

//            try
//            {
//                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
//                var ma = db.TieuChis.Where(x => x.MaTieuChi == MaTieuChi).SingleOrDefault();
//                //String item = equipment.supply_name + "^" + equipment.unit;
//                return Json(new
//                {
//                    DonViDo = ma.DonViDo
//                }, JsonRequestBehavior.AllowGet); ;
//            }
//            catch (Exception ex)
//            {
//                return Json("Mã tiêu chí không tồn tại", JsonRequestBehavior.AllowGet);
//            }

//        }
//    }

//    public class ChiTietTieuChi : KeHoach_TieuChi_TheoThang
//    {
//        public Nullable<int> MaTieuChiNull { get; set; }
//        public string DonViDo { get; set; }
//        public string TenTieuChi { get; set; }

//        public int SoNgayLamViec { get; set; }

//        public string Identify { get; set; }
//    }
//}