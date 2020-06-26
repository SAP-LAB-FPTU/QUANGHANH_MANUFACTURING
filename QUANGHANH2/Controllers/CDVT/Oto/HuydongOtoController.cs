using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Globalization;
using System.Data.Entity;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Oto
{
    public class HuydongOtoController : Controller
    {
        public class EquipTempSearch
        {
            public string equipmentId { get; set; }
        }

        [HttpPost]
        public ActionResult ChangeID(string id, string ck)
        {
            string sql = "";
            if (ck.Equals("0"))
            {
                sql = @"select e.equipmentId
                        from Equipment e join Car c on e.equipmentId = c.equipmentId
                        where e.equipmentId like @id";
            }
            else if (ck.Equals("1"))
            {
                sql = @"select e.equipment_name as 'equipmentId'
                        from Equipment e join Car c on e.equipmentId = c.equipmentId
                        where e.equipment_name like @id";
            }
            else if (ck.Equals("2"))
            {
                sql = @"select ec.Equipment_category_name as 'equipmentId'
                        from Equipment e join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id
                             join Car c on e.equipmentId = c.equipmentId
                        where ec.Equipment_category_name like @id";
            }
            else if (ck.Equals("3"))
            {
                sql = @"select e.supplier as 'equipmentId'
                        from Equipment e join Car c on e.equipmentId = c.equipmentId
                        where e.supplier like @id";
            }
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<EquipTempSearch> list = db.Database.SqlQuery<EquipTempSearch>(sql, new SqlParameter("id", "%" + id + "%")).Take(10).ToList();
            return Json(new { success = true, id = list }, JsonRequestBehavior.AllowGet);
        }

        public class Temp
        {
            public string abc { get; set; }
        }
        [Auther(RightID ="10")]
        [Route("phong-cdvt/oto/huy-dong")]
        [HttpGet]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Department> listDepeartment = db.Departments.ToList<Department>();
            ViewBag.listDepeartment = listDepeartment;
            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Count().ToString();
            var temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_repair_details dr").ToList<Temp>();
            etk.total_repair = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_maintain_details dr").ToList<Temp>();
            etk.total_maintain = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_big_maintain_details dr").ToList<Temp>();
            etk.total_KD = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_liquidation_details dr").ToList<Temp>();
            etk.total_TL = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_revoke_details dr").ToList<Temp>();
            etk.total_TH = temp.Count().ToString();
            ViewBag.Thongke = etk;
            List<EquipWithName> listID = new List<EquipWithName>();
            ViewBag.listID = listID;
            return View("/Views/CDVT/Car/Huydongoto.cshtml");
        }

        public class EquipThongKe
        {
            public string total { get; set; }
            public string total_repair { get; set; }
            public string total_maintain { get; set; }
            public string total_KD { get; set; }
            public string total_TL { get; set; }
            public string total_TH { get; set; }
        }

        public class EquipWithName : Equipment
        {
            public string sokhung { get; set; }
            public string somay { get; set; }
            public Nullable<Boolean> GPS { get; set; }
            public string GPSstring { get; set; }
            public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
            public string statusname { get; set; }
            public string Equipment_category_name { get; set; }
            public string department_name { get; set; }
        }

        public class EquipAtrr : Category_attribute_value
        {
            public string Equipment_category_attribute_name { get; set; }
        }

        [Route("phong-cdvt/oto/huy-dong/export")]
        public ActionResult export()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
            string filename = "huy-dong-oto.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string sql = @"select e.*, c.sokhung, c.somay, c.GPS, ec.Equipment_category_name, d.Department_Name
                            from Equipment e inner join Car c on e.equipmentId = c.equipmentId
				            inner join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id
				            inner join Department d on e.department_id = d.department_id";
                    var equipList = db.Database.SqlQuery<EquipWithName>(sql).ToList();

                    int k = 2;
                    for (int i = 0; i < equipList.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = equipList.ElementAt(i).equipmentId;
                        excelWorksheet.Cells[k, 2].Value = equipList.ElementAt(i).equipment_name;
                        excelWorksheet.Cells[k, 3].Value = equipList.ElementAt(i).sokhung;
                        excelWorksheet.Cells[k, 4].Value = equipList.ElementAt(i).somay;
                        excelWorksheet.Cells[k, 5].Value = equipList.ElementAt(i).supplier;
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 6].Value = equipList.ElementAt(i).date_import.Value.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 7].Value = equipList.ElementAt(i).depreciation_estimate;
                        excelWorksheet.Cells[k, 8].Value = equipList.ElementAt(i).depreciation_present;
                        excelWorksheet.Cells[k, 9].Value = equipList.ElementAt(i).durationOfInspection_fix;
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 10].Value = equipList.ElementAt(i).durationOfInsurance.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 11].Value = equipList.ElementAt(i).usedDay.Value.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 12].Value = equipList.ElementAt(i).total_operating_hours;
                        excelWorksheet.Cells[k, 13].Value = equipList.ElementAt(i).current_Status;
                        excelWorksheet.Cells[k, 14].Value = equipList.ElementAt(i).mark_code;
                        excelWorksheet.Cells[k, 15].Value = equipList.ElementAt(i).fabrication_number;
                        excelWorksheet.Cells[k, 16].Value = equipList.ElementAt(i).quality_type;
                        excelWorksheet.Cells[k, 17].Value = equipList.ElementAt(i).input_channel;
                        excelWorksheet.Cells[k, 18].Value = equipList.ElementAt(i).Equipment_category_name;
                        excelWorksheet.Cells[k, 19].Value = equipList.ElementAt(i).department_name;
                        k++;
                    }
                    string Flocation = "/excel/CDVT/download/baocaohoatdong.xlsx";
                    string savePath = HostingEnvironment.MapPath(Flocation);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/CDVT/download/baocaohoatdong.xlsx")));
                    return Json(new { success = true, location = Flocation }, JsonRequestBehavior.AllowGet);
                }
                //


            }
        }
        [Auther(RightID = "10")]
        [Route("phong-cdvt/oto/huy-dong/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string department, string quality, string dateStart, string dateEnd, string category, string sup)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = Convert.ToDateTime("01/01/2000");
            DateTime dtEnd = DateTime.Now;
            if (!dateStart.Equals(""))
            {
                string[] date = dateStart.Split('/');
                string date_fix = date[2] + "/" + date[1] + "/" + date[0];
                dtStart = DateTime.ParseExact(date_fix, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            if (!dateEnd.Equals(""))
            {
                string[] date = dateEnd.Split('/');
                string date_fix = date[2] + "/" + date[1] + "/" + date[0];
                dtEnd = DateTime.ParseExact(date_fix, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            string query = @"SELECT e.[equipmentId],e.[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,case when ec.Equipment_category_name is null then '' else ec.Equipment_category_name end as 'Equipment_category_name',a.sokhung, a.somay, a.GPS
                            from Equipment e left outer join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id , Department d, Status s, Car a
                             where a.equipmentId = e.equipmentId and d.department_id != 'kho' and e.department_id = d.department_id AND e.current_Status = s.statusid AND ";


            if (!equipmentId.Equals("") || !equipmentName.Equals("") || !department.Equals("") || !quality.Equals("") || !category.Equals("") || !sup.Equals("") || dateStart != "" || dateEnd != "")
            {
                if (dateStart != "" || dateEnd != "") query += "e.usedDay between @start_time1 and @start_time2 AND ";
                if (!equipmentId.Equals("")) query += "e.equipmentId LIKE @equipmentId AND ";
                if (!equipmentName.Equals("")) query += "e.equipment_name LIKE @equipment_name AND ";
                if (!department.Equals("")) query += "d.department_id = @department_name AND ";
                if (!quality.Equals("")) query += "e.quality_type LIKE @quality AND ";
                if (!category.Equals("")) query += "ec.Equipment_category_name LIKE @cate AND ";
                if (!sup.Equals("")) query += "e.supplier LIKE @sup AND ";
            }
            query = query.Substring(0, query.Length - 5);
            List<EquipWithName> equiplist = DBContext.Database.SqlQuery<EquipWithName>(query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", department),
                new SqlParameter("quality", '%' + quality + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd),
                new SqlParameter("cate", '%' + category + '%'),
                new SqlParameter("sup", '%' + sup + '%')
                ).ToList();
            foreach(var item in equiplist)
            {
                if(item.GPS == null) item.GPSstring = "Mất tín hiệu";
                else
                {
                    if (item.GPS.Value == true) item.GPSstring = "Có tín hiệu";
                    else item.GPSstring = "Mất tín hiệu";
                }
                //if (item.GPS.Value == true) item.GPSstring = "Có tín hiệu";
                //else item.GPSstring = "Mất tín hiệu";
            }
            int totalrows = DBContext.Database.SqlQuery<EquipWithName>(query.Replace("e.[equipmentId],e.[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name,a.sokhung, a.somay, a.GPS", "count(e.[equipmentId])"),
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", department),
                new SqlParameter("quality", '%' + quality + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd),
                new SqlParameter("cate", '%' + category + '%'),
                new SqlParameter("sup", '%' + sup + '%')
                ).Count();

            return Json(new { success = true, data = equiplist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

    }
}