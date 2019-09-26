﻿using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.PX.PXKT
{
    public class PXKTController : Controller
    {
        [Route("phan-xuong-khai-thac")]
        public ActionResult Index()
        {
            return View("/Views/PX/PXKT/Report.cshtml");
        }
        [Route("phan-xuong-khai-thac/chi-tiet")]
        public ActionResult Detail()
        {
            return View("/Views/PX/PXKT/Detail.cshtml");
        }
        [Route("phan-xuong-khai-thac/nhap-du-lieu")]
        public ActionResult Add()
        {
            return View("/Views/PX/PXKT/Add.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong")]
        public ActionResult NSLD(string intCa, string strDate)
        {
            if (intCa == null)
            {
                intCa = "1";
            }
            if (strDate == null)
            {
                strDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            var calamviec = Convert.ToInt32(intCa);
            var date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<DiemDanh_NangSuatLaoDong> list = db.DiemDanh_NangSuatLaoDong
                    .Where(a => a.NgayDiemDanh == date)
                    .Where(a => a.CaDiemDanh == calamviec).ToList();
                List<BaoCaoTheoCa> customNSLDs = new List<BaoCaoTheoCa>();
                BaoCaoTheoCa cus;
                foreach (var i in list)
                {
                    cus = new BaoCaoTheoCa
                    {
                        ID = i.MaDiemDanh,
                        Name = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().Ten,
                        BacTho = "6/6",
                        ChucDanh = "MT",
                        DuBaoNguyCo = "Không kiểm tra thiết bị trước khi vận hành",
                        HeSoChiaLuong = i.HeSoChiaLuong.ToString(),
                        LuongSauDuyet = i.Luong.ToString(),
                        LuongTruocDuyet = i.Luong.ToString(),
                        NoiDungCongViec = db.Departments.Where(a => a.department_id == i.MaDonVi).First().department_name,
                        NSLD = i.NangSuatLaoDong,
                        SoThe = i.MaNV,
                        YeuCauBPKTAT = "Trước khi vận hành phải kiểm tra thiết bị đảm bảo an toàn trước khi được vận hành"
                    };
                    customNSLDs.Add(cus);
                }
                ViewBag.nsld = customNSLDs;
            }
            return View("/Views/PX/PXKT/NSLD.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong-update")]
        public void UpdateNSLD(int[] ids, string[] NSLDS, string intCa, string strDate)
        {
            int length = NSLDS.Length;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                for (int i = 0; i < length; i++)
                {
                    int id = ids[i];
                    string NSLD = NSLDS[i];
                    DiemDanh_NangSuatLaoDong f = db.DiemDanh_NangSuatLaoDong.FirstOrDefault(x => x.MaDiemDanh == id);
                    f.NangSuatLaoDong = NSLD;
                    db.SaveChanges();
                }
            }
            NSLD(intCa, strDate);
        }

        [Route("phan-xuong-khai-thac/diem-danh")]
        public ActionResult takeAttendanceView()
        {

            return View("/Views/PX/PXKT/takeAttendance.cshtml");
        }

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh")]
        public ActionResult takeAttendance()
        {
            // fixxing
            var departmentID = "DL1";
            var dateAtt = Convert.ToDateTime("2019-09-10");
            int ca = 1;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var listAttendance = (from emp in db.NhanViens
                                      join per in db.DiemDanh_NangSuatLaoDong
                                        .Where(per => per.MaDonVi == departmentID && per.NgayDiemDanh == dateAtt && per.CaDiemDanh == ca)
                                      on emp.MaNV equals per.MaNV into attendance
                                      from att in attendance.DefaultIfEmpty()
                                      select new
                                      {
                                          maNV = emp.MaNV,
                                          tenNV = emp.Ten,
                                          status = att.DiLam,
                                          timeAttendance = att.ThoiGianThucTeDiemDanh,
                                          dateAttendance = att.NgayDiemDanh,
                                          reason = att.LyDoVangMat,
                                          description = att.GhiChu
                                      }).OrderBy(att => att.status).ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }


    }
    public class BaoCaoTheoCa
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SoThe { get; set; }
        public string BacTho { get; set; }
        public string ChucDanh { get; set; }
        public string NoiDungCongViec { get; set; }
        public string NSLD { get; set; }
        public string HeSoChiaLuong { get; set; }
        public string LuongTruocDuyet { get; set; }
        public string LuongSauDuyet { get; set; }
        public string DuBaoNguyCo { get; set; }
        public string YeuCauBPKTAT { get; set; }
    }
}