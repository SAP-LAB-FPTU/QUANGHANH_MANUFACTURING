﻿using OfficeOpenXml;
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
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Suco
{
    public class SucoThietbiController : Controller
    {
        [Auther(RightID = "79,19,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/su-co")]
        [HttpGet]
        public ActionResult Index()
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            string departID = Session["departID"].ToString();
            List<Equipment> equipments = new List<Equipment>();
            if (departID == "ĐK" || departID == "CV")
                equipments = DBContext.Equipments.ToList();
            else
                equipments = DBContext.Equipments.Where(x => x.department_id.Equals(departID)).ToList();
            List<Department> departments = DBContext.Departments.ToList();
            ViewBag.equipments = equipments;
            ViewBag.departments = departments;
            return View("/Views/CDVT/Suco/SucoThietbi.cshtml");
        }

        [Auther(RightID = "20,79,19,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/su-co/add")]
        [HttpPost]
        public ActionResult Add(string equipment, string reason, string detail, int yearStart, int monthStart, int dayStart, int hourStart, int minuteStart, int yearEnd, int monthEnd, int dayEnd, int hourEnd, int minuteEnd, string checkBox)
        {
            if (reason == "" && checkBox == "no")
                return Json(new { success = false, message = "Thiết bị không thuộc phân xưởng hiện tại" });
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            Incident i = new Incident();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Equipment e = DBContext.Equipments.Find(equipment);
                    string departID = Session["departID"].ToString();
                    if (departID != "CV" && departID != "ĐK" && e.department_id != departID)
                        return Json(new { success = false, message = "Thiết bị không thuộc phân xưởng hiện tại" });
                    if (e.current_Status == 4)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Thiết bị đang có trạng thái hỏng\n không thể thêm sự cố" });
                    }
                    DateTime start = new DateTime(yearStart, monthStart, dayStart, hourStart, minuteStart, 0);
                    DateTime end = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minuteEnd, 0);
                    if (checkBox.Equals("no") && DateTime.Compare(start, end) >= 0)
                        return Json(new { success = false, message = "Bạn đã nhập ngày bắt đầu lớn hơn ngày kết thúc" });
                    i.department_id = e.department_id;
                    i.detail_location = detail;
                    i.equipmentId = equipment;
                    i.reason = reason ?? "";
                    i.start_time = start;
                    i.end_time = end;
                    if (checkBox == "yes")
                    {
                        e.current_Status = 4;
                        i.reason = reason ?? "";
                        i.end_time = null;
                    }

                    DBContext.Incidents.Add(i);
                    DBContext.SaveChanges();

                    Notification nt = new Notification
                    {
                        id_problem = i.incident_id,
                        description = "su co",
                        department_id = i.department_id,
                        date = DateTime.Now.Date,
                        isread = false
                    };
                    DBContext.Notifications.Add(nt);
                    DBContext.SaveChanges();

                    transaction.Commit();
                    return Json(new { success = true, message = "Thêm thành công" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipment + "'").Count() == 0)
                        return Json(new { success = false, message = "Mã thiết bị không tồn tại" });
                    else
                        return Json(new { success = false, message = "Có lỗi xảy ra, xin vui lòng thử lại" });
                }
            }
        }

        [Auther(RightID = "21,79,19,179,180,181,183,184,185,186,187,189,195,003")]
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
                    DateTime start = new DateTime(yearStart, monthStart, dayStart, hourStart, minuteStart, 0);
                    DateTime end = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minuteEnd, 0);
                    if (DateTime.Compare(start, end) >= 0)
                        return Json(new { success = false, message = "Bạn đã nhập ngày bắt đầu lớn hơn ngày kết thúc" });
                    i.department_id = d.department_id;
                    i.detail_location = detail;
                    i.equipmentId = equipment;
                    i.reason = reason;
                    i.start_time = start;
                    i.end_time = end;

                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Chỉnh sửa thành công" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipment + "'").Count() == 0)
                        return Json(new { success = false, message = "Mã thiết bị không tồn tại" });
                    else
                        return Json(new { success = false, message = "Có lỗi xảy ra, xin vui lòng thử lại" });
                }
            }
        }

        [Auther(RightID = "21,79,19,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/su-co/update")]
        [HttpPost]
        public ActionResult Update(int incident_id, string reason, int year, int month, int day, int hour, int minute)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Incident i = DBContext.Incidents.Find(incident_id);
                    DateTime end = new DateTime(year, month, day, hour, minute, 0);
                    if (DateTime.Compare(i.start_time, end) >= 0)
                        return Json(new { success = false, message = "Bạn đã nhập ngày kết thúc nhỏ hơn ngày bắt đầu" });
                    if (i == null)
                    {
                        return Json(new { success = false, message = "Có lỗi xảy ra, xin vui lòng thử lại" });
                    }
                    else
                    {
                        i.reason = reason;
                        i.end_time = new DateTime(year, month, day, hour, minute, 0);
                        DBContext.Database.ExecuteSqlCommand("update Equipment set current_Status = 1 where equipmentId = @equipmentId", new SqlParameter("equipmentId", i.equipmentId));
                        DBContext.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Cập nhật thành công" });
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra, xin vui lòng thử lại" });
                }
            }
        }

        [Route("phong-cdvt/su-co")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string department, string detail, string reason, string dateStart, string dateEnd)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            DateTime dtStart = (dateStart == null || dateStart.Equals("")) ? DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null) : DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            DateTime dtEnd = (dateEnd == null || dateEnd.Equals("")) ? DateTime.Now : DateTime.ParseExact(dateEnd, "dd/MM/yyyy", null);

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            string base_select = "SELECT e.equipment_name, d.department_name, i.*, DATEDIFF(HOUR, i.start_time, i.end_time) as time_different ";
            string query = "FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId " +
                "inner join Department d on d.department_id = i.department_id " +
                "where i.start_time BETWEEN @dtStart AND @dtEnd AND i.equipmentId LIKE @equipmentId AND e.equipment_name LIKE @equipment_name " +
                "AND d.department_name LIKE @department_name AND i.detail_location LIKE @detail_location AND i.reason LIKE @reason";
            string department_id = Session["departID"].ToString();
            if (Session["departName"].ToString().Contains("Phân xưởng")) query += " AND d.department_id = '" + department_id + "'";
            List<IncidentDB> incidents = DBContext.Database.SqlQuery<IncidentDB>(base_select + query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", '%' + department + '%'),
                new SqlParameter("detail_location", '%' + detail + '%'),
                new SqlParameter("reason", '%' + reason + '%'),
                new SqlParameter("dtStart", dtStart),
                new SqlParameter("dtEnd", dtEnd)).ToList();
            int totalrows = DBContext.Database.SqlQuery<int>("select count(e.equipment_name) " + query,
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", '%' + department + '%'),
                new SqlParameter("detail_location", '%' + detail + '%'),
                new SqlParameter("reason", '%' + reason + '%'),
                new SqlParameter("dtStart", dtStart),
                new SqlParameter("dtEnd", dtEnd)).FirstOrDefault();
            foreach (IncidentDB item in incidents)
            {
                item.stringStartTime = item.start_time.ToString("HH:mm dd/MM/yyyy");
                item.stringEndTime = item.getEndtime();
                item.stringDiffTime = item.getDiffTime();
                if (item.time_different.ToString() == "") item.editAble = item.incident_id + "^false";
                else item.editAble = item.incident_id + "^true";
            }
            return Json(new { success = true, data = incidents, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "170,79,19,179,180,181,183,184,185,186,187,189,195,003")]
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
                    //var incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT e.Equipment_category_id, e.*, i.*, d.department_name " +
                    //    "FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId " +
                    //    "inner join Department d on d.department_id = i.department_id " +
                    //    "inner join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id").ToList();
                    var incidents = (from i in DBContext.Incidents
                                     join e in DBContext.Equipments on i.equipmentId equals e.equipmentId
                                     join d in DBContext.Departments on i.department_id equals d.department_id
                                     //join ec in DBContext.Equipment_category on e.Equipment_category_id equals ec.Equipment_category_id
                                     select new IncidentDB
                                     {
                                         Equipment_category_id = e.Equipment_category_id,
                                         equipment_name = e.equipment_name,
                                         mark_code = e.mark_code,
                                         equipmentId = e.equipmentId,
                                         fabrication_number = e.fabrication_number,
                                         detail_location = i.detail_location,
                                         department_name = d.department_name,
                                         start_time = i.start_time,
                                         end_time = i.end_time,
                                         reason = i.reason
                                     }).ToList();
                    int k = 0;
                    for (int i = 5; i < incidents.Count + 5; i++)
                    {
                        excelWorksheet.Cells[i, 1].Value = (k + 1);
                        excelWorksheet.Cells[i, 2].Value = incidents.ElementAt(k).Equipment_category_id;
                        excelWorksheet.Cells[i, 3].Value = incidents.ElementAt(k).equipment_name;
                        excelWorksheet.Cells[i, 4].Value = incidents.ElementAt(k).mark_code;
                        excelWorksheet.Cells[i, 5].Value = incidents.ElementAt(k).equipmentId;
                        excelWorksheet.Cells[i, 6].Value = incidents.ElementAt(k).fabrication_number;
                        excelWorksheet.Cells[i, 7].Value = incidents.ElementAt(k).detail_location;
                        excelWorksheet.Cells[i, 8].Value = incidents.ElementAt(k).department_name;
                        excelWorksheet.Cells[i, 9].Value = incidents.ElementAt(k).start_time.ToString("HH:mm dd/MM/yyyy");
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

        [Auther(RightID = "21,79")]
        [Route("phong-cdvt/su-co/get")]
        [HttpPost]
        public ActionResult GetIncidentById(int incident_id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                IncidentDB incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT e.equipment_name, d.department_name, i.*, DATEDIFF(HOUR, i.start_time, i.end_time) as time_different FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                    "on d.department_id = i.department_id where i.incident_id = @incident_id", new SqlParameter("incident_id", incident_id)).First();
                incidents.stringStartTime = incidents.start_time.ToString("HH:mm dd/MM/yyyy");
                DateTime temp;
                DateTime.TryParse(incidents.end_time.ToString(), out temp);
                incidents.stringEndTime = temp.ToString("HH:mm dd/MM/yyyy");
                return Json(incidents);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra\nxin vui lòng thử lại" }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-cdvt/su-co/getDepartment")]
        [HttpPost]
        public ActionResult getDepartment(string equipmentId)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                Equipment e = DBContext.Equipments.Find(equipmentId);
                Department d = DBContext.Departments.Find(e.department_id);
                return Json(new { success = true, message = d.department_name }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Mã thiết bị không tồn tại\nxin vui lòng thử lại" }, JsonRequestBehavior.AllowGet);
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
        public string fabrication_number { get; set; }
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
                return temp.ToString("HH:mm dd/MM/yyyy");
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