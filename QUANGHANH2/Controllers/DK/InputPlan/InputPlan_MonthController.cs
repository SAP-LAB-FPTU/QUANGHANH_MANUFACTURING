using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.InputPlan
{
    public class InputPlan_MonthController : Controller
    {
        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang")]
        public ActionResult Index()
        {
            return View("/Views/DK/InputPlan/InputPlan_Month.cshtml");
        }

        //////////////////////////////GET INFOR/////////////////////////////
        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/lay-thong-tin")]
        [HttpPost]
        public ActionResult GetInformation()
        {
            try
            {
                var Thang = Request["Thang"].Split()[1];
                var Nam = Request["Nam"].Split()[1];
                var MaPhongBan = Request["MaPhongBan"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    //get data's table to paging
                    int start = Convert.ToInt32(Request["start"]);
                    int length = Convert.ToInt32(Request["length"]);
                    string searchValue = Request["search[value]"];
                    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                    string sortDirection = Request["order[0][dir]"];

                    var sqlGetInfor = @"select pb_tc.MaPhongBan, (case when kh_th.SoNgayLamViec is null then 0 else kh_th.SoNgayLamViec end) as SoNgayLamViec, pb_tc.MaTieuChi, pb_tc.TenTieuChi, pb_tc.DonViDo, ISNULL(kh_th.SanLuong, 0) as SanLuong, kh_th.GhiChu from
                                        ((select a.MaTieuChi, b.TenTieuChi, b.DonViDo, a.MaPhongBan from PhongBan_TieuChi a left outer join TieuChi b on a.MaTieuChi = b.MaTieuChi
                                        where a.Thang = @month and a.Nam = @year and a.MaPhongBan = @departmentID) as pb_tc
                                        left outer join
                                        (select kh_a.MaPhongBan, kh_b.SoNgayLamViec, kh_a.MaTieuChi, kh_b.SanLuong, kh_a.ThoiGianNhapCuoiCung, kh_b.GhiChu  
                                        from ((select a.MaPhongBan, b.MaTieuChi, Max(b.ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung 
                                        from header_KeHoachTungThang a join KeHoach_TieuChi_TheoThang b 
                                        on a.HeaderID = b.HeaderID 
                                        where a.ThangKeHoach = @month and a.NamKeHoach = @year and a.MaPhongBan = @departmentID
                                        group by a.MaPhongBan, b.MaTieuChi) as kh_a 
                                        left outer join  
                                        (select a.MaPhongBan, b.MaTieuChi, a.SoNgayLamViec, b.SanLuong, b.ThoiGianNhapCuoiCung, b.GhiChu 
                                        from header_KeHoachTungThang a join KeHoach_TieuChi_TheoThang b 
                                        on a.HeaderID = b.HeaderID) as kh_b
                                        on kh_a.MaTieuChi = kh_b.MaTieuChi and kh_a.MaPhongBan = kh_b.MaPhongBan and kh_a.ThoiGianNhapCuoiCung = kh_b.ThoiGianNhapCuoiCung)) as kh_th
                                        on pb_tc.MaTieuChi = kh_th.MaTieuChi and pb_tc.MaPhongBan = kh_th.MaPhongBan)
                                        order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";

                    int totalrows = db.NhomCongViecs.Count();
                    int totalrowsafterfiltering = totalrows;
                    List<KeHoachSanXuatTheoThang> listKH = db.Database.SqlQuery<KeHoachSanXuatTheoThang>(sqlGetInfor, new SqlParameter("month", Thang), new SqlParameter("year", Nam), new SqlParameter("departmentID", MaPhongBan)).ToList();
                    return Json(new { SoNgayLamViec = listKH.Count == 0 ? 0 : listKH[0].SoNgayLamViec, listKH = listKH, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /////////////////////////////////INSERT OR UPDATE///////////////////////////////
        [Route("phong-dieu-khien/ke-hoach-san-xuat-thang/nhap-du-lieu-hoac-cap-nhat")]
        [HttpPost]
        public ActionResult InsertOrUpdate()
        {
            try
            {
                var SoNgaySanXuat = Request["SoNgaySanXuat"];
                SoNgaySanXuat = SoNgaySanXuat.Equals("") ? "0" : SoNgaySanXuat;
                var Thang = Convert.ToInt32(Request["Thang"].Split()[1]);
                var Nam = Convert.ToInt32(Request["Nam"].Split()[1]);
                var MaPhongBan = Request["MaPhongBan"];
                var listData = Request["listData"];
                JObject listDataJObject = JObject.Parse(listData);
                JArray listDataArray = (JArray)listDataJObject.SelectToken("list");


                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        var checkHeaderNull = @"select * from header_KeHoachTungThang 
                                            where MaPhongBan = @maphongban and ThangKeHoach = @thang and NamKeHoach = @nam";
                        var listHeader = db.Database.SqlQuery<header_KeHoachTungThang>(checkHeaderNull, new SqlParameter("maphongban", MaPhongBan), new SqlParameter("thang", Thang), new SqlParameter("nam", Nam)).FirstOrDefault();
                        //header null -> insert
                        if (listHeader == null)
                        {
                            //insert to header_KeHoachTungThang
                            listHeader = new header_KeHoachTungThang();
                            listHeader.MaPhongBan = MaPhongBan;
                            listHeader.ThangKeHoach = Thang;
                            listHeader.NamKeHoach = Nam;
                            listHeader.SoNgayLamViec = Convert.ToInt32(SoNgaySanXuat);
                            db.header_KeHoachTungThang.Add(listHeader);
                            db.SaveChanges();
                        }
                        else
                        {
                            //update header_KeHoachTungThang
                            var update = db.header_KeHoachTungThang.Find(listHeader.HeaderID);
                            update.MaPhongBan = MaPhongBan;
                            update.ThangKeHoach = Thang;
                            update.NamKeHoach = Nam;
                            update.SoNgayLamViec = Convert.ToInt32(SoNgaySanXuat);
                            db.SaveChanges();
                        }
                        //insert to KeHoachTungThang
                        foreach (JObject item in listDataArray)
                        {
                            KeHoach_TieuChi_TheoThang kht = new KeHoach_TieuChi_TheoThang();
                            var headerid = listHeader.HeaderID;
                            kht.HeaderID = headerid;
                            kht.MaTieuChi = Convert.ToInt32(item["matieuchi"]);
                            kht.SanLuong = Convert.ToDouble(item["sanluong"]);
                            kht.GhiChu = (string)item["ghichu"] == null ? "" : (string)item["ghichu"];
                            kht.ThoiGianNhapCuoiCung = DateTime.Now;
                            db.KeHoach_TieuChi_TheoThang.Add(kht);
                        }
                        //insert to KeHoachTungThang
                        db.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, title = "Thành công", message = "Thêm kế hoạch tháng thành công." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }
    }

    public class KeHoachSanXuatTheoThang
    {
        public int MaTieuChi { get; set; }
        public int SoNgayLamViec { get; set; }
        public string TenTieuChi { get; set; }
        public string DonViDo { get; set; }
        public double SanLuong { get; set; }
        public string GhiChu { get; set; }
    }
}