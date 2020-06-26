using OfficeOpenXml;
using QUANGHANH2.Models;
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
    public class TieuhaoController : Controller
    {
        private readonly ITieuhaoRepository _repository;
        public QUANGHANHABCEntities context = new QUANGHANHABCEntities();
        public TieuhaoController(ITieuhaoRepository repo)
        {
            _repository = repo;
        }

        [Auther(RightID = "29")]
        [Route("phong-cdvt/vat-tu/tieu-hao")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/Tieuhao.cshtml");
        }

        [HttpPost]
        [Route("phong-cdvt/vat-tu/tieu-hao/details")]
        public ActionResult Details(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName, string type, string month, string year)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            var search = new Detail
            {
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim(),
                DepartmentId = DepartmentId.Trim(),
                DeparmentName = DeparmentName.Trim(),
                type = type.Trim(),
                month = month.Trim(),
                year = year.Trim()
            };
            var details = new List<DataTieuHao>();
            var val = month.Split(' ');
            int recordsTotal=0;
            if (search.type == null || search.type == "month")
            {
                details = context.Database.SqlQuery<DataTieuHao>(GetDetails(search) + "  order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                                                                            new SqlParameter("month", val[1]),
                                                                            new SqlParameter("year", val[2]),
                                                                            new SqlParameter("supplyid", "%" + search.SupplyId + "%"),
                                                                            new SqlParameter("departid", "%" + search.DepartmentId + "%"),
                                                                            new SqlParameter("supplyname", "%" + search.SupplyName + "%"),
                                                                            new SqlParameter("departname", "%" + search.DeparmentName + "%")).ToList();
                recordsTotal = month_detail_count(SupplyId, SupplyName, DepartmentId, DeparmentName, month);
            }

           if(type == "year") {
                details = context.Database.SqlQuery<DataTieuHao>(GetDetails(search) + "  order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                                                                        
                                                                           new SqlParameter("year", year),
                                                                           new SqlParameter("supplyid", "%" + search.SupplyId + "%"),
                                                                           new SqlParameter("departid", "%" + search.DepartmentId + "%"),
                                                                           new SqlParameter("supplyname", "%" + search.SupplyName + "%"),
                                                                           new SqlParameter("departname", "%" + search.DeparmentName + "%")).ToList();
                recordsTotal = year_detail_count(SupplyId, SupplyName, DepartmentId, DeparmentName, year);
            }
            int recordsFiltered = recordsTotal;
        
            return Json(new
            {
                success = true,
                data = details,
                recordsTotal,
                recordsFiltered
            }, JsonRequestBehavior.AllowGet);
        }
        public string GetDetails(Detail search)
        {
     
            string sql="";
            if(search.type == null || search.type == "month")
            {
               sql = @"select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 
(case when a.department_name is null then b.department_name else a.department_name end) 'DepartmentName', 
(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',
(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, es.department_id, d.department_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id
inner join Department d on es.department_id = d.department_id
and MONTH(es.[date]) = @month AND YEAR(es.[date]) = @year
group by s.supply_id, es.department_id, s.supply_name, d.department_name, s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name, mc.departmentid, d.department_name, s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid
inner join Department d on d.department_id = mc.departmentid
and MONTH(mc.[date]) = @month AND YEAR(mc.[date]) = @year
group by s.supply_id, mc.departmentid, s.supply_name, d.department_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
and MONTH(fac.[date]) = @month AND YEAR(fac.[date]) = @year 
inner join Department d on d.department_id = fac.department_id
group by s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit
) as a 
full outer join 
(select sp.supplyid, s.supply_name, sp.departmentid, d.department_name, sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id
where MONTH(sp.[date]) = @month and year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name, sp.departmentid, d.department_name, s.unit
) as b
on a.department_id = b.departmentid and a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) and (b.departmentid like @departid  or a.department_id like @departid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) and (b.department_name like @departname  or a.department_name like @departname )
group by a.supply_id, a.department_id, b.supplyid,b.quantity, b.departmentid, a.supply_name, b.supply_name,
a.department_name, b.department_name, a.unit, b.unit,b.quantity_provide"; 

              
            }
            if(search.type == "year")
            {
               sql = @"select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 
(case when a.department_name is null then b.department_name else a.department_name end) 'DepartmentName', 
(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',

(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, es.department_id, d.department_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id
inner join Department d on es.department_id = d.department_id
 AND YEAR(es.[date]) = @year
group by s.supply_id, es.department_id, s.supply_name, d.department_name, s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name, mc.departmentid, d.department_name, s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid
inner join Department d on d.department_id = mc.departmentid
 AND YEAR(mc.[date]) = @year
group by s.supply_id, mc.departmentid, s.supply_name, d.department_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
 AND YEAR(fac.[date]) = @year 
inner join Department d on d.department_id = fac.department_id
group by s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit

) as a 
full outer join 
(select sp.supplyid, s.supply_name, sp.departmentid, d.department_name, sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id
where  year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name, sp.departmentid, d.department_name, s.unit
) as b
on a.department_id = b.departmentid and a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) and (b.departmentid like @departid  or a.department_id like @departid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) and (b.department_name like @departname  or a.department_name like @departname )
group by a.supply_id, a.department_id, b.supplyid,b.quantity, b.departmentid, a.supply_name, b.supply_name,
a.department_name, b.department_name, a.unit, b.unit,b.quantity_provide
";
              
            }
            return sql;
        }

        public string GetSummary(Summary search)
        { string sql ="";
           
            if(search.type == null || search.type == "month")
            {
                 sql = @" select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 

(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',

(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id

and MONTH(es.[date]) = @month AND YEAR(es.[date]) = @year
group by s.supply_id, s.supply_name,  s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name,  s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid

and MONTH(mc.[date]) = @month AND YEAR(mc.[date]) = @year
group by s.supply_id,  s.supply_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name, s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
and MONTH(fac.[date]) = @month AND YEAR(fac.[date]) = @year 

group by s.supply_id, s.supply_name,  s.unit

) as a 
full outer join 
(select sp.supplyid, s.supply_name, sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid 
where MONTH(sp.[date]) = @month and year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name, s.unit
) as b
on  a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) 
group by a.supply_id, b.supplyid,b.quantity,  a.supply_name, b.supply_name,
 a.unit, b.unit,b.quantity_provide";
 
             
            }
            if (search.type == "year")
            {
                sql = @"select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 

(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',

(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id

 AND YEAR(es.[date]) = @year
group by s.supply_id, s.supply_name,s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name,s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid

 AND YEAR(mc.[date]) = @year
group by s.supply_id,  s.supply_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name,  s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
 AND YEAR(fac.[date]) = @year 

group by s.supply_id, s.supply_name,  s.unit

) as a 
full outer join 
(select sp.supplyid, s.supply_name,  sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id
where  year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name,  s.unit
) as b
on  a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) 
group by a.supply_id, b.supplyid,b.quantity, a.supply_name, b.supply_name,
 a.unit, b.unit,b.quantity_provide";
 
            
            }
            return sql;
        }

        [Auther(RightID = "29")]
        [HttpGet]
        [Route("phong-cdvt/vat-tu/tieu-hao/summary")]
        public ActionResult Summary(string SupplyId, string SupplyName, string type, string month, string year)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            var search = new Summary
            {
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim(),
                type = type.Trim(),
                month = month.Trim(),
                year = year.Trim()
            };
            var val = month.Split(' ');
            var details = new List<DataTieuHao>();

            int recordsTotal = 0;
            if (search.type == null || search.type == "month") {
                details = context.Database.SqlQuery<DataTieuHao>(GetSummary(search) + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                                                                            new SqlParameter("month", val[1]),
                                                                            new SqlParameter("year", val[2]),
                                                                            new SqlParameter("supplyid", "%" + search.SupplyId + "%"),

                                                                            new SqlParameter("supplyname", "%" + search.SupplyName + "%")

                                                                            ).ToList();
                recordsTotal = month_summary_count(SupplyId, SupplyName, month); }

            if (type == "year")
            {
                details = context.Database.SqlQuery<DataTieuHao>(GetSummary(search) + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                                                                   
                                                                            new SqlParameter("year", year),
                                                                            new SqlParameter("supplyid", "%" + search.SupplyId + "%"),

                                                                            new SqlParameter("supplyname", "%" + search.SupplyName + "%")

                                                                            ).ToList();
                recordsTotal = year_summary_count(SupplyId, SupplyName, year);
            } 
     
            int recordsFiltered = recordsTotal;
           
            //// calc SupplyInventory
            ////foreach (var detail in details)
            ////{
            ////    detail.SupplyInventory = detail.SupplyQuantity - detail.SupplyUsed;
            ////}
            return Json(new
            {
                success = true,
                data = details,
                recordsTotal,
                recordsFiltered
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Route("phong-cdvt/vat-tu/tieu-hao/export")]
        public ActionResult Export(string SupplyId, string SupplyName, string type, string month, string year)
        {
            try
            {
                var val = month.Split(' ');
                var details = new List<DataTieuHao>();
                string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
                string templateFilename = "tieu-hao-vat-tu-tong-hop.xlsx";
                string downloadFilename = "tieu-hao-vat-tu-tong-hop-download.xlsx";
                FileInfo file = new FileInfo(path + templateFilename);
                using (ExcelPackage workbook = new ExcelPackage(file))
                {
                    int index = 2;
                    ExcelWorkbook excelWorkbook = workbook.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                    var search = new Summary
                    {
                        SupplyId = SupplyId.Trim(),
                        SupplyName = SupplyName.Trim(),
                        type = type.Trim(),
                        month = month.Trim(),
                        year = year.Trim()
                    };

                    if (search.type == null || search.type == "month")
                    {
                        details = context.Database.SqlQuery<DataTieuHao>(GetSummary(search),
                                                                                    new SqlParameter("month", val[1]),
                                                                                    new SqlParameter("year", val[2]),
                                                                                    new SqlParameter("supplyid", "%" + search.SupplyId + "%"),

                                                                                    new SqlParameter("supplyname", "%" + search.SupplyName + "%")

                                                                                    ).ToList();
                      
                    }

                    if (type == "year")
                    {
                        details = context.Database.SqlQuery<DataTieuHao>(GetSummary(search),

                                                                                    new SqlParameter("year", year),
                                                                                    new SqlParameter("supplyid", "%" + search.SupplyId + "%"),

                                                                                    new SqlParameter("supplyname", "%" + search.SupplyName + "%")

                                                                                    ).ToList();
                        
                    }
               foreach (   var vattu in details)
                    {
                        excelWorksheet.Cells[index, 1].Value = vattu.SupplyId;
                        excelWorksheet.Cells[index, 2].Value = vattu.SupplyName;
                        excelWorksheet.Cells[index, 3].Value = vattu.SupplyProvide;
                        excelWorksheet.Cells[index, 4].Value = vattu.SupplyQuantity;
                        excelWorksheet.Cells[index, 5].Value = vattu.SupplyUnit;
                        excelWorksheet.Cells[index, 6].Value = vattu.SupplyUsed;
                        excelWorksheet.Cells[index, 7].Value = vattu.SupplyEviction;
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
        [Route("phong-cdvt/vat-tu/tieu-hao/download")]
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

        
        [HttpPost]
        [Route("phong-cdvt/vat-tu/tieu-hao/exportdetail")]
        public ActionResult ExportDetail(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName, string type, string month, string year)
        {
            try
            {
                var val = month.Split(' ');
                var details = new List<DataTieuHao>();
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
                string templateFilename = "tieu-hao-vat-tu-chi-tiet.xlsx";
                string downloadFilename = "tieu-hao-vat-tu-chi-tiet-download.xlsx";
                FileInfo file = new FileInfo(path + templateFilename);
                
                var search = new Detail
                {
                    SupplyId = SupplyId.Trim(),
                    SupplyName = SupplyName.Trim(),
                    DepartmentId = DepartmentId.Trim(),
                    DeparmentName = DeparmentName.Trim(),
                    type = type.Trim(),
                    month = month.Trim(),
                    year = year.Trim()
                };
                if (search.type == null || search.type == "month")
                {
                    details = context.Database.SqlQuery<DataTieuHao>(GetDetails(search),
                                                                                new SqlParameter("month", val[1]),
                                                                                new SqlParameter("year", val[2]),
                                                                                new SqlParameter("supplyid", "%" + search.SupplyId + "%"),
                                                                                new SqlParameter("departid", "%" + search.DepartmentId + "%"),
                                                                                new SqlParameter("supplyname", "%" + search.SupplyName + "%"),
                                                                                new SqlParameter("departname", "%" + search.DeparmentName + "%")).ToList();
                   
                }

                if (type == "year")
                {
                    details = context.Database.SqlQuery<DataTieuHao>(GetDetails(search),

                                                                               new SqlParameter("year", year),
                                                                               new SqlParameter("supplyid", "%" + search.SupplyId + "%"),
                                                                               new SqlParameter("departid", "%" + search.DepartmentId + "%"),
                                                                               new SqlParameter("supplyname", "%" + search.SupplyName + "%"),
                                                                               new SqlParameter("departname", "%" + search.DeparmentName + "%")).ToList();
                  
                }
                using (ExcelPackage workbook = new ExcelPackage(file))
                {
                    int index = 2;
                    ExcelWorkbook excelWorkbook = workbook.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                    foreach (var vattu in details)
                    {

                        excelWorksheet.Cells[index, 1].Value = vattu.SupplyId;
                        excelWorksheet.Cells[index, 2].Value = vattu.SupplyName;
                        excelWorksheet.Cells[index, 3].Value = vattu.DepartmentName;
                        excelWorksheet.Cells[index, 4].Value = vattu.SupplyProvide;
                        excelWorksheet.Cells[index, 5].Value = vattu.SupplyQuantity;
                        excelWorksheet.Cells[index, 6].Value = vattu.SupplyUnit;
                        excelWorksheet.Cells[index, 7].Value = vattu.SupplyUsed;
                        excelWorksheet.Cells[index, 8].Value = vattu.SupplyEviction;


                        
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
        [Route("phong-cdvt/vat-tu/tieu-hao/downloaddetail")]
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
        [Route("phong-cdvt/vat-tu/tieu-hao/getsupplydetail")]
        [HttpPost]
        public JsonResult getMaintainCar(string supplyid,string departmentname, string type, string month, string year)
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())

            {
                var val = month.Split(' ');
                var vattudetail = new List<Vattu>();

                if (type == null || type == "month")
                {
                    Department dep = db.Departments.Where(x => x.department_name == departmentname).First();
                    String sql = @"select 
esd.used,esd.thuhoi, es.[date], N'Sửa chữa thường xuyên' as 'purposed'
from Supply s inner
join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid and s.supply_id = @supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id
inner join Department d on es.department_id = d.department_id where es.department_id = @departmentid
and MONTH(es.[date]) = @month AND YEAR(es.[date]) = @year
group by s.supply_id, es.department_id, es.[date], s.supply_name, d.department_name, s.unit,esd.used,esd.thuhoi
union all
select
used,thuhoi, mc.[date], N'Bảo dưỡng hàng ngày' as 'purposed'
from Supply s inner
join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid and s.supply_id = @supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid
inner join Department d on d.department_id = mc.departmentid where mc.departmentid = @departmentid
and MONTH(mc.[date]) = @month AND YEAR(mc.[date]) = @year
group by s.supply_id, mc.departmentid, mc.[date],used,thuhoi
union all
select
sum(fac.consumption_value) 'used',
0 'thuhoi', fac.[date], N'Tiêu hao nhiên liệu' as 'purposed'
from Supply s inner
join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type and s.supply_id = @supplyid inner join Equipment e on fac.equipmentId = e.equipmentId
and MONTH(fac.[date]) = @month AND YEAR(fac.[date]) = @year
inner join Department d on d.department_id = e.department_id where e.department_id = @departmentid
group by s.supply_id, d.department_id, fac.[date]";
                    //Truncate Table to delete all old records.
                   vattudetail = db.Database.SqlQuery<Vattu>(sql, new SqlParameter("supplyid", supplyid), new SqlParameter("departmentid", dep.department_id),
                        new SqlParameter("month", val[1]), new SqlParameter("year", val[2])).ToList();
                    foreach(var item in vattudetail)
                    {
                        item.stringDate = item.date.ToString("dd/MM/yyyy");
                    }
                }
                if (type == "year")

                {
                    Department dep = db.Departments.Where(x => x.department_name == departmentname).First();
                    String sql = @"select 
esd.used,esd.thuhoi, es.[date], N'Sửa chữa thường xuyên' as 'purposed'
from Supply s inner
join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid and s.supply_id = @supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id
inner join Department d on es.department_id = d.department_id where es.department_id = @departmentid
 AND YEAR(es.[date]) = @year
group by s.supply_id, es.department_id, es.[date], s.supply_name, d.department_name, s.unit,esd.used,esd.thuhoi
union all
select
used,thuhoi, mc.[date], N'Bảo dưỡng hàng ngày' as 'purposed'
from Supply s inner
join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid and s.supply_id = @supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid
inner join Department d on d.department_id = mc.departmentid where mc.departmentid = @departmentid
 AND YEAR(mc.[date]) = @year
group by s.supply_id, mc.departmentid, mc.[date],used,thuhoi
union all
select
sum(fac.consumption_value) 'used',
0 'thuhoi', fac.[date], N'Tiêu hao nhiên liệu' as 'purposed'
from Supply s inner
join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type and s.supply_id = @supplyid inner join Equipment e on fac.equipmentId = e.equipmentId
 AND YEAR(fac.[date]) = @year
inner join Department d on d.department_id = e.department_id where e.department_id = @departmentid
group by s.supply_id, d.department_id, fac.[date]";
                    //Truncate Table to delete all old records.
                  vattudetail = db.Database.SqlQuery<Vattu>(sql, new SqlParameter("supplyid", supplyid), new SqlParameter("departmentid", dep.department_id),
                       new SqlParameter("month", month), new SqlParameter("year", year)).ToList();
                    foreach (var item in vattudetail)
                    {
                        item.stringDate = item.date.ToString("dd/MM/yyyy");
                    }
                }

                return Json(vattudetail);
            }
        }
        [HttpPost]
        public ActionResult ChangeID(string id, string ck)
        {
            string sql = "";
            if (ck.Equals("0"))
            {
                sql = @"select supply_name as SupplyId from Supply where supply_name like @id";
            }
            else if (ck.Equals("1"))
            {
                sql = @"select supply_id as SupplyId from Supply where supply_id like @id ";
            }
            else if (ck.Equals("2"))
            {
                sql = @"select department_id as SupplyId from Department where department_id like @id";
            }
            else if (ck.Equals("3"))
            {
                sql = @"select department_name as SupplyId from Department where department_name like @id";
            }
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<SupplySearch> list = db.Database.SqlQuery<SupplySearch>(sql, new SqlParameter("id", "%" + id + "%")).Take(10).ToList();
            return Json(new { success = true, id = list }, JsonRequestBehavior.AllowGet);
        }
        private int month_detail_count(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName,  string month)
        {
            var val = month.Split(' ');
            //find old supplies by device.
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            int recordsTotal = db.Database.SqlQuery<int>(@" select count (t.SupplyId) from  (select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 
(case when a.department_name is null then b.department_name else a.department_name end) 'DepartmentName', 
(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',
(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, es.department_id, d.department_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id
inner join Department d on es.department_id = d.department_id
and MONTH(es.[date]) = @month AND YEAR(es.[date]) = @year
group by s.supply_id, es.department_id, s.supply_name, d.department_name, s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name, mc.departmentid, d.department_name, s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid
inner join Department d on d.department_id = mc.departmentid
and MONTH(mc.[date]) = @month AND YEAR(mc.[date]) = @year
group by s.supply_id, mc.departmentid, s.supply_name, d.department_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
and MONTH(fac.[date]) = @month AND YEAR(fac.[date]) = @year 
inner join Department d on d.department_id = fac.department_id
group by s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit
) as a 
full outer join 
(select sp.supplyid, s.supply_name, sp.departmentid, d.department_name, sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id
where MONTH(sp.[date]) = @month and year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name, sp.departmentid, d.department_name, s.unit
) as b
on a.department_id = b.departmentid and a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) and (b.departmentid like @departid  or a.department_id like @departid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) and (b.department_name like @departname  or a.department_name like @departname )
group by a.supply_id, a.department_id, b.supplyid,b.quantity, b.departmentid, a.supply_name, b.supply_name,
a.department_name, b.department_name, a.unit, b.unit,b.quantity_provide ) as t", 
                                                                            new SqlParameter("month", val[1]),
                                                                            new SqlParameter("year", val[2]),
                                                                            new SqlParameter("supplyid", "%" + SupplyId + "%"),
                                                                            new SqlParameter("departid", "%" + DepartmentId + "%"),
                                                                            new SqlParameter("supplyname", "%" + SupplyName + "%"),
                                                                            new SqlParameter("departname", "%" + DeparmentName + "%")).FirstOrDefault();


            return recordsTotal;
        }
private int year_detail_count(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName, string year)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        int recordsTotal = db.Database.SqlQuery<int>(@" select count(SupplyId) from(select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 
(case when a.department_name is null then b.department_name else a.department_name end) 'DepartmentName', 
(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',

(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, es.department_id, d.department_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id
inner join Department d on es.department_id = d.department_id
 AND YEAR(es.[date]) = @year
group by s.supply_id, es.department_id, s.supply_name, d.department_name, s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name, mc.departmentid, d.department_name, s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid
inner join Department d on d.department_id = mc.departmentid
 AND YEAR(mc.[date]) = @year
group by s.supply_id, mc.departmentid, s.supply_name, d.department_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
 AND YEAR(fac.[date]) = @year 
inner join Department d on d.department_id = fac.department_id
group by s.supply_id, s.supply_name, fac.department_id, d.department_name, s.unit

) as a 
full outer join 
(select sp.supplyid, s.supply_name, sp.departmentid, d.department_name, sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id
where  year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name, sp.departmentid, d.department_name, s.unit
) as b
on a.department_id = b.departmentid and a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) and (b.departmentid like @departid  or a.department_id like @departid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) and (b.department_name like @departname  or a.department_name like @departname )
group by a.supply_id, a.department_id, b.supplyid,b.quantity, b.departmentid, a.supply_name, b.supply_name,
a.department_name, b.department_name, a.unit, b.unit,b.quantity_provide) as t", new SqlParameter("year", year),
                                                                            new SqlParameter("supplyid", "%" + SupplyId + "%"),
                                                                            new SqlParameter("departid", "%" + DepartmentId + "%"),
                                                                            new SqlParameter("supplyname", "%" + SupplyName + "%"),
                                                                            new SqlParameter("departname", "%" + DeparmentName + "%")).FirstOrDefault();


            return recordsTotal;

        }
        private int month_summary_count(string SupplyId,string SupplyName,string month)
        {
            var val = month.Split(' ');
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            int recordsTotal = db.Database.SqlQuery<int>(@" select count(SupplyId) from(select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 

(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',

(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id

and MONTH(es.[date]) = @month AND YEAR(es.[date]) = @year
group by s.supply_id, s.supply_name,  s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name,  s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid

and MONTH(mc.[date]) = @month AND YEAR(mc.[date]) = @year
group by s.supply_id,  s.supply_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name, s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
and MONTH(fac.[date]) = @month AND YEAR(fac.[date]) = @year 

group by s.supply_id, s.supply_name,  s.unit

) as a 
full outer join 
(select sp.supplyid, s.supply_name, sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid 
where MONTH(sp.[date]) = @month and year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name, s.unit
) as b
on  a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) 
group by a.supply_id, b.supplyid,b.quantity,  a.supply_name, b.supply_name,
 a.unit, b.unit,b.quantity_provide) as t", new SqlParameter("month", val[1]),
                                                                            new SqlParameter("year", val[2]),
                                                                            new SqlParameter("supplyid", "%" + SupplyId + "%"),

                                                                            new SqlParameter("supplyname", "%" + SupplyName + "%")).FirstOrDefault();


            return recordsTotal;

        }
        private int year_summary_count(string SupplyId, string SupplyName, string year)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            int recordsTotal = db.Database.SqlQuery<int>(@" select count(SupplyId) from(select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
(case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 

(case when b.quantity_provide is null then 0 else b.quantity_provide end) 'SupplyProvide',
(case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity',

(case when a.unit is null then b.unit else a.unit end) 'SupplyUnit',
sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction'
from
(select s.supply_id, s.supply_name, s.unit,
esd.used,esd.thuhoi
from Supply s inner join Equipment_SCTX_Detail esd
on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id

 AND YEAR(es.[date]) = @year
group by s.supply_id, s.supply_name,s.unit,esd.used,esd.thuhoi
union all
select s.supply_id, s.supply_name,s.unit,
mcd.used,mcd.thuhoi
from Supply s inner join Maintain_Car_Detail mcd
on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid

 AND YEAR(mc.[date]) = @year
group by s.supply_id,  s.supply_name, s.unit,mcd.used,mcd.thuhoi
union all
select s.supply_id, s.supply_name,  s.unit,
sum(fac.consumption_value) 'used',
0 'thuhoi'
from Supply s inner join Fuel_activities_consumption fac
on s.supply_id = fac.fuel_type 
 AND YEAR(fac.[date]) = @year 

group by s.supply_id, s.supply_name,  s.unit

) as a 
full outer join 
(select sp.supplyid, s.supply_name,  sum(sp.quantity) 'quantity',sum(sp.quantity_provide) 'quantity_provide', s.unit
from Supply s inner join SupplyPlan sp
on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id
where  year(sp.[date]) = @year and sp.departmentid != 'CV'
group by  sp.supplyid, s.supply_name,  s.unit
) as b
on  a.supply_id = b.supplyid 
where (a.supply_id like @supplyid or b.supplyid  like @supplyid ) 
and (a.supply_name like @supplyname  or b.supply_name like @supplyname ) 
group by a.supply_id, b.supplyid,b.quantity, a.supply_name, b.supply_name,
 a.unit, b.unit,b.quantity_provide) as t", new SqlParameter("year", year),
                                                                           new SqlParameter("supplyid", "%" + SupplyId + "%"),

                                                                           new SqlParameter("supplyname", "%" + SupplyName + "%")).FirstOrDefault();


            return recordsTotal;

        }
    }
    public class Detail
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string DepartmentId { get; set; }

        public string DeparmentName { get; set; }
        public string type { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }

    public class Vattu
    {
        public int used { get; set; }
        public int thuhoi { get; set; }
        public string purposed { get; set; }
        public string stringDate { get; set; }
        public DateTime date { get; set; }
        
    }
    public class SupplySearch
    {
        public string SupplyId { get; set; }
    }
    public class Summary
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        
        public string type { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
    public class DataTieuHao
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string DepartmentName { get; set; }
        public int SupplyProvide { get; set; }

        public int SupplyQuantity { get; set; }
        public string SupplyUnit { get; set; }
        public int SupplyUsed { get; set; }
        public int SupplyEviction { get; set; }

    }
   
}