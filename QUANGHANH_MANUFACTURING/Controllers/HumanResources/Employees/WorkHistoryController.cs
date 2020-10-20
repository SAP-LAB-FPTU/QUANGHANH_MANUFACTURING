using QUANGHANH_MANUFACTURING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
using System.Data.SqlClient;

namespace QUANGHANH_MANUFACTURING.Controllers.TCLD
{
    public class WorkHistoryController : Controller
    {
        // GET: WorkHistory
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[Route("lich-su-lam-viec")]
        //[HttpGet]
        //public ActionResult WorkHistory()
        //{
        //    var id = Request["id"];
        //    return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        //}

        [Route("phong-tcld/quan-ly-nhan-vien/lich-su-lam-viec")]
        //[HttpPost]
        public ActionResult workHistoryOfEmployee(string id)
        {
            try
            {
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                ProfileNhanVien nhanVien = db.Database.SqlQuery<ProfileNhanVien>(@"SELECT NhanVien.MaNV, NhanVien.Ten, NhanVien.GioiTinh, NhanVien.NgaySinh, NhanVien.NoiOHienTai, Department.department_name, CongViec.TenCongViec
FROM     NhanVien INNER JOIN
                  CongViec ON NhanVien.MaCongViec = CongViec.MaCongViec INNER JOIN
                  Department ON NhanVien.MaPhongBan = Department.department_id
WHERE NhanVien.MaNV = @id", new SqlParameter("id", id)).FirstOrDefault();
                ViewBag.error = 0;
                ViewBag.MaNV = nhanVien.MaNV;
                ViewBag.Ten = nhanVien.Ten;
                ViewBag.GioiTinh = nhanVien.GioiTinh == true ? "Nam" : "Nữ";
                ViewBag.NgaySinh = nhanVien.NgaySinh == null ? "" : nhanVien.NgaySinh.Value.ToString("dd/MM/yyyy");
                ViewBag.NoiOHienTai = nhanVien.NoiOHienTai;
                ViewBag.department_name = nhanVien.department_name;
                ViewBag.TenCongViec = nhanVien.TenCongViec;
                Nullable<DateTime> dateMax = db.Database.SqlQuery<Nullable<DateTime>>("select max(h.NgayDiemDanh) from DiemDanh_NangSuatLaoDong as d inner join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID where MaNV = @id", new SqlParameter("id", id)).FirstOrDefault();
                ViewBag.NgayDiLamGanNhat = dateMax == null ? "Không có dữ liệu" : dateMax.Value.ToString("dd/MM/yyyy");
            }
            catch (Exception e)
            {
                ViewBag.error = 1;
            }
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }

        [HttpPost]
        public ActionResult getDataHistoryWork(string id)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    List<DiemDanh> listDiemDanhById = db.Database.SqlQuery<DiemDanh>("select h.NgayDiemDanh, h.Ca, d.GhiChu from Header_DiemDanh_NangSuat_LaoDong h inner join DiemDanh_NangSuatLaoDong d on h.HeaderID = d.HeaderID where d.MaNV = @MaNV order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY", new SqlParameter("MaNV", id)).ToList();
                    int totalrows = db.Database.SqlQuery<int>("select count(h.NgayDiemDanh) from Header_DiemDanh_NangSuat_LaoDong h inner join DiemDanh_NangSuatLaoDong d on h.HeaderID = d.HeaderID where d.MaNV = @MaNV", new SqlParameter("MaNV", id)).FirstOrDefault();

                    return Json(new { success = true, data = listDiemDanhById, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet); ;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private class DiemDanh
        {
            public DateTime NgayDiemDanh { get; set; }
            public int Ca { get; set; }
            public string GhiChu { get; set; }
        }

        private class ProfileNhanVien
        {
            public string MaNV { get; set; }
            public string Ten { get; set; }
            public bool GioiTinh { get; set; }
            public Nullable<DateTime> NgaySinh { get; set; }
            public string NoiOHienTai { get; set; }
            public string department_name { get; set; }
            public string TenCongViec { get; set; }
        }
    }
}
