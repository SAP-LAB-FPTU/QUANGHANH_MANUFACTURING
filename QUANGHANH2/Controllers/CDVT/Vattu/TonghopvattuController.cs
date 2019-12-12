using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Vattu
{
    public class TonghopvattuController : Controller
    {

        private readonly ITonghopvattuRepository _repository;

        public TonghopvattuController(ITonghopvattuRepository repo)
        {
            _repository = repo;
        }

        [Auther(RightID = "28")]
        [Route("phong-cdvt/tong-hop-vat-tu")]
        public ActionResult Index()
        { using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<Supply> supply = db.Supplies.Take(10).ToList();
                ViewBag.supply = supply;

                return View("/Views/CDVT/Vattu/Tonghopvattu.cshtml");
            }
        }

        [HttpGet]
        [Route("phong-cdvt/tong-hop-vat-tu/details")]
        public ActionResult Details(string DepartmentId, string SupplyId, string SupplyName, string MonthPicked)
        {
            TonghopVattuSearchModelView search = new TonghopVattuSearchModelView
            {
                DepartmentId = DepartmentId.Trim(),
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim(),
                MonthPicked = MonthPicked.Trim()
            };
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            search.DepartmentId = string.IsNullOrWhiteSpace(search.DepartmentId) ? string.Empty : search.DepartmentId;
            search.MonthPicked = string.IsNullOrWhiteSpace(search.MonthPicked) ? DateTime.Now.ToString("dd/MM/yyyy") : search.MonthPicked;
            search.SupplyId = string.IsNullOrWhiteSpace(search.SupplyId) ? string.Empty : search.SupplyId;
            search.SupplyName = string.IsNullOrWhiteSpace(search.SupplyName) ? string.Empty : search.SupplyName;
            IList<TonghopvattuDetailModelView> details = _repository.GetDetails(search);
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

        [Route("phong-cdvt/tong-hop-vat-tu/departments")]
        public ActionResult Departments()
        {
            IList<TonghopvattuDepartmentModelView> departments = _repository.GetDepartments();
            return Json(new
            {
                success = true,
                data = departments,
            }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "28")]
        [HttpGet]
        [Route("phong-cdvt/tong-hop-vat-tu/summary")]
        public ActionResult Summary(string DepartmentId, string SupplyId, string SupplyName, string MonthPicked)
        {
            TonghopVattuSearchModelView search = new TonghopVattuSearchModelView
            {
                DepartmentId = DepartmentId.Trim(),
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim(),
                MonthPicked = MonthPicked.Trim()
            };
            search.DepartmentId = string.IsNullOrWhiteSpace(search.DepartmentId) ? string.Empty : search.DepartmentId;
            search.MonthPicked = string.IsNullOrWhiteSpace(search.MonthPicked) ? DateTime.Now.ToString("dd/MM/yyyy") : search.MonthPicked;
            search.SupplyId = string.IsNullOrWhiteSpace(search.SupplyId) ? string.Empty : search.SupplyId;
            search.SupplyName = string.IsNullOrWhiteSpace(search.SupplyName) ? string.Empty : search.SupplyName;
            IList<TonghopvattuSummaryModelView> details = _repository.GetSummary(search);
            return Json(new
            {
                success = true,
                data = details
            }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "28")]
        [HttpPost]
        [Route("phong-cdvt/tong-hop-vat-tu/export")]
        public ActionResult Export(List<TonghopvattuSummaryModelView> vattus)
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
                string templateFilename = "tong-hop-vat-tu.xlsx";
                string downloadFilename = "tong-hop-vat-tu-download.xlsx";
                FileInfo file = new FileInfo(path + templateFilename);
                using (ExcelPackage workbook = new ExcelPackage(file))
                {
                    int index = 2;
                    ExcelWorkbook excelWorkbook = workbook.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                    foreach (var vattu in vattus)
                    {
                        excelWorksheet.Cells[index, 1].Value = vattu.SupplyId;
                        excelWorksheet.Cells[index, 2].Value = vattu.SupplyName;
                        excelWorksheet.Cells[index, 3].Value = vattu.SupplyUnit;
                        excelWorksheet.Cells[index, 4].Value = vattu.SupplyQuantity;
                        excelWorksheet.Cells[index, 5].Value = vattu.EstimatePrice;
                        excelWorksheet.Cells[index, 6].Value = vattu.Note;
                        index++;
                    }
                    workbook.SaveAs(new FileInfo(HostingEnvironment.MapPath($"/excel/CDVT/download/{downloadFilename}")));
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
        [Route("phong-cdvt/tong-hop-vat-tu/download")]
        public virtual ActionResult Download(string fileGuid, string fileName)
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

        [Auther(RightID = "35")]
        [HttpPost]
        [Route("phong-cdvt/tong-hop-vat-tu/exportdetail")]
        public ActionResult ExportDetail (List<TonghopvattuSummaryModelView> vattus)
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
                string templateFilename = "tong-hop-vat-tu-chi-tiet.xlsx";
                string downloadFilename = "tong-hop-vat-tu-chi-tiet-download.xlsx";
                FileInfo file = new FileInfo(path + templateFilename);
                using (ExcelPackage workbook = new ExcelPackage(file))
                {
                    int index = 2;
                    ExcelWorkbook excelWorkbook = workbook.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                    foreach (var vattu in vattus)
                    {
                        
                        excelWorksheet.Cells[index, 1].Value = vattu.SupplyName;
                        excelWorksheet.Cells[index, 2].Value = vattu.SupplyUnit;
                        excelWorksheet.Cells[index, 3].Value = vattu.SupplyQuantity;
                      
                        index++;
                    }
                    workbook.SaveAs(new FileInfo(HostingEnvironment.MapPath($"/excel/CDVT/download/{downloadFilename}")));
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
        [Route("phong-cdvt/tong-hop-vat-tu/downloaddetail")]
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
    
    [Route("phong-cdvt/tong-hop-vat-tu/change")]
    [HttpPost]
    public ActionResult Change(string supply_name)
    {
        ViewBag.listsupply = null;
        QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        string sql = "select supply_name from Supply where supply_name like @supply_name";
        List<Supply> listsupply = db.Database.SqlQuery<Supply>(sql, new SqlParameter("supply_name", "%" + supply_name + "%")).Take(10).ToList();
        ViewBag.listsupply = listsupply;
        string d = "";
        foreach (var item in listsupply)
        {
            d += "<option value='" + item.supply_name + "'/>";
        }
        return Json(new { success = true, data = d }, JsonRequestBehavior.AllowGet);


    }
}
}
