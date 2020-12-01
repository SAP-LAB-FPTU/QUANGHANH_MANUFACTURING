//using Newtonsoft.Json.Linq;
//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.DK.InputPlan
//{
//    public class InputPlan_MonthController : Controller
//    {
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang")]
//        public ActionResult Index()
//        {
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                var query = " select * from Department WHERE department_type in (@departmentType_1, @departmentType_2) order by department_name";
//                List<Department> listDepartments = db.Database.SqlQuery<Department>(query,
//                    new SqlParameter("departmentType_1", "Phân xưởng sản xuất chính"),
//                    new SqlParameter("departmentType_2", "Đơn vị sản xuất thuê ngoài")).ToList<Department>();
//                ViewBag.listDepartments = listDepartments;
//                return View("/Views/DK/InputPlan/InputPlan_Month.cshtml");
//            }
//        }

//        //////////////////////////////GET INFOR/////////////////////////////
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/lay-thong-tin")]
//        [HttpPost]
//        public ActionResult GetInformation()
//        {
//            try
//            {
//                var Thang = Request["Thang"].Split()[1];
//                var Nam = Request["Nam"].Split()[1];
//                var MaPhongBan = Request["MaPhongBan"];
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    //Get List Department
//                    var query = " select * from Department WHERE department_type = @departmentType order by department_name";
//                    List<Department> listDepartments = db.Database.SqlQuery<Department>(query, new SqlParameter("departmentType", "Phân xưởng sản xuất chính")).ToList<Department>();
//                    ViewBag.listDepartments = listDepartments;

//                    //Get list KH
//                    var sqlGetInfor = @"select pb_tc.MaPhongBan, (case when kh_th.SoNgayLamViec is null then 0 else kh_th.SoNgayLamViec end) as SoNgayLamViec, pb_tc.MaTieuChi, pb_tc.TenTieuChi, pb_tc.DonViDo, ISNULL(kh_th.SanLuong, 0) as SanLuong, kh_th.GhiChu from
//                                        ((select a.MaTieuChi, b.TenTieuChi, b.DonViDo, a.MaPhongBan from PhongBan_TieuChi a left outer join TieuChi b on a.MaTieuChi = b.MaTieuChi
//                                        where a.Thang = @month and a.Nam = @year and a.MaPhongBan = @departmentID) as pb_tc
//                                        left outer join
//                                        (select kh_a.MaPhongBan, kh_b.SoNgayLamViec, kh_a.MaTieuChi, kh_b.SanLuong, kh_a.ThoiGianNhapCuoiCung, kh_b.GhiChu  
//                                        from ((select a.MaPhongBan, b.MaTieuChi, Max(b.ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung 
//                                        from header_KeHoachTungThang a join KeHoach_TieuChi_TheoThang b 
//                                        on a.HeaderID = b.HeaderID join KeHoachTungThang khtt on a.ThangID = khtt.ThangID
//                                        where khtt.ThangKeHoach = @month and khtt.NamKeHoach = @year and a.MaPhongBan = @departmentID
//                                        group by a.MaPhongBan, b.MaTieuChi) as kh_a 
//                                        left outer join  
//                                        (select a.MaPhongBan, b.MaTieuChi, khtt.SoNgayLamViec, b.SanLuong, b.ThoiGianNhapCuoiCung, b.GhiChu 
//                                        from header_KeHoachTungThang a join KeHoach_TieuChi_TheoThang b 
//                                        on a.HeaderID = b.HeaderID join KeHoachTungThang khtt on a.ThangID = khtt.ThangID) as kh_b
//                                        on kh_a.MaTieuChi = kh_b.MaTieuChi and kh_a.MaPhongBan = kh_b.MaPhongBan and kh_a.ThoiGianNhapCuoiCung = kh_b.ThoiGianNhapCuoiCung)) as kh_th
//                                        on pb_tc.MaTieuChi = kh_th.MaTieuChi and pb_tc.MaPhongBan = kh_th.MaPhongBan)";
//                    List<KeHoachSanXuatTheoThang> listKH = db.Database.SqlQuery<KeHoachSanXuatTheoThang>(sqlGetInfor, new SqlParameter("month", Thang), new SqlParameter("year", Nam), new SqlParameter("@departmentID", MaPhongBan)).ToList();

