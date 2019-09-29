using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;

namespace QUANGHANHCORE.Controllers.CDVT.Suco
{
    public class SucoThietbiController : Controller
    {
        [Route("phong-cdvt/su-co")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Suco/SucoThietbi.cshtml");
        }

        [Route("phong-cdvt/su-co/add")]
        [HttpPost]
        public ActionResult Add(string equipment, string department, string reason, string detail, int yearStart, int monthStart, int dayStart, int hourStart, int minuteStart, int yearEnd, int monthEnd, int dayEnd, int hourEnd, int minuteEnd, string checkBox)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            Incident i = new Incident();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Department d = DBContext.Database.SqlQuery<Department>("SELECT * FROM Department WHERE department_name = N'" + department + "'").First();
                    Equipment e = DBContext.Equipments.Find(equipment);
                    if(e.current_Status == 1)
                    {
                        transaction.Rollback();
                        Response.Write("Thiết bị đang có trạng thái hỏng\n không thể thêm sự cố");
                        return new HttpStatusCodeResult(400);
                    }
                    e.current_Status = 1;
                    i.department_id = d.department_id;
                    i.detail_location = detail;
                    i.equipmentId = equipment;
                    i.reason = reason;
                    i.start_time = new DateTime(yearStart, monthStart, dayStart, hourStart, minuteStart, 0);
                    i.end_time = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minuteEnd, 0);
                    if (checkBox == "yes")
                    {
                        i.reason = null;
                        i.end_time = null;
                    }

