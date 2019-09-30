﻿
using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
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
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                db.Configuration.ProxyCreationEnabled = false;
                List<ChungChi> listdata = db.ChungChis.ToList<ChungChi>();

                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<ChungChi>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<ChungChi>();
                var js = Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi-nhan-vien")]
        [HttpPost]
        public ActionResult ListEmployeeCirtificate()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
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
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<ChungChi_NhanVien_Model>();
                //paging
                equipList = equipList.Skip(start).Take(length).ToList<ChungChi_NhanVien_Model>();
                var dataJson = Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }

        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            getListTypeCertificate();

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
        public ActionResult AddCertificateEmployee()
        {
            getListInforEmployeeCirtificate();
            return View();

        }
        public void getListInforEmployeeCirtificate()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                List<ChungChi> listdata_chungchi = db.ChungChis.ToList<ChungChi>();
                List<NhanVien> listdata_nv = db.NhanViens.ToList<NhanVien>();

                SelectList listCirtificate = new SelectList(listdata_chungchi, "MaChungChi", "TenChungChi");
                SelectList listEmployee = new SelectList(listdata_nv, "MaNV", "MaNV");

                ViewBag.List_chungchi = listCirtificate;
                ViewBag.List_nhanvien = listEmployee;
                ViewBag.listdata_nv = listdata_nv;

            }
        }
        [HttpPost]
        public ActionResult validateID(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var chungchi_nvs = db.ChungChi_NhanVien.Where(x => x.SoHieu == id).FirstOrDefault<ChungChi_NhanVien>();
                if (chungchi_nvs != null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public ActionResult validateExistCirtificateOfEmp(string manv, int id,string first_cir)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var chungchi_nvs = db.ChungChi_NhanVien.Where(x => (x.MaNV == manv) &&(x.MaChungChi==id)).FirstOrDefault<ChungChi_NhanVien>();
                if (chungchi_nvs != null)
                {
                    if (first_cir != "" && (chungchi_nvs.MaChungChi.ToString()).Equals(first_cir))
                    {
                        return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (first_cir != "" && !(chungchi_nvs.MaChungChi.ToString()).Equals(first_cir))
                    {
                        return Json(new { success = true, message = "right id" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult validateNameCirtificare(string name)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var chungchi = db.ChungChis.Where(x => x.TenChungChi == name).FirstOrDefault<ChungChi>();
                if (chungchi != null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult getNameEmployee(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var chungchi_nvs = db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>();
                if (chungchi_nvs != null)
                {
                    return Json(new { data = chungchi_nvs.Ten, success = true, message = "success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Không tồn tại", success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
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

                getListTypeCertificate();
                ChungChi chungchi = db.ChungChis.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi>();
                return View(chungchi);
            }

        }
        public void getListTypeCertificate()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "Vĩnh viễn");
            list.Add(2, "Thời hạn");

            SelectList listOption = new SelectList(list, "Key", "Value");
            ViewBag.listOption = listOption;
            Dictionary<int, string> listTypes = new Dictionary<int, string>();
            listTypes.Add(1, "Photo");
            listTypes.Add(2, "Sao, Công chứng");
            listTypes.Add(3, "Bản gốc");
            listTypes.Add(4, "Dấu đỏ");
            SelectList listTypeCert = new SelectList(listTypes, "Value", "Value");
            ViewBag.listTypeCert = listTypeCert;
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
                getListInforEmployeeCirtificate();
                   var cirtificate_emp = db.ChungChi_NhanVien.Where(x => x.SoHieu == id).FirstOrDefault<ChungChi_NhanVien>();
                if (cirtificate_emp != null)
                {
                    var emp = db.NhanViens.Where(x => x.MaNV == cirtificate_emp.MaNV).FirstOrDefault<NhanVien>();
                    if (emp != null)
                    {
                        ViewBag.nameEmp = emp.Ten;
                        ViewBag.first_cir = cirtificate_emp.MaChungChi;
                    }
                }


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
                //List<ChungChi_NhanVien> ccnv = new List<ChungChi_NhanVien>();
                var ccnv = from item in db.ChungChi_NhanVien
                       where item.MaChungChi==id
                       select item;
                //var chungchi_nvs = db.ChungChi_NhanVien.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi_NhanVien>();
                if (ccnv != null)
                {
                    foreach (var item in ccnv)
                    {
                        db.ChungChi_NhanVien.Remove(item);
                    }

                }

                db.SaveChanges();
                return Json(new { success = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public ActionResult DeleteCertificateEmp(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                ChungChi_NhanVien chungchi_nv = db.ChungChi_NhanVien.Where(x => x.SoHieu == id).FirstOrDefault<ChungChi_NhanVien>();
                if (chungchi_nv != null)
                {
                    db.ChungChi_NhanVien.Remove(chungchi_nv);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = "Xóa thất bại" }, JsonRequestBehavior.AllowGet);
                }
                

            }
        }
        //[Route("phong-tcld/chung-chi/tim-kiem-danh-sach-chung-chi")]
        [HttpPost]
        public ActionResult SearchCertificate(string TenChungChi)
        {
            var a = TenChungChi;
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ChungChi> listdataSearch = new List<ChungChi>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                if (TenChungChi != null)
                {

                    listdataSearch = (from cc in db.ChungChis
                                      where (cc.TenChungChi.Contains(TenChungChi))
                                      select new
                                      {
                                          cc.MaChungChi,
                                          cc.TenChungChi,
                                          cc.ThoiHan,
                                          cc.KieuChungChi
                                      }).ToList().Select(p => new ChungChi
                                      {

                                          MaChungChi = p.MaChungChi,
                                          TenChungChi = p.TenChungChi,
                                          ThoiHan = p.ThoiHan,
                                          KieuChungChi = p.KieuChungChi,
                                      }).ToList();

                }
                int totalrows = listdataSearch.Count;
                int totalrowsafterfiltering = listdataSearch.Count;
                listdataSearch = listdataSearch.OrderBy(sortColumnName + " " + sortDirection).ToList<ChungChi>();
                //paging
                listdataSearch = listdataSearch.Skip(start).Take(length).ToList<ChungChi>();
                var js = Json(new { success = true, data = listdataSearch, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }

        }

        [HttpPost]
        public ActionResult SearchCertificateByNV(string ListSearch)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ChungChi_NhanVien_Model> equipList = new List<ChungChi_NhanVien_Model>();
            string[] idsArray = ListSearch.Split(',').ToArray();
            var sohieu = idsArray[0];
            var tenchungchi = idsArray[1];
            var tennv = idsArray[2];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                if (sohieu != null|| tenchungchi != null|| tennv != null)
                {

                    equipList = (from ccnv in db.ChungChi_NhanVien where (ccnv.SoHieu.Contains(sohieu))
                                 join cc in db.ChungChis on ccnv.MaChungChi equals cc.MaChungChi
                                 where (cc.TenChungChi.Contains(tenchungchi))
                                 join nv in db.NhanViens on ccnv.MaNV equals nv.MaNV
                                 where (nv.Ten.Contains(tennv))
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

                }
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<ChungChi_NhanVien_Model>();
                //paging
                equipList = equipList.Skip(start).Take(length).ToList<ChungChi_NhanVien_Model>();
                var dataJson = Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }
        }
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi/xuat-file-excel")]
        [HttpPost]
        public ActionResult ExporTotExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Certificate/Chứng chỉ của cả công ty.xlsx");
            string saveAsPath = ("/excel/TCLD/download/Certificate.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet ws = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    List<ChungChi> listdata = db.ChungChis.ToList<ChungChi>();

                    ws.Cells["A1"].Value = "Mã chứng chỉ";
                    ws.Cells["B1"].Value = "Tên chứng chỉ";
                    ws.Cells["C1"].Value = "Thời hạn (tháng)";
                    ws.Cells["D1"].Value = "Kiểu chứng chỉ";
                    int rowStart = 2;
                    foreach (var i in listdata)
                    {
                        ws.Cells[string.Format("A{0}", rowStart)].Value = i.MaChungChi;
                        ws.Cells[string.Format("B{0}", rowStart)].Value = i.TenChungChi;
                        if (i.ThoiHan == -1)
                        {
                            ws.Cells[string.Format("C{0}", rowStart)].Value = "Vĩnh viễn";
                        }
                        else
                        {
                            ws.Cells[string.Format("C{0}", rowStart)].Value = i.ThoiHan;
                        }

                        ws.Cells[string.Format("D{0}", rowStart)].Value = i.KieuChungChi;
                        rowStart++;

                    }
                }
                excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi-cua-nhan-vien/xuat-file-excel")]
        [HttpPost]
        public ActionResult ExporTotExcelCertificateEmp()
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Certificate/Chứng chỉ của nhân viên.xlsx");
            string saveAsPath = ("/excel/TCLD/download/CertificateOfEmployee.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet ws_cert_emp = excelWorkbook.Worksheets.First();
                List<ChungChi_NhanVien_Model> listdata_certificate_Emp = new List<ChungChi_NhanVien_Model>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    listdata_certificate_Emp = (from ccnv in db.ChungChi_NhanVien
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

                    ws_cert_emp.Cells["A1"].Value = "Số hiệu";
                    ws_cert_emp.Cells["B1"].Value = "Tên chứng chỉ";
                    ws_cert_emp.Cells["C1"].Value = "Mã nhân viên";
                    ws_cert_emp.Cells["D1"].Value = "Tên nhân viên";
                    ws_cert_emp.Cells["E1"].Value = "Ngày cấp";
                    int rowStart = 2;

                    foreach (var item in listdata_certificate_Emp)
                    {
                        ws_cert_emp.Cells[string.Format("A{0}", rowStart)].Value = item.SoHieu;
                        ws_cert_emp.Cells[string.Format("B{0}", rowStart)].Value = item.TenChungChi;
                        ws_cert_emp.Cells[string.Format("C{0}", rowStart)].Value = item.MaNV;
                        ws_cert_emp.Cells[string.Format("D{0}", rowStart)].Value = item.TenNV;
                        ws_cert_emp.Cells[string.Format("E{0}", rowStart)].Value = item.NgayCap;

                        rowStart++;

                    }
                }
                excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
}
