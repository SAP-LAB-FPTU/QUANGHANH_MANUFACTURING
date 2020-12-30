using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using DocumentFormat.OpenXml.Packaging;
using System.Web.Hosting;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using static QUANGHANH2.Controllers.TCLD.EmployeesController;
using static QUANGHANHCORE.Controllers.TCLD.TransferController;
using System.IO.Compression;
using System.Net;
using OfficeOpenXml;
using QUANGHANH2.EntityResult;
using System.Collections;
using System.Data;

namespace QUANGHANH2.Controllers.TCLD
{

    public class ShutDownController : Controller
    {
        public class QuyetDinhLink : Decision
        {
            public string LoaiChamDut { get; set; }

            public Nullable<DateTime> NgayChamDut { get; set; }

            public string Ten { get; set; }
            public string MaNV { get; set; }

        }
        [Auther(RightID = "127")]
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut")]
        [HttpGet]
        public ActionResult List()
        {
            List<Work> listCongViec = new List<Work>();
            List<Department> listPhongBan = new List<Department>();
            List<TerminationType> terminationTypes = new List<TerminationType>();

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                listCongViec = db.Works.ToList();
                listPhongBan = db.Departments.ToList();
                terminationTypes = db.TerminationTypes.ToList();

            }
            ViewBag.listCongViec = listCongViec;
            ViewBag.listPhongBan = listPhongBan;
            ViewBag.terminate_type_html = terminationTypes;
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Shutdown/Process.cshtml");
        }

        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut")]
        [HttpPost]
        public ActionResult Search(string MaNV, string TenNV, string ChucVu, string PhongBan)
        {
            try
            {
                while (MaNV.Contains("  "))
                {
                    MaNV = MaNV.Replace("  ", " ");
                }
                MaNV = MaNV.Trim();
                string[] searchListID = MaNV.Split(' ');
                MaNV = "";
                for (int i = 0; i < searchListID.Length; i++)
                {
                    MaNV += "'" + searchListID[i] + "',";
                }
                MaNV = MaNV.Contains(",") ? MaNV.Substring(0, MaNV.Length - 1) : MaNV;
                MaNV = MaNV == "''" ? "" : MaNV;
                HttpCookie cookie;
                if (HttpContext.Request.Cookies["DanhSachNhanVien"] == null)
                {
                    cookie = new HttpCookie("DanhSachNhanVien");
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    cookie.Value = "[]";
                }
                else
                {
                    cookie = HttpContext.Request.Cookies["DanhSachNhanVien"];
                    cookie.Value = Request["selectList"];
                };

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                db.Configuration.LazyLoadingEnabled = false;
                int border = 2147483647;
                string query_list = @"HumanResources.[GetListEmployees_To_Shutdown] {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}";
                List<GetListEmployees_Result> employees = db.Database.SqlQuery<GetListEmployees_Result>(query_list,
                    MaNV, TenNV, "", PhongBan, ChucVu, sortColumnName, sortDirection, start, length).ToList();
                int totalrows = db.Database.SqlQuery<GetListEmployees_Result>(query_list,
                    MaNV, TenNV, "", PhongBan, ChucVu, sortColumnName, sortDirection, start, border).ToList().Count;
                return Json(new { data = employees, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { data = "-1", draw = Request["draw"], recordsTotal = 0, recordsFiltered = 0 }, JsonRequestBehavior.AllowGet);
            }




        }
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut-step2")]
        [HttpPost]
        public ActionResult Step2()
        {
            // MessageBox.Show(Request["selectedList"]);
            string selected;
            HttpCookie cookie;
            DataTable selected_list = new DataTable();
            selected_list.Columns.Add("id");
            try
            {
                if (HttpContext.Request.Cookies["DanhSachNhanVien"] == null)
                {
                    return null;
                }
                else
                {
                    selected = Request["selectedList"];
                    selected = selected.Substring(1, selected.Length - 2);
                    selected = selected.Replace("\"", "");
                    foreach (var item in selected.Split(','))
                    {
                        selected_list.Rows.Add(item);
                    }
                }

                List<GetListEmployees_Result> listNhanVien = new List<GetListEmployees_Result>();
                int totalrows = listNhanVien.Count;
                int totalrowsafterfiltering = listNhanVien.Count;
                List<TerminationType> terminationTypes = new List<TerminationType>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    string sql =
                    @"[HumanResources].GetShutdown_Step2_List @list_selected";
                    SqlParameter p = new SqlParameter("@list_selected", SqlDbType.Structured)
                    {
                        Value = selected_list,
                        TypeName = "selected_list"
                    };
                    terminationTypes = db.TerminationTypes.ToList();
                    listNhanVien = db.Database.SqlQuery<GetListEmployees_Result>(sql, p).ToList();
                }
                ViewBag.terminate_type = terminationTypes;
                return Json(new { success = true, data = listNhanVien, reason_list = terminationTypes, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { data = "", draw = Request["draw"], recordsTotal = 0, recordsFiltered = 0 }, JsonRequestBehavior.AllowGet);

            }

        }


        [Auther(RightID = "127")]
        // GET: ShutDown
        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult Did()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Shutdown/Did.cshtml");
        }
        [Auther(RightID = "127")]
        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult DidList(string NgayQuyetDinh, string SoQuyetDinh, string NgayChamDut)
        {
            try
            {
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                db.Configuration.LazyLoadingEnabled = false;
                string query = @"[HumanResources].[GetShutDown_Did_List] {0}, {1}, {2}";
                List<GetShutDown_Did_List_Result> searchList = db.Database.
                    SqlQuery<GetShutDown_Did_List_Result>(query, SoQuyetDinh,
                    NgayChamDut.Equals("") ? "" : DateTime.ParseExact(NgayChamDut, "dd/MM/yyyy", null) + "",
                    NgayQuyetDinh.Equals("") ? "" : DateTime.ParseExact(NgayQuyetDinh, "dd/MM/yyyy", null) + "").ToList();

                int totalrows = searchList.Count;

                return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { data = -1, draw = Request["draw"], recordsTotal = 0, recordsFiltered = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut/check-duplicate-sqd")]
        [HttpPost]
        public ActionResult checkDuplicateSQD()
        {
            string sqd = Request["SoQD"];
            if (sqd != null && sqd != "")
            {
                int result;
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string sql = "select count(SoQuyetDinh) as sqd from QuyetDinh\n" +
                    "where SoQuyetDinh = @SoQD ";
                    result = db.Database.SqlQuery<int>(sql, new SqlParameter("SoQD", sqd)).ToList<int>()[0];
                }
                if (result != 0)
                {
                    return Json(new { success = true, data = true });
                }
                else
                {
                    return Json(new { success = true, data = false });
                }
            }
            return Json(new { success = false, message = "Lỗi" });
        }


        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut-chi-tiet")]
        [HttpPost]
        public JsonResult DidListDetail(string id)
        {
            try
            {
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                db.Configuration.LazyLoadingEnabled = false;

                string query = @"HumanResources.GetShutDown_Did_Detail {0}";
                List<GetShutDown_Did_List_Result> list = db.Database.SqlQuery<GetShutDown_Did_List_Result>(query, id).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);

            }

        }
        [Auther(RightID = "128")]
        [Route("deleteDetail")]
        [HttpPost]
        public JsonResult DidDetailDel(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    string query3 = "select cd.* from ChamDut_NhanVien cd inner join NhanVien nv on cd.MaNV = nv.MaNV inner join QuyetDinh q on q.MaQuyetDinh = cd.MaQuyetDinh where cd.MaQuyetDinh = @id";
                    List<ChamDut_NhanVien> list = db.Database.SqlQuery<ChamDut_NhanVien>(query3, new SqlParameter("id", id)).ToList();
                    string listMaNV = "";
                    foreach (var MaNV in list)
                    {
                        listMaNV += "'" + MaNV.MaNV + "'" + ",";
                    }
                    listMaNV = listMaNV.Substring(0, listMaNV.Length - 1);
                    string query4 = "update NhanVien set MaTrangThai = 1 where MaNV in(" + listMaNV + ")";
                    db.Database.ExecuteSqlCommand(query4);

                    string query1 = "delete from ChamDut_NhanVien where MaQuyetDinh = @id";
                    db.Database.ExecuteSqlCommand(query1, new SqlParameter("id", id));
                    string query2 = "delete from QuyetDinh where MaQuyetDinh = @id";
                    db.Database.ExecuteSqlCommand(query2, new SqlParameter("id", id));
                    db.SaveChanges();
                    dbct.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    dbct.Rollback();
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [Auther(RightID = "126")]
        [Route("deleteNotYet")]
        [HttpPost]
        public JsonResult NotYetDelete(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    List<Termination> list = db.Terminations.Where(x => x.decision_id + "" == id).ToList();
                    string listMaNV = "";
                    foreach (var MaNV in list)
                    {
                        listMaNV += "'" + MaNV.employee_id + "'" + ",";
                    }
                    listMaNV = listMaNV.Substring(0, listMaNV.Length - 1);
                    string query = @"update HumanResources.Employee set 
                        current_status_id = 1 where employee_id in(" + listMaNV + ") " +
                        "delete from HumanResources.Termination where decision_id = @id " +
                        "delete from HumanResources.Decision where decision_id = @id";
                    db.Database.ExecuteSqlCommand(query, new SqlParameter("id", id));
                    db.SaveChanges();
                    dbct.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    dbct.Rollback();
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [Auther(RightID = "124")]
        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult NotYet()
        {
            return View("/Views/TCLD/Shutdown/NotYet.cshtml");
        }

        [Auther(RightID = "124")]
        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult NotYetList(string MaQuyetDinh, string NgayChamDut)
        {
            try
            {
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                db.Configuration.LazyLoadingEnabled = false;
                string query = @"HumanResources.GetShutDown_Notyet_List {0}, {1}";
                List<GetShutDown_Notyet_List_Result> searchList =
                    db.Database.SqlQuery<GetShutDown_Notyet_List_Result>(query, 
                    MaQuyetDinh, NgayChamDut.Equals("")? "":DateTime.ParseExact(NgayChamDut, "dd/MM/yyyy", null) + "" ).ToList();

                int totalrows = searchList.Count;
                int totalrowsafterfiltering = searchList.Count;

                return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { data = -1, draw = Request["draw"], recordsTotal = 0, recordsFiltered = 0 }, JsonRequestBehavior.AllowGet);
            }
        }


        [Route("NotYetDetail")]
        [HttpPost]
        public JsonResult NotYetDetail(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;

            string query = "HumanResources.GetShutDown_Notyet_Detail {0}";
            List<GetShutDown_Notyet_List_Result> list = db.Database.SqlQuery<GetShutDown_Notyet_List_Result>(query, id).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "125")]
        [Route("UpdateSoQD")]
        [HttpPost]
        public JsonResult UpdateSoQD(string id, string SoQD)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    if (!SoQD.Equals(""))
                    {
                        string query = @"select * from HumanResources.Decision where number = @SoQD";
                        List<Decision> qdList = db.Database.SqlQuery<Decision>(query, new SqlParameter("SoQD", SoQD)).ToList();

                        if (qdList.Count > 0)
                        {
                            return Json(new { success = false, message = "Số quyết định trùng" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            int MaQD = Convert.ToInt32(id);
                            Decision qd = db.Decisions.Where(x => x.decision_id == MaQD).FirstOrDefault();
                            qd.number = SoQD;
                            qd.date = DateTime.Now.AddDays(2);
                            db.Entry(qd).State = EntityState.Modified;

                            List<string> maNV = db.Terminations.Where(x => x.decision_id == qd.decision_id).
                                Select(x => x.employee_id).ToList();
                            foreach (var item in maNV)
                            {
                                var Nv = db.Employees.Where(nv => nv.employee_id == item).FirstOrDefault();
                                Nv.current_status_id = 2;
                                db.Entry(Nv).State = EntityState.Modified;
                            }

                            db.SaveChanges();
                            dbct.Commit();
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = "Chưa nhập số quyết định" }, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { success = true, message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    dbct.Rollback();
                    return Json(new { success = false, message = "Có lỗi khi thêm" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //[HttpPost]
        //public ActionResult validateID(string id)
        //{
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        QuyetDinh nv = db.QuyetDinhs.Where(x => x.SoQuyetDinh == id).FirstOrDefault<QuyetDinh>();
        //        if (nv != null)
        //        {
        //            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        public class ChamDutModel
        {
            public string MaNV { get; set; }
            public string Ten { get; set; }
            public string LoaiChamDut { get; set; }
            public string NgayChamDut { get; set; }
            public string DonViHienTai { get; set; }
            public string PhanXuong { get; set; }
            public string SoQD { get; set; }
            public string BacLuong { get; set; }
            public string ThangLuong { get; set; }
            public string SoBHXH { get; set; }
            public string MucLuong { get; set; }
            public string PhongBan { get; set; }
            public Nullable<DateTime> NgaySinh { get; set; }
            public Nullable<DateTime> NgayDiLam { get; set; }
            public bool GioiTinh { get; set; }
        }


        //[Route("phong-tcld/quan-ly-nhan-vien/cham-dut/export-quyet-dinh")]
        //[HttpPost]
        //public ActionResult ExportReport(string selectedList)
        //{
        //    string zipPath = HostingEnvironment.MapPath("/doc/TCLD/chamdutzip" + "/quyetdinh.zip");
        //    string sourcePath = HostingEnvironment.MapPath("/doc/TCLD/chamdutdow");
        //    try
        //    {

        //        var js = new JavaScriptSerializer();
        //        List<ChamDutModel> result = JsonConvert.DeserializeObject<List<ChamDutModel>>(selectedList);
        //        string manv = "";
        //        for (int i = 0; i < result.Count; i++)
        //        {
        //            manv += "" + int.Parse(((ChamDutModel)result[i]).MaNV) + ",";
        //        }
        //        manv = manv.Remove(manv.Length - 1);
        //        List<ChamDutModel> exportList = new List<ChamDutModel>();
        //        using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //        {
        //            db.Configuration.LazyLoadingEnabled = false;
        //            string query = @"select a.*, b.department_name as 'PhanXuong', d.MucThangLuong as 'ThangLuong' from NhanVien a
        //                    left join Department b on a.MaPhongBan = b.department_id
        //                    left join BacLuong_ThangLuong_MucLuong c on 
        //                    a.MaBacLuong_ThangLuong_MucLuong = c.MaBacLuong_ThangLuong_MucLuong 
        //                    left join ThangLuong d on c.MaThangLuong = d.MaThangLuong                       
        //                    where a.MaNV in (" + manv + ")";
        //            exportList = db.Database.SqlQuery<ChamDutModel>(query).ToList();
        //        }
        //        string chamdut = result[0].NgayChamDut;
        //        for (int i = 0; i < exportList.Count; i++)
        //        {
        //            exportList[i].NgayChamDut = result[i].NgayChamDut;
        //            exportList[i].LoaiChamDut = result[i].LoaiChamDut;
        //        }
        //        int count = 1;

        //        //Mot nguoi
        //        System.IO.DirectoryInfo di = new DirectoryInfo(HostingEnvironment.MapPath("/doc/TCLD/chamdutdow"));

        //        foreach (FileInfo file in di.GetFiles())
        //        {
        //            file.Delete();
        //        }
        //        string savePath = "";
        //        string fileName = HostingEnvironment.MapPath("/doc/TCLD/chamdut/motnguoi/chamdut-ko-tro-cap-template.docx");
        //        byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
        //        foreach (ChamDutModel item in exportList)
        //        {
        //            using (var stream = new MemoryStream())
        //            {
        //                stream.Write(byteArray, 0, byteArray.Length);
        //                using (var doc = WordprocessingDocument.Open(stream, true))
        //                {
        //                    string docText = null;
        //                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
        //                    {
        //                        docText = sr.ReadToEnd();
        //                    }

        //                    string Flocation = "/doc/TCLD/chamdutdow/quyetdinh-chamdut_";
        //                    Regex regexText = new Regex("%ngayquyetdinh%");
        //                    string[] ngay = item.NgayChamDut.Split('/');
        //                    docText = regexText.Replace(docText, "Ngày " + ngay[0] + " tháng " + ngay[1] + " năm " + ngay[2]);

        //                    regexText = new Regex("%ngaychamdut%");
        //                    docText = regexText.Replace(docText, ngay[1] + "/" + ngay[2]);

        //                    regexText = new Regex("%soqd%");
        //                    docText = regexText.Replace(docText, item.SoQD == null ? "" : item.SoQD);

        //                    regexText = new Regex("%name%");
        //                    docText = regexText.Replace(docText, item.Ten);

        //                    regexText = new Regex("%gender%");
        //                    docText = regexText.Replace(docText, item.GioiTinh ? "Ông" : "Bà");

        //                    regexText = new Regex("%sothe%");
        //                    docText = regexText.Replace(docText, item.MaNV);

        //                    regexText = new Regex("%ngaysinh%");
        //                    docText = regexText.Replace(docText, item.NgaySinh == null ? "" : item.NgaySinh.Value.ToString("dd/MM/yyyy"));

        //                    regexText = new Regex("%ngaydilam%");
        //                    docText = regexText.Replace(docText, item.NgayDiLam == null ? "" : item.NgayDiLam.Value.ToString("MM/yyyy"));

        //                    regexText = new Regex("%soBHXH%");
        //                    docText = regexText.Replace(docText, item.SoBHXH == null ? "" : item.SoBHXH);

        //                    regexText = new Regex("%nghenghiep%");
        //                    docText = regexText.Replace(docText, item.DonViHienTai == null ? "" : item.DonViHienTai);

        //                    regexText = new Regex("%bacluong%");
        //                    docText = regexText.Replace(docText, item.BacLuong == null ? "" : item.BacLuong);

        //                    regexText = new Regex("%mucluong%");
        //                    docText = regexText.Replace(docText, item.DonViHienTai == null ? "" : item.DonViHienTai);

        //                    regexText = new Regex("%thangluong%");
        //                    docText = regexText.Replace(docText, item.ThangLuong == null ? "" : item.ThangLuong);

        //                    regexText = new Regex("%phanxuong%");
        //                    docText = regexText.Replace(docText, item.PhanXuong == null ? "" : item.PhanXuong);

        //                    regexText = new Regex("%lydo%");
        //                    docText = regexText.Replace(docText, item.LoaiChamDut == null ? "" : item.LoaiChamDut);
        //                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
        //                    {
        //                        sw.Write(docText);
        //                    }

        //                    doc.MainDocumentPart.Document.Save(); // won't update the original file 

        //                    Flocation += item.MaNV + ".doc";
        //                    savePath = HostingEnvironment.MapPath(Flocation);
        //                    stream.Position = 0;
        //                    System.IO.File.WriteAllBytes(savePath, stream.ToArray());
        //                    doc.Close();
        //                }
        //            }
        //        }
        //        if (System.IO.File.Exists(zipPath))
        //        {
        //            System.IO.File.Delete(zipPath);
        //        }
        //        ZipFile.CreateFromDirectory(sourcePath, zipPath);


        //        return Json(new { success = true, location = "/doc/TCLD/chamdutzip/quyetdinh.zip" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }



        //    //nhieu nguoi
        //    //else
        //    //{
        //    //    string fileName = HostingEnvironment.MapPath("/doc/TCLD/dieudong/nhieunguoi/dieudong-template.docx");
        //    //    byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
        //    //    using (var stream = new MemoryStream())
        //    //    {
        //    //        stream.Write(byteArray, 0, byteArray.Length);
        //    //        using (var doc = WordprocessingDocument.Open(stream, true))
        //    //        {
        //    //            string docText = null;
        //    //            using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
        //    //            {
        //    //                docText = sr.ReadToEnd();
        //    //            }
        //    //            Regex regexText = new Regex("%ngayquyetdinh%");
        //    //            string[] ngay = result[0].NgayChamDut.Split('/');
        //    //            docText = regexText.Replace(docText, "Ngày " + ngay[0] + " tháng " + ngay[1] + " năm " + ngay[2]);

        //    //            regexText = new Regex("%soquyetdinh%");
        //    //            docText = regexText.Replace(docText, result[0].SoQD);

        //    //            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
        //    //            {
        //    //                sw.Write(docText);
        //    //            }
        //    //            Table table =  doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(2);
        //    //            int i = 0;
        //    //            foreach (ChamDutModel d in result)
        //    //            {
        //    //                TableRow tr = new TableRow();
        //    //                i++;
        //    //                TableCell tc1 = new TableCell();
        //    //                tc1.Append(new Paragraph(new Run(new Text((i).ToString()))));
        //    //                tr.Append(tc1);

        //    //                TableCell tc2 = new TableCell();
        //    //                tc2.Append(new Paragraph(new Run(new Text(d.MaNV))));
        //    //                tr.Append(tc2);

        //    //                TableCell tc3 = new TableCell();
        //    //                tc3.Append(new Paragraph(new Run(new Text(d.TenNV))));
        //    //                tr.Append(tc3);

        //    //                TableCell tc4 = new TableCell();
        //    //                tc4.Append(new Paragraph(new Run(new Text(d.DonViHienTai))));
        //    //                tr.Append(tc4);

        //    //                TableCell tc5 = new TableCell();
        //    //                tc5.Append(new Paragraph(new Run(new Text(d.LoaiChamDut))));
        //    //                tr.Append(tc5);

        //    //                table.Append(tr);
        //    //            }
        //    //            doc.MainDocumentPart.Document.Save(); // won't update the original file 
        //    //        }
        //    //        // Save the file with the new name
        //    //        string savePath = HostingEnvironment.MapPath(Flocation);
        //    //        stream.Position = 0;
        //    //        System.IO.File.WriteAllBytes(savePath, stream.ToArray());
        //    //    }
        //    //}



        //}


        //[Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut/excel")]
        //[HttpPost]
        //public void ReturnExcel()
        //{
        //    string path = HostingEnvironment.MapPath("/excel/TCLD/Brief/Danh-sách-nhân-viên.xlsx");
        //    FileInfo file = new FileInfo(path);
        //    using (ExcelPackage excelPackage = new ExcelPackage(file))
        //    {
        //        ExcelWorkbook excelWorkbook = excelPackage.Workbook;
        //        ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
        //        using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //        {
        //            string query = "select * from NhanVien nv left outer join CongViec cv on nv.MaCongViec = cv.MaCongViec where nv.MaTrangThai = 2";
        //            List<NhanVienExcel> list = db.Database.SqlQuery<NhanVienExcel>(query).ToList();
        //            int k = 4;
        //            for (int i = 0; i < list.Count; i++)
        //            {

        //                excelWorksheet.Cells[k, 1].Value = i + 1;
        //                excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).MaNV;
        //                excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).Ten;
        //                if (list.ElementAt(i).GioiTinh)
        //                {
        //                    excelWorksheet.Cells[k, 4].Value = "Nam";
        //                }
        //                else
        //                {
        //                    excelWorksheet.Cells[k, 4].Value = "Nữ";
        //                }
        //                excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).NgaySinh.HasValue ? list.ElementAt(i).NgaySinh.Value.ToString("dd/MM/yyyy") : "";
        //                excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).SoCMND;
        //                excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).SoBHXH;
        //                excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).TenCongViec;
        //                excelWorksheet.Cells[k, 15].Value = list.ElementAt(i).MucLuong;
        //                excelWorksheet.Cells[k, 17].Value = list.ElementAt(i).BacLuong;
        //                if (list.ElementAt(i).MaTrinhDo != null)
        //                {
        //                    if (list.ElementAt(i).MaTrinhDo.Equals("1"))
        //                    {
        //                        excelWorksheet.Cells[k, 20].Value = "Tiểu học";
        //                    }
        //                    else if (list.ElementAt(i).MaTrinhDo.Equals("2"))
        //                    {
        //                        excelWorksheet.Cells[k, 20].Value = "THCS";
        //                    }
        //                    else if (list.ElementAt(i).MaTrinhDo.Equals("3"))
        //                    {
        //                        excelWorksheet.Cells[k, 20].Value = "THPT";
        //                    }
        //                    else if (list.ElementAt(i).MaTrinhDo.Equals("4"))
        //                    {
        //                        excelWorksheet.Cells[k, 20].Value = "Trung cấp";
        //                    }
        //                    else
        //                    {
        //                        excelWorksheet.Cells[k, 20].Value = "Đại học";
        //                    }
        //                }
        //                excelWorksheet.Cells[k, 22].Value = list.ElementAt(i).QueQuan;
        //                k++;
        //            }
        //            excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh-sách-nhân-viên.xlsx")));
        //        }
        //    }

        //}
    }

}