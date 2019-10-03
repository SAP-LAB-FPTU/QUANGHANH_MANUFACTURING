using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Web.Hosting;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class TransferController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen")]
        public ActionResult Select()
        {
            List<CongViec> listCongViec = new List<CongViec>();
            List<Department> listPhongBan = new List<Department>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                string sql1 = "select * from CongViec";
                listCongViec = db.CongViecs.SqlQuery(sql1).ToList<CongViec>();

            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                string sql1 = "select * from Department";
                listPhongBan = db.Departments.SqlQuery(sql1).ToList<Department>();

            }
            ViewBag.listCongViec = listCongViec;
            ViewBag.listPhongBan = listPhongBan;
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/Process.cshtml");
        }

        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen")]
        public ActionResult Did()
        {
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/History.cshtml");
        }

        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen")]
        public ActionResult NotYet()
        {
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/Temporary.cshtml");
        }

        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen")]
        [HttpPost]
        public ActionResult GetData(String selectListJson, String searchMa, String searchTen, String phongbanSearch, String chucVuSearch)
        {
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
            //MessageBox.Show(Request["selectList"]);

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            ViewBag.selectedList = cookie.Value;
            //
            var listSelect = Request["selectList"];
            List<NhanVienModel> listNhanVien = new List<NhanVienModel>();

            int totalrows;
            int totalrowsafterfiltering;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "SELECT  A.*,B.department_name,C.TenCongViec,D.TenTrangThai\n" +
"FROM\n" +
"(\n" +
    "(SELECT * FROM NhanVien) A\n" +
    "left OUTER JOIN\n" +
    "(SELECT department_id, department_name FROM Department) B on A.MaPhongBan = B.department_id\n" +
    "left OUTER JOIN\n" +
    "(SELECT MaCongViec, TenCongViec FROM CongViec) C on A.MaCongViec = C.MaCongViec\n" +
    "left OUTER JOIN\n" +
    "(SELECT MaTrangThai, TenTrangThai FROM TrangThai) D on A.MaTrangThai = D.MaTrangThai\n" +
    ")";

                if ((searchMa != "" || searchTen != "" || chucVuSearch != "-1" || phongbanSearch != "-1"))
                {
                    sql += " where ";
                    sql += searchMa == "" ? "" : " A.MaNV like @maNV AND";
                    sql += searchTen == "" ? "" : " A.Ten like @tenNV AND";
                    sql += phongbanSearch == "-1" ? "" : " A.MaPhongBan = @maPhongBan AND";
                    sql += chucVuSearch == "-1" ? "" : " A.MaCongViec = @maCongViec AND";
                    sql = sql.Substring(0, sql.Length - 4).Trim();
                }
               sql +=sql.Contains("where") ? " AND A.MaTrangThai<>3" : " WHERE A.MaTrangThai<>2"; ;
                listNhanVien = db.Database.SqlQuery<NhanVienModel>(sql,
                    new SqlParameter("maNV", "%" + searchMa + "%"),
                    new SqlParameter("tenNV", "%" + searchTen + "%"),
                    new SqlParameter("maPhongBan", phongbanSearch),
                    new SqlParameter("maCongViec", chucVuSearch)
                    ).ToList<NhanVienModel>();
                totalrows = listNhanVien.Count;
                totalrowsafterfiltering = listNhanVien.Count;
                listNhanVien = listNhanVien.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVienModel>();
                listNhanVien = listNhanVien.Skip(start).Take(length).ToList<NhanVienModel>();
               
            }
            return Json(new { success = true, data = listNhanVien, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen-step-2")]
        [HttpPost]
        public ActionResult Step2()
        {
            // MessageBox.Show(Request["selectedList"]);
            string selected;
            HttpCookie cookie;
            if (HttpContext.Request.Cookies["DanhSachNhanVien"] == null)
            {
                return null;
            }
            else
            {
                selected = Request["selectedList"];
                selected = selected.Substring(1, selected.Length - 2);
                selected = selected.Replace("\"", "\'");
                //MessageBox.Show(selected);
            }


            List<NhanVienModel> listNhanVien = new List<NhanVienModel>();
            List<Department> listPhongBan = new List<Department>();
            List<CongViec> listCongViec = new List<CongViec>();
            int totalrows = listNhanVien.Count;
            int totalrowsafterfiltering = listNhanVien.Count;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                //listNhanVien = db.Database.ToList<NhanVienModel>();
                //totalrows = listNhanVien.Count;
                //totalrowsafterfiltering = listNhanVien.Count;

                string sql = "SELECT  A.*,B.department_name,C.TenCongViec" +
                " FROM" +
                "(" +
                "(SELECT * FROM NhanVien where MaNV in (" + selected + ")) A" +
                " left OUTER JOIN" +
                " (SELECT department_id, department_name FROM Department) B on A.MaPhongBan = B.department_id" +
                " left OUTER JOIN" +
                " (SELECT MaCongViec, TenCongViec FROM CongViec) C on A.MaCongViec = C.MaCongViec" +
                " )";
                listNhanVien = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                string sql1 = "select * from Department";
                listPhongBan = db.Departments.SqlQuery(sql1).ToList<Department>();

            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                string sql1 = "select * from CongViec";
                listCongViec = db.CongViecs.SqlQuery(sql1).ToList<CongViec>();

            }

            return Json(new { success = true, cviecs = listCongViec, phongbans = listPhongBan, data = listNhanVien, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen-step-3")]
        [HttpPost]
        public ActionResult Step3(string selectedList)
        {
            var js = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<DieuDongModel>>(selectedList);
            string manv = "";
            for (int i = 0; i < result.Count; i++)
            {
                manv += "'" + ((DieuDongModel)result[i]).MaNV + "',";
            }
            manv = manv.Remove(manv.Length - 1);
            List<NhanVienModel> getInfo;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "SELECT  A.*,B.department_name,C.TenCongViec" +
                " FROM" +
                "(" +
                "(SELECT * FROM NhanVien where MaNV in (" + manv + ")) A" +
                " left OUTER JOIN" +
                " (SELECT department_id, department_name FROM Department) B on A.MaPhongBan = B.department_id" +
                " left OUTER JOIN" +
                " (SELECT MaCongViec, TenCongViec FROM CongViec) C on A.MaCongViec = C.MaCongViec" +
                " )";
                getInfo = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();

                for (int i = 0; i < result.Count; i++)
                {
                    for(int j = 0; j < result.Count; j++)
                    {
                        if (((DieuDongModel)result[j]).MaNV==getInfo[i].MaNV)
                        {
                            ((DieuDongModel)result[j]).HoTen = getInfo[i].Ten;
                            ((DieuDongModel)result[j]).DonViHienTai = getInfo[i].department_name;
                            ((DieuDongModel)result[j]).ChucVuHienTai = new ChucVuModel(getInfo[i].MaCongViec.ToString(), getInfo[i].TenCongViec);
                        }
                    }
                    
                }
            }
            List<DieuDongModel> listNhanVien = new List<DieuDongModel>();
            for (int i = 0; i < result.Count; i++)
            {
                DieuDongModel d = new DieuDongModel();
                d.SoQD = ((DieuDongModel)result[i]).SoQD;
                d.MaNV = ((DieuDongModel)result[i]).MaNV;
                d.HoTen = ((DieuDongModel)result[i]).HoTen;
                d.DonViHienTai = ((DieuDongModel)result[i]).DonViHienTai;
                d.ChucVuHienTai = ((DieuDongModel)result[i]).ChucVuHienTai;
                d.BacLuong = ((DieuDongModel)result[i]).BacLuong;
                d.MucLuong = ((DieuDongModel)result[i]).MucLuong;
                d.ThangBacLuong = ((DieuDongModel)result[i]).ThangBacLuong;
                d.PhuCap = ((DieuDongModel)result[i]).PhuCap;
                d.DonViMoi = ((DieuDongModel)result[i]).DonViMoi;
                d.ChucVu = new ChucVuModel(((DieuDongModel)result[i]).ChucVu.maChucVu, ((DieuDongModel)result[i]).ChucVu.tenChucVu);
                d.NgayQD = ((DieuDongModel)result[i]).NgayQD;
                d.LyDo = ((DieuDongModel)result[i]).LyDo;
                listNhanVien.Add(d);
            }

            return Json(new { success = true, data = listNhanVien }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-tcld/dieu-chuyen/export-quyet-dinh")]
        [HttpPost]
        public ActionResult ExportReport(string selectedList)
        {
            var js = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<DieuDongModel>>(selectedList);
            string manv = "";
            for (int i = 0; i < result.Count; i++)
            {
                manv += "'" + ((DieuDongModel)result[i]).MaNV + "',";
            }
            manv = manv.Remove(manv.Length - 1);
            List<NhanVienModel> getInfo;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select NhanVien.*,CongViec.TenCongViec from NhanVien,CongViec where MaNV in (" + manv + ") and CongViec.MaCongViec=NhanVien.MaCongViec";

                getInfo = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();

                for (int i = 0; i < result.Count; i++)
                {
                    ((DieuDongModel)result[i]).HoTen = getInfo[i].Ten;
                    ((DieuDongModel)result[i]).DonViHienTai = getInfo[i].MaPhongBan;
                    ((DieuDongModel)result[i]).ChucVuHienTai = new ChucVuModel(getInfo[i].MaCongViec.ToString(), getInfo[i].TenCongViec);
                }
            }
            List<DieuDongModel> listNhanVien = new List<DieuDongModel>();
            for (int i = 0; i < result.Count; i++)
            {
                DieuDongModel d = new DieuDongModel();
                d.SoQD = ((DieuDongModel)result[i]).SoQD;
                d.MaNV = ((DieuDongModel)result[i]).MaNV;
                d.HoTen = ((DieuDongModel)result[i]).HoTen;
                d.DonViHienTai = ((DieuDongModel)result[i]).DonViHienTai;
                d.ChucVuHienTai = ((DieuDongModel)result[i]).ChucVuHienTai;
                d.BacLuong = ((DieuDongModel)result[i]).BacLuong;
                d.MucLuong = ((DieuDongModel)result[i]).MucLuong;
                d.ThangBacLuong = ((DieuDongModel)result[i]).ThangBacLuong;
                d.PhuCap = ((DieuDongModel)result[i]).PhuCap;
                d.DonViMoi = ((DieuDongModel)result[i]).DonViMoi;
                d.ChucVu = new ChucVuModel(((DieuDongModel)result[i]).ChucVu.maChucVu, ((DieuDongModel)result[i]).ChucVu.tenChucVu);
                d.NgayQD = ((DieuDongModel)result[i]).NgayQD;
                d.LyDo = ((DieuDongModel)result[i]).LyDo;
                listNhanVien.Add(d);
            }
            string Flocation = "/doc/TCLD/dieudong/quyetdinh-dieudong.docx";
            string fileName = HostingEnvironment.MapPath("/doc/TCLD/dieudong/nhieunguoi/dieudong-template.docx");
            byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (var doc = WordprocessingDocument.Open(stream, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }
                    Regex regexText = new Regex("%ngayquyetdinh%");
                    string[] ngay = listNhanVien[0].NgayQD.Split('/');
                    docText = regexText.Replace(docText, "Ngày " + ngay[0] + " tháng " + ngay[1] + " năm " + ngay[2]);

                    regexText = new Regex("%soquyetdinh%");
                    docText = regexText.Replace(docText, listNhanVien[0].SoQD);



                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    Table table =
                       doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(2);
                    int i = 0;
                    foreach (DieuDongModel d in listNhanVien)
                    {
                        TableRow tr = new TableRow();
                        i++;
                        TableCell tc1 = new TableCell();
                        tc1.Append(new Paragraph(new Run(new Text((i).ToString()))));
                        tr.Append(tc1);

                        TableCell tc2 = new TableCell();
                        tc2.Append(new Paragraph(new Run(new Text(d.HoTen))));
                        tr.Append(tc2);

                        TableCell tc3 = new TableCell();
                        tc3.Append(new Paragraph(new Run(new Text(d.MaNV))));
                        tr.Append(tc3);

                        TableCell tc4 = new TableCell();
                        tc4.Append(new Paragraph(new Run(new Text(d.DonViHienTai))));
                        tr.Append(tc4);

                        TableCell tc5 = new TableCell();
                        tc5.Append(new Paragraph(new Run(new Text(d.DonViMoi))));
                        tr.Append(tc5);

                        TableCell tc6 = new TableCell();
                        tc6.Append(new Paragraph(new Run(new Text(d.ChucVu.tenChucVu))));
                        tr.Append(tc6);

                        TableCell tc7 = new TableCell();
                        tc7.Append(new Paragraph(new Run(new Text(d.BacLuong))));
                        tr.Append(tc7);

                        TableCell tc8 = new TableCell();
                        tc8.Append(new Paragraph(new Run(new Text(d.MucLuong.ToString()))));
                        tr.Append(tc8);

                        TableCell tc9 = new TableCell();
                        tc9.Append(new Paragraph(new Run(new Text(d.PhuCap.ToString()))));
                        tr.Append(tc9);

                        TableCell tc10 = new TableCell();
                        tc10.Append(new Paragraph(new Run(new Text(d.LyDo.ToString()))));
                        tr.Append(tc10);

                        table.Append(tr);
                    }
                    doc.MainDocumentPart.Document.Save(); // won't update the original file 
                }
                // Save the file with the new name
                string savePath = HostingEnvironment.MapPath(Flocation);
                stream.Position = 0;
                System.IO.File.WriteAllBytes(savePath, stream.ToArray());
            }
            return Json(new { success = true, location = Flocation }, JsonRequestBehavior.AllowGet);


        }

        [Route("phong-tcld/dieu-chuyen/thuc-hien-dieu-dong")]
        [HttpPost]
        public ActionResult updateToDB(string selectedList)
        {
            var js = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<DieuDongModel>>(selectedList);
            string manv = "";
            for (int i = 0; i < result.Count; i++)
            {
                manv += "'" + ((DieuDongModel)result[i]).MaNV + "',";
            }
            manv = manv.Remove(manv.Length - 1);
            List<NhanVienModel> getInfo;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select NhanVien.*,CongViec.TenCongViec from NhanVien,CongViec where MaNV in (" + manv + ") and CongViec.MaCongViec=NhanVien.MaCongViec";

                getInfo = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();

                for (int i = 0; i < result.Count; i++)
                {
                    ((DieuDongModel)result[i]).HoTen = getInfo[i].Ten;
                    ((DieuDongModel)result[i]).DonViHienTai = getInfo[i].MaPhongBan;
                    ((DieuDongModel)result[i]).ChucVuHienTai = new ChucVuModel(getInfo[i].MaCongViec.ToString(), getInfo[i].TenCongViec);
                    ((DieuDongModel)result[i]).BacLuongCu = getInfo[i].BacLuong;
                        ((DieuDongModel)result[i]).MucLuongCu = getInfo[i].MucLuong.ToString();
                }
            }
            List<DieuDongModel> listNhanVien = new List<DieuDongModel>();
            for (int i = 0; i < result.Count; i++)
            {
                DieuDongModel d = new DieuDongModel();
                d.SoQD = ((DieuDongModel)result[i]).SoQD;
                d.MaNV = ((DieuDongModel)result[i]).MaNV;
                d.HoTen = ((DieuDongModel)result[i]).HoTen;
                d.DonViHienTai = ((DieuDongModel)result[i]).DonViHienTai;
                d.ChucVuHienTai = ((DieuDongModel)result[i]).ChucVuHienTai;
                d.BacLuongCu = ((DieuDongModel)result[i]).BacLuongCu;
                d.MucLuongCu = ((DieuDongModel)result[i]).MucLuongCu;
                d.BacLuong = ((DieuDongModel)result[i]).BacLuong;
                d.MucLuong = ((DieuDongModel)result[i]).MucLuong;
                d.ThangBacLuong = ((DieuDongModel)result[i]).ThangBacLuong;
                d.PhuCap = ((DieuDongModel)result[i]).PhuCap;
                d.DonViMoi = ((DieuDongModel)result[i]).DonViMoi;
                d.ChucVu = new ChucVuModel(((DieuDongModel)result[i]).ChucVu.maChucVu, ((DieuDongModel)result[i]).ChucVu.tenChucVu);
                d.NgayQD = ((DieuDongModel)result[i]).NgayQD;
                d.LyDo = ((DieuDongModel)result[i]).LyDo;
                listNhanVien.Add(d);
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string[] date = listNhanVien[0].NgayQD.Split('/');
                        QuyetDinh q = new QuyetDinh();
                        if (listNhanVien[0].SoQD == "")
                        {
                            q.SoQuyetDinh = null;
                        }
                        else
                        {
                            q.SoQuyetDinh = listNhanVien[0].SoQD;
                        }
                        q.NgayQuyetDinh = DateTime.Parse(date[2] + "/" + date[1] + "/" + date[0]);
                        db.QuyetDinhs.Add(q);
                        db.SaveChanges();
                        int maqd = db.QuyetDinhs.Select(n => n.MaQuyetDinh).DefaultIfEmpty(0).Max();
                        for (int i = 0; i < listNhanVien.Count; i++)
                        {
                            DieuDong_NhanVien dd = new DieuDong_NhanVien();
                            dd.MaQuyetDinh = maqd;
                            dd.MaNV = listNhanVien[i].MaNV;
                            dd.LyDoDieuDong = listNhanVien[i].LyDo;
                            dd.DonViMoi = listNhanVien[i].DonViMoi;
                            dd.ChucVuMoi = listNhanVien[i].ChucVu.maChucVu;
                            dd.BacLuongMoi = listNhanVien[i].BacLuong;
                            dd.MucLuongMoi = Double.Parse(listNhanVien[i].MucLuong);
                            dd.DonViCu = listNhanVien[i].DonViHienTai;
                            dd.ChucVuCu = listNhanVien[i].ChucVuHienTai.maChucVu;
                            dd.BacLuongCu = listNhanVien[i].BacLuongCu;
                            if (listNhanVien[i].MucLuongCu == null)
                            {
                                dd.MucLuongCu = null;
                            }
                            else
                            {
                                dd.MucLuongCu = Double.Parse(listNhanVien[i].MucLuongCu == "" ? "0" : listNhanVien[i].MucLuongCu);
                            }
                            db.DieuDong_NhanVien.Add(dd);
                            db.SaveChanges();
                            if (listNhanVien[i].SoQD != "")
                            {
                                string sql3 = "update NhanVien set MaPhongBan = @MaPhongBan,\n" +
                                " MaCongViec = @MaCongViec,\n" +
                                " MucLuong = @MucLuong,\n" +
                                " BacLuong = @BacLuong, \n" +
                                " MaTrangThai = @MaTrangThai\n" +
                                "where MaNV = @MaNV";
                                db.Database.ExecuteSqlCommand(
                                sql3,
                                new SqlParameter("@MaPhongBan", listNhanVien[i].DonViMoi),
                                new SqlParameter("@MaCongViec", listNhanVien[i].ChucVu.maChucVu),
                                new SqlParameter("@MucLuong", listNhanVien[i].MucLuong),
                                new SqlParameter("@BacLuong", listNhanVien[i].BacLuong),
                                new SqlParameter("@MaTrangThai", 1),
                                new SqlParameter("@MaNV", listNhanVien[i].MaNV)
                                );
                            }
                            else
                            {
                                string sql3 = "update NhanVien set MaTrangThai = @MaTrangThai\n" +
                                              "where MaNV = @MaNV";
                                db.Database.ExecuteSqlCommand(
                                sql3,
                                new SqlParameter("@MaTrangThai", 3),
                                new SqlParameter("@MaNV", listNhanVien[i].MaNV)
                                );
                            }
                        }
                        db.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Tạo quyết định thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }

        public class NhanVienModel : NhanVien
        {
            public string department_name { get; set; }
            public string TenCongViec { get; set; }
            public string TenTrangThai { get; set; }
        }

        public class DieuDongModel
        {
            public string SoQD { get; set; }
            public string MaNV { get; set; }
            public string HoTen { get; set; }
            public string DonViHienTai { get; set; }
            public ChucVuModel ChucVuHienTai { get; set; }
            public string BacLuong { get; set; }
            public string BacLuongCu { get; set; }
            public string MucLuong { get; set; }
            public string MucLuongCu { get; set; }
            public string ThangBacLuong { get; set; }
            public string PhuCap { get; set; }
            public string DonViMoi { get; set; }
            public ChucVuModel ChucVu { get; set; }
            public string NgayQD { get; set; }
            public string LyDo { get; set; }
            public override string ToString()
            {
                return MaNV + DonViHienTai + ChucVuHienTai + BacLuong;
            }
        }
        public class ChucVuModel
        {
            public string maChucVu { get; set; }
            public string tenChucVu { get; set; }
            public ChucVuModel(string maChucVu, string tenChucVu)
            {
                this.maChucVu = maChucVu;
                this.tenChucVu = tenChucVu;
            }
        }

        [Route("phong-tcld/dieu-chuyen/check-duplicate-sqd")]
        [HttpPost]
        public ActionResult checkDuplicateSQD()
        {
            string sqd = Request["SoQD"];
            if (sqd != null && sqd != "")
            {
                int result;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string sql = "select count(SoQuyetDinh) as sqd from QuyetDinh\n" +
                    "where soQuyetDInh = @SoQD ";
                    result=db.Database.SqlQuery<int>(sql,new SqlParameter("SoQD",sqd)).ToList<int>()[0];
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

        /////////////////////////////////////////////QD DA XU LY////////////////////////////////////////////////////

        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen")]
        [HttpPost]
        public ActionResult DieuDongDaXuLy(String searchSoQuyetDinh, String searchMaNV, String searchDate)
        {
            searchMaNV = searchMaNV == null ? "" : searchMaNV;
            searchSoQuyetDinh = searchSoQuyetDinh == null ? "" : searchSoQuyetDinh;
            searchDate = searchDate == null ? "" : searchDate;
            if (searchDate != "")
            {
                string[] date = searchDate.Split('/');
                searchDate = date[2] + "/" + date[1] + "/" + date[0];
            }
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            //string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            List<QuyetDinh> listQuyetDinh = new List<QuyetDinh>();

            int totalrows;
            int totalrowsafterfiltering;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select * from quyetdinh\n" +
                             "where maquyetdinh in\n" +
                             "(SELECT  distinct MaQuyetDinh FROM DIEUDONG_NHANVIEN \n";
                if (searchMaNV != "")
                {
                    sql += " where ";
                    sql += searchMaNV == "" ? "" : " MaNV like @maNV AND";
                    sql = sql.Substring(0, sql.Length - 4);
                }
                sql += searchSoQuyetDinh == "" ? ") and  SoQuyetDinh<>''" : " ) and SoQuyetDinh like @soQuyetDinh";
                sql += searchDate == "" ? "" : " and NgayQuyetDinh = @ngayQuyetDinh";
                listQuyetDinh = db.Database.SqlQuery<QuyetDinh>(sql,
                    new SqlParameter("soQuyetDinh", "%" + searchSoQuyetDinh + "%"),
                    new SqlParameter("maNV", "%" + searchMaNV + "%"),
                    new SqlParameter("ngayQuyetDinh", searchDate)
                    ).ToList<QuyetDinh>();

                totalrows = listQuyetDinh.Count;
                totalrowsafterfiltering = listQuyetDinh.Count;

                listQuyetDinh = listQuyetDinh.OrderBy(sortColumnName + " " + sortDirection).ToList<QuyetDinh>();
                listQuyetDinh = listQuyetDinh.Skip(start).Take(length).ToList<QuyetDinh>();
            }
            return Json(new { success = true, data = listQuyetDinh, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen-detail")]
        [HttpPost]
        public ActionResult DetailQD(string MaQD)
        {
            string sql = "select \n" +
                       "tb1.MaQuyetDinh,tb1.SoQuyetDinh,tb1.NgayQuyetDinh,tb1.MaNV,tb1.Ten,tb1.MaDonViCu,\n" +
                       "tb1.DonViCu,tb1.MaChucVuCu,tb1.ChucVuCu,tb2.MaDonViMoi,tb2.DonViMoi,\n" +
                       "tb2.MaChucVuMoi,tb2.ChucVuMoi,tb2.ThangLuong,\n" +
                       "tb2.PhuCap,tb1.BacLuongMoi,tb1.MucLuongMoi,tb1.BacLuongCu,tb1.MucLuongCu,tb1.LyDoDieuDong\n" +
                       "from\n" +
                       "(select qd.MaQuyetDinh,qd.SoQuyetDinh, dd.MaNV, nv.Ten, dp.department_id as MaDonViCu,\n" +
                       "dp.department_name as DonViCu,cv.MaCongViec as MaChucVuCu, cv.TenCongViec as ChucVuCu,\n" +
                       "qd.NgayQuyetDinh,\n" +
                       "dd.BacLuongMoi, dd.MucLuongMoi,dd.BacLuongCu, dd.MucLuongCu, dd.LyDoDieuDong\n" +
                       "from QuyetDinh qd, DieuDong_NhanVien dd, NhanVien nv,\n" +
                       "CongViec cv, Department dp\n" +
                       "where\n" +
                       "nv.MaNv = dd.MaNV and\n" +
                       "qd.MaQuyetDinh = dd.MaQuyetDinh\n" +
                       "and qd.MaQuyetDinh = @MaQD1\n" +
                       "and cv.MaCongViec = dd.ChucVuCu\n" +
                       "and dp.department_id = dd.DonViCu) tb1,\n" +
                       "(select dd.MaNV,dp.department_id as MaDonViMoi,dp.department_name as DonViMoi,\n" +
                       "cv.MaCongViec as MaChucVuMoi, cv.TenCongViec as ChucVuMoi, cv.ThangLuong, cv.PhuCap\n" +
                       "from Department dp, DieuDong_NhanVien dd, CongViec cv\n" +
                       "where dp.department_id = dd.DonViMoi and\n" +
                       "cv.MaCongViec = dd.ChucVuMoi\n" +
                       "and dd.MaQuyetDinh = @MaQD2) tb2\n" +
                       "where tb1.MaNV = tb2.MaNV";
            List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                list = db.Database.SqlQuery<DetailDieuDongClass>(sql,
                    new SqlParameter("MaQD1", MaQD),
                    new SqlParameter("MaQD2", MaQD)
                    ).ToList<DetailDieuDongClass>();
            }
            return Json(new { success = true, list = list }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen-delete")]
        [HttpPost]
        public ActionResult XoaDieuDongDaXuLy(String MaQD)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string sql = "select \n" +
                      "tb1.MaQuyetDinh,tb1.SoQuyetDinh,tb1.NgayQuyetDinh,tb1.MaNV,tb1.Ten,tb1.MaDonViCu,\n" +
                      "tb1.DonViCu,tb1.MaChucVuCu,tb1.ChucVuCu,tb2.MaDonViMoi,tb2.DonViMoi,\n" +
                      "tb2.MaChucVuMoi,tb2.ChucVuMoi,tb2.ThangLuong,\n" +
                      "tb2.PhuCap,tb1.BacLuongMoi,tb1.MucLuongMoi,tb1.BacLuongCu,tb1.MucLuongCu,tb1.LyDoDieuDong\n" +
                      "from\n" +
                      "(select qd.MaQuyetDinh,qd.SoQuyetDinh, dd.MaNV, nv.Ten, dp.department_id as MaDonViCu,\n" +
                      "dp.department_name as DonViCu,cv.MaCongViec as MaChucVuCu, cv.TenCongViec as ChucVuCu,\n" +
                      "qd.NgayQuyetDinh,\n" +
                      "dd.BacLuongMoi, dd.MucLuongMoi,dd.BacLuongCu, dd.MucLuongCu, dd.LyDoDieuDong\n" +
                      "from QuyetDinh qd, DieuDong_NhanVien dd, NhanVien nv,\n" +
                      "CongViec cv, Department dp\n" +
                      "where\n" +
                      "nv.MaNv = dd.MaNV and\n" +
                      "qd.MaQuyetDinh = dd.MaQuyetDinh\n" +
                      "and qd.MaQuyetDinh = @MaQD1\n" +
                      "and cv.MaCongViec = dd.ChucVuCu\n" +
                      "and dp.department_id = dd.DonViCu) tb1,\n" +
                      "(select dd.MaNV,dp.department_id as MaDonViMoi,dp.department_name as DonViMoi,\n" +
                      "cv.MaCongViec as MaChucVuMoi, cv.TenCongViec as ChucVuMoi, cv.ThangLuong, cv.PhuCap\n" +
                      "from Department dp, DieuDong_NhanVien dd, CongViec cv\n" +
                      "where dp.department_id = dd.DonViMoi and\n" +
                      "cv.MaCongViec = dd.ChucVuMoi\n" +
                      "and dd.MaQuyetDinh = @MaQD2) tb2\n" +
                      "where tb1.MaNV = tb2.MaNV";
                        List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
                        list = db.Database.SqlQuery<DetailDieuDongClass>(sql,
                                new SqlParameter("MaQD1", MaQD),
                                new SqlParameter("MaQD2", MaQD)
                                ).ToList<DetailDieuDongClass>();
                        foreach (DetailDieuDongClass n in list)
                        {
                            string sql1 = "update NhanVien set " +
                                "MaPhongBan=@MaDonViCu," +
                                "MaCongViec=@MaChucVuCu," +
                                "BacLuong=@BacLuongCu, " +
                                "MucLuong=@MucLuongCu " +
                                "where MaNV=@MaNV";
                            db.Database.ExecuteSqlCommand(sql1,
                                new SqlParameter("MaDonViCu", n.MaDonViCu),
                                new SqlParameter("MaChucVuCu", n.MaChucVuCu == null ? 31 : n.MaChucVuCu),
                                new SqlParameter("BacLuongCu", n.BacLuongCu == null ? "" : n.BacLuongCu),
                                new SqlParameter("MucLuongCu", n.MucLuongCu == null ? 0 : n.MucLuongCu),
                                new SqlParameter("MaNV", n.MaNV)
                                );
                        }
                        db.SaveChanges();
                        //////////////////////////////////////////////////////////////
                        sql = "Delete DieuDong_NhanVien where MaQuyetDinh=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////////////////
                        sql = "Delete QuyetDinh where MaQuyetDinh=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////
                        transaction.Commit();
                        return Json(new { success = true, message = "Xóa quyết định thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }

        /////////////////////////////////////////////QD CHUA XU LY////////////////////////////////////////////////////
        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen")]
        [HttpPost]
        public ActionResult DieuDongChuaXuLy(String searchMaNV, String searchDate)
        {
            searchMaNV = searchMaNV == null ? "" : searchMaNV;
            searchDate = searchDate == null ? "" : searchDate;
            if (searchDate != "")
            {
                string[] date = searchDate.Split('/');
                searchDate = date[2] + "/" + date[1] + "/" + date[0];
            }
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            //string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            List<QuyetDinh> listQuyetDinh = new List<QuyetDinh>();

            int totalrows;
            int totalrowsafterfiltering;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select * from quyetdinh\n" +
                             "where maquyetdinh in\n" +
                             "(SELECT  distinct MaQuyetDinh FROM DIEUDONG_NHANVIEN \n";
                if (searchMaNV != "")
                {
                    sql += " where ";
                    sql += searchMaNV == "" ? "" : " MaNV like @maNV AND";
                    sql = sql.Substring(0, sql.Length - 4);
                }
                sql += ") and  SoQuyetDinh is NULL";
                sql += searchDate == "" ? "" : " and NgayQuyetDinh = @ngayQuyetDinh";
                listQuyetDinh = db.Database.SqlQuery<QuyetDinh>(sql,
                    new SqlParameter("maNV", "%" + searchMaNV + "%"),
                    new SqlParameter("ngayQuyetDinh", searchDate)
                    ).ToList<QuyetDinh>();

                totalrows = listQuyetDinh.Count;
                totalrowsafterfiltering = listQuyetDinh.Count;

                listQuyetDinh = listQuyetDinh.OrderBy(sortColumnName + " " + sortDirection).ToList<QuyetDinh>();
                listQuyetDinh = listQuyetDinh.Skip(start).Take(length).ToList<QuyetDinh>();
            }
            return Json(new { success = true, data = listQuyetDinh, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen-delete")]
        [HttpPost]
        public ActionResult XoaDieuDongChuaXuLy(String MaQD)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //////////////////////////////////////////////////////////////////////////////
                        string sql = "select MaNV from DieuDong_NhanVien where MaQuyetDinh=@MaQD";
                        List<String> listMaNV = new List<String>();
                        listMaNV = db.Database.SqlQuery<String>(sql,
                        new SqlParameter("MaQD", MaQD)).ToList<String>();
                        string listNV = "";
                        foreach (String s in listMaNV)
                        {
                            listNV += "'" + s + "'" + ",";
                        }
                        listNV = listNV.Substring(0, listNV.Length - 1);
                        //////////////////////////////////////////////////////////////
                        sql = "update NhanVien set MaTrangThai=1 where MaNV in(" + listNV + ")";
                        db.Database.ExecuteSqlCommand(sql);
                        db.SaveChanges();
                        //////////////////////////////////////////////////////////////
                        sql = "Delete DieuDong_NhanVien where MaQuyetDinh=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////////////////
                        sql = "Delete QuyetDinh where MaQuyetDinh=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////
                        transaction.Commit();
                        return Json(new { success = true, message = "Tạo quyết định thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }

        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen-update")]
        [HttpPost]
        public ActionResult CapNhatDieuDongChuaXuLy()
        {
            var SoQDText = Request["SoQDText"];
            var MaQD = Request["MaQD"];
            SoQDText = SoQDText.Substring(1, SoQDText.Length - 2);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //////////////////////////////////////////////////////////////////////////////
                        string sql = "update QuyetDinh set SoQuyetDinh=@SoQD where MaQuyetDinh=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("SoQD", SoQDText),
                            new SqlParameter("MaQD", MaQD));
                        //////////////////////////////////////////////////////////////////////////////
                        sql = "select \n" +
                        "tb1.MaQuyetDinh,tb1.SoQuyetDinh,tb1.NgayQuyetDinh,tb1.MaNV,tb1.Ten,tb1.MaDonViCu,\n" +
                        "tb1.DonViCu,tb1.MaChucVuCu,tb1.ChucVuCu,tb2.MaDonViMoi,tb2.DonViMoi,\n" +
                        "tb2.MaChucVuMoi,tb2.ChucVuMoi,tb1.ThangLuong,\n" +
                        "tb1.PhuCap,tb1.BacLuongMoi,tb1.MucLuongMoi,tb1.BacLuongCu,tb1.MucLuongCu,tb1.LyDoDieuDong\n" +
                        "from\n" +
                        "(select qd.MaQuyetDinh,qd.SoQuyetDinh, dd.MaNV, nv.Ten, dp.department_id as MaDonViCu,\n" +
                        "dp.department_name as DonViCu,cv.MaCongViec as MaChucVuCu, cv.TenCongViec as ChucVuCu,\n" +
                        "qd.NgayQuyetDinh, cv.ThangLuong, cv.PhuCap,\n" +
                        "dd.BacLuongMoi, dd.MucLuongMoi,dd.BacLuongCu, dd.MucLuongCu, dd.LyDoDieuDong\n" +
                        "from QuyetDinh qd, DieuDong_NhanVien dd, NhanVien nv,\n" +
                        "CongViec cv, Department dp\n" +
                        "where\n" +
                        "nv.MaNv = dd.MaNV and\n" +
                        "qd.MaQuyetDinh = dd.MaQuyetDinh\n" +
                        "and qd.MaQuyetDinh = @MaQD1\n" +
                        "and cv.MaCongViec = dd.ChucVuCu\n" +
                        "and dp.department_id = dd.DonViCu) tb1,\n" +
                        "(select dd.MaNV,dp.department_id as MaDonViMoi,dp.department_name as DonViMoi,\n" +
                        "cv.MaCongViec as MaChucVuMoi, cv.TenCongViec as ChucVuMoi\n" +
                        "from Department dp, DieuDong_NhanVien dd, CongViec cv\n" +
                        "where dp.department_id = dd.DonViMoi and\n" +
                        "cv.MaCongViec = dd.ChucVuMoi\n" +
                        "and dd.MaQuyetDinh = @MaQD2) tb2\n" +
                        "where tb1.MaNV = tb2.MaNV";
                        List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
                        list = db.Database.SqlQuery<DetailDieuDongClass>(sql,
                                new SqlParameter("MaQD1", MaQD),
                                new SqlParameter("MaQD2", MaQD)
                                ).ToList<DetailDieuDongClass>();
                        foreach (DetailDieuDongClass n in list)
                        {
                            sql = "update NhanVien set " +
                                "MaPhongBan=@MaDonViMoi," +
                                "MaCongViec=@MaChucVuMoi," +
                                " BacLuong=@BacLuongMoi, " +
                                "MucLuong=@MucLuongMoi, " +
                                "MaTrangThai=@MaTrangThai " +
                                "where MaNV=@MaNV";
                            db.Database.ExecuteSqlCommand(sql,
                                new SqlParameter("MaDonViMoi", n.MaDonViMoi),
                                new SqlParameter("MaChucVuMoi", n.MaChucVuMoi),
                                new SqlParameter("BacLuongMoi", n.BacLuongMoi),
                                new SqlParameter("MucLuongMoi", n.MucLuongMoi),
                                new SqlParameter("MaTrangThai", 1),
                                new SqlParameter("MaNV", n.MaNV)
                                );
                        }
                        db.SaveChanges();
                        ////////////////////////////////////////////////////
                        transaction.Commit();
                        return Json(new { success = true, message = "Cập nhật quyết định thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen-detail-export")]
        [HttpPost]
        public ActionResult ExportReportAfterAdded(string MaQD)
        {
            try
            {
                string sql = "select \n" +
           "tb1.MaQuyetDinh,tb1.SoQuyetDinh,tb1.NgayQuyetDinh,tb1.MaNV,tb1.Ten,tb1.MaDonViCu,\n" +
           "tb1.DonViCu,tb1.MaChucVuCu,tb1.ChucVuCu,tb2.MaDonViMoi,tb2.DonViMoi,\n" +
           "tb2.MaChucVuMoi,tb2.ChucVuMoi,tb1.ThangLuong,\n" +
           "tb2.PhuCap,tb1.BacLuongMoi,tb1.MucLuongMoi,tb1.LyDoDieuDong\n" +
           "from\n" +
           "(select qd.MaQuyetDinh,qd.SoQuyetDinh, dd.MaNV, nv.Ten, dp.department_id as MaDonViCu,\n" +
           "dp.department_name as DonViCu,cv.MaCongViec as MaChucVuCu, cv.TenCongViec as ChucVuCu,\n" +
           "qd.NgayQuyetDinh, cv.ThangLuong,\n" +
           "dd.BacLuongMoi, dd.MucLuongMoi, dd.LyDoDieuDong\n" +
           "from QuyetDinh qd, DieuDong_NhanVien dd, NhanVien nv,\n" +
           "CongViec cv, Department dp\n" +
           "where\n" +
           "nv.MaNv = dd.MaNV and\n" +
           "qd.MaQuyetDinh = dd.MaQuyetDinh\n" +
           "and qd.MaQuyetDinh = @MaQD1\n" +
           "and cv.MaCongViec = dd.ChucVuCu\n" +
           "and dp.department_id = dd.DonViCu) tb1,\n" +
           "(select dd.MaNV,dp.department_id as MaDonViMoi,dp.department_name as DonViMoi,\n" +
           "cv.MaCongViec as MaChucVuMoi, cv.PhuCap, cv.TenCongViec as ChucVuMoi\n" +
           "from Department dp, DieuDong_NhanVien dd, CongViec cv\n" +
           "where dp.department_id = dd.DonViMoi and\n" +
           "cv.MaCongViec = dd.ChucVuMoi\n" +
           "and dd.MaQuyetDinh = @MaQD2) tb2\n" +
           "where tb1.MaNV = tb2.MaNV";
                List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    list = db.Database.SqlQuery<DetailDieuDongClass>(sql,
                        new SqlParameter("MaQD1", MaQD),
                        new SqlParameter("MaQD2", MaQD)
                        ).ToList<DetailDieuDongClass>();
                }
                string location = WriteReport(list);
                return Json(new { success = true, location = location });
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string WriteReport(List<DetailDieuDongClass> list)
        {
            string Flocation = "/doc/TCLD/dieudong/quyetdinh-dieudong.docx";
            string fileName = HostingEnvironment.MapPath("/doc/TCLD/dieudong/nhieunguoi/dieudong-template.docx");
            try
            {
                byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
                using (var stream = new MemoryStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                    using (var doc = WordprocessingDocument.Open(stream, true))
                    {
                        string docText = null;
                        using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }
                        Regex regexText = new Regex("%ngayquyetdinh%");
                        string[] ngay = list[0].NgayQuyetDinh.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).Split('/');
                        docText = regexText.Replace(docText, "Ngày " + ngay[0] + " tháng " + ngay[1] + " năm " + ngay[2]);

                        regexText = new Regex("%soquyetdinh%");
                        docText = regexText.Replace(docText, list[0].SoQuyetDinh == null ? "" : list[0].SoQuyetDinh);



                        using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        Table table =
                           doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(2);
                        int i = 0;
                        foreach (DetailDieuDongClass d in list)
                        {
                            TableRow tr = new TableRow();
                            i++;
                            TableCell tc1 = new TableCell();
                            tc1.Append(new Paragraph(new Run(new Text((i).ToString()))));
                            tr.Append(tc1);

                            TableCell tc2 = new TableCell();
                            tc2.Append(new Paragraph(new Run(new Text(d.Ten))));
                            tr.Append(tc2);

                            TableCell tc3 = new TableCell();
                            tc3.Append(new Paragraph(new Run(new Text(d.MaNV))));
                            tr.Append(tc3);

                            TableCell tc4 = new TableCell();
                            tc4.Append(new Paragraph(new Run(new Text(d.MaDonViCu))));
                            tr.Append(tc4);

                            TableCell tc5 = new TableCell();
                            tc5.Append(new Paragraph(new Run(new Text(d.MaDonViMoi))));
                            tr.Append(tc5);

                            TableCell tc6 = new TableCell();
                            tc6.Append(new Paragraph(new Run(new Text(d.ChucVuMoi))));
                            tr.Append(tc6);

                            TableCell tc7 = new TableCell();
                            tc7.Append(new Paragraph(new Run(new Text(d.BacLuongMoi==null?"0":d.BacLuongMoi))));
                            tr.Append(tc7);

                            TableCell tc8 = new TableCell();
                            tc8.Append(new Paragraph(new Run(new Text(String.Format("{0:n0}", d.MucLuongMoi.ToString())))));
                            tr.Append(tc8);

                            TableCell tc9 = new TableCell();
                            tc9.Append(new Paragraph(new Run(new Text(String.Format("{0:n0}", d.PhuCap == null ? "" : d.PhuCap.ToString())))));
                            tr.Append(tc9);

                            TableCell tc10 = new TableCell();
                            tc10.Append(new Paragraph(new Run(new Text(d.LyDoDieuDong.ToString()))));
                            tr.Append(tc10);

                            table.Append(tr);
                        }
                        doc.MainDocumentPart.Document.Save(); // won't update the original file 
                    }
                    // Save the file with the new name
                    string savePath = HostingEnvironment.MapPath(Flocation);
                    stream.Position = 0;
                    System.IO.File.WriteAllBytes(savePath, stream.ToArray());
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return null;
            }
            return Flocation;
        }

        public class DetailDieuDongClass
        {
            public int MaQuyetDinh { get; set; }
            public string SoQuyetDinh { get; set; }
            public DateTime NgayQuyetDinh { get; set; }
            public string MaNV { get; set; }
            public string Ten { get; set; }
            public string MaDonViCu { get; set; }
            public string DonViCu { get; set; }
            public int MaChucVuCu { get; set; }
            public string ChucVuCu { get; set; }
            public string MaDonViMoi { get; set; }
            public string DonViMoi { get; set; }
            public int MaChucVuMoi { get; set; }
            public string ChucVuMoi { get; set; }
            public string ThangLuong { get; set; }
            public double? PhuCap { get; set; }
            public string BacLuongMoi { get; set; }
            public double? MucLuongMoi { get; set; }
            public string BacLuongCu { get; set; }
            public double? MucLuongCu { get; set; }
            public string LyDoDieuDong { get; set; }
        }

    }
}