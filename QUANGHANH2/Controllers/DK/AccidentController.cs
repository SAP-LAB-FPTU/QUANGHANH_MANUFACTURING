using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.DK
{
    public class AccidentController : Controller
    {
        //[Auther(RightID = "158")] 
        [Route("phong-dieu-khien/bao-cao-tai-nan")]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            List<NhanVien> listNhanVien = db.NhanViens.ToList<NhanVien>();


            ViewBag.listNhanVien = listNhanVien;

            return View("/Views/DK/Acident.cshtml");
        }
        [Route("phong-dieu-khien/danh-sach-tai-nan")]
        public ActionResult DanhSachBaoCao()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<NhanVien> listNhanVien = db.NhanViens.ToList<NhanVien>();
            ViewBag.listNhanVien = listNhanVien;
            return View("/Views/DK/ListAccident.cshtml");
        }
        [Route("phong-dieu-khien/danh-sach-tai-nan")]
        [HttpPost]
        public ActionResult getData()
        {

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var listTainan = (from tainan in db.TaiNans
                                  join nhanvien in db.NhanViens on tainan.MaNV equals nhanvien.MaNV
                                  join depart in db.Departments on nhanvien.MaPhongBan equals depart.department_id
                                  select new dsTainan
                                  {
                                      MaTaiNan = tainan.MaTaiNan,
                                      MaNV = tainan.MaNV,
                                      Ten = nhanvien.Ten,
                                      department_name = depart.department_name,
                                      LyDo = tainan.LyDo,
                                      Loai = tainan.Loai,
                                      Ca = tainan.Ca,
                                      Ngay = tainan.Ngay,
                                  }
                                  ).ToList();
                int totalrows = listTainan.Count;
                int totalrowsafterfiltering = listTainan.Count;
                listTainan = listTainan.OrderBy(sortColumnName + " " + sortDirection).ToList<dsTainan>();
                listTainan = listTainan.Skip(start).Take(length).ToList<dsTainan>();
                var js = Json(new { success = true, data = listTainan, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }
        [Route("phong-dieu-khien/danh-sach-tai-nan/them")]
        [HttpPost]
        public JsonResult ThemTaiNan(TaiNan tn)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.NhanViens.Where(x => x.MaNV == tn.MaNV).Count() > 0)
                {
                    db.TaiNans.Add(tn);
                    db.SaveChanges();
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);

        }
        [Route("phong-dieu-khien/danh-sach-tai-nan/sua")]
        [HttpPost]
        public JsonResult SuaTaiNan(TaiNan tn)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.NhanViens.Where(x => x.MaNV == tn.MaNV).Count() > 0)
                {
                    var tainan = db.TaiNans.Where(x => x.MaTaiNan == tn.MaTaiNan).SingleOrDefault();
                    tainan.MaNV = tn.MaNV;
                    tainan.LyDo = tn.LyDo;
                    tainan.Loai = tn.Loai;
                    tainan.Ngay = tn.Ngay;
                    tainan.Ca = tn.Ca;
                    db.Entry(tainan).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);

        }
        [Route("phong-dieu-khien/danh-sach-tai-nan/xoa")]
        [HttpPost]
        public JsonResult XoaTaiNan(int id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var tainan = db.TaiNans.Where(x => x.MaTaiNan == id).FirstOrDefault();
                db.TaiNans.Remove(tainan);
                db.SaveChanges();
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [Route("phong-dieu-khien/bao-cao-tai-nan/returnEmployeeName")]
        [HttpPost]
        public JsonResult returnEmployeename(String MaNV)
        {

            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                NhanVien nv = db.NhanViens.Where(x => x.MaNV == MaNV).SingleOrDefault();
                Department d = db.Departments.Where(x => x.department_id == nv.MaPhongBan).SingleOrDefault();

                //String item = equipment.supply_name + "^" + equipment.unit;
                return Json(new
                {
                    Ten = nv.Ten,
                    department_name = d.department_name
                }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception)
            {
                return Json("Mã nhân viên không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }

        [Route("phong-dieu-khien/danh-sach-tai-nan/getid")]
        [HttpPost]
        public JsonResult GetTaiNan(int id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var Tainan = (from tainan in db.TaiNans.Where(x=>x.MaTaiNan == id)
                                  join nhanvien in db.NhanViens on tainan.MaNV equals nhanvien.MaNV
                                  join depart in db.Departments on nhanvien.MaPhongBan equals depart.department_id
                                  select new dsTainan
                                  {
                                      MaTaiNan = tainan.MaTaiNan,
                                      MaNV = tainan.MaNV,
                                      Ten = nhanvien.Ten,
                                      department_name = depart.department_name,
                                      LyDo = tainan.LyDo,
                                      Loai = tainan.Loai,
                                      Ca = tainan.Ca,
                                      Ngay = tainan.Ngay,
                                  }
                                  ).FirstOrDefault();
                return Json(Tainan, JsonRequestBehavior.AllowGet);
            }
        }
    }
    public class TaiNanDB : TaiNan
    {
        public String stringDate { get; set; }
    }
    public class dsTainan
    {
        public int MaTaiNan { get; set; }
        public string MaNV { get; set; }
        public string Ten { get; set; }
        public string department_name { get; set; }
        public string LyDo { get; set; }
        public string Loai { get; set; }
        public Nullable<int> Ca { get; set; }
        public Nullable<DateTime> Ngay { get; set; }
    }
}