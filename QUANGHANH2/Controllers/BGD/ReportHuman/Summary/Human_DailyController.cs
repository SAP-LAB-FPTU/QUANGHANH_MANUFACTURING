using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.ReportHuman
{
    public class ReportHuman_SummaryController : Controller
    {
        [Route("ban-giam-doc/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-luc-theo-ngay")]
        public ActionResult Index()
        {
            return View("/Views/BGD/ReportHuman/Summary/Human_Daily.cshtml");
        }

        [Route("ban-giam-doc/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-luc-theo-ngay/takeData")]
        [HttpPost]
        public ActionResult takeData()
        {
            try
            {
                string date = Request["date"];
                DateTime converted_date;
                if (date == null || date == "") 
                {
                    converted_date = DateTime.Now; 
                } else
                {
                    converted_date = DateTime.Parse(date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0]);
                }
                string mySql = @"select
                                (case when nv_cv.DiLam_CNKT is null then 0 else nv_cv.DiLam_CNKT end) as 'DiLam_CNKT',
                                (case when nv_cv.Nghi_CNKT is null then 0 else nv_cv.Nghi_CNKT end) as 'Nghi_CNKT',
                                (case when nv_cv.DiLam_CNCD is null then 0 else nv_cv.DiLam_CNCD end) as 'DiLam_CNCD',
                                (case when nv_cv.Nghi_CNCD is null then 0 else nv_cv.Nghi_CNCD end) as 'Nghi_CNCD',
                                (case when nv_cv.DiLam_CNMB is null then 0 else nv_cv.DiLam_CNMB end) as 'DiLam_CNMB',
                                (case when nv_cv.Nghi_CNMB is null then 0 else nv_cv.Nghi_CNMB end) as 'Nghi_CNMB',
                                (case when nv_cv.DiLam_QLPB_NV is null then 0 else nv_cv.DiLam_QLPB_NV end) as 'DiLam_QLPB_NV',
                                (case when nv_cv.Nghi_QLPB_NV is null then 0 else nv_cv.Nghi_QLPB_NV end) as 'Nghi_QLPB_NV'
                                from
                                (select 
                                sum(case when (nv_cv.TenNhomCongViec = N'Công nhân khai thác' and nv_cv.DiLam = 1) then 1 else 0 end) as 'DiLam_CNKT',
                                sum(case when (nv_cv.TenNhomCongViec = N'Công nhân khai thác' and nv_cv.DiLam = 0) then 1 else 0 end) as 'Nghi_CNKT',
                                sum(case when (nv_cv.TenNhomCongViec = N'Công nhân cơ điện' and nv_cv.DiLam = 1) then 1 else 0 end) as 'DiLam_CNCD',
                                sum(case when (nv_cv.TenNhomCongViec = N'Công nhân cơ điện' and nv_cv.DiLam = 0) then 1 else 0 end) as 'Nghi_CNCD',
                                sum(case when ((nv_cv.DiLam = 1 and nv_cv.MaPhongBan in (N'ĐS', N'PV', N'XD', N'CKCS', N'PXCBT')) 
				                                or (nv_cv.DiLam = 1 and nv_cv.TenCongViec in (N'(Công nhân) Bắn mìn lộ thiên', 
																                                N'(Công nhân) Sửa chữa cơ điện trên các mỏ lộ thiên',
																                                N'Công nhân vận hành trạm cảnh báo khí, gió mỏ',
																                                N'Công nhân lao động phổ thông',
																                                N'Công nhân trực thông tin',
																                                N'(Công nhân) vận hành, bảo trì trạm biến thế trung thế'))) then 1 else 0 end) as 'DiLam_CNMB',
                                sum(case when ((nv_cv.DiLam = 0 and nv_cv.MaPhongBan in (N'ĐS', N'PV', N'XD', N'CKCS', N'PXCBT')) 
				                                or (nv_cv.DiLam = 0 and nv_cv.TenCongViec in (N'(Công nhân) Bắn mìn lộ thiên', 
																                                N'(Công nhân) Sửa chữa cơ điện trên các mỏ lộ thiên',
																                                N'Công nhân vận hành trạm cảnh báo khí, gió mỏ',
																                                N'Công nhân lao động phổ thông',
																                                N'Công nhân trực thông tin',
																                                N'(Công nhân) vận hành, bảo trì trạm biến thế trung thế'))) then 1 else 0 end) as 'Nghi_CNMB',
                                sum(case when (nv_cv.DiLam = 1 and nv_cv.TenCongViec in (N'Giám Đốc', N'Phó giám đốc', N'Trưởng phòng', N'Phó trưởng phòng', N'Chuyên viên',
															                                N'Cán sự')) then 1 else 0 end) as 'DiLam_QLPB_NV',
                                sum(case when (nv_cv.DiLam = 0 and nv_cv.TenCongViec in (N'Giám Đốc', N'Phó giám đốc', N'Trưởng phòng', N'Phó trưởng phòng', N'Chuyên viên',
															                                N'Cán sự')) then 1 else 0 end) as 'Nghi_QLPB_NV'															 
                                from
                                (select 
                                dd.MaNV,
                                nv_cv.MaPhongBan, 
                                dd.DiLam,
                                nv_cv.Ten, 
                                nv_cv.TenCongViec, 
                                nv_cv.TenNhomCongViec
                                from
                                (select dd.MaNV, dd.DiLam
                                from
                                (select 
                                Min(hd.HeaderID) as 'HeaderID' 
                                from Header_DiemDanh_NangSuat_LaoDong hd 
                                where hd.NgayDiemDanh = @date and hd.Status = 1) as hd 
                                join
                                DiemDanh_NangSuatLaoDong dd on dd.HeaderID = hd.HeaderID) as dd
                                join
                                (select 
                                nv.MaNV,
                                nv.Ten,
                                cv.TenCongViec,
                                ncv.TenNhomCongViec,
                                nv.MaPhongBan
                                from NhanVien nv 
                                left join CongViec cv on nv.MaCongViec = cv.MaCongViec 
                                left join CongViec_NhomCongViec cv_ncv on cv.MaCongViec = cv_ncv.MaCongViec
                                left join NhomCongViec ncv on ncv.MaNhomCongViec = cv_ncv.MaNhomCongViec
                                where nv.MaTrangThai = 1) as nv_cv on nv_cv.MaNV = dd.MaNV) as nv_cv) as nv_cv";
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var humanReport = db.Database.SqlQuery<HumanReport>(mySql, new SqlParameter("@date", converted_date)).ToList();
                    return Json(new { success = true, title = "Thành công", message = "Tải dữ liệu thành công" , humanReport = humanReport});
                }
            } catch (Exception e)
            {
                return Json(new { error = true, title= "Lỗi", message = "Có lỗi xảy ra" });
            }
        }
    }
}

public class HumanReport
{
    public int DiLam_CNKT { get; set; }
    public int Nghi_CNKT { get; set; }
    public int DiLam_CNCD { get; set; }
    public int Nghi_CNCD { get; set; }
    public int DiLam_CNMB { get; set; }
    public int Nghi_CNMB { get; set; }
    public int DiLam_QLPB_NV { get; set; }
    public int Nghi_QLPB_NV { get; set; }
}