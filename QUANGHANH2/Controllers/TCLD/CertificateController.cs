using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class CertificateController : Controller
    {
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Certificate/List.cshtml");
        }

        [Route("phong-tcld/chung-chi/danh-sach-chung-chi")]
        [HttpPost]
        public ActionResult List()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<ChungChi> listdata = db.ChungChis.ToList<ChungChi>();
                var js = Json(new { success = true, data = listdata }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi-nhan-vien")]
        [HttpPost]
        public ActionResult ListEmployeeCirtificate()
        {
            List<ChungChi_NhanVien_Model> equipList = new List<ChungChi_NhanVien_Model>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                equipList = (from ccnv in db.ChungChi_NhanVien
                             join cc in db.ChungChis on ccnv.MaChungChi equals cc.MaChungChi
                             join nv in db.NhanViens on ccnv.MaNV equals nv.MaNV
                             select new
                             {
                                 SoHieu = ccnv.SoHieu,
                                 NgayCap = ccnv.NgayCap,
                                 MaNV = ccnv.MaNV,
                                 TenNV = nv.Ten,
                                 MaChungChi = ccnv.MaChungChi,
                                 TenChungChi = cc.TenChungChi,

                             }).ToList().Select(p => new ChungChi_NhanVien_Model
                             {

                                 SoHieu = p.SoHieu,
                                 NgayCap = p.NgayCap,
                                 MaNV = p.MaNV,
                                 MaChungChi = p.MaChungChi,
                                 TenNV = p.TenNV,
                                 TenChungChi = p.TenChungChi,
                             }).ToList();
                var dataJson = Json(new { success = true, data = equipList });

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }

        }

        [HttpGet]
        public ActionResult AddCertificate(int id = 0)
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddCertificate(ChungChi chungChi)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chungChi != null)
                {
                    db.ChungChis.Add(chungChi);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }


        }
        [HttpGet]
        public ActionResult AddCertificateEmployee(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<ChungChi> listdata_chungchi = db.ChungChis.ToList<ChungChi>();
                List<NhanVien> listdata_nv = db.NhanViens.ToList<NhanVien>();

                SelectList listCirtificate = new SelectList(listdata_chungchi, "MaChungChi", "TenChungChi");
                SelectList listEmployee = new SelectList(listdata_nv, "MaNV", "Ten");
                ViewBag.List_chungchi = listCirtificate;
                ViewBag.List_nhanvien = listEmployee;

                return View();
            }

        }
        [HttpPost]
        public ActionResult AddCertificateEmployee(ChungChi_NhanVien chungChi_nhanVien)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chungChi_nhanVien != null)
                {
                    db.ChungChi_NhanVien.Add(chungChi_nhanVien);
                    db.SaveChanges();

                }
                return RedirectToAction("List");
            }


        }
        [HttpGet]
        public ActionResult EditCertificate(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                ChungChi chungchi = db.ChungChis.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi>();
                return View(chungchi);
            }

        }
        [HttpPost]
        public ActionResult EditCertificate(ChungChi chungChi)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chungChi != null)
                {
                    db.Entry(chungChi).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        public ActionResult EditCertificateEmp(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<ChungChi> listdata_chungchi = db.ChungChis.ToList<ChungChi>();
                List<NhanVien> listdata_nv = db.NhanViens.ToList<NhanVien>();

                SelectList listCirtificate = new SelectList(listdata_chungchi, "MaChungChi", "TenChungChi");
                SelectList listEmployee = new SelectList(listdata_nv, "MaNV", "Ten");
                ViewBag.List_chungchi = listCirtificate;
                ViewBag.List_nhanvien = listEmployee;

                ChungChi_NhanVien chungchinv = db.ChungChi_NhanVien.Where(x => x.SoHieu == id).FirstOrDefault<ChungChi_NhanVien>();

                return View(chungchinv);
            }

        }
        [HttpPost]
        public ActionResult EditCertificateEmp(ChungChi_NhanVien chungchinv)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chungchinv != null)
                {
                    db.Entry(chungchinv).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        [HttpPost]
        public ActionResult DeleteCertificate(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                ChungChi chungChi = db.ChungChis.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi>();
                db.ChungChis.Remove(chungChi);
                var chungchi_nvs = db.ChungChi_NhanVien.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi_NhanVien>();
                if (chungchi_nvs != null)
                {
                    db.ChungChi_NhanVien.Remove(chungchi_nvs);
                }
                
                db.SaveChanges();
                return Json(new { success = true, message = "Delete successful" }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public ActionResult DeleteCertificateEmp(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                ChungChi_NhanVien chungchi_nv = db.ChungChi_NhanVien.Where(x => x.SoHieu == id).FirstOrDefault<ChungChi_NhanVien>();
                db.ChungChi_NhanVien.Remove(chungchi_nv);
                db.SaveChanges();
                return Json(new { success = true, message = "Delete successful" }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpGet]
        public ActionResult SearchCertificate(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<ChungChi> listdata = db.ChungChis.ToList<ChungChi>();
                SelectList listCirtificate = new SelectList(listdata, "MaChungChi", "TenChungChi");
                ChungChi chungchi = new ChungChi();
                ViewBag.List_chungchi = listCirtificate;
                return View(chungchi);
            }

        }

        [Route("phong-tcld/chung-chi/danh-sach-nhan-vien-co-chung-chi-kiem-dinh-ky-thuat-an-toan-lao-dong")]
        public ActionResult ListBriefsByCertificate()
        {
            ViewBag.nameDepartment = "vld-antoan";
            return View("/Views/TCLD/Certificate/ListBriefByCertificate.cshtml");
        }
        [Route("phong-tcld/chung-chi-chung-nhan-dao-tao")]
        public ActionResult ViewJobRegister()
        {
            ViewBag.nameDepartment = "vld-antoan";
            return View("/Views/TCLD/Certificate/ViewJobRegister.cshtml");
        }

        [Route("phong-tcld/dang-ky-cong-viec")]
        public ActionResult ViewJobByPX()
        {
            ViewBag.nameDepartment = "vld-antoan";
            return View("/Views/TCLD/Certificate/ViewJobByPX.cshtml");
        }
        [Route("phong-tcld/bao-cao-tinh-trang-chung-chi-cho-cong-viec")]
        public ActionResult ReportJob()
        {
            ViewBag.nameDepartment = "vld-antoan";
            return View("/Views/TCLD/Certificate/ReportJob.cshtml");
        }
    }
}