//                    //check something by Duy Senpai :)
//                    string sqlchecksnlv = @"select *
//                                            from KeHoachTungThang where ThangKeHoach = @month and NamKeHoach = @year";
//                    KeHoachTungThang khtt = db.Database.SqlQuery<KeHoachTungThang>(sqlchecksnlv, new SqlParameter("month", Thang), new SqlParameter("year", Nam)).FirstOrDefault();
//                    string ck = "";
//                    int num = 0;
//                    if (khtt == null) ck = "0";
//                    else
//                    {
//                        ck = "1";
//                        num = khtt.SoNgayLamViec.Value;
//                    }
//                    return Json(new { SoNgayLamViec = listKH.Count == 0 ? 0 : listKH[0].SoNgayLamViec, listKH = listKH, check = ck, snlv = num }, JsonRequestBehavior.AllowGet);
//                }
//            }
//            catch (Exception e)
//            {
//                return null;
//            }
//        }

//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/nhapsnlv")]
//        [HttpPost]
//        public ActionResult AddSNLV()
//        {
//            int snlv = Convert.ToInt32(Request["snlv"]);
//            int thang = Convert.ToInt32(Request["thang"].Split()[1]);
//            int nam = Convert.ToInt32(Request["nam"].Split()[1]);
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                string sql = "select * from KeHoachTungThang where ThangKeHoach = @month and NamKeHoach = @year";
//                KeHoachTungThang checkadd = db.Database.SqlQuery<KeHoachTungThang>(sql, new SqlParameter("month", thang), new SqlParameter("year", nam)).FirstOrDefault();
//                if (checkadd != null)
//                {
//                    return Json(new { success = false, title = "Thêm không thành công", message = "Tháng này đã nhập số ngày sản xuất." });
//                }
//                using (DbContextTransaction transaction = db.Database.BeginTransaction())
//                {
//                    try
//                    {

//                        KeHoachTungThang kh = new KeHoachTungThang();
//                        kh.NamKeHoach = nam;
//                        kh.ThangKeHoach = thang;
//                        kh.SoNgayLamViec = snlv;
//                        db.KeHoachTungThangs.Add(kh);
//                        db.SaveChanges();
//                        transaction.Commit();
//                    }
//                    catch
//                    {
//                        transaction.Rollback();
//                    }
//                }
//            }

//            return Json(new { success = true, title = "Thành công", message = "Thêm kế hoạch tháng thành công." });
//        }

//        /////////////////////////////////INSERT OR UPDATE///////////////////////////////
//        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/nhap-du-lieu-hoac-cap")]
//        [HttpPost]
//        public ActionResult InsertOrUpdate()
//        {
//            try
//            {
//                var SoNgaySanXuat = Request["SoNgaySanXuat"];
//                SoNgaySanXuat = SoNgaySanXuat.Equals("") ? "0" : SoNgaySanXuat;
//                var Thang = Convert.ToInt32(Request["Thang"].Split()[1]);
//                var Nam = Convert.ToInt32(Request["Nam"].Split()[1]);
//                var MaPhongBan = Request["MaPhongBan"];
//                var listData = Request["listData"];
//                JObject listDataJObject = JObject.Parse(listData);
//                if (listDataJObject.SelectToken("list").ToString() == "[\r\n  {}\r\n]")
//                    return Json(new { success = false, title = "Có lỗi", message = "Phân xưởng chưa có tiêu chí" });
//                JArray listDataArray = (JArray)listDataJObject.SelectToken("list");