                    DBContext.Incidents.Add(i);
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return new HttpStatusCodeResult(201);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    string output = "";
                    if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipment + "'").Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";
                    if (DBContext.Database.SqlQuery<Department>("SELECT * FROM Department WHERE department_name = N'" + department + "'").Count() == 0)
                        output += "Phòng ban không tồn tại\n";
                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        [Route("phong-cdvt/su-co/edit")]
        [HttpPost]
        public ActionResult Edit(int incident_id, string equipment, string department, string reason, string detail, int yearStart, int monthStart, int dayStart, int hourStart, int minuteStart, int yearEnd, int monthEnd, int dayEnd, int hourEnd, int minuteEnd)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Incident i = DBContext.Incidents.Find(incident_id);
                    Department d = DBContext.Database.SqlQuery<Department>("SELECT * FROM Department WHERE department_name = N'" + department + "'").First();
                    i.department_id = d.department_id;
                    i.detail_location = detail;
                    i.equipmentId = equipment;
                    i.reason = reason;
                    i.start_time = new DateTime(yearStart, monthStart, dayStart, hourStart, minuteStart, 0);
                    i.end_time = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minuteEnd, 0);

                    DBContext.SaveChanges();
                    transaction.Commit();
                    return new HttpStatusCodeResult(201);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string output = "";
                    if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipment + "'").Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";
                    if (DBContext.Database.SqlQuery<Department>("SELECT * FROM Department WHERE department_name = N'" + department + "'").Count() == 0)
                        output += "Phòng ban không tồn tại\n";
                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        [Route("phong-cdvt/su-co/update")]
        [HttpPost]
        public ActionResult Update(int incident_id, string reason, int year, int month, int day, int hour, int minute)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            Incident i = DBContext.Incidents.Find(incident_id);
            if (i == null)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
            else
            {
                i.reason = reason;
                i.end_time = new DateTime(year, month, day, hour, minute, 0);
                DBContext.SaveChanges();
                return new HttpStatusCodeResult(201);
            }
        }

        [Route("phong-cdvt/su-co")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string department, string detail, string reason, string dateStart, string dateEnd)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query = "SELECT e.equipment_name, d.department_name, i.*, DATEDIFF(HOUR, i.start_time, i.end_time) as time_different FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                "on d.department_id = i.department_id where i.start_time BETWEEN @start_time1 AND @start_time2 AND ";
            if (!equipmentId.Equals("") || !equipmentName.Equals("") || !department.Equals("") || !detail.Equals("") || !reason.Equals(""))
            {
                if (!equipmentId.Equals("")) query += "i.equipmentId LIKE @equipmentId AND ";
                if (!equipmentName.Equals("")) query += "e.equipment_name LIKE @equipment_name AND ";
                if (!department.Equals("")) query += "d.department_name LIKE @department_name AND ";
                if (!detail.Equals("")) query += "i.detail_location LIKE @detail_location AND ";
                if (!reason.Equals("")) query += "i.reason LIKE @reason AND ";
            }
            query = query.Substring(0, query.Length - 5);
            List<IncidentDB> incidents = DBContext.Database.SqlQuery<IncidentDB>(query, 
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", '%' + department + '%'),
                new SqlParameter("detail_location", '%' + detail + '%'),
                new SqlParameter("reason", '%' + reason + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd)).ToList();
            int totalrows = incidents.Count;
            int totalrowsafterfiltering = incidents.Count;
            //sorting
            incidents = incidents.OrderBy(sortColumnName + " " + sortDirection).ToList<IncidentDB>();
            //paging
            incidents = incidents.Skip(start).Take(length).ToList<IncidentDB>();
            foreach (IncidentDB item in incidents)
            {
                item.stringStartTime = item.start_time.ToString("hh:mm tt dd/MM/yyyy");
                item.stringEndTime = item.getEndtime();
                item.stringDiffTime = item.getDiffTime();
                if (item.time_different.ToString() == "") item.editAble = item.incident_id + "^false";
                else item.editAble = item.incident_id + "^true";
            }
            return Json(new { success = true, data = incidents, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-cdvt/su-co/export")]
        public void Export()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/download/su-co.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
                {
                    var incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT e.Equipment_category_id, e.*, i.*, d.department_name FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id inner join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id").ToList();
                    int k = 0;
                    for (int i = 5; i < incidents.Count + 5; i++)
                    {
                        excelWorksheet.Cells[i, 1].Value = (k+1);
                        excelWorksheet.Cells[i, 2].Value = incidents.ElementAt(k).Equipment_category_id;
                        excelWorksheet.Cells[i, 3].Value = incidents.ElementAt(k).equipment_name;
                        excelWorksheet.Cells[i, 4].Value = incidents.ElementAt(k).mark_code;
                        excelWorksheet.Cells[i, 5].Value = incidents.ElementAt(k).equipmentId;
                        excelWorksheet.Cells[i, 6].Value = incidents.ElementAt(k).fabrication_number;
                        excelWorksheet.Cells[i, 7].Value = incidents.ElementAt(k).detail_location;
                        excelWorksheet.Cells[i, 8].Value = incidents.ElementAt(k).department_name;
                        excelWorksheet.Cells[i, 9].Value = incidents.ElementAt(k).start_time.ToString("hh:mm tt dd/MM/yyyy");
                        excelWorksheet.Cells[i, 10].Value = incidents.ElementAt(k).getEndtime();
                        excelWorksheet.Cells[i, 11].Value = incidents.ElementAt(k).getDiffTime();
                        excelWorksheet.Cells[i, 12].Value = incidents.ElementAt(k).reason;
                        k++;
                    }
                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
                    excelPackage.SaveAs(new FileInfo(location + "/su-co_temp.xlsx"));
                }
            }
        }

        [Route("phong-cdvt/su-co/get")]
        [HttpPost]
        public ActionResult GetIncidentById(int incident_id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                IncidentDB incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT e.equipment_name, d.department_name, i.*, DATEDIFF(HOUR, i.start_time, i.end_time) as time_different FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                    "on d.department_id = i.department_id where i.incident_id = @incident_id", new SqlParameter("incident_id", incident_id)).First();
                incidents.stringStartTime = incidents.start_time.ToString("HH mm dd/MM/yyyy");
                DateTime temp;
                DateTime.TryParse(incidents.end_time.ToString(), out temp);
                incidents.stringEndTime = temp.ToString("HH mm dd/MM/yyyy");
                return Json(incidents);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
    }

    public class IncidentDB : Incident
    {
        public int? time_different { get; set; }
        public string equipment_name { get; set; }
        public string department_name { get; set; }
        public string Equipment_category_id { get; set; }
        public string mark_code { get; set; }
        public double fabrication_number { get; set; }
        public string stringStartTime { get; set; }
        public string stringEndTime { get; set; }
        public string stringDiffTime { get; set; }
        public string editAble { get; set; }

        public string getEndtime()
        {
            if (end_time == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(end_time.ToString(), out temp);
                return temp.ToString("hh:mm tt dd/MM/yyyy");
            }
        }

        public string getDiffTime()
        {
            if (end_time == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(end_time.ToString(), out temp);
                TimeSpan timespan = temp.Subtract(start_time);
                string output = "";
                if (timespan.Days != 0) output += timespan.Days + " ngày ";
                if (timespan.Hours != 0) output += timespan.Hours + " giờ ";
                if (timespan.Minutes != 0) output += timespan.Minutes + " phút ";
                return output;
            }
        }
    }
}