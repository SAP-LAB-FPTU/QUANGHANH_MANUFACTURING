using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using OfficeOpenXml;

namespace QUANGHANH_MANUFACTURING.Controllers.DK.EquipmentIncident
{
    public class ReportController : Controller
    {
        //[Auther(RightID = "19")]
        [Route("phong-dieu-khien/su-co/bao-cao")]
        public ActionResult Index()
        {
            var type = new[] { "month", "quarter", "year" }.Contains(Request["type"]) ? Request["type"] : "month";
            int year = Request["year"] == null ? DateTime.Now.Year : int.Parse(Request["year"]);
            var sql = @"select d.department_id, department_name, (case when total is null then 0 else total end) as total, (case when diff is null then 0 else diff end) as diff
                        from Department d left join
	                        (select
		                        department_id, COUNT(*) as total, SUM(DATEDIFF(SECOND, start_time, end_time)) as diff
		                        from Incident where year(start_time) = " + year;
            switch (type)
            {
                case "month":
                    int month = Request["month"] == null ? DateTime.Now.Month : int.Parse(Request["month"]);
                    sql += " and month(start_time) = " + month;
                    break;
                case "quarter":
                    int quarter = Request["quarter"] == null ? 1 : int.Parse(Request["quarter"]);
                    sql += " and month(start_time) between " + (quarter * 3 - 2) + " and " + (quarter * 3);
                    break;
                default:
                    break;
            }
            sql += @" group by department_id
	                        ) as i on d.department_id = i.department_id
                        where d.department_type like N'%phân xưởng%'";
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var list = db.Database.SqlQuery<Report>(sql).ToList();
                ViewBag.list = list;
                ViewBag.total = list.Sum(x => x.total);
            }
            return View("/Views/DK/EquipmentIncident/Report.cshtml");
        }

        //[Auther(RightID = "19")]
        [Route("phong-dieu-khien/su-co/bao-cao")]
        [HttpPost]
        public ActionResult Detail()
        {
            try
            {
                var type = new[] { "month", "quarter", "year" }.Contains(Request["type"]) ? Request["type"] : "month";
                int year = (Request["year"] == null || Request["year"] == "") ? DateTime.Now.Year : int.Parse(Request["year"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sql = @"select e.equipmentId, e.equipment_name, SUM(DATEDIFF(SECOND, start_time, end_time)) as diff
                        from Incident i inner join Equipment e on i.equipmentId = e.equipmentId
                        where i.department_id = @department_id and YEAR(i.start_time) = " + year;
                    switch (type)
                    {
                        case "month":
                            int month = (Request["month"] == null || Request["month"] == "") ? DateTime.Now.Month : int.Parse(Request["month"]);
                            sql += " and month(start_time) = " + month;
                            break;
                        case "quarter":
                            int quarter = (Request["quarter"] == null || Request["quarter"] == "") ? 1 : int.Parse(Request["quarter"]);
                            sql += " and month(start_time) between " + (quarter * 3 - 2) + " and " + (quarter * 3);
                            break;
                        default:
                            break;
                    }
                    sql += @" group by e.equipmentId, e.equipment_name";
                    var list = db.Database.SqlQuery<SubReport>(sql, new SqlParameter("department_id", Request["department_id"])).ToList();
                    foreach (var item in list)
                    {
                        TimeSpan timespan = TimeSpan.FromSeconds(item.diff);
                        string output = "";
                        if (timespan.Days != 0) output += timespan.Days + " ngày ";
                        if (timespan.Hours != 0) output += timespan.Hours + " giờ ";
                        if (timespan.Minutes != 0) output += timespan.Minutes + " phút ";
                        item.stringdiff = output;
                    }
                    return Json(new { success = true, data = list });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }

        [Route("phong-dieu-khien/su-co/bao-cao/excel")]
        public void Export()
        {
            string path = HostingEnvironment.MapPath("/excel/DK/SuCoThietBi.xlsx");
            string saveAsPath = ("/excel/DK/download/SuCoThietBi.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var type = new[] { "month", "quarter", "year" }.Contains(Request["type"]) ? Request["type"] : "month";
                    if (int.TryParse(Request["year"], out int year))
                        year = int.Parse(Request["year"]);
                    else
                        year = DateTime.Now.Year;

                    if (int.TryParse(Request["month"], out int month))
                        month = int.Parse(Request["month"]);
                    else
                        month = DateTime.Now.Month;

                    if (int.TryParse(Request["quarter"], out int quarter))
                        quarter = int.Parse(Request["quarter"]);
                    else
                        quarter = 1;

                    var sql = @"select d.department_id, department_name, (case when total is null then 0 else total end) as total, (case when diff is null then 0 else diff end) as diff
                        from Department d left join
	                        (select
		                        department_id, COUNT(*) as total, SUM(DATEDIFF(SECOND, start_time, end_time)) as diff
		                        from Incident where year(start_time) = " + year;
                    switch (type)
                    {
                        case "month":
                            sql += " and month(start_time) = " + month;
                            break;
                        case "quarter":
                            sql += " and month(start_time) between " + (quarter * 3 - 2) + " and " + (quarter * 3);
                            break;
                        default:
                            break;
                    }
                    sql += @" group by department_id
	                        ) as i on d.department_id = i.department_id
                        where d.department_type like N'%phân xưởng%'";
                    List<Report> content = db.Database.SqlQuery<Report>(sql).ToList();
                    for (int i = 3; i < content.Count + 3; i++)
                    {
                        excelWorksheet.Cells[i, 1].Value = content.ElementAt(i - 3).department_name;
                        excelWorksheet.Cells[i, 2].Value = content.ElementAt(i - 3).total;
                        excelWorksheet.Cells[i, 3].Value = content.ElementAt(i - 3).stringdiff();
                    }
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment; filename=LeadsExport.xlsx");
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.BinaryWrite(excelPackage.GetAsByteArray());
                    Response.End();
                    //excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            //return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }

        public class Report
        {
            public string department_id { get; set; }
            public string department_name { get; set; }
            public int total { get; set; }
            public int diff { get; set; }
            public string stringdiff()
            {
                TimeSpan timespan = TimeSpan.FromSeconds(diff);
                string output = "";
                if (timespan.Days != 0) output += timespan.Days + " ngày ";
                if (timespan.Hours != 0) output += timespan.Hours + " giờ ";
                if (timespan.Minutes != 0) output += timespan.Minutes + " phút ";
                return output;
            }
        }

        public class SubReport
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public int diff { get; set; }
            public string stringdiff { get; set; }
        }
    }
}