//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
//                    {
//                        //check KeHoachTungThang null
//                        var checkKHTT = @"select * from KeHoachTungThang where ThangKeHoach = @thang and NamKeHoach = @nam";
//                        KeHoachTungThang KHTT = db.Database.SqlQuery<KeHoachTungThang>(checkKHTT,
//                            new SqlParameter("@thang", Thang),
//                            new SqlParameter("@nam", Nam)).FirstOrDefault();

//                        if (KHTT == null)
//                        {
//                            //insert to KeHoachTungThang
//                            KeHoachTungThang khtt = new KeHoachTungThang();
//                            khtt.ThangKeHoach = Thang;
//                            khtt.NamKeHoach = Nam;
//                            khtt.SoNgayLamViec = Convert.ToInt32(SoNgaySanXuat);
//                            db.KeHoachTungThangs.Add(khtt);
//                            db.SaveChanges();
//                        }
//                        else
//                        {
//                            //check header null
//                            var checkHeader = @"select 
//                                                hd.*, 
//                                                kh.MaTieuChi, 
//                                                kh.SanLuong, 
//                                                kh.GhiChu, 
//                                                kh.ThoiGianNhapCuoiCung 
//                                                from header_KeHoachTungThang hd join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
//                                                where hd.MaPhongBan = @maphongban and hd.ThangID = @thangID";
//                            var header = db.Database.SqlQuery<header_KeHoach_TieuChi_TheoThang>(checkHeader,
//                                                                            new SqlParameter("@maphongban", MaPhongBan),
//                                                                            new SqlParameter("@thangID", KHTT.ThangID)).FirstOrDefault();
//                            header_KeHoachTungThang hdkh = new header_KeHoachTungThang();
//                            if (header == null)
//                            {
//                                //insert to Header_KeHoachTungThang
//                                hdkh.MaPhongBan = MaPhongBan;
//                                hdkh.ThangID = KHTT.ThangID;
//                                db.header_KeHoachTungThang.Add(hdkh);
//                                db.SaveChanges();
//                            }
//                            //insert to KeHoach_TieuChi_TheoThang
//                            foreach (JObject e in listDataArray)
//                            {
//                                KeHoach_TieuChi_TheoThang khtctt = new KeHoach_TieuChi_TheoThang();
//                                khtctt.HeaderID = (header == null) ? hdkh.HeaderID : header.HeaderID;
//                                khtctt.MaTieuChi = Convert.ToInt32(e["matieuchi"]);
//                                khtctt.SanLuong = Convert.ToDouble(e["sanluong"]);
//                                khtctt.GhiChu = (string)e["ghichu"] == null ? "" : (string)e["ghichu"];
//                                khtctt.ThoiGianNhapCuoiCung = DateTime.Now;
//                                db.KeHoach_TieuChi_TheoThang.Add(khtctt);
//                            }
//                            db.SaveChanges();
//                            transaction.Commit();
//                        }
//                        return Json(new { success = true, title = "Thành công", message = "Thêm kế hoạch tháng thành công." });
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                return Json(new { success = false, title = "Có lỗi", message = "Có lỗi xảy ra." });
//            }
//        }
//    }

//    public class header_KeHoach_TieuChi_TheoThang
//    {
//        public int HeaderID { get; set; }
//        public string MaPhongBan { get; set; }
//        public int ThangID { get; set; }
//        public int MaTieuChi { get; set; }
//        public double SanLuong { get; set; }
//        public string GhiChu { get; set; }
//        public DateTime ThoiGianNhapCuoiCung { get; set; }
//    }

//    public class KeHoachSanXuatTheoThang
//    {
//        public int MaTieuChi { get; set; }
//        public int SoNgayLamViec { get; set; }
//        public string TenTieuChi { get; set; }
//        public string DonViDo { get; set; }
//        public double SanLuong { get; set; }
//        public string GhiChu { get; set; }
//    }
//}