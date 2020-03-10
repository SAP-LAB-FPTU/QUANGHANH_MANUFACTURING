using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
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
        //[Route("phong-dieu-khien/bao-cao-tai-nan")]
        //public ActionResult Index()
        //{
        //    QUANGHANHABCEntities db = new QUANGHANHABCEntities();

        //    List<NhanVien> listNhanVien = db.NhanViens.ToList<NhanVien>();


        //    ViewBag.listNhanVien = listNhanVien;

        //    return View("/Views/DK/Acident.cshtml");
        //}
        [Route("phong-dieu-khien/danh-sach-tai-nan")]
        public ActionResult DanhSachBaoCao()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<NhanVien> listNhanVien = db.Database.SqlQuery<NhanVien>("select NhanVien.* from NhanVien inner join TrangThai" +
                    " on NhanVien.MaTrangThai = TrangThai.MaTrangThai where TrangThai.MaTrangThai=1 ").ToList();
            ViewBag.listNhanVien = listNhanVien;
            return View("/Views/DK/Accident/ListAccident.cshtml");
        }
        [Route("phong-dieu-khien/danh-sach-tai-nan/search-accident")]
        [HttpPost]
        public ActionResult SearchAccident(string employeeID, string EmployeeName, string timeFrom, string timeTo)
        {
            try
            {

                if (timeFrom.Trim() == "")
                {
                    timeFrom = "01/01/1900";
                }
                DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //validate timeTo when input blank
                DateTime timeT;
                if (timeTo.Trim() == "")
                {
                    timeT = DateTime.Now;
                }
                else
                {
                    timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    List<TaiNanDB> listTainan = (from tainan in db.TaiNans
                                                 join nhanvien in db.NhanViens on tainan.MaNV equals nhanvien.MaNV
                                                 join depart in db.Departments on nhanvien.MaPhongBan equals depart.department_id into output
                                                 from a in output.DefaultIfEmpty()
                                                 select new TaiNanDB
                                                 {
                                                     MaTaiNan = tainan.MaTaiNan,
                                                     MaNV = tainan.MaNV,
                                                     Ten = nhanvien.Ten,
                                                     department_name = a.department_name == null ? "" : a.department_name,
                                                     LyDo = tainan.LyDo,
                                                     Loai = tainan.Loai,
                                                     Ca_Name = tainan.Ca == 1 ? "CA 1" : tainan.Ca == 2 ? "CA 2" : "CA 3",
                                                     Ngay = tainan.Ngay

                                                 }
                                  ).Where(x => x.MaNV.Contains(employeeID) && x.Ten.Contains(EmployeeName) && x.Ngay >= timeF && x.Ngay <= timeT)
                                  .OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                    foreach (TaiNanDB item in listTainan)
                    {
                        item.stringDate = item.Ngay.Value.ToString("dd/MM/yyyy");
                    }
                    int totalrows = (from tainan in db.TaiNans
                                     join nhanvien in db.NhanViens on tainan.MaNV equals nhanvien.MaNV
                                     join depart in db.Departments on nhanvien.MaPhongBan equals depart.department_id into output
                                     from a in output.DefaultIfEmpty()
                                     select new TaiNanDB
                                     {
                                         MaTaiNan = tainan.MaTaiNan,
                                         MaNV = tainan.MaNV,
                                         Ten = nhanvien.Ten,
                                         department_name = a.department_name == null ? "" : a.department_name,
                                         LyDo = tainan.LyDo,
                                         Loai = tainan.Loai,
                                         Ca_Name = tainan.Ca == 1 ? "CA 1" : tainan.Ca == 2 ? "CA 2" : "CA 3",
                                         Ngay = tainan.Ngay

                                     }
                                  ).Where(x => x.MaNV.Contains(employeeID) && x.Ten.Contains(EmployeeName) && x.Ngay >= timeF && x.Ngay <= timeT).Count();
                    return Json(new { success = true, data = listTainan, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
        [Route("phong-dieu-khien/danh-sach-tai-nan/get-information")]
        [HttpPost]
        public ActionResult GetInformation()
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    List<TaiNanDB> listTainan = (from tainan in db.TaiNans
                                                 join nhanvien in db.NhanViens on tainan.MaNV equals nhanvien.MaNV
                                                 join depart in db.Departments on nhanvien.MaPhongBan equals depart.department_id
                                                 select new TaiNanDB
                                                 {
                                                     MaTaiNan = tainan.MaTaiNan,
                                                     MaNV = tainan.MaNV,
                                                     Ten = nhanvien.Ten,
                                                     department_name = depart.department_name,
                                                     LyDo = tainan.LyDo,
                                                     Ca_Name = tainan.Ca == 1 ? "CA 1" : tainan.Ca == 2 ? "CA 2" : "CA 3",
                                                     Ngay = tainan.Ngay,
                                                     Loai = tainan.Loai,
                                                     GhiChu = tainan.GhiChu
                                                 }
                                  ).ToList();

                    return Json(new { success = true, data = listTainan }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
        [Route("phong-dieu-khien/bao-cao-tai-nan/insertaccident")]
        [HttpPost]
        public ActionResult InsertMaintainCar(TaiNanDB accident)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //Truncate Table to delete all old records.
                //Check for NULL.
                try
                {
                    TaiNan t = new TaiNan();
                   

                    if (accident.MaNV == null || db.NhanViens.Find(accident.MaNV) == null)
                    {
                        transaction.Rollback();
                        Response.Write("Mã nhân viên không tồn tại");
                        return new HttpStatusCodeResult(400);
                    }
                    NhanVien nv = db.Database.SqlQuery<NhanVien>("select NhanVien.* from NhanVien inner join TrangThai" +
                 " on NhanVien.MaTrangThai = TrangThai.MaTrangThai where TrangThai.MaTrangThai=1 and MaNV=@MaNV", new SqlParameter("MaNV", accident.MaNV)).SingleOrDefault();
                    if (nv==null)
                    {
                        transaction.Rollback();
                        Response.Write("Nhân viên này đang trong trạng thái không đi làm ");
                        return new HttpStatusCodeResult(400);
                    }

                    t.MaNV = accident.MaNV;
                    t.LyDo = accident.LyDo;
                    t.Ca = accident.Ca;
                    t.Loai = accident.Loai;
                    string date = DateTime.ParseExact(accident.stringDate, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");

                    t.Ngay = DateTime.Parse(date);
                    db.TaiNans.Add(t);
                    db.SaveChanges();




                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Response.Write("Có lỗi xảy ra, vui lòng nhập lại");
                    return new HttpStatusCodeResult(400);
                }

            }

        }
        [Route("phong-dieu-khien/bao-cao-tai-nan/returnEmployeeName")]
        [HttpPost]
        public ActionResult returnEmployeename(String MaNV)
        {

            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                NhanVien nv = db.Database.SqlQuery<NhanVien>("select NhanVien.* from NhanVien inner join TrangThai" +
                    " on NhanVien.MaTrangThai = TrangThai.MaTrangThai where TrangThai.MaTrangThai=1 and MaNV=@MaNV", new SqlParameter("MaNV",MaNV)).SingleOrDefault();
                
                DepartmentDB d = db.Database.SqlQuery<DepartmentDB>("select department_name from Department where department_id=@departmentid ", new SqlParameter("departmentid", nv.MaPhongBan)).SingleOrDefault();
                
                //String item = equipment.supply_name + "^" + equipment.unit;
               
                return Json(new
                { 
                    Ten = nv.Ten,
                    department_name = d.department_name
                }, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception)
            {
                return Json(new
                {
                    Ten = "",
                    department_name = "Không xác định"
                   
                }, JsonRequestBehavior.AllowGet);
            }

        }
        [Route("phong-dieu-khien/bao-cao-tai-nan/getaccidentid")]
        [HttpPost]
        public ActionResult getAccidentID(int MaTaiNan)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();

                TaiNanDB tn = db.Database.SqlQuery<TaiNanDB>(
                   "select t.*,n.Ten,d.department_name from TaiNan t inner join  NhanVien n on t.MaNV = n.MaNV left join  Department d on  d.department_id = n.MaPhongBan "+
     " where  MaTaiNan = @MaTaiNan", new SqlParameter("MaTaiNan", MaTaiNan)
                    ).First();
                tn.stringDate = tn.Ngay.Value.ToString("dd/MM/yyyy");

                return Json(tn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-dieu-khien/bao-cao-tai-nan/editaccident")]
        [HttpPost]
        public ActionResult EditAccident(TaiNanDB tainandb)
        {
            TaiNan t = new TaiNan();
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {

                try
                {
                    NhanVien nv = DBContext.Database.SqlQuery<NhanVien>("select NhanVien.* from NhanVien inner join TrangThai" +
                   " on NhanVien.MaTrangThai = TrangThai.MaTrangThai where TrangThai.MaTrangThai=1 and MaNV=@MaNV", new SqlParameter("MaNV", tainandb.MaNV)).SingleOrDefault();
                    if (nv == null)
                    {
                        transaction.Rollback();
                        Response.Write("Nhân viên này đang trong trạng thái không đi làm");
                        return new HttpStatusCodeResult(400);
                    }

                    t.MaNV = tainandb.MaNV;
                    t.LyDo = tainandb.LyDo; 
                    t.Ngay = DateTime.ParseExact(tainandb.stringDate, "dd/MM/yyyy", null);
                    t.Loai = tainandb.Loai;
                    t.Ca = tainandb.Ca;
                    t.MaTaiNan = tainandb.MaTaiNan;

                    DBContext.Entry(t).State = EntityState.Modified;


                    DBContext.SaveChanges();

                    transaction.Commit();
                    return new HttpStatusCodeResult(201);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");

                    return new HttpStatusCodeResult(400);
                }
            }
        }
        [Route("phong-dieu-khien/bao-cao-tai-nan/deleteaccident")]
        [HttpPost]
        public ActionResult DeleteAccident(int MaTaiNan)
        {
            TaiNan t = new TaiNan();
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {

                try
                {

                    TaiNan d = DBContext.TaiNans.Where(x => x.MaTaiNan == MaTaiNan).First();
                    DBContext.TaiNans.Remove(d);

                    DBContext.SaveChanges();

                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();


                    return new HttpStatusCodeResult(400);
                }
            }
        }
        //[Auther(RightID = "35")]
        [HttpPost]
        [Route("phong-dieu-khien/bao-cao-tai-nan/export")]
        public ActionResult ExportDetail(List<TaiNanDB> accidentSummaries)
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/DK/");
                string templateFilename = "DanhSachTaiNan.xlsx";
                string downloadFilename = "DanhSachTaiNan-download.xlsx";
                FileInfo file = new FileInfo(path + templateFilename);
                using (ExcelPackage workbook = new ExcelPackage(file))
                {
                    int index = 2;
                    ExcelWorkbook excelWorkbook = workbook.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                    foreach (var acci in accidentSummaries)
                    {

                        excelWorksheet.Cells[index, 1].Value = acci.MaNV;
                        excelWorksheet.Cells[index, 2].Value = acci.Ten;
                        excelWorksheet.Cells[index, 3].Value = acci.department_name;
                        excelWorksheet.Cells[index, 4].Value = acci.LyDo;
                        excelWorksheet.Cells[index, 5].Value = acci.Loai;
                        excelWorksheet.Cells[index, 6].Value = acci.Ca_Name;
                        excelWorksheet.Cells[index, 7].Value = acci.stringDate;



                        index++;
                    }
                    workbook.SaveAs(new FileInfo(HostingEnvironment.MapPath($"/excel/DK/{downloadFilename}")));
                    string handle = Guid.NewGuid().ToString();
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        workbook.SaveAs(memoryStream);
                        memoryStream.Position = 0;
                        TempData[handle] = memoryStream.ToArray();
                    }
                    return Json(new
                    {
                        success = true,
                        data = new { FileGuid = handle, FileName = downloadFilename }
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        [Route("phong-dieu-khien/bao-cao-tai-nan/downloaddetail")]
        public virtual ActionResult DownloadDetail(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
            }
        }

        //[Route("phong-dieu-khien/hien-trang-lo")]
        //public ActionResult Index()
        //{
        //    return View("/Views/DK/HienTrangLo.cshtml");
        //}
        [Route("phong-dieu-khien/bao-cao-tai-nan/getinformation")]
        [HttpPost]
        public ActionResult GetData(String date)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var sqlQuery = " select department_name,GhiChu,MaCongTacAnToan,Ngay,MaPhongBan,LoaiGhiChu from CongTacAnToan,Department " +
                    "where CongTacAnToan.MaPhongBan=Department.department_id " +
                    "and CongTacAnToan.Ngay=@date";
                List<CongTacAnToanDB> m = db.Database.SqlQuery<CongTacAnToanDB>(sqlQuery, new SqlParameter("date", DateTime.ParseExact(date, "dd/MM/yyyy", null))).ToList();
                var listAspectDepartments = (from d in db.Departments
                                             select new
                                             {
                                                 department_id = d.department_id,
                                                 department_name = d.department_name
                                             }).ToList();
                return Json(new { data = m, aspects = listAspectDepartments }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("phong-dieu-khien/bao-cao-tai-nan/edit")]
        [HttpPost]
        public ActionResult AddOrEdit(List<CongTacAnToanDB> antoan)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            CongTacAnToan m = new CongTacAnToan();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //note:  thiếu data db cho supply id
                try
                {
                    //                
                    foreach (CongTacAnToanDB item in antoan)
                    {

                        if (item.MaCongTacAnToan == 0)
                        {

                            m.MaPhongBan = item.MaPhongBan;
                            m.Ngay = DateTime.ParseExact(item.stringDate, "dd/MM/yyyy", null);
                            m.GhiChu = item.GhiChu;
                            db.CongTacAnToans.Add(m);
                            db.SaveChanges();
                           
                        }
                        else 
                        {
                            CongTacAnToan c = db.CongTacAnToans.Where(x => x.MaCongTacAnToan == item.MaCongTacAnToan).First();
                            c.MaPhongBan = item.MaPhongBan;
                            c.Ngay = DateTime.ParseExact(item.stringDate, "dd/MM/yyyy", null);
                            c.GhiChu = item.GhiChu;
                            c.MaCongTacAnToan = item.MaCongTacAnToan;
                            db.Entry(c).State = EntityState.Modified;
                            db.SaveChanges();


                        }
                       
                    }
                   
                    transaction.Commit();

                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    string output = "";


                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }
    }
    public class TaiNanDB : TaiNan
    {
        public string stringDate { get; set; }
        public string Ten { get; set; }
        public string Ca_Name { get; set; }
        public string department_name { get; set; }
       
    }
    public class dsTainan
    {
        public int MaTaiNan { get; set; }
        public string MaNV { get; set; }

        public string LyDo { get; set; }
        public Nullable<int> Ca { get; set; }
        public Nullable<DateTime> Ngay { get; set; }
    }
    public class CongTacAnToanDB : CongTacAnToan
    {

        public string department_name { get; set; }

        public string stringDate { get; set; }
    }
    public class DepartmentDB : CongTacAnToan
    {

        public string department_name { get; set; }

       
    }
}