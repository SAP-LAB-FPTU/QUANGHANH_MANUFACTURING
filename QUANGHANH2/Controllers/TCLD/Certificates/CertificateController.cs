using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
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
        [Auther(RightID = "149")]
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Certificate/List.cshtml");
        }
        [Auther(RightID = "149")]
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi")]
        [HttpPost]
        public ActionResult List()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //string name = Session["Name"].ToString()  ;

                //Session["Accept"] = name;
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
        [Auther(RightID = "153")]
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
        [Auther(RightID = "150")]
        [HttpGet]
        public ActionResult AddCertificate()
        {
            getListTypeCertificate();

            return View();

        }
        [Auther(RightID = "150")]
        [HttpPost]
        public ActionResult AddCertificate(ChungChi chungChi)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {

                if (chungChi != null)
                {
                    List<ChungChi> check_list = db.ChungChis.Where(x => x.KieuChungChi.Equals(chungChi.KieuChungChi)
                && x.TenChungChi.Equals(chungChi.TenChungChi) && x.ThoiHan == chungChi.ThoiHan).ToList();
                    if (check_list.Count == 0)
                    {
                        db.ChungChis.Add(chungChi);
                        db.SaveChanges();
                        return RedirectToAction("List", "Certificate");
                    }
                    else
                    {
                        return Json(new { success = 1 }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { success = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
        [Auther(RightID = "154")]
        [HttpGet]
        public ActionResult AddCertificateEmployee()
        {
            getListInforEmployeeCirtificate();
            return View();

        }
        private class Chung_Chi_Display : ChungChi
        {
            public String TenChungChiDisplay { get; set; }
        }
        public void getListInforEmployeeCirtificate()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                String query = @"select * from ChungChi";
                List<Chung_Chi_Display> listdata_chungchi = db.Database.SqlQuery<Chung_Chi_Display>(query).ToList();
                List<NhanVien> listdata_nv = db.NhanViens.ToList<NhanVien>();
                var result = listdata_nv.Where(s => s.MaTrangThai != 2);
                foreach (var item in listdata_chungchi)
                {
                    if (item.ThoiHan == -1)
                    {
                        item.TenChungChiDisplay = item.TenChungChi + " - Vĩnh viễn - " + item.KieuChungChi;
                    }
                    else
                    {
                        item.TenChungChiDisplay = item.TenChungChi + " - " + item.ThoiHan + " tháng - " + item.KieuChungChi;
                    }
                }
                SelectList listCirtificate = new SelectList(listdata_chungchi, "MaChungChi", "TenChungChiDisplay");
                SelectList listEmployee = new SelectList(result, "MaNV", "MaNV");

                ViewBag.List_chungchi = listCirtificate;
                ViewBag.List_nhanvien = listEmployee;
                ViewBag.listdata_nv = listdata_nv;

            }
        }
        [HttpPost]
        public ActionResult validateID(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
        public ActionResult validateExistCirtificateOfEmp(string manv, int id, string first_cir)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var chungchi_nvs = db.ChungChi_NhanVien.Where(x => (x.MaNV == manv) && (x.MaChungChi == id)).FirstOrDefault<ChungChi_NhanVien>();
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var chungchi_nvs = db.NhanViens.Where(x => (x.MaNV == id) && (x.MaTrangThai != 2)).FirstOrDefault<NhanVien>();
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
        [Auther(RightID = "154")]
        [HttpPost]
        public ActionResult AddCertificateEmployee(ChungChi_NhanVien chungChi_nhanVien)
        {
            //string ngaycap = chungChi_nhanVien.NgayCap.ToString();
            //ngaycap = ngaycap.Split(' ')[0];
            //ngaycap = ngaycap.Split('/')[1] +"/"+ ngaycap.Split('/')[0] + "/" + ngaycap.Split('/')[2];
            //chungChi_nhanVien.NgayCap = DateTime.Parse(ngaycap);
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chungChi_nhanVien != null)
                {
                    db.ChungChi_NhanVien.Add(chungChi_nhanVien);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }


        }
        [Auther(RightID = "151")]
        [HttpGet]
        public ActionResult EditCertificate(int id = 0)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
        [Auther(RightID = "151")]
        [HttpPost]
        public ActionResult EditCertificate(ChungChi chungChi)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chungChi != null)
                {

                    db.Entry(chungChi).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        [Auther(RightID = "155")]
        [HttpGet]
        public ActionResult EditCertificateEmp(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
        [Auther(RightID = "155")]
        [HttpPost]
        public ActionResult EditCertificateEmp(ChungChi_NhanVien chungchinv)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chungchinv != null)
                {
                    db.Entry(chungchinv).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        [Auther(RightID = "152")]
        [HttpPost]
        public ActionResult DeleteCertificate(int id = 0)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        ChungChi chungChi = db.ChungChis.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi>();
                        var ccnv = db.ChungChi_NhanVien.Where(x => x.MaChungChi == id).ToList();
                        var nv = db.NhiemVus.Where(x => x.MaChungChi == id).ToList();
                        if (ccnv.Count != 0)
                        {
                            return Json(new { error = true, title = "Lỗi", message = "Chứng chỉ đã được chỉ định với nhân viên củ thể. Không thể xóa" });
                        }
                        else if (nv.Count != 0)
                        {
                            return Json(new { error = true, title = "Lỗi", message = "Chứng chỉ đã được chỉ định với nhiệm vụ củ thể. Không thể xóa" });
                        }
                        else
                        {
                            db.ChungChis.Remove(chungChi);
                            db.SaveChanges();
                            transaction.Commit();
                            return Json(new { success = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
                return RedirectToAction("List");


            }
        }
        [Auther(RightID = "156")]
        [HttpPost]
        public ActionResult DeleteCertificateEmp(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                if (sohieu != null || tenchungchi != null || tennv != null)
                {

                    equipList = (from ccnv in db.ChungChi_NhanVien
                                 join cc in db.ChungChis on ccnv.MaChungChi equals cc.MaChungChi
                                 join nv in db.NhanViens on ccnv.MaNV equals nv.MaNV
                                 where ((nv.Ten.Contains(tennv)) && (ccnv.SoHieu.Contains(sohieu)) && (cc.TenChungChi.Contains(tenchungchi)))
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
            try
            {
                string path = HostingEnvironment.MapPath("/excel/TCLD/Certificate/Chứng chỉ của cả công ty.xlsx");
                string saveAsPath = ("/excel/TCLD/download/Chứng chỉ của cả công ty.xlsx");
                FileInfo file = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                    ExcelWorksheet ws = excelWorkbook.Worksheets.First();
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        List<ChungChi> listdata = db.ChungChis.ToList<ChungChi>();
                        ws.Cells["A1"].Value = "Bảng danh sách chứng chỉ công ty";
                        ws.Cells["B1"].Value = "Tên chứng chỉ";
                        ws.Cells["C1"].Value = "Thời hạn (tháng)";
                        ws.Cells["D1"].Value = "Kiểu chứng chỉ";
                        int rowStart = 3;
                        int count = 0;
                        foreach (var i in listdata)
                        {
                            count++;
                            ws.Cells[string.Format("A{0}", rowStart)].Value = count;
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
            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("phong-tcld/chung-chi/danh-sach-chung-chi-cua-nhan-vien/xuat-file-excel")]
        [HttpPost]
        public ActionResult ExporTotExcelCertificateEmp()
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/TCLD/Certificate/Chứng chỉ của nhân viên.xlsx");
                string saveAsPath = ("/excel/TCLD/download/Chứng chỉ của nhân viên.xlsx");
                FileInfo file = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                    ExcelWorksheet ws_cert_emp = excelWorkbook.Worksheets.First();
                    List<ChungChi_NhanVien_Model> listdata_certificate_Emp = new List<ChungChi_NhanVien_Model>();
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
                        ws_cert_emp.Cells["A1"].Value = "Bảng danh sách chứng chỉ của nhân viên";
                        ws_cert_emp.Cells["B1"].Value = "Số hiệu";
                        ws_cert_emp.Cells["C1"].Value = "Tên chứng chỉ";
                        ws_cert_emp.Cells["D1"].Value = "Mã nhân viên";
                        ws_cert_emp.Cells["E1"].Value = "Tên nhân viên";
                        ws_cert_emp.Cells["F1"].Value = "Ngày cấp";
                        int rowStart = 3;
                        int count = 0;
                        foreach (var item in listdata_certificate_Emp)
                        {
                            count++;
                            ws_cert_emp.Cells[string.Format("A{0}", rowStart)].Value = count;
                            ws_cert_emp.Cells[string.Format("B{0}", rowStart)].Value = item.SoHieu;
                            ws_cert_emp.Cells[string.Format("C{0}", rowStart)].Value = item.TenChungChi;
                            ws_cert_emp.Cells[string.Format("D{0}", rowStart)].Value = item.MaNV;
                            ws_cert_emp.Cells[string.Format("E{0}", rowStart)].Value = item.TenNV;
                            if (item.NgayCap != null)
                            {
                                ws_cert_emp.Cells[string.Format("F{0}", rowStart)].Value = ((DateTime)item.NgayCap).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                ws_cert_emp.Cells[string.Format("F{0}", rowStart)].Value = item.NgayCap;
                            }

                            rowStart++;

                        }
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
