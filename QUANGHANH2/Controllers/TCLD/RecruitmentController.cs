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
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien")]
        [HttpGet]
        public ActionResult Index()
        {
        
            return View("/Views/TCLD/Recruitment/Input.cshtml");
        }
        Boolean checkNull = true;
        [Auther(RightID = "52")]
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien")]
        [HttpPost]
        public ActionResult Add(string jsonname,string soqd,string ngayqd)
        {
            if (jsonname.Equals("{\"data\":[]}"))
            {
                return Json(new { message = "Nodata" }, JsonRequestBehavior.AllowGet);
            }
            QUANGHANHABCEntities DBcontext = new QUANGHANHABCEntities();
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
                        string kind = (string)item["5"];
                        string level = (string)item["6"];
                        string specialized = (string)item["7"];
                        string working = (string)item["8"];
                        string place = (string)item["9"];
                        string salary = (string)item["10"];
                        string leveWork = (string)item["11"];
                        string salaryMonth = (string)item["12"];
                        TuyenDung_NhanVien tdnv = new TuyenDung_NhanVien();
                        tdnv.MaQuyetDinh = maQD;
                        tdnv.MaNV = id;
                        tdnv.NgayTuyenDung = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        DBcontext.TuyenDung_NhanVien.Add(tdnv);
                        //add tabel nhanvien
                        if(checkSalry(salary) == false)
                        {
                            transaction.Rollback();
                            return Json(new { message = "SalaryFaile" , responseText = id}, JsonRequestBehavior.AllowGet);
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
                        emp.LoaiNhanVien = kind;
                        emp.BacLuong = leveWork;
                        if(gender.Equals("nam"))
                        {
                            emp.GioiTinh = true;
                        }
                        else
                        {
                            emp.GioiTinh = false;
                        }
                        if (checkPhongBan(unit) == true) {
                            transaction.Rollback();
                            return Json(new { message = "DonVi", responseText = id }, JsonRequestBehavior.AllowGet);
                        }
                        emp.MaPhongBan = unit;
                        emp.NoiOHienTai = place;
                        if (working != null) {
                            emp.MaCongViec = getMaCongViec(salary, working);
                            if (emp.MaCongViec == -1) {
                                transaction.Rollback();
                                return Json(new { message = "CongViec", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        if (specialized != null) {
                            emp.MaChuyenNganh = getMaChuyenNganh(specialized);
                            if (emp.MaChuyenNganh.Equals("-1")) {
                                transaction.Rollback();
                                return Json(new { message = "ChuyenNganh", responseText = id }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        emp.MucLuong = convertSalary(salaryMonth);
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

            QuyetDinh quyetdinh = null;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
          
                CongViec salary = null;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    salary = db.CongViecs.Where(x => x.ThangLuong.Equals(salaryInput)).FirstOrDefault<CongViec>();
                }
            if(salary == null)
            {
                return false;
            }
            return true;
        }
        public Boolean checkPhongBan(string phongban)
        {

            Department dep = null;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                dep = db.Departments.Where(x => x.department_id.Equals(phongban)).FirstOrDefault<Department>();
            }
            if (dep == null)
            {
                return true;
            }
            return false;
        }
        public double convertSalary(string salary)
        {
            if(salary != null)
            {
                salary = salary.Replace(".", string.Empty);
                return Double.Parse(salary);
            }
            else
            {
                checkNull = false;
                return 0;
            }
            
            
        }
        public string getMaDonVi(string nameDonvi)
        {
            try
            {
                Department dep = null;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    dep = db.Departments.Where(x => x.department_name.Equals(nameDonvi)).FirstOrDefault<Department>();
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
            try
            {
                ChuyenNganh specialized = null;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    specialized = db.ChuyenNganhs.Where(x => x.TenChuyenNganh.ToLower().Equals(tenChuyenNganh.ToLower())).FirstOrDefault<ChuyenNganh>();
                }
                return specialized.MaChuyenNganh;
            }
            catch (NullReferenceException )
            {
                checkNull = false;
                return "-1";
            }

        }
        public int getMaTrinhDo(string tenTrinhDo)
        {
            try
            {
                TrinhDo level = null;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    level = db.TrinhDoes.Where(x => x.TenTrinhDo.Equals(tenTrinhDo)).FirstOrDefault<TrinhDo>();
                }
                return level.MaTrinhDo;
            }
            catch(NullReferenceException )
            {
                checkNull = false;
                return -1;
            }
            
        }
        public int getMaCongViec(string thangLuong,string tenCongViec)
        {
         
            CongViec working = null;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                working = db.CongViecs.Where(x => (x.TenCongViec.ToLower().Equals(tenCongViec.ToLower()))).FirstOrDefault<CongViec>();
            }
            if(working != null)
            {
                return working.MaCongViec;
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


        [Auther(RightID = "52")]
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien-import-excel")]
        [HttpPost]
        public ActionResult getExcel()
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
                    if (!workSheet.Cells[4, 5].Value.ToString().Equals("Đơn vị")) checkExel = false;
                    if (!workSheet.Cells[4, 6].Value.ToString().Equals("Trình độ")) checkExel = false;
                    if (!workSheet.Cells[4, 7].Value.ToString().Equals("Chuyên Nghành")) checkExel = false;
                    if (!workSheet.Cells[4, 8].Value.ToString().Equals("Công việc bố trí")) checkExel = false;
                    if (!workSheet.Cells[4, 9].Value.ToString().Equals("Thường trú")) checkExel = false;
                    if (!workSheet.Cells[4, 10].Value.ToString().Equals("Thang lương")) checkExel = false;
                    if (!workSheet.Cells[4, 11].Value.ToString().Equals("Bậc")) checkExel = false;
                    if (!workSheet.Cells[4, 12].Value.ToString().Equals("Mức lương (đồng/ tháng)")) checkExel = false;
                    if (!workSheet.Cells[3, 5].Value.ToString().Equals("Ngày")) checkExel = false;
                    if (!workSheet.Cells[3, 7].Value.ToString().Equals("Tháng")) checkExel = false;
                    if (!workSheet.Cells[3, 9].Value.ToString().Equals("Năm")) checkExel = false;
                    if (!workSheet.Cells[2, 1].Value.ToString().Equals("Kèm theo Quyết Định Số :")) checkExel = false;
                    if (!workSheet.Cells[2, 9].Value.ToString().Equals("/QĐ-VQHC")) checkExel = false;
                    if(checkExel == false)
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
                        a.DonVi = workSheet.Cells[i, 5].Value == null ? "" : workSheet.Cells[i, 5].Value.ToString();
                        a.TrinhDo = workSheet.Cells[i, 6].Value == null ? "" : workSheet.Cells[i, 6].Value.ToString();
                        a.ChuyenNganh = workSheet.Cells[i, 7].Value == null ? "" : workSheet.Cells[i, 7].Value.ToString();
                        a.CongViec = workSheet.Cells[i, 8].Value == null ? "" : workSheet.Cells[i, 8].Value.ToString();
                        a.ThuongTru = workSheet.Cells[i, 9].Value == null ? "" : workSheet.Cells[i, 9].Value.ToString();
                        a.ThangLuong = workSheet.Cells[i, 10].Value == null ? "" : workSheet.Cells[i, 10].Value.ToString();
                        a.Bac = workSheet.Cells[i, 11].Value == null ? "" : workSheet.Cells[i, 11].Value.ToString();
                        a.MucLuong = workSheet.Cells[i, 12].Value == null ? "" : workSheet.Cells[i, 12].Value.ToString();
                        a.ngay = workSheet.Cells[3,6].Value == null ? "" : workSheet.Cells[3, 6].Value.ToString();
                        a.thang = workSheet.Cells[3, 8].Value == null ? "" : workSheet.Cells[3, 8].Value.ToString();
                        a.nam = workSheet.Cells[3, 10].Value == null ? "" : workSheet.Cells[3, 10].Value.ToString();
                        a.soqd = workSheet.Cells[2, 8].Value == null ? "" : workSheet.Cells[2, 8].Value.ToString();
                        list.Add(a);
                    }
                }
            }
            return Json(new { success = true, list });
        }

        public class TuyenDungModel
        {
            public string SoThe { get; set; }
            public string HoTen { get; set; }
            public string NgaySinh { get; set; }
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