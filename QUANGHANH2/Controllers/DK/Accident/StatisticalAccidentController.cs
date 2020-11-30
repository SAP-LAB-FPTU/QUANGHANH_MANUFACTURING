using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.Accident
{
    public class StatisticalAccidentController : Controller
    {
        public QuangHanhManufacturingEntities context = new QuangHanhManufacturingEntities();

        [Route("phong-dieu-khien/thong-ke-tai-nan")]
        public ActionResult Index()
        {
            return View("/Views/DK/Accident/StatisticalAccident.cshtml");
        }
        [HttpPost]
        [Route("phong-dieu-khien/thong-ke-tai-nan/getinfor")]
        public ActionResult Details(string type, string month1, string quarter1, string year1, string month2, string quarter2, string year2, string quateryear1, string quateryear2, string DepartmentId, string loai)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            var search = new Detail
            {
                DepartmentId = DepartmentId.Trim(),
                type = type.Trim(),
                month1 = month1.Trim(),
                month2 = month2.Trim(),
                year1 = year1.Trim(),
                year2 = year2.Trim(),
                quarter1=quarter1.Trim(),
                quarter2=quarter2.Trim(),
                quarteryear1=quateryear1.Trim(),
                quarteryear2=quateryear2.Trim(),
                loai=loai.Trim(),
            };
            var details = GetDetails(search);
            int recordsTotal = details.Count;
            int recordsFiltered = details.Count;
            details = details.Skip(start).Take(length).ToList();
            return Json(new
            {
                success = true,
                data = details,
                recordsTotal,
                recordsFiltered
            }, JsonRequestBehavior.AllowGet);
        }

        public List<AccidentSummary> GetDetails(Detail search)
        { 
            var month1 = search.month1.Split(' ');
            
            var month2 = search.month2.Split(' ');
            if (search.type == null || search.type == "month")
            {
                string sql = @"select department_name ,Loai,count(loai) as number
                                from TaiNan inner join NhanVien on TaiNan.MaNV = NhanVien.MaNV
                                left join Department on Department.department_id = NhanVien.MaPhongBan
                                where (department_id like @departmentid or department_id is null) and Loai like @loai and DATEPART(year, ngay) +datepart(month, ngay) between @year1 + @month1 and @year2 + @month2
                                group by department_name,Loai";
                var details = context.Database.SqlQuery<AccidentSummary>(sql, new SqlParameter("loai", "%" + search.loai + "%"),
                                                                           new SqlParameter("month1", Int32.Parse(month1[1])),
                                                                           new SqlParameter("month2", Int32.Parse(month2[1])),
                                                                           
                                                                           new SqlParameter("departmentid", "%" + search.DepartmentId + "%"),
                                                                           new SqlParameter("year1", Int32.Parse(month1[2])),
                                                                           new SqlParameter("year2", Int32.Parse(month2[2]))
                                                                           ).ToList();
                return details;
            }
            if (search.type == "year")
            {
                string sql = @"select department_name,Loai,count(loai) as number
                                from TaiNan inner join NhanVien on TaiNan.MaNV = NhanVien.MaNV
                                left join Department on Department.department_id = NhanVien.MaPhongBan
                                where (department_id like @departmentid or department_id is null) and Loai like @loai and year(ngay) between @year1 and @year2
                                group by department_name,Loai";
                var details = context.Database.SqlQuery<AccidentSummary>(sql, new SqlParameter("loai", "%" + search.loai + "%"),
                                                                           new SqlParameter("departmentid", "%" + search.DepartmentId + "%"),
                                                                           new SqlParameter("year1", search.year1),
                                                                           new SqlParameter("year2", search.year2)
                                                                            ).ToList();
                return details;
            }
            if (search.type == "quarter")
            {
                string sql = @"select department_name,Loai,count(loai) as number
from TaiNan inner join NhanVien on TaiNan.MaNV = NhanVien.MaNV
left join Department on Department.department_id = NhanVien.MaPhongBan
where (department_id like @departmentid or department_id is null) and Loai like @loai and DATEPART(year, ngay) +datepart(quarter, ngay) between @year1 + @quarter1 and @year2 + @quarter2
group by department_name,Loai";
                var details = context.Database.SqlQuery<AccidentSummary>(sql, new SqlParameter("quarter1", Int32.Parse(search.quarter1)),
                                                                           new SqlParameter("quarter2", Int32.Parse(search.quarter2)),
                                                                           new SqlParameter("loai", "%" + search.loai + "%"),
                                                                           new SqlParameter("departmentid", "%" + search.DepartmentId + "%"),
                                                                           new SqlParameter("year1", Int32.Parse(search.quarteryear1)),
                                                                           new SqlParameter("year2", Int32.Parse(search.quarteryear2))
                                                                            ).ToList();

                return details;
            }
            return new List<AccidentSummary>();
        }
        [HttpPost]
        [Route("phong-dieu-khien/thong-ke-tai-nan/exportdetail")]
        public ActionResult ExportDetail(string type, string month1, string quarter1, string year1, string month2, string quarter2, string year2, string quateryear1, string quateryear2, string DepartmentId, string loai)
        {
            try
            {
                var search = new Detail
                {
                    DepartmentId = DepartmentId.Trim(),
                    type = type.Trim(),
                    month1 = month1.Trim(),
                    month2 = month2.Trim(),
                    year1 = year1.Trim(),
                    year2 = year2.Trim(),
                    quarter1 = quarter1.Trim(),
                    quarter2 = quarter2.Trim(),
                    quarteryear1 = quateryear1.Trim(),
                    quarteryear2 = quateryear2.Trim(),
                    loai = loai.Trim(),
                };
                var details = GetDetails(search);
                string path = HostingEnvironment.MapPath("/excel/DK/");
                string templateFilename = "Thong-ke-tai-nan.xlsx";
                string downloadFilename = "Thong-ke-tai-nan-download.xlsx";
                FileInfo file = new FileInfo(path + templateFilename);
                using (ExcelPackage workbook = new ExcelPackage(file))
                {
                    int index = 2;
                    ExcelWorkbook excelWorkbook = workbook.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                    foreach (var acci in details)
                    {

                        excelWorksheet.Cells[index, 1].Value = acci.department_name;
                        excelWorksheet.Cells[index, 2].Value = acci.Loai;
                        excelWorksheet.Cells[index, 3].Value = acci.number;
                       

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
        [Route("phong-dieu-khien/thong-ke-tai-nan/downloaddetail")]
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

    }
    public class Detail
    {
        public string type { get; set; }
        public string month1 { get; set; }
        public string month2 { get; set; }

        public string DepartmentId { get; set; }
        public string loai { get; set; }
        public string year1 { get; set; }
        public string year2 { get; set; }
        public string quarter1 { get; set; }
        public string quarter2 { get; set; }
        public string quarteryear1 { get; set; }
        public string quarteryear2 { get; set; }

    }
    public class AccidentSummary
    {
        public string department_name { get; set; }
        public string Loai { get; set; }
        public int number { get; set; }

       

    }
}