using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.TCLD
{
    public class RecruitmentController : Controller
    {
        // GET: Recruitment
        [Auther(RightID = "52")]
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien")]
        [HttpGet]
        public ActionResult Index()
        {
        
            return View("/Views/TCLD/Recruitment/Input.cshtml");
        }
        Boolean checkNull = true;
        
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien")]
        [HttpPost]
        public ActionResult Add(string jsonname,string soqd,string ngayqd)
        {
            if (jsonname.Equals("{\"data\":[]}"))
            {
                return Json(new { message = "Nodata" }, JsonRequestBehavior.AllowGet);
            }
            QuangHanhManufacturingEntities DBcontext = new QuangHanhManufacturingEntities();
            JObject input = JObject.Parse(jsonname);
            JArray vattu = (JArray)input["data"];
              
            using (DbContextTransaction transaction = DBcontext.Database.BeginTransaction())
            {

                try
                {
                    checkNull = true;
                    if (checkQD(soqd) == false)
                    {
                        return Json(new { message = "MaQD" }, JsonRequestBehavior.AllowGet);
                    }
                    QuyetDinh qd = new QuyetDinh();
                    qd.SoQuyetDinh = soqd;
                    DateTime dayQD = convertDate(ngayqd);
                    if (checkDate(dayQD) == false)
                    {
                        return Json(new { message = "NgayQD" }, JsonRequestBehavior.AllowGet);
                    }
                    qd.NgayQuyetDinh = dayQD;
                    DBcontext.QuyetDinhs.Add(qd);
                    DBcontext.SaveChanges();
                    int maQD = qd.MaQuyetDinh;
                    foreach (var item in vattu)
                    {
                        string id = (string)item["0"];
                        string names = (string)item["1"];
                        string dob = (string)item["2"];
                        string gender = (string)item["3"];
                        string unit = (string)item["4"];
                        string level = (string)item["5"];
                        string specialized = (string)item["6"];
                        string working = (string)item["7"];
                        string place = (string)item["8"];
                        string salary = (string)item["9"];
                        string leveWork = (string)item["10"];
                        string salaryMonth = (string)item["11"];
                        string phone = (string)item["12"];
                        string cmt = (string)item["13"];
                        string dateOfIssue = (string)item["14"];
                        string placeOfIssue = (string)item["15"];
                        string nation = (string)item["16"];
                        string father = (string)item["17"];
                        string mother = (string)item["18"];
                        string wife = (string)item["19"];
                        TuyenDung_NhanVien tdnv = new TuyenDung_NhanVien();
                        tdnv.MaQuyetDinh = maQD;
                        tdnv.MaNV = id;
                        tdnv.NgayTuyenDung = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        DBcontext.TuyenDung_NhanVien.Add(tdnv);
                        //add tabel nhanvien
                        ThangLuong thangLuong = null;
                        if(salary.Trim() != "")
                        {
                            if (checkSalry(salary) == false)
                            {
                                transaction.Rollback();
                                return Json(new { message = "SalaryFaile", responseText = id }, JsonRequestBehavior.AllowGet);
                            }

                            else
                            {
                                thangLuong = DBcontext.ThangLuongs.Where(x => x.MucThangLuong.Equals(salary)).FirstOrDefault<ThangLuong>();
                            }
                        }
                      
                        NhanVien emp = new NhanVien();
                        emp.MaNV = id;
                        emp.Ten = names;
                        if (dob.Trim() != "") {
                            emp.NgaySinh = convertDOB(dob);

                            if (emp.NgaySinh.HasValue ? checkDate(emp.NgaySinh.Value) == false : false)
                            {
                                transaction.Rollback();
                                return Json(new { message = "NgaySinh", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        if(checkGender(gender) == true)
                        {
                            if (gender.Equals("Nam"))
                            {
                                emp.GioiTinh = true;
                            }
                            else
                            {
                                emp.GioiTinh = false;
                            }
                        }
                        else
                        {
                            transaction.Rollback();
                            return Json(new { message = "gender", responseText = id }, JsonRequestBehavior.AllowGet);
                        }
                        
                        if (dateOfIssue.Trim() != "")
                        {
                            emp.NgayCapCMND = convertDOB(dateOfIssue);

                            if (emp.NgayCapCMND.HasValue ? checkDate(emp.NgayCapCMND.Value) == false : false)
                            {
                                transaction.Rollback();
                                return Json(new { message = "NgayCap", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        BacLuong bacLuong = null;
                        bacLuong = DBcontext.BacLuongs.Where(x => x.MucBacLuong.Equals(leveWork)).FirstOrDefault<BacLuong>();
                        if(bacLuong == null)
                        {
                            transaction.Rollback();
                            return Json(new { message = "bacluong", responseText = id }, JsonRequestBehavior.AllowGet);
                        }

                        
                       
                        emp.SoDienThoai = phone;
                        emp.SoCMND = cmt;
                        emp.NoiCapCMND = placeOfIssue;
                        emp.DanToc = nation;
                        if (unit.Trim() != "")
                        {
                            emp.MaPhongBan = unit;
                            if (getPhongBan(unit) == null)
                            {
                                transaction.Rollback();
                                return Json(new { message = "DonVi", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                emp.MaPhongBan = getPhongBan(unit).department_id;
                            }
                        }
                        //trinh do
                        if (level.Trim() != "")
                        {
                            if (getMaTrinhDo(level) == -1)
                            {
                                transaction.Rollback();
                                return Json(new { message = "TrinhDo", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                emp.MaTrinhDo = getMaTrinhDo(level);
                            }
                        }
                        QuanHeGiaDinh fatherRela = new QuanHeGiaDinh();
                        fatherRela.MaNV = id;
                        fatherRela.MoiQuanHe = "Bố";
                        fatherRela.HoTen = father;
                        DBcontext.QuanHeGiaDinhs.Add(fatherRela);

                        QuanHeGiaDinh motherRela = new QuanHeGiaDinh();
                        motherRela.MaNV = id;
                        motherRela.MoiQuanHe = "Mẹ";
                        motherRela.HoTen = mother;
                        DBcontext.QuanHeGiaDinhs.Add(motherRela);

                        QuanHeGiaDinh wifeRela = new QuanHeGiaDinh();
                        wifeRela.MaNV = id;
                        wifeRela.MoiQuanHe = "Vợ";
                        wifeRela.HoTen = wife;
                        DBcontext.QuanHeGiaDinhs.Add(wifeRela);

                        emp.NoiOHienTai = place;
                        if (working.Trim() != "") {
                            emp.MaCongViec = getMaCongViec(thangLuong, working);
                            if (emp.MaCongViec == -1) {
                                transaction.Rollback();
                                return Json(new { message = "CongViec", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        if (specialized.Trim() != "") {
                            emp.MaChuyenNganh = getMaChuyenNganh(specialized);
                            if (emp.MaChuyenNganh.Equals("-1")) {
                                transaction.Rollback();
                                return Json(new { message = "ChuyenNganh", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                        }

                        BacLuong_ThangLuong_MucLuong bacLuong_ThangLuong_MucLuong = null;
                        bacLuong_ThangLuong_MucLuong = DBcontext.BacLuong_ThangLuong_MucLuong.Where(x => 
                        x.MaBacLuong == bacLuong.MaBacLuong && x.MaThangLuong == thangLuong.MaThangLuong 
                        ).FirstOrDefault<BacLuong_ThangLuong_MucLuong>();
                        if(bacLuong_ThangLuong_MucLuong == null)
                        {
                            transaction.Rollback();
                            return Json(new { message = "bacLuong_ThangLuong", responseText = id }, JsonRequestBehavior.AllowGet);
                        }

                        if(bacLuong_ThangLuong_MucLuong == null)
                        {
                            transaction.Rollback();
                            return Json(new { message = "SalaryFailed", responseText = id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            emp.MaBacLuong_ThangLuong_MucLuong = bacLuong_ThangLuong_MucLuong.MaBacLuong_ThangLuong_MucLuong;
                        }
                        emp.MaTrangThai = 1;
                        DBcontext.NhanViens.Add(emp);
                        HoSo document = new HoSo();
                        document.MaNV = id;
                        DBcontext.HoSoes.Add(document);
                    }
                    DBcontext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { message = "RollBack" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Redirect("/phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien");
        }
        public Boolean checkQD(string soqd)
        {
            if (soqd.Trim().Equals("")) return false;
            QuyetDinh quyetdinh = null;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                quyetdinh = db.QuyetDinhs.Where(x => x.SoQuyetDinh.Equals(soqd)).FirstOrDefault<QuyetDinh>();
            }
            if (quyetdinh == null)
            {
                return true;
            }
            return false;
        }
        public Boolean checkDate(DateTime date)
        {
            DateTime check = DateTime.Parse("1/1/0001");
            if (date.Equals(check) == true)
            {
                return false;
            }
            return true;
        }
        public Boolean checkSalry(string salaryInput) {
          
                ThangLuong salary = null;
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    salary = db.ThangLuongs.Where(x => x.MucThangLuong.Equals(salaryInput)).FirstOrDefault<ThangLuong>();
                }
            if(salary == null)
            {
                return false;
            }
            return true;
        }
        public Department getPhongBan(string unit)
        {

            Department dep = null;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                dep = db.Departments.Where(x => x.department_name.ToLower().Trim().Equals(unit.ToLower().Trim())).FirstOrDefault<Department>();
            }
            return dep;
        }
        public string convertSalary(string salary)
        {
            if(salary != null)
            {
                salary = salary.Replace("\r\n", "").Replace(",", "");
                return salary.Trim();
            }
            else
            {
                checkNull = false;
                return "0";
            }
        }
        public string getMaDonVi(string nameDonvi)
        {
            try
            {
                Department dep = null;
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    dep = db.Departments.Where(x => x.department_name.ToLower().Trim().Equals(nameDonvi.ToLower().Trim())).FirstOrDefault<Department>();
                }
                return dep.department_id;
            }
            catch (NullReferenceException )
            {
                checkNull = false;
                return "-1";
            }
           
        }
        public string getMaChuyenNganh(string tenChuyenNganh)
        {
            //try
            //{
                ChuyenNganh specialized = null;
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                specialized = db.ChuyenNganhs.Where(x => x.TenChuyenNganh.Replace("\r\n",String.Empty).ToLower().Trim().Equals(tenChuyenNganh.ToLower().Trim())).FirstOrDefault<ChuyenNganh>();
                }
                
            if (specialized == null) {
                return "-1";
            }
            else
            {
                return specialized.MaChuyenNganh;
            }
            //}
            //catch (NullReferenceException )
            //{
            //    checkNull = false;
            //    return "-1";
            //}

        }
        public int getMaTrinhDo(string tenTrinhDo)
        {
            TrinhDo level = null;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                level = db.TrinhDoes.Where(x => x.TenTrinhDo.Replace("\r\n",string.Empty).ToLower().Trim().Equals(tenTrinhDo.ToLower().Trim())).FirstOrDefault<TrinhDo>();
            }
            if(level != null)
            {
                return level.MaTrinhDo;
            }
            else
            {
                return -1;
            }
              
                     
        }
        public int getMaCongViec(ThangLuong thangLuong,string working)
        {
         
            CongViec congViec = null;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                congViec = db.CongViecs.Where(x => (x.TenCongViec.ToLower().Trim().Equals(working.ToLower().Trim()) && x.MaThangLuong == thangLuong.MaThangLuong)).FirstOrDefault<CongViec>();
            }
            if(congViec != null)
            {
                return congViec.MaCongViec;
            }
            else
            {
                checkNull = false;
                return -1;
            }
        }
        public DateTime convertDate(string date)
        {
          
            string dateStr = "";
            try
            {
                if (date.Trim() != null)
                {
                    string[] dateSplit = date.Trim().Split(' ');

                    if (dateSplit[0].Length == 2 && dateSplit[2].Length == 2)
                    {
                        dateStr = dateSplit[3] + "-" + dateSplit[2] + "-" + dateSplit[0];
                    }
                    else if (dateSplit[0].Length == 1 && dateSplit[2].Length == 2)
                    {
                        dateStr = dateSplit[3] + "-" + dateSplit[2] + "-0" + dateSplit[0];
                    }
                    else if (dateSplit[0].Length == 2 && dateSplit[2].Length == 1)
                    {
                        dateStr = dateSplit[3] + "-0" + dateSplit[2] + "-" + dateSplit[0];
                    }
                    else if (dateSplit[0].Length == 1 && dateSplit[2].Length == 1)
                    {
                        dateStr = dateSplit[3] + "-0" + dateSplit[2] + "-0" + dateSplit[0];
                    }
                }
                string dateConvert = DateTime.ParseExact(dateStr, "yyyy-MM-dd", null).ToString("yyyy-MM-dd");
                return DateTime.Parse(dateConvert);
            }
            catch (FormatException)
            {
                return DateTime.Parse("1-1-0001");
            }
          
        }
        public DateTime convertDOB(string date)
        {
            string dateStr = "";
            try
            {
                if (date.Trim() != null)
                {
                    string[] dateSplit = date.Trim().Split('/');

                    if (dateSplit[0].Length == 2 && dateSplit[1].Length == 2)
                    {
                        dateStr = dateSplit[2] + "-" + dateSplit[1] + "-" + dateSplit[0];
                    }
                    else if (dateSplit[0].Length != 2 && dateSplit[1].Length == 2)
                    {
                        dateStr = dateSplit[2] + "-" + dateSplit[1] + "-0" + dateSplit[0];
                    }
                    else if (dateSplit[0].Length == 2 && dateSplit[1].Length != 2)
                    {
                        dateStr = dateSplit[2] + "-0" + dateSplit[1] + "-" + dateSplit[0];
                    }
                    else if (dateSplit[0].Length != 2 && dateSplit[1].Length != 2)
                    {
                        dateStr = dateSplit[2] + "-0" + dateSplit[1] + "-0" + dateSplit[0];
                    }
                }
                string dateConvert = DateTime.ParseExact(dateStr, "yyyy-MM-dd", null).ToString("yyyy-MM-dd");
                return DateTime.Parse(dateConvert);
            }
            catch (FormatException)
            {
                return DateTime.Parse("1-1-0001");
            }
        }
        public Boolean checkGender(string gender)
        {
            if(!gender.ToLower().Equals("nam") && !gender.ToLower().Equals("nữ"))
            {
                return false;
            }
            return true;
        }

        [Auther(RightID = "52")]
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien-import-excel")]
        [HttpPost]
        public ActionResult getExcel()
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];

                List<TuyenDungModel> list = new List<TuyenDungModel>();
                string path = HostingEnvironment.MapPath("/excel/TCLD/TuyenDung/UploadContainer");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (file.ContentLength > 0)
                {
                    file.SaveAs(HostingEnvironment.MapPath("/excel/TCLD/TuyenDung/UploadContainer/temp.xlsx"));
                    FileInfo process_file = new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/TuyenDung/UploadContainer/temp.xlsx"));

                    using (ExcelPackage package = new ExcelPackage(process_file))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault();
                        int totalRows = workSheet.Dimension.Rows;
                        totalRows = totalRows > 50 ? 50 : totalRows;
                        ////check valid cell
                        //for (int i = 7; i <= totalRows; i++)
                        //{
                        //    for (int j = 3; j <= 19; j++)
                        //    {
                        //        string value = workSheet.Cells[i, j].Value == null ? "0" : workSheet.Cells[i, j].Value.ToString();
                        //        if (!cellIsValid(value))
                        //        {
                        //            return Json(new { success = false, message = "Dữ liệu không hợp lệ (Ô "+"["+i+","+j+"]"+")" });
                        //        }
                        //    }
                        //}
                        //Check Exel
                        Boolean checkExel = true;
                        if (!workSheet.Cells[4, 2].Value.ToString().Equals("Số thẻ")) checkExel = false;
                        if (!workSheet.Cells[4, 3].Value.ToString().Equals("Họ và tên")) checkExel = false;
                        if (!workSheet.Cells[4, 4].Value.ToString().Equals("Ngày sinh")) checkExel = false;
                        if (!workSheet.Cells[4, 5].Value.ToString().Equals("Giới tính")) checkExel = false;
                        if (!workSheet.Cells[4, 6].Value.ToString().Equals("Đơn vị")) checkExel = false;
                        if (!workSheet.Cells[4, 7].Value.ToString().Equals("Trình độ")) checkExel = false;
                        if (!workSheet.Cells[4, 8].Value.ToString().Equals("Chuyên Nghành")) checkExel = false;
                        if (!workSheet.Cells[4, 9].Value.ToString().Equals("Công việc bố trí")) checkExel = false;
                        if (!workSheet.Cells[4, 10].Value.ToString().Equals("Thường trú")) checkExel = false;
                        if (!workSheet.Cells[4, 11].Value.ToString().Equals("Thang lương")) checkExel = false;
                        if (!workSheet.Cells[4, 12].Value.ToString().Equals("Bậc")) checkExel = false;
                        if (!workSheet.Cells[4, 13].Value.ToString().Equals("Mức lương (đồng/ tháng)")) checkExel = false;
                        if (!workSheet.Cells[4, 14].Value.ToString().Equals("SĐT")) checkExel = false;
                        if (!workSheet.Cells[4, 15].Value.ToString().Equals("CMT")) checkExel = false;
                        if (!workSheet.Cells[4, 16].Value.ToString().Equals("Ngày cấp CMT")) checkExel = false;
                        if (!workSheet.Cells[4, 17].Value.ToString().Equals("Nơi cấp")) checkExel = false;
                        if (!workSheet.Cells[4, 18].Value.ToString().Equals("Dân tộc")) checkExel = false;
                        if (!workSheet.Cells[4, 19].Value.ToString().Equals("Bố")) checkExel = false;
                        if (!workSheet.Cells[4, 20].Value.ToString().Equals("Mẹ")) checkExel = false;
                        if (!workSheet.Cells[4, 21].Value.ToString().Equals("Vợ")) checkExel = false;
                        if (!workSheet.Cells[3, 5].Value.ToString().Equals("Ngày")) checkExel = false;
                        if (!workSheet.Cells[3, 7].Value.ToString().Equals("Tháng")) checkExel = false;
                        if (!workSheet.Cells[3, 9].Value.ToString().Equals("Năm")) checkExel = false;
                        if (!workSheet.Cells[2, 1].Value.ToString().Equals("Kèm theo Quyết Định Số :")) checkExel = false;
                        if (!workSheet.Cells[2, 9].Value.ToString().Equals("/QĐ-VQHC")) checkExel = false;
                        if (checkExel == false)
                        {
                            return Json(new { success = true, message = "Excel" });
                        }


                        //Get excel value:
                        for (int i = 5; i <= totalRows; i++)
                        {
                            TuyenDungModel a = new TuyenDungModel();
                            a.SoThe = workSheet.Cells[i, 2].Value == null ? "" : workSheet.Cells[i, 2].Value.ToString();
                            a.HoTen = workSheet.Cells[i, 3].Value == null ? "" : workSheet.Cells[i, 3].Value.ToString();
                            a.NgaySinh = workSheet.Cells[i, 4].Value == null ? "" : workSheet.Cells[i, 4].Value.ToString();
                            a.GioiTinh = workSheet.Cells[i, 5].Value == null ? "" : workSheet.Cells[i, 5].Value.ToString();                            
                            a.DonVi = workSheet.Cells[i, 6].Value == null ? "" : workSheet.Cells[i, 6].Value.ToString();
                            a.TrinhDo = workSheet.Cells[i, 7].Value == null ? "" : workSheet.Cells[i, 7].Value.ToString();
                            a.ChuyenNganh = workSheet.Cells[i, 8].Value == null ? "" : workSheet.Cells[i, 8].Value.ToString();
                            a.CongViec = workSheet.Cells[i, 9].Value == null ? "" : workSheet.Cells[i, 9].Value.ToString();
                            a.ThuongTru = workSheet.Cells[i, 10].Value == null ? "" : workSheet.Cells[i, 10].Value.ToString();
                            a.ThangLuong = workSheet.Cells[i, 11].Value == null ? "" : workSheet.Cells[i, 11].Value.ToString();
                            a.Bac = workSheet.Cells[i, 12].Value == null ? "" : workSheet.Cells[i, 12].Value.ToString();
                            a.MucLuong = workSheet.Cells[i, 13].Value == null ? "" : workSheet.Cells[i, 13].Value.ToString();
                            a.SDT = workSheet.Cells[i, 14].Value == null ? "" : workSheet.Cells[i, 14].Value.ToString();
                            a.CMT = workSheet.Cells[i, 15].Value == null ? "" : workSheet.Cells[i, 15].Value.ToString();
                            a.NgayCap = workSheet.Cells[i, 16].Value == null ? "" : workSheet.Cells[i, 16].Value.ToString();
                            a.NoiCap = workSheet.Cells[i, 17].Value == null ? "" : workSheet.Cells[i, 17].Value.ToString();
                            a.DanToc = workSheet.Cells[i, 18].Value == null ? "" : workSheet.Cells[i, 18].Value.ToString();
                            a.Bo = workSheet.Cells[i, 19].Value == null ? "" : workSheet.Cells[i, 19].Value.ToString();
                            a.Me = workSheet.Cells[i, 20].Value == null ? "" : workSheet.Cells[i, 20].Value.ToString();
                            a.Vo = workSheet.Cells[i, 21].Value == null ? "" : workSheet.Cells[i, 21].Value.ToString();
                            a.ngay = workSheet.Cells[3, 6].Value == null ? "" : workSheet.Cells[3, 6].Value.ToString();
                            a.thang = workSheet.Cells[3, 8].Value == null ? "" : workSheet.Cells[3, 8].Value.ToString();
                            a.nam = workSheet.Cells[3, 10].Value == null ? "" : workSheet.Cells[3, 10].Value.ToString();
                            a.soqd = workSheet.Cells[2, 8].Value == null ? "" : workSheet.Cells[2, 8].Value.ToString();
                            list.Add(a);
                        }
                    }
                }
                return Json(new { success = true, list });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        public class TuyenDungModel
        {
            public string SoThe { get; set; }
            public string HoTen { get; set; }
            public string NgaySinh { get; set; }
            public string GioiTinh { get; set; }
            public string SDT { get; set; }
            public string CMT { get; set; }
            public string NgayCap { get; set; }
            public string NoiCap { get; set; }
            public string DanToc { get; set; }
            public string Bo { get; set; }
            public string Me { get; set; }
            public string Vo { get; set; }
        
            public string DonVi { get; set; }
            public string TrinhDo { get; set; }
            public string ChuyenNganh { get; set; }
            public string CongViec { get; set; }
            public string ThuongTru { get; set; }
            public string ThangLuong { get; set; }
            public string Bac { get; set; }
            public string MucLuong { get; set; }
            public string ngay { get; set; }
            public string thang { get; set; }
            public string nam { get; set; }

            public string soqd { get; set; }
        }
    }
}