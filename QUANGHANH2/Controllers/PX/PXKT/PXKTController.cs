﻿using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                        DuBaoNguyCo = i.DuBaoNguyCo,
                        HeSoChiaLuong = i.HeSoChiaLuong.ToString(),
                        LuongSauDuyet = i.Luong.ToString(),
                        LuongTruocDuyet = i.Luong.ToString(),
                        NoiDungCongViec = db.Departments.Where(a => a.department_id == i.MaDonVi).First().department_name,
                        NSLD = i.NangSuatLaoDong.ToString(),
                        SoThe = i.MaNV,
                        YeuCauBPKTAT = i.GiaiPhapNguyCo
                    };
                    customNSLDs.Add(cus);
                }
                ViewBag.nsld = customNSLDs;
            }
            return View("/Views/PX/PXKT/NSLD.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong-update")]
        public void UpdateNSLD(
            string intCa,
            string[] MaDiemDanhs,
            string[] NangSuatLaoDongs,
            string[] HeSoChiaLuongs,
            string[] Luongs,
            string[] DuBaoNguyCos,
            string[] GiaiPhapNguyCos,
            string date)
        {
            int length = MaDiemDanhs.Length;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < length; i++)
                        {
                            int MaDiemDanh = Convert.ToInt32(MaDiemDanhs[i]);
                            DiemDanh_NangSuatLaoDong f = db.DiemDanh_NangSuatLaoDong.FirstOrDefault(x => x.MaDiemDanh == MaDiemDanh);
                            f.NangSuatLaoDong = Convert.ToDouble(String.IsNullOrEmpty(NangSuatLaoDongs[i]) ? "0" : NangSuatLaoDongs[i]);
                            f.HeSoChiaLuong = Convert.ToDouble(String.IsNullOrEmpty(HeSoChiaLuongs[i]) ? "0" : HeSoChiaLuongs[i]);
                            f.Luong = Convert.ToDouble(String.IsNullOrEmpty(Luongs[i]) ? "0" : Luongs[i]);
                            f.DuBaoNguyCo = DuBaoNguyCos[i];
                            f.GiaiPhapNguyCo = GiaiPhapNguyCos[i];
                            db.SaveChanges();
                        }
                        


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }             
                
            }
            
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

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh/cap-nhat")]
        public ActionResult updateAttendance()
        {
            var listUpdate = Request["sessionId "];
            return View();
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