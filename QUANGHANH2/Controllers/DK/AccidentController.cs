using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;

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

                    string output = "";
                    if (output == "")
                        output += "vui lòng kiểm tra ngày nhập";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
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
}