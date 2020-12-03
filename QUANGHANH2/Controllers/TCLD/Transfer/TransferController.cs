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
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class TransferController : Controller
    {
        [Auther(RightID = "64")]
        public ActionResult Index()
        {
            return View();
        }

        [Auther(RightID = "64")]
        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen")]
        public ActionResult Select()
        {
            List<Work> listCongViec = new List<Work>();
            List<Department> listPhongBan = new List<Department>();
            List<PayRate> listBacLuong = new List<PayRate>();

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select * from CongViec";
                listCongViec = db.Works.SqlQuery(sql).ToList<Work>();

                sql = "select * from Department";
                listPhongBan = db.Departments.SqlQuery(sql).ToList<Department>();

                sql = "select * from BacLuong";
                listBacLuong = db.Database.SqlQuery<PayRate>(sql).ToList<PayRate>();

            }
            ViewBag.listCongViec = listCongViec;
            ViewBag.listPhongBan = listPhongBan;
            ViewBag.listBacLuong = listBacLuong;
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/Process.cshtml");
        }

        [Auther(RightID = "102")]
        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen")]
        public ActionResult Did()
        {
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/History.cshtml");
        }

        [Auther(RightID = "103")]
        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen")]
        public ActionResult NotYet()
        {
            ViewBag.nameDepartment = "dieuchuyen";
            return View("/Views/TCLD/Transfer/Temporary.cshtml");
        }

        [Auther(RightID = "64")]
        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen")]
        [HttpPost]
        public ActionResult GetData(String selectListJson, String searchMa, String searchTen, String phongbanSearch, String chucVuSearch)
        {
            while (searchMa.Contains("  "))
            {
                searchMa = searchMa.Replace("  ", " ");
            }
            searchMa = searchMa.Trim();
            string[] searchListID = searchMa.Split(' ');
            searchMa = "";
            for (int i = 0; i < searchListID.Length; i++)
            {
                searchMa += "'" + searchListID[i] + "',";
            }
            searchMa = searchMa.Contains(",") ? searchMa.Substring(0, searchMa.Length - 1) : searchMa;
            searchMa = searchMa == "''" ? "" : searchMa;
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
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            ViewBag.selectedList = cookie.Value;
            //
            List<NhanVienModel> listNhanVien = new List<NhanVienModel>();

            int totalrows;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
                    sql += searchMa == "" ? "" : " A.employee_id in (" + searchMa + ") AND";
                    sql += searchTen == "" ? "" : " A.Ten like @tenNV AND";
                    sql += phongbanSearch == "-1" ? "" : " A.MaPhongBan = @maPhongBan AND";
                    sql += chucVuSearch == "-1" ? "" : " A.MaCongViec = @maCongViec AND";
                    sql = sql.Substring(0, sql.Length - 4).Trim();
                }
                sql += sql.Contains("where") ? " AND A.MaTrangThai<>2" : " WHERE A.MaTrangThai<>2";
                listNhanVien = db.Database.SqlQuery<NhanVienModel>(sql + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("tenNV", "%" + searchTen + "%"),
                    new SqlParameter("maPhongBan", phongbanSearch),
                    new SqlParameter("maCongViec", chucVuSearch)
                    ).ToList();
                totalrows = db.Database.SqlQuery<Int32>(sql.Replace("A.*,B.department_name,C.TenCongViec,D.TenTrangThai", "Count(*) as count"),
                    new SqlParameter("tenNV", "%" + searchTen + "%"),
                    new SqlParameter("maPhongBan", phongbanSearch),
                    new SqlParameter("maCongViec", chucVuSearch)).ToList<Int32>()[0];


            }
            return Json(new { success = true, totalrows = totalrows, data = listNhanVien, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "64")]
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
            }

            List<NhanVienModel> listNhanVien = new List<NhanVienModel>();
            int totalrows = listNhanVien.Count;
            int totalrowsafterfiltering = listNhanVien.Count;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql =
                @"SELECT A.employee_id,A.Ten,B.department_name,C.TenCongViec,C.PhuCap, D.MucBacLuong as BacLuong, D.MucThangLuong as ThangLuong, D.MucLuong as Luong, A.MaPhongBan, A.MaCongViec
                 FROM(
                (SELECT * FROM NhanVien where employee_id in (" + selected + @" )) A
                 left OUTER JOIN
                 (SELECT department_id, department_name FROM Department) B on A.MaPhongBan = B.department_id
                 left OUTER JOIN
                 (SELECT MaCongViec, TenCongViec,PhuCap,MaThangLuong FROM CongViec) C on A.MaCongViec = C.MaCongViec
				 left OUTER JOIN
				 (SELECT tl.MaThangLuong,bl.MaBacLuong, mtm.MaBacLuong_ThangLuong_MucLuong ,tl.MucThangLuong,bl.MucBacLuong,mtm.MucLuong 
				 FROM BacLuong_ThangLuong_MucLuong mtm , BacLuong bl, ThangLuong tl WHERE mtm.MaBacLuong=bl.MaBacLuong AND mtm.MaThangLuong=tl.MaThangLuong) D
				 on A.MaBacLuong_ThangLuong_MucLuong=D.MaBacLuong_ThangLuong_MucLuong
				 ) ";
                listNhanVien = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();
            }
            return Json(new { success = true, data = listNhanVien, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "64")]
        [Route("phong-tcld/dieu-chuyen/get-phu-cap-thang-luong")]
        [HttpPost]
        public ActionResult getPhuCapAndThangLuong()
        {
            int macv = int.Parse(Request["macv"]);
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    var data = (from t1 in db.Works
                                from t2 in db.PayTables.Where(x => t1.pay_table_id == x.pay_table_id && t1.work_id == macv)
                                select new { t1.name, t1.allowance, t2.pay_table, t2.pay_table_id }).FirstOrDefault();

                    var bacs = (from t1 in db.PayRates
                                from t2 in db.Salaries.Where(x => t1.pay_rate_id == x.pay_rate_id && x.pay_table_id == data.pay_table_id)
                                select new { t2.salary_id, t1.pay_rate_id, t1.pay_rate, t2.salary_number }).ToList();

                    return Json(new { success = true, bacs = bacs, data = data, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return null;
                }

            }
        }

        [Auther(RightID = "64")]
        [Route("phong-tcld/dieu-chuyen/get-chuc-vu-theo-don-vi")]
        [HttpPost]
        public ActionResult getChucVu()
        {
            var selectedDeptId = Request["selectedDeptId"];
            List<Work> congviec_phongban = new List<Work>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    if (selectedDeptId != "-1")
                    {
                        string sql = @"Select A.MaCongViec, CongViec.TenCongViec, CongViec.PhuCap , CongViec.MaThangLuong  from CongViec,
                                (select  DISTINCT MaCongViec from NhanVien, Department
                                where MaPhongBan = @MaPhongBan) A
                                where A.MaCongViec = CongViec.MaCongViec";
                        congviec_phongban = db.Database.SqlQuery<Work>(sql,
                            new SqlParameter("@MaPhongBan", selectedDeptId)).ToList<Work>();
                    }
                    else
                    {
                        string sql = @"select * from CongViec";
                        congviec_phongban = db.Database.SqlQuery<Work>(sql).ToList<Work>();
                    }

                    return Json(new { success = true, congviec_phongban = congviec_phongban }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        [Auther(RightID = "64")]
        [Route("phong-tcld/dieu-chuyen/tien-hanh-dieu-chuyen-step-3")]
        [HttpPost]
        public ActionResult Step3(string selectedList)
        {
            var js = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<DieuDongModel>>(selectedList);
            string employee_id = "";
            for (int i = 0; i < result.Count; i++)
            {
                employee_id += "'" + ((DieuDongModel)result[i]).employee_id + "',";
            }
            employee_id = employee_id.Remove(employee_id.Length - 1);
            List<NhanVienModel> getInfo;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "SELECT  A.*,B.department_name,C.TenCongViec" +
                " FROM" +
                "(" +
                "(SELECT * FROM NhanVien where employee_id in (" + employee_id + ")) A" +
                " left OUTER JOIN" +
                " (SELECT department_id, department_name FROM Department) B on A.MaPhongBan = B.department_id" +
                " left OUTER JOIN" +
                " (SELECT MaCongViec, TenCongViec FROM CongViec) C on A.MaCongViec = C.MaCongViec" +
                " )";
                getInfo = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();

                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (((DieuDongModel)result[j]).employee_id == getInfo[i].employee_id)
                        {
                            ((DieuDongModel)result[j]).HoTen = getInfo[i].BASIC_INFO_full_name;
                            ((DieuDongModel)result[j]).DonViHienTai = getInfo[i].department_name;
                            ((DieuDongModel)result[j]).ChucVuHienTai = new ChucVuModel(getInfo[i].current_work_id.ToString(), getInfo[i].TenCongViec);
                        }
                    }

                }
            }
            List<DieuDongModel> listNhanVien = new List<DieuDongModel>();
            for (int i = 0; i < result.Count; i++)
            {
                DieuDongModel d = new DieuDongModel();
                d.SoQD = ((DieuDongModel)result[i]).SoQD;
                d.employee_id = ((DieuDongModel)result[i]).employee_id;
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
            string employee_id = "";
            for (int i = 0; i < result.Count; i++)
            {
                employee_id += "'" + ((DieuDongModel)result[i]).employee_id + "',";
            }
            employee_id = employee_id.Remove(employee_id.Length - 1);
            List<NhanVienModel> getInfo;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select NhanVien.*,CongViec.TenCongViec from NhanVien,CongViec where employee_id in (" + employee_id + ") and CongViec.MaCongViec=NhanVien.MaCongViec";

                getInfo = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();

                for (int i = 0; i < result.Count; i++)
                {

                    for (int j = 0; j < result.Count; j++)
                    {
                        if (((DieuDongModel)result[j]).employee_id == getInfo[i].employee_id)
                        {
                            ((DieuDongModel)result[j]).GioiTinh = getInfo[i].BASIC_INFO_gender;
                            ((DieuDongModel)result[j]).HoTen = getInfo[i].BASIC_INFO_full_name;
                            ((DieuDongModel)result[j]).DonViHienTai = getInfo[i].current_department_id;
                            ((DieuDongModel)result[j]).ChucVuHienTai = new ChucVuModel(getInfo[i].current_work_id.ToString(), getInfo[i].TenCongViec);
                        }
                    }
                }
            }
            List<DieuDongModel> listNhanVien = new List<DieuDongModel>();
            for (int i = 0; i < result.Count; i++)
            {
                DieuDongModel d = new DieuDongModel();
                d.SoQD = ((DieuDongModel)result[i]).SoQD;
                d.employee_id = ((DieuDongModel)result[i]).employee_id;
                d.GioiTinh = ((DieuDongModel)result[i]).GioiTinh;
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
            //Mot nguoi
            if (listNhanVien.Count == 1)
            {
                string fileName = HostingEnvironment.MapPath("/doc/TCLD/dieudong/motnguoi/dieudong-template.docx");
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

                        regexText = new Regex("%soqd%");
                        docText = regexText.Replace(docText, listNhanVien[0].SoQD);

                        regexText = new Regex("%gender%");
                        docText = regexText.Replace(docText, listNhanVien[0].GioiTinh == true ? "Ông" : "Bà");

                        regexText = new Regex("%hoten%");
                        docText = regexText.Replace(docText, listNhanVien[0].HoTen);

                        regexText = new Regex("%sothe%");
                        docText = regexText.Replace(docText, listNhanVien[0].employee_id);

                        if (listNhanVien[0].DonViMoi == listNhanVien[0].DonViHienTai)
                        {
                            regexText = new Regex("%dept1%");
                            docText = regexText.Replace(docText, "Thuộc phân xưởng " + listNhanVien[0].DonViHienTai);

                            regexText = new Regex("%cmn%");
                            docText = regexText.Replace(docText, listNhanVien[0].DonViHienTai);
                        }
                        else
                        {
                            regexText = new Regex("%dept1%");
                            docText = regexText.Replace(docText, "Thuộc " + listNhanVien[0].DonViHienTai + " đến " + listNhanVien[0].DonViMoi);

                            regexText = new Regex("%cmn%");
                            docText = regexText.Replace(docText, listNhanVien[0].DonViHienTai + ", " + listNhanVien[0].DonViMoi);

                        }

                        regexText = new Regex("%bacluong%");
                        docText = regexText.Replace(docText, listNhanVien[0].BacLuong);

                        regexText = new Regex("%nhiemvumoi%");
                        docText = regexText.Replace(docText, listNhanVien[0].ChucVu.tenChucVu);

                        regexText = new Regex("%mucluong%");
                        docText = regexText.Replace(docText, listNhanVien[0].MucLuong == "Chưa cập nhật" ? "    " : listNhanVien[0].MucLuong);

                        regexText = new Regex("%thangluong%");
                        docText = regexText.Replace(docText, listNhanVien[0].ThangBacLuong == "Chưa cập nhật" ? "    " : listNhanVien[0].ThangBacLuong);

                        using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }

                        doc.MainDocumentPart.Document.Save(); // won't update the original file 
                    }
                    // Save the file with the new name
                    string savePath = HostingEnvironment.MapPath(Flocation);
                    stream.Position = 0;
                    System.IO.File.WriteAllBytes(savePath, stream.ToArray());
                }
            }
            //nhieu nguoi
            else
            {
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
                            tc3.Append(new Paragraph(new Run(new Text(d.employee_id))));
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
            }

            return Json(new { success = true, location = Flocation }, JsonRequestBehavior.AllowGet);


        }

        [Route("phong-tcld/dieu-chuyen/thuc-hien-dieu-dong")]
        [HttpPost]
        public ActionResult updateToDB(string selectedList)
        {
            var js = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<DieuDongModel>>(selectedList);
            string employee_id = "";
            for (int i = 0; i < result.Count; i++)
            {
                employee_id += "'" + ((DieuDongModel)result[i]).employee_id + "',";
            }
            employee_id = employee_id.Remove(employee_id.Length - 1);
            List<NhanVienModel> getInfo;
            ///////////////////////////////////////////GET CURRENT INFO OF NHANVIENS////////////////////////////////
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select NhanVien.*,CongViec.TenCongViec from NhanVien,CongViec where employee_id in (" + employee_id + ") and CongViec.MaCongViec=NhanVien.MaCongViec";

                getInfo = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();

                for (int i = 0; i < result.Count; i++)
                {

                    for (int j = 0; j < result.Count; j++)
                    {
                        if (((DieuDongModel)result[j]).employee_id == getInfo[i].employee_id)
                        {
                            ((DieuDongModel)result[j]).HoTen = getInfo[i].BASIC_INFO_full_name;
                            ((DieuDongModel)result[j]).DonViHienTai = getInfo[i].current_department_id;
                            ((DieuDongModel)result[j]).ChucVuHienTai = new ChucVuModel(getInfo[i].current_work_id.ToString(), getInfo[i].TenCongViec);
                            ((DieuDongModel)result[j]).new_salary_id = getInfo[i].current_salary_id;
                        }
                    }
                }
            }

            List<DieuDongModel> listNhanVien = new List<DieuDongModel>();
            for (int i = 0; i < result.Count; i++)
            {
                DieuDongModel d = new DieuDongModel();
                d.SoQD = ((DieuDongModel)result[i]).SoQD;
                d.employee_id = ((DieuDongModel)result[i]).employee_id;
                d.HoTen = ((DieuDongModel)result[i]).HoTen;
                d.DonViHienTai = ((DieuDongModel)result[i]).DonViHienTai;
                d.ChucVuHienTai = ((DieuDongModel)result[i]).ChucVuHienTai;
                d.new_salary_id = ((DieuDongModel)result[i]).new_salary_id;
                d.old_salary_id = ((DieuDongModel)result[i]).old_salary_id;
                d.DonViMoi = ((DieuDongModel)result[i]).DonViMoi;
                d.ChucVu = new ChucVuModel(((DieuDongModel)result[i]).ChucVu.maChucVu, ((DieuDongModel)result[i]).ChucVu.tenChucVu);
                d.NgayQD = ((DieuDongModel)result[i]).NgayQD;
                d.LyDo = ((DieuDongModel)result[i]).LyDo;
                listNhanVien.Add(d);
            }
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string[] date = listNhanVien[0].NgayQD.Split('/');
                        Decision q = new Decision();
                        if (listNhanVien[0].SoQD == "")
                        {
                            q.number = null;
                        }
                        else
                        {
                            q.number = listNhanVien[0].SoQD;
                        }
                        q.date = DateTime.Parse(date[2] + "/" + date[1] + "/" + date[0]);
                        db.Decisions.Add(q);
                        db.SaveChanges();
                        int maqd = db.Decisions.Select(n => n.decision_id).DefaultIfEmpty(0).Max();
                        for (int i = 0; i < listNhanVien.Count; i++)
                        {
                            Transfer dd = new Transfer();
                            dd.decision_id = maqd;
                            dd.employee_id = listNhanVien[i].employee_id;
                            dd.transfer_reason = listNhanVien[i].LyDo;
                            dd.new_department_id = listNhanVien[i].DonViMoi;
                            dd.new_work_id = int.Parse(listNhanVien[i].ChucVu.maChucVu);
                            dd.old_department_id = listNhanVien[i].DonViHienTai;
                            dd.old_work_id = int.Parse(listNhanVien[i].ChucVuHienTai.maChucVu);
                            dd.new_salary_id = listNhanVien[i].new_salary_id;
                            dd.old_salary_id = listNhanVien[i].old_salary_id;

                            db.Transfers.Add(dd);
                            db.SaveChanges();
                            if (listNhanVien[i].SoQD != "")//CHƯA CÓ SỐ QUYẾT ĐỊNH
                            {
                                string sql3 = "update NhanVien set MaPhongBan = @MaPhongBan,\n" +
                                " MaCongViec = @MaCongViec,\n" +
                                " MaBacLuong_ThangLuong_MucLuong = @MaBacLuong_ThangLuong_MucLuong,\n" +
                                " MaTrangThai = @MaTrangThai\n" +
                                "where employee_id = @employee_id";
                                db.Database.ExecuteSqlCommand(
                                sql3,
                                new SqlParameter("@MaPhongBan", listNhanVien[i].DonViMoi),
                                new SqlParameter("@MaCongViec", listNhanVien[i].ChucVu.maChucVu),
                                new SqlParameter("@MaBacLuong_ThangLuong_MucLuong", listNhanVien[i].old_salary_id),
                                new SqlParameter("@MaTrangThai", 1),
                                new SqlParameter("@employee_id", listNhanVien[i].employee_id)
                                );
                            }
                            else
                            {
                                string sql3 = "update NhanVien set MaTrangThai = @MaTrangThai\n" +
                                              "where employee_id = @employee_id";
                                db.Database.ExecuteSqlCommand(
                                sql3,
                                new SqlParameter("@MaTrangThai", 3),
                                new SqlParameter("@employee_id", listNhanVien[i].employee_id)
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

        public class NhanVienModel : Employee
        {
            public string department_name { get; set; }
            public string TenCongViec { get; set; }
            public string TenTrangThai { get; set; }
            public double? PhuCap { get; set; }
            public string ThangLuong { get; set; }

            public string Luong { get; set; }
        }

        public class DieuDongModel
        {
            public bool? GioiTinh { get; set; }
            public string SoQD { get; set; }
            public string employee_id { get; set; }
            public string HoTen { get; set; }
            public string DonViHienTai { get; set; }
            public ChucVuModel ChucVuHienTai { get; set; }
            public string BacLuong { get; set; }
            public string BacLuongCu { get; set; }
            public string MucLuong { get; set; }
            public string MucLuongCu { get; set; }
            public string ThangBacLuong { get; set; }
            public string PhuCap { get; set; }
            public int? new_salary_id { get; set; }
            public int? old_salary_id { get; set; }
            public string DonViMoi { get; set; }
            public ChucVuModel ChucVu { get; set; }
            public string NgayQD { get; set; }
            public string LyDo { get; set; }
            public override string ToString()
            {
                return employee_id + DonViHienTai + ChucVuHienTai + BacLuong;
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
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string sql = "select count(SoQuyetDinh) as sqd from QuyetDinh\n" +
                    "where soQuyetDInh = @SoQD ";
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

        /////////////////////////////////////////////QD DA XU LY////////////////////////////////////////////////////
        [Auther(RightID = "102")]
        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen")]
        [HttpPost]
        public ActionResult DieuDongDaXuLy(String searchSoQuyetDinh, String searchemployee_id, String searchDate)
        {
            searchemployee_id = searchemployee_id == null ? "" : searchemployee_id;
            searchSoQuyetDinh = searchSoQuyetDinh == null ? "" : searchSoQuyetDinh;
            searchDate = searchDate == null ? "" : searchDate;
            if (searchDate != "")
            {
                string[] date = searchDate.Split('/');
                searchDate = date[2] + "/" + date[1] + "/" + date[0];
            }
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            List<Decision> listQuyetDinh = new List<Decision>();

            int totalrows;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select * from quyetdinh\n" +
                             "where decision_id in\n" +
                             "(SELECT  distinct decision_id FROM Transfer \n";
                if (searchemployee_id != "")
                {
                    sql += " where ";
                    sql += searchemployee_id == "" ? "" : " employee_id like @employee_id AND";
                    sql = sql.Substring(0, sql.Length - 4);
                }
                sql += searchSoQuyetDinh == "" ? ") and  SoQuyetDinh<>''" : " ) and SoQuyetDinh like @soQuyetDinh";
                sql += searchDate == "" ? "" : " and NgayQuyetDinh = @ngayQuyetDinh";
                listQuyetDinh = db.Database.SqlQuery<Decision>(sql + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("soQuyetDinh", "%" + searchSoQuyetDinh + "%"),
                    new SqlParameter("employee_id", "%" + searchemployee_id + "%"),
                    new SqlParameter("ngayQuyetDinh", searchDate)
                    ).ToList<Decision>();

                totalrows = db.Database.SqlQuery<int>(sql.Replace("*", "count(decision_id)"),
                    new SqlParameter("soQuyetDinh", "%" + searchSoQuyetDinh + "%"),
                    new SqlParameter("employee_id", "%" + searchemployee_id + "%"),
                    new SqlParameter("ngayQuyetDinh", searchDate)
                    ).FirstOrDefault();
            }
            return Json(new { success = true, data = listQuyetDinh, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "102")]
        [Route("phong-tcld/dieu-chuyen/da-xu-li-dieu-chuyen-detail")]
        [HttpPost]
        public ActionResult DetailQD(string MaQD)
        {
            string sql = @"			select 
           tb1.decision_id,tb1.SoQuyetDinh,tb1.NgayQuyetDinh,tb1.employee_id,tb1.Ten,tb1.old_department_id,
           tb1.DonViCu,tb1.old_work_id,tb1.ChucVuCu,tb2.new_department_id,tb2.DonViMoi,
           tb2.new_work_id,tb2.ChucVuMoi,tb3.MucBacLuong as BacLuongMoi,
           tb2.PhuCap,tb3.MucThangLuong as ThangLuong,tb3.MucLuong as MucLuongMoi,tb1.transfer_reason
           from
           (select qd.decision_id,qd.SoQuyetDinh, dd.employee_id, nv.Ten, dp.department_id as old_department_id,
           dp.department_name as DonViCu,cv.MaCongViec as old_work_id, cv.TenCongViec as ChucVuCu,
           qd.NgayQuyetDinh, dd.transfer_reason,dd.old_salary_id
           from QuyetDinh qd, Transfer dd, NhanVien nv,
           CongViec cv, Department dp
           where  
           nv.employee_id = dd.employee_id and
           qd.decision_id = dd.decision_id
           and qd.decision_id = @MaQD1
           and cv.MaCongViec = dd.old_work_id
           and dp.department_id = dd.old_department_id) tb1,

           (select dd.employee_id,dp.department_id as new_department_id,dp.department_name as DonViMoi,
           cv.MaCongViec as new_work_id, cv.PhuCap, cv.TenCongViec as ChucVuMoi
           from Department dp, Transfer dd, CongViec cv
           where dp.department_id = dd.new_department_id and
           cv.MaCongViec = dd.new_work_id
           and dd.decision_id = @MaQD2) tb2,

		   (select btm.MaBacLuong_ThangLuong_MucLuong,
		   bl.MaBacLuong,
		   bl.MucBacLuong,
		   tl.MaThangLuong,tl.MucThangLuong,
		   btm.MucLuong 
		   from 
		   BacLuong_ThangLuong_MucLuong btm, BacLuong bl, ThangLuong tl
		   where btm.MaBacLuong=bl.MaBacLuong and tl.MaThangLuong=btm.MaThangLuong) tb3
           where tb1.employee_id = tb2.employee_id and tb1.old_salary_id=tb3.MaBacLuong_ThangLuong_MucLuong";
            List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {

                    try
                    {
                        List<RecentQuyetDinhNhanVien> checkList = new List<RecentQuyetDinhNhanVien>();
                        string query = "select employee_id, max(NgayQuyetDinh)  as NgayQuyetDinhGanNhat from QUyetDinh,Transfer\n" +
                        "where QuyetDinh.decision_id = Transfer.decision_id and\n" +
                        "Transfer.employee_id in (select employee_id from Transfer where decision_id = @decision_id)\n" +
                        "group by employee_id\n";
                        checkList = db.Database.SqlQuery<RecentQuyetDinhNhanVien>(query, new SqlParameter("decision_id", MaQD)).ToList<RecentQuyetDinhNhanVien>();

                        string sql = @"select a.*,b.NgayQuyetDinh from Transfer a,QuyetDinh b
                                        where a.decision_id=b.decision_id and a.decision_id=@MaQD";
                        List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
                        list = db.Database.SqlQuery<DetailDieuDongClass>(sql,
                                new SqlParameter("MaQD", MaQD)
                                ).ToList<DetailDieuDongClass>();

                        foreach (DetailDieuDongClass n in list)
                        {
                            foreach (RecentQuyetDinhNhanVien nv in checkList)
                            {
                                if (n.employee_id == nv.employee_id && n.NgayQuyetDinh == nv.NgayQuyetDinhGanNhat)
                                {
                                    string sql1 = "update NhanVien set " +
                                          "MaPhongBan=@old_department_id," +
                                          "MaCongViec=@old_work_id," +
                                          "MaBacLuong_ThangLuong_MucLuong=@MaBacLuong_ThangLuong_MucLuong " +
                                          "where employee_id=@employee_id";
                                    if (n.new_salary_id == null)
                                    {
                                        db.Database.ExecuteSqlCommand(sql1,
                                            new SqlParameter("old_department_id", n.old_department_id),
                                            new SqlParameter("old_work_id", n.old_work_id == null ? 31 : n.old_work_id),
                                            new SqlParameter("MaBacLuong_ThangLuong_MucLuong", DBNull.Value),
                                            new SqlParameter("employee_id", n.employee_id)
                                            );
                                    }
                                    else
                                    {
                                        db.Database.ExecuteSqlCommand(sql1,
                                            new SqlParameter("old_department_id", n.old_department_id),
                                            new SqlParameter("old_work_id", n.old_work_id == null ? 31 : n.old_work_id),
                                            new SqlParameter("MaBacLuong_ThangLuong_MucLuong", n.new_salary_id),
                                            new SqlParameter("employee_id", n.employee_id)
                                            );
                                    }


                                }
                            }
                        }
                        db.SaveChanges();
                        //////////////////////////////////////////////////////////////
                        sql = "Delete Transfer where decision_id=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////////////////
                        sql = "Delete QuyetDinh where decision_id=@MaQD";
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
        [Auther(RightID = "103")]
        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen")]
        [HttpPost]
        public ActionResult DieuDongChuaXuLy(String searchemployee_id, String searchDate)
        {
            searchemployee_id = searchemployee_id == null ? "" : searchemployee_id;
            searchDate = searchDate == null ? "" : searchDate;
            if (searchDate != "")
            {
                string[] date = searchDate.Split('/');
                searchDate = date[2] + "/" + date[1] + "/" + date[0];
            }
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            List<Decision> listQuyetDinh = new List<Decision>();

            int totalrows;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select * from quyetdinh\n" +
                             "where decision_id in\n" +
                             "(SELECT  distinct decision_id FROM Transfer \n";
                if (searchemployee_id != "")
                {
                    sql += " where ";
                    sql += searchemployee_id == "" ? "" : " employee_id like @employee_id AND";
                    sql = sql.Substring(0, sql.Length - 4);
                }
                sql += ") and  SoQuyetDinh is NULL";
                sql += searchDate == "" ? "" : " and NgayQuyetDinh = @ngayQuyetDinh";
                listQuyetDinh = db.Database.SqlQuery<Decision>(sql + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("employee_id", "%" + searchemployee_id + "%"),
                    new SqlParameter("ngayQuyetDinh", searchDate)
                    ).ToList<Decision>();

                totalrows = db.Database.SqlQuery<int>(sql.Replace("*", "count(decision_id)"),
                    new SqlParameter("employee_id", "%" + searchemployee_id + "%"),
                    new SqlParameter("ngayQuyetDinh", searchDate)
                    ).FirstOrDefault();
            }
            return Json(new { success = true, data = listQuyetDinh, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "103")]
        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen-delete")]
        [HttpPost]
        public ActionResult XoaDieuDongChuaXuLy(String MaQD)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //////////////////////////////////////////////////////////////////////////////
                        string sql = "select employee_id from Transfer where decision_id=@MaQD";
                        List<String> listemployee_id = new List<String>();
                        listemployee_id = db.Database.SqlQuery<String>(sql,
                        new SqlParameter("MaQD", MaQD)).ToList<String>();
                        string listNV = "";
                        foreach (String s in listemployee_id)
                        {
                            listNV += "'" + s + "'" + ",";
                        }
                        listNV = listNV.Substring(0, listNV.Length - 1);
                        //////////////////////////////////////////////////////////////
                        sql = "update NhanVien set MaTrangThai=1 where employee_id in(" + listNV + ")";
                        db.Database.ExecuteSqlCommand(sql);
                        db.SaveChanges();
                        //////////////////////////////////////////////////////////////
                        sql = "Delete Transfer where decision_id=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////////////////
                        sql = "Delete QuyetDinh where decision_id=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("MaQD", MaQD));
                        db.SaveChanges();
                        ////////////////////////////////////////////////////
                        transaction.Commit();
                        return Json(new { success = true, message = "Xoá quyết định thành công" }, JsonRequestBehavior.AllowGet);
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

        [Auther(RightID = "119")]
        [Route("phong-tcld/dieu-chuyen/chua-xu-li-dieu-chuyen-update")]
        [HttpPost]
        public ActionResult CapNhatDieuDongChuaXuLy()
        {
            var SoQDText = Request["SoQDText"];
            var MaQD = Request["MaQD"];
            SoQDText = SoQDText.Substring(1, SoQDText.Length - 2);
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //////////////////////////////////////////////////////////////////////////////
                        string sql = "update QuyetDinh set SoQuyetDinh=@SoQD where decision_id=@MaQD";
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("SoQD", SoQDText),
                            new SqlParameter("MaQD", MaQD));
                        //////////////////////////////////////////////////////////////////////////////
                        sql = "select * from Transfer where decision_id=@MaQD";
                        List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
                        list = db.Database.SqlQuery<DetailDieuDongClass>(sql,
                                new SqlParameter("MaQD", MaQD)
                                ).ToList<DetailDieuDongClass>();
                        foreach (DetailDieuDongClass n in list)
                        {
                            sql = "update NhanVien set " +
                                "MaPhongBan=@new_department_id," +
                                "MaCongViec=@new_work_id," +
                                "MaBacLuong_ThangLuong_MucLuong=@MaBacLuong_ThangLuong_MucLuong, " +
                                "MaTrangThai=@MaTrangThai " +
                                "where employee_id=@employee_id";
                            db.Database.ExecuteSqlCommand(sql,
                                new SqlParameter("new_department_id", n.new_department_id),
                                new SqlParameter("new_work_id", n.new_work_id),
                                new SqlParameter("MaBacLuong_ThangLuong_MucLuong", n.old_salary_id),
                                new SqlParameter("MaTrangThai", 1),
                                new SqlParameter("employee_id", n.employee_id)
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
                string sql = @"			select 
           tb1.decision_id,tb1.SoQuyetDinh,tb1.NgayQuyetDinh,tb1.employee_id,tb1.Ten,tb1.old_department_id,
           tb1.DonViCu,tb1.old_work_id,tb1.ChucVuCu,tb2.new_department_id,tb2.DonViMoi,
           tb2.new_work_id,tb2.ChucVuMoi,tb3.MucBacLuong as BacLuongMoi,
           tb2.PhuCap,tb3.MucThangLuong as ThangLuong,tb3.MucLuong as MucLuongMoi,tb1.transfer_reason
           from
           (select qd.decision_id,qd.SoQuyetDinh, dd.employee_id, nv.Ten, dp.department_id as old_department_id,
           dp.department_name as DonViCu,cv.MaCongViec as old_work_id, cv.TenCongViec as ChucVuCu,
           qd.NgayQuyetDinh, dd.transfer_reason,dd.old_salary_id
           from QuyetDinh qd, Transfer dd, NhanVien nv,
           CongViec cv, Department dp
           where  
           nv.employee_id = dd.employee_id and
           qd.decision_id = dd.decision_id
           and qd.decision_id = @MaQD1
           and cv.MaCongViec = dd.old_work_id
           and dp.department_id = dd.old_department_id) tb1,

           (select dd.employee_id,dp.department_id as new_department_id,dp.department_name as DonViMoi,
           cv.MaCongViec as new_work_id, cv.PhuCap, cv.TenCongViec as ChucVuMoi
           from Department dp, Transfer dd, CongViec cv
           where dp.department_id = dd.new_department_id and
           cv.MaCongViec = dd.new_work_id
           and dd.decision_id = @MaQD2) tb2,

		   (select btm.MaBacLuong_ThangLuong_MucLuong,
		   bl.MaBacLuong,
		   bl.MucBacLuong,
		   tl.MaThangLuong,tl.MucThangLuong,
		   btm.MucLuong 
		   from 
		   BacLuong_ThangLuong_MucLuong btm, BacLuong bl, ThangLuong tl
		   where btm.MaBacLuong=bl.MaBacLuong and tl.MaThangLuong=btm.MaThangLuong) tb3
           where tb1.employee_id = tb2.employee_id and tb1.old_salary_id=tb3.MaBacLuong_ThangLuong_MucLuong";
                List<DetailDieuDongClass> list = new List<DetailDieuDongClass>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
                            tc3.Append(new Paragraph(new Run(new Text(d.employee_id))));
                            tr.Append(tc3);

                            TableCell tc4 = new TableCell();
                            tc4.Append(new Paragraph(new Run(new Text(d.old_department_id))));
                            tr.Append(tc4);

                            TableCell tc5 = new TableCell();
                            tc5.Append(new Paragraph(new Run(new Text(d.new_department_id))));
                            tr.Append(tc5);

                            TableCell tc6 = new TableCell();
                            tc6.Append(new Paragraph(new Run(new Text(d.ChucVuMoi))));
                            tr.Append(tc6);

                            TableCell tc7 = new TableCell();
                            tc7.Append(new Paragraph(new Run(new Text(d.BacLuongMoi == null ? "0" : d.BacLuongMoi))));
                            tr.Append(tc7);

                            TableCell tc8 = new TableCell();
                            tc8.Append(new Paragraph(new Run(new Text(String.Format("{0:N2}", Convert.ToDouble(d.MucLuongMoi.ToString()))))));
                            tr.Append(tc8);

                            TableCell tc9 = new TableCell();
                            tc9.Append(new Paragraph(new Run(new Text(String.Format("{0:n0}", d.PhuCap == null ? "" : d.PhuCap.ToString())))));
                            tr.Append(tc9);

                            TableCell tc10 = new TableCell();
                            tc10.Append(new Paragraph(new Run(new Text(d.transfer_reason.ToString()))));
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
            public int decision_id { get; set; }
            public string SoQuyetDinh { get; set; }
            public DateTime NgayQuyetDinh { get; set; }
            public string employee_id { get; set; }
            public string Ten { get; set; }
            public string old_department_id { get; set; }
            public string DonViCu { get; set; }
            public int old_work_id { get; set; }
            public string ChucVuCu { get; set; }
            public string new_department_id { get; set; }
            public string DonViMoi { get; set; }
            public int new_work_id { get; set; }
            public string ChucVuMoi { get; set; }
            public string ThangLuong { get; set; }
            public double? PhuCap { get; set; }
            public string BacLuongMoi { get; set; }
            public string MucLuongMoi { get; set; }
            public string BacLuongCu { get; set; }
            public double? MucLuongCu { get; set; }
            public string transfer_reason { get; set; }
            public int? new_salary_id { get; set; }
            public int? old_salary_id { get; set; }
        }

        public class RecentQuyetDinhNhanVien
        {
            public string employee_id { get; set; }
            public DateTime NgayQuyetDinhGanNhat { get; set; }
        }

    }
}