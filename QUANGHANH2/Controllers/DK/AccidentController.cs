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
        [Route("phong-dieu-khien/bao-cao-tai-nan/insertaccident")]
        [HttpPost]
        public ActionResult InsertMaintainCar(List<TaiNanDB> maintain)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //Truncate Table to delete all old records.
                //Check for NULL.
                try
                {
                    TaiNan t = new TaiNan();
                   
                    foreach (TaiNanDB item in maintain)
                    {
                        if (item.MaNV == null || db.NhanViens.Find(item.MaNV) == null)
                        {
                            transaction.Rollback();
                            Response.Write("Mã nhân viên không tồn tại");
                            return new HttpStatusCodeResult(400);
                        }
                      
                        t.MaNV = item.MaNV;
                        t.LyDo = item.LyDo;
                        t.Ca = item.Ca;
                        string date = DateTime.ParseExact(item.stringDate, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                   
                        t.Ngay = DateTime.Parse(date);
                        db.TaiNans.Add(t);
                        db.SaveChanges();

                    }

                   
                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }

            }

        }
        [Route("phong-dieu-khien/bao-cao-tai-nan/returnEmployeeName")]
        [HttpPost]
        public JsonResult returnEmployeename(String MaNV)
        {

            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                NhanVien nv = db.NhanViens.Where(x => x.MaNV == MaNV).SingleOrDefault();
                Department d= db.Departments.Where(x => x.department_id == nv.MaPhongBan).SingleOrDefault();

                //String item = equipment.supply_name + "^" + equipment.unit;
                return Json(new
                {
                    Ten = nv.Ten,
                    department_name = d.department_name
                }, JsonRequestBehavior.AllowGet) ; ;
            }
            catch (Exception)
            {
                return Json("Mã nhân viên không tồn tại", JsonRequestBehavior.AllowGet);
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
        public Nullable<int> Ca { get; set; }
        public Nullable<DateTime> Ngay { get; set; }
    }
}